Imports WeightPavti.CLS
Public Class FrmShareTrasfer
    Private Sub txtDocno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTharavno.KeyDown, txtTharavDate.KeyDown, txtsrno.KeyDown, txtshrebhagnoTo.KeyDown, txtshrebhagnofrom.KeyDown, txtshare.KeyDown, Txtremark.KeyDown, txtmembname.KeyDown, txtDocno.KeyDown, txtDocDate.KeyDown, txtcertno.KeyDown, txtamount.KeyDown, txtacname.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtsrno.Text = 0 Then
                ButSave.Focus()
            Else
                SendKeys.Send("{Tab}")
            End If

        End If
    End Sub

    Private Sub FrmShareTrasfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDocno.Text = ob.FindOneString("select isnull(max(billno),0)+1 from acmain where year_id='" & clsVariables.WorkingYear & "' and ptype='ShareTransfer'", ob.getconnection())
        txtDocDate.Text = Format(Now, "dd/MM/yyyy")
        txtTharavDate.Text = Format(Now, "dd/MM/yyyy")
        txtsrno.Text = 1
        txtacname.Tag = 1
        If Val(txtacname.Tag) <> 0 Then
            txtacname.Text = ob.FindOneString("select account_Name from account_master where Account_id=" & Val(txtacname.Tag) & "", ob.getconnection())
        End If
        autotwo()
        autotwo1()
    End Sub
    Public Sub autotwo()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Member_name from Member_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Member_name"))
        Next
        txtmembname.AutoCompleteMode = AutoCompleteMode.Suggest
        txtmembname.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtmembname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autotwo1()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Member_name from Member_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Member_name"))
        Next
        txttoshare.AutoCompleteMode = AutoCompleteMode.Suggest
        txttoshare.AutoCompleteSource = AutoCompleteSource.CustomSource
        txttoshare.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub txtmembname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtmembname.Validating
        txtmembname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(txtmembname.Text) & "' or Member_Id=" & Val(txtmembname.Text) & "", ob.getconnection())
        If Val(txtmembname.Tag) <> 0 Then
            txtmembname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(txtmembname.Tag) & "", ob.getconnection())
            txtcertno.Text = ob.FindOneString("select CertiNo from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
            txtshare.Text = ob.FindOneString("select Share from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
            txtshare.Text = ob.FindOneString("select Share from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
            txtshrebhagnofrom.Text = ob.FindOneString("select FromCertiNo from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
            txtshrebhagnoTo.Text = ob.FindOneString("select ToCertiNo from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
            txtamount.Text = ob.FindOneString("select rate from acmain where partyid=" & Val(txtmembname.Tag) & " and acid=" & Val(txtacname.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txttoshare_KeyDown(sender As Object, e As KeyEventArgs) Handles txttoshare.KeyDown
        If e.KeyCode = Keys.Enter Then
            txttoshare.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(txttoshare.Text) & "' or Member_Id=" & Val(txttoshare.Text) & "", ob.getconnection())
            If Val(txttoshare.Tag) <> 0 Then
                txttoshare.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(txttoshare.Tag) & "", ob.getconnection())
            End If
            If Val(txtsrno.Text) > dg.Rows.Count Then
                dg.Rows.Add()
            End If
            dg.Rows(txtsrno.Text - 1).Cells(0).Value = txtsrno.Text
            dg.Rows(txtsrno.Text - 1).Cells(1).Value = txtmembname.Text
            dg.Rows(txtsrno.Text - 1).Cells(1).Tag = txtmembname.Tag
            dg.Rows(txtsrno.Text - 1).Cells(2).Value = txtacname.Text
            dg.Rows(txtsrno.Text - 1).Cells(2).Tag = txtacname.Tag
            dg.Rows(txtsrno.Text - 1).Cells(3).Value = txtcertno.Text
            dg.Rows(txtsrno.Text - 1).Cells(4).Value = txtshare.Text
            dg.Rows(txtsrno.Text - 1).Cells(5).Value = txtshrebhagnofrom.Text
            dg.Rows(txtsrno.Text - 1).Cells(6).Value = txtshrebhagnoTo.Text
            dg.Rows(txtsrno.Text - 1).Cells(7).Value = txtamount.Text
            dg.Rows(txtsrno.Text - 1).Cells(8).Value = txttoshare.Text
            dg.Rows(txtsrno.Text - 1).Cells(8).Tag = txttoshare.Tag
            txtsrno.Text = dg.Rows.Count + 1
            txtmembname.Text = ""
            txtcertno.Text = ""
            txtshare.Text = ""
            txtshrebhagnofrom.Text = ""
            txtshrebhagnoTo.Text = ""
            txtamount.Text = ""
            txtshrebhagnoTo.Text = ""
            txttoshare.Clear()
            txtsrno.Focus()
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where billno=" & Val(txtDocno.Text) & " and billtype='ShareTransfer' and Department='Member' and ptype='ShareTransfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        For i As Integer = 0 To dg.Rows.Count - 1
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, Netamt,PaymentAmt,ptype,Tid,Duedate,Rate,CertiNo,Share,FromCertiNo,ToCertiNo) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','Member','ShareTransfer'," & Val(txtDocno.Text) & ",'" & ob.DateConversion(txtDocDate.Text) & "'," & Val(dg.Rows(i).Cells(1).Tag) & "," & Val(dg.Rows(i).Cells(2).Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(txtTharavno.Text) & "," & Val(dg.Rows(i).Cells(7).Value) & "," & Val(dg.Rows(i).Cells(7).Value) & ",'ShareTransfer'," & Val(dg.Rows(i).Cells(8).Tag) & ",'" & ob.DateConversion(txtTharavDate.Text) & "'," & Val(dg.Rows(i).Cells(7).Value) & "," & Val(dg.Rows(i).Cells(3).Value) & "," & Val(dg.Rows(i).Cells(4).Value) & "," & Val(dg.Rows(i).Cells(5).Value) & "," & Val(dg.Rows(i).Cells(6).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("Saved")
        txtDocno.Text = ob.FindOneString("select isnull(max(billno),0)+1 from acmain where year_id='" & clsVariables.WorkingYear & "' and ptype='ShareTransfer'", ob.getconnection())
        txtDocDate.Text = Format(Now, "dd/MM/yyyy")
        txtTharavDate.Text = Format(Now, "dd/MM/yyyy")
        txtsrno.Text = 1
        txtTharavno.Clear()
        Txtremark.Clear()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        txtDocno.Focus()
    End Sub

    Private Sub txtDocno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDocno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(txtDocno.Text) & " and billtype='ShareTransfer' and Department='Member' and ptype='ShareTransfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                txtDocDate.Text = dt.Rows(0).Item("billdate")
                txtTharavDate.Text = dt.Rows(0).Item("duedate")
                txtTharavno.Text = dt.Rows(0).Item("clid")
                Txtremark.Text = dt.Rows(0).Item("remarks")
                dg.Rows.Add()
                txtsrno.Text = 1
                dg.Rows(txtsrno.Text - 1).Cells(0).Value = 1
                dg.Rows(txtsrno.Text - 1).Cells(1).Value = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())
                dg.Rows(txtsrno.Text - 1).Cells(1).Tag = dt.Rows(0).Item("partyid")
                dg.Rows(txtsrno.Text - 1).Cells(2).Value = ob.FindOneString("select account_Name from account_master where Account_id=92", ob.getconnection())
                dg.Rows(txtsrno.Text - 1).Cells(2).Tag = dt.Rows(0).Item("acid")
                dg.Rows(txtsrno.Text - 1).Cells(3).Value = dt.Rows(0).Item("CertiNo")
                dg.Rows(txtsrno.Text - 1).Cells(4).Value = dt.Rows(0).Item("Share")
                dg.Rows(txtsrno.Text - 1).Cells(5).Value = dt.Rows(0).Item("FromCertiNo")
                dg.Rows(txtsrno.Text - 1).Cells(6).Value = dt.Rows(0).Item("ToCertiNo")
                dg.Rows(txtsrno.Text - 1).Cells(7).Value = dt.Rows(0).Item("rate")
                dg.Rows(txtsrno.Text - 1).Cells(8).Value = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("Tid") & "", ob.getconnection())
                dg.Rows(txtsrno.Text - 1).Cells(8).Tag = dt.Rows(0).Item("Tid")
            End If
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from acmain where billno=" & Val(txtDocno.Text) & " and billtype='ShareTransfer' and Department='Member' and ptype='ShareTransfer' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            MessageBox.Show("Delete")
            txtDocno.Text = ob.FindOneString("select isnull(max(billno),0)+1 from acmain where year_id='" & clsVariables.WorkingYear & "' and ptype='ShareTransfer'", ob.getconnection())
            txtDocDate.Text = Format(Now, "dd/MM/yyyy")
            txtTharavDate.Text = Format(Now, "dd/MM/yyyy")
            txtsrno.Text = 1
            txtTharavno.Clear()
            Txtremark.Clear()
            If dg.Rows.Count > 0 Then
                dg.Rows.Clear()
            End If
            txtDocno.Focus()
        End If
    End Sub
End Class