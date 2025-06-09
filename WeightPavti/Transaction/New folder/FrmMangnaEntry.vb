Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class FrmMangnaEntry
    Private Sub FrmMemberMasterNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dt As DataTable = ob.Returntable("select * from member_master order by member_id", ob.getconnection())
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dg1.Rows.Add()
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Member_id")
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Member_Name")
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Village_name from village_master where village_id=" & Val(dt.Rows(i).Item("village_id")) & "", ob.getconnection())
        'Next
        TxtFill("Select name from ItemGroup", txtvillageid)
        TxtFill("Select village_name from village_master", txtvillagename)
        TxtFill("Select member_name from member_master", txtname)
        TxtFill("Select name from itemgroup", txtcolumn)
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "'  and ptype='Mangna'", ob.getconnection())
        acname.Tag = 22
        acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
        Dim msk As String = billDt.Mask
        billDt.Text = Now
        billDt.Refresh()
        billDt.Mask = msk
        srno.Text = 1
    End Sub

    Private Sub txtmemberid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtvillagename.KeyDown, txtvillageid.KeyDown, txtsrno.KeyDown, txtname.KeyDown, Billno.KeyDown, txthektar.KeyDown, txtguntha.KeyDown, txtboxno.KeyDown, txtare.KeyDown, txtaackar.KeyDown, txtaguntha.KeyDown, txtrate.KeyDown, txtamount.KeyDown, txtlper.KeyDown, txtloamt.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtmobileno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            srno.Focus()
        End If
    End Sub

    Private Sub txtcolumn_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtcolumn.Validating
        txtcolumn.Tag = ob.FindOneString("select code from itemgroup where name=N'" & Trim(txtcolumn.Text) & "' or code=" & Val(txtcolumn.Text) & "", ob.getconnection())
        If Val(txtcolumn.Tag) <> 0 Then
            txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            addvalue()
        End If
    End Sub

    Private Sub txtcolumn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcolumn.KeyDown
        If e.KeyCode = Keys.Enter Then
            srno.Focus()
        End If
    End Sub
    Public Sub addvalue()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Dim dts As DataTable = ob.Returntable("select * from LanDetail where code=" & Val(txtname.Tag) & " and season=" & Val(txtcolumn.Tag) & "", ob.getconnection())
        For i As Integer = 0 To dts.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(i).Cells(0).Value = Val(dts.Rows(i).Item("srno"))
            dg.Rows(i).Cells(1).Tag = Val(dts.Rows(i).Item("cityname"))
            dg.Rows(i).Cells(1).Value = ob.FindOneString("select village_name from village_master where  village_id=" & Val(dts.Rows(i).Item("cityname")) & "", ob.getconnection())
            dg.Rows(i).Cells(2).Value = Val(dts.Rows(i).Item("blockNo"))
            dg.Rows(i).Cells(3).Value = Val(dts.Rows(i).Item("ServeNo"))
            dg.Rows(i).Cells(4).Value = Val(dts.Rows(i).Item("Hektar"))
            dg.Rows(i).Cells(5).Value = Val(dts.Rows(i).Item("Guntha"))
            dg.Rows(i).Cells(6).Value = Val(dts.Rows(i).Item("Area"))
            dg.Rows(i).Cells(7).Value = Val(dts.Rows(i).Item("Hektar"))
            dg.Rows(i).Cells(8).Value = Val(dts.Rows(i).Item("Guntha"))
            dg.Rows(i).Cells(9).Value = ob.FindOneString("select limit from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
            Dim hk = Val(dg.Rows(i).Cells(7).Value) * 100
            Dim dkd = Val(hk) + Val(dg.Rows(i).Cells(8).Value)
            Dim amt = Val(Val(dkd) * Val(dg.Rows(i).Cells(9).Value)) / 100
            amt = Format(Val(amt), "###0.00")
            dg.Rows(i).Cells(10).Value = Val(amt)
            dg.Rows(i).Cells(11).Value = 20
            Dim lamt = Val(amt) * Val(dg.Rows(i).Cells(11).Value) / 100
            lamt = Format(Val(lamt), "###0.00")
            Dim netamt = Val(amt) + Val(lamt)
            netamt = Math.Round(Val(netamt))
            dg.Rows(i).Cells(12).Value = Val(lamt)
            dg.Rows(i).Cells(13).Value = Val(netamt)
        Next
        cal()
    End Sub
    Public Sub cal()
        Dim amt As Double = 0
        Dim amt1 As Double = 0
        Dim amt2 As Double = 0
        Dim amt3 As Double = 0
        Dim amt4 As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            amt += Val(dg.Rows(i).Cells(7).Value)
            amt1 += Val(dg.Rows(i).Cells(8).Value)
            amt2 += Val(dg.Rows(i).Cells(10).Value)
            amt3 += Val(dg.Rows(i).Cells(12).Value)
            amt4 += Val(dg.Rows(i).Cells(13).Value)
        Next
        Dim vbb = Val(amt) * 100
        Dim vcb = vbb + Val(amt1)
        txtnetar.Text = Val(vcb) / 100
        txtnete.Text = Val(txtnetar.Text)
        txtam.Text = Val(amt2)
        txtlam.Text = Val(amt3)
        txtnetamt.Text = Val(amt4)
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

    Private Sub txtmemberid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        filldata(Val(Billno.Text))
    End Sub
    Public Sub filldata(ByVal membid As Integer)
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & " and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            ' If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Billno.Text = membid
            billDt.Text = dt.Rows(0).Item("billdate")
            txtname.Tag = dt.Rows(0).Item("partyid")
            txtname.Text = ob.FindOneString("select member_name from Member_master where member_id=" & Val(dt.Rows(0).Item("partyid")) & "", ob.getconnection())
            txtvillageid.Tag = dt.Rows(0).Item("clid")
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(dt.Rows(0).Item("clid")) & "", ob.getconnection())
            txtcolumn.Tag = dt.Rows(0).Item("tid")
            If (txtcolumn.Tag) <> 0 Then
                txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            End If
            acname.Enabled = False
            Dim dts As DataTable = ob.Returntable("select * from acstock where billno=" & Val(Billno.Text) & " and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            If dg.Rows.Count > 0 Then
                dg.Rows.Clear()
            End If
            For i As Integer = 0 To dts.Rows.Count - 1
                dg.Rows.Add()
                dg.Rows(i).Cells(0).Value = Val(dts.Rows(i).Item("srno"))
                dg.Rows(i).Cells(1).Tag = Val(dts.Rows(i).Item("Itemid"))
                dg.Rows(i).Cells(1).Value = ob.FindOneString("select village_name from village_master where  village_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                dg.Rows(i).Cells(2).Value = Val(dts.Rows(i).Item("blockNo"))
                dg.Rows(i).Cells(3).Value = Val(dts.Rows(i).Item("ServeNo"))
                dg.Rows(i).Cells(4).Value = Val(dts.Rows(i).Item("Hektar"))
                dg.Rows(i).Cells(5).Value = Val(dts.Rows(i).Item("Guntha"))
                dg.Rows(i).Cells(6).Value = Val(dts.Rows(i).Item("Aker"))
                dg.Rows(i).Cells(7).Value = Val(dts.Rows(i).Item("AHektar"))
                dg.Rows(i).Cells(8).Value = Val(dts.Rows(i).Item("AGuntha"))
                dg.Rows(i).Cells(9).Value = Val(dts.Rows(i).Item("Rate1"))
                dg.Rows(i).Cells(10).Value = Val(dts.Rows(i).Item("Amount"))
                dg.Rows(i).Cells(11).Value = Val(dts.Rows(i).Item("LPer"))
                dg.Rows(i).Cells(12).Value = Val(dts.Rows(i).Item("LFund"))
                dg.Rows(i).Cells(13).Value = Val(dts.Rows(i).Item("TotalAmount"))
            Next
            cal()
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
        txtvillageid.Tag = ob.FindOneString("select column_id from column_master where column_name=N'" & Trim(txtvillageid.Text) & "' or column_id=" & Val(txtvillageid.Text) & "", ob.getconnection())
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtvillagename_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillagename.Validating
        txtvillagename.Tag = ob.FindOneString("select village_id from village_master where village_name=N'" & Val(txtvillagename.Text) & "' or village_id=" & Val(txtvillagename.Text) & "", ob.getconnection())
        If Val(txtvillagename.Tag) <> 0 Then
            txtvillagename.Text = ob.FindOneString("select village_name from village_master where  village_id=" & Val(txtvillagename.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        If dg.Rows.Count > 0 Then
            ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & "  and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and  ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            Dim spid As String = ob.FindOneString("Select account_id from column_master Where column_id=" & Val(txtcolumn.Tag) & "", ob.getconnection())

            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Loanno, Fdno,Basic, Netamt,Paymentamt,ptype,rate,tid,clid) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','Mangna','Mangna'," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(txtname.Tag) & "," & Val(spid) & ",N'" & Trim(txtname.Text) & "'," & Val(txtnetar.Text) & "," & Val(txtnete.Text) & "," & Val(txtam.Text) & "," & Val(txtnetamt.Text) & "," & Val(txtnetamt.Text) & ",'Mangna'," & Val(txtlam.Text) & "," & Val(txtcolumn.Tag) & "," & Val(txtvillageid.Tag) & ")", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','Mangna'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & spid & ",N'" & txtcolumn.Text & "'," & (txtnetamt.Text) & ",N'" & Trim(txtname.Text) & "',0,'Mangna','Mangna')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','Mangna'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & (txtnetamt.Text) & ",N'" & Trim(txtname.Text) & "',0,'Mangna','Mangna')", ob.getconnection())
            For i As Integer = 0 To dg.Rows.Count - 1
                ob.Execute("Insert Into Acstock(Cid, Year_id, Department, Billno, Billdate,ptype,Billtype,srno,Itemid,blockNo, ServeNo, Hektar, Guntha, Aker, AHektar, AGuntha, Rate1,Amount, LPer, LFund, TotalAmount) Values(1,'" & clsVariables.WorkingYear & "','Mangna'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "','Mangna','Mangna'," & dg.Rows(i).Cells(0).Value & "," & dg.Rows(i).Cells(1).Tag & "," & dg.Rows(i).Cells(2).Value & "," & dg.Rows(i).Cells(3).Value & "," & dg.Rows(i).Cells(4).Value & "," & dg.Rows(i).Cells(5).Value & "," & dg.Rows(i).Cells(6).Value & "," & dg.Rows(i).Cells(7).Value & "," & dg.Rows(i).Cells(8).Value & "," & dg.Rows(i).Cells(9).Value & "," & dg.Rows(i).Cells(10).Value & "," & dg.Rows(i).Cells(11).Value & "," & dg.Rows(i).Cells(12).Value & "," & dg.Rows(i).Cells(13).Value & ")", ob.getconnection())
            Next
            MessageBox.Show("Save")
            clear()
            subclear()

        End If
    End Sub
    Public Sub clear()
        txtvillageid.Clear()
        txtname.Clear()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If

        'Dim dt As DataTable = ob.Returntable("select * from member_master order by member_id", ob.getconnection())
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dg1.Rows.Add()
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Member_id")
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Member_Name")
        '    dg1.Rows(dg1.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Village_name from village_master where village_id=" & Val(dt.Rows(i).Item("village_id")) & "", ob.getconnection())
        'Next
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "'  and ptype='Mangna'", ob.getconnection())
        Billno.Focus()
        srno.Text = 1
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where billno=" & Val(Billno.Text) & " and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where Docno=" & Val(Billno.Text) & "  and ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acstock where billno=" & Val(Billno.Text) & " and  ptype='Mangna' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("Delete")
        clear()
        subclear()
    End Sub

    Private Sub txtname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        txtname.Tag = ob.FindOneString("select member_id from member_master where member_name=N'" & Trim(txtname.Text) & "' or member_id=" & Val(txtname.Text) & "", ob.getconnection())
        If Val(txtname.Tag) <> 0 Then
            txtname.Text = ob.FindOneString("select member_name from member_master where  member_id=" & Val(txtname.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtrate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Dim hk = Val(txtaackar.Text) * 100
        Dim dkd = Val(hk) + Val(txtaguntha.Text)
        txtamount.Text = Val(Val(dkd) * Val(txtrate.Text)) / 100
        txtamount.Text = Format(Val(txtamount.Text), "###0.00")
    End Sub

    Private Sub txtlper_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtlper.Validating
        txtloamt.Text = Val(txtamount.Text) * Val(txtlper.Text) / 100
        txtloamt.Text = Format(Val(txtloamt.Text), "###0.00")
        txtnamt.Text = Val(txtamount.Text) + Val(txtloamt.Text)
        txtnamt.Text = Math.Round(Val(txtnamt.Text))
    End Sub

    Private Sub srno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles srno.Validating
        For i As Integer = 0 To dg.Rows.Count - 1
            If srno.Text = dg.Rows(i).Cells(0).Value Then
                txtvillagename.Tag = dg.Rows(i).Cells(1).Tag
                txtvillagename.Text = dg.Rows(i).Cells(1).Value
                txtboxno.Text = dg.Rows(i).Cells(2).Value
                txtsrno.Text = dg.Rows(i).Cells(3).Value
                txthektar.Text = dg.Rows(i).Cells(4).Value
                txtguntha.Text = dg.Rows(i).Cells(5).Value
                txtare.Text = dg.Rows(i).Cells(6).Value
                txtaackar.Text = dg.Rows(i).Cells(7).Value
                txtaguntha.Text = dg.Rows(i).Cells(8).Value
                txtrate.Text = dg.Rows(i).Cells(9).Value
                txtamount.Text = dg.Rows(i).Cells(10).Value
                txtlper.Text = dg.Rows(i).Cells(11).Value
                txtloamt.Text = dg.Rows(i).Cells(12).Value
                txtnamt.Text = dg.Rows(i).Cells(13).Value
            End If
        Next
    End Sub

    Private Sub txtnamt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(srno.Text) > dg.Rows.Count Then
                dg.Rows.Add()
                dg.Rows(srno.Text - 1).Cells(1).Tag = txtvillagename.Tag
                dg.Rows(srno.Text - 1).Cells(1).Value = txtvillagename.Text
                dg.Rows(srno.Text - 1).Cells(2).Value = txtboxno.Text
                dg.Rows(srno.Text - 1).Cells(3).Value = txtsrno.Text
                dg.Rows(srno.Text - 1).Cells(4).Value = txthektar.Text
                dg.Rows(srno.Text - 1).Cells(5).Value = txtguntha.Text
                dg.Rows(srno.Text - 1).Cells(6).Value = txtare.Text
                dg.Rows(srno.Text - 1).Cells(7).Value = txtaackar.Text
                dg.Rows(srno.Text - 1).Cells(8).Value = txtaguntha.Text
                dg.Rows(srno.Text - 1).Cells(9).Value = txtrate.Text
                dg.Rows(srno.Text - 1).Cells(10).Value = txtamount.Text
                dg.Rows(srno.Text - 1).Cells(11).Value = txtlper.Text
                dg.Rows(srno.Text - 1).Cells(12).Value = txtloamt.Text
                dg.Rows(srno.Text - 1).Cells(13).Value = txtnamt.Text
                srno.Text = srno.Text + 1
            Else
                dg.Rows(srno.Text - 1).Cells(0).Value = srno.Text
                dg.Rows(srno.Text - 1).Cells(1).Tag = txtvillagename.Tag
                dg.Rows(srno.Text - 1).Cells(1).Value = txtvillagename.Text
                dg.Rows(srno.Text - 1).Cells(2).Value = txtboxno.Text
                dg.Rows(srno.Text - 1).Cells(3).Value = txtsrno.Text
                dg.Rows(srno.Text - 1).Cells(4).Value = txthektar.Text
                dg.Rows(srno.Text - 1).Cells(5).Value = txtguntha.Text
                dg.Rows(srno.Text - 1).Cells(6).Value = txtare.Text
                dg.Rows(srno.Text - 1).Cells(7).Value = txtaackar.Text
                dg.Rows(srno.Text - 1).Cells(8).Value = txtaguntha.Text
                dg.Rows(srno.Text - 1).Cells(9).Value = txtrate.Text
                dg.Rows(srno.Text - 1).Cells(10).Value = txtamount.Text
                dg.Rows(srno.Text - 1).Cells(11).Value = txtlper.Text
                dg.Rows(srno.Text - 1).Cells(12).Value = txtloamt.Text
                dg.Rows(srno.Text - 1).Cells(13).Value = txtnamt.Text
                srno.Text = dg.Rows.Count + 1
            End If
        End If
        subclear()
        cal()
    End Sub
    Public Sub subclear()
        srno.Clear()
        txtvillagename.Clear()
        txtvillagename.Clear()
        txtboxno.Clear()
        txtsrno.Clear()
        txthektar.Clear()
        txtguntha.Clear()
        txtare.Clear()
        txtaackar.Clear()
        txtaguntha.Clear()
        txtrate.Clear()
        txtamount.Clear()
        txtlper.Clear()
        txtloamt.Clear()
        txtnamt.Clear()
        srno.Focus()

    End Sub

    Private Sub txtcolumn_Validated(sender As Object, e As EventArgs) Handles txtcolumn.Validated

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clsVariables.Findqueri = "select billno,billdate,PartyId,m.member_name as membername,Netamt from Acmain as a inner join MEMBER_MASTER as m on a.PartyId=m.Member_Id where year_id='" & clsVariables.WorkingYear & "' and ptype='Mangna' order by billno"
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Billno.Text = clsVariables.HelpId
        filldata(Val(Billno.Text))
    End Sub
End Class