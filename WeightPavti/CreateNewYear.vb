Imports WeightPavti.CLS
Public Class CreateNewYear

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ob.Execute("Insert Into YEAR_MASTER(Company_Id, Year_Id, Year_Name, Co_Start_Date, Co_End_Date) values(1,'" & yearid.Text & "','Account Year-" & yearid.Text & "','" & ob.DateConversion(fromdate.Text) & "','" & ob.DateConversion(todate.Text) & "')", ob.getconnection())
        MessageBox.Show("Year Create")
        Me.Close()
    End Sub

    Private Sub CreateNewYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class