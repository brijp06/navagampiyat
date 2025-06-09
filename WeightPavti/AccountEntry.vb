Imports WeightPavti.CLS
Imports System.Data.SqlClient
Public Class AccountEntry

    Private Sub cmbtype_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dramt.KeyDown, Drac.KeyDown, Docno.KeyDown, Ddate.KeyDown, crremarks.KeyDown, cramt.KeyDown, Crac.KeyDown, cmbtype.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub AccountEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ddate.Text = Format(Now, "dd/MM/yyyy")
        'Ddate.Text = "01/04/2020"
        cmbtype.SelectedIndex = 0
        auto()
        autonn()
        loaddg()
        ' TxtFill("select Party_name from Party_Master", pname)
        TxtFill("select Remarks from acdata", crremarks)
        TxtFill("select Remarks from acdata", Drremarks)


    End Sub
    Public Sub TxtFill(ByVal Sqlstring As String, ByVal txtBox As TextBox)
        Dim sStringColl As New AutoCompleteStringCollection
        Dim qryCity As String
        qryCity = "SELECT DISTINCT NAME FROM ACMASTER  ORDER By NAME"

        Using connection As New SqlConnection(ob.Getconn)

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
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_Name from Account_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_Name"))
        Next
        Crac.AutoCompleteMode = AutoCompleteMode.Suggest
        Crac.AutoCompleteSource = AutoCompleteSource.CustomSource
        Crac.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autonn()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_Name from Account_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_Name"))
        Next
        Drac.AutoCompleteMode = AutoCompleteMode.Suggest
        Drac.AutoCompleteSource = AutoCompleteSource.CustomSource
        Drac.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        If cmbtype.Text = "Cash Receipt" Then
            Crac.Tag = 164
            Crac.Text = ob.FindOneString("select Account_Name from Account_Master Where Account_Id=164", ob.getconnection())
            Crac.Enabled = False
            cramt.Enabled = False
            crremarks.Enabled = False
            Drac.Enabled = True
            Dramt.Enabled = True
            Drremarks.Enabled = True
            Drac.Tag = 0
            Drac.Text = ""
            Tabct.SelectedIndex = 0
        ElseIf cmbtype.Text = "Cash Payment" Then
            Drac.Tag = 164
            Drac.Text = ob.FindOneString("select Account_Name from Account_Master Where Account_Id=164", ob.getconnection())
            Drac.Enabled = False
            Dramt.Enabled = False
            Drremarks.Enabled = False
            Crac.Enabled = True
            cramt.Enabled = True
            crremarks.Enabled = True
            Crac.Tag = 0
            Crac.Text = ""
            Tabct.SelectedIndex = 0
        ElseIf cmbtype.Text = "Bank Receipt" Then
            Drac.Text = ""
            Crac.Text = ""
            Drac.Enabled = True
            Dramt.Enabled = True
            Drremarks.Enabled = True
            Crac.Enabled = True
            cramt.Enabled = True
            crremarks.Enabled = True
            Crac.Tag = 0
            Crac.Text = ""
            Tabct.SelectedIndex = 0
        ElseIf cmbtype.Text = "Bank Payment" Then
            Drac.Text = ""
            Crac.Text = ""
            Drac.Enabled = True
            Dramt.Enabled = True
            Drremarks.Enabled = True
            Crac.Enabled = True
            cramt.Enabled = True
            crremarks.Enabled = True
            Crac.Tag = 0
            Crac.Text = ""
            Tabct.SelectedIndex = 0
        Else
            Drac.Text = ""
            Crac.Text = ""
            Drac.Enabled = True
            Dramt.Enabled = True
            Drremarks.Enabled = True
            Crac.Enabled = True
            cramt.Enabled = True
            crremarks.Enabled = True
            Crac.Tag = 0
            Crac.Text = ""
            Tabct.SelectedIndex = 1
        End If
        autoac()
    End Sub

    Private Sub Crac_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Crac.Validated
        If Crac.Text <> "" Then
            Crac.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Name=N'" & Crac.Text & "' or Account_Id=" & Val(Crac.Text) & "", ob.getconnection())
            Crac.Text = ob.FindOneString("Select Account_name From Account_Master Where  Account_Id=" & Val(Crac.Tag) & "", ob.getconnection())

        Else
            MessageBox.Show("Place Enter Account Name")
        End If
    End Sub

    Private Sub Drac_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drac.Validated
        If Drac.Text <> "" Then
            Drac.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Name=N'" & Drac.Text & "' or Account_Id=" & Val(Drac.Text) & "", ob.getconnection())
            Drac.Text = ob.FindOneString("Select Account_name From Account_Master Where  Account_Id=" & Val(Drac.Tag) & "", ob.getconnection())

        Else
            If cmbtype.Text <> "Transfer" Then
                MessageBox.Show("Place Enter Account Name")
            Else
                Button6.Focus()
            End If
        End If
    End Sub

    Private Sub Drremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Drremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(cmbtype.Text) = "Transfer" Then
                Dgtrasfer.Rows.Add()
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(0).Value = Dgtrasfer.Rows.Count
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Value = Crac.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Tag = Crac.Tag
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(2).Value = Docno.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(3).Value = cmbtype.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(4).Value = 0
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(5).Value = Dramt.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(6).Value = ""
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(7).Value = Drremarks.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(0).Style.Font = New Font("Cambria", 12, FontStyle.Regular)


                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(4).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(5).Style.Font = New Font("Cambria", 12, FontStyle.Regular)



                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(2).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(6).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(7).Style.Font = New Font("Cambria", 12, FontStyle.Regular)


                Dgtrasfer.Rows.Add()
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(0).Value = Dgtrasfer.Rows.Count
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Value = Drac.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Tag = Drac.Tag
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(2).Value = Docno.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(3).Value = cmbtype.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(4).Value = cramt.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(5).Value = 0
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(6).Value = crremarks.Text
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(7).Value = ""

                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(0).Style.Font = New Font("Cambria", 12, FontStyle.Regular)


                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(1).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(4).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(5).Style.Font = New Font("Cambria", 12, FontStyle.Regular)



                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(2).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(6).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dgtrasfer.Rows(Dgtrasfer.Rows.Count - 1).Cells(7).Style.Font = New Font("Cambria", 12, FontStyle.Regular)


                Dgtrasfer.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                'Dgtrasfer.RowsDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Dgtrasfer.Columns(3).DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Bold)

                Crac.Clear()
                Drac.Clear()
                cramt.Clear()
                Dramt.Clear()
                crremarks.Clear()
                Drremarks.Clear()
                Drac.Focus()
            Else
                Button6.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        loaddg()
        ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & "", ob.getconnection())
        If Trim(cmbtype.Text) <> "Transfer" Then
            If Trim(cmbtype.Text) = "Cash Receipt" Or Trim(cmbtype.Text) = "Cash Payment" Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Crac.Tag & ",N'" & Crac.Text & "'," & cramt.Text & ",N'" & Trim(crremarks.Text) & "',0)", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Dramt.Text & ",N'" & Trim(Drremarks.Text) & "',0)", ob.getconnection())
            Else
                If Val(Crac.Tag) <> 164 Then
                    If Val(Drac.Tag) <> 164 Then
                        ' ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Dramt.Text & ",N'" & Trim(crremarks.Text) & "',0)", ob.getconnection())
                        'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Crac.Tag & ",N'" & Crac.Text & "'," & cramt.Text & ",N'" & Trim(Drremarks.Text) & "',0)", ob.getconnection())
                        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Crac.Tag & ",N'" & Crac.Text & "'," & cramt.Text & ",N'" & Trim(crremarks.Text) & "',0)", ob.getconnection())
                        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Dramt.Text & ",N'" & Trim(Drremarks.Text) & "',0)", ob.getconnection())
                    Else
                        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,cs) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Dramt.Text & ",N'" & Trim(crremarks.Text) & "',0,'CASH')", ob.getconnection())
                        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,cs) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Crac.Tag & ",N'" & Crac.Text & "'," & cramt.Text & ",N'" & Trim(Drremarks.Text) & "',0,'CASH')", ob.getconnection())
                    End If
                Else
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,cs) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(Drac.Tag) & ",N'" & Drac.Text & "'," & Dramt.Text & ",N'" & Trim(crremarks.Text) & "',0,'CASH')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,cs) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(Crac.Tag) & ",N'" & Crac.Text & "'," & cramt.Text & ",N'" & Trim(Drremarks.Text) & "',0,'CASH')", ob.getconnection())
                End If
                End If
        Else
                For i As Integer = 0 To Dgtrasfer.Rows.Count - 1
                    If Dgtrasfer.Rows(i).Cells(4).Value <> 0 Then
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Dgtrasfer.Rows(i).Cells(1).Tag & ",N'" & Dgtrasfer.Rows(i).Cells(1).Value & "'," & Dgtrasfer.Rows(i).Cells(4).Value & ",N'" & Trim(Dgtrasfer.Rows(i).Cells(6).Value) & "',0)", ob.getconnection())
                    Else
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Dgtrasfer.Rows(i).Cells(1).Tag & ",N'" & Dgtrasfer.Rows(i).Cells(1).Value & "'," & Dgtrasfer.Rows(i).Cells(5).Value & ",N'" & Trim(Dgtrasfer.Rows(i).Cells(7).Value) & "',0)", ob.getconnection())
                    End If
                Next
        End If
        party()
        clear()
        MessageBox.Show("Saved")
        loaddg()
    End Sub
    Public Sub party()
        If Val(pname.Tag) <> 0 Then
            'If Trim(cmbtype.Text) = "Cash Receipt" Or Trim(cmbtype.Text) = "Bank Receipt" Then
            '    ob.Execute("Insert Into AcMain(Cid, Year_id,docno, docdate, partyid, amount,Recamt) values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(pname.Tag) & ",0," & Val(cramt.Text) & ")", ob.getconnection())
            'Else
            '    ob.Execute("Insert Into AcMain(Cid, Year_id,docno, docdate, partyid, amount,Recamt) values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(pname.Tag) & "," & Val(cramt.Text) & ",0)", ob.getconnection())
            'End If
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Receiptamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(pname.Tag) & "," & Val(Drac.Tag) & "," & Val(Dramt.Text) & ")", ob.getconnection())

        End If
    End Sub
    Public Sub clear()
        Docno.Clear()
        Crac.Clear()
        Drac.Clear()
        cramt.Clear()
        Dramt.Clear()
        crremarks.Clear()
        Drremarks.Clear()
        cmbtype.Focus()
        pname.Clear()
        pname.Tag = 0
    End Sub
    Public Sub autoac()
        Docno.Text = ob.FindOneString("select isnull(max(Docno),0)+1 from Acdata where cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
    End Sub
    Public Sub loaddg()
        Dim dt As DataTable = ob.Returntable("Select * from Acdata Where Docdate='" & ob.DateConversion(Ddate.Text) & "' and Acid<>1 and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dg.Rows.Count - 1 Then
                Dg.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dg.Rows.Add()
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = i + 1
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Style.Font = New Font("Cambria", 12, FontStyle.Regular)

                If dt.Rows(i).Item("Dramt") = "0" Then
                    Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Acname")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = "0.00"
                    Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = dt.Rows(i).Item("Cramt")
                Else
                    Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Acname")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = dt.Rows(i).Item("Dramt")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = "0.00"
                End If
                Dg.Rows(Dg.Rows.Count - 1).Cells(1).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dg.Rows(Dg.Rows.Count - 1).Cells(4).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dg.Rows(Dg.Rows.Count - 1).Cells(5).Style.Font = New Font("Cambria", 12, FontStyle.Regular)

                Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Docno")
                Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Type")
                Dg.Rows(Dg.Rows.Count - 1).Cells(6).Value = dt.Rows(i).Item("remarks")
                Dg.Rows(Dg.Rows.Count - 1).Cells(7).Value = dt.Rows(i).Item("remarks")

                Dg.Rows(Dg.Rows.Count - 1).Cells(2).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dg.Rows(Dg.Rows.Count - 1).Cells(6).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
                Dg.Rows(Dg.Rows.Count - 1).Cells(7).Style.Font = New Font("Cambria", 12, FontStyle.Regular)
            Next
        End If
        Dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
        'Dg.RowsDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Dg.Columns(3).DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Bold)
    End Sub

    Private Sub cramt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cramt.Validated
        If cmbtype.Text = "Transfer" Then
        Else
            Dramt.Text = cramt.Text
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        autoac()
        clear()
    End Sub

    Private Sub Dramt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dramt.Validated
        If Dramt.Text <> "" Then
            cramt.Text = Dramt.Text
        End If
    End Sub

    Private Sub Drremarks_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Drremarks.Text <> "" Then
            crremarks.Text = Drremarks.Text
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loaddg()
    End Sub

    Private Sub Docno_Validated(sender As Object, e As EventArgs) Handles Docno.Validated
        Dim dt As DataTable = ob.Returntable("Select * from Acdata where Docno=" & Val(Docno.Text) & " and Type='" & Trim(cmbtype.Text) & "' and year_id='" & clsVariables.WorkingYear & "' and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("type") = "Cash Receipt" And dt.Rows(i).Item("type") = "Cash Payment" Then

                        If Val(dt.Rows(i).Item("Dramt")) <> 0 Then
                            Crac.Tag = dt.Rows(i).Item("Acid")
                            Crac.Text = dt.Rows(i).Item("Acname")
                            cramt.Text = dt.Rows(i).Item("dramt")
                            crremarks.Text = dt.Rows(i).Item("Remarks")
                            Drremarks.Text = dt.Rows(i).Item("Remarks")
                        Else
                            Drac.Tag = dt.Rows(i).Item("Acid")
                            Drac.Text = dt.Rows(i).Item("Acname")
                            Dramt.Text = dt.Rows(i).Item("cramt")
                        End If
                    Else
                        If Val(dt.Rows(i).Item("Dramt")) = 0 Then
                            Crac.Tag = dt.Rows(i).Item("Acid")
                            Crac.Text = dt.Rows(i).Item("Acname")
                            cramt.Text = dt.Rows(i).Item("Cramt")
                            crremarks.Text = dt.Rows(i).Item("Remarks")
                            Drremarks.Text = dt.Rows(i).Item("Remarks")
                        Else
                            Drac.Tag = dt.Rows(i).Item("Acid")
                            Drac.Text = dt.Rows(i).Item("Acname")
                            Dramt.Text = dt.Rows(i).Item("Dramt")
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & " and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        MessageBox.Show("Deleted")
        clear()
    End Sub

    Private Sub pname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pname.Validating
        If Trim(pname.Text) <> "" Then
            'Dim dt As DataTable = ob.Returntable("select * from Party_master where party_name='" & pname.Text & "'", ob.getconnection())
            'If dt.Rows.Count > 0 Then
            '    pname.Tag = dt.Rows(0).Item("Party_id")
            'End If
            pname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(pname.Text) & "' or Member_Id=" & Val(pname.Text) & "", ob.getconnection())
            If Val(pname.Tag) <> 0 Then
                pname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(pname.Tag) & "", ob.getconnection())

                ' chaln()
            End If
        End If
    End Sub

    Private Sub Drac_Enter(sender As Object, e As EventArgs) Handles Drremarks.Enter, crremarks.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub

    Private Sub Drac_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Drremarks.Validating, crremarks.Validating
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub

    Private Sub pname_KeyDown(sender As Object, e As KeyEventArgs) Handles pname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dramt.Focus()
        End If
    End Sub
End Class