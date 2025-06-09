Imports WeightPavti.CLS
Public Class FrmPackingEntry
    Private Sub Cmbdepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsizename.KeyDown, txtqty.KeyDown, txtitemname.KeyDown, txtitemid.KeyDown, txtbarcode.KeyDown, srno.KeyDown, Sizename.KeyDown, qty.KeyDown, itemname.KeyDown, Itemid.KeyDown, Cmbdepartment.KeyDown, Billno.KeyDown, billDt.KeyDown, Barcode.KeyDown, padtrate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub FrmPackingEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Now
        newnum()
        srno.Text = 1
        Cmbdepartment.SelectedIndex = 0
    End Sub
    Public Sub newnum()
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "' and Department='BHANDAR' and Billtype='Transfer' and ptype='Transfer'", ob.getconnection())
    End Sub

    Private Sub Barcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Barcode.Validating
        If Barcode.Text <> "" Then
            Dim iid As Integer = ob.FindOneString("select Itemid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
            Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
            itemname.Tag = iid
            Itemid.Text = iid
            Sizename.Text = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
            lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & Barcode.Text & "'", ob.getconnection())
            qty.Focus()
        Else
            Itemid.Focus()

        End If
    End Sub

    Private Sub txtbarcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtbarcode.Validating
        If txtbarcode.Text <> "" Then
            Dim iid As Integer = ob.FindOneString("select Itemid from Acstock where barcode='" & txtbarcode.Text & "'", ob.getconnection())
            Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & txtbarcode.Text & "'", ob.getconnection())
            txtitemname.Tag = iid
            txtitemid.Text = iid
            txtsizename.Text = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
            txtitemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(txtitemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & Barcode.Text & "'", ob.getconnection())
            txtqty.Focus()
        Else
            txtitemid.Focus()

        End If
    End Sub

    Private Sub MRP_KeyDown(sender As Object, e As KeyEventArgs) Handles MRP.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Val(srno.Text) > Dg.Rows.Count Then
                Dg.Rows.Add()
                Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                Dg.Rows(srno.Text - 1).Cells(2).Value = txtitemname.Text
                Dg.Rows(srno.Text - 1).Cells(2).Tag = txtitemname.Tag
                Dg.Rows(srno.Text - 1).Cells(3).Value = txtsizename.Text
                Dg.Rows(srno.Text - 1).Cells(3).Tag = txtsizename.Tag
                Dg.Rows(srno.Text - 1).Cells(1).Value = txtbarcode.Text
                Dg.Rows(srno.Text - 1).Cells(4).Value = txtqty.Text
                Dg.Rows(srno.Text - 1).Cells(5).Value = padtrate.Text
                Dg.Rows(srno.Text - 1).Cells(6).Value = MRP.Text
                Dg.Rows(srno.Text - 1).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
                srno.Text = srno.Text + 1
                cal()
            Else
                Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                Dg.Rows(srno.Text - 1).Cells(2).Value = txtitemname.Text
                Dg.Rows(srno.Text - 1).Cells(2).Tag = txtitemname.Tag
                Dg.Rows(srno.Text - 1).Cells(3).Value = txtsizename.Text
                Dg.Rows(srno.Text - 1).Cells(3).Tag = txtsizename.Tag
                Dg.Rows(srno.Text - 1).Cells(1).Value = txtbarcode.Text
                Dg.Rows(srno.Text - 1).Cells(4).Value = txtqty.Text
                Dg.Rows(srno.Text - 1).Cells(5).Value = padtrate.Text
                Dg.Rows(srno.Text - 1).Cells(6).Value = MRP.Text
                Dg.Rows(srno.Text - 1).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
                srno.Text = srno.Text + 1
                cal()
            End If
            txtitemname.Clear()
            txtitemid.Clear()
            txtsizename.Clear()
            txtqty.Clear()
            txtbarcode.Clear()
            padtrate.Clear()
            MRP.Clear()
            srno.Focus()
        End If
    End Sub
    Public Sub cal()
        Dim tt As Double = 0
        For i = 0 To Dg.Rows.Count - 1
            tt += Val(Dg.Rows(i).Cells(4).Value)
        Next
        tqty.Text = Val(tt)
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        If srno.Text <> 0 Then
            For i As Integer = 0 To Dg.Rows.Count - 1
                If srno.Text = Dg.Rows(i).Cells(0).Value Then
                    txtbarcode.Text = Dg.Rows(i).Cells(1).Value
                    txtitemname.Tag = Dg.Rows(i).Cells(2).Tag
                    txtitemid.Text = Dg.Rows(i).Cells(2).Tag
                    txtitemname.Text = Dg.Rows(i).Cells(2).Value
                    txtsizename.Text = Dg.Rows(i).Cells(3).Value
                    txtqty.Text = Dg.Rows(i).Cells(4).Value
                    padtrate.Text = Dg.Rows(i).Cells(5).Value
                    MRP.Text = Dg.Rows(i).Cells(6).Value
                End If
            Next
        Else
            ButSave.Focus()
        End If

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = billDt.Text
        'If Val(qty.Text) <> Val(tqty.Text) Then
        '    MessageBox.Show("Place Chek Qunty...")
        '    txtqty.Focus()
        '    Exit Sub
        'End If

        If sdate >= gFinYearBegin And sdate <= gFinYearEnd Then
            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and billtype='Transfer' and Department=" & aq(Cmbdepartment.Text) & " and ptype='Transfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and billtype='Transfer' and Department=" & aq(Cmbdepartment.Text) & " and ptype='Transfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and billtype='Transfer' and Department=" & aq(Cmbdepartment.Text) & " and ptype='STransfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & ",'Transfer'," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "','Transfer')", ob.getconnection())
            For i As Integer = 0 To Dg.Rows.Count - 1
                Dim iid As String = ob.FindOneString("select Size_id from Size_Master where Size_Name='" & Dg.Rows(i).Cells(3).Value & "'", ob.getconnection())
                ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout,ptype,itemid,Sizeid,barcode,billtype,srno,pdtrate,MRP) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",0,'Transfer'," & Val(Dg.Rows(i).Cells(2).Tag) & ",'" & (iid) & "','" & Trim(Dg.Rows(i).Cells(1).Value) & "','Transfer'," & Val(Dg.Rows(i).Cells(0).Value) & "," & Val(Dg.Rows(i).Cells(5).Value) & "," & Val(Dg.Rows(i).Cells(6).Value) & ")", ob.getconnection())
            Next
            Dim iids As String = ob.FindOneString("select Size_id from Size_Master where Size_Name='" & Sizename.Text & "'", ob.getconnection())
            ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout,ptype,itemid,Sizeid,barcode,billtype,srno) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',0," & Val(qty.Text) & ",'STransfer'," & Val(Itemid.Text) & ",'" & (iids) & "','" & Trim(Barcode.Text) & "','Transfer',1)", ob.getconnection())
            MessageBox.Show("Save")
            clear()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            billDt.Focus()
        End If
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & " and Billtype='Transfer' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='STransfer' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                Barcode.Text = dt.Rows(0).Item("Barcode")
                Itemid.Text = dt.Rows(0).Item("Itemid")
                itemname.Text = ob.FindOneString("select item_name from Item_master where Item_id=" & Val(dt.Rows(0).Item("Itemid")) & "", ob.getconnection())
                itemname.Tag = dt.Rows(0).Item("Itemid")
                Sizename.Tag = dt.Rows(0).Item("sizeid")
                Sizename.Text = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(dt.Rows(0).Item("sizeid")) & "'", ob.getconnection())
                qty.Text = dt.Rows(0).Item("Stockout")
                Dim dts As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & " and Billtype='Transfer' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Transfer'", ob.getconnection())
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                End If
                For i As Integer = 0 To dts.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(i).Cells(0).Value = i + 1
                    Dg.Rows(i).Cells(1).Value = dts.Rows(i).Item("Barcode")
                    Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & dts.Rows(i).Item("Barcode") & "' and ptype='Transfer' and billtype='Transfer'", ob.getconnection())
                    Dg.Rows(i).Cells(3).Value = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
                    Dim iname As String = ob.FindOneString("select item_name from Item_master where Item_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                    Dg.Rows(i).Cells(2).Value = iname
                    Dg.Rows(i).Cells(2).Tag = dts.Rows(i).Item("Itemid")
                    Dg.Rows(i).Cells(4).Value = dts.Rows(i).Item("Stockin")
                    Dg.Rows(i).Cells(5).Value = dts.Rows(i).Item("pdtrate")
                    Dg.Rows(i).Cells(6).Value = dts.Rows(i).Item("MRP")
                    Dg.Rows(i).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
                Next
                'addlist()
                cal()
            End If
        End If
    End Sub
    Public Sub clear()
        ' cmbType.Text = ""
        Billno.Clear()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Cmbdepartment.Focus()
        Cmbdepartment.SelectedIndex = 0
        srno.Text = 1
        Barcode.Clear()
        itemname.Clear()
        Itemid.Clear()
        Sizename.Clear()
        qty.Clear()
        newnum()
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click

    End Sub
End Class