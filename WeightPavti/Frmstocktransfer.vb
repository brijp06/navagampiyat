Imports WeightPavti.CLS
Public Class Frmstocktransfer
    Private Sub Frmstocktransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select  In_No, Item_Id,SUM(Bal_Qnty) as op, M_R_P, Padt_Rate,Size_id FROM Kadod_Retail_2021_2022.dbo.Item_Stock_Balance_Report WHERE     (Bal_Qnty > 0) group by In_No, Item_Id, M_R_P, Padt_Rate,size_id ORDER BY Item_Id", ob.getconnection())
        ob.Execute("delete from acstock where Department='bhandar' and ptype='Opening'", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dpid As String = ob.FindOneinteger("select isnull(max(Billno),0)+1 from acstock where Department='bhandar' and ptype='Opening'", ob.getconnection())
            ob.Execute("insert into acstock(Cid, Year_id, Department, Billno, Billdate, Stockin, Stockout, Rate, Basic, ptype, Itemid, Billtype, Barcode,MRP,sizeid) values(1,'2022-2023','Bhandar'," & Val(dpid) & ",'2022/04/01'," & dt.Rows(i).Item("op") & ",0," & dt.Rows(i).Item("Padt_rate") & "," & dt.Rows(i).Item("Padt_rate") & ",'Opening'," & dt.Rows(i).Item("Item_id") & ",'Opening','" & dt.Rows(i).Item("In_no") & "'," & dt.Rows(i).Item("M_R_P") & ",'" & Trim(dt.Rows(i).Item("Size_id")) & "')", ob.getconnection())
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dt As DataTable = ob.Returntable("select  Quality_id,Product_id FROM Kadod_Retail_2021_2022.dbo.Quality_Master  ORDER BY Quality_id", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            ob.Execute("update product_master set Group_id=" & dt.Rows(i).Item("Product_id") & " where Product_id=" & dt.Rows(i).Item("Quality_id") & "", ob.getconnection())
        Next
        MessageBox.Show("Done")
    End Sub
End Class