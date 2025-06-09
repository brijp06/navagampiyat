Imports WeightPavti.CLS
Public Class AccountBalanceTransfer
    Private Sub AccountBalanceTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ob.Execute("Delete from Acdata where cid=" & clsVariables.CompnyId & " and Year_id=" & aq(yearid.Text) & "  and Type='Opening'", ob.getconnection())
        Dim dt As DataTable = ob.Returntable("select * from Balancesheet", ob.getconnection())
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim ccr As String = ob.FindOneString("select sum(Cramt) from Acdata where acid=" & dt.Rows(i).Item("Account_Id") & " and docdate between " & aq(ob.DateConversion(fromdate.Text)) & " and " & aq(ob.DateConversion(todate.Text)) & " and acid=" & dt.Rows(i).Item("Account_Id") & "", ob.getconnection())
                Dim ddr As String = ob.FindOneString("select sum(Dramt) from Acdata where acid=" & dt.Rows(i).Item("Account_Id") & " and docdate between " & aq(ob.DateConversion(fromdate.Text)) & " and " & aq(ob.DateConversion(todate.Text)) & " and acid=" & dt.Rows(i).Item("Account_Id") & "", ob.getconnection())
                Dim cr As Double = 0
                Dim dr As Double = 0
                If Val(ccr) > Val(ddr) Then
                    cr = Val(ccr) - Val(ddr)
                Else
                    dr = Val(ddr) - Val(ccr)
                End If
                If Val(cr) <> 0 Or Val(dr) <> 0 Then
                    Dim ddate As Date = gFinYearBegin
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid,Dramt ,Remarks,Cramt) Values(1,'" & yearid.Text & "','Opening',1,'" & ob.DateConversion(ddate) & "'," & dt.Rows(i).Item("Account_Id") & "," & Val(dr) & ",'S@ait n)  bik)'," & Val(cr) & ")", ob.getconnection())
                End If
            Next
        End If
        MessageBox.Show("Done")
    End Sub
End Class