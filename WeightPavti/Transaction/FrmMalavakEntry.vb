Imports WeightPavti.CLS
Imports System.Data.SqlClient
Public Class FrmMalavakEntry
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles rate.KeyDown, qty.KeyDown, itemname.KeyDown, Cname.KeyDown, basci.KeyDown, Roundoff.KeyDown, amount.KeyDown, Billno.KeyDown, billDt.KeyDown, Cmbdepartment.KeyDown, Remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub acname_ImeModeChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        newnum()
        loadg()

    End Sub
    Public Sub newnum()
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak'", ob.getconnection())

    End Sub

    Private Sub FrmSalesEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Now
        fromdt.Text = Now
        todt.Text = Now
        TxtFill("Select Member_name from Member_Master", Cname)
        'TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Remarks from Acmain", Remarks)
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

            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub Cmbdepartment_Validated(sender As Object, e As EventArgs) Handles Cmbdepartment.Validated
        TxtFill("Select Item_Name from  Item_Master where Department='" & Trim(Cmbdepartment.Text) & "'", itemname)
        newnum()
    End Sub



    Private Sub itemname_Validated(sender As Object, e As EventArgs) Handles itemname.Validated
        If itemname.Text <> "" Then
            'itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            ' lblstock.Text = "2.00"
            itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & "", ob.getconnection())
            'cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            'sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            rate.Text = ob.FindOneString("Select Padt_rate From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())

        End If
    End Sub

    Private Sub rate_Validated(sender As Object, e As EventArgs) Handles rate.Validated
        If rate.Text <> "" Then
            amount.Text = Format(Val(qty.Text) * Val(rate.Text), "###0.00")
        End If

        'Netamt.Focus()
    End Sub

    Private Sub srno_KeyDown(sender As Object, e As KeyEventArgs) Handles srno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If srno.Text = 0 Then
                basci.Focus()
            Else
                SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Private Sub Netamt_KeyDown(sender As Object, e As KeyEventArgs) Handles amount.KeyDown
        If Val(srno.Text) > Dg.Rows.Count Then
            Dg.Rows.Add()
            Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
            Dg.Rows(srno.Text - 1).Cells(1).Value = itemname.Text
            Dg.Rows(srno.Text - 1).Cells(1).Tag = itemname.Tag
            Dg.Rows(srno.Text - 1).Cells(2).Value = qty.Text
            Dg.Rows(srno.Text - 1).Cells(3).Value = rate.Text
            Dg.Rows(srno.Text - 1).Cells(4).Value = amount.Text

        Else
            Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
            Dg.Rows(srno.Text - 1).Cells(1).Value = itemname.Text
            Dg.Rows(srno.Text - 1).Cells(1).Tag = itemname.Tag
            Dg.Rows(srno.Text - 1).Cells(2).Value = qty.Text
            Dg.Rows(srno.Text - 1).Cells(3).Value = rate.Text
            Dg.Rows(srno.Text - 1).Cells(4).Value = amount.Text
        End If
        srno.Text = Dg.Rows.Count + 1
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
            'x = x + Val(Dg.Rows(i).Cells(6).Value)
            y = y + Val(Dg.Rows(i).Cells(3).Value)
            z = z + Val(Dg.Rows(i).Cells(4).Value)
            't = t + Val(Me.ListView1.Items.Item(i).SubItems(12).Text)
            'g = g + Val(Me.ListView1.Items.Item(i).SubItems(3).Text)

            Me.basci.Text = Format(y, "###0.00")
            Me.tNetamt.Text = Format(z, "###0.00")
        Next
        itemname.Clear()
        rate.Clear()
        qty.Clear()
        amount.Clear()
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
            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & "and Department=" & aq(Cmbdepartment.Text) & " and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & "and Department=" & aq(Cmbdepartment.Text) & " and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billno, Billdate, PartyId, Remarks,  Basic, Roundoff, Netamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(Cname.Tag) & ",N'" & Trim(Remarks.Text) & "'," & Val(basci.Text) & "," & Val(Roundoff.Text) & "," & Val(tNetamt.Text) & ",'Malavak')", ob.getconnection())
            For i As Integer = 0 To Dg.Rows.Count - 1
                'Dim spid As String = ob.FindOneString("Select sid from Item_Master Where Item_id=" & Dg.Rows(i).Cells(1).Tag & "", ob.getconnection())
                ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout, Rate, Basic,ptype,itemid,Cht) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "','" & Dg.Rows(i).Cells(2).Value & "',0," & Dg.Rows(i).Cells(3).Value & "," & Dg.Rows(i).Cells(4).Value & ",'Malavak'," & Dg.Rows(i).Cells(1).Tag & ",0)", ob.getconnection())
            Next

            MessageBox.Show("Save")
            clear()
            loadg()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            billDt.Focus()
        End If
    End Sub
    Public Sub clear()
        ' cmbType.Text = ""
        Billno.Clear()
        Cname.Clear()
        ' Columnname.Clear()
        'acname.Clear()
        'adharno.Clear()
        Remarks.Clear()
        'tcgst.Clear()
        'tsgst.Clear()
        basci.Clear()
        Roundoff.Clear()
        tNetamt.Clear()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Cmbdepartment.Focus()

    End Sub
    Public Sub loadg()
        If Trim(Cmbdepartment.Text) <> "" Then
            ' If Trim(cmbType.Text) <> "" Then
            Dim dt As DataTable = ob.Returntable("select BillNo,BillDate,Partyid,netamt from Acmain where Billdate between '" & ob.DateConversion(fromdt.Text) & "' and '" & ob.DateConversion(todt.Text) & "' and department='" & Trim(Cmbdepartment.Text) & "' and  ptype='Malavak'", ob.getconnection())
            If Dgview.Rows.Count > 0 Then
                    Dgview.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dgview.Rows.Add()
                    Dgview.Rows(i).Cells(0).Value = dt.Rows(i).Item("BillNo")
                    Dgview.Rows(i).Cells(1).Value = Format(dt.Rows(i).Item("BillDate"), "dd/MM/yyyy")
                    Dgview.Rows(i).Cells(2).Value = dt.Rows(i).Item("Partyid")
                    Dgview.Rows(i).Cells(3).Value = dt.Rows(i).Item("netamt")
                    Dgview.Rows(i).DefaultCellStyle.Font = New Font("HARIKRISHNA", 10, FontStyle.Regular)
                Next
            'End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadg()
    End Sub

    Private Sub Remarks_TextChanged(sender As Object, e As EventArgs) Handles Remarks.TextChanged

    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & "  and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                Cname.Tag = dt.Rows(0).Item("partyid")
                Cname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())

                Dim dts As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & "  and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Malavak' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
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
                    Dg.Rows(i).Cells(4).Value = Val(dts.Rows(i).Item("Rate")) * Val(dts.Rows(i).Item("Stockin"))
                Next
                addlist()
            End If
        End If
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        For k = 0 To Dg.Rows.Count - 1
            If Val(Dg.Rows(k).Cells(0).Value) = Val(srno.Text) Then
                itemname.Text = Dg.Rows(k).Cells(1).Value
                itemname.Tag = Dg.Rows(k).Cells(1).Tag
                qty.Text = Dg.Rows(k).Cells(2).Value
                rate.Text = Dg.Rows(k).Cells(3).Value
                amount.Text = Dg.Rows(k).Cells(4).Value
            End If
        Next
    End Sub

    Private Sub billDt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles billDt.Validating
        ob.validdate(sender, billDt.Text, True)

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & "and Department=" & aq(Cmbdepartment.Text) & " and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & "and Department=" & aq(Cmbdepartment.Text) & " and ptype='Malavak' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("delete")
        clear()
    End Sub
End Class