Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class GSTReport

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i, K As Integer
        Dim strFileName As String
        Dim Sqlstring As String
        '        xlApp = New Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        '       xlWorkSheet = xlWorkBook.Sheets("sheet1")

        ob.Execute("delete from TempVat", ob.getconnection())

        Sqlstring = "Select sum(Netamount) as Amt,sum(CGstamt) as Vatamt,sum(SGstamt) as addVatamt,sum(totamt) as Totalamount,Sum(qnty) as Qty,Billno,GSTNo,billDate,CGSTPER,SGSTPER,HSN_Code  from ShowVatReturn where billDate >= '" & ob.DateConversion(FrDt.Text) & "' and billDate <= '" & ob.DateConversion(Todt.Text) & "' Group by Billno,billdate,gstNo,CGSTPER,SGSTPER,HSN_Code"
        '    Sqlstring = "Select sum(Amount) as sum(Amount),sum(Vatamt) as sum(Vatamt),sum(AddVatamt) as sum(AddVatamt),sum(TotalAmount) as sum(TotalAmount),TransMode,TranNo,SecondAcId,TransDate,VatPer,AddVatper  from ShowVatReturn where TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "'   Group by TranNo,TransDate,SecondAcId,Vatper,AddVAtAmt,TransDate,AddVatper,TransMode "

        'Dim conn As New SqlConnection(SqlConnString)
        'Dim mycommand As New SqlCommand(Sqlstring, conn)
        'conn.Open()
        'Dim myreader As SqlDataReader = mycommand.ExecuteReader
        Dim dt As DataTable = ob.Returntable(Sqlstring, ob.getconnection())

        Dim mDate As Date
        Dim tdate As Date
        Dim tvat As Double
        Dim vat As Double
        Dim avat As Double
        Dim GST As String
        For i = 0 To dt.Rows.Count - 1
            mDate = dt.Rows(i).Item("Billdate") 'myreader.Item("").ToString
            vat = Format(Val(dt.Rows(i).Item("CGSTPER").ToString), "#0.00")
            avat = Format(Val(dt.Rows(i).Item("SGSTPER").ToString), "#0.00")
            tvat = Val(vat) + Val(avat)
            'Dim tid As String = ob.FindOneString("", ob.getconnection())
            'GST = Trim(dt.Rows(i).Item("GSTNo"))
            GST = 0

            Sqlstring = "Insert into TempVat(TranNo,TransDate,Amt,TotalAmount,Vat,HSN,Qty,VatAmt,AddVatAmt,GSTNO) Values ('" & Trim(dt.Rows(i).Item("Billno").ToString) & "','" & Format(mDate, "yyyy/MM/dd") & "'," & Val(dt.Rows(i).Item("Amt").ToString) & "," & Val(dt.Rows(i).Item("TotalAmount").ToString) & "," & Val(tvat) & ",'" & Trim(dt.Rows(i).Item("HSN_Code").ToString) & "'," & Val(dt.Rows(i).Item("Qty").ToString) & "," & Val(dt.Rows(i).Item("VatAmt").ToString) & "," & Val(dt.Rows(i).Item("AddVAtAmt").ToString) & ",'" & GST & "')"
            ob.Execute(Sqlstring, ob.getconnection())
        Next
        'conn.Close()
        'myreader = Nothing
        'mycommand = Nothing
        Refresh()

        strFileName = clsVariables.RptLocation & "\Templates\gstNEW.xls"
        xlWorkBook = xlApp.Workbooks.Add(strFileName)
        xlWorkSheet = xlApp.Sheets(6)


        '   Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
        Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt,VAT  from TempVat where Vat<>0 and GSTNo='24' Group by VAT "


        Dim col As Integer
        Dim ros As Integer
        col = 1
        ros = 5

        'Dim conn1 As New SqlConnection(SqlConnString)
        'Dim mycommand1 As New SqlCommand(Sqlstring, conn1)
        'mycommand1.CommandTimeout = 9000
        'conn1.Open()
        'Dim myreader1 As SqlDataReader = mycommand1.ExecuteReader
        Dim dts As DataTable = ob.Returntable(Sqlstring, ob.getconnection())

        Dim mAmt As Double


        For j As Integer = 0 To dts.Rows.Count - 1
            With xlWorkSheet
                i = i + 1
                .Cells(ros, 1) = "OE"
                .Cells(ros, 2) = "24-Gujarat"
                .Cells(ros, 3) = Val(dts.Rows(j).Item("Vat"))
                .Cells(ros, 4) = Val(dts.Rows(j).Item("TotalAmount").ToString)
                .Cells(ros, 5) = Val(dts.Rows(j).Item("CessAmt").ToString)
                .Cells(ros, 6) = ""

            End With
            ros = ros + 1
            If ros = 10000 Then
                xlApp.Visible = True
                Exit Sub
            End If
        Next






        xlWorkSheet = xlApp.Sheets(2)


        '                Sqlstring = "Select GSTNo,Name,Tranno,Transdate,Vat,sum(aMT) as Amt,sum(TotalAmount) as Totalamount,sum(CessAmt) as CessAmt  from TempVat where  GSTNo<>'' Group by GSTNo,Name,Tranno,Transdate,VAT "
        Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,VAT,GSTNo,TranNo,TransDate,Name  from TempVat where  GSTNo<>'24' Group by TranNo,TransDate,GSTNo,VAT,Name "


        col = 1
        ros = 5

        Dim dtk As DataTable = ob.Returntable(Sqlstring, ob.getconnection())

        '                Dim mAmt As Double


        For Ks As Integer = 0 To dtk.Rows.Count - 1
            With xlWorkSheet
                i = i + 1
                .Cells(ros, 1) = dtk.Rows(Ks).Item("GSTNo")
                .Cells(ros, 2) = dtk.Rows(Ks).Item("Name")
                .Cells(ros, 3) = dtk.Rows(Ks).Item("TranNo")
                .Cells(ros, 4) = Format(CDate(dtk.Rows(Ks).Item("TransDate")), "dd/MM/yyyy")
                .Cells(ros, 5) = Format(Val(dtk.Rows(Ks).Item("Amt")), "###.00")
                .Cells(ros, 6) = "24-Gujarat"
                .Cells(ros, 7) = "No"
                .Cells(ros, 8) = "Regular"

                .Cells(ros, 10) = Val(dtk.Rows(Ks).Item("Vat"))
                mAmt = Val(dtk.Rows(Ks).Item("TotalAmount"))
                mAmt = Math.Round(Val(mAmt))
                '    .Cells(ros, 5) = Format(mAmt, "#.00")
            End With

            ros = ros + 1
            If ros = 505 Then
                xlApp.Visible = True
                Exit Sub
            End If
        Next







        '   strFileName = MDIParent1.ReportSource & "\Templates\gst.xls"
        '  xlWorkBook = xlApp.Workbooks.Add(strFileName)
        xlWorkSheet = xlApp.Sheets(19)


        '    Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
        Sqlstring = "Select sum(AMT) as Amt,sum(Vatamt) as Vatamt,sum(AddVatamt) as addVatamt,sum(TotalAmount) as Totalamount,isnull(sum(CessAmt),0) as CessAmt,sum(QTY) as QTY,HSN,VAT  from tEMPvAT   Group by HSN,VAT "

        '   Dim col As Integer
        '   Dim ros As Integer
        col = 1
        ros = 5

        Dim dh As DataTable = ob.Returntable(Sqlstring, ob.getconnection())

        '                Dim mAmt As Double


        For ik As Integer = 0 To dh.Rows.Count - 1
            With xlWorkSheet
                i = i + 1
                .Cells(ros, 1) = dh.Rows(ik).Item("HSN")
                .Cells(ros, 2) = ""
                .Cells(ros, 3) = ""
                .Cells(ros, 4) = Format(Val(dh.Rows(ik).Item("Qty")), "###.00")
                .Cells(ros, 5) = Format(Val(dh.Rows(ik).Item("Amt")), "###.00")
                .Cells(ros, 6) = Val(dh.Rows(ik).Item("TotalAmount"))
                .Cells(ros, 7) = ""
                .Cells(ros, 8) = Val(dh.Rows(ik).Item("VatAmt"))
                .Cells(ros, 9) = Val(dh.Rows(ik).Item("AddVatAmt"))
                .Cells(ros, 10) = Val(dh.Rows(ik).Item("CessAmt"))

                ' .Cells(ros, 2) = Format(CDate(myreader1.Item("TransDate").ToString), "yyyy/MM/dd")

            End With
            ros = ros + 1
            If ros = 10000 Then
                xlApp.Visible = True
                Exit Sub
            End If
        Next






        xlWorkSheet = xlApp.Sheets(18)


        '   Sqlstring = "Select * from TempVat WHERE  TransDate >= '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "' order by TranNo "
        Sqlstring = "Select sum(aMT) as Amt,sum(TotalAmount) as Totalamount,VAT  from TempVat where Vat=0 Group by VAT "


        '   Dim col As Integer
        '   Dim ros As Integer
        col = 1
        ros = 8



        '     Dim mAmt As Double
        Dim dy As DataTable = ob.Returntable(Sqlstring, ob.getconnection())

        For ll As Integer = 0 To dy.Rows.Count - 1
            With xlWorkSheet
                i = i + 1
                .Cells(ros, 1) = "Inter-State supplies to unregistered persons"
                .Cells(ros, 2) = ""
                .Cells(ros, 3) = Val(dy.Rows(ll).Item("TotalAmount"))
                .Cells(ros, 4) = ""
            End With
            ros = ros + 1
            If ros = 10000 Then
                xlApp.Visible = True
                Exit Sub
            End If
        Next
        xlApp.Visible = True
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ob.Execute("delete from StockDetailn", ob.getconnection())
        'Dim dt As DataTable = ob.Returntable("select * from Vpurchase where DocDate >= '" & ob.DateConversion(FrDt.Text) & "' and DocDate <= '" & ob.DateConversion(Todt.Text) & "'", ob.getconnection())
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    ob.Execute("Insert Into StockDetailn(SDate, TotalAmount, VATPer, VATAmt, AddVATPer, AddVATAmt, Amount, StockType, SPLedgerId, SalesPurchase,Gpurchasetype) Values('" & (dt.Rows(i).Item("DocDate")) & "'," & dt.Rows(i).Item("totamt") & "," & dt.Rows(i).Item("CGSTper") & "," & dt.Rows(i).Item("cgstamt") & "," & dt.Rows(i).Item("SGSTper") & "," & dt.Rows(i).Item("sgstamt") & "," & dt.Rows(i).Item("netamount") & ",'Purchase',0,'Purchase','Purchase')", ob.getconnection())
        'Next
        Dim dts As DataTable = ob.Returntable("select * from  acstock where BillDate >= '" & ob.DateConversion(FrDt.Text) & "' and BillDate <= '" & ob.DateConversion(Todt.Text) & "' and ptype in ('purchase','sales')", ob.getconnection())

        For j As Integer = 0 To dts.Rows.Count - 1
            If dts.Rows(j).Item("ptype") = "sales" Then
                ob.Execute("Insert Into StockDetailn(SDate, TotalAmount, VATPer, VATAmt, AddVATPer, AddVATAmt, Amount, StockType, SPLedgerId, SalesPurchase,Gpurchasetype) Values('" & ob.DateConversion(dts.Rows(j).Item("BillDate")) & "'," & dts.Rows(j).Item("Basic") & "," & dts.Rows(j).Item("CGST") & "," & dts.Rows(j).Item("cgstamt") & "," & dts.Rows(j).Item("SGST") & "," & dts.Rows(j).Item("sgstamt") & "," & dts.Rows(j).Item("rate") * dts.Rows(j).Item("stockout") & ",'Sales',0,'Sales','Sales')", ob.getconnection())
            Else
                ob.Execute("Insert Into StockDetailn(SDate, TotalAmount, VATPer, VATAmt, AddVATPer, AddVATAmt, Amount, StockType, SPLedgerId, SalesPurchase,Gpurchasetype) Values('" & ob.DateConversion(dts.Rows(j).Item("BillDate")) & "'," & dts.Rows(j).Item("Basic") & "," & dts.Rows(j).Item("CGST") & "," & dts.Rows(j).Item("cgstamt") & "," & dts.Rows(j).Item("SGST") & "," & dts.Rows(j).Item("sgstamt") & "," & dts.Rows(j).Item("rate") * dts.Rows(j).Item("stockin") & ",'Purchase',0,'Purchase','Purchase')", ob.getconnection())

            End If
        Next
        clsVariables.ReportSql = ""
        clsVariables.FromDate = FrDt.Text
        clsVariables.ToDate = Todt.Text
        clsVariables.Repheader = "GST"
        clsVariables.ReportName = "GSTSumary.RPT"
        Dim frm As New Reportform
        frm.Show()
    End Sub
End Class