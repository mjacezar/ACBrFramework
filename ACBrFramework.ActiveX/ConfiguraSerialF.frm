VERSION 5.00
Begin VB.Form ConfiguraSerialFrm 
   Caption         =   "Porta Serial"
   ClientHeight    =   3525
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   5790
   BeginProperty Font 
      Name            =   "Verdana"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   3525
   ScaleWidth      =   5790
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "&Fechar"
      Height          =   375
      Left            =   4440
      TabIndex        =   16
      Top             =   3000
      Width           =   975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&OK"
      Height          =   375
      Left            =   3360
      TabIndex        =   15
      Top             =   3000
      Width           =   975
   End
   Begin VB.Frame Frame1 
      Height          =   135
      Left            =   240
      TabIndex        =   14
      Top             =   2760
      Width           =   5175
   End
   Begin VB.CheckBox chkSoftFlow 
      Caption         =   "Soft Flow"
      Height          =   255
      Left            =   2880
      TabIndex        =   13
      Top             =   2400
      Width           =   1575
   End
   Begin VB.CheckBox chkHardFlow 
      Caption         =   "Hard Flow"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   2400
      Width           =   1575
   End
   Begin VB.ComboBox cbxHandshaking 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":0000
      Left            =   2880
      List            =   "ConfiguraSerialF.frx":0010
      TabIndex        =   11
      Top             =   1920
      Width           =   2535
   End
   Begin VB.ComboBox cbxStopBits 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":0038
      Left            =   240
      List            =   "ConfiguraSerialF.frx":0045
      TabIndex        =   9
      Top             =   1920
      Width           =   2535
   End
   Begin VB.ComboBox cbxParity 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":0054
      Left            =   2880
      List            =   "ConfiguraSerialF.frx":0067
      TabIndex        =   7
      Top             =   1200
      Width           =   2535
   End
   Begin VB.ComboBox cbxDataBits 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":0089
      Left            =   240
      List            =   "ConfiguraSerialF.frx":0099
      TabIndex        =   5
      Top             =   1200
      Width           =   2535
   End
   Begin VB.ComboBox cbxBaudRate 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":00A9
      Left            =   2880
      List            =   "ConfiguraSerialF.frx":00D4
      TabIndex        =   3
      Text            =   "9600"
      Top             =   480
      Width           =   2535
   End
   Begin VB.ComboBox cbxPortaSerial 
      Height          =   315
      ItemData        =   "ConfiguraSerialF.frx":012A
      Left            =   240
      List            =   "ConfiguraSerialF.frx":0146
      TabIndex        =   1
      Text            =   "COM1"
      Top             =   480
      Width           =   2535
   End
   Begin VB.Label Label6 
      AutoSize        =   -1  'True
      Caption         =   "Handshaking (Controle de Fluxo)"
      Height          =   195
      Left            =   2880
      TabIndex        =   10
      Top             =   1680
      Width           =   2820
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   "Stop Bits (Bits de Parada)"
      Height          =   195
      Left            =   240
      TabIndex        =   8
      Top             =   1680
      Width           =   2220
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "Parity (Paridade)"
      Height          =   195
      Left            =   2880
      TabIndex        =   6
      Top             =   960
      Width           =   1455
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "Data Bits (Bits de Dados)"
      Height          =   195
      Left            =   240
      TabIndex        =   4
      Top             =   960
      Width           =   2175
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Baud rate (Bits por Segundo)"
      Height          =   195
      Left            =   2880
      TabIndex        =   2
      Top             =   240
      Width           =   2520
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Porta Serial"
      Height          =   195
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   1005
   End
End
Attribute VB_Name = "ConfiguraSerialFrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Baseado no demo do projeto ACBrX desenvolvido por Robson Braga
' www.easysoftware.net.br/acbrx.html

Private Sub cbxBaudRate_Click()
    MainFrm.ACBrECF.Device.Baud = cbxBaudRate.Text
End Sub

Private Sub cbxDataBits_Click()
    MainFrm.ACBrECF.Device.DataBits = cbxDataBits.Text
End Sub

Private Sub cbxHandshaking_Click()
    MainFrm.ACBrECF.Device.HandShake = cbxHandshaking.ListIndex
    Call VerificaFlow
End Sub

Private Sub cbxParity_Click()
    MainFrm.ACBrECF.Device.Parity = cmbParity.ListIndex
End Sub

Private Sub cbxPortaSerial_Click()
    MainFrm.ACBrECF.Device.Porta = cbxPortaSerial.Text
End Sub

Private Sub cbxStopBits_Click()
    MainFrm.ACBrECF.Device.StopBits = cbxStopBits.ListIndex
End Sub

Private Sub chkHardFlow_Click()
    MainFrm.ACBrECF.Device.HardFlow = chkHardFlow.Value
    Call VerificaFlow
End Sub

Private Sub chkSoftFlow_Click()
    MainFrm.ACBrECF.Device.SoftFlow = chkSoftFlow.Value
    Call VerificaFlow
End Sub

Private Sub Command2_Click()
    Unload Me
End Sub

Private Sub Form_Load()
    cbxBaudRate.ListIndex = ProcurarComboBox(cbxBaudRate, MainFrm.ACBrECF.Device.Baud)
    cbxDataBits.ListIndex = ProcurarComboBox(cbxBaudRate, MainFrm.ACBrECF.Device.DataBits)
    cbxParity.ListIndex = ProcurarComboBox(cbxParity, MainFrm.ACBrECF.Device.Parity)
    cbxStopBits.ListIndex = ProcurarComboBox(cbxStopBits, MainFrm.ACBrECF.Device.StopBits)
    cbxHandshaking.ListIndex = ProcurarComboBox(cbxHandshaking, MainFrm.ACBrECF.Device.HandShake)
    chkHardFlow.Value = MainFrm.ACBrECF.Device.HardFlow
    chkSoftFlow.Value = MainFrm.ACBrECF.Device.SoftFlow
End Sub

Private Sub VerificaFlow()
    cbxHandshaking.ListIndex = MainFrm.ACBrECF.Device.HandShake
    chkHardFlow.Value = MainFrm.ACBrECF.Device.HardFlow
    chkSoftFlow.Value = MainFrm.ACBrECF.Device.SoftFlow
End Sub
