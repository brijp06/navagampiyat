Imports WeightPavti.CLS
Public Class TarijReport


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Tarij Report")
        'item = Dg.Items.Add("Account Balance Report")

        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = gFinYearBegin

        TxtToDate.Text = Format(Now, "dd/MM/yyyy")

    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_name from Account_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_name"))
        Next
        Acname.AutoCompleteMode = AutoCompleteMode.Suggest
        Acname.AutoCompleteSource = AutoCompleteSource.CustomSource
        Acname.AutoCompleteCustomSource = AutoComp
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
        If Dg.SelectedItems(0).SubItems(0).Text = "Tarij Report" Then
            tarij()
            ssql = "{Final_tarij_Report.Company_id}=" & clsVariables.CompnyId
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Tarij Report"
            clsVariables.ReportName = "FinaltarijReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    Public Sub tarij()
        Dim ssql As String = ""
        Dim dDebitSum As Double
        Dim dCreditSum As Double
        Dim srst As New DataTable
        Dim rst As New DataTable
        ' Dim Ssql As String
        Dim dOpeningBalance As Double
        Dim dClosingBalance As Double
        Dim dRunningBalance As Double

        ssql = "DELETE FROM Final_Tarij_Report where Company_id=" & clsVariables.CompnyId
        ob.Execute(ssql, ob.getconnection(ob.Getconn))
        ob.Execute("Delete from tmpACData", ob.getconnection())
        ob.Execute("Insert Into tmpACData select * from ACData where Year_id='" & clsVariables.WorkingYear & "' and Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'", ob.getconnection())

        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",10,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ")", ob.getconnection())
        '    Next
        'End If
        Dim cr As String = ob.FindOneString("Select isnull(sum(Cramt),0)-isnull(sum(Dramt),0) from tmpACData where Docdate<'" & ob.DateConversion(TxtfromDate.Text) & "' and type in ('Cash Receipt','Cash Payment') and Docno<>0", ob.getconnection())
        Dim ccr As String = ob.FindOneString("Select isnull(sum(Cramt),0)-isnull(sum(Dramt),0) from tmpACData where acid=9941 and type in ('AcOpening','Opening')", ob.getconnection())
        ccr = Math.Abs(Val(ccr))
        ' Dim dr As String = ob.FindOneString("Select isnull(sum(Dramt),0) from tmpACData where Acid=1 and Docdate<'" & ob.DateConversion(TxtfromDate.Text) & "'", ob.getconnection())
        Dim acname As String = ob.FindOneString("Select Account_name from Account_master where Account_id=9941", ob.getconnection())
        dRunningBalance = Val(cr) + Val(ccr)
        dOpeningBalance = dRunningBalance

        Dim dtcr As DataTable = ob.Returntable("select ACid,sum(cramt) as cr,sum(dramt) as dr from tmpACData where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and acid<>9941  and type<>'Opening'  Group by acid", ob.getconnection())

        If dtcr.Rows.Count > 0 Then
            For i As Integer = 0 To dtcr.Rows.Count - 1
                Dim bal As Double = 0
                bal = Math.Abs(dtcr.Rows(i).Item("cr") - dtcr.Rows(i).Item("Dr"))
                ob.Execute("INSERT INTO Final_Tarij_Report(Company_id,Account_Id,Debit_Amount,Credit_Amount,Balance_Amount) Values(1," & dtcr.Rows(i).Item("ACid") & "," & dtcr.Rows(i).Item("dr") & "," & dtcr.Rows(i).Item("cr") & "," & bal & ")", ob.getconnection())
            Next
        End If



        'Dim dtcrd As DataTable = ob.Returntable("select ACid,sum(cramt) as cr,sum(dramt) as dr from tmptmpACData where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and acid<>1 and Docno<>0 and type<>'Opening'  Group by acid", ob.getconnection())

        'If dtcrd.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcrd.Rows.Count - 1
        '        Dim bal As Double = 0
        '        bal = Math.Abs(dtcrd.Rows(i).Item("cr") - dtcrd.Rows(i).Item("Dr"))
        '        ob.Execute("INSERT INTO Final_Tarij_Report(Company_id,Account_Id,Debit_Amount,Credit_Amount,Balance_Amount) Values(1," & dtcrd.Rows(i).Item("ACid") & "," & dtcrd.Rows(i).Item("dr") & "," & dtcrd.Rows(i).Item("cr") & "," & bal & ")", ob.getconnection())
        '    Next
        'End If

        dClosingBalance = ob.FindOneString("Select isnull(sum(Cramt),0)-isnull(sum(Dramt),0) from tmpACData where Docdate<='" & ob.DateConversion(TxtToDate.Text) & "' and acid in (9941)", ob.getconnection())

        clsVariables.dClosingBal = Math.Abs(dClosingBalance)
        clsVariables.dOpeningBal = dOpeningBalance


    End Sub

    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtfromDate.Focus()
        End If
    End Sub

    Private Sub TxtfromDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToDate.KeyDown, txtproduct.KeyDown, TxtfromDate.KeyDown, itemname.KeyDown, Acname.KeyDown
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
        
    End Sub

    Private Sub Acname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Acname.Validated
        If Acname.Text <> "" Then
            Acname.Tag = ob.FindOneinteger("select account_id from account_master where Account_name='" & Acname.Text & "'", ob.getconnection())
        End If
    End Sub
End Class