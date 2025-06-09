Imports WeightPavti.CLS
Public Class Javak

    Private Sub Javak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdocdate.Text = Format(DateTime.Now.Date, "dd/MM/yyyy")
        Dim dt As DataTable
        dt = ob.Returntable("select isnull(max(doc_no),0)+1 as dc from danjavak where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        txtdocno.Text = dt.Rows(0).Item("dc")
        Dim dts As DataTable
        dts = ob.Returntable("select isnull(sum(amount),0) as amt from Danavak where doc_no>=" & ob.DateConversion(txtdocdate.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        Dim danamt As String = dts.Rows(0).Item("amt")
        Dim dbv As DataTable
        dbv = ob.Returntable("select isnull(sum(amount),0) as amt from danjavak where doc_no>=" & ob.DateConversion(txtdocdate.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        Dim javakamt As String = dbv.Rows(0).Item("amt")
        If danamt > javakamt Then
            txtamt.Text = danamt - javakamt
        Else
            txtamt.Text = javakamt - danamt
        End If
        txtremarks.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ob.Execute("delete from danjavak where doc_no=" & txtdocno.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("insert into danjavak (year_id,Doc_No, Doc_date, Remarks, Amount) values(" & aq(clsvariables.workingyear) & "," & txtdocno.Text & "," & aq(ob.DateConversion(txtdocdate.Text)) & "," & aq(txtremarks.Text) & "," & txtreamt.Text & ")", ob.getconnection())
        MessageBox.Show("Paid", "Paid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtreamt.Clear()
        txtremarks.Clear()
        Javak_Load(Nothing, Nothing)
    End Sub

    Private Sub txtdocno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown, txtreamt.KeyDown, txtdocno.KeyDown, txtdocdate.KeyDown, Button2.KeyDown
        tabkey(sender, e)
    End Sub

    Private Sub txtdocno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdocno.Validated
        Dim dt As DataTable
        dt = ob.Returntable("select * from danjavak where doc_no=" & txtdocno.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            If result1 = Windows.Forms.DialogResult.Yes Then
                txtdocdate.Text = ob.DateConversion(dt.Rows(0).Item("doc_date"))
                txtremarks.Text = dt.Rows(0).Item("Remarks")
                txtreamt.Text = dt.Rows(0).Item("Amount")

            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result1 As DialogResult = MessageBox.Show("Do You Want to Delete?", "Important Question", MessageBoxButtons.YesNo)
        If result1 = Windows.Forms.DialogResult.Yes Then
            ob.Execute("delete from danjavak where doc_no=" & txtdocno.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            MessageBox.Show("Delete")
            Me.Close()
        End If
    End Sub
End Class