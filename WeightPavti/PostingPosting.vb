Imports WeightPavti.CLS
Public Class PostingPosting

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ddates As Date = DateTime.Now.Date
        Dim mnd As String = ddates.Month
        Dim dt As DataTable = ob.Returntable("select * from month where id=" & mnd & " and year_id=" & clsVariables.WorkingYear & "", ob.getconnection())
        Dim rps As String = dt.Rows(0).Item("Amount")
        Dim prps As String = dt.Rows(0).Item("pen_amt")
        Dim ds As DataTable = ob.Returntable("select * from party_master", ob.getconnection())
        For i = 0 To ds.Rows.Count - 1
            Dim strResponse, strURL As String
            Dim GetURL As New System.Net.WebClient
            ' strURL = "https://bulksms.smsroot.com/app/smsapi/index.php?key=35DB655F91246B&campaign=0&routeid=13&type=text&contacts=" & dt.Rows(0).Item("mobileno") & "&senderid=NVYMKV&msg=Greetings from Navyuvak Mandal Kavitha , Thank You For Paying " & txtamt.Text & " For " & txtmonthname.Text & "."

            Dim data As System.IO.Stream = GetURL.OpenRead(strURL)

            Dim reader As New System.IO.StreamReader(data)
            strResponse = reader.ReadToEnd()
            data.Close()
            reader.Close()
        Next
    End Sub
End Class