Imports WeightPavti.CLS
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Class Reportform

    Public Sub FillPrinter()
        Try
            Dim pkInstalledPrinters As String
            For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
                cboInstalledPrinters.Items.Add(pkInstalledPrinters)
            Next pkInstalledPrinters

            ' Set the combo to the first printer in the list
            Dim ps As New PrinterSettings()
            cboInstalledPrinters.Text = ps.PrinterName
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub FillSize()
        Try
            'Dim prn As PrinterSettings
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FillPrinter()
        Try
            With CrystalReportViewer1

            End With
            Me.Text = clsVariables.Repheader & "                                              Report File Name : " & clsVariables.ReportName
            'If rpttype = "" Then
            '    Dim ds As DataSet = New DataSet()
            '    Dim adpt As SqlDataAdapter = New SqlDataAdapter
            '    sCommands.setsqlCommand(ds, adpt, clsVariables.ReportSql, clsVariables.RptTable)
            '    Dim report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            '    If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
            '        MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Close()
            '        Exit Sub
            '    End If
            '    report.Load(clsVariables.RptLocation & clsVariables.ReportName)
            '    report.SetDataSource(ds)
            '    report.SetParameterValue("@CompanyName", clsVariables.CompnyName)
            '    report.SetParameterValue("@Repheader", clsVariables.Repheader)
            '    report.SetParameterValue("@fromdate", clsVariables.FromDate)
            '    report.SetParameterValue("@Todate", clsVariables.ToDate)
            '    CrystalReportViewer1.ReportSource = report
            'Else
            If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
                MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            End If
            'Dim pf As New ParameterFields
            'Dim pf1 As New ParameterField
            'Dim pv1 As New ParameterValues
            'pf1.Name = "@CompanyName"
            'pv1.AddValue(clsVariables.CompnyName)
            'pf1.CurrentValues = pv1
            'pf.Add(pf1)
            'Dim pf2 As New ParameterField
            'Dim pv2 As New ParameterValues
            'pf2.Name = "@RepHeader"
            'pv2.AddValue(clsVariables.Repheader)
            'pf2.CurrentValues = pv2
            'pf.Add(pf2)
            'Dim pf3 As New ParameterField
            'Dim pv3 As New ParameterValues
            'pf3.Name = "@fromDate"
            'pv3.AddValue(clsVariables.FromDate)
            'pf3.CurrentValues = pv3
            'pf.Add(pf3)
            'Dim pf4 As New ParameterField
            'Dim pv4 As New ParameterValues
            'pf4.Name = "@toDate"
            'pv4.AddValue(clsVariables.ToDate)
            'pf4.CurrentValues = pv4
            'pf.Add(pf4)
            'If LCase(clsVariables.ReportName) = LCase("FinalTarijTrialBalance.rpt") Or LCase(clsVariables.ReportName) = LCase("FinalTarijReport.rpt") Or LCase(clsVariables.ReportName) = LCase("FundProfitLossAccount.rpt") Or LCase(clsVariables.ReportName) = LCase("FinalBalanceSheet.rpt") Or LCase(clsVariables.ReportName) = LCase("FinalBalanceSheettFormat.rpt") Or LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
            '    Dim pf5 As New ParameterField
            '    Dim pv5 As New ParameterValues
            '    pf5.Name = "@OpeningBal"
            '    pv5.AddValue(clsVariables.dOpeningBal)
            '    pf5.CurrentValues = pv5
            '    pf.Add(pf5)
            '    Dim pf6 As New ParameterField
            '    Dim pv6 As New ParameterValues
            '    pf6.Name = "@ClosingBal"
            '    pv6.AddValue(clsVariables.dClosingBal)
            '    pf6.CurrentValues = pv6
            '    pf.Add(pf6)
            'End If
            'If LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
            '    Dim pf7 As New ParameterField
            '    Dim pv7 As New ParameterValues
            '    pf7.Name = "@NumtoWord"
            '    pv7.AddValue(clsVariables.NumtoWord)
            '    pf7.CurrentValues = pv7
            '    pf.Add(pf7)
            'End If
            'If LCase(clsVariables.ReportName) = LCase("LoanNPAReportNewDetailedSecure.rpt") Or LCase(clsVariables.ReportName) = LCase("LoanNPAReportNewDetailed.rpt") Or LCase(clsVariables.ReportName) = LCase("LoanNPAReportNewSecure.rpt") Or LCase(clsVariables.ReportName) = LCase("LoanNPAReportNew.rpt") Then
            '    Dim pf21 As New ParameterField
            '    Dim pv21 As New ParameterValues
            '    pf21.Name = "@Slab1"
            '    pv21.AddValue(Slab1)
            '    pf21.CurrentValues = pv21
            '    pf.Add(pf21)
            '    Dim pf22 As New ParameterField
            '    Dim pv22 As New ParameterValues
            '    pf22.Name = "@Slab2"
            '    pv22.AddValue(Slab2)
            '    pf22.CurrentValues = pv22
            '    pf.Add(pf22)
            '    Dim pf23 As New ParameterField
            '    Dim pv23 As New ParameterValues
            '    pf23.Name = "@Slab3"
            '    pv23.AddValue(Slab3)
            '    pf23.CurrentValues = pv23
            '    pf.Add(pf23)
            '    Dim pf24 As New ParameterField
            '    Dim pv24 As New ParameterValues
            '    pf24.Name = "@Slab4"
            '    pv24.AddValue(Slab4)
            '    pf24.CurrentValues = pv24
            '    pf.Add(pf24)
            '    Dim pf25 As New ParameterField
            '    Dim pv25 As New ParameterValues
            '    pf25.Name = "@Slab5"
            '    pv25.AddValue(Slab5)
            '    pf25.CurrentValues = pv25
            '    pf.Add(pf25)
            '    Dim pf26 As New ParameterField
            '    Dim pv26 As New ParameterValues
            '    pf26.Name = "@Slab6"
            '    pv26.AddValue(Slab6)
            '    pf26.CurrentValues = pv26
            '    pf.Add(pf26)
            'End If
            Dim crtableLogoninfos As New TableLogOnInfos()
            Dim crtableLogoninfo As New TableLogOnInfo()
            Dim crConnectionInfo As New ConnectionInfo()
            Dim CrTables As Tables
            Dim CrTable As Table
            Dim crReportDocument As New ReportDocument()
            crReportDocument.Load(clsVariables.RptLocation & clsVariables.ReportName)
            Dim i As Integer
            i = 0
            If LCase(clsVariables.ReportName) <> LCase("NewRojmalReport.rpt") And LCase(clsVariables.ReportName) <> LCase("NewRojmalReportDailydetail.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalTrialBalanceTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalBalanceSheetTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("NewRojmalReportDaily.rpt") Then
                'If LCase(clsVariables.ReportName) <> LCase("NewRojmalReport.rpt") And LCase(clsVariables.ReportName) <> LCase("BankBookReport.rpt") Or LCase(clsVariables.ReportName) = LCase("ItemSummaryReport.rpt") Or LCase(clsVariables.ReportName) = LCase("CottonreceiptReport.rpt") Or LCase(clsVariables.ReportName) = LCase("CanereceiptReport.rpt") Then
                If LCase(clsVariables.ReportName) = LCase("OfficeReport.Rpt") Or LCase(clsVariables.ReportName) = LCase("JaminDetailReport.Rpt") Then
                    Do While i < crReportDocument.Subreports.Count
                        crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql1
                        i += 1
                    Loop
                Else
                    Do While i < crReportDocument.Subreports.Count
                        crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql
                        i += 1
                    Loop
                End If

            End If
            With crConnectionInfo
                .ServerName = "assdsn"
                .DatabaseName = dbname
                If DbAuth <> "WIN" Then
                    .UserID = "advsys"
                    .Password = "advsys"
                End If
            End With
            CrTables = crReportDocument.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            crReportDocument.VerifyDatabase()
            'If LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
            '    crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
            'End If
            i = 0
            Do While i < crReportDocument.ParameterFields.Count
                If LCase(crReportDocument.ParameterFields(i).Name) = LCase("@CompanyName") Then
                    crReportDocument.SetParameterValue(i, clsVariables.CompnyName)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@RepHeader") Then
                    crReportDocument.SetParameterValue(i, clsVariables.Repheader)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@fromDate") Then
                    crReportDocument.SetParameterValue(i, clsVariables.FromDate)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@toDate") Then
                    crReportDocument.SetParameterValue(i, clsVariables.ToDate)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@OpeningBal") Then
                    crReportDocument.SetParameterValue(i, clsVariables.dOpeningBal)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@ClosingBal") Then
                    crReportDocument.SetParameterValue(i, clsVariables.dClosingBal)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@NumtoWord") Then
                    crReportDocument.SetParameterValue(i, clsVariables.NumtoWord)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Year_Id") Then
                    crReportDocument.SetParameterValue(i, clsVariables.WorkingYear)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab1") Then
                    crReportDocument.SetParameterValue(i, Slab1)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab2") Then
                    crReportDocument.SetParameterValue(i, Slab2)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab3") Then
                    crReportDocument.SetParameterValue(i, Slab3)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab4") Then
                    crReportDocument.SetParameterValue(i, Slab4)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Username") Then
                    crReportDocument.SetParameterValue(i, clsVariables.UserName)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab6") Then
                    crReportDocument.SetParameterValue(i, Slab6)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@SabhasadId") Then
                    crReportDocument.SetParameterValue(i, Val(clsVariables.PassAccId))
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@FromDt") Then
                    crReportDocument.SetParameterValue(i, clsVariables.FromDate)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@ToDt") Then
                    crReportDocument.SetParameterValue(i, clsVariables.ToDate)
                ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@AccountId") Then
                    crReportDocument.SetParameterValue(i, Val(clsVariables.RDocNo))
                End If
                i += 1
            Loop
            'CrystalReportViewer1.ParameterFieldInfo = pf

            CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
            CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
            'End If

            rpttype = ""
            'End If

            CrystalReportViewer1.Zoom(100)
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        CrystalReportViewer1.PrintReport()
    End Sub
End Class