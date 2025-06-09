Imports WeightPavti.CLS
Public Class StockReport

    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Party Ledgure Report Detail")
        item = Dg.Items.Add("Party Ledgure Report")
        item = Dg.Items.Add("Party Outstanding Report")
        item = Dg.Items.Add("Register")
        item = Dg.Items.Add("Register Detail")
        item = Dg.Items.Add("Free")
        item = Dg.Items.Add("Month Wise Report") 'yearwise
        item = Dg.Items.Add("Year Wise Report")
        item = Dg.Items.Add("House Detail Report")
        item = Dg.Items.Add("House Transfer Report")

        dg1.Columns.Add("", "")
        Panel1.Visible = False
        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = "01/04/2013"
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
        Dim ssql As String
        If Dg.SelectedItems(0).SubItems(0).Text = "Party Ledgure Report Detail" Then
            ssql = "{SData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {SData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(txtproduct.Tag) > 0 Then
                ssql = ssql & " and {SData.Id}=" & Val(txtproduct.Tag) & ""
            End If
            If Val(itemname.Tag) > 0 Then
                ssql = ssql & " and {SData.Fromid}=" & Val(itemname.Tag) & ""
            End If
            If Val(Tomonth.Tag) > 0 Then
                ssql = ssql & " and {SData.Toid}=" & Val(Tomonth.Tag) & ""
            End If
            ssql = ssql & " and {SData.Type}<>'FREE'"

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Ledgure Report"
            clsVariables.ReportName = "PartyLedgure.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "House Detail Report" Then
            ssql = ""
            If Val(txtproduct.Tag) > 0 Then
                Dim idd As String = ob.FindOneString("Select Gstno from Party_Master Where party_name='" & txtproduct.Text & "'", ob.getconnection())
                ssql = "{Housedetail.Id}=" & Val(idd) & ""
            Else
                ssql = ""
            End If

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "House Detail Report"
            clsVariables.ReportName = "Housedetail.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "House Transfer Report" Then
            ssql = ""
            If Val(txtproduct.Tag) > 0 Then
                Dim idd As String = ob.FindOneString("Select Gstno from Party_Master Where party_name='" & txtproduct.Text & "'", ob.getconnection())
                ssql = "{Transfer.Houseno}=" & Val(idd) & ""
            Else
                ssql = ""
            End If

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "House Transfer Report"
            clsVariables.ReportName = "HouseTransfer.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Party Outstanding Report" Then
            ssql = ""
            Dim op As Boolean = False
            ob.Execute("delete from tmpout", ob.getconnection())
            Dim dt As DataTable
            If txtproduct.Text <> "" Then
                dt = ob.Returntable("Select * from Party_master where party_id=" & txtproduct.Tag & "", ob.getconnection())
            Else
                dt = ob.Returntable("Select * from Party_master Order by party_id", ob.getconnection())
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dts As DataTable
                Dim asp As DataTable = ob.Returntable("select * from Opening where Party_id=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                If asp.Rows.Count > 0 Then
                    op = True
                Else
                    op = False
                End If
                If op = False Then
                    Dim trs As DataTable = ob.Returntable("select * from Transfer Where fid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                    If trs.Rows.Count > 0 Then
                        dts = ob.Returntable("select * from month where Id<=" & trs.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())

                    Else
                        Dim lst As DataTable = ob.Returntable("select * from Transfer Where tid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                        If lst.Rows.Count > 0 Then
                            dts = ob.Returntable("select * from month where Id>" & lst.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())
                        Else
                            dts = ob.Returntable("select * from month Order by Id", ob.getconnection())
                        End If
                    End If
                Else
                        dts = ob.Returntable("select * from month where Id>" & asp.Rows(0).Item("Opyear") & " Order by Id", ob.getconnection())
                        op = False
                End If
                For j As Integer = 0 To dts.Rows.Count - 1
                    Dim rks As DataTable = ob.Returntable("select * from sdata where id=" & dt.Rows(i).Item("party_id") & " and Fromid=" & dts.Rows(j).Item("ID") & "", ob.getconnection())
                    If rks.Rows.Count > 0 Then
                    Else
                        ob.Execute("Insert Into tmpOut(Id, Name, Month, Amount,mid,Hsno) Values(" & dt.Rows(i).Item("party_id") & ",'" & dt.Rows(i).Item("Party_name") & "','" & dts.Rows(j).Item("Monthname") & "'," & dts.Rows(j).Item("Amount") & "," & dts.Rows(j).Item("Id") & "," & dt.Rows(i).Item("gstno") & ")", ob.getconnection())
                    End If
                Next
            Next
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Outstanding Report"
            clsVariables.ReportName = "PartyOutStanding.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Year Wise Report" Then
            ssql = ""
            Dim op As Boolean = False
            ob.Execute("delete from tmpout", ob.getconnection())
            Dim dt As DataTable
            If txtproduct.Text <> "" Then
                dt = ob.Returntable("Select * from Party_master where party_id=" & txtproduct.Tag & "", ob.getconnection())
            Else
                dt = ob.Returntable("Select * from Party_master Order by party_id", ob.getconnection())
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dts As DataTable
                Dim asp As DataTable = ob.Returntable("select * from Opening where Party_id=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                If asp.Rows.Count > 0 Then
                    op = True
                Else
                    op = False
                End If
                If op = False Then
                    Dim trs As DataTable = ob.Returntable("select * from Transfer Where fid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                    If trs.Rows.Count > 0 Then
                        dts = ob.Returntable("select * from month where Id<=" & trs.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())

                    Else
                        Dim lst As DataTable = ob.Returntable("select * from Transfer Where tid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                        If lst.Rows.Count > 0 Then
                            dts = ob.Returntable("select * from month where Id>" & lst.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())
                        Else
                            dts = ob.Returntable("select * from month Order by Id", ob.getconnection())
                        End If
                    End If
                Else
                    dts = ob.Returntable("select * from month where Id>" & asp.Rows(0).Item("Opyear") & " Order by Id", ob.getconnection())
                    op = False
                End If
                For j As Integer = 0 To dts.Rows.Count - 1
                    Dim rks As DataTable = ob.Returntable("select * from sdata where id=" & dt.Rows(i).Item("party_id") & " and Fromid=" & dts.Rows(j).Item("ID") & "", ob.getconnection())
                    If rks.Rows.Count > 0 Then
                    Else
                        ob.Execute("Insert Into tmpOut(Id, Name, Month, Amount,mid,Hsno) Values(" & dt.Rows(i).Item("party_id") & ",'" & dt.Rows(i).Item("Party_name") & "','" & dts.Rows(j).Item("Monthname") & "'," & dts.Rows(j).Item("Amount") & "," & dts.Rows(j).Item("Id") & "," & dt.Rows(i).Item("gstno") & ")", ob.getconnection())
                    End If
                Next
            Next
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Outstanding Report"
            clsVariables.ReportName = "Yearwise.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Register" Then
            ssql = "{SData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {SData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(txtproduct.Tag) > 0 Then
                ssql = ssql & " and {SData.Id}=" & Val(txtproduct.Tag) & ""
            End If
            If Val(itemname.Tag) > 0 Then
                ssql = ssql & " and {SData.Fromid}=" & Val(itemname.Tag) & ""
            End If
            If Val(Tomonth.Tag) > 0 Then
                ssql = ssql & " and {SData.Toid}=" & Val(Tomonth.Tag) & ""
            End If
            ssql = ssql & " and {SData.Type}='CR'"

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Register"
            clsVariables.ReportName = "Register.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Register Detail" Then
            ssql = "{SData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {SData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(txtproduct.Tag) > 0 Then
                ssql = ssql & " and {SData.Id}=" & Val(txtproduct.Tag) & ""
            End If
            If Val(itemname.Tag) > 0 Then
                ssql = ssql & " and {SData.Fromid}=" & Val(itemname.Tag) & ""
            End If
            If Val(Tomonth.Tag) > 0 Then
                ssql = ssql & " and {SData.Toid}=" & Val(Tomonth.Tag) & ""
            End If
            ssql = ssql & " and {SData.Type}='CR'"

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Register Detail"
            clsVariables.ReportName = "Registerdetail.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Party Ledgure Report" Then
            ssql = "{SData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {SData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(txtproduct.Tag) > 0 Then
                ssql = ssql & " and {SData.Id}=" & Val(txtproduct.Tag) & ""
            End If
            If Val(itemname.Tag) > 0 Then
                ssql = ssql & " and {SData.Fromid}=" & Val(itemname.Tag) & ""
            End If
            If Val(Tomonth.Tag) > 0 Then
                ssql = ssql & " and {SData.Toid}=" & Val(Tomonth.Tag) & ""
            End If
            ssql = ssql & " and {SData.Type}<>'FREE'"

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Ledgure Report"
            clsVariables.ReportName = "PLed.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Free" Then
            ssql = "{SData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
            ssql = ssql & " and {SData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
            If Val(txtproduct.Tag) > 0 Then
                ssql = ssql & " and {SData.Id}=" & Val(txtproduct.Tag) & ""
            End If
            If Val(itemname.Tag) > 0 Then
                ssql = ssql & " and {SData.Fromid}=" & Val(itemname.Tag) & ""
            End If
            If Val(Tomonth.Tag) > 0 Then
                ssql = ssql & " and {SData.Toid}=" & Val(Tomonth.Tag) & ""
            End If
            ssql = ssql & " and {SData.Type}='FREE'"

            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Ledgure Report"
            clsVariables.ReportName = "Free.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Month Wise Report" Then
            ssql = ""
            Dim op As Boolean = False
            ob.Execute("delete from Detailreport", ob.getconnection())
            Dim dt As DataTable
            If txtproduct.Text <> "" Then
                dt = ob.Returntable("Select * from Party_master where party_id=" & txtproduct.Tag & "", ob.getconnection())
            Else
                dt = ob.Returntable("Select * from Party_master Order by party_id", ob.getconnection())
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dts As DataTable
                Dim asp As DataTable = ob.Returntable("select * from Opening where Party_id=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                If asp.Rows.Count > 0 Then
                    op = True
                Else
                    op = False
                End If
                If op = False Then
                    Dim trs As DataTable = ob.Returntable("select * from Transfer Where fid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                    If trs.Rows.Count > 0 Then
                        dts = ob.Returntable("select * from month where Id<=" & trs.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())

                    Else
                        Dim lst As DataTable = ob.Returntable("select * from Transfer Where tid=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
                        If lst.Rows.Count > 0 Then
                            dts = ob.Returntable("select * from month where Id>" & lst.Rows(0).Item("Mid") & " Order by Id", ob.getconnection())
                        Else
                            dts = ob.Returntable("select * from month Order by Id", ob.getconnection())
                        End If
                    End If
                Else
                    dts = ob.Returntable("select * from month where Id>" & asp.Rows(0).Item("Opyear") & " Order by Id", ob.getconnection())
                    op = False
                End If
                For j As Integer = 0 To dts.Rows.Count - 1
                    Dim rks As DataTable = ob.Returntable("select * from sdata where id=" & dt.Rows(i).Item("party_id") & " and Fromid=" & dts.Rows(j).Item("ID") & "", ob.getconnection())
                    Dim mid As Double = 0
                    mid = dts.Rows(j).Item("Amount")
                    If rks.Rows.Count > 0 Then
                        For mk As Integer = 0 To rks.Rows.Count - 1
                            If rks.Rows(mk).Item("Type") = "CR" Then
                                ob.Execute("Insert into Detailreport(Partyid, docdate, Month, Hno, CDocno, cramt,dramt, freeamt,pname, dDocno, fDocno,mid,Mamt,cref) Values(" & dt.Rows(i).Item("party_id") & ",'" & ob.DateConversion(rks.Rows(mk).Item("Docdate")) & "','" & dts.Rows(j).Item("Monthname") & "'," & dt.Rows(i).Item("gstno") & "," & rks.Rows(mk).Item("docno") & "," & rks.Rows(mk).Item("Amount") & ",0,0,'" & dt.Rows(i).Item("Party_name") & "',0,0," & dts.Rows(j).Item("Id") & "," & mid & "," & rks.Rows(mk).Item("refno") & ")", ob.getconnection())
                            End If
                            If rks.Rows(mk).Item("Id") = 12 Or rks.Rows(mk).Item("Id") = 17 Then
                                If dts.Rows(j).Item("Id") = 3 Then
                                    mid = 0
                                End If
                            End If
                            If rks.Rows(mk).Item("Type") = "DR" Then
                                ob.Execute("Insert into Detailreport(Partyid, ddate, Month, Hno, CDocno, cramt,dramt, freeamt,pname, dDocno, fDocno,mid,Mamt,dref) Values(" & dt.Rows(i).Item("party_id") & ",'" & ob.DateConversion(rks.Rows(mk).Item("Docdate")) & "','" & dts.Rows(j).Item("Monthname") & "'," & dt.Rows(i).Item("gstno") & ",0,0," & rks.Rows(mk).Item("dramt") & ",0,'" & dt.Rows(i).Item("Party_name") & "'," & rks.Rows(mk).Item("docno") & ",0," & dts.Rows(j).Item("Id") & "," & mid & "," & rks.Rows(mk).Item("refno") & ")", ob.getconnection())
                            End If
                            If rks.Rows(mk).Item("Type") = "Free" Then
                                ob.Execute("Insert into Detailreport(Partyid, fdate, Month, Hno, CDocno, cramt,dramt, freeamt,pname, dDocno, fDocno,mid,Mamt) Values(" & dt.Rows(i).Item("party_id") & ",'" & ob.DateConversion(rks.Rows(mk).Item("Docdate")) & "','" & dts.Rows(j).Item("Monthname") & "'," & dt.Rows(i).Item("gstno") & ",0,0,0," & rks.Rows(mk).Item("Amount") & ",'" & dt.Rows(i).Item("Party_name") & "',0," & rks.Rows(mk).Item("docno") & "," & dts.Rows(j).Item("Id") & "," & mid & ")", ob.getconnection())
                            End If
                        Next
                    Else
                        ob.Execute("Insert into Detailreport(Partyid, Month, Hno, CDocno, cramt,dramt, freeamt,pname, dDocno, fDocno,mid,Mamt) Values(" & dt.Rows(i).Item("party_id") & ",'" & dts.Rows(j).Item("Monthname") & "'," & dt.Rows(i).Item("gstno") & ",0,0,0,0,'" & dt.Rows(i).Item("Party_name") & "',0,0," & dts.Rows(j).Item("Id") & "," & mid & ")", ob.getconnection())
                    End If
                Next
            Next
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Party Outstanding Report"
            clsVariables.ReportName = "PartyOut.rpt"
            Dim frm As New Reportform
            frm.Show()
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
End Class