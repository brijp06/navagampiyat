﻿Imports WeightPavti.CLS
Public Class Shareledger


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Share Ledger")
        item = Dg.Items.Add("Share Transfer Report")
        'item = Dg.Items.Add("Account Ledger Report Cash")
        dg1.Columns.Add("", "")
        Panel1.Visible = False
        auto()
        autoname()
        autotwo()
        TxtfromDate.Text = "01/04/2012"
        TxtToDate.Text = Format(Now, "dd/MM/yyyy")
        Acname.Tag = 1
        If Val(Acname.Tag) <> 0 Then
            Acname.Text = ob.FindOneString("select account_Name from account_master where Account_id=" & Val(Acname.Tag) & "", ob.getconnection())
        End If
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_name from Account_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_name"))
        Next
        Acname.AutoCompleteMode = AutoCompleteMode.Suggest
        Acname.AutoCompleteSource = AutoCompleteSource.CustomSource
        Acname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autotwo()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Member_name from Member_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Member_name"))
        Next
        Membname.AutoCompleteMode = AutoCompleteMode.Suggest
        Membname.AutoCompleteSource = AutoCompleteSource.CustomSource
        Membname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autoname()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        txtproduct.AutoCompleteMode = AutoCompleteMode.Suggest
        txtproduct.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtproduct.AutoCompleteCustomSource = AutoComp
    End Sub
    Private Sub txtproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproduct.Validated
        If txtproduct.Text <> "" Then
            If IsNumeric(txtproduct.Text) Then
                Dim trn As DataTable = ob.Returntable("Select * from Transfer Where Houseno=" & txtproduct.Text & " Order By Tharavno desc", ob.getconnection())
                If trn.Rows.Count > 0 Then
                    txtproduct.Text = trn.Rows(0).Item("tname")
                    txtproduct.Tag = trn.Rows(0).Item("tid")
                Else
                    txtproduct.Tag = ob.FindOneinteger("select Party_id From Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                    txtproduct.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                End If
            Else
                Dim dt As DataTable = ob.Returntable("select gstno From Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                If dt.Rows.Count >= 2 Then
                    If dg1.Rows.Count > 0 Then
                        dg1.Rows.Clear()
                    End If
                    Panel1.Visible = True
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dg1.Rows.Add()
                        dg1.Rows(dg1.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("gstno")
                    Next
                    Exit Sub
                Else
                    txtproduct.Tag = ob.FindOneinteger("Select Party_id from Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                End If
            End If
        End If
    End Sub

    Private Sub itemname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemname.Validated
        If itemname.Text <> "" Then
            itemname.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & itemname.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ssql As String = ""
        If Dg.SelectedItems(0).SubItems(0).Text = "Share Ledger" Then
            ssql = "" '"{Acmain.Department}='Member'"
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.PassAccId = Val(Membname.Tag)
            clsVariables.RDocNo = Val(Acname.Tag)
            clsVariables.Repheader = "Share Ledger"
            clsVariables.ReportName = "ShareLedgerReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else
            ssql = "{Acmain.ptype}='ShareTransfer'"
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.PassAccId = Val(Membname.Tag)
            clsVariables.RDocNo = Val(Acname.Tag)
            clsVariables.Repheader = "Share Ledger"
            clsVariables.ReportName = "MemberTransferReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    

    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtfromDate.Focus()
        End If
    End Sub

    Private Sub TxtfromDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToDate.KeyDown, txtproduct.KeyDown, TxtfromDate.KeyDown, itemname.KeyDown, Acname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then
            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub dg1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        Dim gst As String = dg1.Rows(e.RowIndex).Cells(0).Value
        txtproduct.Tag = ob.FindOneString("Select Party_id from Party_master where gstno=" & gst & "", ob.getconnection())
        Panel1.Visible = False
        itemname.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel1.Visible = False
        txtproduct.Clear()
        txtproduct.Focus()
    End Sub

    Private Sub TxtfromDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtfromDate.Validating
        
    End Sub

    Private Sub Acname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Acname.Validated
        Acname.Tag = ob.FindOneinteger("select account_id from account_master where Account_name=N'" & Trim(Acname.Text) & "' or Account_id=" & Val(Acname.Text) & "", ob.getconnection())

        If Val(Acname.Tag) <> 0 Then
            Acname.Text = ob.FindOneString("select account_Name from account_master where Account_id=" & Val(Acname.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub Membname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Membname.Validating
        Membname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Membname.Text) & "' or Member_Id=" & Val(Membname.Text) & "", ob.getconnection())
        If Val(Membname.Tag) <> 0 Then
            Membname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Membname.Tag) & "", ob.getconnection())
        End If

    End Sub

    Private Sub Membname_KeyDown(sender As Object, e As KeyEventArgs) Handles Membname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class