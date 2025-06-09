Imports System.Net
Public Class Tr

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim url As String = "https://translation.googleapis.com/language/translate/v2?key=AIzaSyBLeUjd9W3gWgBenndoiPyzapaRlX5JrFE"
        url += "&source=" + "EN"
        url += "&target=" + "GU"
        url += "&q=" + (TextBox1.Text.Trim())
        Dim client As New WebClient()
        'Dim json As String = client.DownloadString(url)
        Dim json As String = System.Text.UTF8Encoding.UTF8.GetString(client.DownloadData(url))
        Dim ilen As Integer
        ilen = InStr(json, ":")
        Dim bbb As String
        bbb = Mid(json, ilen + 1)
        ilen = InStr(bbb, ":")
        Dim nn As String
        nn = Mid(bbb, ilen + 1)
        ilen = InStr(nn, ":")
        Dim bk As String
        bk = Mid(nn, ilen + 1)
        ilen = InStr(bk, """")
        Dim bkk As String
        bkk = Mid(bk, ilen + 1)
        ilen = InStrRev(bkk, """")
        Dim bbmm As String
        bbmm = bkk.Substring(0, ilen - 1)
        Label1.Text = bbmm
        Label1.Font = New Font("Arial Rounded MT", 10, FontStyle.Bold)
        'bbmm = Label17.Text
        TextBox2.Text = Label1.Text
        Dim conv As String
        conv = TextBox2.Text
        TextBox2.Text = conv.ToUpper()
    End Sub

End Class