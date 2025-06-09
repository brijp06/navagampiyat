Imports WeightPavti.CLS
Public Class FreeEntri

    Private Sub FreeEntri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        auto()
        sdate.Text = Format(Now, "dd/MM/yyyy")
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        month.AutoCompleteMode = AutoCompleteMode.Suggest
        month.AutoCompleteSource = AutoCompleteSource.CustomSource
        month.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub month_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles month.Validated
        month.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & month.Text & "'", ob.getconnection())
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("select * from sdata where Fromid=" & month.Tag & " and type='Free'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim dts As DataTable = ob.Returntable("select * from Party_Master Order By Party_id", ob.getconnection())
            For i As Integer = 0 To dts.Rows.Count - 1
                dg.Rows.Add()
                dg.Rows(i).Cells(1).Value = dts.Rows(i).Item("Party_id")
                dg.Rows(i).Cells(2).Value = dts.Rows(i).Item("gstno")
                dg.Rows(i).Cells(3).Value = dts.Rows(i).Item("Party_name")
                dg.Rows(i).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Dim sds As DataTable = ob.Returntable("Select * from sdata where fromid=" & month.Tag & " and type='Free' and Id=" & dts.Rows(i).Item("Party_id") & "", ob.getconnection())
                If sds.Rows.Count > 0 Then
                    dg.Rows(i).Cells(0).Value = True
                End If

            Next
            sdate.Text = dt.Rows(0).Item("docdate")
            Remark.Text = dt.Rows(0).Item("Remarks")
        Else
            Dim dts As DataTable = ob.Returntable("select * from Party_Master Order By Party_id", ob.getconnection())
            For i As Integer = 0 To dts.Rows.Count - 1
                dg.Rows.Add()
                dg.Rows(i).Cells(1).Value = dts.Rows(i).Item("Party_id")
                dg.Rows(i).Cells(2).Value = dts.Rows(i).Item("gstno")
                dg.Rows(i).Cells(3).Value = dts.Rows(i).Item("Party_name")
                dg.Rows(i).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Next
        End If
        dg.Focus()
    End Sub

    Private Sub month_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles month.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim amt As Double = ob.FindOneString("select Amount from month where ID=" & month.Tag & "", ob.getconnection())
        For i As Integer = 0 To dg.Rows.Count - 1
            Dim docno As Integer = ob.FindOneinteger("select isnull(Max(Docno),0)+1 from sdata where type='Free'", ob.getconnection())
            If dg.Rows(i).Cells(0).Value = True Then
                ob.Execute("Delete from sdata where id=" & dg.Rows(i).Cells(1).Value & " and fromid=" & month.Tag & " and type='Free'", ob.getconnection())
                ob.Execute("Insert Into Sdata(Docno, Docdate, Id, Name, Fromid, Toid, Amount, Refno, Type, Dramt, Remarks) Values(" & docno & ",'" & ob.DateConversion(sdate.Text) & "'," & dg.Rows(i).Cells(1).Value & ",'" & dg.Rows(i).Cells(3).Value & "'," & month.Tag & "," & month.Tag & "," & amt & ",0,'Free'," & amt & ",'" & Remark.Text & "')", ob.getconnection())
            Else
                ob.Execute("Delete from sdata where id=" & dg.Rows(i).Cells(1).Value & " and fromid=" & month.Tag & " and type='Free'", ob.getconnection())
            End If

        Next
        MessageBox.Show("Saved")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clsVariables.HelpId = "fromid"
        clsVariables.HelpName = "monthname"
        clsVariables.TbName = "sdata"
        HelpWin.scodename = "Name"
        HelpWin.sorderby = " order by fromid"
        HelpWin.tsql = "select fromid,f.monthname from sdata as s Inner join month as f On s.fromid=f.id where type='free' Group by fromid,f.monthname"
        HelpWin.ShowDialog()
    End Sub
End Class