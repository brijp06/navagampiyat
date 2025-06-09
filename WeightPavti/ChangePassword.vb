Imports WeightPavti.CLS
Public Class ChangePassword

    Private Sub BUtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtCancel.Click
        Me.Close()
    End Sub

    Private Sub txtpassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.GotFocus, txtNewPassword.GotFocus, txtConfirmPassword.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress, txtConfirmPassword.KeyPress, txtNewPassword.KeyPress
        tabkey(sender, e)
        qute(sender, e)
    End Sub

    Private Sub txtpassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.LostFocus, txtConfirmPassword.LostFocus, txtNewPassword.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassword.TextChanged

    End Sub

    Private Sub txtpassword_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.Validated

    End Sub

    Private Sub BUtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtOk.Click
        Try
            If Len(txtpassword.Text) = 0 Then
                MessageBox.Show("Please Enter Old Password", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtpassword.Focus()
                Exit Sub
            ElseIf ob.FindOneinteger("Select Count(*) from LoginMst where Usrid=" & aq(ob.ChartoAsc(clsVariables.UserName)) & " and PassWd=" & aq(ob.ChartoAsc(txtpassword.Text)), ob.getconnection(ob.Getconn)) = 0 Then
                MessageBox.Show("Please Enter Correct Old Password....!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtpassword.Focus()
                Exit Sub
            ElseIf txtNewPassword.Text <> txtConfirmPassword.Text Then
                MessageBox.Show("Confirm Password Is Not Match , So Enter Correct Confirm Password", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtConfirmPassword.Focus()
            Else
                Dim sql As String
                Sql = "Update LoginMst set "
                sql = sql & "Passwd=" & aq(ob.ChartoAsc(txtNewPassword.Text)) & ","
                sql = sql & "Dta_Dat=" & aq(Format(Now.Date, "MM/dd/yyyy")) & ","
                Sql = Sql & "Dta_time=" & aq(Now.ToLongTimeString) & ","
                Sql = Sql & "Dta_user=" & aq(guser)
                sql = sql & " where usrid=" & aq(ob.ChartoAsc(clsVariables.UserName))
                ob.Execute(Sql, ob.getconnection())
                MessageBox.Show("Password Is Update Successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiMain
        'Me.BackgroundImage = MdiMain.PicMaster.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
End Class