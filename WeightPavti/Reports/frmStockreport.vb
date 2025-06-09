Imports WeightPavti.CLS
Imports System.Data
Imports System.Data.SqlClient
Public Class frmStockreport


    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dg.Columns.Add("Report", "Report")
        Dg.Columns(0).Width = 350
        Dim item As New ListViewItem
        item = Dg.Items.Add("Stock Ledger Report")
        item = Dg.Items.Add("Stock Ledger Report Bhandar")
        item = Dg.Items.Add("Stock Summary Report")
        item = Dg.Items.Add("Cost Wise Stock Summary Report")
        item = Dg.Items.Add("Cost Wise Stock Summary Report Bhandar")
        item = Dg.Items.Add("Stock Summary Report Bhandar")
        item = Dg.Items.Add("Stock Summary Report Bhandar Barcode")
        item = Dg.Items.Add("Stock Summary Report Rajubhai")
        item = Dg.Items.Add("Stock Summary Report TAN")


        'item = Dg.Items.Add("Account Ledger Report Cash")


        dg1.Columns.Add("", "")
        Panel1.Visible = False

        'item.SubItems.Add("")
        'item.SubItems(1).Text = ""
        auto()
        autoname()
        autotwo()
        autogroup()
        TxtfromDate.Text = Format(Now, "dd/MM/yyyy") '"01/04/2020"

        TxtToDate.Text = Format(Now, "dd/MM/yyyy")

    End Sub
    Public Sub autogroup()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Product_id,Product_Name from Product_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Product_Name"))
        Next
        groupname.AutoCompleteMode = AutoCompleteMode.Suggest
        groupname.AutoCompleteSource = AutoCompleteSource.CustomSource
        groupname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Item_Name from Item_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Item_Name"))
        Next
        itemname.AutoCompleteMode = AutoCompleteMode.Suggest
        itemname.AutoCompleteSource = AutoCompleteSource.CustomSource
        itemname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autotwo()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        Tomonth.AutoCompleteMode = AutoCompleteMode.Suggest
        Tomonth.AutoCompleteSource = AutoCompleteSource.CustomSource
        Tomonth.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autoname()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        txtproduct.AutoCompleteMode = AutoCompleteMode.Suggest
        txtproduct.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtproduct.AutoCompleteCustomSource = AutoComp
    End Sub
    Private Sub txtproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproduct.Validated
        If txtproduct.Text <> "" Then
            If IsNumeric(txtproduct.Text) Then
                Dim trn As DataTable = ob.Returntable("Select * from Transfer Where Houseno=" & txtproduct.Text & " Order By Tharavno desc", ob.getconnection())
                If trn.Rows.Count > 0 Then
                    txtproduct.Text = trn.Rows(0).Item("tname")
                    txtproduct.Tag = trn.Rows(0).Item("tid")
                Else
                    txtproduct.Tag = ob.FindOneinteger("select Party_id From Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                    txtproduct.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & txtproduct.Text & "", ob.getconnection())
                End If
                'lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & txtproduct.Tag & "", ob.getconnection())
            Else
                Dim dt As DataTable = ob.Returntable("select gstno From Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                If dt.Rows.Count >= 2 Then
                    If dg1.Rows.Count > 0 Then
                        dg1.Rows.Clear()
                    End If
                    Panel1.Visible = True
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dg1.Rows.Add()
                        dg1.Rows(dg1.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("gstno")
                    Next
                    Exit Sub
                Else
                    txtproduct.Tag = ob.FindOneinteger("Select Party_id from Party_master where Party_name='" & txtproduct.Text & "'", ob.getconnection())
                End If
                '  lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & txtproduct.Tag & "", ob.getconnection())
            End If
            'autonn()
            'utstnding()
            'loaddg()
        End If
    End Sub

    Private Sub itemname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemname.Validated
        If itemname.Text <> "" Then
            '   itemname.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & itemname.Text & "'", ob.getconnection())
            itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
            itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ssql As String = ""

        'clsVariables.dOpeningBal = 0
        'clsVariables.dClosingBal = 0
        'If Dg.Items(0).Selected = False Then
        '    Dg.Items(0).Selected = True
        'End If
        ' ob.Execute("Delete from tmpACData", ob.getconnection())
        'ob.Execute("Insert Into tmpACData select * from ACData where Year_id='" & clsVariables.WorkingYear & "' and Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "'", ob.getconnection())
        'Dim dtcfee As DataTable = ob.Returntable("select  Docno, Docdate, Id, Name,sum(Amount) as amount,sum(Dramt) as Dramt from sdata where Docdate between '" & ob.DateConversion(TxtfromDate.Text) & "' and '" & ob.DateConversion(TxtToDate.Text) & "' Group By Docno, Docdate, Id, Name", ob.getconnection())
        'If dtcfee.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtcfee.Rows.Count - 1
        '        ob.Execute("INSERT INTO tmpACData(Cid, Year_id, Type,Docdate,Docno, ACid, Acname, Cramt, Dramt) Values (1,'2020-2021','Maintenance','" & ob.DateConversion(dtcfee.Rows(i).Item("Docdate")) & "'," & Val(dtcfee.Rows(i).Item("Docno")) & ",10,'" & Trim(dtcfee.Rows(i).Item("Name")) & "'," & dtcfee.Rows(i).Item("Amount") & "," & dtcfee.Rows(i).Item("Dramt") & ")", ob.getconnection())
        '    Next
        'End If

        '   If Dg.SelectedItems(0).SubItems(0).Text = "Account Ledger" Then
        'ssql = "{ACData.Docdate}>=#" & ob.DateConversion(TxtfromDate.Text) & "#"
        'ssql = ssql & " and {ACData.Docdate}<=#" & ob.DateConversion(TxtToDate.Text) & "#"
        'If Val(Acname.Tag) > 0 Then
        '    ssql = ssql & " and {ACData.ACId}=" & Val(Acname.Tag) & ""  
        'End If
        If Dg.SelectedItems(0).SubItems(0).Text = "Stock Ledger Report" Then
            stock(False)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Stock Report"
            clsVariables.ReportName = "ItemLedgerReport.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Ledger Report Bhandar" Then
            stockbhandar()
            'ssql = "{stock.ip_Address}=" & aq(IPAddress)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.UserName = IPAddress
            clsVariables.Repheader = "Stock Report"
            If chkfast.Checked = False Then
                clsVariables.ReportName = "ItemLedgerReportbhandar.rpt"
            Else
                clsVariables.ReportName = "ItemLedgerReportbhandarfast.rpt"
            End If
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Summary Report" Then
            stock(False)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Stock Report"
            clsVariables.ReportName = "ItemStatusReport.rpt"
            Dim frm As New Reportform
            frm.Show() 'Cost Wise Stock Summary Report
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Cost Wise Stock Summary Report" Then
            stock(False)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Stock Report"
            clsVariables.ReportName = "ItemStatusReportcost.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Summary Report Bhandar" Then
            stockbhandar()
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.UserName = IPAddress
            clsVariables.Repheader = "Stock Report"
            If chkfast.Checked = False Then
                clsVariables.ReportName = "ItemStatusReportbhandar.rpt"
            Else
                clsVariables.ReportName = "ItemStatusReportbhandarfast.rpt"
            End If
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Summary Report Bhandar Barcode" Then
            stockbhandar()
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.UserName = IPAddress
            clsVariables.Repheader = "Stock Report"
            If chkfast.Checked = False Then
                clsVariables.ReportName = "ItemStatusReportcostbhandarbarcode.rpt"
            Else
                clsVariables.ReportName = "ItemStatusReportcostbhandarbarcodefast.rpt"
            End If
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Summary Report Rajubhai" Then
            stock(False)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Stock Report"
            clsVariables.ReportName = "ItemStatusReportrajubhai.rpt"
            Dim frm As New Reportform
            frm.Show()
        ElseIf Dg.SelectedItems(0).SubItems(0).Text = "Stock Summary Report TAN" Then
            stock(True)
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.Repheader = "Stock Report"
            clsVariables.ReportName = "ItemStatusReportTAN.rpt"
            Dim frm As New Reportform
            frm.Show()
        Else
            stockbhandar()
            ssql = ""
            clsVariables.ReportSql = ssql
            clsVariables.FromDate = TxtfromDate.Text
            clsVariables.ToDate = TxtToDate.Text
            clsVariables.UserName = IPAddress
            clsVariables.Repheader = "Stock Report"
            If chkfast.Checked = False Then
                clsVariables.ReportName = "ItemStatusReportcostbhandar.rpt"
            Else
                clsVariables.ReportName = "ItemStatusReportcostbhandarfast.rpt"
            End If
            Dim frm As New Reportform
            frm.Show()
        End If
    End Sub
    Dim gRojmel As String = "Rojmel"
    Public Sub stock(ByVal tan As Boolean)
        Dim sttime As DateTime
        Dim edtime As DateTime
        sttime = Now
        ob.Execute("delete from Stockreport", ob.getconnection())
        ob.Execute("delete from Stock", ob.getconnection())
        Dim dt As DataTable
        If Val(itemname.Tag) <> 0 Then
            dt = ob.Returntable("select * from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "'", ob.getconnection())

        Else
            dt = ob.Returntable("select * from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'", ob.getconnection())
        End If
        For id As Integer = 0 To dt.Rows.Count - 1
            If Val(dt.Rows(id).Item("stockin")) <> 0 Then
                ob.Execute("Insert into Stockreport(ItemId, SalesPurchase, TransDate, Qty, Tranno) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockin") & "," & dt.Rows(id).Item("Billno") & ")", ob.getconnection())
            Else
                ob.Execute("Insert into Stockreport(ItemId, SalesPurchase, TransDate, Qty, Tranno) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockout") & "," & dt.Rows(id).Item("Billno") & ")", ob.getconnection())
            End If
        Next
        If TxtfromDate.Text <> gFinYearBegin Then
            Dim cs As DataTable
            If Val(itemname.Tag) <> 0 Then
                cs = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "'  and ptype<>'Purchase' and year_id='" & clsVariables.WorkingYear & "' Group by Itemid", ob.getconnection())
            Else
                cs = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  and ptype<>'Purchase' and year_id='" & clsVariables.WorkingYear & "' Group by Itemid", ob.getconnection())
            End If
            For ics As Integer = 0 To cs.Rows.Count - 1

                ob.Execute("Insert into Stockreport(ItemId, SalesPurchase, TransDate, Qty, Tranno) values(" & cs.Rows(ics).Item("Itemid") & ",'Opening','" & ob.DateConversion(TxtfromDate.Text) & "'," & cs.Rows(ics).Item("stock") & ",9999)", ob.getconnection())
            Next
        End If

        Dim Sqlstring As String
        Dim I As Integer = 0
        Sqlstring = "select * from Stockreport"
        Dim conn8 As New SqlConnection(ob.Getconn())
        Dim mycommand8 As New SqlCommand(Sqlstring, conn8)
        mycommand8.CommandTimeout = 9000
        conn8.Open()
        Dim myreader8 As SqlDataReader = mycommand8.ExecuteReader
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = ob.FindOneinteger("select count(*) from Stockreport where  TransDate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'", ob.getconnection())
        While myreader8.Read = True
            Dim bal As Double
            Dim op As Double = 0
            Dim inqty As Double = 0
            Dim sqty As Double = 0
            Dim type As String
            Dim total As Double
            Dim aout As Double
            Dim rout As Double = 0
            Dim iname As Integer
            Dim iGname As Integer
            Dim mDate As Date
            Dim rr As String
            Dim tqty As Double = 0
            Dim opr As String
            Dim stype As String
            Dim iqty As Double = 0
            Dim oqty As Double = 0
            Dim rreturn As Double = 0
            Dim tranno As String = ""
            Dim tt As String = 0
            iname = Val(myreader8.Item("ItemId").ToString)
            ' iGname = Val(myreader8.Item("ItemGroupId").ToString)
            stype = myreader8.Item("SalesPurchase").ToString
            If myreader8.Item("SalesPurchase").ToString = "Opening" Then
                mDate = myreader8.Item("TransDate").ToString
                op = Val(myreader8.Item("Qty").ToString)
            ElseIf myreader8.Item("SalesPurchase").ToString = "Malavak" Or myreader8.Item("SalesPurchase").ToString = "Purchase" Then
                If myreader8.Item("SalesPurchase").ToString = "Purchase" Then
                    'mDate = myreader8.Item("ChDt").ToString
                    If Cmbdepartment.Text = "KHETSADHAN" Then
                        mDate = myreader8.Item("TransDate").ToString
                        inqty = Val(myreader8.Item("Qty").ToString)
                    End If
                    'mDate = myreader8.Item("TransDate").ToString
                    'inqty = Val(myreader8.Item("Qty").ToString)
                Else
                    'f Val(myreader8.Item("cht").ToString) = "0" Then
                    mDate = myreader8.Item("TransDate").ToString
                    inqty = Val(myreader8.Item("Qty").ToString)
                    'End If
                End If
            ElseIf myreader8.Item("SalesPurchase").ToString = "Sales" Then
                mDate = myreader8.Item("TransDate").ToString
                sqty = Val(myreader8.Item("Qty").ToString)
            ElseIf myreader8.Item("SalesPurchase").ToString = "Transfer" Then
                mDate = myreader8.Item("TransDate").ToString
                tqty = Val(myreader8.Item("Qty").ToString)
                'TQtyIn
            ElseIf myreader8.Item("SalesPurchase").ToString = "PurchaseReturn" Then
                mDate = myreader8.Item("TransDate").ToString
                rout = Val(myreader8.Item("Qty").ToString)
            ElseIf myreader8.Item("SalesPurchase").ToString = "Adj" Then
                mDate = myreader8.Item("TransDate").ToString
                iqty = Val(myreader8.Item("Qty").ToString)
                oqty = Val(myreader8.Item("QtyoUT").ToString)
            Else
                GoTo A
            End If
            type = myreader8.Item("SalesPurchase").ToString

            ' rr = RasClass.GetValue("Select min(Rate) from stockdetail where itemid=" & Val(myreader8.Item("ItemId").ToString) & " and sdate between '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "'")
            rr = 0 ' ob.FindOneString("select PurchaseRate from ItemMaster where Itemcode=" & Val(myreader8.Item("ItemId").ToString) & " ", ob.getconnection())
            tranno = myreader8.Item("Tranno").ToString
            'If rr = 0 Then
            '    opr = RasClass.GetValue("Select rate from TempDetail where Itemid=" & Val(myreader8.Item("ItemId").ToString) & " and SalesPurchase<>'Sales'  ")
            '    rr = Val(opr)
            'Else
            '    rr = Val(myreader8.Item("Rate").ToString)
            'End If
            If Cmbdepartment.Text = "BHANDAR" Then
                rr = ob.FindOneString("select pdtrate from acstock  where itemid=" & Val(iname) & " and ptype='purchase' order by billno desc", ob.getconnection())
                If Val(rr) = 0 Then
                    rr = ob.FindOneString("select rate from acstock  where itemid=" & Val(iname) & " and ptype='Opening' order by billno desc", ob.getconnection())


                End If
            Else
                rr = ob.FindOneString("select rate from acstock  where itemid=" & Val(iname) & " and ptype='purchase' order by billno desc", ob.getconnection())

                If Val(rr) = 0 Then
                    rr = ob.FindOneString("select padt_rate from item_master  where item_id=" & Val(iname) & "", ob.getconnection())

                End If
            End If
            If tan = True Then
                tt = ob.FindOneString("select isnull(bag,0) from item_master  where item_id=" & Val(iname) & "", ob.getconnection())
                If Val(tt) <> 0 Then
                    op = Val(op) * Val(tt)
                    inqty = Val(inqty) * Val(tt)
                End If
            End If
            total = Val(op) + Val(inqty) + Val(rreturn)
            bal = Val(total) - Val(sqty) - Val(rout) - Val(tqty) + Val(iqty) - Val(oqty)
            If Val(bal) <> 0 Then
                Sqlstring = "insert into Stock(ItemId,ItemGroupId,OpQty,InQty,TotalQty,SOut,IqTY,oQTY,ROut,NetQty,TQtyIn,SDate," &
                                "StockType,Rate,Ret,Transno) values " &
                                "(" & Val(iname) & "," & Val(iGname) & "," & Val(op) & "," & Val(inqty) & "," & Val(total) & "," & Val(sqty) & "," & Val(iqty) & "," & Val(oqty) & "," & Val(rout) & "," & Val(bal) & "," & Val(tqty) & ",'" & Format(CDate(mDate), "yyyy/MM/dd") & "'," &
                                "'" & Trim(type) & "'," & Val(rr) & "," & Val(rreturn) & "," & Val(tranno) & ")"
                ob.Execute(Sqlstring, ob.getconnection())
            End If
A:          I = I + 1
            ProgressBar1.Value = ProgressBar1.Value + 1
            ProgressBar1.Refresh()
            lbl.Text = (Format((I / ProgressBar1.Maximum) * 100, "###0")) & "%"
            lbl.Refresh()
        End While
        edtime = Now
        lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
        lbl.Refresh()
        conn8.Close()
        myreader8 = Nothing
        mycommand8 = Nothing
        conn8 = Nothing
    End Sub
    Public Sub newbhandar()
        If Val(itemname.Tag) <> 0 Then
            If Trim(barcode.Text) <> "" Then
                'dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
                ob.Execute("insert into stock (itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,1,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Opening'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,1,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Purchase'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,1,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Sales'", ob.getconnection())


            Else
                'dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "'  and ptype='Opening'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,15,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "'  and ptype='Purchase'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and ptype='Sales'", ob.getconnection())
            End If
        ElseIf Trim(barcode.Text) <> "" Then
            ' dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and barcode=" & aq(barcode.Text) & " and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Opening'", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,15,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Purchase'", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' and ptype='Sales'", ob.getconnection())
        ElseIf Val(groupname.Tag) <> 0 Then
            'dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and im.Quality_id=" & Val(groupname.Tag) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
        ElseIf Trim(cmbgroup.Text) <> "" Then
            If Val(groupname.Tag) <> 0 Then
                ' dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and im.Quality_id=" & Val(groupname.Tag) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name  from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "' and im.Quality_id=" & Val(groupname.Tag) & " and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Opening'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,15,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "' and im.Quality_id=" & Val(groupname.Tag) & " and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Purchase'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' and im.Quality_id=" & Val(groupname.Tag) & " and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Sales'", ob.getconnection())
            Else
                ' dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name  from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "'  and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Opening'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,15,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  and department='" & Trim(Cmbdepartment.Text) & "' and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Purchase'", ob.getconnection())
                ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id inner join item_master as im on im.item_id=Acstock.itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and ptype='Sales'", ob.getconnection())
            End If
        Else
            '  dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,stockin,0,stockin,0,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  and ptype='Opening'", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,stockin,stockin,0,0,0,15,billno,billdate,ptype,rate,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  and ptype='Purchase'", ob.getconnection())
            ob.Execute("insert into stock(itemid,opqty,inqty,totalqty,sout,aout,rout,netqty,transno,sdate,stocktype,rate,barcode,sizeid,ItemGroupId,sizename)  select itemid,0,0,0,stockout,0,0,15,billno,billdate,ptype,0,barcode,sizeid,0 ,Size_Master.Size_Name from acstock inner join Size_Master on Acstock.Sizeid=Size_Master.Size_Id where Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' and ptype='Sales'", ob.getconnection())
        End If

        ob.Execute("update stock set ipaddress=" & aq(IPAddress) & "", ob.getconnection())
    End Sub
    Public Sub stockbhandar()
        Dim sttime As DateTime
        Dim edtime As DateTime
        sttime = Now
        ob.Execute("delete from Stock", ob.getconnection())
        ob.Execute("delete from Stockreportbhandar", ob.getconnection())
        If chkfast.Checked = True Then
            newbhandar()
            Exit Sub
        End If
        Dim dt As DataTable
        If Val(itemname.Tag) <> 0 Then
            If Trim(barcode.Text) <> "" Then
                dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' and barcode='" & barcode.Text & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            Else
                dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            End If
        ElseIf Trim(barcode.Text) <> "" Then
            dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and barcode=" & aq(barcode.Text) & " and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
        ElseIf Val(groupname.Tag) <> 0 Then
            dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and im.Quality_id=" & Val(groupname.Tag) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
        ElseIf Trim(cmbgroup.Text) <> "" Then
            If Val(groupname.Tag) <> 0 Then
                dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " and im.Quality_id=" & Val(groupname.Tag) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            Else
                dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock inner join ITEM_MASTER as im on im.Item_Id=Acstock.Itemid inner join PRODUCT_MASTER as pr on pr.Product_Id=im.Quality_id  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and acstock.department='" & Trim(Cmbdepartment.Text) & "' and pr.Group_id=" & Val(cmbgroup.SelectedValue) & " group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())
            End If
        Else
            dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())

        End If
        Dim I As Integer = 0
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dt.Rows.Count
        For fi As Integer = 0 To dt.Rows.Count - 1
            Dim iname As Integer = dt.Rows(fi).Item("itemid")
            Dim iGname As Integer = 0
            Dim op As String = 0
            If dt.Rows(fi).Item("billdate") = TxtfromDate.Text Then
                op = ob.FindOneString("select sum(stockin)-sum(stockout) as stock,Itemid,BarCode,sizeid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(iname) & " and department='" & Trim(Cmbdepartment.Text) & "'  Group by Itemid,BarCode,sizeid", ob.getconnection())
            End If
            Dim type As String = dt.Rows(fi).Item("ptype")
            Dim inqty As Double = 0
            If type <> "Opening" Then
                inqty = dt.Rows(fi).Item("stockin")
            End If
            Dim total As Double = Val(op) + Val(inqty)
            Dim sqty As Double = dt.Rows(fi).Item("stockout")
            Dim bal As Double

            Dim rout As Double = 0
            Dim mDate As Date = dt.Rows(fi).Item("billdate")
            Dim rr As String
            Dim tqty As Double = 0
            Dim iqty As Double = 0
            Dim oqty As Double = 0
            Dim rreturn As Double = 0
            Dim tranno As String = dt.Rows(fi).Item("billno")
            rr = ob.FindOneString("select pdtrate from acstock  where barcode='" & Trim(dt.Rows(fi).Item("barcode").ToString) & "' and ptype='purchase' and billdate<='" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' order by billno desc", ob.getconnection())
            If Val(rr) = 0 Then
                rr = ob.FindOneString("select rate from acstock  where barcode='" & Trim(dt.Rows(fi).Item("barcode").ToString) & "' and ptype='Opening' order by billno desc", ob.getconnection())
            End If
            bal = Val(total) - Val(sqty) - Val(rout) - Val(tqty) + Val(iqty) - Val(oqty)
            Dim sd As String = ob.FindOneString("select Size_Name from Size_Master where Size_Id='" & dt.Rows(fi).Item("Sizeid") & "'", ob.getconnection())

            Dim Sqlstringw As String = "insert into Stock(ItemId,ItemGroupId,OpQty,InQty,TotalQty,SOut,IqTY,oQTY,ROut,NetQty,TQtyIn,SDate," &
                               "StockType,Rate,Ret,Transno,barcode, sizeid, sizename,ipaddress) values " &
                               "(" & Val(iname) & "," & Val(iGname) & "," & Val(op) & "," & Val(inqty) & "," & Val(total) & "," & Val(sqty) & "," & Val(iqty) & "," & Val(oqty) & "," & Val(rout) & "," & Val(bal) & "," & Val(tqty) & ",'" & Format(CDate(mDate), "yyyy/MM/dd") & "'," &
                               "'" & Trim(type) & "'," & Val(rr) & "," & Val(rreturn) & "," & Val(tranno) & ",'" & Trim(dt.Rows(fi).Item("barcode").ToString) & "','" & Trim(dt.Rows(fi).Item("sizeid").ToString) & "','" & Trim(sd) & "'," & aq(IPAddress) & ")"
            ob.Execute(Sqlstringw, ob.getconnection())
            I = I + 1
            ProgressBar1.Value = ProgressBar1.Value + 1
            ProgressBar1.Refresh()
            lbl.Text = (Format((I / ProgressBar1.Maximum) * 100, "###0")) & "%"
            lbl.Refresh()
        Next


        'For id As Integer = 0 To dt.Rows.Count - 1
        '    If Val(dt.Rows(id).Item("stockin")) <> 0 Then
        '        Dim sd As String = ob.FindOneString("select Size_Name from Size_Master where Size_Id='" & dt.Rows(id).Item("Sizeid") & "'", ob.getconnection())
        '        ob.Execute("Insert into Stockreportbhandar(ItemId, SalesPurchase, TransDate, Qty, Tranno,barcode, sizeid, sizename) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockin") & "," & dt.Rows(id).Item("Billno") & ",'" & dt.Rows(id).Item("Barcode") & "','" & dt.Rows(id).Item("Sizeid") & "','" & Trim(sd) & "')", ob.getconnection())
        '    Else
        '        Dim sd As String = ob.FindOneString("select Size_Name from Size_Master where Size_Id='" & dt.Rows(id).Item("Sizeid") & "'", ob.getconnection())
        '        ob.Execute("Insert into Stockreportbhandar(ItemId, SalesPurchase, TransDate, Qty, Tranno,barcode,sizeid,sizename) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockout") & "," & dt.Rows(id).Item("Billno") & ",'" & dt.Rows(id).Item("Barcode") & "','" & dt.Rows(id).Item("Sizeid") & "','" & Trim(sd) & "')", ob.getconnection())
        '    End If
        'Next



        '        If TxtfromDate.Text <> "01/04/2022" Then
        '            Dim cs As DataTable
        '            If Val(itemname.Tag) <> 0 Then
        '                cs = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid,BarCode,sizeid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(itemname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "'  Group by Itemid,BarCode,sizeid", ob.getconnection())
        '            Else
        '                'cs = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  Group by Itemid", ob.getconnection())
        '                cs = ob.Returntable("select Itemid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  Group by Itemid", ob.getconnection())

        '            End If
        '            For ics As Integer = 0 To cs.Rows.Count - 1
        '                Dim sto As DataTable = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid,BarCode,sizeid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and itemid=" & Val(cs.Rows(ics).Item("Itemid")) & " and department='" & Trim(Cmbdepartment.Text) & "'  Group by Itemid,BarCode,sizeid", ob.getconnection())
        '                For gj As Integer = 0 To sto.Rows.Count - 1
        '                    Dim sd As String = ob.FindOneString("select Size_Name from Size_Master where Size_Id='" & Trim(ob.IfNullThen(sto.Rows(gj).Item("Sizeid"), 0)) & "'", ob.getconnection())
        '                    ob.Execute("Insert into Stockreportbhandar(ItemId, SalesPurchase, TransDate, Qty, Tranno,BARCODE,sizeid,sizename) values(" & Val(sto.Rows(gj).Item("Itemid")) & ",'Opening','" & ob.DateConversion(TxtfromDate.Text) & "'," & Val(sto.Rows(gj).Item("stock")) & ",9999,'" & Trim(sto.Rows(gj).Item("BarCode")) & "','" & Trim(ob.IfNullThen(sto.Rows(gj).Item("Sizeid"), 0)) & "','" & Trim(sd) & "')", ob.getconnection())
        '                Next
        '            Next
        '        End If

        '        Dim Sqlstring As String
        '        Dim I As Integer = 0
        '        Sqlstring = "select * from Stockreportbhandar where  TransDate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'"
        '        Dim conn8 As New SqlConnection(ob.Getconn())
        '        Dim mycommand8 As New SqlCommand(Sqlstring, conn8)
        '        mycommand8.CommandTimeout = 9000
        '        conn8.Open()
        '        Dim myreader8 As SqlDataReader = mycommand8.ExecuteReader
        '        ProgressBar1.Value = 0
        '        ProgressBar1.Minimum = 0
        '        ProgressBar1.Maximum = ob.FindOneinteger("select count(*) from Stockreportbhandar where  TransDate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and TransDate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'", ob.getconnection())

        '        While myreader8.Read = True
        '            Dim bal As Double
        '            Dim op As Double = 0
        '            Dim inqty As Double = 0
        '            Dim sqty As Double = 0
        '            Dim type As String
        '            Dim total As Double
        '            Dim aout As Double
        '            Dim rout As Double = 0
        '            Dim iname As Integer
        '            Dim iGname As Integer
        '            Dim mDate As Date
        '            Dim rr As String
        '            Dim tqty As Double = 0
        '            Dim opr As String
        '            Dim stype As String
        '            Dim iqty As Double = 0
        '            Dim oqty As Double = 0
        '            Dim rreturn As Double = 0
        '            Dim tranno As String = ""
        '            iname = Val(myreader8.Item("ItemId").ToString)
        '            ' iGname = Val(myreader8.Item("ItemGroupId").ToString)
        '            stype = myreader8.Item("SalesPurchase").ToString
        '            If myreader8.Item("SalesPurchase").ToString = "Opening" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                op = Val(myreader8.Item("Qty").ToString)
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "Malavak" Or myreader8.Item("SalesPurchase").ToString = "Purchase" Then
        '                If myreader8.Item("SalesPurchase").ToString = "Purchase" Then
        '                    'mDate = myreader8.Item("ChDt").ToString
        '                    mDate = myreader8.Item("TransDate").ToString
        '                    inqty = Val(myreader8.Item("Qty").ToString)
        '                Else
        '                    mDate = myreader8.Item("TransDate").ToString
        '                    inqty = Val(myreader8.Item("Qty").ToString)
        '                End If
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "Sales" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                sqty = Val(myreader8.Item("Qty").ToString)
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "Transfer" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                inqty = Val(myreader8.Item("Qty").ToString)
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "STransfer" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                sqty = Val(myreader8.Item("Qty").ToString)
        '                'TQtyIn sqty
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "PurchaseReturn" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                rout = Val(myreader8.Item("Qty").ToString)
        '            ElseIf myreader8.Item("SalesPurchase").ToString = "Adj" Then
        '                mDate = myreader8.Item("TransDate").ToString
        '                iqty = Val(myreader8.Item("Qty").ToString)
        '                oqty = Val(myreader8.Item("QtyoUT").ToString)
        '            Else
        '                GoTo A
        '            End If
        '            type = myreader8.Item("SalesPurchase").ToString

        '            ' rr = RasClass.GetValue("select min(Rate) from stockdetail where itemid=" & Val(myreader8.Item("ItemId").ToString) & " and sdate between '" & Format(CDate(Me.FrDt.Text), "yyyy/MM/dd") & "' and '" & Format(CDate(Me.Todt.Text), "yyyy/MM/dd") & "'")
        '            ' rr = 0 ' ob.FindOneString("select PurchaseRate from ItemMaster where Itemcode=" & Val(myreader8.Item("ItemId").ToString) & " ", ob.getconnection())
        '            tranno = myreader8.Item("Tranno").ToString
        '            rr = ob.FindOneString("select pdtrate from acstock  where barcode='" & Trim(myreader8.Item("barcode").ToString) & "' and ptype='purchase' and billdate<='" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' order by billno desc", ob.getconnection())
        '            If Val(rr) = 0 Then
        '                rr = ob.FindOneString("select rate from acstock  where barcode='" & Trim(myreader8.Item("barcode").ToString) & "' and ptype='Opening' order by billno desc", ob.getconnection())
        '            End If
        '            'If rr = 0 Then
        '            '    opr = RasClass.GetValue("Select rate from TempDetail where Itemid=" & Val(myreader8.Item("ItemId").ToString) & " and SalesPurchase<>'Sales'  ")
        '            '    rr = Val(opr)
        '            'Else
        '            '    rr = Val(myreader8.Item("Rate").ToString)
        '            'End If

        '            total = Val(op) + Val(inqty) + Val(rreturn)
        '            bal = Val(total) - Val(sqty) - Val(rout) - Val(tqty) + Val(iqty) - Val(oqty)
        '            'If Val(bal) <> 0 Then
        '            Sqlstring = "insert into Stock(ItemId,ItemGroupId,OpQty,InQty,TotalQty,SOut,IqTY,oQTY,ROut,NetQty,TQtyIn,SDate," &
        '                                "StockType,Rate,Ret,Transno,barcode, sizeid, sizename) values " &
        '                                "(" & Val(iname) & "," & Val(iGname) & "," & Val(op) & "," & Val(inqty) & "," & Val(total) & "," & Val(sqty) & "," & Val(iqty) & "," & Val(oqty) & "," & Val(rout) & "," & Val(bal) & "," & Val(tqty) & ",'" & Format(CDate(mDate), "yyyy/MM/dd") & "'," &
        '                                "'" & Trim(type) & "'," & Val(rr) & "," & Val(rreturn) & "," & Val(tranno) & ",'" & Trim(myreader8.Item("barcode").ToString) & "','" & Trim(myreader8.Item("sizeid").ToString) & "','" & Trim(myreader8.Item("sizename").ToString) & "')"
        '            ob.Execute(Sqlstring, ob.getconnection())

        '            'End If
        'A:          I = I + 1
        '            ProgressBar1.Value = ProgressBar1.Value + 1
        '            ProgressBar1.Refresh()
        '            lbl.Text = (Format((I / ProgressBar1.Maximum) * 100, "###0")) & "%"
        '            lbl.Refresh()
        '        End While
        edtime = Now
        lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
        lbl.Refresh()
        'conn8.Close()
        'myreader8 = Nothing
        'mycommand8 = Nothing
        'conn8 = Nothing
    End Sub

    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtfromDate.Focus()
        End If
    End Sub

    Private Sub TxtfromDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToDate.KeyDown, txtproduct.KeyDown, TxtfromDate.KeyDown, itemname.KeyDown, Acname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Tomonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tomonth.Validated
        If Tomonth.Text <> "" Then
            Tomonth.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Tomonth.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub dg1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellDoubleClick

        'lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())


        Dim gst As String = dg1.Rows(e.RowIndex).Cells(0).Value
        txtproduct.Tag = ob.FindOneString("Select Party_id from Party_master where gstno=" & gst & "", ob.getconnection())
        Panel1.Visible = False
        itemname.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel1.Visible = False
        txtproduct.Clear()
        txtproduct.Focus()
    End Sub

    Private Sub TxtfromDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtfromDate.Validating

    End Sub

    Private Sub Acname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Acname.Validated
        If Acname.Text <> "" Then
            Acname.Tag = ob.FindOneinteger("select account_id from account_master where Account_name='" & Acname.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub barcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles barcode.Validating
        Dim iid As Integer = ob.FindOneString("select Itemid from Acstock where barcode='" & barcode.Text & "'", ob.getconnection())
        Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & barcode.Text & "'", ob.getconnection())
        'itemname.Tag = iid


        lname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(iid) & " and Department=" & aq(Cmbdepartment.Text) & "", ob.getconnection())
    End Sub

    Private Sub groupname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles groupname.Validating
        groupname.Tag = ob.FindOneString("select Product_Id from Product_Master Where Product_Id=" & Val(groupname.Text) & " or Product_Name=N'" & Trim(groupname.Text) & "'", ob.getconnection())
        If Val(groupname.Tag) <> 0 Then
            groupname.Text = ob.FindOneString("select Product_Name from Product_Master Where Product_Id=" & groupname.Tag & " ", ob.getconnection())
        End If
    End Sub

    Private Sub groupname_KeyDown(sender As Object, e As KeyEventArgs) Handles groupname.KeyDown
        If e.KeyCode = Keys.Enter Then
            itemname.Focus()
        End If
    End Sub

    Private Sub Cmbdepartment_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cmbdepartment.Validating
        Dim dts As DataTable = ob.Returntable("select * from group_master order by group_id", ob.getconnection())
        If Cmbdepartment.Text = "BHANDAR" Then
            cmbgroup.DataSource = dts
            cmbgroup.ValueMember = "group_id"
            cmbgroup.DisplayMember = "group_name"
        Else
            cmbgroup.DataSource = Nothing
        End If
    End Sub
End Class