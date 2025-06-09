Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class LoanPayment


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='LoanPayment'", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()
        Fixdac.Tag = 2
        Fixdac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Fixdac.Tag) & "", ob.getconnection())
        percent.Text = "0.50"
        Period.Text = 1
        Dim dat As Date = billDt.Text
        duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)
        Loanno.Text = 1
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

        End If
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where ptype='LoanPayment' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("delete from Acdata where ptype='LoanPayment' and Docno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, Netamt,PaymentAmt,ptype, Loanno, Per, Period, Duedate) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Columnname.Tag) & "," & Val(Netamt.Text) & "," & Val(Netamt.Text) & ",'LoanPayment'," & Loanno.Text & "," & percent.Text & "," & Period.Text & ",'" & ob.DateConversion(duedt.Text) & "')", ob.getconnection())
        If Val(ShareAmt.Text) <> 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, Netamt,Receiptamt,ptype, Loanno, Per, Period, Duedate) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(Fixdac.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Columnname.Tag) & "," & Val(Netamt.Text) & "," & Val(ShareAmt.Text) & ",'LoanPayment'," & Loanno.Text & "," & percent.Text & "," & Period.Text & ",'" & ob.DateConversion(duedt.Text) & "')", ob.getconnection())
        End If
        If Trim(cmbtype.Text) = "CASH" Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
        Else
            '   ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Cramt ,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(Netamt.Text) - Val(ShareAmt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(Netamt.Text) - Val(ShareAmt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())

            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(ShareAmt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Fixdac.Tag & ",N'" & Fixdac.Text & "'," & Val(ShareAmt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'LoanPayment')", ob.getconnection())
        End If
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='LoanPayment'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        ' billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        Netamt.Clear()
        acname.Clear()
        Columnname.Clear()
        percent.Clear()
        Loanno.Clear()
        Period.Clear()
        duedt.Clear()
        payac.Clear()
        cmbtype.Text = ""
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, Period.KeyDown, percent.KeyDown, payac.KeyDown, sname.KeyDown, Netamt.KeyDown, duedt.KeyDown, cmbtype.KeyDown, Columnname.KeyDown, Billno.KeyDown, billDt.KeyDown, acname.KeyDown, Loanno.KeyDown, ShareAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Columnname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Columnname.Validating
        If Columnname.Text <> "" Then
            Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            acname.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles cmbtype.Validated
        If Trim(cmbtype.Text) = "CASH" Then
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
        percent.Focus()
    End Sub

    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles Period.Validated
        Dim dat As Date = billDt.Text
        duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)
    End Sub

    Private Sub Netamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Netamt.Validating

    End Sub

    Private Sub acname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles acname.Validating
        acname.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Id=" & Val(acname.Text) & " Or Account_Name=N'" & Trim(acname.Text) & "'", ob.getconnection())
        If Val(acname.Tag) <> 0 Then
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub PassingNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PassingNo.Validating
        Dim dt As DataTable = ob.Returntable("select * from  PASSING_DATA where Loan_no=" & Val(PassingNo.Text) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            sname.Tag = dt.Rows(0).Item("Member_id")
            sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
            Columnname.Tag = dt.Rows(0).Item("Column_Id")
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            Period.Text = dt.Rows(0).Item("Period")
            percent.Text = dt.Rows(0).Item("Percentage")
            duedt.Text = ob.DateConversion(dt.Rows(0).Item("Due_date"))
            Loanno.Text = dt.Rows(0).Item("File_no")
            Netamt.Text = dt.Rows(0).Item("Amount")
        End If
    End Sub

    Private Sub PassingNo_KeyDown(sender As Object, e As KeyEventArgs) Handles PassingNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where ptype='LoanPayment' and billno=" & Val(Billno.Text) & "", ob.getconnection())
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
                ShareAmt.Text = ob.FindOneString("select Receiptamt from acmain where ptype='LoanPayment' and billno=" & Val(Billno.Text) & " and acid=2", ob.getconnection())
                Netamt.Text = ob.FindOneString("select Paymentamt from acmain where ptype='LoanPayment' and billno=" & Val(Billno.Text) & " and acid=20", ob.getconnection())

                acname.Tag = 20
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=20", ob.getconnection())
                Columnname.Tag = 1
                Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                percent.Text = "0.50"
                Period.Text = 1
                Dim dat As Date = billDt.Text
                duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)
                Loanno.Text = 1
            End If
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("Delete from Acmain where billno=" & Val(Billno.Text) & " and ptype='LoanPayment'", ob.getconnection())
        ob.Execute("Delete from Acdata where Docno=" & Val(Billno.Text) & " and ptype='LoanPayment'", ob.getconnection())

    End Sub

    Private Sub sname_Enter(sender As Object, e As EventArgs) Handles sname.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub
End Class