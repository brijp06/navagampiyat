Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class SavingReceipt


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        'TxtFill("Select Account_name from Column_Master", Acc)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Savingreceipt'", ob.getconnection())
        acname.Tag = 2
        acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        fixdac.Tag = 3
        fixdac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(fixdac.Tag) & "", ob.getconnection())
        kalyanac.Tag = 4
        kalyanac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(kalyanac.Tag) & "", ob.getconnection())
        intac.Tag = 27
        intac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(intac.Tag) & "", ob.getconnection())
        loanac.Tag = 20
        loanac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(loanac.Tag) & "", ob.getconnection())
        dhkhalfeeac.Tag = 165
        dhkhalfeeac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(dhkhalfeeac.Tag) & "", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()
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

    Private Sub sname_Validated(sender As Object, e As EventArgs) Handles sname.Validated
        If sname.Text <> "" Then
            sname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(sname.Text) & "' or Member_Id=" & Val(sname.Text) & "", ob.getconnection())
            If Val(sname.Tag) <> 0 Then
                sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
                Txtremark.Text = sname.Text
                ' chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())
            Dim dt As DataTable = ob.Returntable("Select isnull(sum(paymentamt),0)-isnull(sum(Receiptamt),0) as Amt From Acmain Where  Partyid=" & Val(sname.Tag) & " and Acid=20", ob.getconnection())
            If Val(dt.Rows(0).Item("Amt")) <> 0 Then
                Label14.Text = dt.Rows(0).Item("Amt")
                intamt.Text = Format(Val(dt.Rows(0).Item("Amt")) * Val(0.5) / 100, "###0.00")
            End If
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("delete from Acdata where ptype='Savingreceipt' and Docno=" & Val(Billno.Text) & "", ob.getconnection())

        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,ReceiptAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Netamt.Text) & ",'Savingreceipt')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
        If Val(fixdamt.Text) <> 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,ReceiptAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(fixdac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(fixdamt.Text) & ",'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & fixdac.Tag & ",N'" & fixdac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,Cramt,ptype)  Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
        End If
        If Val(kalyan.Text) <> 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,ReceiptAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(kalyanac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(kalyan.Text) & ",'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & kalyanac.Tag & ",N'" & kalyanac.Text & "'," & kalyan.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,Cramt,ptype)  Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & kalyan.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
        End If

        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,ReceiptAmt,ptype,intamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(loanac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(amount.Text) & "," & Val(amount.Text) & ",'Savingreceipt'," & Val(intamt.Text) & ")", ob.getconnection())

        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & loanac.Tag & ",N'" & loanac.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())

        If (intamt.Text) <> 0 Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & intac.Tag & ",N'" & intac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
        End If

        If Val(dakhalfee.Text) <> 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,ReceiptAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(dhkhalfeeac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(dakhalfee.Text) & ",'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & dhkhalfeeac.Tag & ",N'" & dhkhalfeeac.Text & "'," & dakhalfee.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,Cramt,ptype)  Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & dakhalfee.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Savingreceipt')", ob.getconnection())
        End If
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Savingreceipt'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        'billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        Netamt.Clear()
        'acname.Clear()
        'Columnname.Clear()
        payac.Clear()
        cmbtype.Text = ""
        amount.Clear()
        intamt.Clear()
        fixdamt.Clear()
        kalyan.Clear()
        dakhalfee.Clear()
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, payac.KeyDown, sname.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown, acname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Columnname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'If Columnname.Text <> "" Then
        '    Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
        '    Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
        '    acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
        '    acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        '    acname.Enabled = False
        'End If
    End Sub

    Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles cmbtype.Validated
        If cmbtype.Text = "CASH" Then
            payac.Tag = 164
            payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
            payac.Enabled = False
        Else
            payac.Enabled = True
            payac.Tag = 0
            payac.Focus()
        End If
    End Sub

    Private Sub payac_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles payac.Validating
        payac.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Id=" & Val(payac.Text) & " Or Account_Name=N'" & Trim(payac.Text) & "'", ob.getconnection())
        payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                sname.Tag = dt.Rows(0).Item("partyid")
                sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
                cmbtype.Text = dt.Rows(0).Item("Billtype")
                Txtremark.Text = dt.Rows(0).Item("Remarks")
                If cmbtype.Text = "CASH" Then
                    payac.Tag = 164
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                Else
                    payac.Tag = 19
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                End If
                Netamt.Text = ob.FindOneString("select Receiptamt from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & " and acid=2", ob.getconnection())
                fixdamt.Text = ob.FindOneString("select Receiptamt from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & " and acid=3", ob.getconnection())
                kalyan.Text = ob.FindOneString("select Receiptamt from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & " and acid=4", ob.getconnection())
                amount.Text = ob.FindOneString("select Receiptamt from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & " and acid=20", ob.getconnection())
                intamt.Text = ob.FindOneString("select intamt from acmain where ptype='Savingreceipt' and billno=" & Val(Billno.Text) & " and acid=20", ob.getconnection())


            End If
        End If
    End Sub

    Private Sub amount_KeyDown(sender As Object, e As KeyEventArgs) Handles Netamt.KeyDown, kalyan.KeyDown, intamt.KeyDown, fixdamt.KeyDown, dakhalfee.KeyDown, amount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub amount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles amount.Validating
        If Val(amount.Text) = 0 Then
            amount.Text = 0
        End If
    End Sub

    Private Sub intamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles intamt.Validating
        If intamt.Text = "" Then
            intamt.Text = 0
        End If
    End Sub

    Private Sub Netamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Netamt.Validating
        If Netamt.Text = "" Then
            Netamt.Text = 0
        End If
    End Sub

    Private Sub fixdamt_Validated(sender As Object, e As EventArgs) Handles fixdamt.Validated
        If fixdamt.Text = "" Then
            fixdamt.Text = 0
        End If

    End Sub

    Private Sub kalyan_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles kalyan.Validating
        If kalyan.Text = "" Then
            kalyan.Text = 0
        End If
    End Sub

    Private Sub dakhalfee_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dakhalfee.Validating
        If dakhalfee.Text = "" Then
            dakhalfee.Text = 0
        End If
    End Sub
End Class