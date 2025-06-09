Imports WeightPavti.CLS
Public Class MonthlyPosting
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select * from Member_master where mclose=1 and mcash<>1 and Member_type='" & Trim(ComboMemberType.Text) & "' Order BY Member_id", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            Dg.Rows.Add()
            Dg.Rows(i).Cells(0).Value = i + 1
            Dg.Rows(i).Cells(1).Tag = dt.Rows(i).Item("Member_id")
            Dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Member_Name")
            Dg.Rows(i).Cells(2).Value = 0
            Dg.Rows(i).Cells(3).Value = 0
            Dg.Rows(i).Cells(4).Value = 0
            Dg.Rows(i).Cells(5).Value = 40
            Dg.Rows(i).Cells(6).Value = 950
            Dg.Rows(i).Cells(7).Value = 10
            Dg.Rows(i).Cells(8).Value = 1000
            Dg.Rows(i).Cells(9).Value = True
        Next
        Dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
        loan()
        Dim ts As Double = 0
        Dim tp As Double = 0
        Dim tt As Double = 0
        Dim td As Double = 0
        Dim tss As Double = 0
        Dim tn As Double = 0
        For j As Integer = 0 To Dg.Rows.Count - 1
            ts = Val(ts) + Val(Dg.Rows(j).Cells(5).Value)
            tp = Val(tp) + Val(Dg.Rows(j).Cells(6).Value)
            tt = Val(tt) + Val(Dg.Rows(j).Cells(7).Value)
            td = Val(td) + Val(Dg.Rows(j).Cells(8).Value)
            tss = Val(tss) + Val(Dg.Rows(j).Cells(3).Value)
            tn = Val(tn) + Val(Dg.Rows(j).Cells(4).Value)

        Next
        tshre.Text = Val(ts)
        tfixd.Text = Val(tp)
        tk.Text = Val(tt)
        total.Text = Val(td)
        txtamount.Text = Val(tss)
        txtint.Text = Val(tn)

    End Sub
    Public Sub loan()
        For i As Integer = 0 To Dg.Rows.Count - 1
            Dim dt As DataTable = ob.Returntable("Select isnull(sum(paymentamt),0)-isnull(sum(Receiptamt),0) as Amt From Acmain Where  Partyid=" & Val(Dg.Rows(i).Cells(1).Tag) & " and Acid=20", ob.getconnection())
            If Val(dt.Rows(0).Item("Amt")) <> 0 Then
                Dg.Rows(i).Cells(2).Value = dt.Rows(0).Item("Amt")
                Dg.Rows(i).Cells(4).Value = Format(Val(dt.Rows(0).Item("Amt")) * Val(0.5) / 100, "###0.00")
                Dg.Rows(i).DefaultCellStyle.BackColor = Color.Red
                Dg.Rows(i).Cells(8).Value = 1000 + Val(Dg.Rows(i).Cells(3).Value) + Val(Dg.Rows(i).Cells(4).Value)
            End If

        Next
    End Sub

    Private Sub MonthlyPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dg.ColumnHeadersDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dg.Columns(1).DefaultCellStyle.Font = New Font("shruti", 10, FontStyle.Regular)
        Dg.Columns(2).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Dg.Columns(3).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Dg.Columns(4).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Dg.Columns(5).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Billno.Text = ob.FindOneString("Select isnull(max(Tid),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = Dg.Rows.Count
        ob.Execute("Delete from Acmain where ptype='Posting' and Tid=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("Delete from Acdata where ptype='Posting' and Tid=" & Val(Billno.Text) & "", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            If Dg.Rows(i).Cells(9).Value = True Then
                Dim dc As Integer = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Receiptamt,ptype,Tid) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & Trim(ComboMemberType.Text) & "','BANK'," & Val(dc) & ",'" & ob.DateConversion(ddate.Text) & "'," & Val(Dg.Rows(i).Cells(1).Tag) & ",2,N'" & Trim(Dg.Rows(i).Cells(1).Value) & "'," & Val(Dg.Rows(i).Cells(5).Value) & ",'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
                Dim dcd As Integer = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Receiptamt,ptype,Tid) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & Trim(ComboMemberType.Text) & "','BANK'," & Val(dcd) & ",'" & ob.DateConversion(ddate.Text) & "'," & Val(Dg.Rows(i).Cells(1).Tag) & ",3,N'" & Trim(Dg.Rows(i).Cells(1).Value) & "'," & Val(Dg.Rows(i).Cells(6).Value) & ",'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
                Dim dcde As Integer = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Receiptamt,ptype,Tid) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & Trim(ComboMemberType.Text) & "','BANK'," & Val(dcde) & ",'" & ob.DateConversion(ddate.Text) & "'," & Val(Dg.Rows(i).Cells(1).Tag) & ",4,N'" & Trim(Dg.Rows(i).Cells(1).Value) & "'," & Val(Dg.Rows(i).Cells(7).Value) & ",'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
                Dim dcdec As Integer = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Receiptamt,ptype,Tid,clid,Intamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & Trim(ComboMemberType.Text) & "','BANK'," & Val(dcdec) & ",'" & ob.DateConversion(ddate.Text) & "'," & Val(Dg.Rows(i).Cells(1).Tag) & ",20,N'" & Trim(Dg.Rows(i).Cells(1).Value) & "'," & Val(Dg.Rows(i).Cells(3).Value) & ",'Posting'," & Val(Billno.Text) & ",1," & Val(Dg.Rows(i).Cells(4).Value) & ")", ob.getconnection())
                '        Dim dcdecv As Integer = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='Posting'", ob.getconnection())
                '       ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,Receiptamt,ptype,Tid,clid) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','Posting','BANK'," & Val(dcdecv) & ",'" & ob.DateConversion(ddate.Text) & "'," & Val(Dg.Rows(i).Cells(1).Tag) & ",27,N'" & Trim(Dg.Rows(i).Cells(1).Value) & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",'Posting'," & Val(Billno.Text) & ",1)", ob.getconnection())

                ProgressBar1.Value = ProgressBar1.Value + 1
                Label2.Text = Dg.Rows(i).Cells(1).Value
                Label2.Refresh()
            End If
        Next
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',2,N'સભાસદ શેર ભંડોળ'," & tshre.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',19,N'સ્ટેટ બેંક કરંટ ખાતુ'," & tshre.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',3,N'સભાસદ બચત થાપણ'," & tfixd.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',19,N'સ્ટેટ બેંક કરંટ ખાતુ'," & tfixd.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',4,N'સભાસદ કલ્યાણ નીધી'," & tk.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,tid) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',19,N'સ્ટેટ બેંક કરંટ ખાતુ'," & tk.Text & ",N'મહિનાની રકમ',0,'Posting'," & Val(Billno.Text) & ")", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,dramt,ptype,tid,Remarks) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',20,N'સભાસદ ધિરાણ ખાતુ'," & txtamount.Text & ",0,'Posting'," & Val(Billno.Text) & ",N'મહિનાની રકમ')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,cramt,ptype,tid,Remarks) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',19,N'સ્ટેટ બેંક કરંટ ખાતુ'," & txtamount.Text & ",0,'Posting'," & Val(Billno.Text) & ",N'મહિનાની રકમ')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,dramt,ptype,tid,Remarks) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',27,N'સભાસદ ધિરાણ વ્યાજ'," & txtint.Text & ",0,'Posting'," & Val(Billno.Text) & ",N'મહિનાની રકમ')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,cramt,ptype,tid,Remarks) Values(1,'" & clsVariables.WorkingYear & "','Bank'," & Billno.Text & ",'" & ob.DateConversion(ddate.Text) & "',19,N'સ્ટેટ બેંક કરંટ ખાતુ'," & txtint.Text & ",0,'Posting'," & Val(Billno.Text) & ",N'મહિનાની રકમ')", ob.getconnection())
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        MessageBox.Show("Ok")
        Billno.Text = ob.FindOneString("Select isnull(max(Tid),0)+1 from Acmain where ptype='Posting'", ob.getconnection())

    End Sub



    Private Sub Dg_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.CellValueChanged

    End Sub

    Private Sub Dg_SelectionChanged(sender As Object, e As EventArgs) Handles Dg.SelectionChanged

    End Sub

    Private Sub Dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.CellClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ts As Double = 0
        Dim tp As Double = 0
        Dim tt As Double = 0
        Dim td As Double = 0
        Dim tss As Double = 0
        Dim tn As Double = 0
        For j As Integer = 0 To Dg.Rows.Count - 1
            If Dg.Rows(j).Cells(9).Value = True Then
                ts = Val(ts) + Val(Dg.Rows(j).Cells(5).Value)
                tp = Val(tp) + Val(Dg.Rows(j).Cells(6).Value)
                tt = Val(tt) + Val(Dg.Rows(j).Cells(7).Value)
                td = Val(td) + Val(Dg.Rows(j).Cells(8).Value)
                tss = Val(tss) + Val(Dg.Rows(j).Cells(3).Value)
                tn = Val(tn) + Val(Dg.Rows(j).Cells(4).Value)
            End If
        Next
        tshre.Text = Val(ts)
        tfixd.Text = Val(tp)
        tk.Text = Val(tt)
        total.Text = Val(td)
        txtamount.Text = Val(tss)
        txtint.Text = Val(tn)


    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("Select * from Acmain where ptype='Posting' and Tid=" & Val(Billno.Text) & " and acid=2 order by Billno", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ComboMemberType.Text = ob.FindOneString("select Member_type from Member_Master Where Member_id=" & dt.Rows(0).Item("Partyid") & "", ob.getconnection())
                ddate.Text = dt.Rows(0).Item("Billdate")
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(i).Cells(0).Value = i + 1
                    Dg.Rows(i).Cells(1).Tag = dt.Rows(i).Item("Partyid")
                    Dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Remarks")
                    Dg.Rows(i).Cells(5).Value = 40
                    Dg.Rows(i).Cells(6).Value = 950
                    Dg.Rows(i).Cells(7).Value = 10
                    Dg.Rows(i).Cells(8).Value = 1000
                    Dg.Rows(i).Cells(9).Value = True
                    Dg.Rows(i).Cells(3).Value = ob.FindOneString("Select Receiptamt From Acmain where Ptype='Posting' and tid=" & Billno.Text & " and Partyid=" & dt.Rows(i).Item("Partyid") & " and acid=20", ob.getconnection())
                    Dg.Rows(i).Cells(4).Value = ob.FindOneString("Select intamt From Acmain where Ptype='Posting' and tid=" & Billno.Text & " and Partyid=" & dt.Rows(i).Item("Partyid") & " and acid=20", ob.getconnection())
                Next
            End If
            Button3_Click(Nothing, Nothing)
        End If
    End Sub
End Class