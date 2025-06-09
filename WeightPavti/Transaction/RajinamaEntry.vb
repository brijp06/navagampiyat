Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class RajinamaEntry


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        'TxtFill("Select Account_name from Column_Master", Acc)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Rajinamu'", ob.getconnection())
        acname.Tag = 2
        acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        fixdac.Tag = 3
        fixdac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(fixdac.Tag) & "", ob.getconnection())
        kalyanac.Tag = 20
        kalyanac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(kalyanac.Tag) & "", ob.getconnection())
        Intac.Tag = 27
        Intac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(Intac.Tag) & "", ob.getconnection())
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
                Netamt.Text = ob.FindOneString("Select isnull(sum(Receiptamt),0)-isnull(sum(paymentamt),0) From Acmain Where  Partyid=" & Val(sname.Tag) & " and acid=2", ob.getconnection())
                fixdamt.Text = ob.FindOneString("Select isnull(sum(Receiptamt),0)-isnull(sum(paymentamt),0) From Acmain Where  Partyid=" & Val(sname.Tag) & " and acid=3", ob.getconnection())
                kalyan.Text = ob.FindOneString("Select isnull(sum(paymentamt),0)-isnull(sum(Receiptamt),0) From Acmain Where  Partyid=" & Val(sname.Tag) & " and Clid=1", ob.getconnection())
                intamt.Text = Format(Val(kalyan.Text) * 0.5 / 100, "###0.00")
                ' lbltotal.Text = Val(Netamt.Text) + Val(fixdamt.Text) - Val(lblloan.Text)
                ' chaln()
                Label14.Text = Val(Netamt.Text) + Val(fixdamt.Text)
                Label16.Text = Val(kalyan.Text) + Val(intamt.Text)
                If Val(Label14.Text) >= Val(Label16.Text) Then
                    Label10.Text = Val(Label14.Text) - Val(Label16.Text)
                Else
                    MessageBox.Show("Place Close Loan First")
                    Me.Close()
                End If
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where ptype='Rajinamu' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("delete from Acdata where ptype='Rajinamu' and Docno=" & Val(Billno.Text) & "", ob.getconnection())
        If Val(kalyan.Text) = 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Paymentamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Netamt.Text) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            If Val(fixdamt.Text) <> 0 Then
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Paymentamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(fixdac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(fixdamt.Text) & ",'Rajinamu')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & fixdac.Tag & ",N'" & fixdac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype)  Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            End If
            ob.Execute("update Member_Master set mclose=0 where Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
        Else
            Dim pay As Double = 0
            If Val(Label10.Text) > Val(Netamt.Text) Then
                pay = Val(Label10.Text) - Val(Netamt.Text)
                pay = Val(pay) - Val(fixdamt.Text)
                pay = Val(pay) - Val(intamt.Text)
            Else
                pay = Val(Netamt.Text) - Val(Label10.Text)
                pay = Val(pay) - Val(intamt.Text)
            End If
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt, Paymentamt, ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Label10.Text) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(Label10.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(Label10.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Paymentamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(pay) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Receiptamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(kalyanac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(pay) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(pay) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & kalyanac.Tag & ",N'" & kalyanac.Text & "'," & Val(pay) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Paymentamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(intamt.Text) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Intac.Tag & ",N'" & Intac.Text & "'," & Val(intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Paymentamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(fixdac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(fixdamt.Text) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,Receiptamt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(kalyanac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(fixdamt.Text) & ",'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & fixdac.Tag & ",N'" & fixdac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype)  Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & kalyanac.Tag & ",N'" & payac.Text & "'," & fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'Rajinamu')", ob.getconnection())

            ob.Execute("update Member_Master set mclose=0 where Member_Id=" & Val(sname.Tag) & "", ob.getconnection())

        End If
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Rajinamu'", ob.getconnection())
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
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, payac.KeyDown, sname.KeyDown, Netamt.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown, acname.KeyDown, fixdamt.KeyDown, kalyan.KeyDown, intamt.KeyDown
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
        Txtremark.Focus()
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where ptype='Rajinamu' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                sname.Tag = dt.Rows(0).Item("partyid")
                sname.Text = dt.Rows(0).Item("Remarks")
                cmbtype.Text = dt.Rows(0).Item("Billtype")
                If cmbtype.Text = "CASH" Then
                    payac.Tag = 164
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                Else
                    payac.Tag = 19
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                End If
                Netamt.Text = ob.FindOneString("select paymentamt from acmain where ptype='Rajinamu' and billno=" & Val(Billno.Text) & " and acid=2", ob.getconnection())
                fixdamt.Text = ob.FindOneString("select paymentamt from acmain where ptype='Rajinamu' and billno=" & Val(Billno.Text) & " and acid=3", ob.getconnection())
                kalyan.Text = ob.FindOneString("select paymentamt from acmain where ptype='Rajinamu' and billno=" & Val(Billno.Text) & " and acid=4", ob.getconnection())


            End If
        End If
    End Sub

    Private Sub lbltotal_Click(sender As Object, e As EventArgs)

    End Sub
End Class