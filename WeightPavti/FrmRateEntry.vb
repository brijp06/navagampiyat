Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class FrmRateEntry
    Private Sub FrmRateEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Item_Name from  Item_Master where Department='BHANDAR'", itemname)
        TxtFill("Select Size_Name from  Size_Master", Sizename)
        TxtFill("Select barcode from  acstock", Barcode)
        loaddg()
    End Sub
    Public Sub loaddg()
        Dim conn As String = ""
        If Barcode.Text <> "" Then
            conn = conn + " and barcode='" & Trim(Barcode.Text) & "'"
        End If
        If Sizename.Text <> "" Then
            conn = conn + " and sizeid='" & Trim(Sizename.Tag) & "'"
        End If
        If itemname.Text <> "" Then
            conn = conn + " and itemid=" & Val(itemname.Tag) & ""
        End If
        conn = conn + " order by itemid"
        Dim dt As DataTable = ob.Returntable("select * from ratemaster where 1=1 " & conn & "", ob.getconnection())
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            Dg.Rows.Add()
            Dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("itemid")
            Dg.Rows(i).Cells(1).Value = ob.FindOneString("select Item_name from item_master where item_id=" & Val(dt.Rows(i).Item("itemid")) & "", ob.getconnection())
            Dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("sizeid")
            Dg.Rows(i).Cells(3).Value = ob.FindOneString("select size_name from size_master where size_id=" & aq(dt.Rows(i).Item("sizeid")) & "", ob.getconnection())
            Dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("barcode")
            Dg.Rows(i).Cells(5).Value = dt.Rows(i).Item("rate")
            Dg.Rows(i).Cells(3).Style.Font = New Font("SHREE-GUJ-0768-S02", 12, FontStyle.Regular)
        Next
        Dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Private Sub Barcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Barcode.Validating
        Dim iid As Integer = ob.FindOneString("select Itemid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
        Dim sid As String = ob.FindOneString("select sizeid from Acstock where barcode='" & Barcode.Text & "'", ob.getconnection())
        itemname.Tag = iid
        Sizename.Tag = sid
        Sizename.Text = ob.FindOneString("select Size_Name from Size_Master where Size_id='" & Trim(sid) & "'", ob.getconnection())
        itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & "", ob.getconnection())
        itemname.Enabled = False
        Sizename.Enabled = False
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

    Private Sub itemname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles itemname.Validating
        itemname.Tag = ob.FindOneString("Select item_Id From Item_Master Where item_Name=N'" & Trim(itemname.Text) & "' or item_Id=" & Val(itemname.Text) & "", ob.getconnection())
        itemname.Text = ob.FindOneString("Select item_Name From Item_Master Where  item_Id=" & Val(itemname.Tag) & "", ob.getconnection())
    End Sub

    Private Sub Sizename_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Sizename.Validating
        Sizename.Tag = ob.FindOneString("Select Size_Id From Size_Master Where  Size_Id='" & Trim(Sizename.Text) & "' or Size_Name=N'" & Trim(Sizename.Text) & "'", ob.getconnection())
        Sizename.Text = ob.FindOneString("Select Size_Name From Size_Master Where  Size_Id='" & Trim(Sizename.Text) & "' or Size_Name=N'" & Trim(Sizename.Text) & "'", ob.getconnection())

    End Sub

    Private Sub Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Sizename.KeyDown, itemname.KeyDown, Barcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loaddg()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = 0 To Dg.Rows.Count - 1
            ob.Execute("update ratemaster set rate=" & Val(Dg.Rows(i).Cells(5).Value) & " where itemid=" & Val(Dg.Rows(i).Cells(0).Value) & " and sizeid='" & Trim(Dg.Rows(i).Cells(2).Value) & "' and barcode='" & Trim(Dg.Rows(i).Cells(4).Value) & "'", ob.getconnection())
        Next
        MessageBox.Show("Save")
    End Sub
End Class