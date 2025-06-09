Imports WeightPavti.CLS
Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Xml.Schema

Namespace CLS
    Public Class clsFunctions

        Inherits clsVariables
        Dim sCommands As clsCommands = New clsCommands()
        Dim sVariables As clsVariables = New clsVariables()
        Dim sDataTrans As New clsDataTrans
        Dim objDataTrns As New clsDataTrans

        Dim unit_arr(0 To 9) As String
        Dim tens_arr(0 To 8) As String
        Dim more_tens(0 To 8) As String
        Dim more_arr(0 To 3) As String
        '
        Dim guj_hundred_arr(0 To 9) As String
        Dim guj_unit_arr(0 To 99) As String


        Public Shared dOdInterest As Double

        Public Shared dIntAmt As Double
        Public Shared dODIntAmt As Double

        Public Sub setsqlConnCommand_Open(ByVal sCommand As SqlCommand)

            '  sCommand.Connection = sDataTrans.cn
            clsVariables.sqlConnection.Open()
            sCommand.Connection = sDataTrans.cn

        End Sub
        Public Sub setsqlConnCommand_Close(ByVal sCommand As SqlCommand)
            sCommand.ExecuteNonQuery()
            sCommand.Parameters.Clear()
            ' sCommand.Connection.Close()
            ' clsVariables.sqlConnection.Close()
        End Sub
        Public Sub setDropDownList(ByVal scmdBox As ComboBox, ByVal sSQL As String, ByVal sTable As String, ByVal sFieldName As String, ByVal vFieldName As String)
            Dim sDataSet As DataSet = New DataSet()
            Dim sSqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()

            Try
                sCommands.setsqlCommand(sDataSet, sSqlDataAdapter, sSQL, sTable)
                scmdBox.DataSource = sDataSet.Tables(0).DefaultView
                scmdBox.DisplayMember = sFieldName
                scmdBox.ValueMember = vFieldName
                scmdBox.SelectedIndex = 0
                sCommands.setCommandDatasetClose(sDataSet, sSqlDataAdapter)
            Catch ex As Exception
                sCommands.setCommandDatasetClose(sDataSet, sSqlDataAdapter)
            End Try
        End Sub
        Public Function DateConversion(ByVal sDate As String) As String
            'sDate = Mid(sDate, 4, 2) & "/" & Mid(sDate, 1, 2) & "/" & Mid(sDate, 7, 4)
            'Return sDate

            If Len(Trim(sDate)) = 10 Then
                sDate = (Mid(sDate, 4, 2) & "/" & Mid(sDate, 1, 2) & "/" & Mid(sDate, 7, 4))
            ElseIf Len(Trim(sDate)) > 10 Then
                sDate = (Mid(sDate, 4, 2) & "/" & Mid(sDate, 1, 2) & "/" & Mid(sDate, 7, 4))
            ElseIf Len(Trim(sDate)) = 9 Then
                If Mid(sDate, 2, 1) = "/" Then
                    sDate = (Mid(sDate, 3, 2) & "/" & Mid(sDate, 1, 1) & "/" & Mid(sDate, 6, 4))
                Else
                    sDate = (Mid(sDate, 4, 1) & "/" & Mid(sDate, 1, 2) & "/" & Mid(sDate, 6, 4))
                End If
            ElseIf Len(Trim(sDate)) = 8 Then
                sDate = (Mid(sDate, 3, 1) & "/" & Mid(sDate, 1, 1) & "/" & Mid(sDate, 5, 4))
            End If
            Return sDate
        End Function
        Public Sub Selection(ByVal txtbox As TextBox)
            txtbox.SelectionStart = 0
            txtbox.SelectionLength = Len(txtbox.Text)
        End Sub
        Public Function Num_To_Guj_Word(ByVal dFigure As Double) As String
            Dim temp_str3 As String

            Dim length As Integer
            Dim temp_len As Integer
            Dim temp_text As String
            Dim dec_pos As Integer
            Dim sAmount As String
            Dim dPaisa As Integer
            Dim sPaisa As String
            Dim sRupiya As String

            sPaisa = ""
            sRupiya = ""

            guj_unit_arr(0) = "શુન્ય"
            guj_unit_arr(1) = "એક"
            guj_unit_arr(2) = "બે"
            guj_unit_arr(3) = "ત્રણ"
            guj_unit_arr(4) = "ચાર"
            guj_unit_arr(5) = "પાંચ"
            guj_unit_arr(6) = "છ"
            guj_unit_arr(7) = "સાત"
            guj_unit_arr(8) = "આંઠ"
            guj_unit_arr(9) = "નવ"
            guj_unit_arr(10) = "દસ"

            guj_unit_arr(11) = "અગીયાર"
            guj_unit_arr(12) = "બાર"
            guj_unit_arr(13) = "તેર"
            guj_unit_arr(14) = "ચઊદ"
            guj_unit_arr(15) = "પંદર"
            guj_unit_arr(16) = "સોળ"
            guj_unit_arr(17) = "સત્તર"
            guj_unit_arr(18) = "અઢાર"
            guj_unit_arr(19) = "ઓગણીસ"
            guj_unit_arr(20) = "વીસ"

            guj_unit_arr(21) = "એકવીસ"
            guj_unit_arr(22) = "બાવીસ"
            guj_unit_arr(23) = "ત્રેવીસ"
            guj_unit_arr(24) = "ચોવીસ"
            guj_unit_arr(25) = "પચ્ચીસ"
            guj_unit_arr(26) = "છવ્વીસ"
            guj_unit_arr(27) = "સત્તવીસ"
            guj_unit_arr(28) = "અટ્ઠાવીસ"
            guj_unit_arr(29) = "ઓગણત્રીસ"
            guj_unit_arr(30) = "ત્રીસ"

            guj_unit_arr(31) = "એકત્રીસ"
            guj_unit_arr(32) = "બત્રીસ"
            guj_unit_arr(33) = "તેત્રીસ"
            guj_unit_arr(34) = "ચોત્રીસ"
            guj_unit_arr(35) = "પાત્રીસ"
            guj_unit_arr(36) = "છત્રીસ"
            guj_unit_arr(37) = "સાડત્રીસ"
            guj_unit_arr(38) = "આડત્રીસ"
            guj_unit_arr(39) = "ઓગણચાલીસ"
            guj_unit_arr(40) = "ચાલીસ"

            guj_unit_arr(41) = "એકતાલીસ"
            guj_unit_arr(42) = "બેતાલીસ"
            guj_unit_arr(43) = "તેતાલીસા"
            guj_unit_arr(44) = "ચુમ્મલીસ"
            guj_unit_arr(45) = "પીસ્તળીસ"
            guj_unit_arr(46) = "છેતાળીસ"
            guj_unit_arr(47) = "સુડતાળીસ"
            guj_unit_arr(48) = "અડતાળીસ"
            guj_unit_arr(49) = "ઑગણપચાસ"
            guj_unit_arr(50) = "પચાસ"

            guj_unit_arr(51) = "એકાવન"
            guj_unit_arr(52) = "બાવન"
            guj_unit_arr(53) = "ત્રેપન"
            guj_unit_arr(54) = "ચોપન"
            guj_unit_arr(55) = "પંચાવન"
            guj_unit_arr(56) = "છપ્પન"
            guj_unit_arr(57) = "સત્તાવન"
            guj_unit_arr(58) = "અટ્ઠાવન"
            guj_unit_arr(59) = "ઓગણસાંઇઠ"
            guj_unit_arr(60) = "સાંઇઠ"

            guj_unit_arr(61) = "એક્સઠ"
            guj_unit_arr(62) = "બાંસઠ"
            guj_unit_arr(63) = "ત્રેસઠ"
            guj_unit_arr(64) = "ચોસઠ"
            guj_unit_arr(65) = "પાંસઠ"
            guj_unit_arr(66) = "છાંસઠ"
            guj_unit_arr(67) = "સડસઠ"
            guj_unit_arr(68) = "અડસઠ"
            guj_unit_arr(69) = "ઓગણસીત્તેર"
            guj_unit_arr(70) = "સીત્તેર"

            guj_unit_arr(71) = "એકોતેર"
            guj_unit_arr(72) = "બોત્તેર"
            guj_unit_arr(73) = "તોતેર"
            guj_unit_arr(74) = "ચુમ્મોતેર"
            guj_unit_arr(75) = "પંચોતેર"
            guj_unit_arr(76) = "છોત્તેર"
            guj_unit_arr(77) = "સીત્તોતેર"
            guj_unit_arr(78) = "ઇઠ્યોતેર"
            guj_unit_arr(79) = "ઓગણાએંસી"
            guj_unit_arr(80) = "એંસી"

            guj_unit_arr(81) = "એક્યાંસી"
            guj_unit_arr(82) = "બ્યાંસી"
            guj_unit_arr(83) = "ત્યાંસી"
            guj_unit_arr(84) = "ચોર્યાંસી"
            guj_unit_arr(85) = "પંચ્યાસી"
            guj_unit_arr(86) = "છીંયાસી"
            guj_unit_arr(87) = "સત્યાંસી"
            guj_unit_arr(88) = "ઇઠ્યાંસી"
            guj_unit_arr(89) = "નેવ્યાંસી"
            guj_unit_arr(90) = "નેવુ"

            guj_unit_arr(91) = "એકાણુ"
            guj_unit_arr(92) = "બાણુ"
            guj_unit_arr(93) = "ત્રાણુ"
            guj_unit_arr(94) = "ચોરાણુ"
            guj_unit_arr(95) = "પંચાણુ"
            guj_unit_arr(96) = "છન્નુ"
            guj_unit_arr(97) = "સત્તણુ"
            guj_unit_arr(98) = "અટ્ઠાણુ"
            guj_unit_arr(99) = "નવ્વણુ"

            guj_hundred_arr(1) = "એકસો"
            guj_hundred_arr(2) = "બસો"
            guj_hundred_arr(3) = "ત્રણસો"
            guj_hundred_arr(4) = "ચારસો"
            guj_hundred_arr(5) = "પાંચસો"
            guj_hundred_arr(6) = "છસો"
            guj_hundred_arr(7) = "સાતસો"
            guj_hundred_arr(8) = "આંઠસો"
            guj_hundred_arr(9) = "નવસો"



            '*-*-*-*-*-*-*-*-

            If dFigure >= 0 Then
                sAmount = Format(dFigure, "0.00")
                dec_pos = InStr(1, sAmount, ".", 1)
                If Not dec_pos = 0 And Not Val(sAmount) = 0 Then
                    temp_text = Left$(sAmount, (dec_pos - 1))
                    temp_str3 = Right$(sAmount, Len(sAmount) - dec_pos)
                Else
                    temp_text = sAmount
                    temp_str3 = ""
                End If
                dPaisa = (dFigure - Val(temp_text)) * 100
                If dPaisa > 0 Then
                    sPaisa = guj_unit_arr(dPaisa)
                Else
                    sPaisa = ""
                End If

                length = Len(temp_text)
                temp_len = length
                If length = 10 Then
                    sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 1))) & " અબજ "
                    If Val(Mid(temp_text, 2, 2)) > 0 Then
                        If Len(sRupiya) > 0 Then
                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 2, 2))) & " કરોડ "
                        End If
                    End If
                    If Val(Mid(temp_text, 4, 2)) > 0 Then
                        If Len(sRupiya) > 0 Then
                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 4, 2))) & " લાખ "
                        End If
                    End If
                    If Val(Mid(temp_text, 6, 2)) > 0 Then
                        If Len(sRupiya) > 0 Then
                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 6, 2))) & " હજાર "
                        End If
                    End If
                    If Val(Mid(temp_text, 8, 1)) > 0 Then
                        If Len(sRupiya) > 0 Then
                            sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 8, 1))) & " "
                        End If
                    End If
                    If Val(Mid(temp_text, 9, 2)) > 0 Then
                        If Len(sRupiya) > 0 Then
                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 9, 2)))
                        End If
                    End If
                Else
                    If length = 9 Then
                        sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 2))) & " કરોડ "
                        If Val(Mid(temp_text, 3, 2)) > 0 Then
                            If Len(sRupiya) > 0 Then
                                sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 3, 2))) & " લાખ "
                            End If
                        End If
                        If Val(Mid(temp_text, 5, 2)) > 0 Then
                            If Len(sRupiya) > 0 Then
                                sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 5, 2))) & " હજાર "
                            End If
                        End If
                        If Val(Mid(temp_text, 7, 1)) > 0 Then
                            If Len(sRupiya) > 0 Then
                                sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 7, 1))) & " "
                            End If
                        End If
                        If Val(Mid(temp_text, 8, 2)) > 0 Then
                            If Len(sRupiya) > 0 Then
                                sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 8, 2)))
                            End If
                        End If
                    Else
                        If length = 8 Then
                            sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 1))) & " કરોડ "
                            If Val(Mid(temp_text, 2, 2)) > 0 Then
                                If Len(sRupiya) > 0 Then
                                    sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 2, 2))) & " લાખ "
                                End If
                            End If
                            If Val(Mid(temp_text, 4, 2)) > 0 Then
                                If Len(sRupiya) > 0 Then
                                    sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 4, 2))) & " હજાર "
                                End If
                            End If
                            If Val(Mid(temp_text, 6, 1)) > 0 Then
                                If Len(sRupiya) > 0 Then
                                    sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 6, 1))) & " "
                                End If
                            End If
                            If Val(Mid(temp_text, 7, 2)) > 0 Then
                                If Len(sRupiya) > 0 Then
                                    sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 7, 2)))
                                End If
                            End If
                        Else
                            If length = 7 Then
                                sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 2))) & " લાખ "
                                If Val(Mid(temp_text, 3, 2)) > 0 Then
                                    If Len(sRupiya) > 0 Then
                                        sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 3, 2))) & " હજાર "
                                    End If
                                End If
                                If Val(Mid(temp_text, 5, 1)) > 0 Then
                                    If Len(sRupiya) > 0 Then
                                        sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 5, 1))) & " "
                                    End If
                                End If
                                If Val(Mid(temp_text, 6, 2)) > 0 Then
                                    If Len(sRupiya) > 0 Then
                                        sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 6, 2)))
                                    End If
                                End If
                            Else
                                If length = 6 Then
                                    sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 1))) & " લાખ "
                                    If Val(Mid(temp_text, 2, 2)) > 0 Then
                                        If Len(sRupiya) > 0 Then
                                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 2, 2))) & " હજાર "
                                        End If
                                    End If
                                    If Val(Mid(temp_text, 4, 1)) > 0 Then
                                        If Len(sRupiya) > 0 Then
                                            sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 4, 1))) & " "
                                        End If
                                    End If
                                    If Val(Mid(temp_text, 5, 2)) > 0 Then
                                        If Len(sRupiya) > 0 Then
                                            sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 5, 2)))
                                        End If
                                    End If
                                Else
                                    If length = 5 Then
                                        sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 2))) & " હજાર "
                                        If Val(Mid(temp_text, 3, 1)) > 0 Then
                                            If Len(sRupiya) > 0 Then
                                                sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 3, 1))) & " "
                                            End If
                                        End If
                                        If Val(Mid(temp_text, 4, 2)) > 0 Then
                                            If Len(sRupiya) > 0 Then
                                                sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 4, 2)))
                                            End If
                                        End If
                                    Else
                                        If length = 4 Then
                                            sRupiya = guj_unit_arr(Val(Mid(temp_text, 1, 1))) & " હજાર "
                                            If Val(Mid(temp_text, 2, 1)) > 0 Then
                                                If Len(sRupiya) > 0 Then
                                                    sRupiya = sRupiya & guj_hundred_arr(Val(Mid(temp_text, 2, 1))) & " "
                                                End If
                                            End If
                                            If Val(Mid(temp_text, 3, 2)) > 0 Then
                                                If Len(sRupiya) > 0 Then
                                                    sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 3, 2)))
                                                End If
                                            End If
                                        Else
                                            If length = 3 Then
                                                sRupiya = guj_hundred_arr(Val(Mid(temp_text, 1, 1))) & " "
                                                If Val(Mid(temp_text, 2, 2)) > 0 Then
                                                    If Len(sRupiya) > 0 Then
                                                        sRupiya = sRupiya & guj_unit_arr(Val(Mid(temp_text, 2, 2)))
                                                    End If
                                                End If
                                            Else
                                                If length > 0 Then
                                                    sRupiya = guj_unit_arr(Val(temp_text))
                                                Else
                                                    Num_To_Guj_Word = ""
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If Len(Trim(sPaisa)) > 0 Then
                Num_To_Guj_Word = "અંકે રૂપિયા  " & sRupiya & " અને  " & sPaisa & " પૈસા પુરા."
            Else
                Num_To_Guj_Word = "અંકે રૂપિયા  " & sRupiya & " પુરા."
            End If
            Return Num_To_Guj_Word
        End Function
        Public Function Num_To_Word(ByVal dFigure As Double) As String
            Dim temp_Str1, temp_str2, temp_str3 As String
            Dim i As Integer
            Dim length As Integer
            Dim temp_len As Integer
            Dim temp_text As String
            Dim dec_pos As Integer
            Dim sAmount As String
            temp_Str1 = ""
            temp_str3 = ""
            Num_To_Word = ""

            unit_arr(0) = "Zero"
            unit_arr(1) = "One"
            unit_arr(2) = "Two"
            unit_arr(3) = "Three"
            unit_arr(4) = "Four"
            unit_arr(5) = "Five"
            unit_arr(6) = "Six"
            unit_arr(7) = "Seven"
            unit_arr(8) = "Eight"
            unit_arr(9) = "Nine"

            tens_arr(0) = "Eleven"
            tens_arr(1) = "Twelve"
            tens_arr(2) = "Thirteen"
            tens_arr(3) = "Fourteen"
            tens_arr(4) = "Fifteen"
            tens_arr(5) = "Sixteen"
            tens_arr(6) = "Seventeen"
            tens_arr(7) = "Eighteen"
            tens_arr(8) = "Ninteen"

            more_tens(0) = "Ten"
            more_tens(1) = "Twenty"
            more_tens(2) = "Thirty"
            more_tens(3) = "Forty"
            more_tens(4) = "Fifty"
            more_tens(5) = "Sixty"
            more_tens(6) = "Seventy"
            more_tens(7) = "Eighty"
            more_tens(8) = "Ninty"

            more_arr(0) = "Hundred"
            more_arr(1) = "Thousand"
            more_arr(2) = "Lakh"
            more_arr(3) = "Crore"

            If dFigure >= 0 Then
                sAmount = Format(dFigure, "0.00")
                dec_pos = InStr(1, sAmount, ".", 1)
                If Not dec_pos = 0 And Not Val(sAmount) = 0 Then
                    temp_text = Left$(sAmount, (dec_pos - 1))
                    temp_str3 = Right$(sAmount, Len(sAmount) - dec_pos)
                Else
                    temp_text = sAmount
                    temp_str3 = ""
                End If

                length = Len(temp_text)
                temp_len = length
                If length >= 3 Then
                    temp_Str1 = Convert_First_Three_Digits(Right$(temp_text, 3))
                    temp_len = temp_len - 3
                    temp_text = Left$(temp_text, temp_len)
                Else
                    temp_Str1 = Convert_First_Three_Digits(Right$(temp_text, temp_len))
                    temp_len = 0
                End If
                i = 1
                While (temp_len > 0)
                    If temp_len >= 2 Then
                        temp_str2 = Convert_First_Three_Digits(Right$(temp_text, 2))
                        temp_len = temp_len - 2
                        temp_text = Left$(temp_text, temp_len)
                    Else
                        temp_str2 = Convert_First_Three_Digits(Right$(temp_text, temp_len))
                        temp_len = 0
                    End If
                    temp_Str1 = temp_str2 + " " + more_arr(i) + " " + temp_Str1
                    i = i + 1
                End While
                If Not (temp_str3 = "") And Not (Val(temp_str3) = 0) Then
                    temp_str3 = Convert_First_Three_Digits(temp_str3)
                Else
                    temp_str3 = ""
                End If
            Else
                If dFigure = 0 Then
                    temp_Str1 = "Zero"
                Else
                    MsgBox("Amount out of range.", vbInformation)
                End If
            End If

            If Not Len(Trim(temp_Str1)) = 0 Then
                Num_To_Word = temp_Str1 + " "
            End If
            If Not Len(Trim(temp_str3)) = 0 Then
                Num_To_Word = Num_To_Word + " And Paise" + " " + temp_str3 + " "
            End If
            Num_To_Word = Num_To_Word + "Only."
            Return Num_To_Word
        End Function
        Private Function Convert_First_Three_Digits(ByVal num_str As String) As String
            Dim temp_str As String
            Dim digit1, digit2, digit3 As Integer

            digit1 = 0
            digit2 = 0
            digit3 = 0
            temp_str = ""

            If Len(num_str) = 3 Then
                digit1 = Val(Right$(num_str, 1))
                digit2 = Val(Mid$(num_str, 2, 1))
                digit3 = Val(Left$(num_str, 1))
            Else
                If Len(num_str) = 2 Then
                    digit1 = Val(Right$(num_str, 1))
                    digit2 = Val(Left$(num_str, 1))
                Else
                    digit1 = Val(num_str)
                End If
            End If

            If digit1 = 0 And (digit2 >= 1 And digit2 <= 9) Then
                temp_str = more_tens(digit2 - 1)
            Else
                If digit1 >= 1 And digit2 = 1 Then
                    temp_str = tens_arr(digit1 - 1)
                Else
                    If (digit1 >= 1 And digit1 <= 9) And (digit2 >= 2 And digit2 <= 9) Then
                        temp_str = more_tens(digit2 - 1) + " " + unit_arr(digit1)
                    Else
                        temp_str = unit_arr(digit1)
                    End If
                End If
            End If

            If Not digit3 = 0 Then
                If StrComp(temp_str, "Zero", 1) = 0 Then
                    temp_str = unit_arr(digit3) + " " + more_arr(0)
                Else
                    temp_str = unit_arr(digit3) + " " + more_arr(0) + " " + temp_str
                End If
            End If

            Convert_First_Three_Digits = temp_str

        End Function
        Public Function Calc_Pak_Loan_Member_Balance(ByVal iacid As Integer, ByVal icolid As Integer) As Double
            Dim dbal As Double = 0
            Dim sSql As String
            Dim ds As New DataSet

            Try

                objconnec.GetConnection()
                objDataTrns.OpenCn()
                ds.Tables.Clear()

                dbal = 0

                sSql = "select SUM(Dr_Opening-Cr_Opening) as total from Pak_Loan_Opening_Data where Year_Id = " & aq(clsVariables.WorkingYear) & " and Member_Id = " & iacid & " and Column_id=" & icolid & ""
                sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, sSql, "Payment_data")
                Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
                dbal = dbal + Val(sDataRow("total").ToString())

                ds.Tables.Clear()
                sSql = "select SUM(Doc_Amt) as total from Pak_Loan_Payment_Data where Year_Id = " & aq(clsVariables.WorkingYear) & " and Member_Id = " & iacid & " and Column_id=" & icolid & ""
                sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, sSql, "Payment_data")
                Dim sDataRow1 As DataRow = ds.Tables(0).Rows(0)
                dbal = dbal + Val(sDataRow1("total").ToString())

                ds.Tables.Clear()
                sSql = "select SUM(Doc_Amt) as total from Pak_Loan_Receipt_Data where Year_Id = " & aq(clsVariables.WorkingYear) & " and Member_Id=" & iacid & " and Column_id=" & icolid & ""
                sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, sSql, "Receipt_Data")
                Dim sDataRow2 As DataRow = ds.Tables(0).Rows(0)
                dbal = dbal - Val(sDataRow2("total").ToString())

            Catch ex As Exception
                sCommands.setCloseCommand()
            End Try
            Calc_Pak_Loan_Member_Balance = dbal

        End Function
        Public Function Pak_Loan_Calc_Interest(ByVal iMemberId As Long, ByVal iColumnId As Integer, ByVal sDocDate As Date) As Double
            Dim sSQL As String
            Dim rst As New DataTable

            Dim sRST As New DataTable
            Dim isSQL As String
            Dim iRST As New DataTable

            Dim aSQL As String
            Dim aRST As New DataTable

            Dim cRst As New DataTable

            Dim dDebitSum As Double
            Dim dCreditSum As Double
            Dim dDebitIntSum As Double
            Dim dCreditIntSum As Double

            Dim dDebitODIntSum As Double
            Dim dCreditODIntSum As Double

            Dim dRunningBalance As Double
            Dim dRunningIntBalance As Double
            Dim dRunningODIntBalance As Double

            Dim dODDate As Date

            Dim dInterest As Double

            Try
                Dim gAccountLedgerInt As String = "PAK_LOAN_MEMBER_LEDGER_INT"
                Dim gInterestData As String = "PAK_LOAN_INTEREST_DATA"

                Dim gAccountOpeningBalance As String = "PAK_LOAN_OPENING_DATA"
                Dim gPaymentData As String = "PAK_LOAN_PAYMENT_DATA"
                Dim gReceiptData As String = "PAK_LOAN_RECEIPT_DATA"
                Dim gPakDhiranPassingData As String = "PAK_LOAN_PASSING_DATA"

                Dim gInterestDateData As String = "PAK_LOAN_INTEREST_DATE_DATA"

                dOdInterest = 0
                'Member Opening Data
                If iColumnId = 16 Then
                    dOdInterest = 0
                End If
                sSQL = "SELECT (dr_opening - cr_opening) as Amount,(dr_int_opening - cr_int_opening) as Interest,(dr_OD_int_opening - cr_OD_int_opening) as OD_Interest FROM " & gAccountOpeningBalance & " WHERE company_id = " & clsVariables.CompnyId & " and Year_Id = " & aq(clsVariables.WorkingYear) & " AND Member_ID = " & iMemberId
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                rst = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))

                dDebitSum = 0
                dCreditSum = 0
                dRunningBalance = 0
                dRunningIntBalance = 0
                dRunningODIntBalance = 0
                dCreditIntSum = 0
                dDebitIntSum = 0
                dCreditODIntSum = 0
                dDebitODIntSum = 0

                Dim iRow As Integer

                iRow = 0
                Do While iRow < rst.Rows.Count
                    If Not IsDBNull(rst.Rows(iRow).Item("Amount")) Then
                        If rst.Rows(iRow).Item("Amount") <> 0 Then
                            If rst.Rows(iRow).Item("Amount") > 0 Then
                                dDebitSum = rst.Rows(iRow).Item("Amount")
                            Else
                                dCreditSum = Math.Abs(rst.Rows(iRow).Item("Amount"))
                            End If
                        End If
                        dRunningBalance = dRunningBalance + rst.Rows(iRow).Item("Amount")
                    End If

                    If Not IsDBNull(rst.Rows(iRow).Item("Interest")) Then
                        If rst.Rows(iRow).Item("Interest") <> 0 Then
                            If rst.Rows(iRow).Item("Interest") > 0 Then
                                dDebitIntSum = rst.Rows(iRow).Item("Interest")
                            Else
                                dCreditIntSum = Math.Abs(rst.Rows(iRow).Item("Interest"))
                            End If
                        End If
                        dRunningIntBalance = dRunningIntBalance + rst.Rows(iRow).Item("Interest")
                    End If
                    If Not IsDBNull(rst.Rows(iRow).Item("OD_Interest")) Then
                        If rst.Rows(iRow).Item("OD_Interest") <> 0 Then
                            If rst.Rows(iRow).Item("OD_Interest") > 0 Then
                                dDebitODIntSum = rst.Rows(iRow).Item("Interest")
                            Else
                                dCreditODIntSum = Math.Abs(rst.Rows(iRow).Item("Interest"))
                            End If
                        End If
                        dRunningODIntBalance = dRunningODIntBalance + rst.Rows(iRow).Item("OD_Interest")
                    End If

                    iRow = iRow + 1
                Loop
                rst.Clear()
                rst.Dispose()

                If dRunningBalance <> 0 Then

                    sSQL = "INSERT INTO " & gAccountLedgerInt & " (Company_Id, IP_Address, Member_Id, Column_Id, Doc_Date, Year_Id, Doc_Type, Doc_No, Remarks, Credit_Amt, Debit_Amt, Rec_Int, Pay_Int,Rec_OD_Int, Pay_OD_Int)"
                    sSQL = sSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & iMemberId & "," & iColumnId & "," & aq(sFunction.DateConversion(gFinYearBegin)) & "," & aq(clsVariables.WorkingYear) & ",0,0,'M~Delvr yekr'"
                    If dRunningBalance > 0 Then
                        sSQL = sSQL & ",0," & dRunningBalance & ""
                    Else
                        sSQL = sSQL & "," & Math.Abs(dRunningBalance) & ",0"
                    End If
                    If dRunningIntBalance > 0 Then
                        sSQL = sSQL & ",0," & dRunningIntBalance & ""
                    Else
                        sSQL = sSQL & "," & Math.Abs(dRunningIntBalance) & ",0"
                    End If
                    If dRunningODIntBalance > 0 Then
                        sSQL = sSQL & ",0," & dRunningODIntBalance & ""
                    Else
                        sSQL = sSQL & "," & Math.Abs(dRunningODIntBalance) & ",0"
                    End If
                    sSQL = sSQL & ")"
                    ob.Execute(sSQL, ob.getconnection(ob.Getconn))
                End If

                '    Payment Data
                sSQL = "SELECT doc_no,Doc_Type,Cheque_date,Column_id,Member_Id,remarks,Doc_amt FROM " & gPaymentData & " WHERE company_id = " & clsVariables.CompnyId & " and Year_Id = " & aq(clsVariables.WorkingYear) & " and Member_Id = " & iMemberId & " and Cheque_date <= " & aq(sDocDate) & ""
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                sSQL = sSQL & " ORDER by doc_date"
                rst = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                iRow = 0
                Do While iRow < rst.Rows.Count
                    sSQL = "INSERT INTO " & gAccountLedgerInt & " (Company_Id, IP_Address, Member_Id, Column_Id, Doc_Date, Year_Id, Doc_Type, Doc_No, Remarks, Credit_Amt, Debit_Amt, Rec_Int, Pay_Int,Rec_OD_Int, Pay_OD_Int)"
                    sSQL = sSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & iMemberId & "," & iColumnId & "," & aq(rst.Rows(iRow).Item("Cheque_Date")) & "," & aq(clsVariables.WorkingYear) & "," & Val(rst.Rows(iRow).Item("Doc_Type")) & "," & Val(rst.Rows(iRow).Item("Doc_No")) & "," & aq(rst.Rows(iRow).Item("Remarks"))
                    sSQL = sSQL & ",0," & Val(rst.Rows(iRow).Item("Doc_Amt")) & ",0,0,0,0)"
                    ob.Execute(sSQL, ob.getconnection(ob.Getconn))
                    iRow = iRow + 1
                Loop
                rst.Clear()
                rst.Dispose()

                'Receipt Data
                sSQL = "SELECT Doc_date,cheque_date,doc_type,doc_no,Column_id,Member_Id,Remarks,Doc_amt,Int_Amt,Net_Amt,OD_Int_Amt FROM " & gReceiptData & " WHERE company_id = " & clsVariables.CompnyId & " and Year_Id = " & aq(clsVariables.WorkingYear) & " AND Member_Id = " & iMemberId & " AND cheque_date <= " & aq(sDocDate) & ""
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                rst = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                iRow = 0
                Do While iRow < rst.Rows.Count
                    sSQL = "INSERT INTO " & gAccountLedgerInt & " (Company_Id, IP_Address, Member_Id, Column_Id, Doc_Date, Year_Id, Doc_Type, Doc_No, Remarks, Credit_Amt, Debit_Amt, Rec_Int, Pay_Int,Rec_OD_Int, Pay_OD_Int)"
                    sSQL = sSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & iMemberId & "," & iColumnId & "," & aq(rst.Rows(iRow).Item("Cheque_Date")) & "," & aq(clsVariables.WorkingYear) & "," & Val(rst.Rows(iRow).Item("Doc_Type")) & "," & Val(rst.Rows(iRow).Item("Doc_No")) & "," & aq(rst.Rows(iRow).Item("Remarks"))
                    sSQL = sSQL & "," & Val(rst.Rows(iRow).Item("Doc_Amt")) & ",0," & Val(rst.Rows(iRow).Item("Int_Amt")) & ",0," & Val(rst.Rows(iRow).Item("OD_Int_Amt")) & ",0)"
                    ob.Execute(sSQL, ob.getconnection(ob.Getconn))
                    iRow = iRow + 1
                Loop
                rst.Clear()
                rst.Dispose()

                'Interest Calculation
                Dim mInt As Double
                Dim mODINT As Double

                Dim dAccountId As Integer
                Dim xAccountId As Integer
                Dim dColumnId As Integer
                Dim dDate As Date
                Dim dRECAMT As Double
                Dim dPAYAMT As Double
                Dim dBAL As Double
                Dim dRecBal As Double
                Dim dPayBal As Double
                Dim dRecProd As Double
                Dim dPayProd As Double
                Dim mPayInt As Double
                Dim mRecInt As Double
                Dim dDays As Integer
                Dim mToDate As Date
                Dim dEndDate As Date
                Dim mRec As Integer

                Dim sYearId As String
                Dim dDocType As Integer
                Dim dDocNo As Integer

                Dim dPassAmount As Double
                Dim pRST As New DataTable

                Dim dRODPROD As Double
                Dim dPODPROD As Double
                Dim mPODINT As Double
                Dim mRODINT As Double
                Dim dODDays As Integer

                Dim dRow As Integer

                mInt = 0
                mODINT = 3
                mRec = 0
                dDays = 0

                sSQL = "DELETE FROM " & gInterestData & " WHERE IP_Address = " & aq(IPAddress) & " and Member_Id = " & iMemberId & ""
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                ob.Execute(sSQL, ob.getconnection(ob.Getconn))

                sSQL = "INSERT INTO " & gInterestData & " (Company_id,IP_Address,Member_Id,Column_id,Doc_date,Working_Year,Doc_Type,Doc_No,Remarks,Pay_Amt,Rec_Amt,Pay_Int,Rec_Int,Rec_Bal,Pay_bal,Rec_Prod,Pay_Prod,Days,Int_Per,Pay_OD_Int,Rec_OD_Int,Rec_OD_Pro,Pay_OD_Pro,OD_Days,OD_Int,OD_Int_Per)"
                sSQL = sSQL & " SELECT Company_id,IP_Address,Member_Id,Column_id,Doc_date,Year_Id,Doc_Type,Doc_No,Remarks,Debit_Amt,Credit_Amt,Pay_Int,Rec_Int,0 as rec_bal,0 as Pay_Bal,0 as rec_Prod,0 as Pay_Prod,0 as Days,0 as Int_Per,Pay_OD_Int,Rec_OD_Int,0 as Rec_OD_Pro,0 as Pay_OD_Pro,0 as OD_Days,0 as OD_Int,0 as OD_Int_Per FROM " & gAccountLedgerInt & " WHERE Company_id = " & clsVariables.CompnyId & " and IP_Address = " & aq(IPAddress) & " and Member_Id = " & iMemberId
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                ob.Execute(sSQL, ob.getconnection(ob.Getconn))

                sSQL = "SELECT Member_Id,column_id,Working_Year,doc_type,Doc_date,doc_no,rec_Amt,pay_amt FROM " & gInterestData & " WHERE company_id = " & clsVariables.CompnyId & " and IP_Address = " & aq(IPAddress) & " ORDER BY Member_Id,Doc_date"
                rst = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))

                dAccountId = 0
                xAccountId = 0
                dColumnId = 0
                dDate = Date.Now
                iRow = 0
                Do While iRow < rst.Rows.Count
                    dAccountId = Val(rst.Rows(iRow).Item("Member_Id"))
                    dColumnId = Val(rst.Rows(iRow).Item("Column_Id"))
                    dDate = rst.Rows(iRow).Item("Doc_Date")
                    dDocType = Val(rst.Rows(iRow).Item("doc_type"))
                    dDocNo = Val(rst.Rows(iRow).Item("doc_no"))
                    sYearId = rst.Rows(iRow).Item("Working_Year")
                    dRECAMT = 0
                    dPAYAMT = 0
                    dBAL = 0

                    dPassAmount = 0
                    dODDate = sDocDate

                    sSQL = "SELECT Pass_Amount,Due_Date FROM " & gPakDhiranPassingData & " WHERE company_id = " & clsVariables.CompnyId & " and Member_Id = " & dAccountId & " and Column_Id = " & dColumnId
                    pRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                    If Not IsDBNull(pRST.Rows(iRow).Item("Pass_Amount")) Then
                        dPassAmount = Val(pRST.Rows(iRow).Item("Pass_Amount"))
                    End If
                    If Not IsDBNull(pRST.Rows(iRow).Item("Due_Date")) Then
                        dODDate = pRST.Rows(iRow).Item("Due_Date")
                    Else
                        dODDate = gFinYearEnd
                    End If
                    pRST.Clear()
                    pRST.Dispose()

                    Do While iRow < rst.Rows.Count And dAccountId = rst.Rows(iRow).Item("Member_Id")

                        'Check Slab wise Interest Rate
                        sSQL = "SELECT From_Date,To_Date,From_Pass_Amt,To_Pass_Amt,Interest_Rate,Over_Due_Interest_Rate FROM " & gInterestDateData & " WHERE company_id = " & clsVariables.CompnyId & " ORDER by From_Date "
                        sRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                        If sRST.Rows.Count <> 0 Then
                            dRow = 0
                            Do While dRow < sRST.Rows.Count
                                If dPassAmount >= sRST.Rows(dRow).Item("From_Pass_Amt") And dPassAmount <= sRST.Rows(dRow).Item("To_Pass_Amt") Then
                                    If dDate >= sRST.Rows(dRow).Item("from_date") And dDate <= sRST.Rows(dRow).Item("to_Date") Then
                                        If rst.Rows(iRow).Item("Doc_Date") > sRST.Rows(dRow).Item("to_Date") Then
                                            mInt = sRST.Rows(dRow).Item("Interest_Rate")

                                            dRecBal = 0
                                            dPayBal = 0
                                            dRecProd = 0
                                            dPayProd = 0
                                            mPayInt = 0
                                            mRecInt = 0

                                            dRODPROD = 0
                                            dPODPROD = 0
                                            mPODINT = 0
                                            mRODINT = 0
                                            dODDays = 0

                                            dDays = (DateDiff(DateInterval.Day, dDate, sRST.Rows(dRow).Item("to_Date"))) + 1
                                            If sRST.Rows(dRow).Item("to_Date") > dODDate Then
                                                dODDays = DateDiff(DateInterval.Day, dODDate, sRST.Rows(dRow).Item("to_Date"))
                                                dODDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                            Else
                                                dODDays = 0
                                            End If
                                            If dBAL < 0 Then
                                                dRecBal = Math.Abs(dBAL)
                                                dRecProd = (dRecBal * dDays)
                                                dRODPROD = (dRecBal * dODDays)
                                                mRecInt = Math.Round((mInt * dRecProd) / 36500, 0)
                                                mRODINT = Math.Round((mODINT * dRODPROD) / 36500, 0)
                                            Else
                                                dPayBal = Math.Abs(dBAL)
                                                dPayProd = (dPayBal * dDays)
                                                dPODPROD = (dPayBal * dODDays)
                                                mPayInt = Math.Round((mInt * dPayProd) / 36500, 0)
                                                mPODINT = Math.Round((mODINT * dPODPROD) / 36500, 0)
                                            End If

                                            isSQL = "INSERT INTO " & gInterestData & " (Company_id,IP_Address,Member_Id,Column_id,Doc_date,Working_Year,Doc_Type,Doc_No,Remarks,Pay_Amt,Rec_Amt,Pay_Int,Rec_Int,Rec_Bal,Pay_bal,Rec_Prod,Pay_Prod,Days,Int_Per,Pay_OD_Int,Rec_OD_Int,Rec_OD_Pro,Pay_OD_Pro,OD_Days,OD_Int,OD_Int_Per)"
                                            isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(sRST.Rows(dRow).Item("to_Date")) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & ",0," & Val(mODINT) & ")"
                                            'isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(sRST.Rows(dRow).Item("To_date")) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & ",0," & Val(mODINT) & ")"
                                            ob.Execute(isSQL, ob.getconnection(ob.Getconn))
                                            dDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                        Else
                                            dDays = DateDiff(DateInterval.Day, dDate, rst.Rows(iRow).Item("Doc_Date"))
                                            If rst.Rows(iRow).Item("Doc_Date") > dODDate Then
                                                dODDays = DateDiff(DateInterval.Day, dODDate, rst.Rows(iRow).Item("Doc_Date"))
                                                dODDate = DateAdd(DateInterval.Day, 1, rst.Rows(iRow).Item("Doc_Date"))
                                                If rst.Rows(iRow).Item("Doc_Date") = sRST.Rows(dRow).Item("to_Date") Then
                                                    dODDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                                End If
                                            Else
                                                dODDays = 0
                                            End If

                                            mInt = sRST.Rows(dRow).Item("Interest_Rate")

                                            dRecBal = 0
                                            dPayBal = 0
                                            dRecProd = 0
                                            dPayProd = 0
                                            mPayInt = 0
                                            mRecInt = 0

                                            dRODPROD = 0
                                            dPODPROD = 0
                                            mPODINT = 0
                                            mRODINT = 0
                                            If dBAL < 0 Then
                                                dRecBal = Math.Abs(dBAL)
                                                dRecProd = (dRecBal * dDays)
                                                mRecInt = Math.Round((mInt * dRecProd) / 36500, 0)
                                                dRODPROD = (dRecBal * dODDays)
                                                mRODINT = Math.Round((mODINT * dRODPROD) / 36500, 0)
                                            Else
                                                dPayBal = Math.Abs(dBAL)
                                                dPayProd = (dPayBal * dDays)
                                                mPayInt = Math.Round((mInt * dPayProd) / 36500, 0)
                                                dPODPROD = (dPayBal * dODDays)
                                                mPODINT = Math.Round((mODINT * dPODPROD) / 36500, 0)
                                            End If

                                            dDate = rst.Rows(iRow).Item("Doc_Date")
                                            dDocType = Val(rst.Rows(iRow).Item("doc_type"))
                                            dDocNo = Val(rst.Rows(iRow).Item("doc_no"))
                                            sYearId = rst.Rows(iRow).Item("Working_Year")

                                            If (mPayInt + mRecInt) <> 0 Then
                                                aSQL = "UPDATE " & gInterestData & " SET days=" & dDays & ",rec_bal=" & dRecBal & ",pay_bal=" & dPayBal & ",rec_prod=" & dRecProd & ",pay_prod=" & dPayProd & ",pay_int=pay_int+" & mPayInt & ",rec_int=rec_int+" & mRecInt & ",Int_Per = " & Val(mInt) & ",OD_days = " & dODDays & ",rec_od_pro=" & dRODPROD & ",pay_od_pro=" & dPODPROD & ",pay_OD_int=pay_OD_int+" & mPODINT & ",rec_OD_int=rec_OD_int+" & mRODINT & ",OD_Int_Per = " & Val(mODINT) & " WHERE company_id = " & clsVariables.CompnyId & " and IP_Address = " & aq(IPAddress) & " and Working_Year = " & aq(sYearId) & " AND Member_Id = " & dAccountId & " and doc_Type = " & dDocType & " and doc_no = " & dDocNo & " and doc_date = " & aq(dDate) & ""
                                                ob.Execute(aSQL, ob.getconnection(ob.Getconn))
                                            End If
                                            If rst.Rows(iRow).Item("Doc_Date") = sRST.Rows(dRow).Item("to_Date") Then
                                                dDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                            End If
                                        End If
                                    End If
                                End If
                                dRow = dRow + 1
                            Loop
                        End If
                        sRST.Clear()
                        sRST.Dispose()

                        '// AGAIN FOR NEXT CALUCATION

                        dRECAMT = dRECAMT + Val(rst.Rows(iRow).Item("rec_amt"))
                        dPAYAMT = dPAYAMT + Val(rst.Rows(iRow).Item("PAY_AMT"))
                        dBAL = dPAYAMT - dRECAMT

                        iRow = iRow + 1

                        If iRow > rst.Rows.Count - 1 Then
                            Exit Do
                        End If
                    Loop

                    mToDate = sDocDate
                    '+ 1
                    dDays = DateDiff(DateInterval.Day, dDate, mToDate)

                    mRecInt = 0
                    mPayInt = 0
                    mRODINT = 0
                    mPODINT = 0

                    'Check Slab wise Interest Rate
                    sSQL = "SELECT From_Date,To_Date,From_Pass_Amt,To_Pass_Amt,Interest_Rate,Over_Due_Interest_Rate FROM " & gInterestDateData & " WHERE company_id = " & clsVariables.CompnyId & " ORDER by From_Date "
                    sRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                    If sRST.Rows.Count <> 0 Then
                        dRow = 0
                        Do While dRow < sRST.Rows.Count
                            dRecBal = 0
                            dPayBal = 0
                            dRecProd = 0
                            dPayProd = 0
                            mPayInt = 0
                            mRecInt = 0

                            dRODPROD = 0
                            dPODPROD = 0
                            mPODINT = 0
                            mRODINT = 0
                            If dPassAmount >= sRST.Rows(dRow).Item("From_Pass_Amt") And dPassAmount <= sRST.Rows(dRow).Item("To_Pass_Amt") Then

                                If dDate >= sRST.Rows(dRow).Item("from_date") And dDate <= sRST.Rows(dRow).Item("to_Date") Then
                                    If mToDate >= sRST.Rows(dRow).Item("to_Date") Then
                                        mInt = sRST.Rows(dRow).Item("Interest_Rate")
                                        dDays = DateDiff(DateInterval.Day, dDate, sRST.Rows(dRow).Item("to_Date"))

                                        If sRST.Rows(dRow).Item("to_Date") > dODDate Then
                                            dODDays = DateDiff(DateInterval.Day, dODDate, sRST.Rows(dRow).Item("to_Date"))
                                            dODDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                        Else
                                            dODDays = 0
                                        End If

                                        If dBAL < 0 Then
                                            dRecBal = Math.Abs(dBAL)
                                            dRecProd = (dRecBal * dDays)
                                            mRecInt = Math.Round((mInt * dRecProd) / 36500, 0)
                                            dRODPROD = (dRecBal * dODDays)
                                            mRODINT = Math.Round((mODINT * dRODPROD) / 36500, 0)
                                        Else
                                            dPayBal = Math.Abs(dBAL)
                                            dPayProd = (dPayBal * dDays)
                                            mPayInt = Math.Round((mInt * dPayProd) / 36500, 0)
                                            dPODPROD = (dPayBal * dODDays)
                                            mPODINT = Math.Round((mODINT * dPODPROD) / 36500, 0)
                                        End If
                                        If dBAL <> 0 Then
                                            isSQL = "INSERT INTO " & gInterestData & " (Company_id,IP_Address,Member_Id,Column_id,Doc_date,Working_Year,Doc_Type,Doc_No,Remarks,Pay_Amt,Rec_Amt,Pay_Int,Rec_Int,Rec_Bal,Pay_bal,Rec_Prod,Pay_Prod,Days,Int_Per,Pay_OD_Int,Rec_OD_Int,Rec_OD_Pro,Pay_OD_Pro,OD_Days,OD_Int,OD_Int_Per)"
                                            'isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(sRST.Rows(dRow).Item("to_Date")) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & "," & Val(mODINT) & ")"
                                            isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(sRST.Rows(dRow).Item("to_Date")) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & ",0," & Val(mODINT) & ")"
                                            ob.Execute(isSQL, ob.getconnection(ob.Getconn))

                                        End If
                                        dDate = DateAdd(DateInterval.Day, 1, sRST.Rows(dRow).Item("to_Date"))
                                    Else

                                        dDays = DateDiff(DateInterval.Day, dDate, mToDate) '+ 1
                                        If mToDate > dODDate Then
                                            dODDays = DateDiff(DateInterval.Day, dODDate, mToDate)
                                        Else
                                            dODDays = 0
                                        End If
                                        mInt = sRST.Rows(dRow).Item("Interest_Rate")
                                        If dBAL < 0 Then
                                            dRecBal = Math.Abs(dBAL)
                                            dRecProd = (dRecBal * dDays)
                                            mRecInt = Math.Round((mInt * dRecProd) / 36500, 0)
                                            dRODPROD = (dRecBal * dODDays)
                                            mRODINT = Math.Round((mODINT * dRODPROD) / 36500, 0)
                                        Else
                                            dPayBal = Math.Abs(dBAL)
                                            dPayProd = (dPayBal * dDays)
                                            mPayInt = Math.Round((mInt * dPayProd) / 36500, 0)
                                            dPODPROD = (dPayBal * dODDays)
                                            mPODINT = Math.Round((mODINT * dPODPROD) / 36500, 0)
                                        End If
                                        dEndDate = sDocDate
                                        If dBAL <> 0 Then
                                            isSQL = "INSERT INTO " & gInterestData & " (Company_id,IP_Address,Member_Id,Column_id,Doc_date,Working_Year,Doc_Type,Doc_No,Remarks,Pay_Amt,Rec_Amt,Pay_Int,Rec_Int,Rec_Bal,Pay_bal,Rec_Prod,Pay_Prod,Days,Int_Per,Pay_OD_Int,Rec_OD_Int,Rec_OD_Pro,Pay_OD_Pro,OD_Days,OD_Int,OD_Int_Per)"
                                            'isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(dEndDate) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & "," & Val(mODINT) & ")"
                                            isSQL = isSQL & " VALUES(" & clsVariables.CompnyId & "," & aq(IPAddress) & "," & dAccountId & "," & dColumnId & "," & aq(dEndDate) & "," & aq(clsVariables.WorkingYear) & ",0,9999,'ìepS>',0,0," & mPayInt & "," & mRecInt & "," & dRecBal & "," & dPayBal & "," & dRecProd & "," & dPayProd & "," & dDays & "," & Val(mInt) & "," & mPODINT & "," & mRODINT & "," & dRODPROD & "," & dPODPROD & "," & dODDays & ",0," & Val(mODINT) & ")"
                                            ob.Execute(isSQL, ob.getconnection(ob.Getconn))
                                        End If
                                    End If
                                End If
                            End If
                            dRow = dRow + 1
                        Loop
                    End If
                    sRST.Clear()
                    sRST.Dispose()

                    If iRow >= rst.Rows.Count - 1 Then
                        Exit Do
                    End If
                Loop
                rst.Clear()
                rst.Dispose()

                'Interst Data Transfer to Account LEdger Interest Table
                sSQL = "DELETE FROM " & gAccountLedgerInt & " WHERE IP_Address = " & aq(IPAddress) & " and Member_Id = " & iMemberId
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                ob.Execute(sSQL, ob.getconnection(ob.Getconn))

                sSQL = "INSERT INTO " & gAccountLedgerInt & " (Company_Id, IP_Address, Member_Id, Column_Id, Doc_Date, Year_Id, Doc_Type, Doc_No, Remarks, Debit_Amt, Credit_Amt, Pay_Int, Rec_Int, Days, Int_Per, Rec_OD_Int, Pay_OD_Int, OD_Days, OD_Int_Per)"
                sSQL = sSQL & " SELECT Company_id, IP_Address, Member_Id, Column_id, Doc_date, Working_Year, Doc_Type, Doc_No, Remarks, Pay_Amt, Rec_Amt, Pay_Int, Rec_Int, Days, Int_Per, Rec_OD_Int, Pay_OD_Int, OD_Days, OD_Int_Per FROM " & gInterestData & " WHERE IP_Address = " & aq(IPAddress) & " and Member_Id = " & iMemberId
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                ob.Execute(sSQL, ob.getconnection(ob.Getconn))

                dInterest = 0
                dOdInterest = 0
                sSQL = "SELECT Sum(pay_int - rec_int) as IntAmt,Sum(Pay_OD_Int - Rec_Od_Int) as ODInt FROM " & gAccountLedgerInt & " WHERE IP_Address = " & aq(IPAddress) & " and Member_Id = " & iMemberId
                If iColumnId <> 0 Then
                    sSQL = sSQL & " and column_id = " & iColumnId & ""
                End If
                rst = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
                iRow = 0
                If rst.Rows.Count <> 0 Then
                    If Not IsDBNull(rst.Rows(iRow).Item("IntAmt")) Then
                        dInterest = dInterest + Val(rst.Rows(iRow).Item("IntAmt"))

                    End If
                    If Not IsDBNull(rst.Rows(iRow).Item("ODInt")) Then
                        dOdInterest = dOdInterest + Val(rst.Rows(iRow).Item("ODInt"))
                    End If

                End If
                dIntAmt = dInterest
                dODIntAmt = dOdInterest

                Pak_Loan_Calc_Interest = dInterest


            Catch ex As Exception
                'Error Message
                MsgBox(ex.Message)
            End Try
        End Function
        ''ranjeet
        Public Function Get_Last_Receipt_Date_New(ByVal iLoanNo As Long, ByVal sLoanDate As String, ByVal sUpToDate As String)
            Dim sSQL As String
            Dim rdRST As DataTable

            sSQL = "SELECT max(doc_date) as LastDate FROM MLOAN_RECEIPT_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo & " and doc_date <= '" & sFunction.DateConversion(sUpToDate) & "'"
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count > 0 And Not IsDBNull(rdRST.Rows(0).Item("lastdate")) Then
                If gLastReserveDate > rdRST.Rows(0).Item("lastdate") Then
                    Get_Last_Receipt_Date_New = gLastReserveDate
                Else
                    Get_Last_Receipt_Date_New = rdRST.Rows(0).Item("lastdate")
                End If
            Else
                If gLastReserveDate > DateValue(sFunction.DateConversion(sLoanDate)) Then
                    Get_Last_Receipt_Date_New = gLastReserveDate
                Else
                    Get_Last_Receipt_Date_New = DateValue(sFunction.DateConversion(sLoanDate))
                End If
            End If
            rdRST.Clear()
        End Function
        Public Function Get_Loan_Amount(ByVal iLoanNo As Long)
            Dim sSQL As String
            Dim rdRST As DataTable
            Dim dBalance As Double

            dBalance = 0
            '    sSQL = "SELECT Opening_Amount FROM " & gLOANOpeningBalance & " WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo
            '    Set rdRST = gdbUser.OpenRecordset(sSQL, dbOpenSnapshot)
            '    If Not rdRST.EOF And Not IsNull(rdRST!Opening_amount) Then
            '       dBalance = rdRST!Opening_amount
            '    End If
            '    rdRST.Close

            'Payment
            sSQL = "SELECT sum(Paid_amount) as amount FROM MLoan_PAYMENT_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count <> 0 And Not IsDBNull(rdRST.Rows(0).Item("Amount")) Then
                dBalance = dBalance + rdRST.Rows(0).Item("Amount")
            End If
            rdRST.Clear()

            'Expence
            sSQL = "SELECT sum(Expence_amount) as amount FROM MLOAN_EXPENCE_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count > 0 And Not IsDBNull(rdRST.Rows(0).Item("Amount")) Then
                dBalance = dBalance + rdRST.Rows(0).Item("Amount")
            End If
            rdRST.Clear()

            Get_Loan_Amount = dBalance
        End Function
        Public Function Get_Loan_Balance(ByVal iLoanNo As Long, ByVal sUpToDate As String)
            Dim sSQL As String
            Dim rdRST As New DataTable
            Dim dBalance As Double

            dBalance = 0
            '    sSQL = "SELECT Opening_Amount FROM " & gLOANOpeningBalance & " WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo
            '    Set rdRST = gdbUser.OpenRecordset(sSQL, dbOpenSnapshot)
            '    If Not rdRST.EOF And Not IsNull(rdRST!Opening_amount) Then
            '       dBalance = rdRST!Opening_amount
            '    End If
            '    rdRST.Close

            'Payment
            sSQL = "SELECT sum(Paid_Amount) as amount FROM MLoan_PAYMENT_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo & " and doc_date <= '" & sFunction.DateConversion(sUpToDate) & "'"
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count <> 0 And Not IsDBNull(rdRST.Rows(0).Item("Amount")) Then
                dBalance = dBalance + rdRST.Rows(0).Item("Amount")
            End If
            rdRST.Clear()

            'Expence
            sSQL = "SELECT sum(Expence_Amount) as amount FROM MLOAN_EXPENCE_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo & " and doc_date <= '" & sFunction.DateConversion(sUpToDate) & "'"
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count <> 0 And Not IsDBNull(rdRST.Rows(0).Item("Amount")) Then
                dBalance = dBalance + rdRST.Rows(0).Item("Amount")
            End If
            rdRST.Clear()

            'Receipt
            sSQL = "SELECT sum(Receipt_Amount) as amount FROM MLOAN_RECEIPT_DATA WHERE company_id = " & clsVariables.CompnyId & " and loan_no = " & iLoanNo & " and doc_date <= '" & sFunction.DateConversion(sUpToDate) & "'"
            rdRST = ob.Returntable(sSQL, ob.getconnection(ob.Getconn))
            If rdRST.Rows.Count <> 0 And Not IsDBNull(rdRST.Rows(0).Item("Amount")) Then
                dBalance = dBalance - rdRST.Rows(0).Item("Amount")
            End If
            rdRST.Clear()
            Get_Loan_Balance = dBalance
        End Function

        'Public Sub InsertData(ByVal sqlcmdtext As String, ByVal strfldvalue As String)

        '    Try
        '        Dim tempstr As String = ""
        '        Dim tmpstr1 As String = ""
        '        Dim iStart As Integer = 0
        '        Dim iEnd As Integer = 0
        '        Dim i As Integer = 0
        '        Dim j As Integer = 0
        '        Dim fldvalue As String = ""
        '        Dim strTableName As String = ""

        '        Dim strParaFld(0 To 250) As String
        '        Dim strValueFld(0 To 250) As String

        '        tempstr = sqlcmdtext

        '        Dim sqlcommand As New SqlClient.SqlCommand
        '        sqlcommand.Connection = ob.getconnection(ob.Getconn)
        '        sqlcommand.CommandText = sqlcmdtext

        '        Dim pos As Short

        '        Dim xx As String = ""
        '        Dim k As Integer = 0
        '        sqlcommand.CommandText = "Insert into Account_Ledger_Report(Company_Id,Working_Year,IP_Address,Account_Id,Doc_Ser_Id,Doc_Date,Doc_No,Open_amt,Credit_Amt,Debit_Amt,Member_Id,Sr_No)" & _
        '    "values(@Company_Id,@Working_Year,@IP_Address,@Account_Id,@Doc_Ser_Id,@Doc_Date,@Doc_No,@Open_Amt,@Credit_Amt,@Debit_Amt,@Member_Id,@Sr_No)"


        '        xx = tempstr
        '        pos = InStr(1, xx, ")")
        '        xx = Mid(xx, 1, pos - 1)
        '        pos = InStr(1, xx, "(")
        '        strTableName = Mid(xx, 13, pos - 1)
        '        xx = Mid(xx, pos, Len(xx))
        '        pos = pos + 1
        '        k = pos
        '        Do While pos > 0
        '            pos = InStr(pos + 1, xx, ",")
        '            strParaFld(j) = Trim(Mid(xx, k, pos - 1))
        '            xx = Mid(xx, pos, Len(xx))
        '            pos = InStr(pos + 1, xx, ",")
        '        Loop

        '        xx = strfldvalue

        '        pos = InStr(1, xx, "(")
        '        pos = pos + 1
        '        k = pos
        '        Do While pos > 0
        '            pos = InStr(pos + 1, xx, ",")
        '            strValueFld(j) = Trim(Mid(xx, k, pos - 1))
        '            xx = Mid(xx, pos, Len(xx))
        '            pos = InStr(pos + 1, xx, ",")
        '        Loop

        '        'sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
        '        'sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
        '        'sqlcommand.Parameters.AddWithValue("@Working_Year", clsVariables.WorkingYear)
        '        'sqlcommand.Parameters.AddWithValue("@IP_Address", 1)
        '        'sqlcommand.Parameters.AddWithValue("@Account_Id", AccountId)
        '        'sqlcommand.Parameters.AddWithValue("@Doc_Ser_Id", docserId)
        '        'sqlcommand.Parameters.AddWithValue("@Doc_Date", docdate)
        '        'sqlcommand.Parameters.AddWithValue("@Doc_No", Doc_No)
        '        'sqlcommand.Parameters.AddWithValue("@Sr_No", iSrNo)
        '        'sqlcommand.Parameters.AddWithValue("@Open_Amt", openAmt)
        '        'sqlcommand.Parameters.AddWithValue("@Credit_Amt", Credit_Amt)
        '        'sqlcommand.Parameters.AddWithValue("@Debit_Amt", Debit_Amt)
        '        'sqlcommand.Parameters.AddWithValue("@Member_id", Member_Id)

        '        sqlcommand.ExecuteNonQuery()
        '        sqlcommand.Parameters.Clear()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        'End Sub
    End Class


End Namespace
