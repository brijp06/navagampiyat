Imports WeightPavti.CLS
Public Class MemberView
    Private Sub MemberView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = ob.Returntable("select * from Member_Master where Member_id<7000 order by Member_id", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("Member_id")
            dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Member_Name")
            dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("Mobile_no")
            dg.Rows(i).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Next
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        For i As Integer = 0 To dg.Rows.Count - 1
            ob.Execute("Update Member_master set Mobile_no='" & Trim(dg.Rows(i).Cells(2).Value) & "' where Member_id=" & dg.Rows(i).Cells(0).Value & "", ob.getconnection())
        Next
        MessageBox.Show("Done")
    End Sub
End Class