Public Class Intro
    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\intro.mp4"
        ' Me.Hide()


        'Login.Show()
    End Sub

    Private Sub AxWindowsMediaPlayer1_EndOfStream(sender As Object, e As AxWMPLib._WMPOCXEvents_EndOfStreamEvent) Handles AxWindowsMediaPlayer1.EndOfStream

    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            Me.Hide()
            Login.Show()
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class