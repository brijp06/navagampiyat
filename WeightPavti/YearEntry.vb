Public Class YearEntry

    Private Sub YearEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        auto()
        autotwo()
        Dg.Columns.Add("Year", "Year")
        Dg.Columns.Add("FromYear", "FromYear")
        Dg.Columns.Add("ToYear", "ToYear")
        Dg.DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        fillgrid()
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
    Public Sub fillgrid()
        Dim dt As DataTable = ob.Returntable("select Yearid from yearmast group by yearid", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dg.Rows.Count > 0 Then
                Dg.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dg.Rows.Add()
                Dim max As Integer = ob.FindOneinteger("select max(id) from yearmast where yearid='" & dt.Rows(i).Item("Yearid") & "'", ob.getconnection())
                Dim min As Integer = ob.FindOneinteger("select min(id) from yearmast where yearid='" & dt.Rows(i).Item("Yearid") & "'", ob.getconnection())
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Yearid")

                Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select Monthname from Month Where id=" & min & "", ob.getconnection())
                Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Monthname from Month Where id=" & max & "", ob.getconnection())
            Next
        End If
    End Sub

    Private Sub Dg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg.CellClick
        If Dg.Rows.Count > 0 Then
            Yearid.Text = Dg.Rows(e.RowIndex).Cells(0).Value
            frommonth.Text = Dg.Rows(e.RowIndex).Cells(1).Value
            Tomonth.Text = Dg.Rows(e.RowIndex).Cells(2).Value
            frommonth.Tag = ob.FindOneinteger("select id from Month Where Monthname='" & frommonth.Text & "'", ob.getconnection())
            Tomonth.Tag = ob.FindOneinteger("select id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ob.Execute("delete from yearmast where yearid='" & Yearid.Text & "'", ob.getconnection())
        Dim fid As Integer = ob.FindOneinteger("select isnull(max(yid),0)+1 from Yearmast", ob.getconnection())
        Dim mid As Integer = frommonth.Tag
        For i As Integer = frommonth.Tag To Tomonth.Tag
            ob.Execute("Insert into Yearmast(yid,Yearid,id) Values(" & fid & ",'" & Yearid.Text & "'," & mid & ")", ob.getconnection())
            mid = mid + 1
        Next
        fillgrid()
        Yearid.Text = ""
        frommonth.Text = ""
        Tomonth.Text = ""
    End Sub

    Private Sub Yearid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Yearid.KeyDown, Tomonth.KeyDown, frommonth.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub frommonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frommonth.Validated
        If frommonth.Text <> "" Then
            frommonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & frommonth.Text & "'", ob.getconnection())           
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then
            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
        End If
    End Sub

End Class