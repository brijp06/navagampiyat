Imports WeightPavti.CLS
Public Class PurchaseReport


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Purchase Detail Report")
        item = Dg.Items.Add("Bhandar Purchase Detail Report")
        item = Dg.Items.Add("purchase summary Report")

        '  item = Dg.Items.Add("MalAvak Summary Report")

        'item = Dg.Items.Add("Account Ledger Report Cash")


        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = Format(Now, "dd/MM/yyyy") '"01/04/2020"
        autogroup()
        TxtToDate.Text = Format(Now, "dd/MM/yyyy")

    End Sub
    Public Sub autotwo()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Member_name from Member_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Member_name"))
        Next
        Membname.AutoCompleteMode = AutoCompleteMode.Suggest
        Membname.AutoCompleteSource = AutoCompleteSource.CustomSource
        Membname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autogroup()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Product_id,Product_Name from Product_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Product_Name"))
        Next
        groupname.AutoCompleteMode = AutoCompleteMode.Suggest
        groupname.AutoCompleteSource = AutoCompleteSource.CustomSource
        groupname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_name from Account_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_name"))
        Next
        groupname.AutoCompleteMode = AutoCompleteMode.Suggest
        groupname.AutoCompleteSource = AutoCompleteSource.CustomSource
        groupname.AutoCompleteCustomSource = AutoComp
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
        'clsVariables.dOpeningBal = 0
        'clsVariables.dClosingBal = 0
        'If Dg.Items(0).Selected = False Then
        '    Dg.Items(0).Selected = True
        'End If
        ' ob.Execute("Delete from tmpACData", ob.getconnection())
        'ob.Execute("Insert Into tmpACData select * from ACData where Year_id='" & clsVariables.WorkingYear & "' and Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'", ob.getconnection())
        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",10,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ")", ob.getconnection())
        '    Next
        'End If

        '   If Dg.SelectedItems(0).SubItems(0).Text = "Account Ledger" Then
        'ssql = "{ACData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
        'ssql = ssql & " and {ACData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
        'If Val(Acname.Tag) > 0 Then
        '    ssql = ssql & " and {ACData.ACId}=" & Val(Acname.Tag) & ""  
        'End If
        If Dg.SelectedItems(0).SubItems(0).Text = "Purchase Detail Report" Then
            ssql = "{Acmain.Billdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {Acmain.Billdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            ssql = ssql & " and {Acmain.Ptype}='Purchase'"
            ssql = ssql & " and {Acmain.Department}='" & Trim(Cmbdepartment.Text) & "'"
            If Val(Membname.Tag) <> 0 Then
                ssql = ssql & " and {Acmain.Partyid}=" & Val(Membname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Purchase Report"
            clsVariables.ReportName = "PurchaseDetailReport.rpt"
            Dim frm As New Reportform
            frm.Show()
            'Bhandar Purchase Detail Report
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Bhandar Purchase Detail Report" Then
            ssql = "{Acmain.Billdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {Acmain.Billdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            ssql = ssql & " and {Acmain.Ptype}='Purchase'"
            ssql = ssql & " and {Acmain.Department}='Bhandar'"
            If Val(groupname.Tag) <> 0 Then
                ssql = ssql & " and {Item_master.Quality_id}=" & Val(groupname.Tag)
            End If
            If Val(Membname.Tag) <> 0 Then
                ssql = ssql & " and {Acmain.Partyid}=" & Val(Membname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Bhandar Purchase Report"
            clsVariables.ReportName = "BhandarPurchaseReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else
            ssql = "{Acmain.Billdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {Acmain.Billdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            ssql = ssql & " and {Acmain.Ptype}='Purchase'"
            ssql = ssql & " and {Acmain.Department}='" & Cmbdepartment.Text & "'"
            If Val(Membname.Tag) <> 0 Then
                ssql = ssql & " and {Acmain.Partyid}=" & Val(Membname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Purchase summary Report"
            clsVariables.ReportName = "PurchaseSummaryreport.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"


    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtfromDate.Focus()
        End If
    End Sub

    Private Sub TxtfromDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToDate.KeyDown, txtproduct.KeyDown, TxtfromDate.KeyDown, itemname.KeyDown, groupname.KeyDown
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

    Private Sub Acname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupname.Validated
        groupname.Tag = ob.FindOneString("select Product_Id from Product_Master Where Product_Id=" & Val(groupname.Text) & " or Product_Name=N'" & Trim(groupname.Text) & "'", ob.getconnection())
        If Val(groupname.Tag) <> 0 Then
            groupname.Text = ob.FindOneString("select Product_Name from Product_Master Where Product_Id=" & groupname.Tag & " ", ob.getconnection())

        End If
    End Sub

    Private Sub Membname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Membname.Validating
        Membname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Membname.Text) & "' or Member_Id=" & Val(Membname.Text) & "", ob.getconnection())
        If Val(Membname.Tag) <> 0 Then
            Membname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Membname.Tag) & "", ob.getconnection())
        End If
    End Sub
End Class