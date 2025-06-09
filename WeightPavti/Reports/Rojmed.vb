Imports WeightPavti.CLS
Public Class Rojmed


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Rojmed")
        item = Dg.Items.Add("RojmedFull")
        item = Dg.Items.Add("RojmedFullDaily")
        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = Format(Now, "dd/MM/yyyy")

        TxtToDate.Text = Format(Now, "dd/MM/yyyy")

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
        'If Dg.Items(0).Selected = False Then
        '    Dg.Items(0).Selected = True
        'End If
        If Dg.SelectedItems(0).SubItems(0).Text = "Rojmed" Then
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
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "RojmedFull" Then
            accountdata()
            ssql = "{" & gRojmel & ".Company_id}=" & clsVariables.CompnyId
            'ssql = ssql & " and {" & gRojmel & ".ip_Address}=" & aq(IPAddress)
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Rojmed"
            clsVariables.ReportName = "NewRojmalReportDaily.rpt"
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
            clsVariables.ReportName = "NewRojmalReportDailydetail.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    Public Sub accountdata()
        Dim ssql As String = ""
        Dim dRunningBalance As Double = 0
        Dim dCloseBalance As Double = 0
        Dim DopnAmt As Double = 0
        ssql = "DELETE FROM " & gRojmel & " where Company_id=" & clsVariables.CompnyId
        ob.Execute(ssql, ob.getconnection())
        'Opening
        'Cash
        'Transaction
        Dim sty As DataTable = ob.Returntable("select * from acdata WHERE     (ACid = 9941) AND (Type in ('Bank Receipt','Bank Payment')) AND (cs IS NULL)", ob.getconnection())
        If sty.Rows.Count > 0 Then
            For i As Integer = 0 To sty.Rows.Count - 1
                ob.Execute("Update Acdata set cs='CASH' where Docno=" & Val(sty.Rows(i).Item("Docno")) & " and Ptype='" & sty.Rows(i).Item("Type") & "' and year_id='" & sty.Rows(i).Item("year_id") & "'", ob.getconnection())
            Next
        End If
        'Opening
        If TxtfromDate.Text = gFinYearBegin Then
            Dim dtt As DataTable = ob.Returntable("select isnull(sum(isnull(dramt-cramt,0)),0) as amt from Acdata where acid=9941 and Docdate='" & ob.DateConversion(TxtfromDate.Text) & "' and type in ('AcOpening','Opening')", ob.getconnection())
            dRunningBalance = Val(dtt.Rows(0).Item("amt"))
        Else
            Dim dtt As DataTable = ob.Returntable("select isnull(sum(isnull(dramt-cramt,0)),0) as amt from Acdata where acid=9941 and Docdate<'" & ob.DateConversion(TxtToDate.Text) & "' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
            dRunningBalance = Val(dtt.Rows(0).Item("amt"))
        End If
        'Cash Data
        Dim dtcr As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and Acid<>9941 and type not in('Bank Receipt','Bank Payment','Transfer','OPENING','Credit','Bank','intrespayment','Mangna')", ob.getconnection())
        'Dim dtdr As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & TxtfromDate.Text & "' and '" & TxtToDate.Text & "' and crid=1 and cramt<>0", ob.getconnection())
        If dtcr.Rows.Count > 0 Then
            For i As Integer = 0 To dtcr.Rows.Count - 1
                Dim sname As String = ob.FindOneString("select member_name from MEMBER_MASTER where Member_Id in (select partyid from Acmain where Billno=" & Val(dtcr.Rows(i).Item("Docno")) & " and ptype='" & dtcr.Rows(i).Item("ptype") & "' and Year_id='" & dtcr.Rows(i).Item("Year_id") & "')", ob.getconnection())
                Dim rems As String = ""
                If sname <> Trim(dtcr.Rows(i).Item("Remarks")) Then
                    rems = Trim(dtcr.Rows(i).Item("Remarks"))
                End If
                If dtcr.Rows(i).Item("ptype") <> "Sales" And dtcr.Rows(i).Item("ptype") <> "Receipt" And dtcr.Rows(i).Item("ptype") <> "Purchase" And dtcr.Rows(i).Item("ptype") <> "intrespayment" Then
                    ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,remarks,Credit_Amt,Debit_amt,Opamt,Sname) Values (1," & dtcr.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcr.Rows(i).Item("Docdate")) & "',1," & Val(dtcr.Rows(i).Item("Docno")) & ",0,N'" & rems & "'," & dtcr.Rows(i).Item("Dramt") & "," & dtcr.Rows(i).Item("cramt") & ",0,N'" & Trim(sname) & "')", ob.getconnection())
                Else
                    ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,Credit_Amt,Debit_amt,Opamt,remarks,Sname) Values (1," & dtcr.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcr.Rows(i).Item("Docdate")) & "',1," & Val(dtcr.Rows(i).Item("Docno")) & ",0," & dtcr.Rows(i).Item("Dramt") & "," & dtcr.Rows(i).Item("cramt") & ",0,'-',N'" & Trim(sname) & "')", ob.getconnection())

                End If
            Next
        End If

        'Bank
        Dim dtcrc As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and  type  in('Bank Receipt','Bank Payment','Transfer','Credit','Bank','intrespayment','Mangna') and cs is null and Acid<>9941", ob.getconnection())
        If dtcrc.Rows.Count > 0 Then
            For i As Integer = 0 To dtcrc.Rows.Count - 1
                Dim sname As String = ob.FindOneString("select member_name from MEMBER_MASTER where Member_Id in (select partyid from Acmain where Billno=" & Val(dtcrc.Rows(i).Item("Docno")) & " and ptype='" & dtcrc.Rows(i).Item("ptype") & "' and Year_id='" & dtcrc.Rows(i).Item("Year_id") & "')", ob.getconnection())
                Dim rems As String = ""
                If sname <> Trim(dtcrc.Rows(i).Item("Remarks")) Then
                    rems = Trim(dtcrc.Rows(i).Item("Remarks"))
                End If
                If dtcrc.Rows(i).Item("ptype") <> "Sales" And dtcrc.Rows(i).Item("ptype") <> "Receipt" And dtcrc.Rows(i).Item("ptype") <> "Purchase" And dtcrc.Rows(i).Item("ptype") <> "intrespayment" Then
                    ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,JK_Credit_Amt,JK_Debit_amt,Debit_amt,Credit_Amt,Opamt,remarks,Sname) Values (1," & dtcrc.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcrc.Rows(i).Item("Docdate")) & "',1," & Val(dtcrc.Rows(i).Item("Docno")) & ",0," & dtcrc.Rows(i).Item("Dramt") & "," & dtcrc.Rows(i).Item("cramt") & ",0,0,0,N'" & Trim(rems) & "',N'" & Trim(sname) & "')", ob.getconnection())
                Else
                    ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,JK_Credit_Amt,JK_Debit_amt,Debit_amt,Credit_Amt,Opamt,remarks,Sname) Values (1," & dtcrc.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcrc.Rows(i).Item("Docdate")) & "',1," & Val(dtcrc.Rows(i).Item("Docno")) & ",0," & dtcrc.Rows(i).Item("Dramt") & "," & dtcrc.Rows(i).Item("cramt") & ",0,0,0,'-',N'" & Trim(sname) & "')", ob.getconnection())
                End If
            Next
        End If

        'bank cash
        Dim dtcrcc As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and CS='CASH' and Acid<>9941 and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        'Dim dtdr As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & TxtfromDate.Text & "' and '" & TxtToDate.Text & "' and crid=1 and cramt<>0", ob.getconnection())
        If dtcrcc.Rows.Count > 0 Then
            For i As Integer = 0 To dtcrcc.Rows.Count - 1
                Dim sname As String = ob.FindOneString("select member_name from MEMBER_MASTER where Member_Id in (select partyid from Acmain where Billno=" & Val(dtcrcc.Rows(i).Item("Docno")) & " and ptype='" & dtcrcc.Rows(i).Item("ptype") & "' and Year_id='" & dtcrcc.Rows(i).Item("Year_id") & "')", ob.getconnection())
                Dim rems As String = ""
                If sname <> Trim(dtcrcc.Rows(i).Item("Remarks")) Then
                    rems = Trim(dtcrcc.Rows(i).Item("Remarks"))
                End If
                ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,remarks,Debit_amt,Credit_Amt,Sname) Values (" & clsVariables.CompnyId & "," & dtcrcc.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcrcc.Rows(i).Item("Docdate")) & "',1," & Val(dtcrcc.Rows(i).Item("Docno")) & ",0,N'" & Trim(rems) & "'," & dtcrcc.Rows(i).Item("Cramt") & "," & dtcrcc.Rows(i).Item("Dramt") & ",N'" & Trim(sname) & "')", ob.getconnection())


            Next
        End If

        'Transfer

        Dim dtcrccd As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' and CS='Bank' and Acid<>9941 and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        'Dim dtdr As DataTable = ob.Returntable("select * from Acdata where Docdate between '" & TxtfromDate.Text & "' and '" & TxtToDate.Text & "' and crid=1 and cramt<>0", ob.getconnection())
        If dtcrccd.Rows.Count > 0 Then
            For i As Integer = 0 To dtcrccd.Rows.Count - 1
                Dim sname As String = ob.FindOneString("select member_name from MEMBER_MASTER where Member_Id in (select partyid from Acmain where Billno=" & Val(dtcrccd.Rows(i).Item("Docno")) & " and ptype='" & dtcrccd.Rows(i).Item("ptype") & "' and Year_id='" & dtcrccd.Rows(i).Item("Year_id") & "')", ob.getconnection())
                Dim rems As String = ""
                If sname <> Trim(dtcrccd.Rows(i).Item("Remarks")) Then
                    rems = Trim(dtcrccd.Rows(i).Item("Remarks"))
                End If
                ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,remarks,JK_Debit_amt,JK_Credit_Amt,Debit_amt,Credit_Amt,Sname) Values (" & clsVariables.CompnyId & "," & dtcrccd.Rows(i).Item("ACid") & ",1,'" & ob.DateConversion(dtcrccd.Rows(i).Item("Docdate")) & "',1," & Val(dtcrccd.Rows(i).Item("Docno")) & ",0,N'" & Trim(rems) & "'," & dtcrccd.Rows(i).Item("Dramt") & "," & dtcrccd.Rows(i).Item("cramt") & ",0,0,N'" & Trim(sname) & "')", ob.getconnection())


            Next
        End If

        'Fees
        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO " & gRojmel & "(Company_Id,Account_id,Column_Id,Doc_Date,Doc_Type,Doc_no,Party_id,remarks,Debit_amt,Credit_Amt,JK_Debit_amt,JK_Credit_Amt,Opamt) Values (1,10,1,'" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "',1," & Val(dtcfee.Rows(i).Item("Docno")) & "," & Val(dtcfee.Rows(i).Item("id")) & ",'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ",0,0,0)", ob.getconnection())
        '    Next
        'End If

        Dim rst As DataTable
        ssql = "SELECT sum(credit_amt) as credit , sum(debit_amt) as debit FROM " & gRojmel & " WHERE doc_no<>0 and company_id = " & clsVariables.CompnyId
        ' ssql = ssql & " and ip_Address=" & aq(IPAddress)
        rst = ob.Returntable(ssql, ob.getconnection(ob.Getconn))
        dCloseBalance = dRunningBalance
        If rst.Rows.Count > 0 Then
            dCloseBalance = dCloseBalance + Val(ob.IfNullThen(rst.Rows(0).Item("Debit"), 0))
            dCloseBalance = dCloseBalance - Val(ob.IfNullThen(rst.Rows(0).Item("Credit"), 0))
        End If
        clsVariables.dOpeningBal = dRunningBalance
        clsVariables.dClosingBal = 0
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(dCloseBalance)
        ob.Execute("Update ROJMEL set JK_Credit_Amt=0 where JK_Credit_Amt is null", ob.getconnection())
        ob.Execute("Update ROJMEL set JK_Debit_amt=0 where JK_Debit_amt is null", ob.getconnection())
        ob.Execute("Update ROJMEL set ip_address='" & IPAddress & "'", ob.getconnection())

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