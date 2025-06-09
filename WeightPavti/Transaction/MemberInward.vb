Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class MemberInward


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtShareAmount.KeyDown, Txtremark.KeyDown, txtAdmissionfee.KeyDown, Netamt.KeyDown, sname.KeyDown, Billno.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='MemberInward'", ob.getconnection())
        billDt.Text = Now
        txtShareAccountName.Tag = 10
        txtShareAccountName.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(txtShareAccountName.Tag) & "", ob.getconnection())
        txtAdmissionFeeAccountName.Tag = 207
        txtAdmissionFeeAccountName.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(txtAdmissionFeeAccountName.Tag) & "", ob.getconnection())
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

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,  Netamt,ReceiptAmt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','CASH','CASH'," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(txtShareAccountName.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(txtShareAmount.Text) & ",'MemberInward')", ob.getconnection())
        If Val(txtShareAmount.Text) <> 0 Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',164,'b'," & txtShareAmount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberInward')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & txtShareAccountName.Tag & ",N'" & txtShareAccountName.Text & "'," & txtShareAmount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberInward')", ob.getconnection())
        End If
        If Val(txtAdmissionfee.Text) <> 0 Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',164,'b'," & txtAdmissionfee.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberInward')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName,Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & txtAdmissionFeeAccountName.Tag & ",N'" & txtAdmissionFeeAccountName.Text & "'," & txtAdmissionfee.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberInward')", ob.getconnection())
        End If
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='MemberInward'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        txtShareAmount.Clear()
        txtAdmissionfee.Clear()
        Netamt.Clear()
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs) Handles txtAdmissionfee.Validated
        Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub
End Class