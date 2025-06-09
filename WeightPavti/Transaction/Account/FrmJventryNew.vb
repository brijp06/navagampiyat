Imports System.Data.SqlClient
Imports WeightPavti.CLS

Public Class FrmJventryNew
    Private Sub FrmJventryNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='Transfer' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        Ddate.Text = Format(Now, "dd/MM/yyyy")
        TxtFill("select Remarks from acdata", remarks)
        txtsrno.Text = 1
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
    Private Sub txtAccountName_Validated(sender As Object, e As EventArgs) Handles txtAccountName.Validated
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

    Private Sub Dramount_KeyDown(sender As Object, e As KeyEventArgs) Handles Dramount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtsrno.Text) > dg.Rows.Count Then
                dg.Rows.Add()
                dg.Rows(dg.Rows.Count - 1).Cells(0).Value = txtsrno.Text
                dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = txtAccountName.Tag
                dg.Rows(dg.Rows.Count - 1).Cells(1).Value = txtAccountName.Text
                dg.Rows(dg.Rows.Count - 1).Cells(2).Tag = sname.Tag
                dg.Rows(dg.Rows.Count - 1).Cells(2).Value = sname.Text
                dg.Rows(dg.Rows.Count - 1).Cells(3).Value = remarks.Text
                dg.Rows(dg.Rows.Count - 1).Cells(4).Value = Val(CrAmount.Text)
                dg.Rows(dg.Rows.Count - 1).Cells(5).Value = Val(Dramount.Text)
                dg.Rows(dg.Rows.Count - 1).Cells(0).Style.Font = New Font("HARIKRISHNA", 10, FontStyle.Regular)
                dg.Rows(dg.Rows.Count - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(dg.Rows.Count - 1).Cells(2).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(dg.Rows.Count - 1).Cells(3).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(dg.Rows.Count - 1).Cells(4).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                dg.Rows(dg.Rows.Count - 1).Cells(5).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                txtAccountName.Tag = 0
                txtAccountName.Text = ""
                sname.Tag = 0
                sname.Clear()
                remarks.Clear()
                CrAmount.Clear()
                Dramount.Clear()
                txtAccountName.Focus()
                txtsrno.Text = dg.Rows.Count + 1
                total()
            Else
                dg.Rows(txtsrno.Text - 1).Cells(0).Value = txtsrno.Text
                dg.Rows(txtsrno.Text - 1).Cells(1).Tag = txtAccountName.Tag
                dg.Rows(txtsrno.Text - 1).Cells(1).Value = txtAccountName.Text
                dg.Rows(txtsrno.Text - 1).Cells(2).Tag = sname.Tag
                dg.Rows(txtsrno.Text - 1).Cells(2).Value = sname.Text
                dg.Rows(txtsrno.Text - 1).Cells(3).Value = remarks.Text
                dg.Rows(txtsrno.Text - 1).Cells(4).Value = Val(CrAmount.Text)
                dg.Rows(txtsrno.Text - 1).Cells(5).Value = Val(Dramount.Text)
                dg.Rows(txtsrno.Text - 1).Cells(0).Style.Font = New Font("HARIKRISHNA", 10, FontStyle.Regular)
                dg.Rows(txtsrno.Text - 1).Cells(1).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(txtsrno.Text - 1).Cells(2).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(txtsrno.Text - 1).Cells(3).Style.Font = New Font("shruti", 10, FontStyle.Regular)
                dg.Rows(txtsrno.Text - 1).Cells(4).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                dg.Rows(txtsrno.Text - 1).Cells(5).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                txtAccountName.Tag = 0
                txtAccountName.Text = ""
                sname.Tag = 0
                sname.Clear()
                remarks.Clear()
                CrAmount.Clear()
                Dramount.Clear()
                txtAccountName.Focus()
                txtsrno.Text = dg.Rows.Count + 1
                total()
            End If
        End If
    End Sub
    Public Sub total()
        Dim cc As Double = 0
        Dim dd As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            cc = Val(cc) + Val(dg.Rows(i).Cells(4).Value)
            dd = Val(dd) + Val(dg.Rows(i).Cells(5).Value)
        Next
        dcr.Text = Val(cc)
        ddr.Text = Val(dd)
    End Sub
    Private Sub Docno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountName.KeyDown, remarks.KeyDown, Docno.KeyDown, Ddate.KeyDown, CrAmount.KeyDown, sname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Docno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Docno.Validating
        Dim dt As New DataTable
        dt = ob.Returntable("Select * from Acdata where Docno=" & Val(Docno.Text) & " and Type='Transfer' and year_id='" & clsVariables.WorkingYear & "' and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            If dg.Rows.Count > 0 Then
                dg.Rows.Clear()
            End If
            If result1 = 6 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dg.Rows.Add()
                    dg.Rows(i).Cells(0).Value = i + 1
                    dg.Rows(i).Cells(1).Tag = dt.Rows(i).Item("Acid")
                    dg.Rows(i).Cells(1).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(dt.Rows(i).Item("acid")) & "", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Tag = ob.FindOneString("select Partyid from Acmain where Billno=" & Val(Docno.Text) & " and Billtype='Transfer' and acid=" & Val(dt.Rows(i).Item("acid")) & " and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(dg.Rows(dg.Rows.Count - 1).Cells(2).Tag) & "", ob.getconnection())
                    dg.Rows(i).Cells(3).Value = dt.Rows(i).Item("Remarks")
                    dg.Rows(i).Cells(4).Value = Val(dt.Rows(i).Item("Cramt"))
                    dg.Rows(i).Cells(5).Value = Val(dt.Rows(i).Item("Dramt"))
                    Ddate.Text = dt.Rows(i).Item("docdate")
                Next
                total()
            End If
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = Ddate.Text

        If (sdate) >= gFinYearBegin And (sdate) <= gFinYearEnd Then
            If Val(ddr.Text) = Val(dcr.Text) Then
                ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and ptype='Transfer' and Billno=" & Docno.Text & " and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
                ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and ptype='Transfer' and Docno=" & Docno.Text & " and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
                For i As Integer = 0 To dg.Rows.Count - 1
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','Transfer'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & dg.Rows(i).Cells(1).Tag & ",N'" & dg.Rows(i).Cells(1).Value & "'," & dg.Rows(i).Cells(4).Value & ",N'" & Trim(dg.Rows(i).Cells(3).Value) & "'," & dg.Rows(i).Cells(5).Value & ",'Transfer')", ob.getconnection())
                    ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Receiptamt,Paymentamt,Remarks,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','Transfer','Transfer'," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(dg.Rows(i).Cells(2).Tag) & "," & Val(dg.Rows(i).Cells(1).Tag) & "," & Val(dg.Rows(i).Cells(4).Value) & "," & Val(dg.Rows(i).Cells(5).Value) & ",N'" & Trim(dg.Rows(i).Cells(3).Value) & "','Transfer')", ob.getconnection())
                Next
                If dg.Rows.Count > 0 Then
                    dg.Rows.Clear()
                End If
                Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='Transfer' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
                Ddate.Text = Format(Now, "dd/MM/yyyy")
                Docno.Focus()
                TxtFill("select Remarks from acdata", remarks)
            Else
                MessageBox.Show("Total MissMatch")
                Exit Sub
            End If
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            Ddate.Focus()
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and ptype='Transfer' and Billno=" & Docno.Text & " and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())

        ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and type='Transfer' and Docno=" & Docno.Text & " and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='Transfer' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())

        Ddate.Text = Format(Now, "dd/MM/yyyy")
        Docno.Focus()
    End Sub

    Private Sub sname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sname.Validating
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

    Private Sub dg_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dg.RowsRemoved
        total()
    End Sub

    Private Sub Ddate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Ddate.Validating
        ob.validdate(sender, Ddate.Text, True)

    End Sub

    Private Sub txtsrno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsrno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountName.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clsVariables.Findqueri = " select docno,docdate,SUM(dramt) as dramt,sum(cramt) as cramt from acdata where   ptype='Transfer' and year_id='" & clsVariables.WorkingYear & "' group by docno,docdate order by docno"
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Docno.Text = clsVariables.HelpId
        Docno_Validating(Nothing, Nothing)
    End Sub

    Private Sub txtsrno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtsrno.Validating

        For i As Integer = 0 To dg.Rows.Count - 1
                If txtsrno.Text = dg.Rows(i).Cells(0).Value Then
                    txtsrno.Text = dg.Rows(txtsrno.Text - 1).Cells(0).Value
                    txtAccountName.Tag = dg.Rows(txtsrno.Text - 1).Cells(1).Tag
                    txtAccountName.Text = dg.Rows(txtsrno.Text - 1).Cells(1).Value
                    sname.Tag = dg.Rows(txtsrno.Text - 1).Cells(2).Tag
                    sname.Text = dg.Rows(txtsrno.Text - 1).Cells(2).Value
                    remarks.Text = dg.Rows(txtsrno.Text - 1).Cells(3).Value
                    CrAmount.Text = dg.Rows(txtsrno.Text - 1).Cells(4).Value
                    Dramount.Text = dg.Rows(txtsrno.Text - 1).Cells(5).Value
                    txtAccountName.Focus()
                End If
            Next

    End Sub
End Class