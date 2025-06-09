Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class FrmMemberMasterNew
    Private Sub FrmMemberMasterNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select village_name from village_master", txtvillageid)
        TxtFill("Select village_name from village_master", txtvillagename)
        TxtFill("Select name from itemgroup", txtcolumn)
        txtmemberid.Text = ob.FindOneString("select isnull(max(Member_id),0)+1 from member_master", ob.getconnection())
        txtmemberid.Focus()
    End Sub

    Private Sub txtmemberid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtvillagename.KeyDown, txtvillageid.KeyDown, txtsrno.KeyDown, txtname.KeyDown, txtmemberid.KeyDown, txthektar.KeyDown, txtguntha.KeyDown, txtboxno.KeyDown, txtare.KeyDown, txtkhata.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{Tab}")

        End If
    End Sub

    Private Sub txtmobileno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtmobileno.KeyDown
        If e.KeyCode = Keys.Enter Then
            srno.Focus()
        End If
    End Sub

    Private Sub txtcolumn_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtcolumn.Validating

    End Sub

    Private Sub txtcolumn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcolumn.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtcolumn.Tag = ob.FindOneString("select code from itemgroup where name=N'" & Trim(txtcolumn.Text) & "' or code=" & Val(txtcolumn.Text) & "", ob.getconnection())
            If (txtcolumn.Tag) <> 0 Then
                txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            End If
            If Val(srno.Text) > dg.Rows.Count Then
                dg.Rows.Add()
                dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                dg.Rows(srno.Text - 1).Cells(1).Value = txtvillagename.Text
                dg.Rows(srno.Text - 1).Cells(1).Tag = txtvillagename.Tag
                dg.Rows(srno.Text - 1).Cells(2).Value = txtkhata.Text
                dg.Rows(srno.Text - 1).Cells(3).Value = txtboxno.Text
                dg.Rows(srno.Text - 1).Cells(4).Value = txtsrno.Text
                dg.Rows(srno.Text - 1).Cells(5).Value = txthektar.Text
                dg.Rows(srno.Text - 1).Cells(6).Value = txtguntha.Text
                dg.Rows(srno.Text - 1).Cells(7).Value = txtare.Text
                dg.Rows(srno.Text - 1).Cells(8).Value = txtcolumn.Text
                dg.Rows(srno.Text - 1).Cells(8).Tag = txtcolumn.Tag
                srno.Text = srno.Text + 1
            Else
                dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                dg.Rows(srno.Text - 1).Cells(1).Value = txtvillagename.Text
                dg.Rows(srno.Text - 1).Cells(1).Tag = txtvillagename.Tag
                dg.Rows(srno.Text - 1).Cells(2).Value = txtkhata.Text
                dg.Rows(srno.Text - 1).Cells(3).Value = txtboxno.Text
                dg.Rows(srno.Text - 1).Cells(4).Value = txtsrno.Text
                dg.Rows(srno.Text - 1).Cells(5).Value = txthektar.Text
                dg.Rows(srno.Text - 1).Cells(6).Value = txtguntha.Text
                dg.Rows(srno.Text - 1).Cells(7).Value = txtare.Text
                dg.Rows(srno.Text - 1).Cells(8).Value = txtcolumn.Text
                dg.Rows(srno.Text - 1).Cells(8).Tag = txtcolumn.Tag
                srno.Text = dg.Rows.Count + 1
            End If
            subclear()
        End If

    End Sub
    Public Sub subclear()
        txtvillagename.Tag = 0
        txtvillagename.Clear()
        txtboxno.Clear()
        txtsrno.Clear()
        txtguntha.Clear()
        txthektar.Clear()
        txtare.Clear()
        txtcolumn.Tag = 0
        txtcolumn.Clear()
        srno.Focus()

    End Sub
    Public Sub TxtFill(ByVal Sqlstring As String, ByVal txtBox As TextBox)
        Dim sStringColl As New AutoCompleteStringCollection
        Dim qryCity As String
        Dim SqlConnString As String = "Password=advsys;Data Source=" & servername & ";Initial Catalog=" & dbname & ";Integrated Security=False;Persist Security Info=False;User ID=advsys;Max Pool Size=5000;Connect Timeout=0"
        qryCity = "SELECT DISTINCT NAME FROM ACMASTER  ORDER By NAME"

        Using connection As New SqlConnection(SqlConnString)

            Dim cmdCity As New SqlCommand(Sqlstring, connection)
            connection.Open()

            Dim city_reader As SqlDataReader = cmdCity.ExecuteReader()

            ' Loop through the data.
            While city_reader.Read()
                sStringColl.AddRange(New String() {Trim(city_reader(0).ToString)})
            End While

            city_reader.Close()
        End Using
        txtBox.AutoCompleteCustomSource = sStringColl
        txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub txtmemberid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtmemberid.Validating
        filldata(Val(txtmemberid.Text))
    End Sub
    Public Sub filldata(ByVal membid As Integer)
        Dim dt As DataTable = ob.Returntable("select * from member_master where member_id=" & Val(membid) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            'If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            txtmemberid.Text = membid
            txtname.Text = dt.Rows(0).Item("member_name")
            txtvillageid.Tag = dt.Rows(0).Item("village_id")
            txtvillageid.Text = ob.FindOneString("select Village_name from village_master where village_id=" & Val(dt.Rows(0).Item("village_id")) & "", ob.getconnection())
            Dim dts As DataTable = ob.Returntable("select * from LanDetail where code=" & Val(membid) & "", ob.getconnection())
            For i As Integer = 0 To dts.Rows.Count - 1
                dg.Rows.Add()
                dg.Rows(i).Cells(0).Value = dts.Rows(i).Item("srno")
                dg.Rows(i).Cells(1).Value = ob.FindOneString("select Village_name from village_master where village_id=" & Val(dts.Rows(i).Item("cityname")) & "", ob.getconnection())
                dg.Rows(i).Cells(1).Tag = dts.Rows(i).Item("cityname")
                dg.Rows(i).Cells(3).Value = dts.Rows(i).Item("Blockno")
                dg.Rows(i).Cells(4).Value = dts.Rows(i).Item("serveno")
                dg.Rows(i).Cells(5).Value = dts.Rows(i).Item("hektar")
                dg.Rows(i).Cells(6).Value = dts.Rows(i).Item("Guntha")
                dg.Rows(i).Cells(7).Value = dts.Rows(i).Item("Area")
                dg.Rows(i).Cells(8).Value = ob.FindOneString("select Name from ItemGroup where Code=" & Val(dts.Rows(i).Item("Season")) & "", ob.getconnection())
                dg.Rows(i).Cells(8).Tag = dts.Rows(i).Item("Season")
                dg.Rows(i).Cells(2).Value = ob.IfNullThen(dts.Rows(i).Item("khatano"), 0)

            Next
            'End If
        End If
    End Sub

    Private Sub srno_KeyDown(sender As Object, e As KeyEventArgs) Handles srno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(srno.Text) = 0 Then
                ButSave.Focus()
            Else
                SendKeys.Send("{Tab}")
            End If
        End If
    End Sub
    Private Sub txtvillageid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillageid.Validating
        txtvillageid.Tag = ob.FindOneString("select village_id from village_master where village_name=N'" & Val(txtvillageid.Text) & "' or village_id=" & Val(txtvillageid.Text) & "", ob.getconnection())
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select village_name from village_master where  village_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtvillagename_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillagename.Validating
        txtvillagename.Tag = ob.FindOneString("select village_id from village_master where village_name=N'" & Trim(txtvillagename.Text) & "' or village_id=" & Val(txtvillagename.Text) & "", ob.getconnection())
        If Val(txtvillagename.Tag) <> 0 Then
            txtvillagename.Text = ob.FindOneString("select village_name from village_master where  village_id=" & Val(txtvillagename.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from member_master where member_id=" & Val(txtmemberid.Text) & "", ob.getconnection())
        ob.Execute("delete LanDetail where code=" & Val(txtmemberid.Text) & "", ob.getconnection())
        ob.Execute("Insert Into member_master (company_id,member_id,Member_name,village_id) values(1," & Val(txtmemberid.Text) & ",N'" & Trim(txtname.Text) & "'," & Val(txtvillageid.Tag) & ")", ob.getconnection())
        For i As Integer = 0 To dg.Rows.Count - 1
            ob.Execute("Insert Into LanDetail (Code, SrNo, CityName, Blockno, ServeNo, Hektar, Guntha, Area, Season,khatano) values(" & Val(txtmemberid.Text) & "," & Val(dg.Rows(i).Cells(0).Value) & "," & Val(dg.Rows(i).Cells(1).Tag) & "," & Val(dg.Rows(i).Cells(3).Value) & "," & Val(dg.Rows(i).Cells(4).Value) & "," & Val(dg.Rows(i).Cells(5).Value) & "," & Val(dg.Rows(i).Cells(6).Value) & "," & Val(dg.Rows(i).Cells(7).Value) & "," & Val(dg.Rows(i).Cells(8).Tag) & "," & Val(dg.Rows(i).Cells(2).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("Save")
        clear()
        subclear()
    End Sub
    Public Sub clear()
        txtvillageid.Clear()
        txtname.Clear()
        txtmobileno.Clear()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If

        txtmemberid.Text = ob.FindOneString("select isnull(max(Member_id),0)+1 from member_master", ob.getconnection())
        txtmemberid.Focus()
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from member_master where member_id=" & Val(txtmemberid.Text) & "", ob.getconnection())
        ob.Execute("delete LanDetail where code=" & Val(txtmemberid.Text) & "", ob.getconnection())
        MessageBox.Show("Delete")
        clear()
        subclear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clsVariables.Findqueri = "select Member_id,Member_name,v.Village_name from MEMBER_MASTER inner join VILLAGE_MASTER as v on MEMBER_MASTER.Village_id=v.Village_Id order by Member_id"
        clsVariables.findtablename = "MEMBER_MASTER"
        FrmFind.ShowDialog()
        txtmemberid.Text = clsVariables.HelpId
        filldata(Val(txtmemberid.Text))
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        If Val(srno.Text) <> 0 Then
            srno.Text = dg.Rows(srno.Text - 1).Cells(0).Value
            txtvillagename.Text = dg.Rows(srno.Text - 1).Cells(1).Value
            txtvillagename.Tag = dg.Rows(srno.Text - 1).Cells(1).Tag
            txtkhata.Text = dg.Rows(srno.Text - 1).Cells(2).Value
            txtboxno.Text = dg.Rows(srno.Text - 1).Cells(3).Value
            txtsrno.Text = dg.Rows(srno.Text - 1).Cells(4).Value
            txthektar.Text = dg.Rows(srno.Text - 1).Cells(5).Value
            txtguntha.Text = dg.Rows(srno.Text - 1).Cells(6).Value
            txtare.Text = dg.Rows(srno.Text - 1).Cells(7).Value
            txtcolumn.Text = dg.Rows(srno.Text - 1).Cells(8).Value
            txtcolumn.Tag = dg.Rows(srno.Text - 1).Cells(8).Tag
        Else
            ButSave.Focus()
        End If
    End Sub
End Class