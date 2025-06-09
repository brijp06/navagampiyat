Imports WeightPavti.CLS

Public Class WeightPavtiReport

    Private Sub InwardMilkReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.MdiParent = MdiMain

        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Hide()
        'WeightPavtiEntry.Show()
        Login.Show()
    End Sub
End Class