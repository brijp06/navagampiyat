Imports WeightPavti.CLS
Public Class FrmDataTrasfer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbdata.Text = "Mangna" Then
            Dim sttime As DateTime
            Dim edtime As DateTime
            sttime = Now
            Dim dt As DataTable = ob.Returntable("select * from PiyatMandli.dbo.transactionmaster where transmode='Mangna' order by tranno", ob.getconnection())
            ProgressBar1.Value = 0
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dt.Rows.Count

            For i As Integer = 0 To dt.Rows.Count - 1
                ob.Execute("delete from acmain where billno=" & Val(dt.Rows(i).Item("tranno")) & " and ptype='Mangna' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("delete from Acstock where billno=" & Val(dt.Rows(i).Item("tranno")) & " and  ptype='Mangna' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, gst,Basic,Roundoff, Netamt,Paymentamt,ptype,rate,clid,tid) Values(" & clsVariables.CompnyId & ",'" & dt.Rows(i).Item("finyear") & "','Mangna','Mangna'," & Val(dt.Rows(i).Item("tranno")) & ",'" & ob.DateConversion(dt.Rows(i).Item("transdate")) & "'," & Val(dt.Rows(i).Item("partyaccountid")) & ",22,N'-'," & Val(dt.Rows(i).Item("octroi")) & "," & Val(dt.Rows(i).Item("subtotal")) & "," & Val(dt.Rows(i).Item("octroi")) & "," & Val(dt.Rows(i).Item("Paymentamt")) & "," & Val(dt.Rows(i).Item("Paymentamt")) & ",'Mangna'," & Val(dt.Rows(i).Item("addamt")) & "," & Val(dt.Rows(i).Item("columnid")) & "," & Val(dt.Rows(i).Item("TractorMasterId")) & ")", ob.getconnection())
                Dim dts As DataTable = ob.Returntable("select * from PiyatMandli.dbo.Stockdetail where Transactionid=" & Val(dt.Rows(i).Item("Transactionid")) & "", ob.getconnection())
                For it As Integer = 0 To dts.Rows.Count - 1
                    ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,ptype,Billtype,srno,Itemid,blockNo, ServeNo, Hektar, Guntha, Aker, AHektar, AGuntha, Rate1,Amount, LPer, LFund, TotalAmount) Values(1,'" & dt.Rows(i).Item("finyear") & "','Mangna'," & Val(dt.Rows(i).Item("tranno")) & ",'" & ob.DateConversion(dt.Rows(i).Item("transdate")) & "','Mangna','Mangna'," & Val(dts.Rows(it).Item("srno")) & "," & Val(dts.Rows(it).Item("Itemid")) & "," & Val(dts.Rows(it).Item("Blockno")) & "," & Val(dts.Rows(it).Item("ServeNo")) & "," & Val(dts.Rows(it).Item("Hektar")) & "," & Val(dts.Rows(it).Item("Guntha")) & "," & Val(dts.Rows(it).Item("Aker")) & "," & Val(dts.Rows(it).Item("AHektar")) & "," & Val(dts.Rows(it).Item("AGuntha")) & "," & Val(dts.Rows(it).Item("Rate")) & "," & Val(dts.Rows(it).Item("Amount")) & "," & Val(dts.Rows(it).Item("LPer")) & "," & Val(dts.Rows(it).Item("LFund")) & "," & Val(dts.Rows(it).Item("TotalAmount")) & ")", ob.getconnection())
                Next
                ProgressBar1.Value = ProgressBar1.Value + 1
                ProgressBar1.Refresh()
                lbl.Text = (Format((i / ProgressBar1.Maximum) * 100, "###0")) & "%"
                lbl.Refresh()
            Next
            edtime = Now
            lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
            lbl.Refresh()
            MessageBox.Show("Done")
        ElseIf cmbdata.Text = "MemberOpening" Then
            Dim sttime As DateTime
            Dim edtime As DateTime
            sttime = Now
            Dim dt As DataTable = ob.Returntable("select * from PiyatMandli.dbo.transactionmaster where transmode='Opening' order by tranno", ob.getconnection())
            ProgressBar1.Value = 0
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dt.Rows.Count

            For i As Integer = 0 To dt.Rows.Count - 1
                ob.Execute("delete from acmain where billno=" & Val(dt.Rows(i).Item("tranno")) & " and ptype='Opening' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("delete from Acstock where billno=" & Val(dt.Rows(i).Item("tranno")) & " and  ptype='Opening' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, gst,Basic,Roundoff, Netamt,Paymentamt,ptype,rate,clid,tid) Values(" & clsVariables.CompnyId & ",'" & dt.Rows(i).Item("finyear") & "','Opening','Opening'," & Val(dt.Rows(i).Item("tranno")) & ",'" & ob.DateConversion(dt.Rows(i).Item("transdate")) & "'," & Val(dt.Rows(i).Item("partyaccountid")) & ",21,N'-'," & Val(dt.Rows(i).Item("octroi")) & "," & Val(dt.Rows(i).Item("subtotal")) & "," & Val(dt.Rows(i).Item("octroi")) & "," & Val(dt.Rows(i).Item("Paymentamt")) & "," & Val(dt.Rows(i).Item("Paymentamt")) & ",'Opening'," & Val(dt.Rows(i).Item("addamt")) & "," & Val(dt.Rows(i).Item("columnid")) & "," & Val(dt.Rows(i).Item("TractorMasterId")) & ")", ob.getconnection())
                Dim dts As DataTable = ob.Returntable("select srno,Itemid,isnull(Blockno,0)Blockno,isnull(ServeNo,0)ServeNo,isnull(Hektar,0)Hektar,isnull(Guntha,0)Guntha,isnull(Aker,0)Aker,isnull(AHektar,0)AHektar,AGuntha,Rate,Amount,LPer,LFund,TotalAmount from PiyatMandli.dbo.Stockdetail where Transactionid=" & Val(dt.Rows(i).Item("Transactionid")) & "", ob.getconnection())
                For it As Integer = 0 To dts.Rows.Count - 1
                    ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,ptype,Billtype,srno,Itemid,blockNo, ServeNo, Hektar, Guntha, Aker, AHektar, AGuntha, Rate1,Amount, LPer, LFund, TotalAmount) Values(1,'" & dt.Rows(i).Item("finyear") & "','Opening'," & Val(dt.Rows(i).Item("tranno")) & ",'" & ob.DateConversion(dt.Rows(i).Item("transdate")) & "','Opening','Opening'," & Val(dts.Rows(it).Item("srno")) & "," & Val(dts.Rows(it).Item("Itemid")) & "," & Val(dts.Rows(it).Item("Blockno")) & "," & Val(dts.Rows(it).Item("ServeNo")) & "," & Val(dts.Rows(it).Item("Hektar")) & "," & Val(dts.Rows(it).Item("Guntha")) & "," & Val(dts.Rows(it).Item("Aker")) & "," & Val(dts.Rows(it).Item("AHektar")) & "," & Val(dts.Rows(it).Item("AGuntha")) & "," & Val(dts.Rows(it).Item("Rate")) & "," & Val(dts.Rows(it).Item("Amount")) & "," & Val(dts.Rows(it).Item("LPer")) & "," & Val(dts.Rows(it).Item("LFund")) & "," & Val(dts.Rows(it).Item("TotalAmount")) & ")", ob.getconnection())
                Next
                ProgressBar1.Value = ProgressBar1.Value + 1
                ProgressBar1.Refresh()
                lbl.Text = (Format((i / ProgressBar1.Maximum) * 100, "###0")) & "%"
                lbl.Refresh()
            Next
            edtime = Now
            lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
            lbl.Refresh()
            MessageBox.Show("Done")
        ElseIf cmbdata.Text = "oldreceipt" Then
            Dim sttime As DateTime
            Dim edtime As DateTime
            sttime = Now
            Dim dt As DataTable = ob.Returntable("select * from PiyatMandli.dbo.transactionmaster where transmode='MReceiptO' order by tranno", ob.getconnection())
            ProgressBar1.Value = 0
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dt.Rows.Count

            For i As Integer = 0 To dt.Rows.Count - 1
                ob.Execute("delete from acmain where billno=" & Val(dt.Rows(i).Item("tranno")) & " and ptype='OReceipt' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("delete from Acdata where Docno=" & Val(dt.Rows(i).Item("tranno")) & " and  ptype='OReceipt' and year_id=" & aq(dt.Rows(i).Item("finyear")) & "", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Basic,Roundoff, Netamt,Receiptamt,ptype,clid,tid,cbj,intamt) Values(" & clsVariables.CompnyId & ",'" & dt.Rows(i).Item("finyear") & "','OMANGNARECEIPT'," & aq(dt.Rows(i).Item("cbj")) & "," & Val(dt.Rows(i).Item("tranno")) & ",'" & ob.DateConversion(dt.Rows(i).Item("transdate")) & "'," & Val(dt.Rows(i).Item("partyaccountid")) & "," & Val(dt.Rows(i).Item("purchaseaccountid")) & ",N'-'," & Val(dt.Rows(i).Item("dueamt")) & "," & Val(dt.Rows(i).Item("paneltyamt")) & "," & Val(dt.Rows(i).Item("Receiptamt")) & "," & Val(dt.Rows(i).Item("Receiptamt")) - Val(dt.Rows(i).Item("IntAmt")) & ",'OReceipt'," & Val(dt.Rows(i).Item("columnid")) & ",1," & Val(dt.Rows(i).Item("cbjaccountid")) & "," & Val(dt.Rows(i).Item("IntAmt")) & ")", ob.getconnection())
                Dim dts As DataTable = ob.Returntable("select * from PiyatMandli.dbo.VoucherDetail where Transactionid=" & Val(dt.Rows(i).Item("Transactionid")) & "", ob.getconnection())
                For it As Integer = 0 To dts.Rows.Count - 1
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & dts.Rows(it).Item("finyear") & "','" & dts.Rows(it).Item("Season") & "'," & dts.Rows(it).Item("Voucherno") & ",'" & ob.DateConversion(dts.Rows(it).Item("Voucherdate")) & "'," & dts.Rows(it).Item("Ledgeraccountid") & ", N'-'," & Val(dts.Rows(it).Item("debit")) & ",N'" & dts.Rows(it).Item("remarks") & "'," & dts.Rows(it).Item("credit") & ",'OReceipt','OMANGNARECEIPT')", ob.getconnection())
                Next
                ProgressBar1.Value = ProgressBar1.Value + 1
                ProgressBar1.Refresh()
                lbl.Text = (Format((i / ProgressBar1.Maximum) * 100, "###0")) & "%"
                lbl.Refresh()
            Next
            edtime = Now
            lbl.Text = "Process Completed In Minute : " & DateDiff(DateInterval.Minute, sttime, edtime) & " Second : " & IIf(DateDiff(DateInterval.Minute, sttime, edtime) = 0, DateDiff(DateInterval.Second, sttime, edtime), DateDiff(DateInterval.Second, sttime, edtime) - (DateDiff(DateInterval.Minute, sttime, edtime) * 60))
            lbl.Refresh()
            MessageBox.Show("Done")
        End If
    End Sub
End Class