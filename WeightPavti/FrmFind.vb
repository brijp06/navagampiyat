Imports WeightPavti.CLS
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmFind
    Dim dt As New DataSet
    Dim FieldType As Type
    Private Sub FrmFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("=")
        ComboBox2.Items.Add(">=")
        ComboBox2.Items.Add("<=")
        ComboBox2.Items.Add(" Like %")
        ComboBox2.Text = (">=")
        fillgrid(clsVariables.Findqueri)
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
        dg.Font = New Font("HARIKRISHNA", 12.99, FontStyle.Regular, GraphicsUnit.Point)
        dg.ColumnHeadersDefaultCellStyle.Font = New Font("Verdena", 10.0, FontStyle.Regular, GraphicsUnit.Point)
        cmb.Focus()
    End Sub
    Private Sub fillgrid(ByVal cmdText As String)

        dt = ob.ReturnDataset(cmdText, ob.getconnection())
        dg.DataSource = Nothing
        dg.DataSource = dt.Tables("Temp")
        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect



        Dim col As DataColumn
        For Each col In dt.Tables("Temp").Columns
            cmb.Items.Add((col.ColumnName))
        Next
        dg.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim col As DataColumn

        For Each col In dt.Tables("Temp").Columns
            If col.ColumnName = Me.cmb.Text Then
                FieldType = col.DataType ' Decimal
            End If
        Next

        Dim sort As String
        'Dim Rowstate As DataViewRowState
        Dim FilterField As String = ""

        If cmb.Text <> "" Then
            FilterField = cmb.Text
            If TextBox1.Text = "" Then
                Exit Sub
            Else

                'If ComboBox2.Text <> " Like %" Then

                '    Select Case FieldType.Name
                '        Case "String"
                '            FilterField = FilterField & ComboBox2.Text & "'" & TextBox1.Text & "'"
                '        Case "Decimal"
                '            FilterField = FilterField & ComboBox2.Text & Val(TextBox1.Text)
                '        Case "DateTime"
                '            FilterField = FilterField & " = '" & TextBox1.Text & "'"

                '            'CONVERT(CHAR(10),USERSTAMP,101)="09/08/2007"
                '    End Select

                'Else

                Select Case FieldType.Name
                        Case "String"
                            FilterField = FilterField & " Like '%" & TextBox1.Text & "%'"
                        Case "Decimal"
                            FilterField = FilterField & " = " & Val(TextBox1.Text)
                        Case "Int32"
                            FilterField = FilterField & " = " & Val(TextBox1.Text)
                        Case "DateTime"
                            'Format(Now(), "dd/MM/yyyy 00:00")
                            FilterField = FilterField & " = '" & TextBox1.Text & "'"

                    End Select

                End If
            End If


        'FilterField = "'" + FilterField + "'"
        'MessageBox.Show(FilterField)
        sort = cmb.SelectedItem
        dt.Tables("Temp").DefaultView.Sort = sort
        dt.Tables("Temp").DefaultView.RowFilter = FilterField
        'Chargecodeid=65"
        'FilterField

        'myDataset.Tables("finddata").DefaultView.RowStateFilter = _
        '[Enum].Parse(Rowstate.GetType, FieldList.SelectedItem)

        'Rowstate.parese(Rowstate.GetType, FieldList.SelectedItem)

        dg.Focus()

    End Sub

    Private Sub dg_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellDoubleClick
        Dim strVal As String
        strVal = CStr(dg.Item(0, dg.CurrentRow.Index).Value)
        clsVariables.HelpId = strVal
        Me.Close()
    End Sub

    Private Sub dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick

    End Sub

    Private Sub dg_KeyDown(sender As Object, e As KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strVal As String
            strVal = CStr(dg.Item(0, dg.CurrentRow.Index).Value)
            clsVariables.HelpId = strVal
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class