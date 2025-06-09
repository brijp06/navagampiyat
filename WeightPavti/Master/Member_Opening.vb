Imports WeightPavti.CLS
Public Class Member_Opening

    Private Sub Member_Opening_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns.Add("", "")
        DgDoc_Column.Columns(0).HeaderText = "Party Id"
        DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(0).Width = 50
        DgDoc_Column.Columns(1).Width = 250
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Bold)
        auto()
        loadg()
    End Sub
    Public Sub loadg()
        If DgDoc_Column.Rows.Count > 0 Then
            DgDoc_Column.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("select * from Opening where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                DgDoc_Column.Rows.Add()
                DgDoc_Column.Rows(i).Cells(0).Value = dt.Rows(i).Item("party_id")
                DgDoc_Column.Rows(i).Cells(1).Value = ob.FindOneString("select party_name from party_master where party_id=" & dt.Rows(i).Item("party_id") & "", ob.getconnection())
            Next
        End If
        DgDoc_Column.Refresh()

    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        Opyear.AutoCompleteMode = AutoCompleteMode.Suggest
        Opyear.AutoCompleteSource = AutoCompleteSource.CustomSource
        Opyear.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub txtpartid_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartid.Validated
        Dim dt As DataTable
        dt = ob.Returntable("select party_name from party_master where party_id=" & txtpartid.Text & "", ob.getconnection())
        txtpartyname.Text = dt.Rows(0).Item("party_name")
        Dim dts As DataTable
        dts = ob.Returntable("select * from opening where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpartid.Text & "", ob.getconnection())
        If dts.Rows.Count > 0 Then
            Opyear.Tag = dts.Rows(0).Item("Opyear")
            Opyear.Text = ob.FindOneString("Select Monthname from Month Where Id='" & Opyear.Tag & "'", ob.getconnection())
        End If
    End Sub

    Private Sub txtpartid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpartyname.KeyDown, txtpartid.KeyDown
        tabkey(sender, e)
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        ob.Execute("delete from Opening where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpartid.Text & "", ob.getconnection())
        ob.Execute("insert into Opening (Year_id, Party_id,opyear) values (" & aq(clsVariables.WorkingYear) & "," & txtpartid.Text & "," & Opyear.Tag & ")", ob.getconnection())
        txtpartid.Clear()
        txtpartyname.Clear()
        Opyear.Clear()
        loadg()
    End Sub

    Private Sub Opyear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Opyear.KeyDown
        tabkey(sender, e)

    End Sub

    Private Sub Opyear_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Opyear.Validating
        If Opyear.Text <> "" Then
            Opyear.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Opyear.Text & "'", ob.getconnection())
        End If
    End Sub
End Class