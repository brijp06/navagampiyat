Imports WeightPavti.CLS
Public Class Acledger


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Account Ledger")
        item = Dg.Items.Add("Account Balance Report")
        item = Dg.Items.Add("Account Ledger Report Cash")


        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = gFinYearBegin

        TxtToDate.Text = gFinYearEnd

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
        'If Dg.Items(0).Selected = False Then
        '    Dg.Items(0).Selected = True
        'End If
        ob.Execute("Delete from tmpACData", ob.getconnection())
        Dim op As Double = ob.FindOneString("select isnull(sum(dramt),0)-isnull(sum(Cramt),0) from Acdata where  Docdate<'" & ob.DateConversion(TxtfromDate.Text) & "' and Acid=" & Val(Acname.Tag) & " and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        Dim ccr As Double = 0
        Dim ddr As Double = 0
        If Val(op) < 0 Then
            ccr = Math.Abs(Val(op))
        Else
            ddr = Math.Abs(Val(op))
        End If
        If (TxtfromDate.Text) <> gFinYearBegin Then
            ob.Execute("Insert Into tmpACData(Cid, Year_id, Type, Docno, Docdate, ACid, Acname,Cramt, Remarks,Dramt) Values(1,'" & (clsVariables.WorkingYear) & "','Opening',0,'" & ob.DateConversion(TxtfromDate.Text) & "'," & Val(Acname.Tag) & ",'-'," & Val(ccr) & ",'-'," & Val(ddr) & ")", ob.getconnection())
        End If
        ob.Execute("Insert Into tmpACData SELECT  Cid, Year_id, Type, Docno, Docdate, ACid, Acname, sum(Cramt), Remarks, sum(Dramt), ptype,cs,Department, tid  FROM Acdata where  Year_id='" & clsVariables.WorkingYear & "' and Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'  group by Cid, Year_id, Type, Docno, Docdate, ACid, Acname, Remarks,ptype,cs,Department, tid", ob.getconnection())
        ob.Execute("update tmpACData set tid=0 where type='Opening'", ob.getconnection())
        ob.Execute("update tmpACData set tid=1 where type<>'Opening'", ob.getconnection())



        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",10,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ")", ob.getconnection())
        '    Next
        'End If

        If Dg.SelectedItems(0).SubItems(0).Text = "Account Ledger" Then
            'ssql = "{ACData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            'ssql = ssql & " and {ACData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            'If Val(Acname.Tag) > 0 Then
            '    ssql = ssql & " and {ACData.ACId}=" & Val(Acname.Tag) & ""
            'End If
            ssql = "{tmpAcdata.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {tmpAcdata.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(Acname.Tag) > 0 Then
                ssql = ssql & " and {tmpAcdata.ACId}=" & Val(Acname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Account Ledger"
            clsVariables.ReportName = "FinalAccountLedgerReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Account Balance Report" Then
            'ssql = "{ACData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            'ssql = ssql & " and {ACData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            'If Val(Acname.Tag) > 0 Then
            '    ssql = ssql & " and {ACData.ACId}=" & Val(Acname.Tag) & ""
            'End If
            ssql = "{tmpAcdata.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {tmpAcdata.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(Acname.Tag) > 0 Then
                ssql = ssql & " and {tmpAcdata.ACId}=" & Val(Acname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Account Ledger"
            clsVariables.ReportName = "FinalAccountBalanceReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else

            ssql = "{tmpAcdata.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {tmpAcdata.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(Acname.Tag) > 0 Then
                ssql = ssql & " and {tmpAcdata.ACId}=" & Val(Acname.Tag) & ""
            End If
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Account Ledger"
            clsVariables.ReportName = "FinalAccountLedgerReportCash.rpt"
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
            Acname.Tag = ob.FindOneinteger("select account_id from account_master where Account_name=N'" & Trim(Acname.Text) & "' or account_id=" & Val(Acname.Text) & "", ob.getconnection())
            Acname.Text = ob.FindOneString("select Account_name from account_master where account_id=" & Val(Acname.Tag) & "", ob.getconnection())
        End If
    End Sub
End Class



