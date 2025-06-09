Imports WeightPavti.CLS
Imports System.Data
Imports System.Data.SqlClient
Public Class Frmstocktrasfernew
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtyear.Text <> "" Then
            If Cmbdepartment.Text = "BHANDAR" Then
                stockbhandar()
            Else
                stock()
            End If
        Else
            MessageBox.Show("Place enter year")
            txtyear.Focus()
        End If
    End Sub

    Public Sub stock()
        Dim sttime As DateTime
        Dim edtime As DateTime
        sttime = Now
        ob.Execute("delete from Stockreport", ob.getconnection())
        ob.Execute("delete from Stock", ob.getconnection())
        Dim dt As DataTable

        dt = ob.Returntable("select * from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'", ob.getconnection())

        For id As Integer = 0 To dt.Rows.Count - 1
            If Val(dt.Rows(id).Item("stockin")) <> 0 Then
                ob.Execute("Insert into Stockreport(ItemId, SalesPurchase, TransDate, Qty, Tranno) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockin") & "," & dt.Rows(id).Item("Billno") & ")", ob.getconnection())
            Else
                ob.Execute("Insert into Stockreport(ItemId, SalesPurchase, TransDate, Qty, Tranno) values(" & dt.Rows(id).Item("Itemid") & ",'" & dt.Rows(id).Item("Ptype") & "','" & ob.DateConversion(dt.Rows(id).Item("Billdate")) & "'," & dt.Rows(id).Item("stockout") & "," & dt.Rows(id).Item("Billno") & ")", ob.getconnection())
            End If
        Next
        If TxtfromDate.Text <> "01/04/2022" Then
            Dim cs As DataTable
            cs = ob.Returntable("select sum(stockin)-sum(stockout) as stock,Itemid from Acstock where Billdate <'" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "'  and ptype<>'Purchase'  Group by Itemid", ob.getconnection())
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
        ob.Execute("delete from acstock where year_id='" & txtyear.Text & "' and ptype='Opening' and Department='" & Cmbdepartment.Text & "'", ob.getconnection())

        Dim cdates As Date = TxtfromDate.Text
        Dim ndate As Date = DateAndTime.DateAdd(DateInterval.Year, 1, cdates)
        Dim dts As DataTable = ob.Returntable("select * from item_master where Department='" & Cmbdepartment.Text & "'", ob.getconnection())
        For iss As Integer = 0 To dts.Rows.Count - 1
            Dim nbal As String = ob.FindOneString("Select Sum(Netqty) as Bal from Stock where  ItemID = " & Val(dts.Rows(iss).Item("Item_ID")) & " Group BY ItemID", ob.getconnection())
            ob.Execute("insert into acstock(Cid, Year_id, Department, Billno, Billdate, Stockin, Stockout,ptype, Itemid, Billtype) values(1,'" & txtyear.Text & "','" & Cmbdepartment.Text & "'," & Val(iss) + 1 & ",'" & ob.DateConversion(ndate) & "'," & Val(nbal) & ",0,'Opening'," & Val(dts.Rows(iss).Item("Item_ID")) & ",'Opening')", ob.getconnection())
        Next
        edtime = Now
        lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
        lbl.Refresh()
        conn8.Close()
        myreader8 = Nothing
        mycommand8 = Nothing
        conn8 = Nothing
        MessageBox.Show("Done")
    End Sub
    Public Sub stockbhandar()
        Dim sttime As DateTime
        Dim edtime As DateTime
        sttime = Now
        ob.Execute("delete from Stock", ob.getconnection())
        ob.Execute("delete from Stockreportbhandar", ob.getconnection())
        Dim dt As DataTable


        dt = ob.Returntable("select Billno,Billdate,SUM(Stockin) as Stockin,SUM(Stockout)as Stockout,itemid,sizeid,barcode,ptype from Acstock  where  Billdate >= '" & Format(CDate(Me.TxtfromDate.Text), "yyyy/MM/dd") & "' and Billdate <= '" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "' and department='" & Trim(Cmbdepartment.Text) & "' group by Billno,Billdate,itemid,sizeid,barcode,ptype order by Billdate,ItemId", ob.getconnection())


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
            Dim inqty As Double = dt.Rows(fi).Item("stockin")
            Dim total As Double = Val(op) + Val(inqty)
            Dim sqty As Double = dt.Rows(fi).Item("stockout")
            Dim bal As Double
            Dim type As String = dt.Rows(fi).Item("ptype")
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

        ob.Execute("delete from acstock where year_id='" & txtyear.Text & "' and ptype='Opening' and Department='" & Cmbdepartment.Text & "'", ob.getconnection())

        Dim cdates As Date = TxtfromDate.Text
        Dim ndate As Date = DateAndTime.DateAdd(DateInterval.Year, 1, cdates)
        Dim dts As DataTable = ob.Returntable("select * from item_master where Department='" & Cmbdepartment.Text & "'", ob.getconnection())
        For iss As Integer = 0 To dts.Rows.Count - 1
            Dim nbal As String = ob.FindOneString("Select Sum(Netqty) as Bal from Stock where  ItemID = " & Val(dts.Rows(iss).Item("Item_ID")) & " Group BY ItemID,barcode, sizeid", ob.getconnection())
            Dim barc As String = ob.FindOneString("Select barcode from Stock where  ItemID = " & Val(dts.Rows(iss).Item("Item_ID")) & " Group BY ItemID,barcode, sizeid", ob.getconnection())
            Dim size As String = ob.FindOneString("Select sizeid from Stock where  ItemID = " & Val(dts.Rows(iss).Item("Item_ID")) & " Group BY ItemID,barcode, sizeid", ob.getconnection())
            ob.Execute("insert into acstock(Cid, Year_id, Department, Billno, Billdate, Stockin, Stockout, ptype, Itemid, Billtype, Barcode,sizeid) values(1,'" & txtyear.Text & "','" & Cmbdepartment.Text & "'," & Val(iss) + 1 & ",'" & ob.DateConversion(ndate) & "'," & Val(nbal) & ",0,'Opening'," & Val(dts.Rows(iss).Item("Item_ID")) & ",'Opening'," & aq(barc) & "," & aq(size) & ")", ob.getconnection())
        Next


        edtime = Now
        lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
        lbl.Refresh()
    End Sub
End Class