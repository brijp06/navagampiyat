Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class LoanPassingEntry


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Member_name from Member_Master", Jamin1)
        TxtFill("Select Member_name from Member_Master", Jamin2)


        ' TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Loan_no),0)+1 from PASSING_DATA", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()
        cmbinttype.SelectedIndex = 0
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
                ' Txtremark.Text = sname.Text
                ' chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub


    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("Delete from PASSING_DATA where Loan_no=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("Delete from Passing_Due_Date_Data where Doc_no=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("Insert Into PASSING_DATA(Loan_no, Doc_Date, member_id, File_no, Period, Percentage, Due_Date, Column_Id, Amount, Jamin_1_Id, Jamin_2_Id, Interest_Type) values(" & Val(Billno.Text) & "," & aq(ob.DateConversion(billDt.Text)) & "," & Val(sname.Tag) & "," & Val(Loanno.Text) & "," & Val(Period.Text) & "," & Val(percent.Text) & "," & aq(ob.DateConversion(duedt.Text)) & "," & Val(Columnname.Tag) & "," & Val(Netamt.Text) & "," & Val(Jamin1.Tag) & "," & Val(Jamin2.Tag) & "," & aq(cmbinttype.Text) & ")", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            ob.Execute("Insert Into Passing_Due_Date_Data(DOC_NO, Sr_No, Member_Id, Interest_Amount, Due_date, Installment_Amount) values(" & Val(Billno.Text) & "," & Val(Dg.Rows(i).Cells(0).Value) & "," & Val(sname.Tag) & "," & Val(Dg.Rows(i).Cells(2).Value) & "," & aq(ob.DateConversion(Dg.Rows(i).Cells(1).Value)) & "," & Val(Dg.Rows(i).Cells(3).Value) & ")", ob.getconnection())
        Next
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Loan_no),0)+1 from PASSING_DATA", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        ' Txtremark.Clear()
        Netamt.Clear()
        Jamin1.Clear()
        Columnname.Clear()
        percent.Clear()
        Loanno.Clear()
        Period.Clear()
        duedt.Clear()
        'payac.Clear()
        'cmbtype.Text = ""
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Period.KeyDown, percent.KeyDown, sname.KeyDown, Netamt.KeyDown, duedt.KeyDown, Columnname.KeyDown, Billno.KeyDown, billDt.KeyDown, Jamin1.KeyDown, Loanno.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Columnname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Columnname.Validating
        If Columnname.Text <> "" Then
            Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
        End If
    End Sub





    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles Period.Validated
        Dim dat As Date = billDt.Text
        duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)

    End Sub

    Private Sub Jamin1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Jamin1.Validating
        If Jamin1.Text <> "" Then
            Jamin1.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Jamin1.Text) & "' or Member_Id=" & Val(Jamin1.Text) & "", ob.getconnection())
            If Val(Jamin1.Tag) <> 0 Then
                Jamin1.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Jamin1.Tag) & "", ob.getconnection())
                ' Txtremark.Text = sname.Text
                ' chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub Jamin2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Jamin2.Validating
        If Jamin2.Text <> "" Then
            Jamin2.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Jamin2.Text) & "' or Member_Id=" & Val(Jamin2.Text) & "", ob.getconnection())
            If Val(Jamin1.Tag) <> 0 Then
                Jamin2.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Jamin2.Tag) & "", ob.getconnection())
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub Netamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Netamt.Validating
        Dim dat As Date = billDt.Text
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If

        For i As Integer = 0 To Val(Period.Text) - 1
            Dg.Rows.Add()
            Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = i + 1
            Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = Format(DateAndTime.DateAdd(DateInterval.Month, Val(i + 1), dat), "dd/MM/yyyy")
            Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = Val(Netamt.Text) / Val(Period.Text)
            Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = Format(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value), g2Dec)
            Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = (Val(Netamt.Text) * Val(percent.Text)) / (Val(Period.Text) * 100)
            Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = Format(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value), g2Dec)
            Dg.Rows(Dg.Rows.Count - 1).Cells(0).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(Dg.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(Dg.Rows.Count - 1).Cells(2).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(Dg.Rows.Count - 1).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)

        Next
        Dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow

    End Sub
End Class