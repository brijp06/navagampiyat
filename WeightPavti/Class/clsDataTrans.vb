Imports WeightPavti.CLS
Imports System.Data.SqlClient

Public Class clsDataTrans
    Inherits clsVariables
    Dim sVariables As New clsVariables
    Public cn As SqlClient.SqlConnection

    ' / Function to open the connection for data transaction
    Public Function OpenCn() As Boolean
        'On Error GoTo oops
        If cn Is Nothing Then
            cn = New SqlClient.SqlConnection(constr)
        End If
        If Not cn.State = ConnectionState.Open Then
            Try
                cn.Open()
            Catch ex As Exception
                MsgBox("Error occured: " & ex.Message)
                OpenCn = False
            End Try
        End If
        OpenCn = True
    End Function
    ' /close the connection
    Public Sub CloseCn()
        On Error GoTo oops
        cn.Close()
        Exit Sub
oops:
        MsgBox("error occured: " & Err.Description)
    End Sub
    ' / gets a dataset for given sql string with the table name and given transaction
    Public Function GetDtSet(ByVal StrSql As String, Optional ByVal Nm As String = "First", Optional ByVal trans As SqlTransaction = Nothing) As Data.DataSet
        On Error GoTo oops
        Dim da As SqlClient.SqlDataAdapter
        Dim mycmd As SqlClient.SqlCommand
        Dim ds As New Data.DataSet
        ds.Clear()
        If OpenCn() Then
            mycmd = New SqlClient.SqlCommand(StrSql, cn, trans)
            da = New SqlClient.SqlDataAdapter(mycmd)
            da.Fill(ds, Nm)
            'CloseCn()
            Return ds
        Else
            Return Nothing
            Exit Function
        End If
oops:
        MsgBox("Error Occured: " & Err.Description, MsgBoxStyle.Critical, "Error")
        Return Nothing
    End Function
    Public Function fillgrid(ByVal strsql As String) As DataSet

        Dim da1 As New DataSet()
        Dim s2 As New SqlCommand(strsql, cn)
        Dim ad2 As New SqlDataAdapter(s2)
        ad2.Fill(da1)

        Return da1
    End Function
    Public Function fillgriddT(ByVal strsql As String) As DataTable

        Dim da1 As New DataSet()
        Dim DT As New DataTable
        Dim s2 As New SqlCommand(strsql, cn)
        Dim ad2 As New SqlDataAdapter(s2)
        ad2.Fill(da1)
        DT = da1.Tables(0)
        Return DT
    End Function
    ' / gets a datatable for given sql string with the table name and given transaction
    Public Function GetDtTab(ByVal StrSql As String, Optional ByVal Nm As String = "First", Optional ByVal cmdtype As CommandType = CommandType.Text, Optional ByRef trans As SqlTransaction = Nothing) As Data.DataTable
        On Error GoTo oops
        Dim da As SqlClient.SqlDataAdapter
        Dim mycmd As SqlClient.SqlCommand
        Dim ds As New Data.DataSet
        Dim dt As New Data.DataTable
        If OpenCn() Then
            ds.Clear()
            mycmd = New SqlClient.SqlCommand(StrSql, cn, trans)
            mycmd.CommandType = cmdtype
            da = New SqlClient.SqlDataAdapter(mycmd)
            da.Fill(ds, Nm)
            dt = ds.Tables(0)
            'CloseCn()
            Return dt
            Exit Function
        End If
oops:
        MsgBox("Error Occured: " & Err.Description, MsgBoxStyle.Critical, "Error")
        Return Nothing
    End Function
    ' / gets the first datarow from the datatable for given sql string with the table name and given transaction
    Public Function getdtrw(ByVal strsql As String, Optional ByVal nm As String = "First") As DataRow
        On Error GoTo oops
        Dim da As SqlClient.SqlDataAdapter
        Dim mycmd As SqlClient.SqlCommand
        Dim ds As New Data.DataSet
        Dim dt As New Data.DataTable
        Dim drx As DataRow
        If OpenCn() Then
            ds.Clear()
            mycmd = New SqlClient.SqlCommand(strsql, cn)
            da = New SqlClient.SqlDataAdapter(mycmd)
            da.Fill(ds, nm)
            dt = ds.Tables(0)
            drx = dt.Rows(0)
            'CloseCn()
            Return drx
            Exit Function
        End If
oops:
        MsgBox("Error Occured: " & Err.Description, MsgBoxStyle.Critical, "Error")
        Return Nothing
    End Function
    ' / Executes the sqlcommand with given transaction
    Public Function executesql(ByVal comnd As String, Optional ByVal tr1 As SqlTransaction = Nothing) As Boolean
        On Error GoTo oops
        Dim cmd1 As SqlClient.SqlCommand

        If OpenCn() = False Then
            Err.Raise(999, , "SQL Connectin")
        End If

        If Not tr1 Is Nothing Then
            cmd1 = New SqlClient.SqlCommand(comnd, cn, tr1) 'del
        Else
            cmd1 = New SqlClient.SqlCommand(comnd, cn)
        End If

        cmd1.ExecuteNonQuery()
        executesql = True

        Exit Function
oops:
        MsgBox(Err.Description)
        If Not tr1 Is Nothing Then
            tr1.Rollback()
            tr1.Dispose()
        End If
        executesql = False
    End Function

    ' / fills the given combobox with the given field of given table
    Public Sub FillCmb(ByVal Cmb As ComboBox, ByVal TblNm As String, ByVal FldNm As String, Optional ByVal selstr As String = "", Optional ByVal distct As Boolean = False)
        On Error GoTo oops
        Dim ndt As DataTable
        Dim i As Integer
        Dim t As UserControl
        Dim x As ListBox

        Cmb.Items.Clear()

        ndt = GetDtTab("select " & IIf(distct = True, "DISTINCT ", "") & FldNm & " from " & TblNm & IIf(selstr = "", "", " where " & selstr & ""), "forcmb")
        If Not ndt.Rows.Count < 1 Then
            For i = 0 To ndt.Rows.Count - 1
                Cmb.Items.Add(Trim(ndt.Rows(i).Item(0).ToString))
            Next
        End If

        Exit Sub
oops:
        MsgBox("Error Occured: " & Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub

    
End Class
