Imports WeightPavti.CLS
Public Class MaintenanceEntry
    Dim rid As Integer
    Dim isadd As Boolean
    Private Sub MaintenanceEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountDataSet.tmpOut' table. You can move, or remove it, as needed.
        'Me.TmpOutTableAdapter.Fill(Me.AccountDataSet.tmpOut)
        Docdate.Text = Format(Now, "dd/MM/yyyy")
        Docno.Text = ob.FindOneString("Select isnull(Max(Docno),0)+1 from sdata where type='CR'", ob.getconnection())
        auto()
        autotwo()
        autoname()
        isadd = True
        DG.Columns.Add("Id", "Id")
        DG.Columns.Add("MonthName", "Month name")
        DG.Columns.Add("Amount", "Amount")
        Dgout.Columns.Add("PartyName", "PartyName")
        Dgout.Columns.Add("MonthName", "MonthName")
        Dgout.Columns.Add("Amount", "Amount")
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = ""
        chk.Width = 30
        chk.Name = "Selection"
        Dgout.Columns.Insert(2, chk)

        Dgout.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Bold)
        Dgout.Columns(0).Width = 170
        Dgout.Columns(3).Width = 110

        dg1.Columns.Add("", "")
        Panel1.Visible = False
        DG.Columns(0).Width = 50
        DG.Columns(1).Width = 150
        DG.Columns(2).Width = 100
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        Month.AutoCompleteMode = AutoCompleteMode.Suggest
        Month.AutoCompleteSource = AutoCompleteSource.CustomSource
        Month.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autonn()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Id,Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            Dim dts As DataTable
            dts = ob.Returntable("select * from sdata where fromid=" & dt.Rows(i).Item("Id") & " and id=" & Partname.Tag & "", ob.getconnection())
            If dts.Rows.Count > 0 Then
            Else
                AutoComp.Add(dt.Rows(i).Item("Monthname"))
            End If
        Next
        Month.AutoCompleteMode = AutoCompleteMode.Suggest
        Month.AutoCompleteSource = AutoCompleteSource.CustomSource
        Month.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autonnbb()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        Dim msn As String = ob.FindOneString("select Mid from Transfer where Houseno=" & hno.Text & "", ob.getconnection())
        dt = ob.Returntable("select Id,Monthname from month where id>" & msn & "", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            Dim dts As DataTable
            dts = ob.Returntable("select * from sdata where fromid=" & dt.Rows(i).Item("Id") & " and id=" & Partname.Tag & "", ob.getconnection())
            If dts.Rows.Count > 0 Then
            Else
                AutoComp.Add(dt.Rows(i).Item("Monthname"))
            End If
        Next
        Month.AutoCompleteMode = AutoCompleteMode.Suggest
        Month.AutoCompleteSource = AutoCompleteSource.CustomSource
        Month.AutoCompleteCustomSource = AutoComp
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
        Partname.AutoCompleteMode = AutoCompleteMode.Suggest
        Partname.AutoCompleteSource = AutoCompleteSource.CustomSource
        Partname.AutoCompleteCustomSource = AutoComp
    End Sub


    Private Sub Docno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tomonth.KeyDown, Partname.KeyDown, frommonth.KeyDown, Docno.KeyDown, Docdate.KeyDown, Amount.KeyDown, Refno.KeyDown, Remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Partname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Partname.Validated
        If Partname.Text <> "" Then
            If IsNumeric(Partname.Text) Then
                Partname.Tag = ob.FindOneinteger("select Party_id From Party_master where Gstno=" & Partname.Text & "", ob.getconnection())
                Partname.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & Partname.Text & "", ob.getconnection())
                lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
            Else
                Dim dt As DataTable = ob.Returntable("select gstno From Party_master where Party_name='" & Partname.Text & "'", ob.getconnection())
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
                    Partname.Tag = ob.FindOneinteger("Select Party_id from Party_master where Party_name='" & Partname.Text & "'", ob.getconnection())
                End If
                lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
            End If
            autonn()
            outstnding()
            'loaddg()
        End If
    End Sub
    Public Sub outstnding()
        Dim dt As DataTable = ob.Returntable("select * from Month", ob.getconnection())
        Dim bs As Double = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dts As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and fromid=" & dt.Rows(i).Item("id") & "", ob.getconnection())
            If dts.Rows.Count > 0 Then
            Else
                bs += Val(dt.Rows(i).Item("Amount"))
            End If
        Next
        lblout.Text = bs
    End Sub
   
    Private Sub frommonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frommonth.Validated
        If frommonth.Text <> "" Then
            frommonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & frommonth.Text & "'", ob.getconnection())
            If frommonth.Tag = 0 Then
                MessageBox.Show("Sorry Invalid Month Selection", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frommonth.Clear()
                frommonth.Focus()
            End If
            If isadd = True Then
                Dim dt As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and Fromid=" & frommonth.Tag & " And Type='CR'", ob.getconnection())
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Maintenance All Ready Paid In Doc No:-" & dt.Rows(0).Item("Docno") & "", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frommonth.Clear()
                    frommonth.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then

            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
            If Tomonth.Tag = 0 Then
                MessageBox.Show("Sorry Invalid Month Selection", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frommonth.Clear()
                frommonth.Focus()
            End If
            If isadd = True Then
                Dim dt As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and Toid=" & Tomonth.Tag & " And Type='CR'", ob.getconnection())
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Maintenance All Ready Paid In Doc No:-" & dt.Rows(0).Item("Docno") & "", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Tomonth.Clear()
                    Tomonth.Focus()
                    Exit Sub
                End If
            End If
            rid = Val(Tomonth.Tag) - Val(frommonth.Tag)
            If rid = 0 Then
                Amount.Text = ob.FindOneString("select Amount From Month where Id=" & frommonth.Tag & "", ob.getconnection())
            Else
                Dim damt As Double = 0
                Dim fid As Integer = frommonth.Tag
                For i As Integer = 0 To rid
                    Dim dsdamt As Double = 0
                    dsdamt = ob.FindOneString("select Amount From Month where Id=" & fid & "", ob.getconnection())
                    fid = fid + 1
                    damt = damt + dsdamt
                Next
                Amount.Text = damt

            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DG.Rows.Count > 0 Then
            ob.Execute("delete from sdata where docno=" & Docno.Text & " and type='CR'", ob.getconnection())
            For i As Integer = 0 To DG.Rows.Count - 1
                ob.Execute("Insert Into sdata(Docno, Docdate, Id, Name, Fromid, Toid, Amount,Refno,type,Remarks,Dramt) Values(" & Val(Docno.Text) & ",'" & ob.DateConversion(Docdate.Text) & "'," & Partname.Tag & ",'" & Partname.Text & "'," & DG.Rows(i).Cells(0).Value & "," & DG.Rows(i).Cells(0).Value & "," & DG.Rows(i).Cells(2).Value & "," & Val(Refno.Text) & ",'CR','" & Trim(Remarks.Text) & "',0)", ob.getconnection())
            Next
            MessageBox.Show("Saved")
            cler()
        Else
            MessageBox.Show("કૃપા કરી મહિનો દાખલ કરો  અથવા કેન્સલ કરો ")
        End If
    End Sub
    Public Sub cler()
        Partname.Tag = ""
        Partname.Text = ""
        hno.Clear()
        frommonth.Tag = ""
        frommonth.Text = ""
        Tomonth.Tag = ""
        Tomonth.Text = ""
        Amount.Text = ""
        Refno.Text = ""
        Remarks.Text = ""
        lblhouseno.Text = ""
        lblout.Text = ""

        ' Docdate.Text = ob.DateConversion(DateTime.Now.Date)
        Docdate.Text = Format(Now, "dd/MM/yyyy")
        Docno.Text = ob.FindOneString("Select isnull(Max(Docno),0)+1 from sdata where type='CR'", ob.getconnection())
        Refno.Focus()
        isadd = True
        DG.Rows.Clear()
        If Dgout.Rows.Count - 1 Then
            Dgout.Rows.Clear()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Partname.Text <> "" Then
            Dim dt As DataTable
            dt = ob.Returntable("select * from Sdata where Id=" & Partname.Tag & " Order By Fromid", ob.getconnection())
            Grd.dg.Columns.Add("Party_id", "Party Id")
            Grd.dg.Columns.Add("MonthName", "Month Name")
            Grd.dg.Columns.Add("Docno", "Doc No")
            Grd.dg.Columns.Add("Date", "Date")
            Grd.dg.Columns.Add("Penalty", "CR Amount")
            Grd.dg.Columns.Add("Penalty", "DR Amount")
            Grd.dg.Columns.Add("Penalty", "Free")
            Grd.dg.Columns.Add("Ref", "Ref No")


            Grd.dg.Columns(0).Width = 50
            Grd.dg.Columns(2).Width = 50
            Grd.dg.Columns(4).Width = 70

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Grd.dg.Rows.Add()
                    Grd.dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("id")
                    Dim dts As DataTable = ob.Returntable("select Monthname from month where id=" & dt.Rows(i).Item("Fromid") & "", ob.getconnection())
                    Grd.dg.Rows(i).Cells(1).Value = dts.Rows(0).Item("Monthname")
                    Grd.dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("Docno")
                    'Dim df As DataTable = ob.Returntable("select doc_date from danavak where doc_no=" & dt.Rows(i).Item("Doc_no") & "", ob.getconnection())
                    Grd.dg.Rows(i).Cells(3).Value = Format(dt.Rows(i).Item("docdate"), "dd/MM/yyyy")
                    Grd.dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("Amount")
                    Grd.dg.Rows(i).Cells(5).Value = ob.IfNullThen(dt.Rows(i).Item("Dramt"), 0)
                    If dt.Rows(i).Item("Type") = "Free" Then
                        Grd.dg.Rows(i).Cells(6).Value = dt.Rows(i).Item("Amount")
                        Grd.dg.Rows(i).Cells(4).Value = 0
                        Grd.dg.Rows(i).Cells(5).Value = 0
                    Else
                        Grd.dg.Rows(i).Cells(6).Value = 0
                    End If
                    Grd.dg.Rows(i).Cells(7).Value = dt.Rows(i).Item("Refno")

                    Grd.dg.Rows(i).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Next
            End If
            Grd.Show()
        End If
    End Sub

    Private Sub Docno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Docno.Validated
        Dim dt As DataTable = ob.Returntable("select * from sdata where docno=" & Docno.Text & " and type='CR'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Docdate.Text = dt.Rows(0).Item("docdate")
                Partname.Text = dt.Rows(0).Item("Name")
                Partname.Tag = dt.Rows(0).Item("Id")
                If DG.Rows.Count > 0 Then
                    DG.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    DG.Rows.Add()
                    DG.Rows(DG.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Fromid")
                    DG.Rows(DG.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select Monthname from month where id=" & dt.Rows(i).Item("Fromid") & "", ob.getconnection())
                    DG.Rows(DG.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Amount")
                    DG.Rows(DG.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Next
                Dim bn As Double = 0
                For isd As Integer = 0 To DG.Rows.Count - 1
                    bn += DG.Rows(isd).Cells(2).Value
                Next
                txttotal.Text = Val(bn)
                lbltotal.Refresh()
                Refno.Text = dt.Rows(0).Item("Refno")
                Remarks.Text = dt.Rows(0).Item("Remarks")
                lblhouseno.Text = "House No:- " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
                isadd = False
            Else
                cler()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from sdata where docno=" & Docno.Text & " and type='cr'", ob.getconnection())
            MessageBox.Show("Delete")
            cler()
        End If
    End Sub

    Private Sub Month_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Month.Validated
        If Month.Text <> "" Then
            Month.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Month.Text & "'", ob.getconnection())
            If Month.Tag = 0 Then
                MessageBox.Show("Sorry Invalid Month Selection", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Month.Clear()
                Month.Focus()
            End If
            If isadd = True Then
                Dim dt As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and Fromid=" & Month.Tag & "", ob.getconnection())
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Maintenance All Ready Paid In Doc No:-" & dt.Rows(0).Item("Docno") & "", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Month.Clear()
                    Month.Focus()
                End If
            End If
            Amt.Text = ob.FindOneString("select Amount From Month where Id=" & Month.Tag & "", ob.getconnection())
        Else
            Button1.Focus()
        End If
        For i As Integer = 0 To DG.Rows.Count - 1
            If DG.Rows(i).Cells(0).Value = Month.Tag Then
                MessageBox.Show("Sorry This MOnth Is allready In List", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Month.Clear()
                Month.Focus()
            End If
        Next
    End Sub

    Private Sub Month_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Month.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Amt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Amt.KeyDown
        If e.KeyCode = Keys.Enter Then
            DG.Rows.Add()
            DG.Rows(DG.Rows.Count - 1).Cells(0).Value = Month.Tag
            DG.Rows(DG.Rows.Count - 1).Cells(1).Value = Month.Text
            DG.Rows(DG.Rows.Count - 1).Cells(2).Value = Amt.Text
            DG.Rows(DG.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dim bn As Double = 0
            For i As Integer = 0 To DG.Rows.Count - 1
                bn += DG.Rows(i).Cells(2).Value
            Next
            txttotal.Text = Val(bn)
            Month.Clear()
            Amt.Clear()
            Month.Focus()
        End If
    End Sub

   
    
    Private Sub dg1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg1.DoubleClick
        ' Dim sl As Integer = dg1.SelectedRows.Count
        
    End Sub

    Private Sub dg1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg1.CellMouseDoubleClick
        Dim gst As String = dg1.Rows(e.RowIndex).Cells(0).Value
        Partname.Tag = ob.FindOneString("Select Party_id from Party_master where gstno=" & gst & "", ob.getconnection())
        lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
        Panel1.Visible = False
        Remarks.Focus()
        autonn()
        outstnding()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel1.Hide()
        Partname.Clear()
        Partname.Focus()
    End Sub

    Private Sub hno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hno.Validated
        If hno.Text <> "" Then
            'Partname.Tag = hno.Text
            Dim trn As DataTable = ob.Returntable("Select * from Transfer Where Houseno=" & hno.Text & " Order By Tharavno desc", ob.getconnection())
            If trn.Rows.Count > 0 Then
                Partname.Text = trn.Rows(0).Item("tname")
                Partname.Tag = trn.Rows(0).Item("tid")
                lblhouseno.Text = "House No : " & hno.Text
                autonnbb()
                outstnding()
                ou()
            Else
                Partname.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & hno.Text & "", ob.getconnection())
                Partname.Tag = ob.FindOneString("Select Party_id from Party_master where Gstno=" & hno.Text & "", ob.getconnection())
                lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
                autonn()
                outstnding()
                ou()
            End If
        Else
            clsVariables.HelpId = "gstno"
            clsVariables.HelpName = "Party_name"
            clsVariables.TbName = "Party_master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Party_id"
            HelpWin.tsql = "Select gstno,Party_name from Party_master Where Company_id=1"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                hno.Text = clsVariables.RtnHelpId
                Partname.Text = clsVariables.RtnHelpName
                Partname.Tag = ob.FindOneString("Select Party_id from Party_master where Gstno=" & hno.Text & "", ob.getconnection())
                lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
                autonn()
                outstnding()
                ou()
            Else
                hno.Focus()
            End If
        End If
    End Sub
    Public Sub ou()
        If Dgout.Rows.Count > 0 Then
            Dgout.Rows.Clear()
        End If
        Dim op As Boolean = False
        ob.Execute("delete from tmpout", ob.getconnection())
        Dim dt As DataTable
        'Dim pid As String = ob.FindOneString("select Party_id from Party_Master where GSTno=" & hno.Text & "", ob.getconnection())
        dt = ob.Returntable("Select * from Party_master where party_id=" & Partname.Tag & "", ob.getconnection())

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
        Dim ous As DataTable = ob.Returntable("select * from tmpout Order by mid", ob.getconnection())
        For mj As Integer = 0 To ous.Rows.Count - 1
            Dgout.Rows.Add()
            Dgout.Rows(mj).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgout.Rows(mj).Cells(0).Value = Partname.Text
            Dgout.Rows(mj).Cells(1).Value = ous.Rows(mj).Item("Month")
            Dgout.Rows(mj).Cells(3).Value = ous.Rows(mj).Item("Amount")

        Next
        Dgout.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow

    End Sub

    Private Sub hno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles hno.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        cler()
        Docno.Focus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If DG.Rows.Count > 0 Then
            DG.Rows.Clear()
        End If
        For i As Integer = 0 To Dgout.Rows.Count - 1
            If Dgout.Rows(i).Cells(2).Value = True Then
                DG.Rows.Add()
                DG.Rows(DG.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Id from Month where Monthname='" & Dgout.Rows(i).Cells(1).Value & "'", ob.getconnection())
                DG.Rows(DG.Rows.Count - 1).Cells(1).Value = Dgout.Rows(i).Cells(1).Value
                DG.Rows(DG.Rows.Count - 1).Cells(2).Value = Dgout.Rows(i).Cells(3).Value
                DG.Rows(DG.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Dim bn As Double = 0
                For ind As Integer = 0 To DG.Rows.Count - 1
                    bn += DG.Rows(ind).Cells(2).Value
                Next
                txttotal.Text = Val(bn)
            End If
        Next
    End Sub


End Class