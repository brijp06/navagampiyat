Public Class Sp
    Private Sub Sp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiMain
        WeightPavtiEntry.Show()

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Hide()

    End Sub
End Class