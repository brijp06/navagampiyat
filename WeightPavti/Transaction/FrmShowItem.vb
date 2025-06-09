Imports WeightPavti.CLS
Public Class FrmShowItem
    Dim rw As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        If txtsearch.Text <> "" Then
            Dim dt As DataTable = ob.Returntable("select barcode,itemid,Item_Name,sizeid,Size_Name from acstock as ass inner join ITEM_MASTER as im on ass.Itemid=im.Item_Id inner join Size_Master as sm on ass.Sizeid=sm.Size_Id where Item_Name Like  N'" & Trim(txtsearch.Text) & "%' and ptype<>'Purchase' group by barcode,itemid,Item_Name,sizeid,Size_Name", ob.getconnection())
            If dt.Rows.Count > 0 Then
                If dg.Rows.Count > 0 Then
                    dg.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    dg.Rows.Add()
                    dg.Rows(dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("barcode")
                    dg.Rows(dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("itemid")
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Item_Name")
                    dg.Rows(dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("sizeid")
                    dg.Rows(dg.Rows.Count - 1).Cells(4).Value = dt.Rows(i).Item("Size_Name")
                    Dim Rate As String = ob.FindOneString("Select MRP From Acstock Where barcode='" & dt.Rows(i).Item("barcode") & "' and ptype='Purchase' order by billno desc", ob.getconnection())
                    If Val(Rate) = 0 Then
                        Rate = ob.FindOneString("Select MRP From Acstock Where barcode='" & dt.Rows(i).Item("barcode") & "' and ptype='Opening'", ob.getconnection())
                    End If
                    dg.Rows(dg.Rows.Count - 1).Cells(5).Value = Val(Rate)
                    dg.Rows(dg.Rows.Count - 1).Cells(4).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("SHRUTI", 12, FontStyle.Regular)
                    dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                    dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                    dg.Rows(dg.Rows.Count - 1).Cells(5).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Next
            End If
        End If
    End Sub

    Private Sub dg_KeyDown(sender As Object, e As KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = Keys.Enter Then
            FrmSalesEntryBhandar.Barcode.Text = dg.Rows(dg.CurrentRow.Index).Cells(0).Value
            FrmPurchaseEntryBhandar.Barcode.Text = dg.Rows(dg.CurrentRow.Index).Cells(0).Value
            RatePosting.Barcode.Text = dg.Rows(dg.CurrentRow.Index).Cells(0).Value
            Me.Close()
            '   Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
            FrmSalesEntryBhandar.Barcode.Focus()
            FrmPurchaseEntryBhandar.Barcode.Focus()
            RatePosting.Barcode.Focus()
        End If
    End Sub

    Private Sub dg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dg.KeyPress

    End Sub

    Private Sub txtsearch_Enter(sender As Object, e As EventArgs) Handles txtsearch.Enter
        'Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub
End Class