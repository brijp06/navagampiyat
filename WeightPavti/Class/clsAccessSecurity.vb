Imports WeightPavti.CLS
Imports System.Data.SqlClient
Public Class clsAccessSecurity
    Inherits clsVariables
    Dim sVariables As New clsVariables
    Dim scommands As New clsCommands
    Dim sSql As String
    Public cn As SqlClient.SqlConnection
    Public Shared User_Name As String
    Public Shared Form_Name As String
    Public Shared Department_Id As Integer
    Public Shared Add_Right As String
    Public Shared Change_Right As String
    Public Shared Delete_Right As String
    Public Shared View_Right As String
    Public Shared Lock_Right As String
    Public Function filldata(ByVal sSQL As String) As clsAccessSecurity

        Dim objAccessSecurity As New clsAccessSecurity
        Try
            scommands.setsqlCommand(sVariables.sDataSet, clsVariables.sqlDataAdapter, sSQL, "ACCESS_SECURITY_NEW")
            Dim sDataRow As DataRow = sVariables.sDataSet.Tables("ACCESS_SECURITY_NEW").Rows(0)

            With objAccessSecurity
                User_Name = sDataRow("User_Name")
                Form_Name = sDataRow("Form_Name")
                Department_Id = sDataRow("Department_Id")
                Add_Right = sDataRow("Add_Right")
                Change_Right = sDataRow("Change_Right")
                Delete_Right = sDataRow("Delete_Right")
                View_Right = sDataRow("View_Right")
                Lock_Right = sDataRow("Lock_Right")

            End With

            scommands.setCommandDatasetClose(svariables.sDataSet, clsVariables.sqlDataAdapter)
        Catch ex As Exception
            scommands.setCommandDatasetClose(svariables.sDataSet, clsVariables.sqlDataAdapter)
        End Try

        Return objAccessSecurity

    End Function
    Public Function CountRecord1(ByVal sSQL As String) As Integer
        Try

            scommands.setsqlCommand(sVariables.sDataSet, clsVariables.sqlDataAdapter, sSQL, "ACCESS_SECURITY_NEW")
            'Dim sDataRow As DataRow = sVariables.sDataSet.Tables(0).Rows(0)
            Dim p As Integer
            p = sVariables.sDataSet.Tables(0).Rows.Count
            scommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            Return p
        Catch ex As Exception
            scommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function dispDataAll(ByVal sUserName As String, ByVal sFormName As String) As String
        Dim sSQL As String
        sSQL = "select * from ACCESS_SECURITY_NEW where User_Name='" & sUserName & "' and Form_Name='" & sFormName & "'"
        Return sSQL
    End Function
    Public Function CheckEditRights(ByVal FrmName As String) As Boolean
        sSql = dispDataAll(clsVariables.UserName, FrmName)
        If CountRecord1(sSql) <> 0 Then
            filldata(sSql)

            'check edit rights
            If clsAccessSecurity.Change_Right = "False" Then
                MsgBox("You don't have Rights to Edit the Records!!!")
                Return False
            Else
                Return True
            End If
        Else
            MsgBox("Entry of This Page with this User NOT FOUND in DATABASE!!!!!!!!!!!!!")
            'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Function
        End If

    End Function
    Public Function CheckDeleteRights(ByVal FrmName As String) As Boolean
        sSql = dispDataAll(clsVariables.UserName, FrmName)
        If CountRecord1(sSql) <> 0 Then
            filldata(sSql)
            'check Delete Rights
            If clsAccessSecurity.Delete_Right = "False" Then
                MsgBox("You don't have Rights to Delete the Records!!!")
                Return False
            Else
                Return True
            End If
        Else
            MsgBox("Entry of This Page with this User NOT FOUND in DATABASE!!!!!!!!!!!!!")
            'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Function
        End If

    End Function
    Public Function CheckAddRights(ByVal FrmName As String) As Boolean
        sSql = dispDataAll(clsVariables.UserName, FrmName)
        If CountRecord1(sSql) <> 0 Then
            filldata(sSql)
            'check Delete Rights
            If clsAccessSecurity.Add_Right = "False" Then
                MsgBox("You don't have Rights to Add the Records!!!")

                Return False

            Else


                Return True
            End If
        Else
            MsgBox("Entry of This Page with this User NOT FOUND in DATABASE!!!!!!!!!!!!!")
            'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Function
        End If

    End Function
    Public Function CheckViewRights(ByVal FrmName As String) As Boolean
        sSql = dispDataAll(clsVariables.UserName, FrmName)
        If CountRecord1(sSql) <> 0 Then
            filldata(sSql)
            'check Delete Rights
            If clsAccessSecurity.View_Right = "False" Then
                MsgBox("You don't have Rights to View the Records!!!")
                Return False

            Else
                Return True

            End If
        Else
            MsgBox("Entry of This Page with this User NOT FOUND in DATABASE!!!!!!!!!!!!!")
            'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Function

        End If

    End Function
End Class
