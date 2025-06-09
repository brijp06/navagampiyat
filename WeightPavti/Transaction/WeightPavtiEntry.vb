Imports System.IO
Imports WeightPavti.CLS
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Threading
Imports System.Data
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms

Public Class WeightPavtiEntry

    Private Sub InwardAutoWeightEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiMain
        ' strart()
        ' Dim bw As BackgroundWorker = New BackgroundWorker
        cashbank()
        dpv()
        dpvc()
        Dgpvcuu()
        bki()
        bkio()
        Timer1.Start()
    End Sub

    Public Sub strart()
        Dim ts As ThreadStart = New ThreadStart(AddressOf cashbank)
        Dim t As Thread = New Thread(ts)
        t.IsBackground = True
        t.Start()

        Dim tsv As ThreadStart = New ThreadStart(AddressOf dpv)
        Dim tt As Thread = New Thread(tsv)
        tt.IsBackground = True
        tt.Start()

        Dim tsvr As ThreadStart = New ThreadStart(AddressOf dpvc)
        Dim ttr As Thread = New Thread(tsvr)
        ttr.IsBackground = True
        ttr.Start()

        Dim tsvra As ThreadStart = New ThreadStart(AddressOf Dgpvcuu)
        Dim ttra As Thread = New Thread(tsvra)
        ttra.IsBackground = True
        ttra.Start()

        Dim abc As ThreadStart = New ThreadStart(AddressOf bki)
        Dim hb As Thread = New Thread(abc)
        hb.IsBackground = True
        hb.Start()

        Dim tsvraav As ThreadStart = New ThreadStart(AddressOf bkio)
        Dim ttraav As Thread = New Thread(tsvraav)
        ttraav.IsBackground = True
        ttraav.Start()

    End Sub
    Public Sub cashbank()
        If DGbank.Rows.Count > 0 Then
            DGbank.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("Select Account_id,Account_Name from Account_Master where Group_id=117", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                DGbank.Rows.Add()
                DGbank.Rows(DGbank.Rows.Count - 1).Cells(0).Value = "રોકડ સીલ્લક"
                DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(cramt),0)-isnull(sum(Dramt),0) from acdata where acid=149", ob.getconnection())
                DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value))
            End If
            DGbank.Rows.Add()
            DGbank.Rows(DGbank.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Account_Name")
            DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(cramt),0)-isnull(sum(Dramt),0) from acdata where acid=" & dt.Rows(i).Item("Account_id") & "", ob.getconnection())
            DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value))
        Next
        DGbank.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DGbank.ClearSelection()
        DGbank.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub
    Public Sub dpv()
        Dim nn As Date = DateTime.Now.Date
        'Dim nn As Date = "26/11/2022"
        If Dgpv.Rows.Count > 0 Then
            Dgpv.Rows.Clear()
        End If

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=244", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=243", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=8", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=7", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=6", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=5", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=310", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='KHETSADHAN'  and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.Rows.Add()
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=309", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where  department='KHETSADHAN' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales'", ob.getconnection())
        Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpv.Rows(Dgpv.Rows.Count - 1).Cells(1).Value))

        Dgpv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Dgpv.ClearSelection()
        Dgpv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Public Sub dpvc()
        Dim nn As Date = DateTime.Now.Date

        'Dim nn As Date = "26/11/2022"
        If Dgpvc.Rows.Count > 0 Then
            Dgpvc.Rows.Clear()
        End If

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=244", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=243", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=8", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=7", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=6", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=5", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=310", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='KHETSADHAN'  and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))

        Dgpvc.Rows.Add()
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=309", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where  department='KHETSADHAN' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype='Cash'", ob.getconnection())
        Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvc.Rows(Dgpvc.Rows.Count - 1).Cells(1).Value))


        Dgpvc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Dgpvc.ClearSelection()
        Dgpvc.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Public Sub Dgpvcuu()
        Dim nn As Date = DateTime.Now.Date

        'Dim nn As Date = "26/11/2022"

        If Dgpvcu.Rows.Count > 0 Then
            Dgpvcu.Rows.Clear()
        End If
        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=244", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=243", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=8", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=7", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=6", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=5", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=310", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='KHETSADHAN'  and billdate='" & ob.DateConversion(nn) & "' and ptype='Purchase' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.Rows.Add()
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=309", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where  department='KHETSADHAN' and billdate='" & ob.DateConversion(nn) & "' and ptype='Sales' and billtype<>'Cash'", ob.getconnection())
        Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Dgpvcu.Rows(Dgpvcu.Rows.Count - 1).Cells(1).Value))

        Dgpvcu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Dgpvcu.ClearSelection()
        Dgpvcu.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub
    Public Sub bki()
        Dim nn As Date = DateTime.Now.Date
        'Dim nn As Date = "26/11/2022"
        If dgr.Rows.Count > 0 Then
            dgr.Rows.Clear()
        End If

        dgr.Rows.Add()
        dgr.Rows(dgr.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=139", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Receipt'", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value))

        dgr.Rows.Add()
        dgr.Rows(dgr.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=141", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and billdate='" & ob.DateConversion(nn) & "' and ptype='Receipt'", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value))

        dgr.Rows.Add()
        dgr.Rows(dgr.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=143", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and billdate='" & ob.DateConversion(nn) & "' and ptype='Receipt'", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value))

        dgr.Rows.Add()
        dgr.Rows(dgr.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=312", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='KHETSADHAN' and billdate='" & ob.DateConversion(nn) & "' and ptype='Receipt'", ob.getconnection())
        dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(dgr.Rows(dgr.Rows.Count - 1).Cells(1).Value))

        dgr.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgr.ClearSelection()
        dgr.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Public Sub bkio()
        Dim nn As Date = DateTime.Now.Date
        'Dim nn As Date = "26/11/2022"

        If Gb.Rows.Count > 0 Then
            Gb.Rows.Clear()
        End If
        Gb.Rows.Add()
        Gb.Rows(Gb.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=139", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Bhandar'  and ptype='Sales' and Billtype='Credit'", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value))

        Gb.Rows.Add()
        Gb.Rows(Gb.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=141", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='Khatar' and ptype='Sales' and Billtype='Credit'", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value))

        Gb.Rows.Add()
        Gb.Rows(Gb.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=143", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='FATAKDA' and ptype='Sales' and Billtype='Credit'", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value))

        Gb.Rows.Add()
        Gb.Rows(Gb.Rows.Count - 1).Cells(0).Value = ob.FindOneString("select Account_name from Account_Master where Account_id=312", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(ReceiptAmt),0)-isnull(sum(PaymentAmt),0) from acmain where department='KHETSADHAN' and ptype='Sales' and Billtype='Credit'", ob.getconnection())
        Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value = Math.Abs(Val(Gb.Rows(Gb.Rows.Count - 1).Cells(1).Value))

        Gb.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Gb.ClearSelection()
        Gb.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'strart()
        cashbank()
        dpv()
        dpvc()
        Dgpvcuu()
        bki()
        bkio()
    End Sub




End Class