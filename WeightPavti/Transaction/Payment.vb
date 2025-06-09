Public Class Payment

    Private Sub Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtloanno.Focus()
    End Sub


    Private Sub txtloanno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrs.KeyPress, txtname.KeyPress, txtloanno.KeyPress, txtex.KeyPress, txtemi.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtloanno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtloanno.Validated
        If txtloanno.Text <> "" Then
            Dim dt As DataTable = ob.Returntable("select * from loan where loanno=" & txtloanno.Text & "", ob.getconnection(sysdbname))
            If dt.Rows.Count > 0 Then
                txtname.Text = dt.Rows(0).Item("Name")
                Dim dts As DataTable = ob.Returntable("select * from Loan_detail where Loanno=" & txtloanno.Text & "and recrs=0", ob.getconnection(sysdbname))
                txtemi.Text = dts.Rows(0).Item("noemi")
                txtrs.Text = dts.Rows(0).Item("emirs")
                txtex.Focus()
            Else
                MessageBox.Show("No Date Found")
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtloanno.Text <> "" Then
            ob.Execute("update loan_detail set Recrs=" & txtrs.Text & ",Recdate=" & aq(ob.DateConversion(DateTime.Now.Date)) & " where loanno=" & txtloanno.Text & " and noemi=" & txtemi.Text & "", ob.getconnection(sysdbname))
            sms()
            MessageBox.Show("Paid")
        End If
    End Sub

    Public Sub sms()
        Dim strResponse, strURL As String
        Dim GetURL As New System.Net.WebClient
        Dim mno As String
        Dim dt As DataTable = ob.Returntable("select mobileno from loan where loanno=" & txtloanno.Text & "", ob.getconnection(sysdbname))
        mno = dt.Rows(0).Item("mobileno")
        strURL = "https://bulksms.smsroot.com/app/smsapi/index.php?key=35DB655F91246B&campaign=0&routeid=13&type=text&contacts=" & mno & "&senderid=BNEFNS&msg=Thank You For Payment Of Your Emi No:- " & txtemi.Text & " And Emi Rs:- " & txtrs.Text & " . Thank You."

        Dim data As System.IO.Stream = GetURL.OpenRead(strURL)

        Dim reader As New System.IO.StreamReader(data)
        strResponse = reader.ReadToEnd()
        data.Close()
        reader.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class