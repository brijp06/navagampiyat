Imports WeightPavti.CLS
Public Class MonthlyReport


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Monthly Report")
        '  item = Dg.Items.Add("RojmedFull")
        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = Format(Now, "dd/MM/yyyy")

        ' TxtToDate.Text = Format(Now, "dd/MM/yyyy")

    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        itemname.AutoCompleteMode = AutoCompleteMode.Suggest
        itemname.AutoCompleteSource = AutoCompleteSource.CustomSource
        itemname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autotwo()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        Tomonth.AutoCompleteMode = AutoCompleteMode.Suggest
        Tomonth.AutoCompleteSource = AutoCompleteSource.CustomSource
        Tomonth.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autoname()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        txtproduct.AutoCompleteMode = AutoCompleteMode.Suggest
        txtproduct.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtproduct.AutoCompleteCustomSource = AutoComp
    End Sub
    Private Sub txtproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproduct.Validated
        If txtproduct.Text <> "" Then
            If IsNumeric(txtproduct.Text) Then
                Dim trn As DataTable = ob.Returntable("Select * from Transfer Where Houseno=" & txtproduct.Text & " Order By Tharavno desc", ob.getconnection())
                If trn.Rows.Count > 0 Then
                    txtproduct.Text = trn.Rows(0).Item("tname")
                    txtproduct.Tag = trn.Rows(0).Item("tid")
                Else
                    txtproduct.Tag = ob.FindOneinteger("select Party_id From Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                    txtproduct.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                End If
                'lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & txtproduct.Tag & "", ob.getconnection())
            Else
                Dim dt As DataTable = ob.Returntable("select gstno From Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                If dt.Rows.Count >= 2 Then
                    If dg1.Rows.Count > 0 Then
                        dg1.Rows.Clear()
                    End If
                    Panel1.Visible = True
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dg1.Rows.Add()
                        dg1.Rows(dg1.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("gstno")
                    Next
                    Exit Sub
                Else
                    txtproduct.Tag = ob.FindOneinteger("Select Party_id from Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                End If
                '  lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & txtproduct.Tag & "", ob.getconnection())
            End If
            'autonn()
            'utstnding()
            'loaddg()
        End If
    End Sub

    Private Sub itemname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemname.Validated
        If itemname.Text <> "" Then
            itemname.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & itemname.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ssql As String = ""
        clsVariables.dOpeningBal = 0
        clsVariables.dClosingBal = 0
        If Dg.Items(0).Selected = False Then
            Dg.Items(0).Selected = True
        End If
        If Dg.SelectedItems(0).SubItems(0).Text = "Monthly Report" Then
            accountdata()
            ssql = ""
            ' ssql = "{" & gRojmel & ".Company_id}=" & clsVariables.CompnyId
            'ssql = ssql & " and {" & gRojmel & ".ip_Address}=" & aq(IPAddress)
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Monthly Report"
            clsVariables.ReportName = "MonthlyReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else
            accountdata()
            ssql = "{" & gRojmel & ".Company_id}=" & clsVariables.CompnyId
            'ssql = ssql & " and {" & gRojmel & ".ip_Address}=" & aq(IPAddress)
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Rojmed"
            clsVariables.ReportName = "NewRojmalReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    Public Sub accountdata()
        ob.Execute("delete from tmpmonth", ob.getconnection())
        Dim dt As New DataTable
        If chkcash.Checked = False Then

            If Trim(ComboMemberType.Text) <> "" Then
                dt = ob.Returntable("select * from MonthlyReport where Department='" & Trim(ComboMemberType.Text) & "' and Billdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and Billtype='Bank'", ob.getconnection())
            Else
                dt = ob.Returntable("select * from MonthlyReport where Billdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and Billtype='Bank'", ob.getconnection())
            End If
        Else
            dt = ob.Returntable("select * from MonthlyReport where  Billdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and Billtype='Cash'", ob.getconnection())

        End If
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim th As Double = 0
                Dim mud As Double = 0
                Dim ints As Double = 0
                Dim sh As Double = 0
                Dim tha As Double = 0
                Dim kl As Double = 0
                If dt.Rows(i).Item("Acid") = 2 Then
                    sh = dt.Rows(i).Item("Receiptamt")
                ElseIf dt.Rows(i).Item("Acid") = 3 Then
                    tha = dt.Rows(i).Item("Receiptamt")
                ElseIf dt.Rows(i).Item("Acid") = 4 Then
                    kl = dt.Rows(i).Item("Receiptamt")
                ElseIf dt.Rows(i).Item("Acid") = 20 Then
                    mud = dt.Rows(i).Item("Receiptamt")
                    ints = dt.Rows(i).Item("Intamt")
                    th = ob.FindOneString("select sum(Paymentamt)-sum(Receiptamt) from Acmain where PartyId=" & Val(dt.Rows(i).Item("Member_id")) & " and Clid=1", ob.getconnection())
                    th = Val(th) + Val(mud)
                End If

                ob.Execute("Insert Into tmpmonth(Type, id, sName, tdhiran, mudal, Int, share, thapanamt, kal) values('" & Trim(dt.Rows(i).Item("Department")) & "'," & dt.Rows(i).Item("Member_id") & ",N'" & dt.Rows(i).Item("Member_Name") & "'," & Val(th) & "," & Val(mud) & "," & Val(ints) & "," & Val(sh) & "," & Val(tha) & "," & Val(kl) & ")", ob.getconnection())
            Next
        End If

    End Sub

    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtfromDate.Focus()
        End If
    End Sub

    Private Sub TxtfromDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToDate.KeyDown, txtproduct.KeyDown, TxtfromDate.KeyDown, itemname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then
            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub dg1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellDoubleClick

        'lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
       

        Dim gst As String = dg1.Rows(e.RowIndex).Cells(0).Value
        txtproduct.Tag = ob.FindOneString("Select Party_id from Party_master where gstno=" & gst & "", ob.getconnection())
        Panel1.Visible = False
        itemname.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel1.Visible = False
        txtproduct.Clear()
        txtproduct.Focus()
    End Sub

    Private Sub TxtfromDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtfromDate.Validating
        If TxtfromDate.Text <> "" Then
            TxtToDate.Text = TxtfromDate.Text
        End If
    End Sub
End Class