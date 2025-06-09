Imports WeightPavti.CLS
Public Class Rate_Master

    Private Sub Rate_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns(0).HeaderText = "Month Id"
        DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(2).HeaderText = "Amount"
        DgDoc_Column.Columns(3).HeaderText = "Pen Amount"
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Bold)
        DgDoc_Column.Columns(1).Width = 150
        loadg()
        auto()
        Dim dt As DataTable
        dt = ob.Returntable("select isnull(max(id),0)+1 as b from month where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        txtmonthid.Text = dt.Rows(0).Item("b")
        txtmonthname.Focus()
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        txtmonthname.AutoCompleteMode = AutoCompleteMode.Suggest
        txtmonthname.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtmonthname.AutoCompleteCustomSource = AutoComp
    End Sub
   
    Public Sub loadg()
        If DgDoc_Column.Rows.Count > 0 Then
            DgDoc_Column.Rows.Clear()
        End If
        Dim dt As DataTable
        dt = ob.Returntable("select Id,Monthname,Amount,pen_amt FROM month where year_id=" & aq(clsVariables.WorkingYear) & " Order By Id", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            DgDoc_Column.Rows.Add()
            DgDoc_Column.Rows(i).Cells(0).Value = dt.Rows(i).Item("id")
            DgDoc_Column.Rows(i).Cells(1).Value = dt.Rows(i).Item("Monthname")
            DgDoc_Column.Rows(i).Cells(2).Value = dt.Rows(i).Item("Amount")
            DgDoc_Column.Rows(i).Cells(3).Value = dt.Rows(i).Item("pen_amt")
        Next
        DgDoc_Column.Refresh()
    End Sub

    Private Sub txtmonthid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpenamt.KeyDown, txtmonthname.KeyDown, txtmonthid.KeyDown, txtamount.KeyDown
        tabkey(sender, e)
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        ob.Execute("delete from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=" & txtmonthid.Text & "", ob.getconnection())
        ob.Execute("insert into month (Year_id, Id, Monthname, Amount, pen_amt) values(" & aq(clsVariables.WorkingYear) & "," & txtmonthid.Text & "," & aq(txtmonthname.Text) & "," & aq(txtamount.Text) & "," & aq(txtpenamt.Text) & ")", ob.getconnection())
        txtmonthname.Clear()
        txtmonthid.Clear()
        txtamount.Clear()
        txtpenamt.Clear()
        loadg()
        Dim dt As DataTable
        auto()
        dt = ob.Returntable("select isnull(max(id),0)+1 as b from month where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        txtmonthid.Text = dt.Rows(0).Item("b")
        txtmonthname.Focus()
    End Sub

    Private Sub txtmonthid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmonthid.Validating
        Dim dt As DataTable
        dt = ob.Returntable("select * from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=" & txtmonthid.Text & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            txtmonthname.Text = dt.Rows(0).Item("monthname")
            txtamount.Text = ob.IfNullThen(dt.Rows(0).Item("Amount"), 0)
            txtpenamt.Text = ob.IfNullThen(dt.Rows(0).Item("pen_amt"), 0)
        End If
    End Sub

    Private Sub txtmonthname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmonthname.Validated
        Dim dt As DataTable = ob.Returntable("select monthname from Month where Monthname='" & txtmonthname.Text & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            MessageBox.Show("માફ કરસો આ મહિનો અગાઉ થી નાખેલો છે", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtmonthname.Clear()
            txtmonthname.Focus()
        End If
    End Sub
End Class