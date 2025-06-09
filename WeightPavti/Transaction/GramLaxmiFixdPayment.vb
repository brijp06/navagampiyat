Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class GramLaxmiFixdPayment


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        'TxtFill("Select Account_name from Column_Master", Acc)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='GramlaxmiFixdPayment'", ob.getconnection())
        acname.Tag = 24
        acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        Intac.Tag = 64
        Intac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Intac.Tag) & "", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()
        Dg.Columns.Add("Fromdate", "Fromdate")
        Dg.Columns.Add("Todate", "Todate")
        Dg.Columns.Add("Amount", "Amount")
        Dg.Columns.Add("Int.Rate", "Int.Rate")
        Dg.Columns.Add("Days", "Days")
        Dg.Columns.Add("Int.Amount", "Int.Amount")
        Dg.Columns(0).Width = 70
        Dg.Columns(1).Width = 70
        Dg.Columns(2).Width = 70
        Dg.Columns(3).Width = 50
        Dg.Columns(4).Width = 50
        Dg.Columns(5).Width = 75
        Dg.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
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
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,PaymentAmt,ptype, Per, Period, Duedate,fdno) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Fixdamt.Text) & ",'GramlaxmiFixdPayment'," & percent.Text & "," & Period.Text & ",'" & ob.DateConversion(duedt.Text) & "'," & Val(Fixno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'GramlaxmiFixdPayment')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'GramlaxmiFixdPayment')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Intac.Tag & ",N'" & Intac.Text & "'," & Intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'GramlaxmiFixdPayment')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'GramlaxmiFixdPayment')", ob.getconnection())
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='GramlaxmiFixdPayment'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        Netamt.Clear()
        acname.Clear()
        'Columnname.Clear()
        percent.Clear()
        ' Loanno.Clear()
        Period.Clear()
        duedt.Clear()
        payac.Clear()
        cmbtype.Text = ""
        Fixno.Clear()
        Intamt.Clear()
        Fixdamt.Clear()
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
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
            payac.Tag = 9941
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

    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles Period.Validated
        Dim dat As Date = billDt.Text
        duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, Netamt.KeyDown, Intamt.KeyDown, Fixno.KeyDown, Fixdamt.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Fixno_Validated(sender As Object, e As EventArgs) Handles Fixno.Validated
        Dim dt As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ch=0 and ptype='GramlaxmiFixdReceipt'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            sname.Tag = dt.Rows(0).Item("PartyId")
            sname.Text = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(sname.Tag) & "", ob.getconnection())
            percent.Text = dt.Rows(0).Item("Per")
            Period.Text = dt.Rows(0).Item("Period")
            Period.Text = dt.Rows(0).Item("Period")
            Fixdamt.Text = dt.Rows(0).Item("Netamt")
            duedt.Text = dt.Rows(0).Item("Billdate")
            lbldate.Text = dt.Rows(0).Item("Duedate")
            calint()
        Else
            MessageBox.Show("Invalid Fixd No")
            Fixno.Clear()
            Fixno.Focus()
        End If
    End Sub
    Public Sub calint()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Dim ndate As Date = billDt.Text
        Dim ddate As Date = lbldate.Text

        Dg.Rows.Add()
        Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = duedt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = billDt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = Fixdamt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = percent.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Month, Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value, Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value)
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Format(Val(Fixdamt.Text) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value) / 1200, "###0.00")
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Math.Round(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value))
        Dg.Rows.Add()
        Dim fddate As Date = duedt.Text
        Dim year As Integer = fddate.Year
        Dim mon As Date = fddate.AddMonths(1)
        Dim mm As Integer = mon.Month
        Dim xdate As Date = DateSerial(year, mm, 1)
        Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = duedt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = Format(xdate, "dd/MM/yyyy")
        Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = Fixdamt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = percent.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Day, Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value, Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value)
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Format(Val(Fixdamt.Text) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value) / 36500, "###0.00")
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Math.Round(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value))
        Intamt.Text = Val(Dg.Rows(0).Cells(5).Value) + Val(Dg.Rows(1).Cells(5).Value)
    End Sub

    Private Sub Intamt_Validated(sender As Object, e As EventArgs) Handles Intamt.Validated
        Netamt.Text = Val(Fixdamt.Text) + Val(Intamt.Text)
    End Sub
End Class