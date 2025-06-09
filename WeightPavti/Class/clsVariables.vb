Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Namespace CLS
    Public Class clsVariables
        Public Shared CompnyName As String
        Public Shared Repheader As String
        Public Shared WorkingYear As String
        Public Shared CompnyId As String
        Public Shared UserName As String
        Public Shared HelpId As String
        Public Shared HelpName As String
        Public Shared TbName As String
        Public Shared RtnHelpId As String
        Public Shared RtnHelpName As String
        Public Shared ImgPath As String
        Public Shared RojmalBankLoan As String
        Public Shared ScurrentSysDateFromate
        Public Shared sReqSysDateFormate = "MM/dd/yyyy"
        Public Shared Findqueri As String
        Public Shared findtablename As String
        Public Shared PassAccId As Integer
        Public Shared PassAccName As String
        'Public Shared CalcInt As Integer

        Public Shared dOpeningCashBalance As Double
        Public Shared dOpeningBankBalance As Double
        Public Shared dClosingCashBalance As Double
        Public Shared dClosingBankBalance As Double

        Public Shared HelpProd As String
        Public Shared HelpQual As String

        'SQL VARIABLES
        Public Shared sqlConnection As SqlConnection = New SqlConnection()
        Public Shared sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
        Public Shared sqlDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        Public Shared sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
        Public sqlCommand As SqlCommand = New SqlCommand()
        Public sqlDataReader As SqlDataReader
        Public Shared constr As String
        'DATASET VARIABLES
        Public sDataSet As DataSet = New DataSet()
        Public sdetailDataSet As DataSet = New DataSet()
        Public sSubDetailDataSet As DataSet = New DataSet()
        'Public datasetTables As dsTables = New dsTables()
        Public Shared sSearch As String
        Public Shared boolConnected As Boolean = False
        Public Shared nonNumberEntered As Boolean = False

        'Report Verialble

        Public Shared RDocSerId As Integer
        Public Shared RDocNo As Integer
        Public Shared RptLocation As String = ""
        Public Shared FromDate As String = ""
        Public Shared ToDate As String = ""
        Public Shared ReportName As String
        Public Shared ReportSql As String
        Public Shared ReportSql1 As String
        Public Shared RptTable As String
        Public Shared dOpeningBal As Double
        Public Shared dClosingBal As Double
        Public Shared NumtoWord As String
        Public Shared sDeptID As String
        Public Shared sdepartment As String
        Public Shared spint As String = ""

    End Class
End Namespace
