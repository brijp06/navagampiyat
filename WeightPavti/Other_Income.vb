Imports WeightPavti.CLS
Public Class Other_Income
    Dim drows As Integer
    Private Sub Other_Income_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dg.Columns.Add("Product_id", "Product ID")
        dg.Columns.Add("Product_name", "Product Name")
        dg.Columns.Add("Amount", "Amount")
        dg.Columns(0).Width = 100
        dg.Columns(1).Width = 290
        dg.Columns(2).Width = 100
        dg.Columns(1).DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 11, FontStyle.Regular)
        dg.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        txtdocdate.Text = Format(DateTime.Now.Date, "dd/MM/yyyy")
        maxdp()
    End Sub

    Public Sub maxdp()
        Dim dt As DataTable
        dt = ob.Returntable("select isnull(max(doc_no),0)+1 as bv from other_income_main where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        txtdoc_no.Text = dt.Rows(0).Item("bv")
    End Sub

  
    Private Sub txtdoc_no_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdocdate.KeyUp, txtdoc_no.KeyUp, txtdetail.KeyUp
        tabkey(sender, e)
    End Sub

    Private Sub txtid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtid.KeyDown
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Product_Id"
            clsVariables.HelpName = "Product_Name"
            clsVariables.TbName = "Product_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Product_Name"
            HelpWin.tsql = "Select Product_Id,Product_Name from Product_Master where  Company_id=" & Val(clsVariables.CompnyId)
            '& " and Product_Id in (" & sprodID & ")"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtid.Text = clsVariables.RtnHelpId
                txtname.Text = clsVariables.RtnHelpName
                txtamount.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Product_Id"
            clsVariables.HelpName = "Product_Name"
            clsVariables.TbName = "Product_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Product_Id"
            HelpWin.tsql = "Select Product_Id,Product_Name from Product_Master where  Company_id=" & Val(clsVariables.CompnyId)
            '& " and Product_Id in (" & sprodID & ")"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtid.Text = clsVariables.RtnHelpId
                txtname.Text = clsVariables.RtnHelpName
                txtamount.Focus()
            End If

        ElseIf e.KeyCode = Keys.Enter Then

            txtid_Validated(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtid_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.Validated
        Try

            Dim ssql As String = ""
            If txtid.Text <> "" Then
                ssql = "Select Product_Name from Product_Master where  Product_Id= " & Val(txtid.Text) & " and Company_Id=" & clsVariables.CompnyId
                '& " and Product_Id in (" & sprodID & ")"
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtname.Text = dt.Rows(0).Item(0).ToString
                    txtamount.Focus()
                Else

                    MsgBox("Invalid Product Id")
                    txtname.Text = ""
                    txtid.Focus()


                End If
            Else
               
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtamount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtamount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtid.Text <> "" And txtamount.Text <> "" Then
                dg.Rows.Add()
                dg.Rows(dg.Rows.Count - 1).Cells(0).Value = txtid.Text
                dg.Rows(dg.Rows.Count - 1).Cells(1).Value = txtname.Text
                dg.Rows(dg.Rows.Count - 1).Cells(2).Value = txtamount.Text
            End If
            txtid.Clear()
            txtname.Clear()
            txtamount.Clear()
            cal()
            txtid.Focus()
        End If
    End Sub
    Public Sub cal()
        Dim dtal As Double
        For i = 0 To dg.Rows.Count - 1
            dtal += (dg.Rows(i).Cells(2).Value)
        Next
        txttamt.Text = dtal
    End Sub

    Private Sub dg_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg.RowsRemoved
        cal()
    End Sub

    Private Sub dg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        'If e.KeyCode = Keys.Delete Then
        '    dg.Rows.RemoveAt(drows)
        '    cal()
        'End If
    End Sub

    Private Sub dg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        'drows = dg.Rows(e.RowIndex).Index
    End Sub

    Private Sub txtamount_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamount.Validated
      
        End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ob.Execute("delete from other_income_main where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
        ob.Execute("insert into other_income_main (year_id, Doc_no, Doc_date, Details, Total_amt) values (" & aq(clsVariables.WorkingYear) & "," & txtdoc_no.Text & "," & aq(ob.DateConversion(txtdocdate.Text)) & "," & aq(txtdetail.Text) & "," & txttamt.Text & ")", ob.getconnection())
        ob.Execute("delete from other_income_detail where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
        For i = 0 To dg.Rows.Count - 1
            ob.Execute("insert into other_income_detail (Year_id, Doc_no, Product_id, Amount) values(" & aq(clsVariables.WorkingYear) & "," & txtdoc_no.Text & "," & dg.Rows(i).Cells(0).Value & "," & dg.Rows(i).Cells(2).Value & ")", ob.getconnection())
        Next
        MessageBox.Show("Saved")
        txtdetail.Clear()
        maxdp()
        txttamt.Clear()
        txtdetail.Focus()
        dg.Rows.Clear()
    End Sub

    Private Sub txtdoc_no_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc_no.Validated
        Dim dt As DataTable
        dt = ob.Returntable("select * from other_income_main where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            If result1 = Windows.Forms.DialogResult.Yes Then
                txtdoc_no.Text = dt.Rows(0).Item("doc_no")
                txtdocdate.Text = ob.DateConversion(dt.Rows(0).Item("Doc_date"))
                txtdetail.Text = dt.Rows(0).Item("Details")
                txttamt.Text = dt.Rows(0).Item("Total_amt")
                Dim dts As DataTable
                dts = ob.Returntable("select * from other_income_detail where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
                For i = 0 To dts.Rows.Count - 1
                    dg.Rows.Add()
                    dg.Rows(i).Cells(0).Value = dts.Rows(i).Item("Product_id")
                    dg.Rows(i).Cells(1).Value = ob.FindOneString("select product_name from product_master where product_id=" & dts.Rows(i).Item("Product_id") & "", ob.getconnection())
                    dg.Rows(i).Cells(2).Value = dts.Rows(i).Item("amount")


                Next
            End If
        Else

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ob.Execute("delete from other_income_main where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
        ob.Execute("delete from other_income_detail where year_id=" & aq(clsVariables.WorkingYear) & " and doc_no=" & txtdoc_no.Text & "", ob.getconnection())
        MessageBox.Show("delete")
    End Sub
End Class