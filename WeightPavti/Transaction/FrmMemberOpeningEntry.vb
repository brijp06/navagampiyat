Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class FrmMemberOpeningEntry
    Private Sub FrmMemberOpeningEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select name from ItemGroup", txtvillageid)
        TxtFill("Select name from itemgroup", txtcolumn)
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "'  and ptype='Opening'", ob.getconnection())

        'Dim msk As String = gFinYearBegin
        'billDt.Text = Now
        'billDt.Refresh()
        billDt.Text = gFinYearBegin
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

    Private Sub txtvillageid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillageid.Validating
        txtvillageid.Tag = ob.FindOneString("select column_id from column_master where column_name=N'" & Trim(txtvillageid.Text) & "' or column_id=" & Val(txtvillageid.Text) & "", ob.getconnection())
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtcolumn_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtcolumn.Validating
        txtcolumn.Tag = ob.FindOneString("select code from itemgroup where name=N'" & Trim(txtcolumn.Text) & "' or code=" & Val(txtcolumn.Text) & "", ob.getconnection())
        If Val(txtcolumn.Tag) <> 0 Then
            txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub TextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        txtname.Tag = ob.FindOneString("select member_id from member_master where member_name=N'" & Trim(txtname.Text) & "' or member_id=" & Val(txtname.Text) & "", ob.getconnection())
        If Val(txtname.Tag) <> 0 Then
            txtname.Text = ob.FindOneString("select member_name from member_master where  member_id=" & Val(txtname.Tag) & "", ob.getconnection())
            Dim vi As String = ob.FindOneString("select village_id from member_master where  member_id=" & Val(txtname.Tag) & "", ob.getconnection())
            txtvname.Text = ob.FindOneString("select village_name from village_master where  village_id=" & Val(vi) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtamount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtamount.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg.Rows.Add()
            dg.Rows(dg.Rows.Count - 1).Cells(0).Value = txtname.Tag
            dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = txtname.Tag

            dg.Rows(dg.Rows.Count - 1).Cells(1).Value = txtname.Text
            dg.Rows(dg.Rows.Count - 1).Cells(2).Value = txtvname.Text
            dg.Rows(dg.Rows.Count - 1).Cells(3).Value = txtamount.Text
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

            txtname.Clear()
            txtvname.Clear()
            txtamount.Clear()
            txtname.Focus()
        End If
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtvillageid.KeyDown, txtname.KeyDown, txtcolumn.KeyDown, Billno.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{Tab}")

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from Acmain Where  Billno=" & Billno.Text & " and Year_id='" & clsVariables.WorkingYear & "'  and ptype='Opening'", ob.getconnection())
        For i As Integer = 0 To dg.Rows.Count - 1
            ob.Execute("Insert into Acmain( Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, gst, Basic, Roundoff, Netamt, PaymentAmt, ReceiptAmt, ptype,Tid) values(1,'" & clsVariables.WorkingYear & "','Opening','Opening'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(dg.Rows(i).Cells(1).Tag) & ",21,'-',5,0," & Val(dg.Rows(i).Cells(3).Value) & ",0," & Val(dg.Rows(i).Cells(3).Value) & "," & Val(dg.Rows(i).Cells(3).Value) & ",0,'Opening',5)", ob.getconnection())
            ob.Execute("Insert into Acstock( Cid, Year_id, Department, Billtype, Billno, Billdate,ptype,blockNo, ServeNo, Hektar, Guntha, Aker, AHektar, AGuntha, LPer, LFund, Rate1, Amount, TotalAmount) values(1,'" & clsVariables.WorkingYear & "','Opening','Opening'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "','Opening',0,0,0,0,0,0,0,0,0,0," & Val(dg.Rows(i).Cells(3).Value) & "," & Val(dg.Rows(i).Cells(3).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("saved")
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "'  and ptype='Opening'", ob.getconnection())

        Dim msk As String = billDt.Mask
        billDt.Text = Now
        billDt.Refresh()
        billDt.Mask = msk

        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        txtvillageid.Clear()
        txtcolumn.Clear()
        Billno.Focus()
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & " and  ptype='Opening' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                txtvillageid.Tag = 5
                If Val(txtvillageid.Tag) <> 0 Then
                    txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
                End If
                txtcolumn.Tag = 1
                If Val(txtcolumn.Tag) <> 0 Then
                    txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    dg.Rows.Add()
                    dg.Rows(dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("partyid")
                    dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = dt.Rows(i).Item("partyid")

                    dg.Rows(dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(i).Item("partyid") & "", ob.getconnection())
                    Dim vi As String = ob.FindOneString("select village_id from member_master where  member_id=" & Val(dt.Rows(i).Item("partyid")) & "", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select village_name from village_master where  village_id=" & Val(vi) & "", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("PaymentAmt")
                Next
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

            End If
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from Acmain Where Billno=" & Billno.Text & " and Year_id='" & clsVariables.WorkingYear & "'  and ptype='Opening'", ob.getconnection())
            Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "'  and ptype='Opening'", ob.getconnection())

            Dim msk As String = billDt.Mask
            billDt.Text = Now
            billDt.Refresh()
            billDt.Mask = msk

            If dg.Rows.Count > 0 Then
                dg.Rows.Clear()
            End If
            txtvillageid.Clear()
            txtcolumn.Clear()
            Billno.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class