Imports System.Data.SqlClient

Imports WeightPavti.CLS

Module Comman
    'CHANGE 31/01/2015 PRAMOD
    Public FixdSYSTEM As Boolean
    Public SAVINGSYSTEM As Boolean
    Public SHARESYSTEM As Boolean
    'END
    Public gUserId As Integer
    Public cnn As New SqlConnection
    Public guser As String
    Public IPAddress As String
    Public MachineName As String
    Public ob As New AdoFunc
    Public servername As String
    Public dbname As String
    Public rptlocation As String
    Public ImagePath As String
    Public ImageAlign As String
    Public sysname As String
    Public RptApp As String
    Public Season_Id As String
    Public vrepstatus As Boolean
    Public objconnec As New clsConnection
    'Public gCSCnn As New SqlConnection
    Public objDataTrns As New clsDataTrans
    Public sVariables As New clsVariables
    Public sCommands As New clsCommands
    Public sFunction As New clsFunctions
    Public ObjAcces As New clsAccessSecurity
    Public DbAuth As String
    Public BackDbname As String
    Public OLDDbname As String
    Public rpttype As String = ""
    Public gCompanyId As Integer
    Public gCurrFinYear As Date
    Public gFinYearBegin As Date
    Public gFinYearEnd As Date
    Public gLastReserveDate As Date
    Public gWorkingYear As String
    Public vIsadmin As Boolean
    Public gCompany As String
    Public Searchtxt As String
    Public gbackUserName As String
    Public gbackAdddate As DateTime
    Public gDeptLoanName As String = "(r^fpZ rhcpN)"
    Public gDeptMemberName As String = "(i¡f rhcpN)"
    Public mRINTAMT, mRPANAMT, mRODINTAMT, mRODPANAMT, xPINTBAL, mODINTBAL, mODPANBAL, mDuePeriod As Double
    Public MemberBalId As Long
    Public MemebrBalExt As String
    Public MemebrColumnid As String
    Public MemberBalName As String
    Public Trns As String
    Public TrnsRep As String
    Public TrnsothRepledger As String
    Public TrnsothRepinterestreserve As String
    Public TrnsothRepmembal As String
    Public TrnsothRepbalint As String
    Public TrnsothRepintrev As String
    Public Const g2Dec = "###0.00"
    Public Const g3Dec = "###0.000"
    Public Const g0Dec = "###0"
    Public New_Entry As String = "New_Entry"
    Public delete_Entry As String = "Delete_Entry"
    Public vimagewindow As String
    Public sdepartment As String
    Public sDeptid As String
    Public Val1 As Integer
    Public Slab1 As String
    Public Slab2 As String
    Public Slab3 As String
    Public Slab4 As String
    Public Slab5 As String
    Public Slab6 As String
    Public fulluserName As String
    Public Const _decimal As Integer = 2

    'Public Vat_Account_id As Integer
    'Public Add_Vat_Account_id As Integer
    'Public Freight_Account_id As Integer
    'Public Oth_Account_id As Integer
    Public gClosing_Stock_Main As String = "Closing_Stock_Main"
    Public gClosing_Stock_Detail As String = "Closing_Stock_Detail"
    Public gAdd_Ded_Master As String = "Add_Ded_Master"
    Public gPT_Master As String = "PT_Master"
    Public BasedRate As String

    Public vSms_System As Boolean
    Public MsgSenderId As String
    Public MsguserID As String
    Public Msguserpass As String
    Public Sub OnTextChange(ByVal sender As Object, ByVal e As EventArgs)
        'Dim TLeft As String = ""
        'Dim TRight As String = sender.Text
        'Dim Dot As Integer = 0
        'Dim [Decimal] As Integer = _decimal
        'Dot = TRight.IndexOf(".") + 1
        'If Dot > 0 Then
        '    TLeft = TRight.Substring(0, Dot)
        '    TRight = TRight.Substring(Dot, TRight.Length - Dot)
        '    TRight = TRight.Substring(0, [Decimal])
        '    sender.Text = TLeft & TRight
        'End If
    End Sub
    Public Function upperChar(ByVal ch As Char) As Char
        Dim ch1 As Integer
        ch1 = Asc(ch)
        If (ch1 >= 97 And ch1 <= 122) Then
            ch1 = ch1 - 32
        End If
        Return Chr(ch1)
    End Function
    Public Function CurrencyFormate(ByVal sender As Object, ByVal NewCStyle As String, ByVal Value As String) As String
        If NewCStyle.ToString() = "None" Then
            Return Value
        End If
        Dim Result As String = ""
        Dim NewValue As String = ""
        Dim newSrtArr As String() = Value.Split("."c)
        Dim Points As String = ""
        If newSrtArr.Length > 1 Then
            Dim tempPoint As String() = newSrtArr(1).Split(","c)
            For i As Integer = 0 To tempPoint.Length - 1
                Points += tempPoint(i).ToString()
            Next
        End If
        Value = newSrtArr(0).ToString()
        Select Case NewCStyle.ToString()
            Case "1"
                NewValue = ManageComma(Value, 3)
                Exit Select
            Case "2"
                NewValue = ManageComma(Value, 2)
                Exit Select
        End Select
        'Result = NewPriFixSide.ToString() == "Left" ? NewCFormate.ToString() : "";
        Result += NewValue
        Result += If(newSrtArr.Length > 1, ".", "")
        Result += Points
        'Result += NewPriFixSide.ToString() == "Right" ? NewCFormate.ToString() : "";
        Return Result
    End Function
    Public Function ManageComma(ByVal ConvertStr As String, ByVal Place As Integer) As String
        Dim ProcessStr As String = ""
        Dim tempPro As String = ""
        Dim tempStr As String() = ConvertStr.Split(","c)
        For i As Integer = 0 To tempStr.Length - 1
            tempPro += tempStr(i).ToString()
        Next
        Dim fix As Integer = tempPro.Length - 3
        Dim Com As Integer = If(fix > 0, fix \ Place, 0)
        Dim Rest As Integer = tempPro.Length - ((Com * Place) + 3)
        If Rest > 0 Then
            ProcessStr += tempPro.Substring(0, Rest)
        End If
        ProcessStr += If(ProcessStr.Length > 0, ",", "")
        For j As Integer = 0 To Com - 1
            ProcessStr += tempPro.Substring(Rest, Place) + ","
            Rest += Place
        Next
        If fix > 0 Then
            ProcessStr += tempPro.Substring(fix, 3)
        Else
            ProcessStr += tempPro
        End If
        Return ProcessStr
    End Function
    Public Sub Numeric(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim BackDecimal As Integer = sender.Text.Length
        Dim Cursor As Integer = sender.SelectionStart
        Dim DPoin As Integer = sender.Text.IndexOf(".")
        Dim DifPoint As Integer = BackDecimal - DPoin
        If (Char.IsDigit(e.KeyChar)) Or e.KeyChar = "."c Then
            If _decimal > 0 Then
                If DPoin > 0 Then
                    If Cursor > DPoin Then
                        If _decimal < DifPoint Then
                            e.Handled = True
                        ElseIf e.KeyChar = "."c Then
                            e.Handled = True
                        End If
                    ElseIf DPoin > 0 Then
                        If e.KeyChar = "."c Then
                            e.Handled = True
                        End If
                    End If
                ElseIf DPoin = 0 Then
                    sender.Text = "0" + sender.Text
                    sender.SelectionStart = sender.Text.Length
                    If e.KeyChar = "."c Then
                        e.Handled = True
                    End If
                End If
            Else
                If e.KeyChar = "."c Then
                    e.Handled = True
                End If
            End If
        ElseIf e.KeyChar = "-"c Then
            If sender.Text.IndexOf("-"c) <> 0 Then
                sender.Text = "-" + sender.Text
            End If
            e.Handled = True
            'ElseIf e.KeyChar = CChar(Keys.Back) Then
        Else
            e.Handled = True
        End If
    End Sub
    Public Enum AccessMode
        AddMode
        ChangeMode
        DeleteMode
        ViewMode
    End Enum
    Public Function AddQuote(ByVal txt As String) As String
        Dim pos As Integer

        pos = InStr(1, txt, "'")
        Do While pos > 0
            txt = Left(txt, pos - 1) & "'" & Mid(txt, pos, Len(txt))
            pos = InStr(pos + 2, txt, "'")
        Loop
        AddQuote = txt
    End Function
    Public Sub messageright(ByVal mode As String)
        Select Case mode
            Case AccessMode.AddMode
                MsgBox("Sorry. You don't have rights to add information in this form.", vbInformation, Application.ProductName)
            Case AccessMode.ChangeMode
                MsgBox("Sorry. You don't have rights to change information in this form.", vbInformation, Application.ProductName)
            Case AccessMode.DeleteMode
                MsgBox("Sorry. You don't have rights to remove information from this form.", vbInformation, Application.ProductName)
            Case AccessMode.ViewMode
                MsgBox("Sorry. You don't have rights for this form.", vbInformation, Application.ProductName)
        End Select
    End Sub

    Public Function CheckNumeric(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) As Boolean
        If Len(sender.Text) > 0 Then
            If IsNumeric(sender.text) = False Then
                MessageBox.Show("Invalid Format", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckNumeric = False
                e.Cancel = True
            Else
                CheckNumeric = True
            End If
        Else
            CheckNumeric = True
        End If
    End Function
    Public Function CheckNumerictext(ByVal text As TextBox) As Boolean
        If Len(text.Text) > 0 Then
            If IsNumeric(text.Text) = False Then
                MessageBox.Show("Invalid Format", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckNumerictext = False

            Else
                CheckNumerictext = True
            End If
        Else
            CheckNumerictext = True
        End If
    End Function
    Public Sub tabkey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        qute(sender, e)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Public Sub tabkey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Public Sub qute(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Public Sub Digit(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            e.Handled = True
        End If
    End Sub
    Public Sub Amount(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = "." Or Asc(e.KeyChar) = 8) Then
            e.Handled = True
        End If
    End Sub
    Public Sub Textactive(ByVal sender As Object)
        sender.BackColor = Color.LightCyan
        If (sender.GetType.ToString) = "System.Windows.Forms.MaskedTextBox" Then
            sender.SelectionStart = 0
            sender.SelectionLength = Len(sender.Text)
        End If
    End Sub
    Public Sub Textactiveg(ByVal sender As Object)
        sender.BackColor = Color.LightCyan
        'sender.SelectionStart = 0
        'sender.SelectionLength = 0
    End Sub
    Public Sub Textreset(ByVal sender As Object)
        sender.BackColor = Color.White
    End Sub
    Public Function aq(ByVal str As String, Optional ByVal qut As String = "'") As String
        Dim sql As String
        sql = qut & AddQuote(str) & qut
        Return sql
    End Function
    Public Function PadString(ByVal str As String, ByVal length As Integer, ByVal sbeforetxt As Boolean, Optional ByVal qut As String = "'") As String
        Dim sql As String = ""
        Dim j As Integer
        If Len(str) < length Then
            For j = 1 To length - Len(str)
                sql = sql & qut
            Next
        End If
        If sbeforetxt Then
            PadString = sql & str
        Else
            PadString = str & sql
        End If
        Return PadString
    End Function
End Module
