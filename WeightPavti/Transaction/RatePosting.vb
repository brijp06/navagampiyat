Public Class RatePosting
    Private Sub Barcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Barcode.Validating
        If Trim(Barcode.Text) <> "" Then
            Dim iid As Integer = ob.FindOneString("select Itemid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
            Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
            itemname.Tag = iid
            Sizename.Text = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())

            rate.Text = ob.FindOneString("Select MRP From Acstock Where barcode='" & Barcode.Text & "' and ptype='Purchase' order by billdate desc", ob.getconnection())
            If Val(rate.Text) = 0 Then
                rate.Text = ob.FindOneString("Select MRP From Acstock Where barcode='" & Barcode.Text & "' and ptype='Opening'", ob.getconnection())
            End If
            Prate.Text = ob.FindOneString("Select PDTRate From Acstock Where barcode='" & Barcode.Text & "' and ptype='Purchase' order by billdate desc", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ob.Execute("Update Acstock Set MRP=" & rate.Text & " where barcode='" & Barcode.Text & "'", ob.getconnection())
        MessageBox.Show("Update")
    End Sub

    Private Sub Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Barcode.KeyDown
        If e.KeyCode = Keys.F2 Then
            FrmShowItem.Show()
        End If
    End Sub
End Class