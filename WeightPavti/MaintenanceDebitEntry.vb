Imports WeightPavti.CLS
Public Class MaintenanceDebitEntry
    Dim rid As Integer
    Private Sub MaintenanceEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Docdate.Text = Format(Now, "dd/MM/yyyy")
        Docno.Text = ob.FindOneString("Select isnull(Max(Docno),0)+1 from sdata where type='DR'", ob.getconnection())
        auto()
        autotwo()
        autoname()
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        frommonth.AutoCompleteMode = AutoCompleteMode.Suggest
        frommonth.AutoCompleteSource = AutoCompleteSource.CustomSource
        frommonth.AutoCompleteCustomSource = AutoComp
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
                Partname.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & Partname.Text & "", ob.getconnection())
                Partname.Tag = ob.FindOneinteger("select Party_id From Party_master where Party_name='" & Partname.Text & "'", ob.getconnection())
                lblhouseno.Text = "House No:- " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
            Else
                Partname.Tag = ob.FindOneinteger("select Party_id From Party_master where Party_name='" & Partname.Text & "'", ob.getconnection())
                lblhouseno.Text = "House No:- " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
            End If
        End If
    End Sub

    Private Sub frommonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frommonth.Validated
        If frommonth.Text <> "" Then
            frommonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & frommonth.Text & "'", ob.getconnection())
            Dim dt As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and Fromid=" & frommonth.Tag & " and Type='DR'", ob.getconnection())
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Maintenance All Ready Paid In Doc No:-" & dt.Rows(0).Item("Docno") & "", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frommonth.Clear()
                frommonth.Focus()
            End If
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then
            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
            Dim dt As DataTable = ob.Returntable("select * from sdata where id=" & Partname.Tag & " and Toid=" & Tomonth.Tag & " And Type='DR'", ob.getconnection())
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Maintenance All Ready Paid In Doc No:-" & dt.Rows(0).Item("Docno") & "", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Tomonth.Clear()
                Tomonth.Focus()
                Exit Sub
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
        If rid = 0 Then
            ob.Execute("delete from sdata where docno=" & Docno.Text & " and type='DR'", ob.getconnection())
            ob.Execute("Insert Into sdata(Docno, Docdate, Id, Name, Fromid, Toid, Dramt,Refno,type,Remarks,Amount) Values(" & Docno.Text & ",'" & ob.DateConversion(Docdate.Text) & "'," & Partname.Tag & ",'" & Partname.Text & "'," & frommonth.Tag & "," & Tomonth.Tag & "," & Amount.Text & "," & Refno.Text & ",'DR','" & Remarks.Text & "',0)", ob.getconnection())
        Else
            ob.Execute("delete from sdata where docno=" & Docno.Text & " and type='DR'", ob.getconnection())
            Dim fid As Integer = frommonth.Tag
            For i As Integer = 0 To rid
                Dim dsdamt As Double = 0
                dsdamt = ob.FindOneString("select Amount From Month where Id=" & fid & "", ob.getconnection())
                ob.Execute("Insert Into sdata(Docno, Docdate, Id, Name, Fromid, Toid, Dramt,refno,type,Remarks,Amount) Values(" & Docno.Text & ",'" & ob.DateConversion(Docdate.Text) & "'," & Partname.Tag & ",'" & Partname.Text & "'," & fid & "," & fid & "," & dsdamt & "," & Refno.Text & ",'DR','" & Remarks.Text & "',0)", ob.getconnection())
                fid = fid + 1
            Next
        End If
        MessageBox.Show("Saved")
        cler()
    End Sub
    Public Sub cler()
        Partname.Tag = ""
        Partname.Text = ""
        frommonth.Tag = ""
        frommonth.Text = ""
        Tomonth.Tag = ""
        Tomonth.Text = ""
        Amount.Text = ""
        Refno.Text = ""
        Remarks.Text = ""
        Docdate.Text = Format(Now, "dd/MM/yyyy")
        Docno.Text = ob.FindOneString("Select isnull(Max(Docno),0)+1 from sdata where type='DR'", ob.getconnection())
        Refno.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Partname.Text <> "" Then
            Dim dt As DataTable
            dt = ob.Returntable("select * from Sdata where Id=" & Partname.Tag & "", ob.getconnection())
            Grd.dg.Columns.Add("Party_id", "Party Id")
            Grd.dg.Columns.Add("MonthName", "Month Name")
            Grd.dg.Columns.Add("Docno", "Doc No")
            Grd.dg.Columns.Add("Date", "Date")
            Grd.dg.Columns.Add("Penalty", "Cr Amount")
            Grd.dg.Columns.Add("Penalty", "Dr Amount")

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
                    Grd.dg.Rows(i).Cells(3).Value = ob.DateConversion(dt.Rows(0).Item("docdate"))
                    Grd.dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("Amount")
                    Grd.dg.Rows(i).Cells(5).Value = ob.IfNullThen(dt.Rows(i).Item("Dramt"), 0)

                    Grd.dg.Rows(i).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Next
            End If
            Grd.Show()
        End If
    End Sub

    Private Sub Docno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Docno.Validated
        Dim dt As DataTable = ob.Returntable("select * from sdata where docno=" & Docno.Text & " and type='DR'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Docdate.Text = dt.Rows(0).Item("docdate")
                Partname.Text = dt.Rows(0).Item("Name")
                Partname.Tag = dt.Rows(0).Item("Id")
                frommonth.Tag = dt.Rows(0).Item("Fromid")
                Tomonth.Tag = dt.Rows(0).Item("Toid")
                Amount.Text = dt.Rows(0).Item("Dramt")
                frommonth.Text = ob.FindOneString("Select Monthname from Month Where Id='" & frommonth.Tag & "'", ob.getconnection())
                Tomonth.Text = ob.FindOneString("Select Monthname from Month Where Id='" & Tomonth.Tag & "'", ob.getconnection())
                Refno.Text = dt.Rows(0).Item("Refno")
                Remarks.Text = dt.Rows(0).Item("Remarks")
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from sdata where docno=" & Docno.Text & " and type='DR'", ob.getconnection())
            MessageBox.Show("Delete")
            cler()
        End If
    End Sub
End Class