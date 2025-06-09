Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class FrmGSTSummaryReport
    Dim RasClass As New ProjSet
    Dim Sqlstring As String

    Private Sub FrmSalesBookReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent1
        'RasClass.ChkFrmName(Me.Name, Me.Text)
        ListView1.Items.Clear()
        ' ListView1.Items.Add("GST Khatar Summary Report")
        ' ListView1.Items.Add("GST Bhandar Summary Report")
        '  ListView1.Items.Add("GST Summary Report")
        ListView1.Items.Add("GSTR1 Report")


        FrDt.Text = Now()
        Todt.Text = Now()
        ListView1.Focus()
        Page.Text = 0
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim newRpt As New ReportDocument
        Dim Ii As Integer = -1

        If ListView1.SelectedItems.Count > 0 Then
            Ii = ListView1.SelectedItems(0).Index
        Else
            ListView1.Items(0).Selected = True
            Ii = ListView1.SelectedItems(0).Index
        End If
        RasClass.AddRecord("delete from TempVat")
        RasClass.AddRecord("delete from TempVatNo")


        Select Case Ii

            'Case 0 'Sales DetailReport
            '    newRpt.Load(MDIParent1.ReportSource + "\VatSumary.rpt")
            '    RasClass.SetDBLogonForReport(newRpt)
            '    '   RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
            '    newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
            '    newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
            '    Dim frmRptDisp As New rptdisp
            '    frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
            '    frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
            '    frmRptDisp.Show()

            Case 0 'Sales DetailReport
                Dim I As Integer = -1

                Dim xlApp As New Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                '  Dim i, K As Integer
                Dim strFileName As String
                '        xlApp = New Excel.ApplicationClass
                'xlWorkBook = xlApp.Workbooks.Add(misValue)
                '       xlWorkSheet = xlWorkBook.Sheets("sheet1")

                RasClass.AddRecord("delete from TempVat")

                Sqlstring = "Select sum(Amount) as Amt,sum(Vatamt) as Vatamt,sum(AddVatamt) as addVatamt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt,TransMode,TranNo,SecondAcId,TransDate,VatPer,AddVatper,qTY,hsn,ThirdAcId,AuthoName from ShowVatReturn where TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "'   Group by TranNo,TransDate,SecondAcId,Vatper,AddVAtAmt,CessAmt,TransDate,AddVatper,TransMode,qTY,hsn,ThirdAcId,AuthoName "

                Dim conn As New SqlConnection(SqlConnString)
                Dim mycommand As New SqlCommand(Sqlstring, conn)
                mycommand.CommandTimeout = 9000
                conn.Open()
                Dim myreader As SqlDataReader = mycommand.ExecuteReader

                Dim mDate As Date
                Dim tdate As Date
                Dim tvat As Double
                Dim vat As Double
                Dim avat As Double
                Dim cessp As Double
                While myreader.Read = True
                    mDate = myreader.Item("TransDate").ToString
                    vat = Format(Val(myreader.Item("Vatper").ToString), "#0.00")
                    avat = Format(Val(myreader.Item("AddVatper").ToString), "#0.00")
                    tvat = Val(vat) + Val(avat)

                    Sqlstring = "Insert into TempVat(TranNo,TransDate,SecondAcid,Amt,TotalAmount,Vat,qTY,hsn,VatAmt,AddVatAmt,CessAmt,GSTNo,Name) Values (" & Val(myreader.Item("TranNo").ToString) & ",'" & Format(mDate, "yyyy/MM/dd") & "','" & Trim(myreader.Item("SecondAcId").ToString) & "'," & Val(myreader.Item("Amt").ToString) & "," & Val(myreader.Item("TotalAmount").ToString) & "," & Val(tvat) & "," & Val(myreader.Item("qTY").ToString) & "," & Val(myreader.Item("hsn").ToString) & "," & Val(myreader.Item("VatAmt").ToString) & "," & Val(myreader.Item("AddVAtAmt").ToString) & "," & Val(myreader.Item("CessAmt").ToString) & ",'" & Trim(myreader.Item("ThirdAcId").ToString) & "','" & Trim(myreader.Item("AuthoName").ToString) & "')"
                    RasClass.AddRecord(Sqlstring)
                End While

                conn.Close()
                myreader = Nothing
                mycommand = Nothing
                Refresh()




                strFileName = MDIParent1.ReportSource & "\Templates\gstNEW.xls"
                xlWorkBook = xlApp.Workbooks.Add(strFileName)
                xlWorkSheet = xlApp.Sheets(6)


                '   Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
                Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt,VAT  from TempVat where Vat<>0 and GSTNo='' Group by VAT "


                Dim col As Integer
                Dim ros As Integer
                col = 1
                ros = 5

                Dim conn1 As New SqlConnection(SqlConnString)
                Dim mycommand1 As New SqlCommand(Sqlstring, conn1)
                mycommand1.CommandTimeout = 9000
                conn1.Open()
                Dim myreader1 As SqlDataReader = mycommand1.ExecuteReader

                Dim mAmt As Double


                While myreader1.Read = True
                    With xlWorkSheet
                        I = I + 1
                        .Cells(ros, 1) = "OE"
                        .Cells(ros, 2) = "24-Gujarat"
                        .Cells(ros, 3) = Val(myreader1.Item("Vat").ToString)
                        .Cells(ros, 4) = Val(myreader1.Item("TotalAmount").ToString)
                        .Cells(ros, 5) = Val(myreader1.Item("CessAmt").ToString)
                        .Cells(ros, 6) = ""

                    End With
                    ros = ros + 1
                    If ros = 10000 Then
                        xlApp.Visible = True
                        Exit Sub
                    End If
                End While






                xlWorkSheet = xlApp.Sheets(2)


                '                Sqlstring = "Select GSTNo,Name,Tranno,Transdate,Vat,sum(aMT) as Amt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt  from TempVat where  GSTNo<>'' Group by GSTNo,Name,Tranno,Transdate,VAT "
                Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,VAT,GSTNo,TranNo,TransDate,Name  from TempVat where  GSTNo<>'' Group by TranNo,TransDate,GSTNo,VAT,Name "


                col = 1
                ros = 5

                Dim conn11 As New SqlConnection(SqlConnString)
                Dim mycommand11 As New SqlCommand(Sqlstring, conn11)
                conn11.Open()
                Dim myreader11 As SqlDataReader = mycommand11.ExecuteReader

                '                Dim mAmt As Double


                While myreader11.Read = True
                    With xlWorkSheet
                        I = I + 1
                        .Cells(ros, 1) = myreader11.Item("GSTNo").ToString
                        .Cells(ros, 2) = myreader11.Item("Name").ToString
                        .Cells(ros, 3) = myreader11.Item("TranNo").ToString
                        .Cells(ros, 4) = Format(CDate(myreader11.Item("TransDate").ToString), "dd/MM/yyyy")
                        .Cells(ros, 5) = Format(Val(myreader11.Item("Amt").ToString), "###.00")
                        .Cells(ros, 6) = "24-Gujarat"
                        .Cells(ros, 7) = "No"
                        .Cells(ros, 8) = "Regular"

                        .Cells(ros, 10) = Val(myreader11.Item("Vat").ToString)
                        mAmt = Val(myreader11.Item("TotalAmount").ToString)
                        mAmt = Math.Round(Val(mAmt))
                        '    .Cells(ros, 5) = Format(mAmt, "#.00")
                    End With

                    ros = ros + 1
                    If ros = 505 Then
                        xlApp.Visible = True
                        Exit Sub
                    End If
                End While







                '   strFileName = MDIParent1.ReportSource & "\Templates\gst.xls"
                '  xlWorkBook = xlApp.Workbooks.Add(strFileName)
                xlWorkSheet = xlApp.Sheets(19)


                '    Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
                Sqlstring = "Select sum(AMT) as Amt,sum(Vatamt) as Vatamt,sum(AddVatamt) as addVatamt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt,sum(QTY) as QTY,HSN,VAT  from tEMPvAT   Group by HSN,VAT "

                '   Dim col As Integer
                '   Dim ros As Integer
                col = 1
                ros = 5

                Dim conn2 As New SqlConnection(SqlConnString)
                Dim mycommand2 As New SqlCommand(Sqlstring, conn2)
                mycommand2.CommandTimeout = 9000
                conn2.Open()
                Dim myreader2 As SqlDataReader = mycommand2.ExecuteReader

                '                Dim mAmt As Double


                While myreader2.Read = True
                    With xlWorkSheet
                        I = I + 1
                        .Cells(ros, 1) = myreader2.Item("HSN").ToString
                        .Cells(ros, 2) = ""
                        .Cells(ros, 3) = ""
                        .Cells(ros, 4) = Format(Val(myreader2.Item("Qty").ToString), "###.00")
                        .Cells(ros, 5) = Format(Val(myreader2.Item("Amt").ToString), "###.00")
                        .Cells(ros, 6) = Val(myreader2.Item("TotalAmount").ToString)
                        .Cells(ros, 7) = ""
                        .Cells(ros, 8) = Val(myreader2.Item("VatAmt").ToString)
                        .Cells(ros, 9) = Val(myreader2.Item("AddVatAmt").ToString)
                        .Cells(ros, 10) = Val(myreader2.Item("CessAmt").ToString)

                        ' .Cells(ros, 2) = Format(CDate(myreader1.Item("TransDate").ToString), "yyyy/MM/dd")

                    End With
                    ros = ros + 1
                    If ros = 10000 Then
                        xlApp.Visible = True
                        Exit Sub
                    End If
                End While






                xlWorkSheet = xlApp.Sheets(18)


                '   Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
                Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,VAT  from TempVat where Vat=0 Group by VAT "


                '   Dim col As Integer
                '   Dim ros As Integer
                col = 1
                ros = 8

                Dim conn3 As New SqlConnection(SqlConnString)
                Dim mycommand3 As New SqlCommand(Sqlstring, conn3)
                mycommand3.CommandTimeout = 9000
                conn3.Open()
                Dim myreader3 As SqlDataReader = mycommand3.ExecuteReader

                '     Dim mAmt As Double


                While myreader3.Read = True
                    With xlWorkSheet
                        I = I + 1
                        .Cells(ros, 1) = "Inter-State supplies to unregistered persons"
                        .Cells(ros, 2) = ""
                        .Cells(ros, 3) = Val(myreader3.Item("TotalAmount").ToString)
                        .Cells(ros, 4) = ""
                    End With
                    ros = ros + 1
                    If ros = 10000 Then
                        xlApp.Visible = True
                        Exit Sub
                    End If
                End While





                conn.Close()
                myreader = Nothing
                mycommand = Nothing
                conn = Nothing
                xlApp.Visible = True



            Case 4 'Sales DetailReport
                newRpt.Load(MDIParent1.ReportSource + "\DailyCreditSalesReportBhandar.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))

                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag), "ProductWiseReport")
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "ProductWiseReport")
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "ProductWiseReport")

                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "ItemWiseReport")
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "ItemWiseReport")
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag), "ItemWiseReport")
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "ItemWiseReport")
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "ItemWiseReport")



                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()


            Case 5 'Sales DetailReport
                newRpt.Load(MDIParent1.ReportSource + "\DailyCashCreditSalesReportBhandar.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))

                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag), "ProductWiseReport")
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "ProductWiseReport")
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "ProductWiseReport")

                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "ItemWiseReport")
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "ItemWiseReport")
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag), "ItemWiseReport")
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "ItemWiseReport")
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "ItemWiseReport")



                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()


                'Case 2 'Sales DetailReport
                '    newRpt.Load(MDIParent1.ReportSource + "\DailyKarajkhatReport.rpt")
                '    RasClass.SetDBLogonForReport(newRpt)
                '    RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                '    newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                '    newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                '    newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                '    newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                '    newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))

                '    newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                '    newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "ProductWiseReport")
                '    newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag), "ProductWiseReport")
                '    newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "ProductWiseReport")
                '    newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "ProductWiseReport")

                '    RasClass.SetDBLogonForReport(newRpt)
                '    Dim frmRptDisp As New rptdisp
                '    frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                '    frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                '    frmRptDisp.Show()

                'Case 3 'Sales DetailReport
                '    newRpt.Load(MDIParent1.ReportSource + "\SalesDetailReport.rpt")
                '    RasClass.SetDBLogonForReport(newRpt)
                '    RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                '    newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                '    newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                '    newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                '    newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                '    newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                '    Dim frmRptDisp As New rptdisp
                '    frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                '    frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                '    frmRptDisp.Show()
            Case 6 'Sales Summary Report 
                newRpt.Load(MDIParent1.ReportSource + "\SalesSummaryReport.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()
            Case 7 'Sales VAT Register
                newRpt.Load(MDIParent1.ReportSource + "\SalesVATRegister.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()
            Case 8 'Sales Monthly Summary 
                newRpt.Load(MDIParent1.ReportSource + "\SalesMonthlySummary.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()
            Case 9 'Sales VAT % Monthly Summary 
                newRpt.Load(MDIParent1.ReportSource + "\SalesVATPercMonthlySummary.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@Sabhasadid", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()
            Case 10 'Sales Summary Report 
                newRpt.Load(MDIParent1.ReportSource + "\SalesSummary.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                '  newRpt.SetParameterValue("@Sabhasadid", Val(SabhasadName.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                '  newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag))
                newRpt.SetParameterValue("Page", Page.Text)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"), "SalesSub")
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"), "SalesSub")
                ' newRpt.SetParameterValue("@Sabhasadid", Val(SabhasadName.Tag), "SalesSub")
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag), "SalesSub")
                ' newRpt.SetParameterValue("@AccountId", Val(AccountName.Tag), "SalesSub")
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()

            Case 11 'Sabhasad Rebate Report
                newRpt.Load(MDIParent1.ReportSource + "\RebateReport.rpt")
                RasClass.SetDBLogonForReport(newRpt)
                RasClass.AddVale(MDIParent1.MCompanyName, newRpt.ParameterFields("Company").CurrentValues)
                newRpt.SetParameterValue("@FromDt", Format(CDate(Me.FrDt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@ToDt", Format(CDate(Me.Todt.Text), "yyyy/MM/dd"))
                newRpt.SetParameterValue("@AccountId", Val(sABHASADnAME.Tag))
                newRpt.SetParameterValue("@ItemId", Val(ItemName.Tag))
                newRpt.SetParameterValue("@FinYear", MDIParent1.FinYear)
                RasClass.SetDBLogonForReport(newRpt)
                Dim frmRptDisp As New rptdisp
                frmRptDisp.CrystalReportViewer1.ReportSource = newRpt
                frmRptDisp.Text = frmRptDisp.Text + ListView1.SelectedItems(0).Text
                frmRptDisp.Show()
        End Select
    End Sub

    Private Sub sABHASADnAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles sABHASADnAME.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub SabhasadName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles sABHASADnAME.KeyUp
        If e.KeyCode = Keys.F2 Then
            MDIParent1.HelpString = "select Name,code,City from ShowSabhasad Order By Name"
            MDIParent1.HelpFilter = "name like '%" + sABHASADnAME.Text + "%'"
            FrmHelp.ShowDialog()
            sABHASADnAME.Text = MDIParent1.HelpString
            sABHASADnAME.Tag = MDIParent1.Helpid
        End If

    End Sub
    Private Sub SabhasadName_Validatig(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sABHASADnAME.Validating
        sABHASADnAME.Tag = RasClass.GetValue("Select code from Sabhasadmaster where name='" & sABHASADnAME.Text & "' or code=" & Val(sABHASADnAME.Text) & "")
        If Val(sABHASADnAME.Tag) <> 0 Then
            sABHASADnAME.Text = RasClass.GetValue("Select name from Sabhasadmaster where code=" & Val(sABHASADnAME.Tag) & "")
        End If

    End Sub

    Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub ItemName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyUp
        If e.KeyCode = Keys.F2 Then
            MDIParent1.HelpString = "select Name,itemCODE from Itemmaster Order By Name"
            MDIParent1.HelpFilter = "name like '%" + ItemName.Text + "%'"
            FrmHelp.ShowDialog()
            ItemName.Text = MDIParent1.HelpString
            ItemName.Tag = MDIParent1.Helpid
        End If

    End Sub
    Private Sub ItemName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Validating
        ItemName.Tag = RasClass.GetValue("Select itemcode from Itemmaster where name='" & ItemName.Text & "' or itemcode=" & Val(ItemName.Text) & "")
        If Val(ItemName.Tag) <> 0 Then
            ItemName.Text = RasClass.GetValue("Select name from Itemmaster where itemcode=" & Val(ItemName.Tag) & "")
        End If
        'If Val(ItemName.Tag) = 0 Then
        '    MDIParent1.HelpString = "select Name,itemCODE from Itemmaster Order By Name"
        '    MDIParent1.HelpFilter = "name like '%" + ItemName.Text + "%'"
        '    FrmHelp.ShowDialog()
        '    ItemName.Text = MDIParent1.HelpString
        '    ItemName.Tag = MDIParent1.Helpid
        'End If
    End Sub
    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub ListView1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.LostFocus
        '       ListView1.Items(ListView1.FocusedItem.Index).Selected = True
    End Sub

    Private Sub frDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrDt.GotFocus
        FrDt.SelectionStart = 0
        'FrDt.SelectionLength = Len(FrDt.Text)
    End Sub

    Private Sub toDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Todt.GotFocus
        Todt.SelectionStart = 0
        'Todt.SelectionLength = Len(Todt.Text)
    End Sub
    Private Sub FrDt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FrDt.KeyPress
        DateinsertMode(FrDt, AscW(ChrW(AscW(e.KeyChar))))
    End Sub
    Private Sub ToDt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Todt.KeyPress
        DateinsertMode(Todt, AscW(ChrW(AscW(e.KeyChar))))
    End Sub

    Private Sub toDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Todt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub frDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FrDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub AccountName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            '            MDIParent1.HelpString = "select Name,CODE,City from AcMaster where code not in (Select AcmasterId from SabhasadMAster) Order By Name"
            MDIParent1.HelpString = "select Name,CODE,City from AcMaster order By Name"
            MDIParent1.HelpFilter = "name like '%" + AccountName.Text + "%'"
            FrmHelp.ShowDialog()
            AccountName.Text = MDIParent1.HelpString
            AccountName.Tag = MDIParent1.Helpid
        End If

    End Sub

    Private Sub AccountName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        AccountName.Tag = RasClass.GetValue("Select code from Acmaster where name='" & AccountName.Text & "' or code=" & Val(AccountName.Text) & "")
        If Val(AccountName.Tag) <> 0 Then
            AccountName.Text = RasClass.GetValue("Select name from Acmaster where code=" & Val(AccountName.Tag) & "")
        End If
    End Sub

    Private Sub FrDt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrDt.LostFocus
        Todt.Text = FrDt.Text
    End Sub

    Private Sub ItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AccountName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AccountName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub branchcode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles branchcode.Validated
        If Val(branchcode.Text) = 1 Then
            name.Text = "Head Office"
        ElseIf Val(branchcode.Text) = 2 Then
            name.Text = "Petrol Pump"
        ElseIf Val(branchcode.Text) = 3 Then
            name.Text = "Sharpor"
        ElseIf Val(branchcode.Text) = 4 Then
            name.Text = "Butlav"
        ElseIf Val(branchcode.Text) = 5 Then
            name.Text = "Mahudi"
        ElseIf Val(branchcode.Text) = 6 Then
            name.Text = "Kumbhar Faliya"
        End If

    End Sub

    Private Sub branchcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles branchcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub branchcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles branchcode.TextChanged

    End Sub
End Class