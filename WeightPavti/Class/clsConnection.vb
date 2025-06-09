Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Xml.Schema
Namespace CLS
    Public Class clsConnection
        Inherits clsVariables
        Dim sVariables As New clsVariables
        Public Sub GetConnection()
            'Dim RptLocation As String = ""
            'Dim ServerName As String = ""
            Dim DatabaseName As String = ""
            Dim aa As String = ""
            Try
                FileOpen(1, Application.StartupPath & "\Mandali_ERP.ini", OpenMode.Input)
                Input(1, RptLocation)
                Input(1, ServerName)
                Input(1, DatabaseName)
                Input(1, ImgPath)
                Input(1, ImageAlign)
                Input(1, sysname)
                Input(1, RptApp)
                Input(1, BackDbname)
                Input(1, DbAuth)
                FileClose(1)
            Catch ex As Exception

            End Try
            
            ServerName = ServerName
            dbname = DatabaseName
            ImagePath = ImgPath
            If DbAuth = "WIN" Then
                constr = "Integrated Security=True;Initial Catalog=" & dbname & ";Data Source=" & servername & " ; Connect Timeout=0; MAX Pool Size = 5000; "
            Else
                constr = "Password=advsys;Data Source=" & servername & ";Initial Catalog=" & dbname & ";Integrated Security=False;Persist Security Info=False;User ID=advsys;Max Pool Size=5000;Connect Timeout=0"
            End If
            'd.Close()

        End Sub
        Public Sub Getconnectionstring()
            Dim sPath As String
            Dim sServername As String
            Dim sDatabaseName As String
            Dim iflag As Integer
            iflag = 0
            sServername = ""
            sDatabaseName = ""
            sPath = ""

            Dim fs = New FileStream("<Account>", FileMode.Open, FileAccess.Read)
            Dim d As New StreamReader(fs)
            d.BaseStream.Seek(0, SeekOrigin.Begin)
            While d.Peek() > -1
                If iflag = 0 Then
                    sPath = d.ReadLine()
                ElseIf iflag = 1 Then
                    sServername = d.ReadLine()
                ElseIf iflag = 2 Then
                    sDatabaseName = d.ReadLine()

                End If

                iflag = Val(iflag + 1)
                'Textbox1.Text &= d.ReadLine()
            End While
            d.Close()

        End Sub
        Public Shared Function setConnectionString() As String
            ' Return "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|SugarNew.mdf;Integrated Security=True;User Instance=True"
            'Return "Data Source=Advance;Initial Catalog=Sugar_chalthan;Integrated Security=True;"
            'Return System.Configuration.ConfigurationManager.ConnectionStrings("sugar_chalthanConnectionString").ConnectionString
            Return constr


        End Function
        Public Shared Sub setsqlConnectionState()
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
                sqlConnection.Dispose()
            End If
            sqlConnection.ConnectionString = setConnectionString()

        End Sub
    End Class

End Namespace
