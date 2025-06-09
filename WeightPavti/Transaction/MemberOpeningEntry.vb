Imports WeightPavti.CLS
Imports System.Data
Imports System.Data.SqlClient
Public Class MemberOpeningEntry
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Sname.KeyDown, No.KeyDown, Acname.KeyDown, Docno.KeyDown, Docdate.KeyDown, Cmbdepartment.KeyDown, Billdate.KeyDown, BillNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyCode = Keys.F7 Then
            Sname.Text = "શ્રી"
        ElseIf e.KeyCode = Keys.F8 Then
            Sname.Text = "શ્રીમતિ"
        End If
    End Sub

    Private Sub MemberOpeningEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("select Account_name from Account_Master", Acname)
        TxtFill("Select Member_name from Member_Master", Sname)
        Docno.Text = ob.FindOneString("Select isnull(max(Tid),0)+1 from AcMain", ob.getconnection())
        Docdate.Text = Format(Now, "dd/MM/yyyy")
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

    Private Sub Acname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Acname.Validating
        If Acname.Text <> "" Then
            Acname.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Name=N'" & Trim(Acname.Text) & "' or Account_Id=" & Val(Acname.Text) & "", ob.getconnection())
            If Val(Acname.Tag) <> 0 Then
                Acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_Id=" & Val(Acname.Tag) & "", ob.getconnection())
                '  Txtremark.Text = Sname.Text
                ' chaln()
            End If
        End If
    End Sub

    Private Sub Sname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Sname.Validating
        If Sname.Text <> "" Then
            Sname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Sname.Text) & "' or Member_Id=" & Val(Sname.Text) & "", ob.getconnection())
            If Val(Sname.Tag) <> 0 Then
                Sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Sname.Tag) & "", ob.getconnection())
                lblmember.Text = Sname.Tag
                '  Txtremark.Text = Sname.Text
                ' chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub Debit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Debit.Validating

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("Delete from Acmain where Tid=" & Val(Docno.Text) & "", ob.getconnection())
        For i As Integer = 0 To DG.Rows.Count - 1
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,PaymentAmt,tid,Ptype,Receiptamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & DG.Rows(i).Cells(2).Value & "','Opening'," & Val(DG.Rows(i).Cells(4).Value) & ",'" & ob.DateConversion(DG.Rows(i).Cells(3).Value) & "'," & Val(DG.Rows(i).Cells(1).Tag) & "," & Val(Acname.Tag) & ",N'" & Trim(DG.Rows(i).Cells(1).Value) & "'," & Val(DG.Rows(i).Cells(5).Value) & "," & Val(Docno.Text) & ",'Opening'," & Val(DG.Rows(i).Cells(6).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("Saved")
        Acname.Clear()
        Acname.Tag = 0
        If DG.Rows.Count > 0 Then
            DG.Rows.Clear()
        End If
        Docno.Text = ob.FindOneString("Select isnull(max(Tid),0)+1 from AcMain", ob.getconnection())

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("Delete from Acmain where Tid=" & Val(Docno.Text) & "", ob.getconnection())
        End If
    End Sub

    Private Sub Debit_KeyDown(sender As Object, e As KeyEventArgs) Handles Debit.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Docno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Docno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where Tid=" & Val(Docno.Text) & " and Billtype='Opening'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Docdate.Text = dt.Rows(0).Item("Billdate")
                Acname.Tag = dt.Rows(0).Item("Acid")
                Acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_Id=" & Val(Acname.Tag) & "", ob.getconnection())
                If DG.Rows.Count > 0 Then
                    DG.Rows.Clear()
                End If
                Dim dbal As Double = 0
                For i = 0 To dt.Rows.Count - 1
                    DG.Rows.Add()
                    DG.Rows(i).Cells(0).Value = i + 1
                    DG.Rows(i).Cells(1).Value = ob.FindOneString("Select Member_name from Member_master where Member_id=" & Val(dt.Rows(i).Item("Partyid")) & "", ob.getconnection())
                    DG.Rows(i).Cells(1).Tag = dt.Rows(i).Item("Partyid")
                    DG.Rows(i).Cells(2).Value = dt.Rows(i).Item("Department")
                    DG.Rows(i).Cells(3).Value = dt.Rows(i).Item("Billdate")
                    DG.Rows(i).Cells(4).Value = dt.Rows(i).Item("BillNo")
                    DG.Rows(i).Cells(5).Value = dt.Rows(i).Item("Paymentamt")
                    DG.Rows(i).Cells(6).Value = dt.Rows(i).Item("Receiptamt")
                    dbal = Val(dbal) + Val(dt.Rows(i).Item("Paymentamt"))
                Next
                Label10.Text = Val(dbal)

                No.Text = DG.Rows.Count + 1
                No.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Credit.KeyDown
        If e.KeyCode = Keys.Enter Then
            DG.Rows.Add()
            DG.Rows(No.Text - 1).Cells(0).Value = No.Text
            DG.Rows(No.Text - 1).Cells(1).Value = Sname.Text
            DG.Rows(No.Text - 1).Cells(1).Tag = Sname.Tag
            DG.Rows(No.Text - 1).Cells(2).Value = Cmbdepartment.Text
            DG.Rows(No.Text - 1).Cells(3).Value = (Billdate.Text)
            DG.Rows(No.Text - 1).Cells(4).Value = Val(BillNo.Text)
            DG.Rows(No.Text - 1).Cells(5).Value = Val(Debit.Text)
            DG.Rows(No.Text - 1).Cells(6).Value = Val(Credit.Text)
            No.Text = DG.Rows.Count + 1
            Sname.Clear()
            BillNo.Clear()
            Debit.Clear()
            Credit.Clear()
            Sname.Tag = 0
            No.Focus()
        End If
    End Sub
End Class