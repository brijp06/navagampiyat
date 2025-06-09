Imports WeightPavti.CLS
Public Class CompanyMst
    Dim Ssql As String
    Dim ISadd As Boolean
    Private Sub CompanyMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        'Me.BackgroundImage = MdiMain.PicTransaction.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
    End Sub

    Private Sub TxtCompanyid_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyid.Enter
        Textactive(sender)
    End Sub

    Private Sub TxtCompanyid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCompanyid.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub TxtCompanyid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyid.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCompanyid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCompanyid.TextChanged

    End Sub

    Private Sub TxtCompanyName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyName.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtCompanyName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCompanyName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtCompanyName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCompanyName.TextChanged

    End Sub

    Private Sub TxtPropriter_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPropriter.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPropriter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPropriter.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtPropriter_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPropriter.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtPropriter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPropriter.TextChanged

    End Sub

    Private Sub TxtMethodOfAc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMethodOfAc.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtMethodOfAc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMethodOfAc.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtMethodOfAc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMethodOfAc.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtMethodOfAc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMethodOfAc.TextChanged

    End Sub

    Private Sub TxtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddress.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddress.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtAddress_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddress.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddress.TextChanged

    End Sub

    Private Sub TXtCity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtCity.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtCity.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtCity.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtCity.TextChanged

    End Sub

    Private Sub TxtState_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtState.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtState.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtState_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtState.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtState_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtState.TextChanged

    End Sub

    Private Sub TxtPhoneNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPhoneNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPhoneNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhoneNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtPhoneNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPhoneNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtPhoneNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPhoneNo.TextChanged

    End Sub

    Private Sub TXtFax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtFax.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtFax.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtFax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtFax.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtFax.TextChanged

    End Sub

    Private Sub TXtEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtEmail.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtEmail.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtEmail.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtEmail.TextChanged

    End Sub

    Private Sub TxtPanNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPanNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPanNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPanNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtPanNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPanNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtPanNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPanNo.TextChanged

    End Sub

    Private Sub TxtCStNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCStNO.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtCStNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCStNO.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtCStNO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCStNO.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCStNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCStNO.TextChanged

    End Sub

    Private Sub TXtLstNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtLstNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtLstNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtLstNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtLstNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtLstNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtLstNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtLstNo.TextChanged

    End Sub

    Private Sub TXtProfTaxNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtProfTaxNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtProfTaxNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtProfTaxNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtProfTaxNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtProfTaxNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtProfTaxNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtProfTaxNo.TextChanged

    End Sub

    Private Sub TxtFinancialYear_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFinancialYear.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtFinancialYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFinancialYear.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtFinancialYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFinancialYear.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtFinancialYear_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtFinancialYear.MaskInputRejected

    End Sub

    Private Sub TxtFinancialYear_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFinancialYear.Validated

    End Sub

    Private Sub txtStartDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartDate.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtStartDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartDate.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtStartDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartDate.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtStartDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtStartDate.MaskInputRejected

    End Sub

    Private Sub txtStartDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartDate.Validated
        ob.validdate(sender, txtStartDate.Text)
    End Sub

    Private Sub TxtEndDAte_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEndDAte.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtEndDAte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEndDAte.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtEndDAte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEndDAte.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtEndDAte_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtEndDAte.MaskInputRejected

    End Sub

    Private Sub TxtEndDAte_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEndDAte.Validated
        ob.validdate(sender, TxtEndDAte.Text)
    End Sub

    Private Sub TxtPrevReserDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevReserDate.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPrevReserDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrevReserDate.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtPrevReserDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevReserDate.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtPrevReserDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtPrevReserDate.MaskInputRejected

    End Sub

    Private Sub TxtPrevReserDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevReserDate.Validated
        ob.validdate(sender, TxtPrevReserDate.Text)
    End Sub

    Private Sub TxtreserveDate1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtreserveDate1.GotFocus, TXtReserveDate2.GotFocus, TxtReserveDAte3.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtreserveDate1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtreserveDate1.KeyPress, TXtReserveDate2.KeyPress, TxtReserveDAte3.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtreserveDate1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtreserveDate1.LostFocus, TXtReserveDate2.LostFocus, TxtReserveDAte3.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtreserveDate1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtreserveDate1.MaskInputRejected

    End Sub

    Private Sub TxtreserveDate1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtreserveDate1.Validated
        If ob.checkdate(TxtreserveDate1.Text) = False Then
            ob.validdate(sender, TxtreserveDate1.Text)
        End If
    End Sub

    Private Sub TXtReserveDate2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TXtReserveDate2.MaskInputRejected

    End Sub

    Private Sub TXtReserveDate2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtReserveDate2.Validated
        If ob.checkdate(TXtReserveDate2.Text) = False Then
            ob.validdate(sender, TXtReserveDate2.Text)
        End If
    End Sub

    Private Sub TxtReserveDAte3_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtReserveDAte3.MaskInputRejected

    End Sub

    Private Sub TxtReserveDAte3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReserveDAte3.Validated
        If ob.checkdate(TxtReserveDAte3.Text) = False Then
            ob.validdate(sender, TxtReserveDAte3.Text)
        End If
    End Sub

    Private Sub TxtPrevIntDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevIntDate.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPrevIntDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrevIntDate.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtPrevIntDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevIntDate.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtPrevIntDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtPrevIntDate.MaskInputRejected

    End Sub

    Private Sub TxtPrevIntDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrevIntDate.Validated
        ob.validdate(sender, TxtPrevIntDate.Text)
    End Sub

    Private Sub TxtCurrantIntDAte_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrantIntDAte.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtCurrantIntDAte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCurrantIntDAte.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtCurrantIntDAte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrantIntDAte.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCurrantIntDAte_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtCurrantIntDAte.MaskInputRejected

    End Sub

    Private Sub TxtCurrantIntDAte_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrantIntDAte.Validated
        ob.validdate(sender, TxtCurrantIntDAte.Text)
    End Sub

    Private Sub TxtInterestDays_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInterestDays.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtInterestDays_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInterestDays.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub TxtInterestDays_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInterestDays.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtInterestDays_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInterestDays.TextChanged

    End Sub

    Private Sub TxtlastReserveDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtlastReserveDate.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtlastReserveDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtlastReserveDate.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtlastReserveDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtlastReserveDate.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtlastReserveDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtlastReserveDate.MaskInputRejected

    End Sub

    Private Sub TxtlastReserveDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtlastReserveDate.Validated
        ob.validdate(sender, TxtlastReserveDate.Text)
    End Sub
    Public Sub AutoDocno()
        TxtCompanyid.Text = ob.FindOneString("Select isnull(max(Company_Id),0)+1 from Company", ob.getconnection(ob.Getconn))
    End Sub
    Public Sub cleartext()
        txtStartDate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TxtEndDAte.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TxtCompanyid.Clear()
        TxtCompanyName.Clear()
        TxtAddress.Clear()
        TXtCity.Clear()
        TxtCStNO.Clear()
        TxtCurrantIntDAte.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TXtEmail.Clear()
        TXtFax.Clear()
        TxtFinancialYear.Text = "    -"
        TxtInterestDays.Clear()
        TxtlastReserveDate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TXtLstNo.Clear()
        TxtMethodOfAc.Clear()
        TxtPanNo.Clear()
        TxtPhoneNo.Clear()
        TxtPrevIntDate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TxtPrevReserDate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        TXtProfTaxNo.Clear()
        TxtPropriter.Clear()
        TxtreserveDate1.Text = "  /  /"
        TXtReserveDate2.Text = "  /  /"
        TxtReserveDAte3.Text = "  /  /"
        TxtState.Clear()
    End Sub
    Public Sub butstyle1()
        ButAdd.Enabled = True
        ButEdit.Enabled = True
        ButDelete.Enabled = True
        ButSave.Enabled = False
        ButCAncel.Enabled = False
        ButFind.Enabled = True
        ButFirst.Enabled = True
        ButNExt.Enabled = True
        BUtPrev.Enabled = True
        ButLast.Enabled = True

        txtStartDate.Enabled = False
        TxtEndDAte.Enabled = False
        TxtCompanyid.Enabled = False
        TxtCompanyName.Enabled = False
        TxtAddress.Enabled = False
        TXtCity.Enabled = False
        TxtCStNO.Enabled = False
        TxtCurrantIntDAte.Enabled = False
        TXtEmail.Enabled = False
        TXtFax.Enabled = False
        TxtFinancialYear.Enabled = False
        TxtInterestDays.Enabled = False
        TxtlastReserveDate.Enabled = False
        TXtLstNo.Enabled = False
        TxtMethodOfAc.Enabled = False
        TxtPanNo.Enabled = False
        TxtPhoneNo.Enabled = False
        TxtPrevIntDate.Enabled = False
        TxtPrevReserDate.Enabled = False
        TXtProfTaxNo.Enabled = False
        TxtPropriter.Enabled = False
        TxtreserveDate1.Enabled = False
        TXtReserveDate2.Enabled = False
        TxtReserveDAte3.Enabled = False
        TxtState.Enabled = False
    End Sub
    Public Sub butstyle2()
        ButAdd.Enabled = False
        ButEdit.Enabled = False
        ButDelete.Enabled = False
        ButSave.Enabled = True
        ButCAncel.Enabled = True
        ButFind.Enabled = False
        ButFirst.Enabled = False
        ButNExt.Enabled = False
        BUtPrev.Enabled = False
        ButLast.Enabled = False


        txtStartDate.Enabled = True
        TxtEndDAte.Enabled = True
        TxtCompanyid.Enabled = True
        TxtCompanyName.Enabled = True
        TxtAddress.Enabled = True
        TXtCity.Enabled = True
        TxtCStNO.Enabled = True
        TxtCurrantIntDAte.Enabled = True
        TXtEmail.Enabled = True
        TXtFax.Enabled = True
        TxtFinancialYear.Enabled = True
        TxtInterestDays.Enabled = True
        TxtlastReserveDate.Enabled = True
        TXtLstNo.Enabled = True
        TxtMethodOfAc.Enabled = True
        TxtPanNo.Enabled = True
        TxtPhoneNo.Enabled = True
        TxtPrevIntDate.Enabled = True
        TxtPrevReserDate.Enabled = True
        TXtProfTaxNo.Enabled = True
        TxtPropriter.Enabled = True
        TxtreserveDate1.Enabled = True
        TXtReserveDate2.Enabled = True
        TxtReserveDAte3.Enabled = True
        TxtState.Enabled = True
    End Sub
    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        Try
            If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                butstyle1()
                messageright(AccessMode.AddMode)
                Exit Sub
            End If
            cleartext()
            ISadd = True
            butstyle2()
            AutoDocno()
            TxtCompanyid.Focus()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        Try
            If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.ChangeMode)
                butstyle1()
                Exit Sub
            End If
            If Val(TxtCompanyid.Text) = 0 Then
                MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK)
            Else
                ISadd = False
                butstyle2()
                TxtCompanyid.Enabled = False
                TxtCompanyName.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.DeleteMode)
                butstyle1()
                Exit Sub
            End If
            If Val(TxtCompanyid.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK)
            Else
                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from Company where Company_Id=" & Val(TxtCompanyid.Text), ob.getconnection(ob.Getconn()))
                    'ob.UpdateEditUser("Company", "Company_Id=" & Val(clsVariables.CompnyId), ob.getconnection(ob.Getconn(BackDbname)), True)
                    'MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
                    If Entry_Move("next") = False Then
                        If Entry_Move("prev") = False Then
                            cleartext()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Company "
                sql = sql & " Order by Company_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Company "
                sql = sql & " where company_id>" & Val(TxtCompanyid.Text)
                sql = sql & " Order by  Company_Id"
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Company "
                sql = sql & " where company_id<" & Val(TxtCompanyid.Text)
                sql = sql & " Order by  Company_Id  desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Company "
                sql = sql & " Order by  Company_Id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_Id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub filltext(ByVal Docno As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Company where Company_id=" & Val(Docno), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                TxtCompanyid.Text = IIf(IsDBNull(dt.Rows(0).Item("Company_id")), "", dt.Rows(0).Item("Company_id"))
                TxtCompanyName.Text = ob.IfNullThen(dt.Rows(0).Item("Company_name"), "")
                TxtPropriter.Text = ob.IfNullThen(dt.Rows(0).Item("Proprietor"), "")
                TxtMethodOfAc.Text = ob.IfNullThen(dt.Rows(0).Item("Method_of_Ac"), "")
                TxtAddress.Text = ob.IfNullThen(dt.Rows(0).Item("address"), "")
                TXtCity.Text = ob.IfNullThen(dt.Rows(0).Item("city"), "")
                TxtState.Text = ob.IfNullThen(dt.Rows(0).Item("state"), "")
                TxtPhoneNo.Text = ob.IfNullThen(dt.Rows(0).Item("phone"), "")
                TXtFax.Text = ob.IfNullThen(dt.Rows(0).Item("fax"), "")
                TXtEmail.Text = ob.IfNullThen(dt.Rows(0).Item("email"), "")
                TxtPanNo.Text = ob.IfNullThen(dt.Rows(0).Item("Pan_No"), "")
                TxtCStNO.Text = ob.IfNullThen(dt.Rows(0).Item("cst_no"), "")
                TXtLstNo.Text = ob.IfNullThen(dt.Rows(0).Item("Lst_no"), "")
                TXtProfTaxNo.Text = ob.IfNullThen(dt.Rows(0).Item("Prof_Tax_No"), "")
                If IsDBNull(dt.Rows(0).Item("fin_year_begin")) Then
                    txtStartDate.Text = "  /  /"
                Else
                    txtStartDate.Text = Format(CDate(dt.Rows(0).Item("fin_year_begin")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Fin_year_End")) Then
                    TxtEndDAte.Text = "  /  /"
                Else
                    TxtEndDAte.Text = Format(CDate(dt.Rows(0).Item("Fin_year_End")), "dd/MM/yyyy")
                End If
                TxtFinancialYear.Text = ob.IfNullThen(dt.Rows(0).Item("Financial_Year"), "")
                If IsDBNull(dt.Rows(0).Item("Previous_Reserve_Date")) Then
                    TxtPrevReserDate.Text = "  /  /"
                Else
                    TxtPrevReserDate.Text = Format(CDate(dt.Rows(0).Item("Previous_Reserve_Date")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Reserve1_date")) Then
                    TxtreserveDate1.Text = "  /  /"
                Else
                    TxtreserveDate1.Text = Format(CDate(dt.Rows(0).Item("Reserve1_date")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Reserve2_date")) Then
                    TXtReserveDate2.Text = "  /  /"
                Else
                    TXtReserveDate2.Text = Format(CDate(dt.Rows(0).Item("Reserve2_date")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Reserve3_date")) Then
                    TxtReserveDAte3.Text = "  /  /"
                Else
                    TxtReserveDAte3.Text = Format(CDate(dt.Rows(0).Item("Reserve3_date")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Previous_Interest_Date")) Then
                    TxtPrevIntDate.Text = "  /  /"
                Else
                    TxtPrevIntDate.Text = Format(CDate(dt.Rows(0).Item("Previous_Interest_Date")), "dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows(0).Item("Current_Interest_Date")) Then
                    TxtCurrantIntDAte.Text = "  /  /"
                Else
                    TxtCurrantIntDAte.Text = Format(CDate(dt.Rows(0).Item("Current_Interest_Date")), "dd/MM/yyyy")
                End If
                TxtInterestDays.Text = ob.IfNullThen(dt.Rows(0).Item("Interest_Days"), 0)
                If IsDBNull(dt.Rows(0).Item("Last_Reserve_Date")) Then
                    TxtlastReserveDate.Text = "  /  /"
                Else
                    TxtlastReserveDate.Text = Format(CDate(dt.Rows(0).Item("Last_Reserve_Date")), "dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        filltext(Val(TxtCompanyid.Text))
        ButAdd.Focus()
    End Sub
    Private Sub ButFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFirst.Click
        Entry_Move("first")
    End Sub

    Private Sub ButNExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButNExt.Click
        Entry_Move("next")
    End Sub

    Private Sub BUtPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtPrev.Click
        Entry_Move("prev")
    End Sub

    Private Sub ButLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLast.Click
        Entry_Move("last")
    End Sub

    Private Sub BuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuExit.Click
        Me.Close()
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Try
            If Val(TxtCompanyid.Text) = 0 Then
                MessageBox.Show("Please Enter Company Id", Application.ProductName, MessageBoxButtons.OK)
                TxtCompanyid.Focus()
                Exit Sub
            ElseIf Len(TxtCompanyName.Text) = 0 Then
                MessageBox.Show("Please Enter Company Name", Application.ProductName, MessageBoxButtons.OK)
                TxtCompanyName.Focus()
                Exit Sub
            Else
                If ISadd Then
q:
                    Ssql = "Select Count(*) from Company where Company_id=" & Val(TxtCompanyid.Text)
                    If ob.FindOneinteger(Ssql, ob.getconnection) > 0 Then
                        AutoDocno()
                    End If
                    Ssql = "Insert into Company("
                    Ssql = Ssql & " Company_Id, company_name, Proprietor, Method_of_Ac, address, city, state, phone, fax, email,"
                    Ssql = Ssql & " Pan_No, cst_no, Lst_no, Prof_Tax_No, fin_year_begin, "
                    Ssql = Ssql & " Fin_year_End, Financial_Year, Previous_Reserve_Date, Reserve1_date, Reserve2_date, Reserve3_date,"
                    Ssql = Ssql & " Previous_Interest_Date, Current_Interest_Date, "
                    Ssql = Ssql & " Interest_Days, Last_Reserve_Date, Dta_Dat, Dta_User,Ip_Address, Mach_Name,SMS_System ) values("
                    Ssql = Ssql & Val(TxtCompanyid.Text) & ","
                    Ssql = Ssql & aq(TxtCompanyName.Text) & ","
                    Ssql = Ssql & aq(TxtPropriter.Text) & ","
                    Ssql = Ssql & aq(TxtMethodOfAc.Text) & ","
                    Ssql = Ssql & aq(TxtAddress.Text) & ","
                    Ssql = Ssql & aq(TXtCity.Text) & ","
                    Ssql = Ssql & aq(TxtState.Text) & ","
                    Ssql = Ssql & aq(TxtPhoneNo.Text) & ","
                    Ssql = Ssql & aq(TXtFax.Text) & ","
                    Ssql = Ssql & aq(TXtEmail.Text) & ","
                    Ssql = Ssql & aq(TxtPanNo.Text) & ","
                    Ssql = Ssql & aq(TxtCStNO.Text) & ","
                    Ssql = Ssql & aq(TXtLstNo.Text) & ","
                    Ssql = Ssql & aq(TXtProfTaxNo.Text) & ","
                    If ob.checkdate(txtStartDate.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(txtStartDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtEndDAte.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtEndDAte.Text)) & ","
                    End If
                    Ssql = Ssql & aq(TxtFinancialYear.Text) & ","
                    If ob.checkdate(TxtPrevReserDate.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtPrevReserDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtreserveDate1.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtreserveDate1.Text)) & ","
                    End If
                    If ob.checkdate(TXtReserveDate2.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TXtReserveDate2.Text)) & ","
                    End If
                    If ob.checkdate(TxtReserveDAte3.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtReserveDAte3.Text)) & ","
                    End If
                    If ob.checkdate(TxtPrevIntDate.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtPrevIntDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtCurrantIntDAte.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtCurrantIntDAte.Text)) & ","
                    End If
                    Ssql = Ssql & Val(TxtInterestDays.Text) & ","
                    If ob.checkdate(TxtlastReserveDate.Text) = True Then
                        Ssql = Ssql & "Null,"
                    Else
                        Ssql = Ssql & aq(sFunction.DateConversion(TxtlastReserveDate.Text)) & ","
                    End If
                    Ssql = Ssql & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt")) & ","
                    Ssql = Ssql & aq(clsVariables.UserName) & ","
                    Ssql = Ssql & aq(IPAddress) & ","
                    Ssql = Ssql & aq(MachineName) & ","

                    If chkSMSSystem.Checked = True Then
                        Ssql = Ssql & "-1"
                    Else
                        Ssql = Ssql & "0"
                    End If
                    Ssql = Ssql & ")"
                    ob.Execute(Ssql, ob.getconnection)
                Else
                    Ssql = "Update Company set "
                    Ssql = Ssql & " company_name=" & aq(TxtCompanyName.Text) & ","
                    Ssql = Ssql & " Proprietor=" & aq(TxtPropriter.Text) & ","
                    Ssql = Ssql & " Method_of_Ac=" & aq(TxtMethodOfAc.Text) & ","
                    Ssql = Ssql & " address=" & aq(TxtAddress.Text) & ","
                    Ssql = Ssql & " city=" & aq(TXtCity.Text) & ","
                    Ssql = Ssql & " state=" & aq(TxtState.Text) & ","
                    Ssql = Ssql & " phone=" & aq(TxtPhoneNo.Text) & ","
                    Ssql = Ssql & " fax=" & aq(TXtFax.Text) & ","
                    Ssql = Ssql & " email=" & aq(TXtEmail.Text) & ","
                    Ssql = Ssql & " pAN_NO=" & aq(TxtPanNo.Text) & ","
                    Ssql = Ssql & " cST_NO=" & aq(TxtCStNO.Text) & ","
                    Ssql = Ssql & " Lst_no=" & aq(TXtLstNo.Text) & ","
                    Ssql = Ssql & " Prof_Tax_No=" & aq(TXtProfTaxNo.Text) & ","
                    If ob.checkdate(txtStartDate.Text) = True Then
                        Ssql = Ssql & " fin_year_begin=Null,"
                    Else
                        Ssql = Ssql & " fin_year_begin=" & aq(sFunction.DateConversion(txtStartDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtEndDAte.Text) = True Then
                        Ssql = Ssql & " Fin_year_End=Null,"
                    Else
                        Ssql = Ssql & " Fin_year_End=" & aq(sFunction.DateConversion(TxtEndDAte.Text)) & ","
                    End If
                    Ssql = Ssql & " Financial_Year=" & aq(TxtFinancialYear.Text) & ","
                    If ob.checkdate(TxtPrevReserDate.Text) = True Then
                        Ssql = Ssql & " Previous_Reserve_Date=Null,"
                    Else
                        Ssql = Ssql & " Previous_Reserve_Date=" & aq(sFunction.DateConversion(TxtPrevReserDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtreserveDate1.Text) = True Then
                        Ssql = Ssql & " Reserve1_date=Null,"
                    Else
                        Ssql = Ssql & " Reserve1_date=" & aq(sFunction.DateConversion(TxtreserveDate1.Text)) & ","
                    End If
                    If ob.checkdate(TXtReserveDate2.Text) = True Then
                        Ssql = Ssql & " Reserve2_date=Null,"
                    Else
                        Ssql = Ssql & " Reserve2_date=" & aq(sFunction.DateConversion(TXtReserveDate2.Text)) & ","
                    End If
                    If ob.checkdate(TxtReserveDAte3.Text) = True Then
                        Ssql = Ssql & " Reserve3_date=Null,"
                    Else
                        Ssql = Ssql & " Reserve3_date=" & aq(sFunction.DateConversion(TxtReserveDAte3.Text)) & ","
                    End If
                    If ob.checkdate(TxtPrevIntDate.Text) = True Then
                        Ssql = Ssql & " Previous_Interest_Date=Null,"
                    Else
                        Ssql = Ssql & " Previous_Interest_Date=" & aq(sFunction.DateConversion(TxtPrevIntDate.Text)) & ","
                    End If
                    If ob.checkdate(TxtCurrantIntDAte.Text) = True Then
                        Ssql = Ssql & " Current_Interest_Date=Null,"
                    Else
                        Ssql = Ssql & " Current_Interest_Date=" & aq(sFunction.DateConversion(TxtCurrantIntDAte.Text)) & ","
                    End If
                    Ssql = Ssql & " Interest_Days=" & Val(TxtInterestDays.Text) & ","
                    If ob.checkdate(TxtlastReserveDate.Text) = True Then
                        Ssql = Ssql & " Last_Reserve_Date=Null,"
                    Else
                        Ssql = Ssql & " Last_Reserve_Date=" & aq(sFunction.DateConversion(TxtlastReserveDate.Text)) & ","
                    End If
                    Ssql = Ssql & " Dta_Dat=" & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt")) & ","
                    Ssql = Ssql & " Dta_User=" & aq(clsVariables.UserName) & ","
                    Ssql = Ssql & " Ip_Address=" & aq(IPAddress) & ","
                    Ssql = Ssql & " MACH_nAME=" & aq(MachineName) & ","
                    If chkSMSSystem.Checked = True Then
                        Ssql = Ssql & " SMS_System = -1"
                    Else
                        Ssql = Ssql & " SMS_System = 0"
                    End If
                    Ssql = Ssql & " WHERE cOMPANY_ID=" & Val(TxtCompanyid.Text)
                    ob.Execute(Ssql, ob.getconnection)
                End If
                ButAdd_Click(e, e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtCompanyid_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyid.Validated
        Try
            If ob.FindOneinteger("Select Count(*) from Company where Company_id=" & Val(TxtCompanyid.Text), ob.getconnection(ob.Getconn)) > 0 Then
                If MessageBox.Show("Do You Want To Edit..?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    filltext(Val(TxtCompanyid.Text))
                    ButEdit_Click(e, e)
                Else
                    ButAdd_Click(e, e)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class