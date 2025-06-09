Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Xml.Schema
Namespace CLS
    Public Class clsCommands
        Inherits clsVariables
        Public Sub setsqlCommand(ByVal dsFill As DataSet, ByVal daFill As SqlDataAdapter, ByVal sSQL As String, ByVal sTable As String)

            Try
                clsConnection.setsqlConnectionState()

                daFill.SelectCommand = New SqlCommand(sSQL, sqlConnection)
                dsFill.Clear()
                daFill.Fill(dsFill, sTable)
                clsConnection.setsqlConnectionState()

            Catch ex As Exception
                setCommandDatasetClose(dsFill, daFill)
            End Try

        End Sub
        Public Sub setCommandDatasetClose(ByVal dsFill As DataSet, ByVal daFill As SqlDataAdapter)
            dsFill.Tables.Clear()
            dsFill.Dispose()
            daFill.Dispose()

            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
                sqlConnection.Dispose()
            End If

        End Sub
        Public Sub setsqlCommandReader(ByVal sSQL As String)
            clsConnection.setsqlConnectionState()
            sqlConnection.Open()
            sqlCommand.Connection = sqlConnection
            sqlCommand.CommandText = sSQL
            sqlDataReader = sqlCommand.ExecuteReader()
        End Sub

        
        Public Sub setCloseCommand()

            Try
                sqlDataReader.Close()
                sqlCommand.Dispose()
                If sqlConnection.State = ConnectionState.Open Then
                    sqlConnection.Close()
                    sqlConnection.Dispose()
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Class
End Namespace
