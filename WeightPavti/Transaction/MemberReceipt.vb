Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class MemberReceipt


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='MemberReceipt'", ob.getconnection())
        txtcertino.Text = ob.FindOneString("select isnull(max(CertiNo),0)+1 from Acmain", ob.getconnection())

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

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,  Netamt,ReceiptAmt,ptype,Rate, CertiNo, Share, FromCertiNo,ToCertiNo) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','CASH','CASH'," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & ",1,N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Netamt.Text) & ",'MemberReceipt'," & txtShareAmount.Text & "," & txtcertino.Text & "," & txtShare.Text & "," & fromct.Text & "," & toct.Text & ")", ob.getconnection())

        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',164,'b'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberReceipt')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','CASH'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',5,'b'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'MemberReceipt')", ob.getconnection())

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
        txtShare.Clear()
        txtcertino.Clear()
        Netamt.Clear()
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs) Handles txtcertino.Validated
        'Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles toct.TextChanged

    End Sub

    Private Sub Billno_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtShareAmount.KeyDown, txtShare.KeyDown, Txtremark.KeyDown, txtcertino.KeyDown, toct.KeyDown, sname.KeyDown, Netamt.KeyDown, fromct.KeyDown, Billno.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtShareAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtShareAmount.Validating
        Netamt.Text = Val(txtShare.Text) * Val(txtShareAmount.Text)
        fromct.Text = ob.FindOneString("select isnull(max(ToCertiNo),0)+1 from Acmain", ob.getconnection())
        toct.Text = Val(fromct.Text) + Val(txtShare.Text) - 1

    End Sub
End Class