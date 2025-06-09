Imports WeightPavti.CLS
Public Class BalanceSheet


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("BalanceSheet Guj")
        item = Dg.Items.Add("BalanceSheet T Format")

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
        If Dg.SelectedItems(0).SubItems(0).Text = "BalanceSheet Guj" Then
            tarij()
            ssql = "{Account_group_master.Final_Report_Type}='Balance Sheet'"
            ssql = ssql & " and {Joint_Trial_Balance.Company_id}=" & clsVariables.CompnyId
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Balance Sheet Report"
            clsVariables.ReportName = "FinalBalanceSheet.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else
            tarij()
            ssql = "{Ac_group_master.Final_Report_Type}='Balance Sheet'"
            ssql = ssql & " and {Joint_Trial_Balance.Company_id}=" & clsVariables.CompnyId
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Balance Sheet Report"
            clsVariables.ReportName = "JointBalanceSheetTFormat.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    Public Sub tarij()
        Dim ssql As String = ""
           ' Dim Ssql As String
    

        ssql = "DELETE FROM Joint_Trial_Balance where Company_id=" & clsVariables.CompnyId
        ob.Execute(ssql, ob.getconnection(ob.Getconn))

        ob.Execute("Delete from tmpACData", ob.getconnection())
        ob.Execute("Insert Into tmpACData select * from ACData where Year_id='" & clsVariables.WorkingYear & "' and Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'", ob.getconnection())

        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",10,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ")", ob.getconnection())
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",1,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Dramt") & "," & dtcfee.Rows(i).Item("Amount") & ")", ob.getconnection())
        '    Next
        'End If

        Dim dtcr As DataTable = ob.Returntable("select ACid,sum(cramt) as cr,sum(dramt) as dr from tmpAcdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'   Group by acid", ob.getconnection())

        If dtcr.Rows.Count > 0 Then
            For i As Integer = 0 To dtcr.Rows.Count - 1
                Dim bal As Double = 0
                'bal = Val(dtcr.Rows(i).Item("cr")) - Val(dtcr.Rows(i).Item("Dr"))
                'If bal > 0 Then
                ob.Execute("INSERT INTO Joint_Trial_Balance(Company_id,Account_Id,HO_Dr,Ho_Cr) Values(1," & dtcr.Rows(i).Item("ACid") & "," & dtcr.Rows(i).Item("dr") & "," & dtcr.Rows(i).Item("cr") & ")", ob.getconnection())
                'Else
                'ob.Execute("INSERT INTO Joint_Trial_Balance(Company_id,Account_Id,HO_Dr,Ho_Cr) Values(1," & dtcr.Rows(i).Item("ACid") & "," & Math.Abs(bal) & ",0)", ob.getconnection())

                'End If
            Next
        End If
        Dim dGrossProfitLoss As Double
        dGrossProfitLoss = 0
        Dim rst As New DataTable

        ssql = "SELECT sum(ho_cr) as Credit,sum(ho_dr) as debit FROM Joint_Trial_Balance as jtb,"
        ssql = ssql & "Account_Group_Master as agm,Account_Master  as am "
        ssql = ssql & " WHERE jtb.company_id = " & clsVariables.CompnyId
        ssql = ssql & " and jtb.Company_id = am.Company_id and jtb.Account_id = am.Account_id and am.Company_id = agm.Company_id "
        ssql = ssql & " and am.Group_id = agm.Group_id and Final_Report_type <> 'Balance Sheet'"
        rst = ob.Returntable(ssql, ob.getconnection(ob.Getconn))

        If rst.Rows.Count > 0 Then
            dGrossProfitLoss = dGrossProfitLoss + Val(ob.IfNullThen(rst.Rows(0).Item("Credit"), 0))
            dGrossProfitLoss = dGrossProfitLoss - Val(ob.IfNullThen(rst.Rows(0).Item("Debit"), 0))
        End If
        If dGrossProfitLoss > 0 Then
            clsVariables.dOpeningBal = dGrossProfitLoss
        Else
            clsVariables.dClosingBal = Math.Abs(dGrossProfitLoss)
        End If
       

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