Imports WeightPavti.CLS
Public Class HousedetailMaster

    Private Sub HouseNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tperson.KeyDown, tname.KeyDown, sname.KeyDown, plno.KeyDown, lanno.KeyDown, HouseNo.KeyDown, gasmitno.KeyDown, gascn.KeyDown, elemino.KeyDown, elecn.KeyDown, bname.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ob.Execute("Delete From Housedetail Where Id=" & HouseNo.Text & "", ob.getconnection())
        ob.Execute("Insert Into Housedetail(id,fname,sname,tname,pno,lno,elemno,elecno,gasmno,gascno,tperson,bhadut) Values(" & HouseNo.Text & ",'" & Trim(Name.Text) & "','" & Trim(sname.Text) & "','" & Trim(tname.Text) & "','" & Trim(plno.Text) & "','" & Trim(lanno.Text) & "','" & Trim(elemino.Text) & "','" & Trim(elecn.Text) & "','" & Trim(gasmitno.Text) & "','" & Trim(gascn.Text) & "'," & Val(tperson.Text) & ",'" & Trim(bname.Text) & "')", ob.getconnection())
        Dim chk As DataTable = ob.Returntable("select * from Party_Master Where gstno=" & HouseNo.Text & "", ob.getconnection())
        If chk.Rows.Count > 0 Then
        Else
            Dim nm As DataTable = ob.Returntable("select isnull(GSTno,2004)as hno,Party_Name,Mobileno from Party_Master where Party_id=" & Name.Tag & "", ob.getconnection())
            If nm.Rows(0).Item("hno") = 2004 Then
                ob.Execute("Update Party_Master Set Gstno=" & HouseNo.Text & " Where Party_id=" & Name.Tag & "", ob.getconnection())
            Else
                Dim pid As String = ob.FindOneString("select max(Party_id) from Party_Master", ob.getconnection())
                pid = pid + 1
                ob.Execute("Insert Into Party_Master (Company_id,Party_id,Party_name,Mobileno,gstno,pid) Values(1," & pid & ",'" & Trim(nm.Rows(0).Item("Party_name")) & "','" & Trim(nm.Rows(0).Item("Mobileno")) & "'," & Val(HouseNo.Text) & "," & Val(Name.Tag) & ")", ob.getconnection())
            End If
        End If
            MessageBox.Show("Saved")
        cleartext()
        HouseNo.Focus()
    End Sub
    Public Sub cleartext()
        HouseNo.Clear()
        Name.Clear()
        sname.Clear()
        tname.Clear()
        plno.Clear()
        lanno.Clear()
        elecn.Clear()
        elemino.Clear()
        gascn.Clear()
        gasmitno.Clear()
        tperson.Clear()
        bname.Clear()
    End Sub

    Private Sub HouseNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles HouseNo.Validating
        If HouseNo.Text <> "" Then
            Name.Text = ob.FindOneString("Select Party_Name From Party_Master Where gstno=" & HouseNo.Text & "", ob.getconnection())
            Name.Tag = ob.FindOneString("Select Party_id From Party_Master Where gstno=" & HouseNo.Text & "", ob.getconnection())
            Dim dt As DataTable = ob.Returntable("Select * from HouseDetail where id=" & HouseNo.Text & "", ob.getconnection())
            If dt.Rows.Count > 0 Then
                If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    sname.Text = dt.Rows(0).Item("sname")
                    tname.Text = dt.Rows(0).Item("tname")
                    plno.Text = dt.Rows(0).Item("pno")
                    lanno.Text = dt.Rows(0).Item("lno")
                    elecn.Text = dt.Rows(0).Item("elecno")
                    elemino.Text = dt.Rows(0).Item("elemno")
                    gascn.Text = dt.Rows(0).Item("gascno")
                    gasmitno.Text = dt.Rows(0).Item("gasmno")
                    tperson.Text = dt.Rows(0).Item("tperson")
                    bname.Text = dt.Rows(0).Item("bhadut")
                Else
                    HouseNo.Clear()
                    Name.Clear()
                    HouseNo.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("Delete From Housedetail Where Id=" & HouseNo.Text & "", ob.getconnection())
            Dim dts As DataTable = ob.Returntable("Select * from Party_Master Where Party_Name='" & Name.Text & "'", ob.getconnection())
            If dts.Rows.Count <= 1 Then
                MessageBox.Show("કૃપા કરી ધ્યાન આપો આ એન્ટ્રી ડિલીટ નઇ થસે આની સીધી અસર પાર્ટી માસ્ટર ને થસે કૃપા કરી એડિટ કરો", "ઘર નું સોફ્ટવેર ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                ob.Execute("Delete From Party_Master Where gstno=" & HouseNo.Text & "", ob.getconnection())
            End If
            cleartext()
        End If
    End Sub

    Private Sub HousedetailMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        autoname()
    End Sub
    Public Sub autoname()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Party_name from Party_master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Party_name"))
        Next
        Name.AutoCompleteMode = AutoCompleteMode.Suggest
        Name.AutoCompleteSource = AutoCompleteSource.CustomSource
        Name.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub Name_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Name.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Name.Text <> "" Then
                sname.Focus()
            Else
                clsVariables.HelpId = "gstno"
                clsVariables.HelpName = "Party_name"
                clsVariables.TbName = "Party_master"
                HelpWin.scodename = "Name"
                HelpWin.sorderby = " order by Party_id"
                HelpWin.tsql = "Select gstno,Party_name from Party_master Where Company_id=1"
                HelpWin.ShowDialog()
                If clsVariables.RtnHelpId <> "" Then
                    ' hno.Text = clsVariables.RtnHelpId
                    Name.Text = clsVariables.RtnHelpName
                    Name.Tag = ob.FindOneString("Select Party_id from Party_master where Party_name='" & Name.Text & "'", ob.getconnection())
                    'lblhouseno.Text = "House No : " & ob.FindOneString("Select gstno from Party_master where Party_id=" & Partname.Tag & "", ob.getconnection())
                    'autonn()
                    'outstnding()
                Else
                    'hno.Focus()
                    Name.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Name_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name.Validated
        Name.Tag = ob.FindOneString("select Party_id from Party_Master Where Party_name='" & Name.Text & "'", ob.getconnection())

        If Val(Name.Tag) = 0 Then
            MessageBox.Show("Sorry Invalid Name Selection", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Name.Clear()
            Name.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clsVariables.HelpId = "id"
        clsVariables.HelpName = "sname"
        clsVariables.TbName = "Housedetail"
        HelpWin.scodename = "Name"
        HelpWin.sorderby = " order by id"
        HelpWin.tsql = "Select id,fname from Housedetail"
        HelpWin.ShowDialog()
    End Sub
End Class