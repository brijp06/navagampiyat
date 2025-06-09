Imports WeightPavti.CLS
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmSalesEntryBhandar
    Dim barc As String
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles acname.KeyDown, Columnname.KeyDown, Cname.KeyDown, basci.KeyDown, Roundoff.KeyDown, tsgst.KeyDown, tcgst.KeyDown, Billno.KeyDown, billDt.KeyDown, Cmbdepartment.KeyDown, cmbType.KeyDown, Remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles tsgst.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub acname_ImeModeChanged(sender As Object, e As EventArgs) Handles acname.ImeModeChanged

    End Sub

    Private Sub cmbType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbType.Validating
        newnum()
        loadg()
        If Trim(cmbType.Text) = "CASH" Or Trim(cmbType.Text) = "Cash1" Then
            Columnname.Tag = 1
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            Columnname.Enabled = False
            acname.Enabled = False
            Cname.Text = 9999
        Else
            If Trim(Cmbdepartment.Text) = "KHATAR" Then
                Columnname.Tag = 3
                Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                Columnname.Enabled = False
                acname.Enabled = False
                Cname.Clear()
            Else
                Columnname.Tag = 2
                Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                Columnname.Enabled = False
                acname.Enabled = False
                Cname.Clear()
            End If
        End If
    End Sub
    Public Sub newnum()
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "' and Department='" & Trim(Cmbdepartment.Text) & "' and Billtype='" & Trim(cmbType.Text) & "' and ptype='Sales'", ob.getconnection())
    End Sub

    Private Sub FrmSalesEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Now
        fromdt.Text = Now
        todt.Text = Now
        'TxtFill("Select Member_name from Member_Master", Cname)
        TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Remarks from Acmain", Remarks)
        Cmbdepartment.SelectedIndex = 0
        cmbType.SelectedIndex = 0
        srno.Text = 1
        Panel1.Visible = False
        txtprint.Text = 1
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
        If Trim(Cname.Text) <> "" Then
            Cname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Cname.Text) & "' or Member_Id=" & Val(Cname.Text) & "", ob.getconnection())
            If Val(Cname.Tag) <> 0 Then
                Cname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())
                adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())
            Else
                clsVariables.HelpId = "Member_id"
                clsVariables.HelpName = "Member_Name"
                clsVariables.TbName = "Member_Master"
                HelpWin.scodename = "Name"
                HelpWin.sorderby = " order by Member_Name"
                HelpWin.tsql = "Select Member_Id,Member_Name,v.village_Name from Member_Master inner join VILLAGE_MASTER as v on v.Village_Id=MEMBER_MASTER.Village_id where  Member_name Like N'" & Trim(Cname.Text) & "%'"
                HelpWin.ShowDialog()
                If clsVariables.RtnHelpId <> "" Then
                    Cname.Tag = clsVariables.RtnHelpId
                    Cname.Text = clsVariables.RtnHelpName
                    adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

                End If

            End If

        End If
        If Val(Cname.Tag) = 0 Then
            Cname.Focus()
            MessageBox.Show("કૃપા કરી સભાસદ નું નામ લખો")
        End If
        ' Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub

    Private Sub Cmbdepartment_Validated(sender As Object, e As EventArgs) Handles Cmbdepartment.Validated
        TxtFill("Select Item_Name from  Item_Master where Department='" & Trim(Cmbdepartment.Text) & "'", itemname)
    End Sub

    Private Sub Columnname_Validated(sender As Object, e As EventArgs) Handles Columnname.Validated
        If Columnname.Text <> "" Then
            Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            acname.Enabled = False
        End If
    End Sub

    Private Sub itemname_Validated(sender As Object, e As EventArgs)
        If itemname.Text <> "" Then
            If Trim(Cmbdepartment.Text) = "BHANDAR" Then
                Dim iid As String = itemname.Text
                Dim icoun As String = iid.Length
                If Val(icoun) > 4 Then
                    barc = itemname.Text
                    itemname.Tag = ob.FindOneString("Select itemId From Acstock Where Barcode='" & Val(itemname.Text) & "'", ob.getconnection())
                    itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
                    lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & barc & "'", ob.getconnection())
                    cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                    sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                    Rate.Text = ob.FindOneString("Select Rate from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & barc & "'", ob.getconnection())
                Else
                    itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
                    itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
                    lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
                    cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                    sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                    Rate.Text = ob.FindOneString("Select Rate from acstock where itemid=" & Val(itemname.Tag) & " and ptype='Opening'", ob.getconnection())
                End If
            Else
                itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
                itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
                lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
                cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
                Rate.Text = ob.FindOneString("Select sell_rate From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            End If
        End If
        '   Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub

    Private Sub rate_Validated(sender As Object, e As EventArgs)
        If Rate.Text <> "" Then
            Amount.Text = Format(Val(qty.Text) * Val(Rate.Text), "###0.00")
        End If
        Dim amt As Double
        amt = Val(Amount.Text)
        Dim mAmt As Double
        mAmt = Val(amt) * (Val(cgst.Text) + Val(sgst.Text))
        mAmt = mAmt / (100 + Val(cgst.Text) + Val(sgst.Text))
        mAmt = Math.Round(mAmt, 4)
        cgstamt.Text = Format(Val(amt - mAmt) * Val(cgst.Text) / 100, "###0.00")
        sgstamt.Text = Format(Val(amt - mAmt) * Val(sgst.Text) / 100, "###0.00")
        Netamt.Text = amt
        Amount.Text = Format(Val(amt) - (Val(cgstamt.Text) + Val(sgstamt.Text)), "###0.00")
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



    Private Sub tNetamt_KeyDown(sender As Object, e As KeyEventArgs) Handles tNetamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButSave.Focus()
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = billDt.Text

        If sdate >= gFinYearBegin And sdate <= gFinYearEnd Then
            Dim dac As String = 139

            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Sales' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Sales' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and ptype='Sales' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, gst, Basic, Roundoff, Netamt,PaymentAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & aq(cmbType.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(Cname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Remarks.Text) & "'," & Val(Columnname.Tag) & "," & Val(tcgst.Text) & "," & Val(basci.Text) & "," & Val(Roundoff.Text) & "," & Val(tNetamt.Text) & "," & Val(tNetamt.Text) & ",'Sales')", ob.getconnection())

            If Val(Roundoff.Text) < 0 Then
                Dim spid As String
                spid = ob.FindOneString("Select sid from Item_Master Where Item_id=" & Dg.Rows(0).Cells(2).Tag & "", ob.getconnection())


                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & Dg.Rows(0).Cells(1).Value & "'," & Val(tNetamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(tNetamt.Text) + Val(Math.Abs(Val(Roundoff.Text))) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())

            Else
                For i As Integer = 0 To Dg.Rows.Count - 1
                    Dim spid As String

                    spid = ob.FindOneString("Select sid from Item_Master Where Item_id=" & Dg.Rows(i).Cells(2).Tag & "", ob.getconnection())


                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & Dg.Rows(i).Cells(1).Value & "'," & Dg.Rows(i).Cells(11).Value & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Dg.Rows(i).Cells(11).Value & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
                Next
            End If


            For i As Integer = 0 To Dg.Rows.Count - 1
                'Dim spid As String = ob.FindOneString("Select sid from Item_Master Where Item_id=" & Dg.Rows(i).Cells(1).Tag & "", ob.getconnection())

                Dim iid As String = ob.FindOneString("select Size_id from Size_Master where Size_Name='" & Dg.Rows(i).Cells(3).Value & "'", ob.getconnection())
                ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,Stockin, Stockout, Rate, Basic, CGST, SGST, CGSTAMT, SGSTAMT,ptype,itemid,Sizeid,barcode,billtype,srno) Values(1,'" & clsVariables.WorkingYear & "','" & Cmbdepartment.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',0," & Dg.Rows(i).Cells(4).Value & "," & Dg.Rows(i).Cells(5).Value & "," & Dg.Rows(i).Cells(6).Value & "," & Dg.Rows(i).Cells(7).Value & "," & Dg.Rows(i).Cells(9).Value & "," & Dg.Rows(i).Cells(8).Value & "," & Dg.Rows(i).Cells(10).Value & ",'Sales'," & Val(Dg.Rows(i).Cells(2).Tag) & ",'" & (iid) & "','" & Trim(Dg.Rows(i).Cells(1).Value) & "','" & cmbType.Text & "'," & Val(Dg.Rows(i).Cells(0).Value) & ")", ob.getconnection())
            Next

            'If Val(Roundoff.Text) <> 0 Then
            '    If Val(Roundoff.Text) > 0 Then
            '        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'90'," & Val(Roundoff.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
            '        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(acname.Tag) & ",N'139',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())

            '    Else
            '        Roundoff.Text = Math.Abs(Val(Roundoff.Text))
            '        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(acname.Tag) & ",N'90',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
            '        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'139'," & Val(Roundoff.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())

            '    End If
            'End If

            If Val(Roundoff.Text) <> 0 Then
                If Val(Roundoff.Text) > 0 Then
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'90'," & Val(Roundoff.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(acname.Tag) & ",N'141',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())

                Else
                    'Roundoff.Text = Math.Abs(Val(Roundoff.Text))
                    'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(acname.Tag) & ",N'90',0,N'" & Trim(Remarks.Text) & "'," & Val(Roundoff.Text) & ",'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',90,N'139'," & Val(Math.Abs(Val(Roundoff.Text))) & ",N'" & Trim(Remarks.Text) & "',0,'Sales','" & Cmbdepartment.Text & "')", ob.getconnection())

                End If
            End If
            MessageBox.Show("Save")

            If Trim(cmbType.Text) = "Credit" Then
                If MessageBox.Show("Do You Want To Send SMS...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim mnum As String = ob.FindOneString("select Mobile_No from Member_Master where Member_id=" & Cname.Tag & "", ob.getconnection())
                    ' Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and Clid=" & Columnname.Tag & "", ob.getconnection())
                    Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and  acid=139", ob.getconnection())

                    Dim msg As String = "(KSMMOL)ભંડાર વિભાગ તા:-" & billDt.Text & " બીલ નં.:" & Billno.Text & " રકમ :" & tNetamt.Text & " બાકી રકમ રૂપિયા.:" & Val(bal) & " "
                    ob.SendSMSkm(mnum, msg)
                    Panel1.Visible = True
                    Label34.Text = tNetamt.Text
                    TextBox1.Focus()
                Else
                    Panel1.Visible = True
                    Label34.Text = tNetamt.Text
                    TextBox1.Focus()
                End If
            Else
                If MessageBox.Show("Do You Want To Send SMS...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Panel2.Visible = True
                    Mobileno.Focus()
                Else
                    '  Panel2.Visible = False
                    Panel1.Visible = True
                    Label34.Text = tNetamt.Text
                    TextBox1.Focus()
                End If
            End If
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            billDt.Focus()
        End If
        'Cal.Show()
        'Cal.Label1.Text = tNetamt.Text


    End Sub
    Public Sub clear()
        ' cmbType.Text = ""
        Billno.Clear()
        Cname.Clear()
        Columnname.Clear()
        acname.Clear()
        adharno.Clear()
        Remarks.Clear()
        tcgst.Clear()
        tsgst.Clear()
        basci.Clear()
        Roundoff.Clear()
        tNetamt.Clear()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Cmbdepartment.Focus()
        Cmbdepartment.SelectedIndex = 0
        cmbType.SelectedIndex = 0
        srno.Text = 1
        TextBox1.Clear()
        Panel1.Visible = False
        Mobileno.Clear()
    End Sub
    Public Sub loadg()
        If Trim(Cmbdepartment.Text) <> "" Then
            If Trim(cmbType.Text) <> "" Then
                Dim dt As DataTable = ob.Returntable("select BillNo,BillDate,Partyid,netamt from Acmain where Billdate between '" & ob.DateConversion(fromdt.Text) & "' and '" & ob.DateConversion(todt.Text) & "' and department='" & Trim(Cmbdepartment.Text) & "' and billtype='" & Trim(cmbType.Text) & "' and ptype='Sales'", ob.getconnection())
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
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadg()
    End Sub

    Private Sub ButPrint_Click(sender As Object, e As EventArgs) Handles ButPrint.Click
        Dim ssql As String
        ssql = "{Salesbillprintbhandar.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Salesbillprintbhandar.Department}=" & aq(Cmbdepartment.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Billtype}=" & aq(cmbType.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Year_id}=" & aq(clsVariables.WorkingYear)
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(tNetamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "BillPrintingThermal.rpt"
        print()
    End Sub
    Public Sub print()
        Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Text = clsVariables.Repheader & "                                              Report File Name : " & clsVariables.ReportName
        'If rpttype = "" Then
        '    Dim ds As DataSet = New DataSet()
        '    Dim adpt As SqlDataAdapter = New SqlDataAdapter
        '    sCommands.setsqlCommand(ds, adpt, clsVariables.ReportSql, clsVariables.RptTable)
        '    Dim report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
        '        MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.Close()
        '        Exit Sub
        '    End If
        '    report.Load(clsVariables.RptLocation & clsVariables.ReportName)
        '    report.SetDataSource(ds)
        '    report.SetParameterValue("@CompanyName", clsVariables.CompnyName)
        '    report.SetParameterValue("@Repheader", clsVariables.Repheader)
        '    report.SetParameterValue("@fromdate", clsVariables.FromDate)
        '    report.SetParameterValue("@Todate", clsVariables.ToDate)
        '    CrystalReportViewer1.ReportSource = report
        'Else
        If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
            MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If
        Dim crtableLogoninfos As New TableLogOnInfos()
        Dim crtableLogoninfo As New TableLogOnInfo()
        Dim crConnectionInfo As New ConnectionInfo()
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim crReportDocument As New ReportDocument()
        crReportDocument.Load(clsVariables.RptLocation & clsVariables.ReportName)
        Dim i As Integer
        i = 0
        If LCase(clsVariables.ReportName) <> LCase("NewRojmalReport.rpt") And LCase(clsVariables.ReportName) <> LCase("BankBookReport.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalTrialBalanceTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalBalanceSheetTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("PayslipPrinting.rpt") And LCase(clsVariables.ReportName) <> LCase("PadyRojmalReport.rpt") Then

            If LCase(clsVariables.ReportName) = LCase("OfficeReport.Rpt") Or LCase(clsVariables.ReportName) = LCase("JaminDetailReport.Rpt") Then
                Do While i < crReportDocument.Subreports.Count
                    crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql1
                    i += 1
                Loop
            Else
                Do While i < crReportDocument.Subreports.Count
                    '  crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSubSql(i)
                    i += 1
                Loop
            End If
        End If
        With crConnectionInfo
            .ServerName = "assdsn"
            .DatabaseName = dbname
            If DbAuth <> "WIN" Then
                .UserID = "advsys"
                .Password = "advsys"
            End If
        End With
        CrTables = crReportDocument.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        crReportDocument.VerifyDatabase()
        'If LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
        '    crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
        'End If
        i = 0
        Do While i < crReportDocument.ParameterFields.Count
            If LCase(crReportDocument.ParameterFields(i).Name) = LCase("@CompanyName") Then
                crReportDocument.SetParameterValue(i, clsVariables.CompnyName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@RepHeader") Then
                crReportDocument.SetParameterValue(i, clsVariables.Repheader)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@fromDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@toDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.ToDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@OpeningBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dOpeningBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@ClosingBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dClosingBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@NumtoWord") Then
                crReportDocument.SetParameterValue(i, clsVariables.NumtoWord)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Year_Id") Then
                crReportDocument.SetParameterValue(i, clsVariables.WorkingYear)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab1") Then
                '    crReportDocument.SetParameterValue(i, Slab1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Val1") Then
                '    crReportDocument.SetParameterValue(i, Val1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab2") Then
                '    crReportDocument.SetParameterValue(i, Slab2)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab3") Then
                '    crReportDocument.SetParameterValue(i, Slab3)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab4") Then
                '    crReportDocument.SetParameterValue(i, Slab4)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab5") Then
                '    crReportDocument.SetParameterValue(i, Slab5)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab6") Then
                'crReportDocument.SetParameterValue(i, Slab6)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@UserName") Then
                crReportDocument.SetParameterValue(i, fulluserName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Date") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate & " To " & clsVariables.ToDate)

                '    crReportDocument.SetParameterValue(i, MdiMain.ComboDept.Text)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTDRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtDbIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTCRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtCrIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@BasedRate") Then
                '    crReportDocument.SetParameterValue(i, BasedRate)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Season_Id") Then
                '    crReportDocument.SetParameterValue(i, Season_Id)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Department_Id") Then
                '    crReportDocument.SetParameterValue(i, Val(MdiMain.ComboDept.SelectedValue))
            End If
            i += 1
        Loop
        'CrystalReportViewer1.ParameterFieldInfo = pf
        ' Dim pr As String
        ' pr = clsVariables.print
        'If pr <> 2 Then
        '    CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        '    CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        '    'End If
        '    rpttype = ""
        '    'End If

        '    'CrystalReportViewer1.Print()
        '    CrystalReportViewer1.Zoom(100)
        '    CrystalReportViewer1.Refresh()
        'Else
        'CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        crReportDocument.RecordSelectionFormula = clsVariables.ReportSql
        CrystalReportViewer1.ReportSource = crReportDocument
        crReportDocument.PrintOptions.PrinterName = "EPSON TM-T82 Receipt"
        crReportDocument.PrintToPrinter(Val(txtprint.Text), False, 0, 0)
        'End If

    End Sub
    Public Sub printnew()
        Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Text = clsVariables.Repheader & "                                              Report File Name : " & clsVariables.ReportName
        'If rpttype = "" Then
        '    Dim ds As DataSet = New DataSet()
        '    Dim adpt As SqlDataAdapter = New SqlDataAdapter
        '    sCommands.setsqlCommand(ds, adpt, clsVariables.ReportSql, clsVariables.RptTable)
        '    Dim report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
        '        MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.Close()
        '        Exit Sub
        '    End If
        '    report.Load(clsVariables.RptLocation & clsVariables.ReportName)
        '    report.SetDataSource(ds)
        '    report.SetParameterValue("@CompanyName", clsVariables.CompnyName)
        '    report.SetParameterValue("@Repheader", clsVariables.Repheader)
        '    report.SetParameterValue("@fromdate", clsVariables.FromDate)
        '    report.SetParameterValue("@Todate", clsVariables.ToDate)
        '    CrystalReportViewer1.ReportSource = report
        'Else
        If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
            MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If
        Dim crtableLogoninfos As New TableLogOnInfos()
        Dim crtableLogoninfo As New TableLogOnInfo()
        Dim crConnectionInfo As New ConnectionInfo()
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim crReportDocument As New ReportDocument()
        crReportDocument.Load(clsVariables.RptLocation & clsVariables.ReportName)
        Dim i As Integer
        i = 0
        If LCase(clsVariables.ReportName) <> LCase("NewRojmalReport.rpt") And LCase(clsVariables.ReportName) <> LCase("BankBookReport.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalTrialBalanceTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalBalanceSheetTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("PayslipPrinting.rpt") And LCase(clsVariables.ReportName) <> LCase("PadyRojmalReport.rpt") Then

            If LCase(clsVariables.ReportName) = LCase("OfficeReport.Rpt") Or LCase(clsVariables.ReportName) = LCase("JaminDetailReport.Rpt") Then
                Do While i < crReportDocument.Subreports.Count
                    crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql1
                    i += 1
                Loop
            Else
                Do While i < crReportDocument.Subreports.Count
                    crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql
                    i += 1
                Loop
            End If
        End If
        With crConnectionInfo
            .ServerName = "assdsn"
            .DatabaseName = dbname
            If DbAuth <> "WIN" Then
                .UserID = "advsys"
                .Password = "advsys"
            End If
        End With
        CrTables = crReportDocument.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        crReportDocument.VerifyDatabase()
        'If LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
        '    crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
        'End If
        i = 0
        Do While i < crReportDocument.ParameterFields.Count
            If LCase(crReportDocument.ParameterFields(i).Name) = LCase("@CompanyName") Then
                crReportDocument.SetParameterValue(i, clsVariables.CompnyName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@RepHeader") Then
                crReportDocument.SetParameterValue(i, clsVariables.Repheader)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@fromDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@toDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.ToDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@OpeningBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dOpeningBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@ClosingBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dClosingBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@NumtoWord") Then
                crReportDocument.SetParameterValue(i, clsVariables.NumtoWord)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Year_Id") Then
                crReportDocument.SetParameterValue(i, clsVariables.WorkingYear)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab1") Then
                '    crReportDocument.SetParameterValue(i, Slab1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Val1") Then
                '    crReportDocument.SetParameterValue(i, Val1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab2") Then
                '    crReportDocument.SetParameterValue(i, Slab2)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab3") Then
                '    crReportDocument.SetParameterValue(i, Slab3)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab4") Then
                '    crReportDocument.SetParameterValue(i, Slab4)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab5") Then
                '    crReportDocument.SetParameterValue(i, Slab5)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab6") Then
                'crReportDocument.SetParameterValue(i, Slab6)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@UserName") Then
                crReportDocument.SetParameterValue(i, fulluserName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Date") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate & " To " & clsVariables.ToDate)

                '    crReportDocument.SetParameterValue(i, MdiMain.ComboDept.Text)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTDRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtDbIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTCRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtCrIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@BasedRate") Then
                '    crReportDocument.SetParameterValue(i, BasedRate)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Season_Id") Then
                '    crReportDocument.SetParameterValue(i, Season_Id)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Department_Id") Then
                '    crReportDocument.SetParameterValue(i, Val(MdiMain.ComboDept.SelectedValue))
            End If
            i += 1
        Loop
        'CrystalReportViewer1.ParameterFieldInfo = pf
        ' Dim pr As String
        ' pr = clsVariables.print
        'If pr <> 2 Then
        '    CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        '    CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        '    'End If
        '    rpttype = ""
        '    'End If

        '    'CrystalReportViewer1.Print()
        '    CrystalReportViewer1.Zoom(100)
        '    CrystalReportViewer1.Refresh()
        'Else
        'CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        crReportDocument.RecordSelectionFormula = clsVariables.ReportSql
        CrystalReportViewer1.ReportSource = crReportDocument
        'crReportDocument.PrintOptions.PrinterName = "EPSON TM-T82 Receipt"
        crReportDocument.PrintToPrinter(Val(txtprint.Text), False, 0, 0)
        'End If

    End Sub
    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & " and Billtype='" & Trim(cmbType.Text) & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Sales' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                Cname.Tag = dt.Rows(0).Item("partyid")
                Cname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())
                Columnname.Tag = dt.Rows(0).Item("Clid")
                Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                cmbType.Text = dt.Rows(0).Item("Billtype")
                acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                Remarks.Text = dt.Rows(0).Item("Remarks")
                acname.Enabled = False
                tcgst.Text = dt.Rows(0).Item("gst")
                tsgst.Text = dt.Rows(0).Item("gst")
                Roundoff.Text = dt.Rows(0).Item("Roundoff")
                tNetamt.Text = dt.Rows(0).Item("Paymentamt")
                basci.Text = dt.Rows(0).Item("Basic")
                Dim dts As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & " and Billtype='" & Trim(cmbType.Text) & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Sales' and year_id='" & clsVariables.WorkingYear & "' Order by Srno", ob.getconnection())
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                End If
                For i As Integer = 0 To dts.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(i).Cells(0).Value = i + 1
                    Dg.Rows(i).Cells(1).Value = dts.Rows(i).Item("Barcode")
                    Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & dts.Rows(i).Item("Barcode") & "' and ptype='sales' and billtype='" & cmbType.Text & "'", ob.getconnection())
                    Dg.Rows(i).Cells(3).Value = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
                    Dim iname As String = ob.FindOneString("select item_name from Item_master where Item_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                    Dg.Rows(i).Cells(2).Value = iname
                    Dg.Rows(i).Cells(2).Tag = dts.Rows(i).Item("Itemid")

                    Dg.Rows(i).Cells(4).Value = dts.Rows(i).Item("Stockout")
                    Dg.Rows(i).Cells(5).Value = dts.Rows(i).Item("Rate")
                    Dg.Rows(i).Cells(6).Value = dts.Rows(i).Item("Basic")
                    Dg.Rows(i).Cells(7).Value = dts.Rows(i).Item("CGST")
                    Dg.Rows(i).Cells(8).Value = dts.Rows(i).Item("CGSTAMT")
                    Dg.Rows(i).Cells(9).Value = dts.Rows(i).Item("SGST")
                    Dg.Rows(i).Cells(10).Value = dts.Rows(i).Item("SGSTAMT")
                    Dg.Rows(i).Cells(11).Value = Val(dts.Rows(i).Item("Rate")) * Val(dts.Rows(i).Item("Stockout"))
                    Dg.Rows(i).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)

                Next
                'addlist()
            End If
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        If MessageBox.Show("Do You Want To delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & " and Type=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and billtype=" & aq(cmbType.Text) & " and Department=" & aq(Cmbdepartment.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            clear()
        End If
    End Sub

    Private Sub Cname_Enter(sender As Object, e As EventArgs) Handles Cname.Enter
        ' Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub

    Private Sub itemname_Enter(sender As Object, e As EventArgs)
        'Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub

    Private Sub itemname_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub itemname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles itemname.Validating
        If Trim(Cmbdepartment.Text) = "BHANDAR" Then
            itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
            'lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & "", ob.getconnection())
            cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            ' rate.Text = ob.FindOneString("Select MRP From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
        End If

    End Sub

    Private Sub Sizename_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Sizename.Validating
        If Trim(Cmbdepartment.Text) = "BHANDAR" Then
            'Sizename.Tag = ob.FindOneString("Select Size_Id From Size_Master Where Size_Name=N'" & Trim(Sizename.Text) & "' or Size_Id='" & Trim(Sizename.Text) & "'", ob.getconnection())
            Sizename.Text = ob.FindOneString("Select Size_Name From Size_Master Where  Size_Id='" & Trim(Sizename.Text) & "'", ob.getconnection())

        End If
    End Sub

    Private Sub rate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rate.Validating
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
    End Sub

    Private Sub Netamt_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Netamt.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Val(srno.Text) > Dg.Rows.Count Then
                Dg.Rows.Add()
                Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                Dg.Rows(srno.Text - 1).Cells(2).Value = itemname.Text
                Dg.Rows(srno.Text - 1).Cells(2).Tag = itemname.Tag
                Dg.Rows(srno.Text - 1).Cells(3).Value = Sizename.Text
                Dg.Rows(srno.Text - 1).Cells(3).Tag = Sizename.Tag
                Dg.Rows(srno.Text - 1).Cells(1).Value = Barcode.Text
                Dg.Rows(srno.Text - 1).Cells(4).Value = qty.Text
                Dg.Rows(srno.Text - 1).Cells(5).Value = rate.Text
                Dg.Rows(srno.Text - 1).Cells(6).Value = amount.Text
                Dg.Rows(srno.Text - 1).Cells(7).Value = cgst.Text
                Dg.Rows(srno.Text - 1).Cells(8).Value = cgstamt.Text
                Dg.Rows(srno.Text - 1).Cells(9).Value = sgst.Text
                Dg.Rows(srno.Text - 1).Cells(10).Value = sgstamt.Text
                Dg.Rows(srno.Text - 1).Cells(11).Value = Netamt.Text
                Dg.Rows(srno.Text - 1).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)

                srno.Text = srno.Text + 1
                '  Dg.Rows(srno.Text - 1).Cells(2).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
            Else
                'Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                'Dg.Rows(srno.Text - 1).Cells(1).Value = itemname.Text
                'Dg.Rows(srno.Text - 1).Cells(1).Tag = itemname.Tag
                'Dg.Rows(srno.Text - 1).Cells(2).Value = Sizename.Text
                'Dg.Rows(srno.Text - 1).Cells(2).Tag = Sizename.Tag
                'Dg.Rows(srno.Text - 1).Cells(3).Value = Barcode.Text
                'Dg.Rows(srno.Text - 1).Cells(4).Value = qty.Text
                'Dg.Rows(srno.Text - 1).Cells(5).Value = rate.Text
                'Dg.Rows(srno.Text - 1).Cells(6).Value = amount.Text
                'Dg.Rows(srno.Text - 1).Cells(7).Value = cgst.Text
                'Dg.Rows(srno.Text - 1).Cells(8).Value = cgstamt.Text
                'Dg.Rows(srno.Text - 1).Cells(9).Value = sgst.Text
                'Dg.Rows(srno.Text - 1).Cells(10).Value = sgstamt.Text
                'Dg.Rows(srno.Text - 1).Cells(11).Value = Netamt.Text
                Dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                Dg.Rows(srno.Text - 1).Cells(2).Value = itemname.Text
                Dg.Rows(srno.Text - 1).Cells(2).Tag = itemname.Tag
                Dg.Rows(srno.Text - 1).Cells(3).Value = Sizename.Text
                Dg.Rows(srno.Text - 1).Cells(3).Tag = Sizename.Tag
                Dg.Rows(srno.Text - 1).Cells(1).Value = Barcode.Text
                Dg.Rows(srno.Text - 1).Cells(4).Value = qty.Text
                Dg.Rows(srno.Text - 1).Cells(5).Value = rate.Text
                Dg.Rows(srno.Text - 1).Cells(6).Value = amount.Text
                Dg.Rows(srno.Text - 1).Cells(7).Value = cgst.Text
                Dg.Rows(srno.Text - 1).Cells(8).Value = cgstamt.Text
                Dg.Rows(srno.Text - 1).Cells(9).Value = sgst.Text
                Dg.Rows(srno.Text - 1).Cells(10).Value = sgstamt.Text
                Dg.Rows(srno.Text - 1).Cells(11).Value = Netamt.Text
                Dg.Rows(srno.Text - 1).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)

                Dg.Rows(srno.Text - 1).Cells(2).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)

                ' Dg.Rows(srno.Text - 1).Cells(2).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)

                srno.Text = Dg.Rows.Count + 1

            End If
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
            x = x + Val(Dg.Rows(i).Cells(8).Value)
            y = y + Val(Dg.Rows(i).Cells(6).Value)
            z = z + Val(Dg.Rows(i).Cells(11).Value)
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
        Sizename.Clear()
        Barcode.Clear()
        Itemid.Clear()
        srno.Focus()
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
            cgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            sgst.Text = ob.FindOneString("Select CGST_Per From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "'", ob.getconnection())
            rate.Text = ob.FindOneString("Select MRP From Acstock Where barcode='" & Barcode.Text & "' and ptype='Purchase'  order by billdate desc", ob.getconnection())
            If Val(rate.Text) = 0 Then
                rate.Text = ob.FindOneString("Select MRP From Acstock Where barcode='" & Barcode.Text & "' and ptype='Opening'", ob.getconnection())
            End If
            lblstock.Text = ob.FindOneString("select isnull(sum(stockin),0)-isnull(sum(stockout),0) from acstock where itemid=" & Val(itemname.Tag) & " and Barcode='" & Barcode.Text & "'", ob.getconnection())
            qty.Focus()
        Else
            Itemid.Focus()

        End If
    End Sub

    Private Sub Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Sizename.KeyDown, rate.KeyDown, qty.KeyDown, itemname.KeyDown, Barcode.KeyDown, amount.KeyDown, Itemid.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F2 Then
            FrmShowItem.Show()

        End If
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        For i As Integer = 0 To Dg.Rows.Count - 1
            If srno.Text = Dg.Rows(i).Cells(0).Value Then
                Barcode.Text = Dg.Rows(i).Cells(1).Value
                itemname.Tag = Dg.Rows(i).Cells(2).Tag
                Itemid.Text = Dg.Rows(i).Cells(2).Tag
                itemname.Text = Dg.Rows(i).Cells(2).Value
                Sizename.Text = Dg.Rows(i).Cells(3).Value
                qty.Text = Dg.Rows(i).Cells(4).Value
                rate.Text = Dg.Rows(i).Cells(5).Value
                amount.Text = Dg.Rows(i).Cells(6).Value
                cgst.Text = Dg.Rows(i).Cells(7).Value
                cgstamt.Text = Dg.Rows(i).Cells(8).Value
                sgst.Text = Dg.Rows(i).Cells(9).Value
                sgstamt.Text = Dg.Rows(i).Cells(10).Value
                Netamt.Text = Dg.Rows(i).Cells(11).Value


            End If
        Next

    End Sub

    Private Sub adharno_KeyDown(sender As Object, e As KeyEventArgs) Handles adharno.KeyDown
        If e.KeyCode = Keys.Enter Then

            srno.Focus()

        End If
    End Sub

    Private Sub Barcode_TextChanged(sender As Object, e As EventArgs) Handles Barcode.TextChanged

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

    Private Sub Itemid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Itemid.Validating
        itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(Itemid.Text) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ssql As String
        ssql = "{Salesbillprintbhandar.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Salesbillprintbhandar.Department}=" & aq(Cmbdepartment.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Billtype}=" & aq(cmbType.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Year_id}=" & aq(clsVariables.WorkingYear)
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(tNetamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "SalesBillPrintBhandar.rpt"
        printnew()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label34.Text = Val(Label34.Text) - Val(TextBox1.Text)
            If MessageBox.Show("Do You Want To Print This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ButPrint_Click(Nothing, Nothing)
            End If
            clear()
            loadg()
        End If
    End Sub

    Private Sub Mobileno_KeyDown(sender As Object, e As KeyEventArgs) Handles Mobileno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Mobileno.TextLength = 10 Then
                '  Dim mnum As String = ob.FindOneString("select Mobile_No from Member_Master where Member_id=" & Cname.Tag & "", ob.getconnection())
                ' Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and Clid=" & Columnname.Tag & "", ob.getconnection())
                ' Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and  acid=139", ob.getconnection())

                Dim msg As String = "પ્રિય કડોદ કૃષીમોલ ગ્રાહક,મુલાકાત બદલ આભાર..હોમ ડિલીવરી ફ્રી માટે ટોલ ફ્રી નં:૯૮૭૯૩૪૬૦૭૩ શરતોને આધીન. "
                ob.SendSMScash(Mobileno.Text, msg)
                MessageBox.Show("Send")
                Panel2.Visible = False
                Panel1.Visible = True
                Label34.Text = tNetamt.Text
                TextBox1.Focus()
            Else
                MessageBox.Show("Invalid Number")
                Mobileno.Focus()
            End If
        End If
    End Sub

    Private Sub Mobileno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Mobileno.Validating

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ssql As String
        ssql = "{Salesbillprintbhandar.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Salesbillprintbhandar.Department}=" & aq(Cmbdepartment.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Billtype}=" & aq(cmbType.Text)
        ssql = ssql & " and {Salesbillprintbhandar.Year_id}=" & aq(clsVariables.WorkingYear)
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(tNetamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "SalesBillPrintBhandargst.rpt"
        printnew()
    End Sub

    Private Sub billDt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles billDt.Validating
        ob.validdate(sender, billDt.Text, True)

    End Sub
End Class