Imports WeightPavti.CLS
Imports System.Data
Imports System.Data.SqlClient
Public Class BankEntry
    Private Sub cmbtype_KeyDown(sender As Object, e As KeyEventArgs) Handles remarks.KeyDown, txtAccountName.KeyDown, Drac.KeyDown, Docno.KeyDown, Ddate.KeyDown, cmbtype.KeyDown, sname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmbtype_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='" & Trim(cmbtype.Text) & "' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())

    End Sub

    Private Sub BankEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ddate.Text = Format(Now, "dd/MM/yyyy")
        'Ddate.Text = "01/04/2020"
        cmbtype.SelectedIndex = 0
        TxtFill("select Remarks from acdata", remarks)
        txtAccountName.Tag = 9941
        If Val(txtAccountName.Tag) <> 0 Then
            txtAccountName.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())
        End If

    End Sub

    Private Sub txtAccountName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAccountName.Validating
        If txtAccountName.Text <> "" Then
            txtAccountName.Tag = ob.FindOneString("Select Account_id From Account_Master Where Account_Name=N'" & Trim(txtAccountName.Text) & "' or Account_id=" & Val(txtAccountName.Text) & "", ob.getconnection())
            If Val(txtAccountName.Tag) <> 0 Then
                txtAccountName.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())

                ' chaln()
            Else
                If Val(txtAccountName.Tag) = 0 Then
                    clsVariables.HelpId = "Account_id"
                    clsVariables.HelpName = "Account_Name"
                    clsVariables.TbName = "Account_Master"
                    HelpWin.scodename = "Name"
                    HelpWin.sorderby = " order by Account_Name"
                    HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Account_Name Like N'" & Trim(txtAccountName.Text) & "%'"
                    HelpWin.ShowDialog()
                    If clsVariables.RtnHelpId <> "" Then
                        txtAccountName.Tag = clsVariables.RtnHelpId
                        txtAccountName.Text = clsVariables.RtnHelpName

                    End If
                End If
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
        ' Drac.Tag = 9941
        'Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
        'InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub

    Private Sub txtAccountName_Enter(sender As Object, e As EventArgs) Handles txtAccountName.Enter
        ' InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(2)

    End Sub

    Private Sub Dramt_Validated(sender As Object, e As EventArgs) Handles Amount.Validated


    End Sub

    Private Sub Drac_Validated(sender As Object, e As EventArgs) Handles Drac.Validated
        Drac.Tag = ob.FindOneString("Select Account_id From Account_Master Where Account_Name=N'" & Trim(Drac.Text) & "' or Account_id=" & Val(Drac.Text) & "", ob.getconnection())
        If Val(Drac.Tag) <> 0 Then
            Drac.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
        End If
        If Val(Drac.Tag) = 0 Or Trim(Drac.Text) = "" Then
            clsVariables.HelpId = "Account_id"
            clsVariables.HelpName = "Account_Name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_Name"
            HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Group_id=8"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                Drac.Tag = clsVariables.RtnHelpId
                Drac.Text = clsVariables.RtnHelpName
            End If
        End If
    End Sub

    Private Sub Amount_KeyDown(sender As Object, e As KeyEventArgs) Handles Amount.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg.Rows.Add()
            dg.Rows(dg.Rows.Count - 1).Cells(0).Tag = txtAccountName.Tag
            dg.Rows(dg.Rows.Count - 1).Cells(0).Value = txtAccountName.Text
            dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = sname.Tag
            dg.Rows(dg.Rows.Count - 1).Cells(1).Value = sname.Text
            dg.Rows(dg.Rows.Count - 1).Cells(2).Value = remarks.Text
            dg.Rows(dg.Rows.Count - 1).Cells(3).Value = Amount.Text
            dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("shruti", 10, FontStyle.Regular)
            dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
            dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("shruti", 10, FontStyle.Regular)
            dg.Rows(dg.Rows.Count - 1).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
            txtAccountName.Tag = 0
            txtAccountName.Text = ""
            sname.Tag = 0
            sname.Clear()
            remarks.Clear()
            Amount.Clear()
            txtAccountName.Focus()
            total()
            txtAccountName.Tag = 9941
            If Val(txtAccountName.Tag) <> 0 Then
                txtAccountName.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())
            End If
        End If
    End Sub
    Public Sub total()
        Dim cc As Double = 0
        Dim dd As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            cc = Val(cc) + Val(dg.Rows(i).Cells(3).Value)
            'dd = Val(dd) + Val(dg.Rows(i).Cells(4).Value)
        Next
        dtotal.Text = Val(cc)
        'ddr.Text = Val(dd)
    End Sub

    Private Sub Docno_Validated(sender As Object, e As EventArgs) Handles Docno.Validated
        Dim dt As New DataTable
        dt = ob.Returntable("Select * from Acdata where Docno=" & Val(Docno.Text) & " and Type='" & Trim(cmbtype.Text) & "' and year_id='" & clsVariables.WorkingYear & "' and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If dg.Rows.Count > 0 Then
                dg.Rows.Clear()
            End If
            'Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            'If result1 = 6 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If Trim(cmbtype.Text) = "Bank Receipt" Then
                    If Val(dt.Rows(i).Item("Dramt")) <> 0 Then
                        Drac.Tag = dt.Rows(i).Item("acid")
                        Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
                        Ddate.Text = dt.Rows(i).Item("docdate")
                    Else
                        dg.Rows.Add()
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Tag = dt.Rows(i).Item("acid")
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(dt.Rows(i).Item("acid")) & "", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = ob.FindOneString("select Partyid from Acmain where Billno=" & Val(Docno.Text) & " and Billtype='" & Trim(cmbtype.Text) & "' and acid=" & Val(dt.Rows(i).Item("acid")) & " and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(dg.Rows(dg.Rows.Count - 1).Cells(1).Tag) & "", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Remarks")
                        dg.Rows(dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Cramt")
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                    End If
                Else
                    If Val(dt.Rows(i).Item("Dramt")) = 0 Then
                        Drac.Tag = dt.Rows(i).Item("acid")
                        Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
                        Ddate.Text = dt.Rows(i).Item("docdate")
                    Else
                        'dg.Rows.Add()
                        'dg.Rows(dg.Rows.Count - 1).Cells(0).Tag = dt.Rows(i).Item("acid")
                        'dg.Rows(dg.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(dt.Rows(i).Item("acid")) & "", ob.getconnection())
                        'dg.Rows(dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Remarks")
                        'dg.Rows(dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Dramt")
                        'dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        'dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        'dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                        'dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                        dg.Rows.Add()
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Tag = dt.Rows(i).Item("acid")
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(dt.Rows(i).Item("acid")) & "", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = ob.FindOneString("select Partyid from Acmain where Billno=" & Val(Docno.Text) & " and Billtype='" & Trim(cmbtype.Text) & "' and acid=" & Val(dt.Rows(i).Item("acid")) & " and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(dg.Rows(dg.Rows.Count - 1).Cells(1).Tag) & "", ob.getconnection())
                        dg.Rows(dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Remarks")
                        dg.Rows(dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Dramt")
                        dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                        dg.Rows(dg.Rows.Count - 1).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                    End If
                End If
            Next
            total()
        End If
        'End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = Ddate.Text
        If (sdate) >= gFinYearBegin And (sdate) <= gFinYearEnd Then
            ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())
            ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and Billno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())

            If Trim(cmbtype.Text) <> "Bank Receipt" Then
                For i As Integer = 0 To dg.Rows.Count - 1
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & dg.Rows(i).Cells(0).Tag & ",N'" & dg.Rows(i).Cells(0).Value & "'," & dg.Rows(i).Cells(3).Value & ",N'" & Trim(dg.Rows(i).Cells(2).Value) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & dg.Rows(i).Cells(3).Value & ",N'" & Trim(dg.Rows(i).Cells(2).Value) & "',0,'" & cmbtype.Text & "')", ob.getconnection())

                    ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Paymentamt,ptype,Remarks) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(dg.Rows(i).Cells(1).Tag) & "," & Val(dg.Rows(i).Cells(0).Tag) & "," & Val(dg.Rows(i).Cells(3).Value) & ",'" & cmbtype.Text & "',N'" & Trim(dg.Rows(i).Cells(2).Value) & "')", ob.getconnection())


                Next
            Else
                For i As Integer = 0 To dg.Rows.Count - 1
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Cramt ,Remarks,Dramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & dg.Rows(i).Cells(0).Tag & ",N'" & dg.Rows(i).Cells(0).Value & "'," & dg.Rows(i).Cells(3).Value & ",N'" & Trim(dg.Rows(i).Cells(2).Value) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & dg.Rows(i).Cells(3).Value & ",N'" & Trim(dg.Rows(i).Cells(2).Value) & "',0,'" & cmbtype.Text & "')", ob.getconnection())

                    ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Receiptamt,ptype,Remarks) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(dg.Rows(i).Cells(1).Tag) & "," & Val(dg.Rows(i).Cells(0).Tag) & "," & Val(dg.Rows(i).Cells(3).Value) & ",'" & cmbtype.Text & "',N'" & Trim(dg.Rows(i).Cells(2).Value) & "')", ob.getconnection())


                Next
            End If
            MessageBox.Show("Saved")
            TxtFill("select Remarks from acdata", remarks)

            cleartext()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            Ddate.Focus()
        End If
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
    Public Sub cleartext()
        txtAccountName.Clear()
        Drac.Tag = 0
        Drac.Text = 0
        txtAccountName.Tag = 0
        txtAccountName.Text = ""
        remarks.Clear()
        Amount.Clear()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='" & Trim(cmbtype.Text) & "' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())
            ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and Billno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())
            cleartext()
        End If
    End Sub

    Private Sub sname_Validated(sender As Object, e As EventArgs) Handles sname.Validated
        If sname.Text <> "" Then
            sname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(sname.Text) & "' or Member_Id=" & Val(sname.Text) & "", ob.getconnection())
            If Val(sname.Tag) <> 0 Then
                sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())

                ' chaln()
            Else
                If Val(sname.Tag) = 0 Then
                    clsVariables.HelpId = "Member_id"
                    clsVariables.HelpName = "Member_Name"
                    clsVariables.TbName = "Member_Master"
                    HelpWin.scodename = "Name"
                    HelpWin.sorderby = " order by Member_Name"
                    HelpWin.tsql = "Select Member_Id,Member_Name from Member_Master where  Member_name Like N'" & Trim(sname.Text) & "%'"
                    HelpWin.ShowDialog()
                    If clsVariables.RtnHelpId <> "" Then
                        sname.Tag = clsVariables.RtnHelpId
                        sname.Text = clsVariables.RtnHelpName

                    End If
                End If
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If

    End Sub

    Private Sub Ddate_Validated(sender As Object, e As EventArgs) Handles Ddate.Validated
        ob.validdate(sender, Ddate.Text, True)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ssl As String = ""
        If cmbtype.Text = "Bank Receipt" Then
            ssl = "select docno,docdate,ACid,Acname,Remarks,dramt,cramt from acdata where  dramt<>0 and ptype='" & cmbtype.Text & "' and year_id='" & clsVariables.WorkingYear & "' order by docno"
        Else
            ssl = "select docno,docdate,ACid,Acname,Remarks,dramt,cramt from acdata where  dramt=0 and ptype='" & cmbtype.Text & "' and year_id='" & clsVariables.WorkingYear & "' order by docno"
        End If
        clsVariables.Findqueri = ssl
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Docno.Text = clsVariables.HelpId
        Docno_Validated(Nothing, Nothing)
        'txtDocNo_Validated(Nothing, Nothing)
    End Sub
End Class