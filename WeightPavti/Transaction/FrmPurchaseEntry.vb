Imports WeightPavti.CLS
Imports System.Data.SqlClient
Public Class FrmPurchaseEntry
    Dim barc As String
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles rate.KeyDown, qty.KeyDown, itemname.KeyDown, acname.KeyDown, Cname.KeyDown, basci.KeyDown, Roundoff.KeyDown, tsgst.KeyDown, tcgst.KeyDown, sgstamt.KeyDown, sgst.KeyDown, cgstamt.KeyDown, cgst.KeyDown, amount.KeyDown, Billno.KeyDown, billDt.KeyDown, Cmbdepartment.KeyDown, cmbType.KeyDown, Remarks.KeyDown, comamt.KeyDown, txtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles cgstamt.TextChanged

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles sgstamt.TextChanged

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles tsgst.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub acname_ImeModeChanged(sender As Object, e As EventArgs) Handles acname.ImeModeChanged

    End Sub

    Private Sub cmbType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbType.Validating
        newnum()
        loadg()
        If cmbType.Text = "credit" Then
            If Cmbdepartment.Text = "khatar" Then
                acname.Tag = 104
                acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
            Else
                acname.Tag = 311
                acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
            End If
        Else
                acname.Tag = 149
            acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
        End If
    End Sub
    Public Sub newnum()
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "' and Department='" & Trim(Cmbdepartment.Text) & "' and Billtype='" & Trim(cmbType.Text) & "' and ptype='Purchase'", ob.getconnection())

    End Sub

    Private Sub FrmSalesEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Now
        fromdt.Text = Now
        todt.Text = Now
        TxtFill("Select Member_name from Member_Master", Cname)
        'TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Remarks from Acmain", Remarks)
        Cmbdepartment.SelectedIndex = 0
        cmbType.SelectedIndex = 0

        srno.Text = 1
    End Sub
    Public Sub TxtFill(ByVal Sqlstring As String, ByVal txtBox As TextBox)
        Dim sStringColl As New AutoCompleteStringCollection
        Dim qryCity As String
        Dim SqlConnString As String = "Password=advsys;Data Source=" & servername & ";Initial Catalog=" & dbname & ";Integrated Security=False;Persist Security Info=False;User ID=advsys;Max Pool Size=5000;Connect Timeout=0"
        qryCity = "SELECT DISTINCT NAME FROM ACMASTER  ORDER By NAME"

        Using connection As New SqlConnection(SqlConnString)

            Dim cmdCity As New SqlCommand(Sqlstring, connection)
            connection.Open()

            Dim city_reader As SqlDataReader = cmdCity.ExecuteReader()

            ' Loop through the data.
            While city_reader.Read()
                sStringColl.AddRange(New String() {Trim(city_reader(0).ToString)})
            End While

            city_reader.Close()
        End Using
        txtBox.AutoCompleteCustomSource = sStringColl
        txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub Cname_Validated(sender As Object, e As EventArgs) Handles Cname.Validated
        If Cname.Text <> "" Then
            Cname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Cname.Text) & "' or Member_Id=" & Val(Cname.Text) & "", ob.getconnection())
            If Val(Cname.Tag) <> 0 Then
                Cname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())
                chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub
    Public Sub chaln()
        Dim dt As DataTable = ob.Returntable("select * from acmain where Partyid=" & Val(Cname.Tag) & " and ch=0 and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dgchalan.Rows.Count > 0 Then
                Dgchalan.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dgchalan.Rows.Add()
                Dgchalan.Rows(Dgchalan.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Billno")
                Dgchalan.Rows(Dgchalan.Rows.Count - 1).Cells(2).Value = Format(dt.Rows(i).Item("Billdate"), "dd/MM/yyyy")
                Dgchalan.Rows(Dgchalan.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Netamt")
            Next
        End If
    End Sub

    Private Sub Cmbdepartment_Validated(sender As Object, e As EventArgs) Handles Cmbdepartment.Validated
        TxtFill("Select Item_Name from  Item_Master where Department='" & Trim(Cmbdepartment.Text) & "'", itemname)

    End Sub



    Private Sub itemname_Validated(sender As Object, e As EventArgs) Handles itemname.Validated
        'If itemname.Text <> "" Then
        '    'itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
        '    ' lblstock.Text = "2.00"
        '    itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
        '    itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & "", ob.getconnection())
        '    cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
        '    sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
        '    rate.Text = ob.FindOneString("Select sell_rate From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())

        'End If
        If Trim(Cmbdepartment.Text) = "BHANDAR" Then
            Dim iid As String = itemname.Text
            Dim icoun As String = iid.Length
            If Val(icoun) > 4 Then
                barc = itemname.Text
                itemname.Tag = ob.FindOneString("Select itemId From Acstock Where Barcode='" & Val(itemname.Text) & "'", ob.getconnection())
                itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
                'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & barc & "'", ob.getconnection())
                cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                rate.Text = ob.FindOneString("Select Rate from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & barc & "' and ptype='Purchase'", ob.getconnection())
            Else
                itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
                itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
                'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
                cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                rate.Text = ob.FindOneString("Select Rate from acstock where itemid=" & Val(itemname.Tag) & " and  ptype='Purchase'", ob.getconnection())
            End If
        Else
            itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
            cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            rate.Text = ob.FindOneString("Select sell_rate From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
        End If

        'Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub

    Private Sub rate_Validated(sender As Object, e As EventArgs) Handles rate.Validated
        If rate.Text <> "" Then
            amount.Text = Format(Val(qty.Text) * Val(rate.Text), "###0.00")
        End If
        Dim amt As Double
        amt = Val(amount.Text)
        Dim mAmt As Double
        mAmt = Val(amt) * (Val(cgst.Text) + Val(sgst.Text))
        mAmt = mAmt / (100 + Val(cgst.Text) + Val(sgst.Text))
        mAmt = Math.Round(mAmt, 4)
        cgstamt.Text = Format(Val(amt - mAmt) * Val(cgst.Text) / 100, "###0.00")
        sgstamt.Text = Format(Val(amt - mAmt) * Val(sgst.Text) / 100, "###0.00")
        Netamt.Text = amt
        amount.Text = Format(Val(amt) - (Val(cgstamt.Text) + Val(sgstamt.Text)), "###0.00")
        'Netamt.Focus()
    End Sub

    Private Sub srno_KeyDown(sender As Object, e As KeyEventArgs) Handles srno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If srno.Text = 0 Then
                tcgst.Focus()
            Else
                SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Private Sub Netamt_KeyDown(sender As Object, e As KeyEventArgs) Handles Netamt.KeyDown
        If Val(srno.Text) > Dg.Rows.Count Then
            Dg.Rows.Add()
            Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
            Dg.Rows(srno.Text - 1).Cells(1).Value = itemname.Text
            Dg.Rows(srno.Text - 1).Cells(1).Tag = itemname.Tag
            Dg.Rows(srno.Text - 1).Cells(2).Value = qty.Text
            Dg.Rows(srno.Text - 1).Cells(3).Value = rate.Text
            Dg.Rows(srno.Text - 1).Cells(4).Value = amount.Text
            Dg.Rows(srno.Text - 1).Cells(5).Value = cgst.Text
            Dg.Rows(srno.Text - 1).Cells(6).Value = cgstamt.Text
            Dg.Rows(srno.Text - 1).Cells(7).Value = sgst.Text
            Dg.Rows(srno.Text - 1).Cells(8).Value = sgstamt.Text
            Dg.Rows(srno.Text - 1).Cells(9).Value = Netamt.Text
            srno.Text = srno.Text + 1

        Else
            Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
            Dg.Rows(srno.Text - 1).Cells(1).Value = itemname.Text
            Dg.Rows(srno.Text - 1).Cells(1).Tag = itemname.Tag
            Dg.Rows(srno.Text - 1).Cells(2).Value = qty.Text
            Dg.Rows(srno.Text - 1).Cells(3).Value = rate.Text
            Dg.Rows(srno.Text - 1).Cells(4).Value = amount.Text
            Dg.Rows(srno.Text - 1).Cells(5).Value = cgst.Text
            Dg.Rows(srno.Text - 1).Cells(6).Value = cgstamt.Text
            Dg.Rows(srno.Text - 1).Cells(7).Value = sgst.Text
            Dg.Rows(srno.Text - 1).Cells(8).Value = sgstamt.Text
            Dg.Rows(srno.Text - 1).Cells(9).Value = Netamt.Text
            srno.Text = Dg.Rows.Count + 1

        End If
        addlist()
    End Sub
    Public Sub addlist()
        Dim x As Double
        Dim y As Double
        Dim z As Double
        Dim t As Double
        Dim g As Double
        Dim i As Integer
        For i = 0 To Dg.Rows.Count - 1
            x = x + Val(Dg.Rows(i).Cells(6).Value)
            y = y + Val(Dg.Rows(i).Cells(4).Value)
            z = z + Val(Dg.Rows(i).Cells(9).Value)
            't = t + Val(Me.ListView1.Items.Item(i).SubItems(12).Text)
            'g = g + Val(Me.ListView1.Items.Item(i).SubItems(3).Text)

            Me.tcgst.Text = Format(x, "###0.00")
            Me.tsgst.Text = Format(x, "###0.00")
            Me.basci.Text = Format(y, "###0.00")
            Me.tNetamt.Text = Format(z, "###0.00")
        Next
        itemname.Clear()
        rate.Clear()
        qty.Clear()
        amount.Clear()
        cgst.Clear()
        cgstamt.Clear()
        sgst.Clear()
        sgstamt.Clear()
        Netamt.Clear()
        srno.Focus()
    End Sub

    Private Sub tNetamt_KeyDown(sender As Object, e As KeyEventArgs) Handles tNetamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButSave.Focus()
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = billDt.Text

        If sdate >= gFinYearBegin And sdate <= gFinYearEnd Then
            Dim dac As String = acname.Tag
            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Department='Khatar' and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())

            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, gst, Basic, Roundoff, Netamt,ReceiptAmt,ptype,rate,lessamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & aq(cmbType.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(Cname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Remarks.Text) & "'," & Val(tcgst.Text) & "," & Val(basci.Text) & "," & Val(Roundoff.Text) & "," & Val(tNetamt.Text) & "," & Val(tNetamt.Text) & ",'Purchase'," & Val(comamt.Text) & "," & Val(txtDisc.Text) & ")", ob.getconnection())
            For i As Integer = 0 To Dg.Rows.Count - 1
                Dim spid As String
                If Cmbdepartment.Text = "Bhandar" Then
                    Dim iid As String = ob.FindOneString("select Itemid from Acstock where barcode='" & Dg.Rows(i).Cells(1).Tag & "'", ob.getconnection())
                    spid = ob.FindOneString("Select pid from Item_Master Where Item_id=" & Val(iid) & "", ob.getconnection())
                Else
                    spid = ob.FindOneString("Select pid from Item_Master Where Item_id=" & Dg.Rows(i).Cells(1).Tag & "", ob.getconnection())
                End If
                'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & Dg.Rows(i).Cells(1).Value & "'," & Dg.Rows(i).Cells(9).Value & ",N'" & Trim(Remarks.Text) & "',0,'Purchase')", ob.getconnection())
                'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Dg.Rows(i).Cells(9).Value & ",N'" & Trim(Remarks.Text) & "',0,'Purchase')", ob.getconnection())
                If Val(comamt.Text) <> 0 Then
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & Dg.Rows(i).Cells(1).Value & "'," & Dg.Rows(i).Cells(9).Value & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(Dg.Rows(i).Cells(9).Value) - Val(comamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',32,N'" & acname.Text & "'," & Val(comamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())

                Else
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & Dg.Rows(i).Cells(1).Value & "'," & Dg.Rows(i).Cells(9).Value & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Dg.Rows(i).Cells(9).Value & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                End If
            Next
            For i As Integer = 0 To Dg.Rows.Count - 1
                If Cmbdepartment.Text = "Bhandar" Then
                    Dim iid As String = ob.FindOneString("select Itemid from Acstock where barcode='" & Dg.Rows(i).Cells(1).Tag & "'", ob.getconnection())
                    ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout, Rate, Basic, CGST, SGST, CGSTAMT, SGSTAMT,ptype,itemid,Billtype) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "','" & Dg.Rows(i).Cells(2).Value & "',0," & Dg.Rows(i).Cells(3).Value & "," & Dg.Rows(i).Cells(4).Value & "," & Dg.Rows(i).Cells(5).Value & "," & Dg.Rows(i).Cells(7).Value & "," & Dg.Rows(i).Cells(6).Value & "," & Dg.Rows(i).Cells(8).Value & ",'Purchase'," & Val(iid) & "," & aq(cmbType.Text) & ")", ob.getconnection())
                Else
                    ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout, Rate, Basic, CGST, SGST, CGSTAMT, SGSTAMT,ptype,itemid,Billtype) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "','" & Dg.Rows(i).Cells(2).Value & "',0," & Dg.Rows(i).Cells(3).Value & "," & Dg.Rows(i).Cells(4).Value & "," & Dg.Rows(i).Cells(5).Value & "," & Dg.Rows(i).Cells(7).Value & "," & Dg.Rows(i).Cells(6).Value & "," & Dg.Rows(i).Cells(8).Value & ",'Purchase'," & Dg.Rows(i).Cells(1).Tag & "," & aq(cmbType.Text) & ")", ob.getconnection())
                End If
            Next

            If Val(Roundoff.Text) <> 0 Then
                If Val(Roundoff.Text) > 0 Then
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'90'," & Val(Roundoff.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(dac) & ",N'102',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                Else
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(dac) & ",N'90',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'139'," & Val(Roundoff.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase','" & Cmbdepartment.Text & "')", ob.getconnection())
                End If
            End If

            'If Val(comamt.Text) <> 0 Then
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "',0,N'" & Trim(Remarks.Text) & "'," & Val(comamt.Text) & ",'Purchase')", ob.getconnection())
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',32,N'" & acname.Text & "'," & Val(comamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase')", ob.getconnection())
            'End If

            If Val(txtDisc.Text) <> 0 Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(txtDisc.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Purchase')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'" & acname.Text & "',0,N'" & Trim(Remarks.Text) & "'," & Val(txtDisc.Text) & ",'Purchase')", ob.getconnection())
            End If

            chalantrue()
            MessageBox.Show("Save")
            clear()
            loadg()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            billDt.Focus()
        End If

    End Sub
    Public Sub chalantrue()
        For i As Integer = 0 To Dgchalan.Rows.Count - 1
            If Dgchalan.Rows(i).Cells(0).Value = True Then
                ob.Execute("Update Acmain Set ch=1 where Billno=" & Dgchalan.Rows(i).Cells(1).Value & " and department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
                ob.Execute("Update Acstock Set cht=1 where Billno=" & Dgchalan.Rows(i).Cells(1).Value & " and department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            End If
        Next
    End Sub
    Public Sub clear()
        '     cmbType.Text = ""
        Billno.Clear()
        Cname.Clear()
        ' Columnname.Clear()
        acname.Clear()
        'adharno.Clear()
        Remarks.Clear()
        tcgst.Clear()
        tsgst.Clear()
        basci.Clear()
        Roundoff.Clear()
        tNetamt.Clear()
        txtDisc.Clear()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Cmbdepartment.Focus()
        If Dgchalan.Rows.Count > 0 Then
            Dgchalan.Rows.Clear()
        End If
    End Sub
    Public Sub loadg()
        If Trim(Cmbdepartment.Text) <> "" Then
            If Trim(cmbType.Text) <> "" Then
                Dim dt As DataTable = ob.Returntable("select BillNo,BillDate,Partyid,netamt from Acmain where Billdate between '" & ob.DateConversion(fromdt.Text) & "' and '" & ob.DateConversion(todt.Text) & "' and department='" & Trim(Cmbdepartment.Text) & "' and billtype='" & Trim(cmbType.Text) & "' and ptype='Purchase'", ob.getconnection())
                If Dgview.Rows.Count > 0 Then
                    Dgview.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dgview.Rows.Add()
                    Dgview.Rows(Dgview.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("BillNo")
                    Dgview.Rows(Dgview.Rows.Count - 1I).Cells(1).Value = Format(dt.Rows(i).Item("BillDate"), "dd/MM/yyyy")
                    Dgview.Rows(Dgview.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Partyid")
                    Dgview.Rows(Dgview.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("netamt")
                    Dgview.Rows(Dgview.Rows.Count - 1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 10, FontStyle.Regular)
                Next
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadg()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Dgchalan.Rows.Count > 0 Then

            For i As Integer = 0 To Dgchalan.Rows.Count - 1
                ' Dg.Rows.Add()
                ' Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("BillNo")
                If Dgchalan.Rows(i).Cells(0).Value = True Then
                    Dim dt As DataTable = ob.Returntable("select * from Acstock where BillNo=" & Dgchalan.Rows(i).Cells(1).Value & " and Department='" & Trim(Cmbdepartment.Text) & "' and Cht=0 and ptype='malavak'", ob.getconnection())
                    If dt.Rows.Count > 0 Then
                        For ids As Integer = 0 To dt.Rows.Count - 1
                            Dg.Rows.Add()
                            Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = ids + 1
                            Dg.Rows(Dg.Rows.Count - 1).Cells(1).Tag = dt.Rows(ids).Item("Itemid")
                            Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("Select item_name from Item_master where Item_id=" & dt.Rows(ids).Item("Itemid") & "", ob.getconnection())
                            Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = dt.Rows(ids).Item("Stockin")
                            Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = dt.Rows(ids).Item("Rate")
                            Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = dt.Rows(ids).Item("Basic")
                            Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = 0
                            Dg.Rows(Dg.Rows.Count - 1).Cells(6).Value = 0
                            Dg.Rows(Dg.Rows.Count - 1).Cells(7).Value = 0
                            Dg.Rows(Dg.Rows.Count - 1).Cells(8).Value = 0
                            Dg.Rows(Dg.Rows.Count - 1).Cells(9).Value = 0



                        Next
                    End If
                End If

            Next
            srno.Focus()
        Else
            MessageBox.Show("No Pending Chalan FOund")
        End If
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        For i As Integer = 0 To Dg.Rows.Count - 1
            If srno.Text = Dg.Rows(i).Cells(0).Value Then
                itemname.Tag = Dg.Rows(i).Cells(1).Tag
                itemname.Text = Dg.Rows(i).Cells(1).Value
                qty.Text = Dg.Rows(i).Cells(2).Value
                rate.Text = Dg.Rows(i).Cells(3).Value
                basci.Text = Dg.Rows(i).Cells(4).Value
                cgst.Text = Dg.Rows(i).Cells(5).Value
                cgstamt.Text = Dg.Rows(i).Cells(6).Value
                sgst.Text = Dg.Rows(i).Cells(7).Value
                sgstamt.Text = Dg.Rows(i).Cells(8).Value
                Netamt.Text = Dg.Rows(i).Cells(9).Value
            End If
        Next
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & " and Billtype='" & Trim(cmbType.Text) & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Purchase' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                Cname.Tag = dt.Rows(0).Item("partyid")
                Cname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())

                cmbType.Text = dt.Rows(0).Item("Billtype")
                acname.Tag = dt.Rows(0).Item("acID")
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                Remarks.Text = dt.Rows(0).Item("Remarks")
                acname.Enabled = False
                tcgst.Text = dt.Rows(0).Item("gst")
                tsgst.Text = dt.Rows(0).Item("gst")
                Roundoff.Text = dt.Rows(0).Item("Roundoff")
                tNetamt.Text = dt.Rows(0).Item("ReceiptAmt")
                basci.Text = dt.Rows(0).Item("Basic")
                comamt.Text = dt.Rows(0).Item("rate")
                txtDisc.Text = dt.Rows(0).Item("Lessamt")

                Dim dts As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & " and Billtype='" & Trim(cmbType.Text) & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Purchase' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                End If
                For i As Integer = 0 To dts.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(i).Cells(0).Value = i + 1
                    Dim iname As String = ob.FindOneString("select item_name from Item_master where Item_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                    Dg.Rows(i).Cells(1).Value = iname
                    Dg.Rows(i).Cells(1).Tag = dts.Rows(i).Item("Itemid")
                    Dg.Rows(i).Cells(2).Value = dts.Rows(i).Item("Stockin")
                    Dg.Rows(i).Cells(3).Value = dts.Rows(i).Item("Rate")
                    Dg.Rows(i).Cells(4).Value = dts.Rows(i).Item("Basic")
                    Dg.Rows(i).Cells(5).Value = dts.Rows(i).Item("CGST")
                    Dg.Rows(i).Cells(6).Value = dts.Rows(i).Item("CGSTAMT")
                    Dg.Rows(i).Cells(7).Value = dts.Rows(i).Item("SGST")
                    Dg.Rows(i).Cells(8).Value = dts.Rows(i).Item("SGSTAMT")
                    Dg.Rows(i).Cells(9).Value = Val(dts.Rows(i).Item("Rate")) * Val(dts.Rows(i).Item("Stockin"))
                Next
            End If
        End If
    End Sub

    Private Sub Roundoff_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Roundoff.Validating
        Dim net As Double
        If Val(tNetamt.Text) <> 0 Then
            net = Val(tNetamt.Text)
            tNetamt.Text = Math.Round(Val(tNetamt.Text), 0, MidpointRounding.AwayFromZero)
            Roundoff.Text = Val(tNetamt.Text) - Val(net)
            Roundoff.Text = Format(Val(Roundoff.Text), "#0.00")
        End If
        tNetamt.Text = Format(Math.Round(Val(tNetamt.Text)), "######0.00")
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub comamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles comamt.Validating
        tNetamt.Text = Val(tNetamt.Text) - Val(comamt.Text)
    End Sub

    Private Sub txtDisc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDisc.Validating
        tNetamt.Text = Val(tNetamt.Text) - Val(txtDisc.Text)

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Departmen='" & Cmbdepartment.Text & "' and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Department='" & Cmbdepartment.Text & "' and ptype='Purchase' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("delete")
        clear()
    End Sub

    Private Sub billDt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles billDt.Validating
        ob.validdate(sender, billDt.Text, True)
    End Sub
End Class