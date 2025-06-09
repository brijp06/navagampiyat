Imports WeightPavti.CLS
Public Class Transfer
    Dim sec As Boolean = False
    Private Sub Transfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        auto()
        autoname()
        autoname1()
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Monthname from month", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Monthname"))
        Next
        Month.AutoCompleteMode = AutoCompleteMode.Suggest
        Month.AutoCompleteSource = AutoCompleteSource.CustomSource
        Month.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autoname()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        fparty.AutoCompleteMode = AutoCompleteMode.Suggest
        fparty.AutoCompleteSource = AutoCompleteSource.CustomSource
        fparty.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autoname1()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        toparty.AutoCompleteMode = AutoCompleteMode.Suggest
        toparty.AutoCompleteSource = AutoCompleteSource.CustomSource
        toparty.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub Hno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Hno.Validating
        If Hno.Text <> "" Then
            Dim dt As DataTable = ob.Returntable("select * from Transfer where Houseno=" & Hno.Text & " Order by Tharavno desc", ob.getconnection())
            If dt.Rows.Count > 0 Then
                If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Hno.Text = dt.Rows(0).Item("Houseno")
                    fparty.Tag = dt.Rows(0).Item("fid")
                    fparty.Text = dt.Rows(0).Item("fname")
                    toparty.Tag = dt.Rows(0).Item("tid")
                    toparty.Text = dt.Rows(0).Item("tname")
                    Month.Tag = dt.Rows(0).Item("Mid")
                    Month.Text = dt.Rows(0).Item("Monthname")
                    tharavno.Text = dt.Rows(0).Item("TharavNo")
                    Tharavdate.Text = dt.Rows(0).Item("Tharavdate")
                    vremarks.Text = dt.Rows(0).Item("Vremarks")
                    lremarks.Text = dt.Rows(0).Item("Lremarks")
                    If dt.Rows.Count > 1 Then
                        sec = True
                    Else
                        sec = False
                    End If
                    Button1.Focus()
                Else
                    If MessageBox.Show("Do You Want To Add Other Entry For This Home...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        sec = True
                        fparty.Text = ob.FindOneString("Select tname from Transfer where Houseno=" & Hno.Text & "", ob.getconnection())
                        fparty.Tag = ob.FindOneString("Select tid from Transfer where Houseno=" & Hno.Text & "", ob.getconnection())
                    Else
                        sec = False
                    End If
                End If
            Else
                    fparty.Text = ob.FindOneString("Select Party_name from Party_master where Gstno=" & Hno.Text & "", ob.getconnection())
                    fparty.Tag = ob.FindOneString("Select Party_id from Party_master where Gstno=" & Hno.Text & "", ob.getconnection())
            End If
        End If
    End Sub

    Private Sub toparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toparty.Validated
        If toparty.Text <> "" Then
            toparty.Tag = ob.FindOneString("Select Party_id from Party_master where Party_name='" & toparty.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub Month_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Month.TextChanged
        If Month.Text <> "" Then
            Month.Tag = ob.FindOneinteger("Select Id from Month Where Monthname='" & Month.Text & "'", ob.getconnection())
        End If
    End Sub

    Private Sub Hno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles toparty.KeyDown, Month.KeyDown, Hno.KeyDown, fparty.KeyDown, Tharavdate.KeyDown, tharavno.KeyDown, vremarks.KeyDown, lremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tms As DataTable = ob.Returntable("select * from Party_master where Party_id=" & toparty.Tag & " and gstno is null", ob.getconnection())
        If tms.Rows.Count > 0 Then
        Else
            Dim nm As DataTable = ob.Returntable("select * from Party_master where Party_id=" & toparty.Tag & "", ob.getconnection())

            Dim pid As String = ob.FindOneString("select max(Party_id) from Party_Master", ob.getconnection())
            pid = pid + 1
            ob.Execute("Insert Into Party_Master (Company_id,Party_id,Party_name,Mobileno,gstno,pid) Values(1," & pid & ",'" & Trim(nm.Rows(0).Item("Party_name")) & "','" & Trim(nm.Rows(0).Item("Mobileno")) & "'," & Val(Hno.Text) & "," & Val(toparty.Tag) & ")", ob.getconnection())
            toparty.Tag = pid
        End If

        If sec = False Then
            ob.Execute("Delete From Transfer Where Houseno=" & Hno.Text & " and Tharavno=" & tharavno.Text & "", ob.getconnection())
            ob.Execute("Insert Into Transfer(Houseno, fid, fname, tid, tname, Mid, Monthname,Tharavdate, TharavNo, Vremarks, Lremarks) Values(" & Hno.Text & "," & fparty.Tag & ",'" & fparty.Text & "'," & toparty.Tag & ",'" & toparty.Text & "'," & Month.Tag & ",'" & Month.Text & "','" & ob.DateConversion(Tharavdate.Text) & "'," & tharavno.Text & ",'" & vremarks.Text & "','" & lremarks.Text & "')", ob.getconnection())
            MessageBox.Show("Saved")
            Hno.Clear()
            fparty.Clear()
            toparty.Clear()
            Month.Clear()
            Hno.Focus()
        Else
            ob.Execute("Insert Into Transfer(Houseno, fid, fname, tid, tname, Mid, Monthname,Tharavdate, TharavNo, Vremarks, Lremarks) Values(" & Hno.Text & "," & fparty.Tag & ",'" & fparty.Text & "'," & toparty.Tag & ",'" & toparty.Text & "'," & Month.Tag & ",'" & Month.Text & "','" & ob.DateConversion(Tharavdate.Text) & "'," & tharavno.Text & ",'" & vremarks.Text & "','" & lremarks.Text & "')", ob.getconnection())
            MessageBox.Show("Saved")
            Hno.Clear()
            fparty.Clear()
            toparty.Clear()
            Month.Clear()
            Hno.Focus()
            sec = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("Delete From Transfer Where Houseno=" & Hno.Text & " and Tharavno=" & tharavno.Text & "", ob.getconnection())
            If MessageBox.Show("Do You Want To Delete This Entry On Party Master...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ob.Execute("Delete From Party_master Where Party_id=" & toparty.Tag & "", ob.getconnection())
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clsVariables.HelpId = "Houseno"
        clsVariables.HelpName = "fname"
        clsVariables.TbName = "Transfer"
        HelpWin.scodename = "Name"
        HelpWin.sorderby = " order by Houseno"
        HelpWin.tsql = "Select Houseno,fname,tname,Monthname from Transfer"
        HelpWin.ShowDialog()
    End Sub
End Class