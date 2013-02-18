VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form MainFrm 
   Caption         =   "Teste de Impressora Fiscal"
   ClientHeight    =   6135
   ClientLeft      =   165
   ClientTop       =   810
   ClientWidth     =   8910
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
   ScaleHeight     =   6135
   ScaleWidth      =   8910
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog Dialog 
      Left            =   120
      Top             =   5280
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton btnAtivarDesativar 
      Caption         =   "Ativar"
      Height          =   495
      Left            =   7200
      TabIndex        =   106
      Top             =   5280
      Width           =   1575
   End
   Begin TabDlg.SSTab SSTabMain 
      Height          =   5055
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   8655
      _ExtentX        =   15266
      _ExtentY        =   8916
      _Version        =   393216
      Style           =   1
      Tabs            =   7
      TabsPerRow      =   7
      TabHeight       =   520
      TabCaption(0)   =   "ECF"
      TabPicture(0)   =   "Main.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label(2)"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label(3)"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "Label(4)"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label(5)"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Label(6)"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "Label(7)"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "Label(8)"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "UpDown(2)"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "UpDown(1)"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "cbModelo"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "cbPorta"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "UpDown(0)"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "txtTimeOut"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "txtIntervalo"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "txtLinhasBuffer"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "chkTentarNovamente"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).Control(18)=   "chkBloqueiaMouseTeclado"
      Tab(0).Control(18).Enabled=   0   'False
      Tab(0).Control(19)=   "chkExibeMsgAguarde"
      Tab(0).Control(19).Enabled=   0   'False
      Tab(0).Control(20)=   "chkArredondaPorQtd"
      Tab(0).Control(20).Enabled=   0   'False
      Tab(0).Control(21)=   "chkGavetaSinalInvertido"
      Tab(0).Control(21).Enabled=   0   'False
      Tab(0).Control(22)=   "chkDescricaoGrande"
      Tab(0).Control(22).Enabled=   0   'False
      Tab(0).Control(23)=   "txtMensagemAguarde"
      Tab(0).Control(23).Enabled=   0   'False
      Tab(0).Control(24)=   "txtMensagemTrabalho"
      Tab(0).Control(24).Enabled=   0   'False
      Tab(0).Control(25)=   "txtArqLog"
      Tab(0).Control(25).Enabled=   0   'False
      Tab(0).Control(26)=   "txtOperador"
      Tab(0).Control(26).Enabled=   0   'False
      Tab(0).Control(27)=   "btnFontesECF"
      Tab(0).Control(27).Enabled=   0   'False
      Tab(0).Control(28)=   "btnIdentificaPAF"
      Tab(0).Control(28).Enabled=   0   'False
      Tab(0).Control(29)=   "btnSerial"
      Tab(0).Control(29).Enabled=   0   'False
      Tab(0).ControlCount=   30
      TabCaption(1)   =   "Cmd/Resp"
      TabPicture(1)   =   "Main.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "txtResp"
      Tab(1).Control(1)=   "txtEnviado"
      Tab(1).Control(2)=   "Label(10)"
      Tab(1).Control(3)=   "Label(9)"
      Tab(1).ControlCount=   4
      TabCaption(2)   =   "Cupom"
      TabPicture(2)   =   "Main.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "btnBobinaLimpar"
      Tab(2).Control(1)=   "btnBobinaParams"
      Tab(2).Control(2)=   "txtBobina"
      Tab(2).ControlCount=   3
      TabCaption(3)   =   "RFD"
      TabPicture(3)   =   "Main.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "SSTab2"
      Tab(3).Control(1)=   "Command6"
      Tab(3).Control(2)=   "txtDirRFD"
      Tab(3).Control(3)=   "chkRFD"
      Tab(3).Control(4)=   "Label(11)"
      Tab(3).ControlCount=   5
      TabCaption(4)   =   "Código de Barras"
      TabPicture(4)   =   "Main.frx":0070
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "Command10"
      Tab(4).Control(1)=   "Command9"
      Tab(4).Control(2)=   "chkImpTextoVertical"
      Tab(4).Control(3)=   "chkImpTextoAbaixoBarras"
      Tab(4).Control(4)=   "txtTextoBarras"
      Tab(4).Control(5)=   "txtCodBarras"
      Tab(4).Control(6)=   "txtAlturaBarra"
      Tab(4).Control(7)=   "txtLarguraBarra"
      Tab(4).Control(8)=   "Frame1"
      Tab(4).Control(9)=   "UpDown(3)"
      Tab(4).Control(10)=   "UpDown(4)"
      Tab(4).Control(11)=   "Label(24)"
      Tab(4).Control(12)=   "Label(23)"
      Tab(4).Control(13)=   "Label(22)"
      Tab(4).ControlCount=   14
      TabCaption(5)   =   "Dados RZ"
      TabPicture(5)   =   "Main.frx":008C
      Tab(5).ControlEnabled=   0   'False
      Tab(5).Control(0)=   "btnLerDadosReducaoZ"
      Tab(5).Control(1)=   "txtDadosRZ"
      Tab(5).Control(2)=   "Label(25)"
      Tab(5).ControlCount=   3
      TabCaption(6)   =   "Menu Fiscal"
      TabPicture(6)   =   "Main.frx":00A8
      Tab(6).ControlEnabled=   0   'False
      Tab(6).Control(0)=   "Frame2"
      Tab(6).Control(1)=   "sstMenuFiscalTipo"
      Tab(6).ControlCount=   2
      Begin VB.CommandButton btnLerDadosReducaoZ 
         Caption         =   "Ler Dados RZ"
         Height          =   375
         Left            =   -74880
         TabIndex        =   107
         Top             =   4560
         Width           =   1695
      End
      Begin TabDlg.SSTab sstMenuFiscalTipo 
         Height          =   1095
         Left            =   -74880
         TabIndex        =   97
         Top             =   3840
         Width           =   8415
         _ExtentX        =   14843
         _ExtentY        =   1931
         _Version        =   393216
         Style           =   1
         Tabs            =   2
         Tab             =   1
         TabsPerRow      =   2
         TabHeight       =   520
         TabCaption(0)   =   "Emissão por intervalo de data"
         TabPicture(0)   =   "Main.frx":00C4
         Tab(0).ControlEnabled=   0   'False
         Tab(0).Control(0)=   "Label(26)"
         Tab(0).Control(1)=   "Label(27)"
         Tab(0).Control(2)=   "dtpData(1)"
         Tab(0).Control(3)=   "dtpData(0)"
         Tab(0).ControlCount=   4
         TabCaption(1)   =   "Emissão por intervalo de COO"
         TabPicture(1)   =   "Main.frx":00E0
         Tab(1).ControlEnabled=   -1  'True
         Tab(1).Control(0)=   "Label(28)"
         Tab(1).Control(0).Enabled=   0   'False
         Tab(1).Control(1)=   "Label(29)"
         Tab(1).Control(1).Enabled=   0   'False
         Tab(1).Control(2)=   "txtCOO(0)"
         Tab(1).Control(2).Enabled=   0   'False
         Tab(1).Control(3)=   "txtCOO(1)"
         Tab(1).Control(3).Enabled=   0   'False
         Tab(1).ControlCount=   4
         Begin VB.TextBox txtCOO 
            Height          =   285
            Index           =   1
            Left            =   3240
            TabIndex        =   105
            Top             =   600
            Width           =   1935
         End
         Begin VB.TextBox txtCOO 
            Height          =   285
            Index           =   0
            Left            =   600
            TabIndex        =   104
            Top             =   600
            Width           =   1935
         End
         Begin MSComCtl2.DTPicker dtpData 
            Height          =   375
            Index           =   0
            Left            =   -74400
            TabIndex        =   98
            Top             =   480
            Width           =   1935
            _ExtentX        =   3413
            _ExtentY        =   661
            _Version        =   393216
            Format          =   183369729
            CurrentDate     =   40758
         End
         Begin MSComCtl2.DTPicker dtpData 
            Height          =   375
            Index           =   1
            Left            =   -71760
            TabIndex        =   99
            Top             =   480
            Width           =   1935
            _ExtentX        =   3413
            _ExtentY        =   661
            _Version        =   393216
            Format          =   183369729
            CurrentDate     =   40758
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Até"
            Height          =   195
            Index           =   29
            Left            =   2760
            TabIndex        =   103
            Top             =   600
            Width           =   285
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "De"
            Height          =   195
            Index           =   28
            Left            =   240
            TabIndex        =   102
            Top             =   600
            Width           =   240
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Até"
            Height          =   195
            Index           =   27
            Left            =   -72240
            TabIndex        =   101
            Top             =   600
            Width           =   285
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "De"
            Height          =   195
            Index           =   26
            Left            =   -74760
            TabIndex        =   100
            Top             =   600
            Width           =   240
         End
      End
      Begin VB.Frame Frame2 
         Caption         =   "Opções do Menu Fiscal"
         Height          =   3255
         Left            =   -74880
         TabIndex        =   94
         Top             =   480
         Width           =   8415
         Begin VB.CommandButton btnMenuFiscalRelIdentPAFECF 
            Caption         =   "Identificação PAF-ECF"
            Height          =   375
            Left            =   5400
            TabIndex        =   115
            Top             =   1560
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalLMFS 
            Caption         =   "LMFS"
            Height          =   375
            Left            =   360
            TabIndex        =   114
            Top             =   1560
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalRelDAVEmitidos 
            Caption         =   "DAV Emitidos"
            Height          =   375
            Left            =   5400
            TabIndex        =   113
            Top             =   960
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalMFDArq 
            Caption         =   "Arquivo MFD"
            Height          =   375
            Left            =   2880
            TabIndex        =   112
            Top             =   960
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalLMFC 
            Caption         =   "LMFC"
            Height          =   375
            Left            =   360
            TabIndex        =   111
            Top             =   960
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalRelMeiosPagto 
            Caption         =   "Meios de Pagto."
            Height          =   375
            Left            =   5400
            TabIndex        =   110
            Top             =   360
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalMFDEspelho 
            Caption         =   "Espelho MFD"
            Height          =   375
            Left            =   2880
            TabIndex        =   109
            Top             =   360
            Width           =   2055
         End
         Begin VB.CommandButton btnMenuFiscalLX 
            Caption         =   "LX"
            Height          =   375
            Left            =   360
            TabIndex        =   108
            Top             =   360
            Width           =   2055
         End
         Begin VB.CheckBox chkMenuFiscalCotepe1704 
            Caption         =   "Gerar arquivo no formato do ato Cotepe 17/04 (Somente para os menus: LMFC, Arq.MFD)"
            Height          =   255
            Left            =   120
            TabIndex        =   96
            Top             =   2880
            Width           =   8175
         End
         Begin VB.CheckBox chkMenuFiscalGerarArquivo 
            Caption         =   "Efetuar a Geração do arquivo"
            Height          =   255
            Left            =   120
            TabIndex        =   95
            Top             =   2520
            Width           =   7935
         End
      End
      Begin VB.TextBox txtDadosRZ 
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3735
         Left            =   -74880
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   92
         Top             =   720
         Width           =   8415
      End
      Begin VB.CommandButton Command10 
         Caption         =   "Fechar Cupom"
         Height          =   375
         Left            =   -70560
         TabIndex        =   91
         Top             =   3960
         Width           =   1575
      End
      Begin VB.CommandButton Command9 
         Caption         =   "Enviar Linha Gerencial"
         Height          =   375
         Left            =   -68880
         TabIndex        =   90
         Top             =   3960
         Width           =   2175
      End
      Begin VB.CheckBox chkImpTextoVertical 
         Caption         =   "Imprime Código na Vertical"
         Height          =   255
         Left            =   -74880
         TabIndex        =   89
         Top             =   3720
         Width           =   2895
      End
      Begin VB.CheckBox chkImpTextoAbaixoBarras 
         Caption         =   "Imprime texto abaixo das barras"
         Height          =   255
         Left            =   -74880
         TabIndex        =   88
         Top             =   4080
         Value           =   1  'Checked
         Width           =   3375
      End
      Begin VB.TextBox txtTextoBarras 
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1935
         Left            =   -71400
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   87
         Text            =   "Main.frx":00FC
         Top             =   1680
         Width           =   4695
      End
      Begin VB.TextBox txtCodBarras 
         Height          =   285
         Left            =   -71400
         TabIndex        =   85
         Top             =   1320
         Width           =   4695
      End
      Begin VB.TextBox txtAlturaBarra 
         Height          =   285
         Left            =   -67440
         TabIndex        =   82
         Text            =   "80"
         Top             =   600
         Width           =   480
      End
      Begin VB.TextBox txtLarguraBarra 
         Height          =   285
         Left            =   -69840
         TabIndex        =   79
         Text            =   "2"
         Top             =   600
         Width           =   480
      End
      Begin VB.Frame Frame1 
         Caption         =   "Tipo"
         Height          =   3135
         Left            =   -74880
         TabIndex        =   67
         Top             =   480
         Width           =   3255
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "CODE11"
            Height          =   255
            Index           =   10
            Left            =   120
            TabIndex        =   78
            Top             =   2760
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "MSI"
            Height          =   255
            Index           =   9
            Left            =   120
            TabIndex        =   77
            Top             =   2520
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "CODABAR"
            Height          =   255
            Index           =   8
            Left            =   120
            TabIndex        =   76
            Top             =   2280
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "UPC-A"
            Height          =   255
            Index           =   7
            Left            =   120
            TabIndex        =   75
            Top             =   2040
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "CODE93"
            Height          =   255
            Index           =   6
            Left            =   120
            TabIndex        =   74
            Top             =   1800
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "CODE39"
            Height          =   255
            Index           =   5
            Left            =   120
            TabIndex        =   73
            Top             =   1560
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "CODE128"
            Height          =   255
            Index           =   4
            Left            =   120
            TabIndex        =   72
            Top             =   1320
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "INTERLEAVED 2 OF 5"
            Height          =   255
            Index           =   3
            Left            =   120
            TabIndex        =   71
            Top             =   1080
            Width           =   2175
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "STANDARD 2 OF 5"
            Height          =   255
            Index           =   2
            Left            =   120
            TabIndex        =   70
            Top             =   840
            Width           =   2055
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "EAN-8"
            Height          =   255
            Index           =   1
            Left            =   120
            TabIndex        =   69
            Top             =   600
            Width           =   2055
         End
         Begin VB.OptionButton obTipoCodBarras 
            Caption         =   "EAN-13"
            Height          =   255
            Index           =   0
            Left            =   120
            TabIndex        =   68
            Top             =   360
            Value           =   -1  'True
            Width           =   2055
         End
      End
      Begin TabDlg.SSTab SSTab2 
         Height          =   3615
         Left            =   -74880
         TabIndex        =   42
         Top             =   1320
         Width           =   8415
         _ExtentX        =   14843
         _ExtentY        =   6376
         _Version        =   393216
         Style           =   1
         Tabs            =   2
         TabsPerRow      =   2
         TabHeight       =   520
         TabCaption(0)   =   "Dados da Software House"
         TabPicture(0)   =   "Main.frx":013D
         Tab(0).ControlEnabled=   -1  'True
         Tab(0).Control(0)=   "Label(12)"
         Tab(0).Control(0).Enabled=   0   'False
         Tab(0).Control(1)=   "Label(13)"
         Tab(0).Control(1).Enabled=   0   'False
         Tab(0).Control(2)=   "Label(14)"
         Tab(0).Control(2).Enabled=   0   'False
         Tab(0).Control(3)=   "Label(15)"
         Tab(0).Control(3).Enabled=   0   'False
         Tab(0).Control(4)=   "Label(16)"
         Tab(0).Control(4).Enabled=   0   'False
         Tab(0).Control(5)=   "Label(17)"
         Tab(0).Control(5).Enabled=   0   'False
         Tab(0).Control(6)=   "Label(18)"
         Tab(0).Control(6).Enabled=   0   'False
         Tab(0).Control(7)=   "Label(19)"
         Tab(0).Control(7).Enabled=   0   'False
         Tab(0).Control(8)=   "Label(20)"
         Tab(0).Control(8).Enabled=   0   'False
         Tab(0).Control(9)=   "Label(21)"
         Tab(0).Control(9).Enabled=   0   'False
         Tab(0).Control(10)=   "txtDadosSW(0)"
         Tab(0).Control(10).Enabled=   0   'False
         Tab(0).Control(11)=   "txtDadosSW(1)"
         Tab(0).Control(11).Enabled=   0   'False
         Tab(0).Control(12)=   "txtDadosSW(2)"
         Tab(0).Control(12).Enabled=   0   'False
         Tab(0).Control(13)=   "txtDadosSW(3)"
         Tab(0).Control(13).Enabled=   0   'False
         Tab(0).Control(14)=   "txtDadosSW(4)"
         Tab(0).Control(14).Enabled=   0   'False
         Tab(0).Control(15)=   "txtDadosSW(5)"
         Tab(0).Control(15).Enabled=   0   'False
         Tab(0).Control(16)=   "txtDadosSW(6)"
         Tab(0).Control(16).Enabled=   0   'False
         Tab(0).Control(17)=   "txtDadosSW(7)"
         Tab(0).Control(17).Enabled=   0   'False
         Tab(0).Control(18)=   "txtDadosSW(8)"
         Tab(0).Control(18).Enabled=   0   'False
         Tab(0).Control(19)=   "txtDadosSW(9)"
         Tab(0).Control(19).Enabled=   0   'False
         Tab(0).ControlCount=   20
         TabCaption(1)   =   "ACBrRFD.ini"
         TabPicture(1)   =   "Main.frx":0159
         Tab(1).ControlEnabled=   0   'False
         Tab(1).Control(0)=   "txtRFDParam"
         Tab(1).Control(1)=   "Command7"
         Tab(1).Control(2)=   "Command8"
         Tab(1).ControlCount=   3
         Begin VB.CommandButton Command8 
            Caption         =   "Salvar"
            Height          =   375
            Left            =   -73680
            TabIndex        =   66
            Top             =   3000
            Width           =   1095
         End
         Begin VB.CommandButton Command7 
            Caption         =   "Ler"
            Height          =   375
            Left            =   -74880
            TabIndex        =   65
            Top             =   3000
            Width           =   1095
         End
         Begin VB.TextBox txtRFDParam 
            BeginProperty Font 
               Name            =   "Lucida Console"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   2415
            Left            =   -74880
            MultiLine       =   -1  'True
            ScrollBars      =   2  'Vertical
            TabIndex        =   64
            Top             =   480
            Width           =   8175
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   9
            Left            =   120
            TabIndex        =   61
            Top             =   3120
            Width           =   6375
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   8
            Left            =   120
            TabIndex        =   59
            Top             =   2520
            Width           =   6375
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   7
            Left            =   4560
            TabIndex        =   57
            Top             =   1920
            Width           =   1935
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   6
            Left            =   2880
            TabIndex        =   55
            Top             =   1920
            Width           =   1575
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   5
            Left            =   120
            TabIndex        =   53
            Top             =   1920
            Width           =   2655
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   4
            Left            =   4560
            TabIndex        =   51
            Top             =   1320
            Width           =   1935
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   3
            Left            =   2280
            TabIndex        =   49
            Top             =   1320
            Width           =   2175
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   2
            Left            =   120
            TabIndex        =   47
            Top             =   1320
            Width           =   2055
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   1
            Left            =   4560
            TabIndex        =   45
            Top             =   720
            Width           =   1935
         End
         Begin VB.TextBox txtDadosSW 
            Height          =   285
            Index           =   0
            Left            =   120
            TabIndex        =   43
            Top             =   720
            Width           =   4335
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Linha 2"
            Height          =   195
            Index           =   21
            Left            =   120
            TabIndex        =   62
            Top             =   2880
            Width           =   615
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Linha 1"
            Height          =   195
            Index           =   20
            Left            =   120
            TabIndex        =   60
            Top             =   2280
            Width           =   615
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Versão"
            Height          =   195
            Index           =   19
            Left            =   4560
            TabIndex        =   58
            Top             =   1680
            Width           =   600
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Número"
            Height          =   195
            Index           =   18
            Left            =   2880
            TabIndex        =   56
            Top             =   1680
            Width           =   675
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Aplicativo"
            Height          =   195
            Index           =   17
            Left            =   120
            TabIndex        =   54
            Top             =   1680
            Width           =   825
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Incr. Municipal"
            Height          =   195
            Index           =   16
            Left            =   4560
            TabIndex        =   52
            Top             =   1080
            Width           =   1245
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Incr. Estadual"
            Height          =   195
            Index           =   15
            Left            =   2280
            TabIndex        =   50
            Top             =   1080
            Width           =   1185
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "CNPJ"
            Height          =   195
            Index           =   14
            Left            =   120
            TabIndex        =   48
            Top             =   1080
            Width           =   435
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "COO"
            Height          =   195
            Index           =   13
            Left            =   4560
            TabIndex        =   46
            Top             =   480
            Width           =   405
         End
         Begin VB.Label Label 
            AutoSize        =   -1  'True
            Caption         =   "Razão Social"
            Height          =   195
            Index           =   12
            Left            =   120
            TabIndex        =   44
            Top             =   480
            Width           =   1095
         End
      End
      Begin VB.CommandButton Command6 
         Caption         =   "..."
         Height          =   255
         Left            =   -67080
         TabIndex        =   41
         Top             =   840
         Width           =   375
      End
      Begin VB.TextBox txtDirRFD 
         Height          =   285
         Left            =   -73440
         TabIndex        =   40
         Top             =   840
         Width           =   6255
      End
      Begin VB.CheckBox chkRFD 
         Caption         =   "Gerar RFD"
         Height          =   255
         Left            =   -74760
         TabIndex        =   39
         Top             =   840
         Width           =   1335
      End
      Begin VB.TextBox txtBobina 
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3975
         Left            =   -74880
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   38
         Top             =   960
         Width           =   8415
      End
      Begin VB.CommandButton btnBobinaParams 
         Caption         =   "Parâmetros"
         Height          =   375
         Left            =   -74880
         TabIndex        =   37
         Top             =   480
         Width           =   1455
      End
      Begin VB.CommandButton btnBobinaLimpar 
         Caption         =   "Limpar"
         Height          =   375
         Left            =   -73320
         TabIndex        =   36
         Top             =   480
         Width           =   1455
      End
      Begin VB.TextBox txtResp 
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3015
         Left            =   -74880
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   34
         Top             =   1920
         Width           =   8415
      End
      Begin VB.TextBox txtEnviado 
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   -74880
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   32
         Top             =   720
         Width           =   8415
      End
      Begin VB.CommandButton btnSerial 
         Caption         =   "Serial"
         Height          =   375
         Left            =   6960
         TabIndex        =   31
         Top             =   4560
         Width           =   1455
      End
      Begin VB.CommandButton btnIdentificaPAF 
         Caption         =   "Identifica PAF-ECF"
         Height          =   375
         Left            =   5040
         TabIndex        =   30
         Top             =   4560
         Width           =   1815
      End
      Begin VB.CommandButton btnFontesECF 
         Caption         =   "Fontes do ECF"
         Height          =   375
         Left            =   3120
         TabIndex        =   29
         Top             =   4560
         Width           =   1815
      End
      Begin VB.TextBox txtOperador 
         Height          =   285
         Left            =   1200
         TabIndex        =   28
         Top             =   4560
         Width           =   1695
      End
      Begin VB.TextBox txtArqLog 
         Height          =   285
         Left            =   1200
         TabIndex        =   26
         Text            =   "c:\temp\LogACBrX.txt"
         Top             =   4200
         Width           =   7215
      End
      Begin VB.TextBox txtMensagemTrabalho 
         Height          =   285
         Left            =   5640
         TabIndex        =   24
         Text            =   "Impressora está trabalhando"
         Top             =   3120
         Width           =   2775
      End
      Begin VB.TextBox txtMensagemAguarde 
         Height          =   855
         Left            =   240
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   22
         Top             =   3120
         Width           =   5175
      End
      Begin VB.CheckBox chkDescricaoGrande 
         Caption         =   "Descrição Grande"
         Height          =   255
         Left            =   3600
         TabIndex        =   20
         Top             =   2280
         Value           =   1  'Checked
         Width           =   1935
      End
      Begin VB.CheckBox chkGavetaSinalInvertido 
         Caption         =   "Gaveta Sinal Invertido"
         Height          =   255
         Left            =   3600
         TabIndex        =   19
         Top             =   1920
         Width           =   2415
      End
      Begin VB.CheckBox chkArredondaPorQtd 
         Caption         =   "Arredondamento por Quantidade"
         Height          =   255
         Left            =   3600
         TabIndex        =   18
         Top             =   1560
         Width           =   3255
      End
      Begin VB.CheckBox chkExibeMsgAguarde 
         Caption         =   "Exibe Msg. Aguarde..."
         Height          =   255
         Left            =   240
         TabIndex        =   17
         Top             =   2280
         Value           =   1  'Checked
         Width           =   2415
      End
      Begin VB.CheckBox chkBloqueiaMouseTeclado 
         Caption         =   "Bloqueia Mouse Teclado"
         Height          =   255
         Left            =   240
         TabIndex        =   16
         Top             =   1920
         Value           =   1  'Checked
         Width           =   2415
      End
      Begin VB.CheckBox chkTentarNovamente 
         Caption         =   "Tentar Novamente"
         Height          =   255
         Left            =   240
         TabIndex        =   15
         Top             =   1560
         Width           =   1935
      End
      Begin VB.TextBox txtLinhasBuffer 
         Height          =   285
         Left            =   6720
         TabIndex        =   12
         Text            =   "3"
         Top             =   840
         Width           =   480
      End
      Begin VB.TextBox txtIntervalo 
         Height          =   285
         Left            =   5640
         TabIndex        =   9
         Text            =   "100"
         Top             =   840
         Width           =   480
      End
      Begin VB.TextBox txtTimeOut 
         Height          =   285
         Left            =   4560
         TabIndex        =   8
         Text            =   "3"
         Top             =   840
         Width           =   480
      End
      Begin MSComCtl2.UpDown UpDown 
         Height          =   285
         Index           =   0
         Left            =   5040
         TabIndex        =   7
         TabStop         =   0   'False
         Top             =   840
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "txtTimeOut"
         BuddyDispid     =   196662
         OrigLeft        =   5040
         OrigTop         =   840
         OrigRight       =   5295
         OrigBottom      =   1095
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   0
         Enabled         =   -1  'True
      End
      Begin VB.ComboBox cbPorta 
         Height          =   315
         ItemData        =   "Main.frx":0175
         Left            =   2400
         List            =   "Main.frx":01A9
         TabIndex        =   5
         Top             =   840
         Width           =   1935
      End
      Begin VB.ComboBox cbModelo 
         Height          =   315
         ItemData        =   "Main.frx":0240
         Left            =   240
         List            =   "Main.frx":0274
         TabIndex        =   3
         Top             =   840
         Width           =   1935
      End
      Begin MSComCtl2.UpDown UpDown 
         Height          =   285
         Index           =   1
         Left            =   6120
         TabIndex        =   10
         TabStop         =   0   'False
         Top             =   840
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "txtTimeOut"
         BuddyDispid     =   196662
         OrigLeft        =   5040
         OrigTop         =   840
         OrigRight       =   5295
         OrigBottom      =   1095
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   0
         Enabled         =   -1  'True
      End
      Begin MSComCtl2.UpDown UpDown 
         Height          =   285
         Index           =   2
         Left            =   7200
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   840
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "txtTimeOut"
         BuddyDispid     =   196662
         OrigLeft        =   5040
         OrigTop         =   840
         OrigRight       =   5295
         OrigBottom      =   1095
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   0
         Enabled         =   -1  'True
      End
      Begin MSComCtl2.UpDown UpDown 
         Height          =   285
         Index           =   3
         Left            =   -69360
         TabIndex        =   80
         TabStop         =   0   'False
         Top             =   600
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "txtTimeOut"
         BuddyDispid     =   196662
         OrigLeft        =   5040
         OrigTop         =   840
         OrigRight       =   5295
         OrigBottom      =   1095
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   0
         Enabled         =   -1  'True
      End
      Begin MSComCtl2.UpDown UpDown 
         Height          =   285
         Index           =   4
         Left            =   -66960
         TabIndex        =   83
         TabStop         =   0   'False
         Top             =   600
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "txtTimeOut"
         BuddyDispid     =   196662
         OrigLeft        =   5040
         OrigTop         =   840
         OrigRight       =   5295
         OrigBottom      =   1095
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   0
         Enabled         =   -1  'True
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Resposta"
         Height          =   195
         Index           =   25
         Left            =   -74880
         TabIndex        =   93
         Top             =   480
         Width           =   780
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "String"
         Height          =   195
         Index           =   24
         Left            =   -71400
         TabIndex        =   86
         Top             =   1080
         Width           =   510
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Altura da Barra"
         Height          =   195
         Index           =   23
         Left            =   -68865
         TabIndex        =   84
         Top             =   600
         Width           =   1320
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Largura da Barra"
         Height          =   195
         Index           =   22
         Left            =   -71400
         TabIndex        =   81
         Top             =   600
         Width           =   1470
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Diretório Arquivos RFD"
         Height          =   195
         Index           =   11
         Left            =   -73440
         TabIndex        =   63
         Top             =   600
         Width           =   1965
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Resposta"
         Height          =   195
         Index           =   10
         Left            =   -74880
         TabIndex        =   35
         Top             =   1680
         Width           =   780
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Comando Enviado"
         Height          =   195
         Index           =   9
         Left            =   -74880
         TabIndex        =   33
         Top             =   480
         Width           =   1560
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Operador"
         Height          =   195
         Index           =   8
         Left            =   250
         TabIndex        =   27
         Top             =   4560
         Width           =   810
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Arq. Log"
         Height          =   195
         Index           =   7
         Left            =   360
         TabIndex        =   25
         Top             =   4200
         Width           =   720
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Mensagem Trabalhando"
         Height          =   195
         Index           =   6
         Left            =   5640
         TabIndex        =   23
         Top             =   2880
         Width           =   2040
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Mensagem Aguarde..."
         Height          =   195
         Index           =   5
         Left            =   240
         TabIndex        =   21
         Top             =   2880
         Width           =   1875
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Linhas Buffer"
         Height          =   195
         Index           =   4
         Left            =   6720
         TabIndex        =   14
         Top             =   600
         Width           =   1125
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Intervalo"
         Height          =   195
         Index           =   3
         Left            =   5640
         TabIndex        =   11
         Top             =   600
         Width           =   780
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "TimeOut"
         Height          =   195
         Index           =   2
         Left            =   4560
         TabIndex        =   6
         Top             =   600
         Width           =   720
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Porta"
         Height          =   195
         Index           =   1
         Left            =   2400
         TabIndex        =   4
         Top             =   600
         Width           =   450
      End
      Begin VB.Label Label 
         AutoSize        =   -1  'True
         Caption         =   "Modelo"
         Height          =   195
         Index           =   0
         Left            =   240
         TabIndex        =   2
         Top             =   600
         Width           =   600
      End
   End
   Begin MSComctlLib.StatusBar StatusBar 
      Align           =   2  'Align Bottom
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   5880
      Width           =   8910
      _ExtentX        =   15716
      _ExtentY        =   450
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   2
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   12621
         EndProperty
      EndProperty
   End
   Begin VB.Menu mnPrincipal 
      Caption         =   "&Principal"
      Begin VB.Menu mniAtivar 
         Caption         =   "Ativar"
      End
      Begin VB.Menu mniDesativar 
         Caption         =   "Desativar"
      End
      Begin VB.Menu mniTestar 
         Caption         =   "Testar"
      End
      Begin VB.Menu mniSeparator1 
         Caption         =   "-"
      End
      Begin VB.Menu mniSobreACBr 
         Caption         =   "Sobre o ACBrFramework"
      End
      Begin VB.Menu mniSeparator2 
         Caption         =   "-"
      End
      Begin VB.Menu mniSair 
         Caption         =   "Sair"
      End
   End
   Begin VB.Menu mnVariaveis 
      Caption         =   "&Variaveis"
      Begin VB.Menu mniEquipamentos 
         Caption         =   "Equipamentos"
         Begin VB.Menu mniEstado 
            Caption         =   "Estado"
         End
         Begin VB.Menu mniDataHora 
            Caption         =   "Data Hora"
         End
         Begin VB.Menu mniSeparator7 
            Caption         =   "-"
         End
         Begin VB.Menu mniModeloStr 
            Caption         =   "ModeloStr"
         End
         Begin VB.Menu mniNumECF 
            Caption         =   "Num ECF"
         End
         Begin VB.Menu mniNumLoja 
            Caption         =   "Num Loja"
         End
         Begin VB.Menu mniUsuarioAtual 
            Caption         =   "Usuario Atual"
         End
         Begin VB.Menu mniNumSerieMFD 
            Caption         =   "Num Série MFD"
         End
         Begin VB.Menu mniNumSerie 
            Caption         =   "Num Série"
         End
         Begin VB.Menu mniNumVersao 
            Caption         =   "Num Versão"
         End
         Begin VB.Menu mniCNPJ 
            Caption         =   "CNPJ"
         End
         Begin VB.Menu mniIE 
            Caption         =   "IE"
         End
         Begin VB.Menu mniModelo 
            Caption         =   "Modelo"
         End
      End
      Begin VB.Menu mniSeparator3 
         Caption         =   "-"
      End
      Begin VB.Menu mniFlags 
         Caption         =   "Flags"
         Begin VB.Menu mniPoucoPapel 
            Caption         =   "Pouco Papel ?"
         End
         Begin VB.Menu mniHorarioVerao 
            Caption         =   "Horario Verão ?"
         End
         Begin VB.Menu mniArredonda 
            Caption         =   "Arredonda ?"
         End
         Begin VB.Menu mniEhMFD 
            Caption         =   "É MFD ?"
         End
         Begin VB.Menu mniEhTermica 
            Caption         =   "É Termica ?"
         End
         Begin VB.Menu mniParametroDescontoISSQN 
            Caption         =   "Parametro Desconto ISSQN ?"
         End
      End
      Begin VB.Menu mniMapaResumo 
         Caption         =   "Mapa Resumo"
         Begin VB.Menu mniDataMovimento 
            Caption         =   "Data Movimento"
         End
         Begin VB.Menu mniDadosReducaoZ60M 
            Caption         =   "Dados Reducao Z (60M)"
         End
         Begin VB.Menu mniDadosUltimaReducaoZ 
            Caption         =   "Dados Ultima Redução Z"
         End
         Begin VB.Menu mniSeparator8 
            Caption         =   "-"
         End
         Begin VB.Menu mniNumCOO 
            Caption         =   "NumCOO"
         End
         Begin VB.Menu mniNumCRZ 
            Caption         =   "Num CRZ"
         End
         Begin VB.Menu mniNumCRO 
            Caption         =   "Num CRO"
         End
         Begin VB.Menu mniNumCCF 
            Caption         =   "Num CCF"
         End
         Begin VB.Menu mniNumCOOInicial 
            Caption         =   "Num COO Inicial"
         End
         Begin VB.Menu mniNumGNF 
            Caption         =   "Num GNF"
         End
         Begin VB.Menu mniSeparator9 
            Caption         =   "-"
         End
         Begin VB.Menu mniVendaBruta 
            Caption         =   "Venda Bruta"
         End
         Begin VB.Menu mniGrandeTotal 
            Caption         =   "Grande Total"
         End
         Begin VB.Menu mniSeparator10 
            Caption         =   "-"
         End
         Begin VB.Menu mniTotalCancelamentos 
            Caption         =   "Total Cancelamentos"
         End
         Begin VB.Menu mniTotalDescontos 
            Caption         =   "Total Descontos"
         End
         Begin VB.Menu mniTotalAcrescimos 
            Caption         =   "Total Acrescimos"
         End
         Begin VB.Menu mniTotalNaoFiscal 
            Caption         =   "Total Não Fiscal"
         End
         Begin VB.Menu mniSeparator11 
            Caption         =   "-"
         End
         Begin VB.Menu mniTotalSubstituicaoTributaria 
            Caption         =   "Total Substituicao Tributaria"
         End
         Begin VB.Menu mniTotalNaoTributado 
            Caption         =   "Total Não Tributado"
         End
         Begin VB.Menu mniTotalIsencao 
            Caption         =   "Total Isenção"
         End
         Begin VB.Menu mniSeparator23 
            Caption         =   "-"
         End
         Begin VB.Menu mniTotalSubstituicaoTributariaISSQN 
            Caption         =   "Total Substituição Tributaria ISSQN"
         End
         Begin VB.Menu mniTotalNaoTributadoISSQN 
            Caption         =   "Total Não Tributado ISSQN"
         End
         Begin VB.Menu mniTotalIsencaoISSQN 
            Caption         =   "Total Isenção ISSQN"
         End
      End
      Begin VB.Menu mniSeparator5 
         Caption         =   "-"
      End
      Begin VB.Menu mniAliquotas 
         Caption         =   "Aliquotas"
         Begin VB.Menu mniCarregaAliquotasICMS 
            Caption         =   "Carrega Aliquotas (ICMS)"
         End
         Begin VB.Menu mniLerTotaisAliquotas 
            Caption         =   "Ler Totais Aliquotas"
         End
         Begin VB.Menu mniSeparator12 
            Caption         =   "-"
         End
         Begin VB.Menu mniAchaAliquotaIndice 
            Caption         =   "Acha Aliquota por Indice"
         End
         Begin VB.Menu mniAchaAliquotaValor 
            Caption         =   "Acha Aliquota por Valor"
         End
      End
      Begin VB.Menu mniFormasPagamento 
         Caption         =   "Formas de Pagamento"
         Begin VB.Menu mniCarregaFormasPagamento 
            Caption         =   "Carrega Formas Pagamento"
         End
         Begin VB.Menu mniLerTotaisFormaPagamento 
            Caption         =   "Ler Totais Forma de Pagamento"
         End
         Begin VB.Menu mniSeparator13 
            Caption         =   "-"
         End
         Begin VB.Menu mniAcharFormasPagamentoIndice 
            Caption         =   "Achar Formas Pagamento por Indice"
         End
         Begin VB.Menu mniAcharFormasPagametoDescricao 
            Caption         =   "Achar Formas Pagameto por Descrição"
         End
         Begin VB.Menu mniSeparator14 
            Caption         =   "-"
         End
         Begin VB.Menu mniLerTroco 
            Caption         =   "Ler Troco"
         End
      End
      Begin VB.Menu mniComprovantesNaoFiscais 
         Caption         =   "Comprovantes Não Fiscais"
         Begin VB.Menu mniCarregaComprovantesNaoFiscais 
            Caption         =   "Carrega Comprovantes Não Fiscais"
         End
         Begin VB.Menu mniLerTotaisComprovanteNaoFiscal 
            Caption         =   "Ler Totais Comprovante Não Fiscal"
         End
         Begin VB.Menu mniSeparator15 
            Caption         =   "-"
         End
         Begin VB.Menu mniAchaCNFIndice 
            Caption         =   "Acha CNF por Indice"
         End
         Begin VB.Menu mniAchaCNFDescricao 
            Caption         =   "Acha CNF por Descrição"
         End
      End
      Begin VB.Menu mniRelatoriosGerenciais 
         Caption         =   "Relatórios Gerenciais"
         Begin VB.Menu mniCarregaRelatoriosGerenciais 
            Caption         =   "Carrega Relatórios Gerenciais"
         End
         Begin VB.Menu mniSeparator16 
            Caption         =   "-"
         End
         Begin VB.Menu mniAchaRGIndice 
            Caption         =   "Acha RG por Indice"
         End
         Begin VB.Menu mniAchaRGDescricao 
            Caption         =   "Acha RG por Descrição"
         End
      End
      Begin VB.Menu mniCarregaUnidadesMedida 
         Caption         =   "Carrega Unidades de Medida"
      End
      Begin VB.Menu mniSeparator6 
         Caption         =   "-"
      End
      Begin VB.Menu mniLerTodasVariaveis 
         Caption         =   "Ler Todas as Variáveis"
      End
   End
   Begin VB.Menu mnRelatorios 
      Caption         =   "&Relatórios"
      Begin VB.Menu mniLeituraX 
         Caption         =   "Leitura X"
      End
      Begin VB.Menu mniReducaoZ 
         Caption         =   "Redução Z"
      End
      Begin VB.Menu mniSeparator17 
         Caption         =   "-"
      End
      Begin VB.Menu mniCupomVinculado 
         Caption         =   "Cupom Vinculado"
         Begin VB.Menu mniCupomVinculadoCompleto 
            Caption         =   "Cupom Vinculado Completo"
         End
         Begin VB.Menu mniSeparator24 
            Caption         =   "-"
         End
         Begin VB.Menu mniAbreCupomVinculado 
            Caption         =   "Abre Cupom Vinculado"
         End
         Begin VB.Menu mniImprimeLinhaCupomVinculado 
            Caption         =   "Imprime Linha Cupom Vinculado"
         End
         Begin VB.Menu mniSeparator25 
            Caption         =   "-"
         End
         Begin VB.Menu mniTesteVinculado 
            Caption         =   "Teste de Vinculado"
         End
      End
      Begin VB.Menu mniRelatorioGerencial 
         Caption         =   "Relatorio Gerencial"
         Begin VB.Menu mniRelatorioGerencialCompleto 
            Caption         =   "Relatorio Gerencial Completo"
         End
         Begin VB.Menu mniSeparator27 
            Caption         =   "-"
         End
         Begin VB.Menu mniAbreRelatorioGerencial 
            Caption         =   "Abre Relatorio Gerencial"
         End
         Begin VB.Menu mniImprimeLinhaRelatorio 
            Caption         =   "Imprime Linha Relatorio"
         End
      End
      Begin VB.Menu mniPularLinhas 
         Caption         =   "Pular Linhas"
      End
      Begin VB.Menu mniCortaPapel 
         Caption         =   "Corta Papel"
      End
      Begin VB.Menu mniSeparator18 
         Caption         =   "-"
      End
      Begin VB.Menu mniFechaRelatorioVinculado 
         Caption         =   "Fecha Relatório / Vinculado"
      End
      Begin VB.Menu mniSeparator19 
         Caption         =   "-"
      End
      Begin VB.Menu mniLeituraMemoriaFiscal 
         Caption         =   "Leitura de Memoria Fiscal"
         Begin VB.Menu mniCapturaNReduçaoZ 
            Caption         =   "Captura por Nº ReduçaoZ"
         End
         Begin VB.Menu mniCapturaPeriodo 
            Caption         =   "Captura por Periodo"
         End
         Begin VB.Menu mniImprimeNReduçaoZ 
            Caption         =   "Imprime por Nº ReduçaoZ"
         End
         Begin VB.Menu mniImprimePeriodo 
            Caption         =   "Imprime por Periodo"
         End
      End
      Begin VB.Menu mniSeparator20 
         Caption         =   "-"
      End
      Begin VB.Menu mniLeituraMFDSerial 
         Caption         =   "Leitura MFD Serial"
         Begin VB.Menu mniPorIntervaloCOO 
            Caption         =   "Por Intervalo de COO"
         End
         Begin VB.Menu mniPorIntervaloPeriodo 
            Caption         =   "Por Intervalo de Periodo"
         End
         Begin VB.Menu mniPorCOO 
            Caption         =   "Por COO"
         End
         Begin VB.Menu mniPorDataMovimento 
            Caption         =   "Por Data de Movimento"
         End
      End
      Begin VB.Menu mniSeparator21 
         Caption         =   "-"
      End
      Begin VB.Menu mniEspelhoMFDDLL 
         Caption         =   "Espelho MFD DLL"
         Begin VB.Menu mniEspelhoPorCOO 
            Caption         =   "Por COO"
         End
         Begin VB.Menu mniEspelhoPorPeriodo 
            Caption         =   "Por Periodo"
         End
      End
      Begin VB.Menu mniSeparator22 
         Caption         =   "-"
      End
      Begin VB.Menu mniArquivoMFDDLL 
         Caption         =   "Arquivo MFD DLL"
         Begin VB.Menu mniArquivoPorCOO 
            Caption         =   "Por COO"
         End
         Begin VB.Menu mniArquivoPorPeriodo 
            Caption         =   "Por Periodo"
         End
      End
   End
   Begin VB.Menu mnCupomFiscal 
      Caption         =   "&Cupom Fiscal"
      Begin VB.Menu mniTestaPodeAbrirCupom 
         Caption         =   "Testa Pode Abrir Cupom"
      End
      Begin VB.Menu mniIdentificaConsumidor 
         Caption         =   "Identifica Consumidor"
      End
      Begin VB.Menu mniSeparator26 
         Caption         =   "-"
      End
      Begin VB.Menu mniAbreCupomFiscal 
         Caption         =   "Abre Cupom"
      End
      Begin VB.Menu mniVendeItem 
         Caption         =   "Vende Item"
      End
      Begin VB.Menu mni 
         Caption         =   "Legenda Inmetro Próximo Item "
      End
      Begin VB.Menu mniCancelaItemVendido 
         Caption         =   "Cancela Item Vendido"
      End
      Begin VB.Menu mniCancelaItemVendidoParcial 
         Caption         =   "Cancela Item Vendido Parcial"
      End
      Begin VB.Menu mniCancelaDescontoAcrescimoItem 
         Caption         =   "Cancela Desconto/Acrescimo Item"
      End
      Begin VB.Menu mniSeparator28 
         Caption         =   "-"
      End
      Begin VB.Menu mniSubTotalizaCupom 
         Caption         =   "SubTotaliza Cupom"
      End
      Begin VB.Menu mniCancelaDescontoAcrescimoSubTotal 
         Caption         =   "Cancela Desconto/Acrescimo SubTotal"
      End
      Begin VB.Menu mniEfetuaPagamento 
         Caption         =   "Efetua Pagamento"
      End
      Begin VB.Menu mniEstornaMeioPagamento 
         Caption         =   "Estorna Meio de Pagamento"
      End
      Begin VB.Menu mniFechaCupom 
         Caption         =   "Fecha Cupom"
      End
      Begin VB.Menu mniCancelaCupom 
         Caption         =   "Cancela Cupom"
      End
      Begin VB.Menu mniSeparator29 
         Caption         =   "-"
      End
      Begin VB.Menu mniVariaveis 
         Caption         =   "Variáveis"
         Begin VB.Menu mniNumeroCupom 
            Caption         =   "Número do Cupom"
         End
         Begin VB.Menu mniSubTotal 
            Caption         =   "SubTotal"
         End
         Begin VB.Menu mniTotalPago 
            Caption         =   "Total Pago"
         End
         Begin VB.Menu mniNumUltimoItem 
            Caption         =   "Número Último Item"
         End
      End
      Begin VB.Menu mniSeparator30 
         Caption         =   "-"
      End
      Begin VB.Menu mniTesteVelocidade 
         Caption         =   "Teste de Velocidade"
      End
   End
   Begin VB.Menu mnNaoFiscal 
      Caption         =   "&Não Fiscal"
      Begin VB.Menu mniNãoFiscalCompleto 
         Caption         =   "Não Fiscal Completo"
      End
      Begin VB.Menu mniSeparator31 
         Caption         =   "-"
      End
      Begin VB.Menu mniSangria 
         Caption         =   "Sangria"
      End
      Begin VB.Menu mniSuprimento 
         Caption         =   "Suprimento"
      End
      Begin VB.Menu mniSeparator32 
         Caption         =   "-"
      End
      Begin VB.Menu mniAbreNaoFiscal 
         Caption         =   "Abre Não Fiscal"
      End
      Begin VB.Menu mniRegistraItemNaoFiscal 
         Caption         =   "Registra Item Não Fiscal"
      End
      Begin VB.Menu mniSubTotalizaNaoFiscal 
         Caption         =   "SubTotaliza Não Fiscal"
      End
      Begin VB.Menu mniEfetuaPagamentoNaoFiscal 
         Caption         =   "Efetua Pagamento Não Fiscal"
      End
      Begin VB.Menu mniFechaNaoFiscal 
         Caption         =   "Fecha Não Fiscal"
      End
      Begin VB.Menu mniSeparator33 
         Caption         =   "-"
      End
      Begin VB.Menu mniCancelaNaoFiscal 
         Caption         =   "Cancela Não Fiscal"
      End
   End
   Begin VB.Menu mnDispositivos 
      Caption         =   "&Dispositivos"
      Begin VB.Menu mniGaveta 
         Caption         =   "&Gaveta"
         Begin VB.Menu mniAbreGaveta 
            Caption         =   "Abre Gaveta"
         End
         Begin VB.Menu mniGavetaAberta 
            Caption         =   "Gaveta Aberta ?"
         End
      End
      Begin VB.Menu mniCheque 
         Caption         =   "&Cheque"
         Begin VB.Menu mniChequePronto 
            Caption         =   "Cheque Pronto ?"
         End
         Begin VB.Menu mniImprimeCheque 
            Caption         =   "Imprime Cheque"
         End
         Begin VB.Menu mniCancelaImpressaoCheque 
            Caption         =   "Cancela Impressão Cheque"
         End
      End
   End
   Begin VB.Menu mnUtilitarios 
      Caption         =   "&Utilitários"
      Begin VB.Menu mniProgramaAliquota 
         Caption         =   "Programa Aliquota"
      End
      Begin VB.Menu mniProgramaFormaPagamento 
         Caption         =   "Programa Forma de Pagamento"
      End
      Begin VB.Menu mniProgramaComprovanteNaoFiscal 
         Caption         =   "Programa Comprovante NÃO Fiscal"
      End
      Begin VB.Menu mniProgramaRelatorioGerencial 
         Caption         =   "Programa Relatório Gerencial"
      End
      Begin VB.Menu mniProgramaUnidadeMedida 
         Caption         =   "Programa Unidade Medida"
      End
      Begin VB.Menu mniSeparator35 
         Caption         =   "-"
      End
      Begin VB.Menu mniConsultaRegistradorECF 
         Caption         =   "Consulta Registrador ECF"
      End
      Begin VB.Menu mniDeCodificaTexto 
         Caption         =   "De/Codifica Texto"
      End
      Begin VB.Menu mniSeparator36 
         Caption         =   "-"
      End
      Begin VB.Menu mniMudaHorarioVerao 
         Caption         =   "Muda Horário Verão"
      End
      Begin VB.Menu mniMudaArredondamento 
         Caption         =   "Muda Arredondamento"
      End
      Begin VB.Menu mniImpactoAgulhas 
         Caption         =   "Impacto Agulhas"
      End
      Begin VB.Menu mniSeparator37 
         Caption         =   "-"
      End
      Begin VB.Menu mniCorrigeEstadoErro 
         Caption         =   "Corrige Estado de Erro"
      End
      Begin VB.Menu mniSeparator38 
         Caption         =   "-"
      End
      Begin VB.Menu mniEnviaComando 
         Caption         =   "Envia Comando"
      End
   End
End
Attribute VB_Name = "MainFrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Baseado no demo do projeto ACBrX desenvolvido por Robson Braga
' www.easysoftware.net.br/acbrx.html

Option Explicit

Public WithEvents ACBrECF As ACBrFramework_Net.ACBrECF
Attribute ACBrECF.VB_VarHelpID = -1
Public WithEvents ACBrAAC As ACBrFramework_Net.ACBrAAC
Attribute ACBrAAC.VB_VarHelpID = -1
Public WithEvents ACBrEAD As ACBrFramework_Net.ACBrEAD
Attribute ACBrEAD.VB_VarHelpID = -1

Dim Estados() As Variant
Const PARAMETROS As String = "Parâmetros"
Const SALVAR As String = "Salvar"

Private Sub CarregarACBrECF()
    Set ACBrECF = New ACBrECF
    
    'Utilizar o AAC
    'Set ACBrAAC = New ACBrAAC
    'ACBrAAC.NomeArquivoAuxiliar = "C:\teste.txt"
    'Set ACBrECF.AAC = ACBrAAC
    
    'Utilizar o EAD
    'Set ACBrEAD = New ACBrEAD
    'Set ACBrECF.EAD = ACBrEAD
        
    ReDim Estados(10)
    Estados = Array("Não Inicializada", "Desconhecido", _
        "Livre", "Venda", "Pagamento", "Relatório", "Bloqueada", _
        "Requer Z", "Requer X", "Não Fiscal")
End Sub

Private Sub Ativar()
    Call MouseEspera
    ACBrECF.Device.Porta = cbPorta.Text

    If cbModelo.ListIndex = 0 Then
        If Not ACBrECF.AcharECF(True, False) Then
            Call MouseNormal
            MsgBox "Nenhum ECF encontrado.", vbInformation
            Exit Sub
        End If
    End If
    
    ACBrECF.Ativar
    If Not ACBrECF.Ativo Then
        Call MouseNormal
        Exit Sub
    End If

    btnSerial.Enabled = False
    btnAtivarDesativar.Caption = "Desativar"
    Call AdicionarResposta("Ativar")
    
    Call AtualizarMemos
    Call GravarINI
    
    If SSTabMain.Tab = 0 Then
       SSTabMain.Tab = 1
    End If
    
    cbModelo.ListIndex = ACBrECF.Modelo
    cbPorta.Text = ACBrECF.Device.Porta
    Call MouseNormal
End Sub

Private Sub Desativar()
    Call ACBrECF.Desativar
    btnAtivarDesativar.Caption = "Ativar"
    Call AdicionarResposta("Desativar")
    Call AtualizarMemos
    btnSerial.Enabled = True
End Sub

Public Sub AtualizarMemos()
    txtEnviado.Text = ACBrECF.ComandoEnviado
    Call AdicionarResposta(ACBrECF.RespostaComando)
    Call AdicionarResposta("- + - + - + - + - + - + - + - + - + - + - + -")
    StatusBar.Panels(1).Text = EstadoECF(ACBrECF.Estado)
End Sub

Private Sub GravarINI()
    Dim ini As String
    ini = App.Path & "\ECFTeste.ini"
    
    Call WriteINI(ini, "ECF", "Modelo", cbModelo.ListIndex)
    Call WriteINI(ini, "ECF", "Porta", cbPorta.Text)
    Call WriteINI(ini, "ECF", "TimeOut", txtTimeOut.Text)
    Call WriteINI(ini, "ECF", "IntervaloAposComando", txtIntervalo.Text)
    Call WriteINI(ini, "ECF", "TentarNovamente", chkTentarNovamente.Value)
    Call WriteINI(ini, "ECF", "BloqueiaMouseTeclado", chkBloqueiaMouseTeclado.Value)
    Call WriteINI(ini, "ECF", "ExibeMsgAguarde", chkExibeMsgAguarde.Value)
    Call WriteINI(ini, "ECF", "ArredondaPorQtd", chkArredondaPorQtd.Value)
    Call WriteINI(ini, "ECF", "GavetaSinalInvertido", chkGavetaSinalInvertido.Value)
    Call WriteINI(ini, "ECF", "DescricaoGrande", chkDescricaoGrande.Value)
    Call WriteINI(ini, "ECF", "MensagemAguarde", txtMensagemAguarde.Text)
    Call WriteINI(ini, "ECF", "ArqLog", txtArqLog.Text)
    Call WriteINI(ini, "ECF", "Operador", ACBrECF.Operador)
    Call WriteINI(ini, "ECF", "MensagemTrabalhando", txtMensagemTrabalho.Text)
    
    Call WriteINI(ini, "RFD", "GerarRFD", chkRFD.Value)
    Call WriteINI(ini, "RFD", "DirRFD", txtDirRFD.Text)
    Call WriteINI(ini, "RFD", "SH_RazaoSocial", txtDadosSW(0).Text)
    Call WriteINI(ini, "RFD", "SH_COO", txtDadosSW(1).Text)
    Call WriteINI(ini, "RFD", "SH_CNPJ", txtDadosSW(2).Text)
    Call WriteINI(ini, "RFD", "SH_IE", txtDadosSW(3).Text)
    Call WriteINI(ini, "RFD", "SH_IM", txtDadosSW(4).Text)
    Call WriteINI(ini, "RFD", "SH_Aplicativo", txtDadosSW(5).Text)
    Call WriteINI(ini, "RFD", "SH_NumeroAplicativo", txtDadosSW(6).Text)
    Call WriteINI(ini, "RFD", "SH_VersaoAplicativo", txtDadosSW(7).Text)
    Call WriteINI(ini, "RFD", "SH_Linha1", txtDadosSW(8).Text)
    Call WriteINI(ini, "RFD", "SH_Linha2", txtDadosSW(9).Text)
End Sub

Private Sub LerINI()
    Dim ini As String
    Dim IniMemo As String
    ini = App.Path & "\ECFTeste.ini"
    
    If ReadINI(ini, "ECF", "Modelo", "") <> "" Then
        cbModelo.ListIndex = ReadINI(ini, "ECF", "Modelo", "")
        cbPorta.Text = ReadINI(ini, "ECF", "Porta", "")
        txtTimeOut.Text = ReadINI(ini, "ECF", "TimeOut", "3")
        txtIntervalo.Text = ReadINI(ini, "ECF", "IntervaloAposComando", "100")
        chkTentarNovamente.Value = ReadINI(ini, "ECF", "TentarNovamente", "0")
        chkBloqueiaMouseTeclado.Value = ReadINI(ini, "ECF", "BloqueiaMouseTeclado", "0")
        chkExibeMsgAguarde.Value = ReadINI(ini, "ECF", "ExibeMsgAguarde", "0")
        chkArredondaPorQtd.Value = ReadINI(ini, "ECF", "ArredondaPorQtd", "0")
        chkGavetaSinalInvertido.Value = ReadINI(ini, "ECF", "GavetaSinalInvertido", "0")
        chkDescricaoGrande.Value = ReadINI(ini, "ECF", "DescricaoGrande", "0")
        txtMensagemAguarde.Text = ReadINI(ini, "ECF", "MensagemAguarde", "")
        txtArqLog.Text = ReadINI(ini, "ECF", "ArqLog", "")
        txtMensagemTrabalho.Text = ReadINI(ini, "ECF", "MensagemTrabalhando", "")
        ACBrECF.Operador = ReadINI(ini, "ECF", "Operador", "")
    End If
    
    ACBrECF.Device.TimeOut = txtTimeOut.Text
    ACBrECF.IntervaloAposComando = txtIntervalo.Text
    ACBrECF.ArredondaPorQtd = chkArredondaPorQtd.Value
    ACBrECF.GavetaSinalInvertido = chkGavetaSinalInvertido.Value
    ACBrECF.DescricaoGrande = chkDescricaoGrande.Value
    ACBrECF.ArqLOG = txtArqLog.Text

    chkRFD.Value = ReadINI(ini, "RFD", "GerarRFD", "0")
    txtDirRFD.Text = ReadINI(ini, "RFD", "DirRFD", "")
    txtDadosSW(0).Text = ReadINI(ini, "RFD", "SH_RazaoSocial", "")
    txtDadosSW(1).Text = ReadINI(ini, "RFD", "SH_COO", "")
    txtDadosSW(2).Text = ReadINI(ini, "RFD", "SH_CNPJ", "")
    txtDadosSW(3).Text = ReadINI(ini, "RFD", "SH_IE", "")
    txtDadosSW(4).Text = ReadINI(ini, "RFD", "SH_IM", "")
    txtDadosSW(5).Text = ReadINI(ini, "RFD", "SH_Aplicativo", "")
    txtDadosSW(6).Text = ReadINI(ini, "RFD", "SH_NumeroAplicativo", "")
    txtDadosSW(7).Text = ReadINI(ini, "RFD", "SH_VersaoAplicativo", "")
    txtDadosSW(8).Text = ReadINI(ini, "RFD", "SH_Linha1", "")
    txtDadosSW(9).Text = ReadINI(ini, "RFD", "SH_Linha2", "")
    
    'PENDENTE: ACBrRFD não portado para ActiveX
    'ACBrRFD.DirRFD = txtDirRFD.Text
    'ACBrRFD.SH_RazaoSocial = txtDadosSW(0).Text
    'ACBrRFD.SH_COO = txtDadosSW(1).Text
    'ACBrRFD.SH_CNPJ = txtDadosSW(2).Text
    'ACBrRFD.SH_IE = txtDadosSW(3).Text
    'ACBrRFD.SH_IM = txtDadosSW(4).Text
    'ACBrRFD.SH_NomeAplicativo = txtDadosSW(5).Text
    'ACBrRFD.SH_NumeroAplicativo = txtDadosSW(6).Text
    'ACBrRFD.SH_VersaoAplicativo = txtDadosSW(7).Text
    'ACBrRFD.SH_Linha1 = txtDadosSW(8).Text
    'ACBrRFD.SH_Linha2 = txtDadosSW(9).Text
    
    'IniMemo = App.Path & "\ACBrECFMemoParams.ini"
    
    'If Dir(IniMemo) <> "" Then
     '   Call ACBrECF.CarregarMemoParams(IniMemo)
    'End If

End Sub

Private Function EstadoECF(e As EstadoECF) As String
    EstadoECF = Estados(e)
End Function



Private Sub ACBrECF_OnAguardandoRespostaChange()
    If ACBrECF.AguardandoResposta Then
        StatusBar.Panels(1).Text = "Processando..."
    Else
        StatusBar.Panels(1).Text = ""
    End If
End Sub


Private Sub ACBrECF_OnBobinaAdicionaLinhas(ByVal e As ACBrFramework_Net.BobinaEventArgs)
    txtBobina.Text = txtBobina.Text & vbCrLf & e.Linhas
    txtBobina.SelStart = Len(txtBobina.Text)
End Sub

Private Sub ACBrECF_OnMsgAguarde(ByVal e As ACBrFramework_Net.MsgEventArgs)
  StatusBar.Panels(2).Text = Replace(e.Mensagem, vbLf, " ")
End Sub

Private Sub ACBrECF_OnMsgPoucoPapel()
    SSTabMain.Tab = 1
    Call AdicionarResposta("POUCO PAPEL NO ECF")
End Sub

Private Sub btnAtivarDesativar_Click()
    If btnAtivarDesativar.Caption = "Ativar" Then
        Call Ativar
    ElseIf btnAtivarDesativar.Caption = "Desativar" Then
        Call Desativar
    End If
End Sub

Private Sub btnBobinaLimpar_Click()
    txtBobina.Text = ""
    If btnBobinaParams.Caption = SALVAR Then
        btnBobinaParams.Caption = PARAMETROS
    End If
End Sub

Private Sub btnBobinaParams_Click()
Dim Bobina As String
    
    If btnBobinaParams.Caption = PARAMETROS Then
        Call ArrayToStr(ACBrECF.MemoParams, Bobina)
        txtBobina.Text = Bobina
        btnBobinaParams.Caption = SALVAR
    Else
        btnBobinaParams.Caption = PARAMETROS
        Call btnBobinaLimpar_Click
    End If
    
End Sub

Private Sub btnFontesECF_Click()
    Call ACBrECF.AbreRelatorioGerencial
    Call ACBrECF.LinhaRelatorioGerencial("LINHA NORMAL 1")
    Call ACBrECF.LinhaRelatorioGerencial(Chr(14) & "EXPANDIDO 1 LINHA")
    Call ACBrECF.LinhaRelatorioGerencial("LINHA NORMAL 1")
    Call ACBrECF.LinhaRelatorioGerencial(Chr(15) & "ON/OFF MODO CONDENSADO" & Chr(18))
    Call ACBrECF.LinhaRelatorioGerencial(Chr(27) & "W1" & "ON/OFF MODO EXPANDIDO" & Chr(27) & "W0")
    Call ACBrECF.FechaRelatorio
End Sub

Private Sub btnIdentificaPAF_Click()
    Call ACBrECF.IdentificaPAF("MD5: 0123456789!@#$%¨&*()QWERTYUIOPAX", "Demo ACBrECF")
    MsgBox "Identificação feita com sucesso.", vbInformation
End Sub

Private Sub btnLerDadosReducaoZ_Click()
Dim Aliquota As Variant
Dim CNFV As Variant
Dim Relatorio As Variant
Dim forma As Variant

    Call MouseEspera
    ACBrECF.DadosReducaoZ

    txtDadosRZ.Text = ""
    With ACBrECF.DadosReducaoZClass
  
        Call AdicionarDadosRZ("Data Impressora    : " & .DataDaImpressora)
        Call AdicionarDadosRZ("Numero Série       : " & .NumeroDeSerie)
        Call AdicionarDadosRZ("Numero Série MFD   : " & .NumeroDeSerieMFD)
        Call AdicionarDadosRZ("Numero ECF         : " & .NumeroDoECF)
        Call AdicionarDadosRZ("Numero Loja        : " & .NumeroDaLoja)
        Call AdicionarDadosRZ("Numero COO Inicial : " & .NumeroCOOInicial)
        
        Call AdicionarDadosRZ("{ REDUÇÃO Z }")
        Call AdicionarDadosRZ("Data Movimento  : " & .DataDoMovimento)
        Call AdicionarDadosRZ(" ")
        Call AdicionarDadosRZ("{ CONTADORES }")
        Call AdicionarDadosRZ("COO  : " & .COO)
        Call AdicionarDadosRZ("GNF  : " & .GNF)
        Call AdicionarDadosRZ("CRO  : " & .CRO)
        Call AdicionarDadosRZ("CRZ  : " & .CRZ)
        Call AdicionarDadosRZ("CCF  : " & .CCF)
        Call AdicionarDadosRZ("CFD  : " & .CFD)
        Call AdicionarDadosRZ("CDC  : " & .CDC)
        Call AdicionarDadosRZ("GRG  : " & .GRG)
        Call AdicionarDadosRZ("GNFC : " & .GNFC)
        Call AdicionarDadosRZ("CFC  : " & .CFC)
        Call AdicionarDadosRZ("NCN  : " & .NCN)
        Call AdicionarDadosRZ("CCDC : " & .CCDC)
        Call AdicionarDadosRZ(" ")
        
        Call AdicionarDadosRZ("{ TOTALIZADORES }")
        Call AdicionarDadosRZ("Grande Total      : " & Format(.ValorGrandeTotal, "#0.00"))
        Call AdicionarDadosRZ("VendaBruta        : " & Format(.ValorVendaBruta, "#0.00"))
        Call AdicionarDadosRZ("CancelamentoICMS  : " & Format(.CancelamentoICMS, "#0.00"))
        Call AdicionarDadosRZ("DescontoICMS      : " & Format(.DescontoICMS, "#0.00"))
        Call AdicionarDadosRZ("CancelamentoISSQN : " & Format(.CancelamentoISSQN, "#0.00"))
        Call AdicionarDadosRZ("DescontoISSQN     : " & Format(.DescontoISSQN, "#0.00"))
        Call AdicionarDadosRZ("CancelamentoOPNF  : " & Format(.CancelamentoOPNF, "#0.00"))
        Call AdicionarDadosRZ("DescontoOPNF      : " & Format(.DescontoOPNF, "#0.00"))
        Call AdicionarDadosRZ("VendaLiquida      : " & Format(.VendaLiquida, "#0.00"))
        Call AdicionarDadosRZ("AcrescimoICMS     : " & Format(.AcrescimoICMS, "#0.00"))
        Call AdicionarDadosRZ("AcrescimoISSQN    : " & Format(.AcrescimoISSQN, "#0.00"))
        Call AdicionarDadosRZ("AcrescimoOPNF     : " & Format(.AcrescimoOPNF, "#0.00"))
        Call AdicionarDadosRZ("")

        Call AdicionarDadosRZ("{ ICMS }")
        
        For Each Aliquota In .ICMS
            Call AdicionarDadosRZ("Indice    : " & Aliquota.Indice)
            Call AdicionarDadosRZ("Tipo      : " & Aliquota.tipo)
            Call AdicionarDadosRZ("Aliquota  : " & Format(Aliquota.ValorAliquota, "#0.00"))
            Call AdicionarDadosRZ("Total     : " & Format(Aliquota.Total, "#0.00"))
        Next
        
        Call AdicionarDadosRZ("TotalICMS         : " & Format(.TotalICMS, "#0.00"))
        Call AdicionarDadosRZ("SubstituicaoTributariaICMS: " & Format(.SubstituicaoTributariaICMS, "#0.00"))
        Call AdicionarDadosRZ("IsentoICMS                : " & Format(.IsentoICMS, "#0.00"))
        Call AdicionarDadosRZ("NaoTributadoICMS          : " & Format(.NaoTributadoICMS, "#0.00"))
        Call AdicionarDadosRZ(" ")

        Call AdicionarDadosRZ("{ ISSQN }")
        For Each Aliquota In .ISSQN
            Call AdicionarDadosRZ("Indice    : " & Aliquota.Indice)
            Call AdicionarDadosRZ("Tipo      : " & Aliquota.tipo)
            Call AdicionarDadosRZ("Aliquota  : " & Format(Aliquota.Aliquota, "#0.00"))
            Call AdicionarDadosRZ("Total     : " & Format(Aliquota.Total, "#0.00"))
        Next
        
        Call AdicionarDadosRZ("TotalISSQN        : " & Format(.TotalISSQN, "#0.00"))
        Call AdicionarDadosRZ("SubstituicaoTributariaISSQN: " & Format(.SubstituicaoTributariaISSQN, "#0.00"))
        Call AdicionarDadosRZ("IsentoISSQN                : " & Format(.IsentoISSQN, "#0.00"))
        Call AdicionarDadosRZ("NaoTributadoISSQN          : " & Format(.NaoTributadoISSQN, "#0.00"))
        Call AdicionarDadosRZ(" ")

        Call AdicionarDadosRZ("{ TOTALIZADORES NÃO FISCAIS }")
        For Each CNFV In .TotalizadoresNaoFiscais
            Call AdicionarDadosRZ("Indice     : " & CNFV.Indice)
            Call AdicionarDadosRZ("Descrição  : " & CNFV.Descricao)
            Call AdicionarDadosRZ("Forma Pagto: " & CNFV.FormaPagamento)
            Call AdicionarDadosRZ("Total      : " & Format(CNFV.Total, "#0.00"))
        Next
        
        Call AdicionarDadosRZ("TotalOperacaoNaoFiscal : " & Format(.TotalOperacaoNaoFiscal, "#0.00"))
        Call AdicionarDadosRZ(" ")
        
        Call AdicionarDadosRZ("{ RELATÓRIO GERENCIAL }")
        
        For Each Relatorio In .RelatorioGerencial
            Call AdicionarDadosRZ("Indice     : " & Relatorio.Indice)
            Call AdicionarDadosRZ("Descrição  : " & Relatorio.Descricao)
        Next
        Call AdicionarDadosRZ(" ")
        
        Call AdicionarDadosRZ("{ MEIOS DE PAGAMENTO }")
        For Each forma In .MeiosDePagamento
            Call AdicionarDadosRZ("Indice     : " & forma.Indice)
            Call AdicionarDadosRZ("Descrição  : " & forma.Descricao)
            Call AdicionarDadosRZ("Total      : " & Format(forma.Total, "#0.00"))
        Next
        Call AdicionarDadosRZ("Total Troco : " & Format(.TotalTroco, "#0.00"))
    End With
    
    Call MouseNormal
End Sub

Private Sub btnMenuFiscalLMFC_Click()
Dim PathArquivo As String

    If chkMenuFiscalGerarArquivo.Value Then
    
        Dialog.DialogTitle = "Salvar Arquivo"
        Dialog.Filter = "Arquivos texto (*.txt)"
        Dialog.CancelError = True
        Dialog.DefaultExt = "txt"
        
        On Error Resume Next
        
        Dialog.ShowSave
        If Err Then
            MsgBox "Operação cancelada", vbCritical
            Exit Sub
        End If
    
        PathArquivo = Dialog.FileName

        If chkMenuFiscalCotepe1704.Value Then
            If sstMenuFiscalTipo.Tab = 0 Then
                ACBrECF.PafMF_LMFC_Cotepe1704PorData dtpData(0).Value, dtpData(1).Value, PathArquivo
            Else
                ACBrECF.PafMF_LMFC_Cotepe1704PorCRZ txtCOO(0).Text, txtCOO(1).Text, PathArquivo
            End If
        Else
            If sstMenuFiscalTipo.Tab = 0 Then
                ACBrECF.PafMF_LMFC_EspelhoPorData dtpData(0).Value, dtpData(1).Value, PathArquivo
    
            Else
                ACBrECF.PafMF_LMFC_EspelhoPorCRZ txtCOO(0).Text, txtCOO(1).Text, PathArquivo
            End If
        End If
    Else
        If sstMenuFiscalTipo.Tab = 0 Then
            ACBrECF.PafMF_LMFC_ImpressaoPorData dtpData(0).Value, dtpData(1).Value
        Else
            ACBrECF.PafMF_LMFC_ImpressaoPorCRZ txtCOO(0).Text, txtCOO(1).Text

        End If
      
    End If
End Sub

Private Sub btnMenuFiscalLMFS_Click()
Dim PathArquivo As String

    If chkMenuFiscalGerarArquivo.Value Then
  
        Dialog.DialogTitle = "Salvar Arquivo"
        Dialog.Filter = "Arquivos texto (*.txt)"
        Dialog.CancelError = True
        Dialog.DefaultExt = "txt"
        
        On Error Resume Next
        
        Dialog.ShowSave
        If Err Then
            MsgBox "Operação cancelada", vbCritical
            Exit Sub
        End If
        
        PathArquivo = Dialog.FileName
        
        PathArquivo = Dialog.FileName
        If sstMenuFiscalTipo.Tab = 0 Then
            ACBrECF.PafMF_LMFS_EspelhoPorData dtpData(0).Value, dtpData(1).Value, PathArquivo
        Else
            ACBrECF.PafMF_LMFS_EspelhoPorCRZ txtCOO(0).Text, txtCOO(1).Text, PathArquivo
        End If
        
        MsgBox "Arquivo gerado com sucesso em:" & vbCrLf & PathArquivo, vbInformation
    Else
        If sstMenuFiscalTipo.Tab = 0 Then
            ACBrECF.PafMF_LMFS_ImpressaoPorData dtpData(0).Value, dtpData(1).Value
        Else
            ACBrECF.PafMF_LMFS_ImpressaoPorCRZ txtCOO(0).Text, txtCOO(1).Text
        End If
  End If
End Sub

Private Sub btnMenuFiscalLX_Click()
    Call ACBrECF.PafMF_LX_Impressao
End Sub

Private Sub btnMenuFiscalMFDArq_Click()
Dim PathArquivo As String

    Dialog.DialogTitle = "Salvar Arquivo"
    Dialog.Filter = "Arquivos texto (*.txt)"
    Dialog.CancelError = True
    Dialog.DefaultExt = "txt"
    
    On Error Resume Next
    
    Dialog.ShowSave
    If Err Then
        MsgBox "Operação cancelada", vbCritical
        Exit Sub
    End If
  
    PathArquivo = Dialog.FileName

    If sstMenuFiscalTipo.Tab = 0 Then
        ACBrECF.PafMF_MFD_Cotepe1704PorData dtpData(0).Value, dtpData(1).Value, PathArquivo
    Else
        ACBrECF.PafMF_MFD_Cotepe1704PorCOO txtCOO(0).Text, txtCOO(1).Text, PathArquivo
    End If

    MsgBox "Arquivo gerado com sucesso em:" & vbCrLf & PathArquivo, vbInformation
  
End Sub

Private Sub btnMenuFiscalMFDEspelho_Click()
Dim PathArquivo As String
  
    Dialog.DialogTitle = "Salvar Arquivo"
    Dialog.Filter = "Arquivos texto (*.txt)"
    Dialog.CancelError = True
    Dialog.DefaultExt = "txt"
    
    On Error Resume Next
    
    Dialog.ShowSave
    If Err Then
        MsgBox "Operação cancelada", vbCritical
        Exit Sub
    End If
  
    PathArquivo = Dialog.FileName
    
    If sstMenuFiscalTipo.Tab = 0 Then
        ACBrECF.PafMF_MFD_EspelhoPorData dtpData(0).Value, dtpData(1).Value, PathArquivo
    Else
        ACBrECF.PafMF_MFD_EspelhoPorCOO txtCOO(0).Text, txtCOO(1).Text, PathArquivo
    End If
    
    MsgBox "Arquivo gerado com sucesso em:" & vbCrLf & PathArquivo, vbInformation
End Sub

Private Sub btnMenuFiscalRelDAVEmitidos_Click()
Dim DAVs(1 To 25) As DAVs
Dim i, itd, iv, id, COODav, COOCupom As Integer
Dim TipoDAV As Variant
Dim Valores As Variant
Dim Datas As Variant

    ReDim TipoDAV(2)
    ReDim Valores(4)
    ReDim Datas(5)
    
    TipoDAV = Array("PEDIDO", "ORÇAMENTO")
    Valores = Array(1, 2, 3.5, 10.45)
    Datas = Array("30/12/2000", "01/01/2011", "25/02/2010", "04/02/2011", "13/04/2011")
    
    For i = 1 To 25
        Set DAVs(i) = New DAVs
        
        Call Randomize
        itd = CInt(Int((2 * Rnd()) + 1)) - 1
        id = CInt(Int((5 * Rnd()) + 1)) - 1
        iv = CInt(Int((4 * Rnd()) + 1)) - 1
        
        DAVs(i).COO_Dav = Int(Rnd * 1000) + 1
        DAVs(i).COO_Cupom = Int(Rnd * 1000) + 1
        DAVs(i).Titulo = TipoDAV(itd)
        DAVs(i).DtEmissao = Datas(id)
        DAVs(i).Valor = CCur(Valores(iv))
        
    Next i

    ACBrECF.PafMF_RelDAVEmitidos DAVs, "REFERENCIA: 00/00/0000 A 00/00/0000", 0
End Sub

Private Sub btnMenuFiscalRelMeiosPagto_Click()
  
 Call ACBrECF.PafMF_RelMeiosPagamento(ACBrECF.DadosReducaoZClass.MeiosDePagamento, "PERIODO 01/01/2000 A 31/12/2000", 0)
   
End Sub

Private Sub btnSerial_Click()
    ConfiguraSerialFrm.cbxPortaSerial.Text = cbPorta.Text
    ConfiguraSerialFrm.Show vbModal
    cbPorta.Text = ConfiguraSerialFrm.cbxPortaSerial.Text
End Sub

Private Sub cbModelo_Click()
    ACBrECF.Modelo = cbModelo.ListIndex
End Sub

Private Sub cbPorta_Click()
    ACBrECF.Device.Porta = cbPorta.Text
End Sub

Private Sub chkArredondaPorQtd_Click()
    ACBrECF.ArredondaPorQtd = chkArredondaPorQtd.Value
End Sub


Private Sub chkDescricaoGrande_Click()
    ACBrECF.DescricaoGrande = chkDescricaoGrande.Value
End Sub


Private Sub chkGavetaSinalInvertido_Click()
    ACBrECF.GavetaSinalInvertido = chkGavetaSinalInvertido.Value
End Sub

Private Sub chkImpTextoVertical_Click()
    txtTextoBarras.Enabled = chkImpTextoVertical.Value
End Sub

Private Sub chkRFD_Click()
Dim OldAtivo As Boolean

    OldAtivo = ACBrECF.Ativo
    
    Call ACBrECF.Desativar
    
    'PENDENTE:
    'If chkRFD.Value Then
    '    ACBrECF.RFD = ACBrRFD
    'Else
    '    ACBrECF.RFD = Nothing
    'End If
    
    If (OldAtivo) Then
    ACBrECF.Ativar
    End If
    

End Sub


Private Sub Command10_Click()
Dim TipoCodBarra As Integer

    If obTipoCodBarras(0).Value Then
        TipoCodBarra = 0
    ElseIf obTipoCodBarras(1).Value Then
        TipoCodBarra = 1
    ElseIf obTipoCodBarras(2).Value Then
        TipoCodBarra = 2
    ElseIf obTipoCodBarras(3).Value Then
        TipoCodBarra = 3
    ElseIf obTipoCodBarras(4).Value Then
        TipoCodBarra = 4
    ElseIf obTipoCodBarras(5).Value Then
        TipoCodBarra = 5
    ElseIf obTipoCodBarras(6).Value Then
        TipoCodBarra = 6
    ElseIf obTipoCodBarras(7).Value Then
        TipoCodBarra = 7
    ElseIf obTipoCodBarras(8).Value Then
        TipoCodBarra = 8
    ElseIf obTipoCodBarras(9).Value Then
        TipoCodBarra = 9
    ElseIf obTipoCodBarras(10).Value Then
        TipoCodBarra = 10
    End If
    
    'PENDENTE
    'If ACBrECF.CodigodeBarras.AdicionarCodBarra(TipoCodBarra, _
        'txtLarguraBarra.Text, txtAlturaBarra.Text, txtCodBarras.Text, _
        'chkImpTextoAbaixoBarras.Value, chkImpTextoVertical.Value) Then
    
        'Call ACBrECF.FechaCupom(txtTextoBarras.Text, 0)
    'End If
End Sub

Private Sub Command6_Click()
    txtDirRFD.Text = SelecionarDiretorio("Por favor, selecione o diretório " & _
        "para arquivos RFD.")
End Sub

Private Sub Command7_Click()

'PENDENTE
'Dim s As String
'Dim a As Variant
'    If Not ACBrRFD.Ativo Then
'        MsgBox "ACBrRFD não está ativo", vbCritical
'        Exit Sub
'    End If
'
'    a = ACBrECF.LoadFromFile(ACBrRFD.ArqINI)
'    Call ArrayToStr(a, s)
'    txtRFDParam.Text = s
End Sub

Private Sub Command8_Click()
'PENDENTE
'Dim OldAtivo As Boolean
'Dim t As Variant
'
'    OldAtivo = ACBrRFD.Ativo
'
'    t = Split(txtRFDParam.Text, vbCrLf)
'    Call ACBrECF.SaveToFile(t, ACBrRFD.ArqINI)
'    Call ACBrRFD.Desativar
'
'    ACBrRFD.Ativo = OldAtivo
End Sub

Private Sub Command9_Click()
Dim TipoCodBarra As Integer

    If obTipoCodBarras(0).Value Then
        TipoCodBarra = 0
    ElseIf obTipoCodBarras(1).Value Then
        TipoCodBarra = 1
    ElseIf obTipoCodBarras(2).Value Then
        TipoCodBarra = 2
    ElseIf obTipoCodBarras(3).Value Then
        TipoCodBarra = 3
    ElseIf obTipoCodBarras(4).Value Then
        TipoCodBarra = 4
    ElseIf obTipoCodBarras(5).Value Then
        TipoCodBarra = 5
    ElseIf obTipoCodBarras(6).Value Then
        TipoCodBarra = 6
    ElseIf obTipoCodBarras(7).Value Then
        TipoCodBarra = 7
    ElseIf obTipoCodBarras(8).Value Then
        TipoCodBarra = 8
    ElseIf obTipoCodBarras(9).Value Then
        TipoCodBarra = 9
    ElseIf obTipoCodBarras(10).Value Then
        TipoCodBarra = 10
    End If
    
    'PENDENTE
    'Call ACBrECF.CodigodeBarras.AdicionarCodBarra(TipoCodBarra, _
        txtLarguraBarra.Text, txtAlturaBarra.Text, txtCodBarras.Text, _
        chkImpTextoAbaixoBarras.Value, chkImpTextoVertical.Value)
    
    Call ACBrECF.LinhaRelatorioGerencial(txtTextoBarras.Text)
End Sub

Private Sub Form_Load()
    SSTabMain.Tab = 0
    sstMenuFiscalTipo.Tab = 0
    dtpData(0).Value = "01/" & Format$(Now, "mm/yy")
    dtpData(1).Value = Format$(Now, "dd/mm/yy")
    Call CarregarACBrECF
    Call LerINI
End Sub

Private Sub mni_Click()
    Call ACBrECF.LegendaInmetroProximoItem
End Sub

Private Sub mniAbreCupomFiscal_Click()
Dim Consumidor As String
Dim CPF, Nome, Endereco As String
Dim p As Integer
Dim str As Variant

    Consumidor = " "
    If ACBrECF.Consumidor.Documento <> "" Then
        Consumidor = ACBrECF.Consumidor.Documento
    End If
    
    If ACBrECF.Consumidor.Nome <> "" Then
        Consumidor = Consumidor & "|" & ACBrECF.Consumidor.Nome
    End If
        
    If ACBrECF.Consumidor.Endereco <> "" Then
        Consumidor = Consumidor & "|" & ACBrECF.Consumidor.Endereco
    End If
    
    Consumidor = InputBox("Se necessário, Informe o Documento | Nome | Endereco" & vbCrLf & _
        "Nota: Use o sinal pipe (|) para separar os campos", "Abrir Cupom Fiscal", Consumidor)
    
    Consumidor = Trim(Consumidor)
    
    If Consumidor <> "" Then
        'Por algum motivo que desconhecemos, a função split não está permitindo que o programa seja finalizado
        str = Split(Consumidor, "|")
        
        CPF = str(0)
        Nome = str(1)
        Endereco = str(2)
    End If
    
    Call ACBrECF.AbreCupom(CPF, Nome, Endereco)
    Call AdicionarResposta("AbreCupom")
    Call AtualizarMemos
End Sub

Private Sub mniAbreCupomVinculado_Click()
Dim COO As String
Dim CodFormaPagamento As String
Dim Valor As String
  
    COO = ACBrECF.NumCupom
    CodFormaPagamento = "01"
    Valor = "0,00"
    
    CodFormaPagamento = InputBox("Digite o Cod.Forma Pagamento utilizada no cupom anterior", _
        "Abertura de Cupom Vinculado", CodFormaPagamento)
        
    If CodFormaPagamento = "" Then
        Exit Sub
    End If
        
    Valor = InputBox("Digite o Valor a vincular no cupom anterior" & vbCrLf & _
        "(Não é necessário em alguns modelos)", "Abertura de Cupom Vinculado", _
        Valor)
    
    If Valor = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.AbreCupomVinculado(COO, CodFormaPagamento, Valor)
End Sub

Private Sub mniAbreGaveta_Click()
    Call ACBrECF.AbreGaveta
    Call AdicionarResposta("AbreGaveta")
    Call AtualizarMemos
End Sub

Private Sub mniAbreNaoFiscal_Click()
Dim CPF_CNPJ As String

    CPF_CNPJ = InputBox("Se necessário, informe o CPF ou CNPJ do cliente", _
        "Abre Comprovante Não Fiscal", CPF_CNPJ)
        
    If CPF_CNPJ = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.AbreNaoFiscal(CPF_CNPJ)
    Call AdicionarResposta("Abre Não Fiscal: " & CPF_CNPJ)
    Call AtualizarMemos
End Sub

Private Sub mniAbreRelatorioGerencial_Click()
Dim IndiceStr As String
  
    IndiceStr = "1"
    IndiceStr = InputBox("Digite o Indice do Relatório Gerencial a ser utilizado", _
        "Abertura de Relatório Gerencial", IndiceStr)
    
    If IndiceStr = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.AbreRelatorioGerencial(Val(IndiceStr))
End Sub

Private Sub mniAchaAliquotaIndice_Click()

Dim Aliquota As Aliquota
Dim Indice As String

    Call ACBrECF.LerTotaisAliquota

    Indice = InputBox("Achar Aliquota por Indice", "Entre com o Indice:")

    If Indice = "" Then
        Exit Sub
    End If

    'PENDENTE
    'Set Aliquota = ACBrECF.AchaICMSIndice(Indice)

    If Not Aliquota Is Nothing Then
        Call AdicionarResposta("Indice  : " & Aliquota.Indice & vbCrLf & _
            "Aliquota: " & Format(Aliquota.Total, "#0.00") & vbCrLf & _
            "Valor atual do totalizador R$ " & Format(Aliquota.Total, "#0.00"))
    Else
      Call AdicionarResposta("Indice (" & Indice & ") não encontrado.")
    End If

    Call AtualizarMemos
End Sub

Private Sub mniAchaAliquotaValor_Click()
'PENDENTE
'Dim Aliquota As Aliquota
'Dim Valor As String
'
'    Call ACBrECF.LerTotaisAliquota
'
'    Valor = InputBox("Achar Aliquota por Valor", "Entre com o Valor:")
'
'    If Valor = "" Then
'        Exit Sub
'    End If
'
'    Set Aliquota = ACBrECF.AchaICMSAliquota(Valor, "")
'
'    If Not Aliquota Is Nothing Then
'        Call AdicionarResposta("Indice  : " & Aliquota.Indice & vbCrLf & _
'            "Aliquota: " & Format(Aliquota.Aliquota, "#0.00") & vbCrLf & _
'            "Valor atual do totalizador R$ " & Format(Aliquota.Total, "#0.00") & vbCrLf & _
'            "*****")
'    Else
'      Call AdicionarResposta("Aliquota (" & Valor & ") não encontrado.")
'    End If
'
'    Call AtualizarMemos
End Sub

Private Sub mniAchaCNFDescricao_Click()
Dim CNF As ComprovanteNaoFiscal
Dim Descricao As String

    Call ACBrECF.LerTotaisComprovanteNaoFiscal
    
    Descricao = InputBox("Entre com a Descrição:", "Acha CNF por Descrição")
    
    If Descricao = "" Then
        Exit Sub
    End If
    
    Set CNF = ACBrECF.AchaCNFDescricao(Descricao, False, True)
    
    If Not CNF Is Nothing Then
        Call AdicionarResposta("Indice   : " & CNF.Indice & vbCrLf & _
            "CON      : " & CNF.Contador & vbCrLf & _
            "Descrição: " & CNF.Descricao & vbCrLf & _
            "Valor atual do totalizador R$ " & Format(CNF.Total, "#0.00"))
    Else
        Call AdicionarResposta("CNF (" & Descricao & ") não encontrado.")
    End If
    
    Call AtualizarMemos
End Sub

Private Sub mniAchaCNFIndice_Click()
'PENDENTE
'Dim CNF As ComprovanteNaoFiscal
' Dim Indice As String
'
'    Call ACBrECF.LerTotaisComprovanteNaoFiscal
'
'    Indice = InputBox("Entre com o Indice:", "Acha CNF por Indice")
'
'    If Indice = "" Then
'        Exit Sub
'    End If
'
'    Set CNF = ACBrECF.AchaCNFIndice(Indice)
'
'    If Not CNF Is Nothing Then
'        Call AdicionarResposta("Indice   : " & CNF.Indice & vbCrLf & _
'            "CON      : " & CNF.Contador & vbCrLf & _
'            "Descrição: " & CNF.Descricao & vbCrLf & _
'            "Valor atual do totalizador R$ " & Format(CNF.Total, "#0.00"))
'    Else
'        Call AdicionarResposta("Indice (" & Indice & ") não encontrado.")
'    End If
'
'    Call AtualizarMemos
End Sub

Private Sub mniAcharFormasPagamentoIndice_Click()
Dim FormaPagto As FormaPagamento
Dim Indice As String

    Call ACBrECF.LerTotaisFormaPagamento
    
    'opa
    'MsgBox ACBrECF.FormasPagamento(0).Descricao
    
    Indice = InputBox("Entre com o Indice:", "Achar Forma Pagamento por Indice")
    If Indice = "" Then
        Exit Sub
    End If
    
    Set FormaPagto = ACBrECF.AchaFPGIndice(Indice)
    
    If Not FormaPagto Is Nothing Then
        Call AdicionarResposta("Indice   : " & FormaPagto.Indice & vbCrLf & _
            "Descrição: " & FormaPagto.Descricao & vbCrLf & _
            "Valor atual do totalizador R$ " & Format(FormaPagto.Total, "#0.00"))
    Else
        Call AdicionarResposta("Indice (" & Indice & ") não encontrado.")
    End If
    
    Call AtualizarMemos
End Sub

Private Sub mniAcharFormasPagametoDescricao_Click()
Dim FormaPagto As FormaPagamento
Dim Descricao As String

    Call ACBrECF.LerTotaisFormaPagamento
    
    Descricao = InputBox("Entre com a descrição:", "Achar Forma Pagamento por Descrição")
      
    If Descricao = "" Then
        Exit Sub
    End If
    
    Set FormaPagto = ACBrECF.AchaFPGDescricao(Descricao, False, True)
    
    If Not FormaPagto Is Nothing Then
        Call AdicionarResposta("Indice   : " & FormaPagto.Indice & vbCrLf & _
            "Descrição: " & FormaPagto.Descricao & vbCrLf & _
            "Valor atual do totalizador R$ " & Format(FormaPagto.Total, "#0.00"))
    Else
        Call AdicionarResposta("Forma de Pagamento (" & Descricao & ") não encontrada.")
    End If
    
    Call AtualizarMemos
End Sub

Private Sub mniAchaRGDescricao_Click()
'PENDENTE
'Dim RG As RelatorioGerencial
'Dim Descricao As String
'
'    Call ACBrECF.CarregaRelatoriosGerenciais
'
'    Descricao = InputBox("Entre com o Indice:", "Acha Relatório Gerencial por Indice")
'
'    If Descricao = "" Then
'      Exit Sub
'    End If
'
'    Set RG = ACBrECF.AchaRGDescricao(Descricao, False, True)
'
'    If Not RG Is Nothing Then
'        Call AdicionarResposta("Indice   : " & RG.Indice & vbCrLf & _
'            "Descrição: " & RG.Descricao & vbCrLf & _
'            "CER:     : " & Format(RG.Contador, "0000"))
'    Else
'        Call AdicionarResposta("Relatório Gerencial (" & Descricao & ") não encontrado.")
'    End If
'
'    Call AtualizarMemos
End Sub

Private Sub mniAchaRGIndice_Click()
'PENDENTE
'Dim RG As RelatorioGerencial
'Dim Indice As String
'
'    Call ACBrECF.CarregaRelatoriosGerenciais
'
'    Indice = InputBox("Entre com o Indice:", "Acha Relatório Gerencial por Indice")
'
'    If Indice = "" Then
'      Exit Sub
'    End If
'
'    Set RG = ACBrECF.AchaRGIndice(Indice)
'
'    If Not RG Is Nothing Then
'        Call AdicionarResposta("Indice   : " & RG.Indice & vbCrLf & _
'            "Descrição: " & RG.Descricao & vbCrLf & _
'            "CER:     : " & Format(RG.Contador, "0000"))
'    Else
'        Call AdicionarResposta("Indice (" & Indice & ") não encontrado.")
'    End If
'
'    Call AtualizarMemos
End Sub

Private Sub mniArquivoPorCOO_Click()
Dim Arquivo As String
Dim COOInicial, COOFinal As String

    Arquivo = "c:\temp\ArquivoMFD.txt"
    Arquivo = InputBox("Nome Arquivo:", "Arquivo da MFD DLL", Arquivo)
    If Arquivo = "" Then
        Exit Sub
    End If
    
    COOInicial = "0"
    COOFinal = "0"
    
    COOInicial = InputBox("Entre com o COO Inicial:", _
        "Arquivo da MFD DLL", COOInicial)
    If COOInicial = "" Or Val(COOInicial) < 0 Then
        Exit Sub
    End If
    
    COOFinal = InputBox("Entre com o COO Final:", _
        "Arquivo da MFD DLL", COOFinal)
    If COOFinal = "" Or Val(COOFinal) < 0 Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.ArquivoMFD_DLLPorCont(COOInicial, COOFinal, Arquivo, _
        docTodos, finMFD, tpcCOO)
End Sub

Private Sub mniArredonda_Click()
    Call AdicionarRespostaBoolean(ACBrECF.Arredonda, "Arredonda")
    AtualizarMemos
End Sub

Private Sub mniAtivar_Click()
    Call Ativar
End Sub

Private Sub mniCancelaCupom_Click()
    Call ACBrECF.CancelaCupom
    Call AdicionarResposta("CancelaCupom")
    Call AtualizarMemos
End Sub

Private Sub mniCancelaDescontoAcrescimoItem_Click()
Dim item As String

    item = "1"
    item = InputBox("Informe o número da Sequencia de Venda", _
        "Cancelar DescontoAcrescimo do Item Vendido", item)
    If item <> "" Then
        Call ACBrECF.CancelaDescontoAcrescimoItem(item)
        AdicionarResposta ("Cancelar AcrescimoDesconto: " & item)
        Call AtualizarMemos
    End If
End Sub

Private Sub mniCancelaDescontoAcrescimoSubTotal_Click()
Dim Info As String
Dim tipo As String

  Info = "D"
  
  Info = InputBox("Digite 'A' para cancelar Acrescimo ou 'D' para Desconto", _
    "Cancela DescontoAcrescimo SubTotal do Cupom", Info)
  If Info <> "" Then
     tipo = Info
     Call ACBrECF.CancelaDescontoAcrescimoSubTotal(tipo)
     Call AdicionarResposta("Cancela DescontoAcrescimo SubTotal do Cupom: " & tipo)
     Call AtualizarMemos
  End If
End Sub

Private Sub mniCancelaImpressaoCheque_Click()
    Call ACBrECF.CancelaImpressaoCheque
    Call AdicionarResposta("CancelaImpressaoCheque")
    Call AtualizarMemos
End Sub

Private Sub mniCancelaItemVendido_Click()
Dim item As String

    item = "1"
    item = InputBox("Informe o número da Sequencia de Venda", _
        "Cancelar Item Vendido", item)
    
    If item <> "" Then
        Call ACBrECF.CancelaItemVendido(item)
        Call AdicionarResposta("Cancela Item Vendido: " & item)
        Call AtualizarMemos
    End If
End Sub

Private Sub mniCancelaItemVendidoParcial_Click()
Dim item As String
Dim Qtde As String

    item = "1"
    item = InputBox("Informe o número da Sequencia de Venda", _
        "Cancelar Item Vendido", item)
    
    Qtde = InputBox("Informe quantidade do Item a cancelar", _
        "Quantidade do Item a cancelar", Qtde)
        
    If item <> "" And Qtde <> "" And Val(item) > 0 And Val(Qtde) > 0 Then
        Call ACBrECF.CancelaItemVendidoParcial(item, Qtde)
        Call AdicionarResposta("Cancela Item Vendido Parcial: " & item & ", Qtde: " & Qtde)
        Call AtualizarMemos
    End If
End Sub

Private Sub mniCancelaNaoFiscal_Click()
    Call ACBrECF.CancelaNaoFiscal
    Call AdicionarResposta("Cancela Não Fiscal")
    Call AtualizarMemos
End Sub

Private Sub mniCapturaNReduçaoZ_Click()
Dim Linhas As Variant
Dim ReducaoInicial, ReducaoFinal As String
Dim i As Integer

    ReducaoInicial = "0"
    ReducaoFinal = "0"
    
    ReducaoInicial = InputBox("Entre com o a Reduçao Z Inicial:", _
        "Captura da Memoria Fiscal", ReducaoInicial)
    
    If ReducaoInicial = "" Or Val(ReducaoInicial) < 0 Then
        Exit Sub
    End If
    
    ReducaoFinal = InputBox("Entre com o a Reduçao Z Final:", _
        "Captura da Memoria Fiscal", ReducaoFinal)
    
    If ReducaoFinal = "" Or Val(ReducaoFinal) < 0 Then
        Exit Sub
    End If
    
    
    'PENDENTE
    'Call ACBrECF.LeituraMemoriaFiscalSerialPorReducao(ReducaoInicial, ReducaoFinal, Linhas, False)
    
    'If Linhas = Empty Then
    '    Call AdicionarResposta("Memoria Serial Fiscal não encontrada.")
    '    Exit Sub
    'End If
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
    
    Call AtualizarMemos
End Sub

Private Sub mniCapturaPeriodo_Click()
Dim Linhas As Variant
Dim DataInicial, DataFinal As String
Dim i As Integer

    DataInicial = "01/" & Format$(Now, "mm/yy")
    DataFinal = Format$(Now, "dd/mm/yy")
    
    DataInicial = InputBox("Entre com o a Data Inicial (DD/MM/AA):", _
        "Captura da Memoria Fiscal", DataInicial)
    If DataInicial = "" Then
        Exit Sub
    End If
    
    DataFinal = InputBox("Entre com o a Data Final (DD/MM/AA):", _
        "Captura da Memoria Fiscal", DataFinal)
    If DataFinal = "" Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.LeituraMemoriaFiscalSerialPorData(DataInicial, DataFinal, Linhas, False)
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
End Sub

Private Sub mniCarregaAliquotasICMS_Click()
    Call CarregarAliquotasECF
End Sub

Public Sub mniCarregaComprovantesNaoFiscais_Click()
Dim comprovante As Variant
  
    Call ACBrECF.CarregaComprovantesNaoFiscais
    
    For Each comprovante In ACBrECF.ComprovantesNaoFiscais
        Call AdicionarResposta("CNF: " & comprovante.Indice & " -> " & _
             comprovante.Descricao & vbCrLf & _
             "FPG Associada: " & comprovante.FormaPagamento)
        Call AdicionarRespostaBoolean(comprovante.permiteVinculado, "Permite Vinculado")
        Call AdicionarResposta("*****")
    Next
    
    Call AtualizarMemos
End Sub

Public Sub mniCarregaFormasPagamento_Click()
Dim forma As Variant

    Call ACBrECF.CarregaFormasPagamento
    
    For Each forma In ACBrECF.FormasPagamento
        Call AdicionarResposta("Forma Pagto: " & forma.Indice & " -> " & forma.Descricao)
        Call AdicionarRespostaBoolean(forma.permiteVinculado, "Permite Vinculado")
        Call AdicionarResposta("*****")
    Next
    
    Call AtualizarMemos
End Sub

Private Sub mniCarregaRelatoriosGerenciais_Click()
Dim Relatorio As Variant
    
    Call ACBrECF.CarregaRelatoriosGerenciais
    
    For Each Relatorio In ACBrECF.RelatoriosGerenciais
        Call AdicionarResposta("RG: " & Relatorio.Indice & " -> " & _
            Relatorio.Descricao & vbCrLf & _
            "CER:" & Relatorio.Contador & vbCrLf & _
            "*****")
    Next
    
    Call AtualizarMemos
End Sub

Private Sub mniCarregaUnidadesMedida_Click()
'PENDENTE
'Dim unidade As UnidadeMedida
'
'    Call ACBrECF.CarregaUnidadesMedida
'
'    For Each unidade In ACBrECF.UnidadesMedida
'        Call AdicionarResposta("Unid Medida: " & unidade.Indice & " -> " & _
'            unidade.Descricao & vbCrLf & "*****")
'    Next
'
'    Call AtualizarMemos
End Sub

Private Sub mniChequePronto_Click()
    Call AdicionarRespostaBoolean(ACBrECF.ChequePronto, "Cheque Pronto")
    Call AtualizarMemos
End Sub

Private Sub mniCNPJ_Click()
    Call AdicionarResposta("CNPJ: (" & ACBrECF.CNPJ & ")")
    Call AtualizarMemos
End Sub

Private Sub mniConsultaRegistradorECF_Click()
'PENDENTE
'Dim Indice As String
'Dim Linhas As String
'
'    Indice = InputBox("Entre com o Indice da Informação:", _
'        "Consulta Registrador ECF", Indice)
'    If Indice = "" Then
'        Exit Sub
'    End If
'
'    Linhas = ACBrECF.RetornaInfoECF(Indice)
'
'    Call AdicionarResposta("Informação: " & Linhas)
'    Call AtualizarMemos
End Sub

Private Sub mniCorrigeEstadoErro_Click()
    Call ACBrECF.CorrigeEstadoErro(True)
End Sub

Private Sub mniCortaPapel_Click()
Dim Resp As VbMsgBoxResult

    Resp = MsgBox("Corte Parcial ?", vbYesNoCancel + vbQuestion)
    
    If Resp = vbCancel Then
        Exit Sub
    End If

    ACBrECF.CortaPapel ((Resp = vbYes))
End Sub

Private Sub mniCupomVinculadoCompleto_Click()
    Call MsgBox("Para imprimir um Cupom Vinculado você deve ter " & _
        "informações dos Pagamentos Efetuados no último Cupom Fiscal", _
        vbInformation)
    RelatorioFrm.TipoRelatorio = "V"
    RelatorioFrm.Show vbModal
End Sub

Private Sub mniDadosReducaoZ60M_Click()
    Call AdicionarResposta("Dados da Redução Z" & vbCrLf & ACBrECF.DadosReducaoZ)
    Call AtualizarMemos
End Sub

Private Sub mniDadosUltimaReducaoZ_Click()
    Call AdicionarResposta(ACBrECF.DadosUltimaReducaoZ)
    Call AtualizarMemos
End Sub

Private Sub mniDataHora_Click()
    Call AdicionarResposta("Data/Hora: " & ACBrECF.DataHora)
    Call AtualizarMemos
End Sub

Private Sub mniDataMovimento_Click()
    Call AdicionarResposta("Data Movimento: (" & ACBrECF.DataMovimento & ")")
    Call AtualizarMemos
End Sub

Private Sub mniDeCodificaTexto_Click()
Dim Operacao As String
Dim Texto As String
Dim Resposta As String

    Operacao = "C"
    Operacao = InputBox("Informe a operação a ser realizada 'C', 'D' ou 'V'", _
        "De/Codificacao", Operacao)
    If Operacao = "" Then
        Exit Sub
    End If
    
    Texto = "ACBrFramework"
    Texto = InputBox("Informe o texto a ser decodificado", _
        "Texto a ser de/codificado ou verificado", Texto)
    If Texto = "" Then
        Exit Sub
    End If
    
'PENDENTE
'    Call ACBrECF.DecodificaTexto(Operacao, Texto, Resposta)
    Call AdicionarResposta("Resposta: " & Resposta)
    Call AtualizarMemos
End Sub

Private Sub mniDesativar_Click()
    Call Desativar
End Sub

Public Sub MouseEspera()
    Screen.MousePointer = vbHourglass
    MainFrm.Enabled = False
End Sub

Public Sub MouseNormal()
    Screen.MousePointer = vbDefault
    MainFrm.Enabled = True
End Sub

Private Sub mniEfetuaPagamento_Click()

    If Not (ACBrECF.Modelo = ModeloECF_DataRegis) And Not (ACBrECF.Modelo = ModeloECF_FiscNET) Then
        If ACBrECF.Estado <> EstadoECF_Pagamento Then
            Call MsgBox("Impressora nao está em Estado de Pagamento" & vbCrLf & _
                "Primeiro use SubTotaliza Cupom", vbExclamation)
            Exit Sub
        End If
    End If
    
    PagamentoFrm.TipoCupom = "F"
    PagamentoFrm.Show vbModal
End Sub

Private Sub mniEfetuaPagamentoNaoFiscal_Click()
    PagamentoFrm.TipoCupom = "N"
    PagamentoFrm.Show vbModal
End Sub

Private Sub mniEhMFD_Click()
    Call AdicionarRespostaBoolean(ACBrECF.MFD, "MFD")
    AtualizarMemos
End Sub

Private Sub mniEhTermica_Click()
    Call AdicionarRespostaBoolean(ACBrECF.Termica, "Térmica")
    AtualizarMemos
End Sub

Private Sub mniEnviaComando_Click()
Dim CMD1, CMD2, c As String
Dim a As Integer
Dim t As String

    CMD1 = ""
    t = "0"
    CMD1 = InputBox("Digite o comando de acordo com a Sintaxe da Impressora" & vbCrLf & vbCrLf & _
        "Para Caracteres ASC use #nnn  Ex: #006 = chr(006)" & vbCrLf & vbCrLf & _
        "Exemplo: #006 irá imprimir uma Leitura X na Bematech", _
        "Enviar Comando", CMD1)
    If CMD1 <> "" Then
        t = InputBox("Digite o tamanho em Bytes do Retorno esperado" & vbCrLf & vbCrLf & _
            "NAO adcione os 3 bytes de ACK+ST1+ST2", _
            "Enviar Comando BEMATECH")
        If (Not (ACBrECF.Modelo = ModeloECF_Bematech)) Or (t <> "") Then
            CMD2 = ""
            a = 1
            'If ACBrECF.ECF Is TACBrECFBematech Then
            '  (ACBrECF.ECF as TACBrECFBematech).BytesResp := StrToIntDef(T,0) ;
            
            Do While a <= Len(CMD1)
                c = CMD1.SubString(a, 1)
                
                If c = "#" Then
                    'Ainda tenhos dúvidas sobre esse comando
                    CMD2 = CMD2 & Chr(CMD1.SubString(a + 1, 3))
                    a = a + 3
                Else
                    CMD2 = CMD2 & c
                End If
                
                a = a + 1
            Loop
            Call ACBrECF.EnviaComando(CMD2)
            Call AdicionarResposta("Envia Comando: " & CMD1)
            Call AtualizarMemos
        End If
    End If
End Sub

Private Sub mniEspelhoPorCOO_Click()
Dim Arquivo As String
Dim COOInicial, COOFinal As String

    Arquivo = "c:\temp\EspelhoMFD.txt"
    Arquivo = InputBox("Nome Arquivo:", "Espelho da MFD DLL", Arquivo)
    If Arquivo = "" Then
        Exit Sub
    End If
    
    COOInicial = "0"
    COOFinal = "0"
    
    COOInicial = InputBox("Entre com o COO Inicial:", "Espelho da MFD DLL", COOInicial)
    If COOInicial = "" Or Val(COOInicial) < 0 Then
        Exit Sub
    End If
    
    COOFinal = InputBox("Entre com o COO Final:", "Espelho da MFD DLL", COOFinal)
    If COOFinal = "" Then
        Exit Sub
    End If
    
    If COOFinal = "" Or Val(COOFinal) < 0 Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.EspelhoMFD_DLLPorCOO(COOInicial, COOFinal, Arquivo, docTodos)
End Sub

Private Sub mniEspelhoPorPeriodo_Click()
Dim Arquivo As String
Dim DataInicial, DataFinal As String
  
    Arquivo = "c:\temp\EspelhoMFD.txt"
    Arquivo = InputBox("Nome Arquivo:", "Espelho da MFD DLL", Arquivo)
    If Arquivo = "" Then
        Exit Sub
    End If
    
    DataInicial = "01/" & Format$(Now, "mm/yy")
    DataFinal = Format$(Now, "dd/mm/yy")
    
    DataInicial = InputBox("Entre com o a Data Inicial (DD/MM/AA):", _
        "Espelho da MFD DLL", DataInicial)
    If DataInicial = "" Then
        Exit Sub
    End If
    
    DataFinal = InputBox("Entre com o a Data Final (DD/MM/AA):", _
        "Captura da MFD", DataFinal)
    If DataFinal = "" Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.EspelhoMFD_DLLPorData(DataInicial, DataFinal, Arquivo, docTodos)
End Sub

Private Sub mniEstado_Click()
    Call AdicionarResposta("Estado: " & Estados(ACBrECF.Estado))
    Call AtualizarMemos
End Sub

Private Sub mniEstornaMeioPagamento_Click()
    PagamentoFrm.Estado = "Estorno"
    PagamentoFrm.Show vbModal
End Sub

Private Sub mniFechaCupom_Click()
Dim Obs As String
Dim IndiceBMP As String

    Obs = "ACBrFramework ActiveX"
    IndiceBMP = "0"
    Obs = InputBox("Se Necessário digite alguma Observaçao (até 8 linhas)" & vbCrLf & _
        "O sinal | (pipe) será convertido para #10 (quebra de linha)", _
        "Fechar Cupom", Obs)
    If Obs <> "" Then
        If (ACBrECF.Modelo = ModeloECF_Daruma) And (ACBrECF.MFD) Then
            IndiceBMP = InputBox("Digite o Indice do BMP que deseja utilizar", _
                "Impressao de imagem BMP", _
                IndiceBMP)
                
            If IndiceBMP = "" Then
                Exit Sub
            End If
        End If
        
        Obs = Replace(Obs, "|", vbCrLf)
        Call ACBrECF.FechaCupom(Obs)
        AdicionarResposta ("Fecha Cupom: " & vbCrLf & Obs)
        Call AtualizarMemos
    End If
End Sub

Private Sub mniFechaNaoFiscal_Click()
Dim Obs As String
Dim IndiceBMP As String

    Obs = "ACBrFramework ActiveX"
    IndiceBMP = "0"
    Obs = InputBox("Se Necessário digite alguma Observaçao (até 8 linhas)" & vbCrLf & _
        "O sinal | (pipe) será convertido para #10 (quebra de linha)", Obs)
    If Obs = "" Then
        Exit Sub
    End If
    
    If (ACBrECF.Modelo = ModeloECF_Daruma) And (ACBrECF.MFD) Then
        IndiceBMP = InputBox("Digite o Indice do BMP que deseja utilizar", _
            "Impressao de imagem BMP", IndiceBMP)
        If IndiceBMP = "" Then
            Exit Sub
        End If
    End If
    
    Obs = Replace(Obs, "|", vbCrLf)
    Call ACBrECF.FechaNaoFiscal(Obs)
    Call AdicionarResposta("Fecha Não Fiscal: " & vbCrLf & Obs)
    Call AtualizarMemos
End Sub

Private Sub mniFechaRelatorioVinculado_Click()
    Call ACBrECF.FechaRelatorio
End Sub

Private Sub mniGavetaAberta_Click()
    Call AdicionarRespostaBoolean(ACBrECF.GavetaAberta, "Gaveta Aberta")
    Call AtualizarMemos
End Sub

Private Sub mniGrandeTotal_Click()
    Call AdicionarResposta("GrandeTotal: (" & ACBrECF.grandeTotal & ")")
    Call AtualizarMemos
End Sub

Private Sub mniHorarioVerao_Click()
    Call AdicionarRespostaBoolean(ACBrECF.HorarioVerao, "Horário de Verão")
    AtualizarMemos
End Sub

Private Sub mniIdentificaConsumidor_Click()
Dim CPF, Nome, Endereco As String
  
  CPF = ACBrECF.Consumidor.Documento
  Nome = ACBrECF.Consumidor.Nome
  Endereco = ACBrECF.Consumidor.Endereco

  CPF = InputBox("Informe o Documento", "Identifica Consumidor", CPF)
  Nome = InputBox("Informe o Nome do Consumidor", _
    "Identifica Consumidor", Nome)
  Endereco = InputBox("Se necessários, informe o Endereço do Consumidor", _
    "Identifica Consumidor", Endereco)

  Call ACBrECF.IdentificaConsumidor(CPF, Nome, Endereco)
End Sub

Private Sub mniIE_Click()
    Call AdicionarResposta("IE: (" & ACBrECF.IE & ")")
    Call AtualizarMemos
End Sub

Private Sub mniImpactoAgulhas_Click()
    'PENDENTE
    'Call ACBrECF.ImpactoAgulhas(2)
    'Call AdicionarResposta("ImpactoAgulhas")
    'Call AtualizarMemos
End Sub

Private Sub mniImprimeCheque_Click()
Dim Valor As String
Dim Banco, Favorecido, Cidade As String
  
    Valor = "10,00"
    Banco = "001"
    Favorecido = "Projeto ACBr"
    Cidade = "Sao Paulo"
    
    Valor = InputBox("Entre com o valor do Cheque:", _
        "Impressão de Cheque", Valor)
    If Valor = "" Then
        Exit Sub
    End If
    
    If Valor = "" Or Val(Valor) = 0 Then
        Exit Sub
    End If
    
    Banco = InputBox("Entre com o Numero do Banco", _
        "Impressão de Cheque", Banco)
    If Banco = "" Then
        Exit Sub
    End If
    
    Favorecido = InputBox("Entre com o Favorecido", _
        "Impressão de Cheque", Favorecido)
    If Favorecido = "" Then
        Exit Sub
    End If
    
    Cidade = InputBox("Entre com a Cidade", "Impressão de Cheque", Cidade)
    If Cidade = "" Then
        Exit Sub
    End If
    
    Do While Not ACBrECF.ChequePronto
        If (MsgBox("Favor inserir o cheque e pressionar OK", _
            vbYesNoCancel + vbQuestion) = vbCancel) Then
            Exit Sub
        End If
    Loop
    
    Call ACBrECF.ImprimeCheque(Banco, Valor, Favorecido, Cidade, Now, _
        "TSESTE DE IMPRESSAO DE CHEQUE")
    
    Call AdicionarResposta("ImprimeCheque Banco:" & Banco & _
        " Valor:" & Valor & _
        " Favorecido:" & Favorecido & _
        " Cidade:" & Cidade & _
        " Data:" & Format$(Now, "dd/mm/yy"))
    Call AtualizarMemos
End Sub

Private Sub mniImprimeLinhaCupomVinculado_Click()
Dim Linha  As String

    Linha = InputBox("", "Digite a linha a imprimir")
    If Linha = "" Then
        Exit Sub
    End If
        
    Call ACBrECF.LinhaCupomVinculado(Linha)
End Sub

Private Sub mniImprimeLinhaRelatorio_Click()
Dim Linha As String
    
    Linha = InputBox("Digite a linha a imprimir", "Inpressão de Linha NÃO Fiscal")
    If Linha = "" Then
        Exit Sub
    End If
    Call ACBrECF.LinhaRelatorioGerencial(Linha, 1)
End Sub

Private Sub mniImprimeNReduçaoZ_Click()
Dim ReducaoInicial, ReducaoFinal As String

    ReducaoInicial = "0"
    ReducaoFinal = "0"
    
    ReducaoInicial = InputBox("Entre com o a Reduçao Z Inicial:", _
        "Impressão da Memoria Fiscal", ReducaoInicial)
        
    If ReducaoInicial = "" Or Val(ReducaoInicial) < 0 Then
        Exit Sub
    End If
    
    ReducaoFinal = InputBox("Entre com o a Reduçao Z Final:", _
        "Impressão da Memoria Fiscal", ReducaoFinal)
        
    If ReducaoFinal = "" Or Val(ReducaoFinal) < 0 Then
        Exit Sub
    End If
    
    Call ACBrECF.LeituraMemoriaFiscalPorCRZ(ReducaoInicial, ReducaoFinal, False)
    Call AdicionarResposta("Leitura da Memoria Fiscal por Reduçao")
    Call AtualizarMemos
End Sub

Private Sub mniImprimePeriodo_Click()
Dim DataInicial, DataFinal As String

    DataInicial = "01/" & Format$(Now, "mm/yy")
    DataFinal = Format$(Now, "dd/mm/yy")
    
    DataInicial = InputBox("Entre com o a Data Inicial (DD/MM/AA):", _
        "Captura da Memoria Fiscal", DataInicial)
    
    If DataInicial = "" Then
        Exit Sub
    End If
    
    DataFinal = InputBox("Entre com o a Data Final (DD/MM/AA):", _
        "Captura da Memoria Fiscal", DataFinal)
        
    If DataFinal = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.LeituraMemoriaFiscalPorData(DataInicial, DataFinal, False)
    Call AdicionarResposta("Leitura da Memoria Fiscal por Data")
    Call AtualizarMemos
End Sub

Private Sub mniLeituraX_Click()
    Call ACBrECF.LeituraX
    Call AdicionarResposta("Leitura X")
    Call AtualizarMemos
End Sub

Private Sub mniLerTodasVariaveis_Click()
    Call mniDataHora_Click
    Call mniNumECF_Click
    Call mniNumLoja_Click
    Call mniNumSerie_Click
    Call mniNumVersao_Click
    Call mniNumCRO_Click
    Call mniNumeroCupom_Click
    Call mniSubTotal_Click
    Call mniTotalPago_Click
    
    Call mniPoucoPapel_Click
    Call mniHorarioVerao_Click
    Call mniArredonda_Click
    
    Call mniCarregaAliquotasICMS_Click
    Call mniCarregaFormasPagamento_Click
    Call mniCarregaComprovantesNaoFiscais_Click
    Call mniCarregaUnidadesMedida_Click
End Sub

Private Sub mniLerTotaisAliquotas_Click()
    Call LerTotaisAliquotas
End Sub

Private Sub mniLerTotaisComprovanteNaoFiscal_Click()
Dim comprovante As Variant
    
    Call ACBrECF.LerTotaisComprovanteNaoFiscal
    
    For Each comprovante In ACBrECF.ComprovantesNaoFiscais
        Call AdicionarResposta("CNF: " & comprovante.Indice & " - " & _
            comprovante.Descricao & vbCrLf & _
            " CON (" & comprovante.Contador & ") -> " & _
            Format(comprovante.Total, "#0.00") & vbCrLf & _
            "*****")
    Next
    
    Call AtualizarMemos
    
End Sub

Private Sub mniLerTotaisFormaPagamento_Click()
Dim forma As Variant

    Call ACBrECF.LerTotaisFormaPagamento
    
    For Each forma In ACBrECF.FormasPagamento
        Call AdicionarResposta("Forma Pagto: " & forma.Indice & " - " & _
           forma.Descricao & " -> " & _
           Format(forma.Total, "#0.00") & vbCrLf & _
           "*****")
    Next
    
    Call AtualizarMemos
End Sub

Private Sub mniLerTroco_Click()
    Call AdicionarResposta("Total do Troco: " & Format(ACBrECF.TotalTroco, "#0.00"))
    Call AtualizarMemos
End Sub

Private Sub mniModelo_Click()
    Call AdicionarResposta("Modelo: (" & ACBrECF.ModeloStr & ")")
    Call AtualizarMemos
End Sub

Private Sub mniModeloStr_Click()
    Call AdicionarResposta("ModeloStr: (" & ACBrECF.ModeloStr & ")")
    Call AtualizarMemos
End Sub

Private Sub mniMudaArredondamento_Click()

Dim Resp As VbMsgBoxResult
    Resp = MsgBox("Arredondar ?", vbQuestion + vbYesNoCancel)
    If Resp <> vbCancel Then
        Call ACBrECF.MudaArredondamento(Resp = vbYes)
        Call AdicionarResposta("MudaArredondamento")
        Call AtualizarMemos
    End If
End Sub

Private Sub mniMudaHorarioVerao_Click()
Dim EhHorarioVerao As Boolean
    EhHorarioVerao = MsgBox("Mudar para horário de verão?", vbQuestion + vbYesNo) = vbYes
    Call ACBrECF.MudaHorarioVerao
    Call AdicionarResposta("MudaHorarioVerao")
    Call AtualizarMemos
End Sub

Private Sub mniNãoFiscalCompleto_Click()
Dim Valor, CodCNF, CodFPG As String

    CodCNF = "01"
    CodFPG = "01"
    Valor = "0"
    
    CodCNF = InputBox("Entre com o indice do Comprovante Não Fiscal", _
        "Comprovante Não Fiscal Completo", CodCNF)
    If CodCNF = "" Then
        Exit Sub
    End If
    
    Valor = InputBox("Entre com o Valor do Comprovante Não Fiscal", _
        "Comprovante Não Fiscal Completo", Valor)
    If Valor = "" Then
        Exit Sub
    End If
    
    CodFPG = InputBox("Entre com o indice da Forma de Pagamento", _
        "Comprovante Não Fiscal Completo", CodFPG)
    If CodFPG = "" Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.NaoFiscalCompleto(CodCNF, Valor, CodFPG, "TESTE DE COMPROVANTE NAO FISCAL")
    Call AdicionarResposta("Nao Fiscal Completo: " & CodCNF & " " & Valor & " " & CodFPG)
    Call AtualizarMemos
End Sub

Private Sub mniNumCCF_Click()
    Call AdicionarResposta("Nº CCF: (" & ACBrECF.NumCCF & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumCOO_Click()
    Call AdicionarResposta("Nº Ultimo Cupom: " & ACBrECF.NumCupom)
    Call AtualizarMemos
End Sub

Private Sub mniNumCOOInicial_Click()
    Call AdicionarResposta("Nº NumCOOInicial: (" & ACBrECF.NumCOOInicial & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumCRO_Click()
    Call AdicionarResposta("Nº CRO: (" & ACBrECF.NumCRO & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumCRZ_Click()
    Call AdicionarResposta("Nº CRZ: (" & ACBrECF.NumCRZ & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumECF_Click()
    Call AdicionarResposta("Nº ECF: (" & ACBrECF.NumECF & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumeroCupom_Click()
    Call AdicionarResposta("Nº Ultimo Cupom: " & ACBrECF.NumCupom)
    Call AtualizarMemos
End Sub

Private Sub mniNumGNF_Click()
    Call AdicionarResposta("Nº GNF: (" & ACBrECF.NumGNF & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumLoja_Click()
    Call AdicionarResposta("Nº Loja: (" & ACBrECF.NumLoja & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumSerie_Click()
    Call AdicionarResposta("Nº Série: (" & ACBrECF.numSerie & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumSerieMFD_Click()
    Call AdicionarResposta("Nº Série MFD: (" & ACBrECF.NumSerieMFD & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumUltimoItem_Click()
    Call AdicionarResposta("Nº Ultimo Item: (" & ACBrECF.NumUltItem & ")")
    Call AtualizarMemos
End Sub

Private Sub mniNumVersao_Click()
    Call AdicionarResposta("Nº Versão: " & ACBrECF.NumVersao)
    Call AtualizarMemos
End Sub

Private Sub mniParametroDescontoISSQN_Click()
    Call AdicionarRespostaBoolean(ACBrECF.ParamDescontoISSQN, "Parametro Desconto ISSQN")
    AtualizarMemos
End Sub

Private Sub mniPorCOO_Click()
Dim Linhas As Variant
Dim COO As String
Dim i As Integer
    
    COO = "0"
    COO = InputBox("Entre com o COO que deseja capturar:", _
        "Captura da MFD", COO)
    
    If COO = "" Or Val(COO) < 0 Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.LeituraMemoriaFiscalSerialPorCRZ(COO, COO, Linhas, docTodos)
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
    
    Call AtualizarMemos
End Sub

Private Sub mniPorDataMovimento_Click()
Dim Linhas As Variant
Dim Data  As String
Dim i As Integer

    Data = Format$(Now, "dd/mm/yy")
    
    Data = InputBox("Entre com o a Data do Movimento (DD/MM/AA):", _
        "Captura da MFD", Data)
    If Data = "" Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.LeituraMFDSerialPorData(Data, Data, Linhas, docTodos)
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
    
    Call AtualizarMemos
End Sub

Private Sub mniPorIntervaloCOO_Click()
Dim Linhas As Variant
Dim COOInicial, COOFinal As String
Dim i As Integer

    COOInicial = "0"
    COOFinal = "0"
    
    COOInicial = InputBox("Entre com o COO Inicial:", _
        "Captura da MFD", COOInicial)
        
    If COOInicial = "" Then
        Exit Sub
    End If
    
    If COOInicial = "" Or Val(COOInicial) < 0 Then
        Exit Sub
    End If
    
    COOFinal = InputBox("Entre com o COO Final:", _
        "Captura da MFD", COOFinal)
    
    If COOFinal = "" Or Val(COOFinal) < 0 Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.LeituraMFDSerialPorCOO(COOInicial, COOFinal, Linhas, docTodos)
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
    
    Call AtualizarMemos
End Sub

Private Sub mniPorIntervaloPeriodo_Click()
Dim Linhas As Variant
Dim DataInicial, DataFinal As String
Dim i As Integer
    
    DataInicial = "01/" & Format$(Now, "mm/yy")
    DataFinal = Format$(Now, "dd/mm/yy")
    
    DataInicial = InputBox("Entre com o a Data Inicial (DD/MM/AA):", _
        "Captura da MFD", DataInicial)
    If DataInicial = "" Then
        Exit Sub
    End If
    
    DataFinal = InputBox("Entre com o a Data Final (DD/MM/AA):", _
        "Captura da MFD", DataFinal)
    If DataFinal = "" Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.LeituraMFDSerialPorData(DataInicial, DataFinal, Linhas, docTodos)
    
    For i = LBound(Linhas) To UBound(Linhas)
        AdicionarResposta (Linhas(i))
    Next i
    
    Call AtualizarMemos
End Sub

Private Sub mniPoucoPapel_Click()
    Call AdicionarRespostaBoolean(ACBrECF.PoucoPapel, "Pouco Papel")
    AtualizarMemos
End Sub

Private Sub mniProgramaAliquota_Click()
Dim Aliquota As String
Dim tipo As String
Dim Resp As VbMsgBoxResult
  
    Aliquota = "18,00"
    
    Aliquota = InputBox("Entre com o valor da Aliquota:", _
        "Programaçao de Aliquotas", Aliquota)
    If Aliquota = "" Or Val(Aliquota) = 0 Then
        Exit Sub
    End If
    
    Resp = MsgBox("Aliquota do ICMS ?" & vbCrLf & _
        "SIM = ICMS, NAO = ISS", vbYesNoCancel + vbQuestion)
        
    If Resp = vbCancel Then
        Exit Sub
    ElseIf Resp = vbYes Then
        tipo = "T"
    Else
        tipo = "S"
    End If
    
    If MsgBox("A aliquota: [" & Aliquota & "] do Tipo: [" & tipo & _
        "] será programada." & vbCrLf & vbCrLf & _
        "ANTEÇÃO!!! A programação de Aliquotas é irreversivel" & vbCrLf & _
        "Confirma a operação ?", vbYesNoCancel + vbQuestion) <> vbYes Then
        Exit Sub
    End If
    
    Call ACBrECF.ProgramaAliquota(Aliquota, tipo, "")
    Call mniCarregaAliquotasICMS_Click
End Sub

Private Sub mniProgramaComprovanteNaoFiscal_Click()
Dim Descricao As String
Dim tipo As String

    Descricao = "Cartao"
    tipo = ""
    
    Descricao = InputBox("Programaçao de Comprovantes NAO Fiscais (CNF)", _
        "Entre com a Descriçao:", Descricao)
    If Descricao = "" Then
        Exit Sub
    End If
    
    If ACBrECF.Modelo = ModeloECF_Schalter Then
        tipo = InputBox("Entre com a String do parametro 'Tipo'." & vbCrLf & _
            "D - Permite Desconto e Item " & vbCrLf & _
            "A - Permite Acrescimo no Subtotal" & vbCrLf & _
            "C - Permite Cancelamento de Item" & vbCrLf & _
            "P - Obriga forma de Pagamento" & vbCrLf & vbCrLf & _
            "Vnn - Obriga emissao de vinculado na Forma de " & _
            "Pagamento nn" & vbCrLf & vbCrLf & _
            "Se vazio assume Default = 'DAC'" & vbCrLf & _
            "Exemplos:  V04 -> Torna a Emissao do Cupom Fiscal " & _
            "Vinculado obrigatória para a Forma de Pagamento 04", _
            "Comprovantes NAO Fiscal " & ACBrECF.ModeloStr, tipo)
    
    ElseIf ACBrECF.Modelo = ModeloECF_Daruma Then
        tipo = InputBox("Entre com a String do parametro 'Tipo'." & vbCrLf & _
            "V  Comprovante Vinculado" & vbCrLf & _
            "+  Entrada de Recursos" & vbCrLf & _
            "-  Saida de Recursos" & vbCrLf & vbCrLf & _
            "Se vazio assume Default = 'V'" & vbCrLf & _
            "Informe Apenas uma das Opçoes", _
            "Comprovantes NAO Fiscal " & ACBrECF.ModeloStr, tipo)
    
    ElseIf ACBrECF.Modelo = ModeloECF_Sweda Or ACBrECF.Modelo = ModeloECF_Quattro Then
        tipo = InputBox("Entre com a String do parametro 'Tipo'." & vbCrLf & _
            "&  Criaçao de um novo Grupo (Titulo)" & vbCrLf & _
            "+  Entrada de Recursos" & vbCrLf & _
            "-  Saida de Recursos" & vbCrLf & vbCrLf & _
            "Se vazio assume Default = '+'" & vbCrLf & _
            "Informe Apenas uma das Opçoes", _
            "Comprovantes NAO Fiscal " & ACBrECF.ModeloStr, tipo)
    
    ElseIf ACBrECF.Modelo = ModeloECF_FiscNET Or ACBrECF.Modelo = ModeloECF_ICash Then
        tipo = InputBox("Entre com a String do parametro 'Tipo'." & vbCrLf & _
            "+  Entrada de Recursos" & vbCrLf & _
            "-  Saida de Recursos" & vbCrLf & vbCrLf & _
            "Se vazio assume Default = " + "" & vbCrLf & _
            "Informe Apenas uma das Opçoes", tipo)
        If tipo = "" Then
            Exit Sub
        End If
    End If
    
    If tipo = "" Then
        Exit Sub
    End If
    
    If MsgBox("O Comprovante Nao Fiscal: [" & Descricao & "] " & _
        IIf(ACBrECF.Modelo = ModeloECF_Daruma Or ACBrECF.Modelo = ModeloECF_Schalter Or _
            ACBrECF.Modelo = ModeloECF_Sweda Or ACBrECF.Modelo = ModeloECF_Quattro Or _
            ACBrECF.Modelo = ModeloECF_FiscNET, " do Tipo: [" + tipo + "] ", "") & _
        "será programado." & vbCrLf & vbCrLf & _
        "Cuidado !! A programação de CNFs é irreversivel" & vbCrLf & _
        "Confirma a operação ?", vbYesNoCancel + vbQuestion, 0) <> vbYes Then
        Exit Sub
    End If
    
    Call ACBrECF.ProgramaComprovanteNaoFiscal(Descricao, tipo, "")
    Call mniCarregaComprovantesNaoFiscais_Click
End Sub

Private Sub mniProgramaFormaPagamento_Click()
Dim Descricao As String
Dim Vinculado  As Boolean
Dim Resp As VbMsgBoxResult
  
    Descricao = "Cartao"
    Vinculado = True
    
    Descricao = InputBox("Entre com a Descriçao:", _
        "Programaçao de Formas de Pagamento (FPG)", Descricao)
    If Descricao = "" Then
        Exit Sub
    End If
    
    If ACBrECF.Modelo <> ModeloECF_Bematech And ACBrECF.Modelo <> ModeloECF_NaoFiscal And ACBrECF.Modelo <> ModeloECF_Mecaf Then
        Resp = MsgBox("Permite Vinculado nessa Forma de Pagamento ?", vbYesNoCancel + vbQuestion)
        If Resp = vbCancel Then
            Exit Sub
        Else
            Vinculado = (Resp = vbYes)
        End If
    End If
    
    If MsgBox("A Forma de Pagamento: [" & Descricao & "] " & _
        "será programada." & vbCrLf & vbCrLf & _
        "ATENÇÃO!!! A programação de Formas de Pagamento é irreversivel" & vbCrLf & _
        "Confirma a operação ?", vbYesNoCancel + vbQuestion) <> vbYes Then
        Exit Sub
    End If
    
    Call ACBrECF.ProgramaFormaPagamento(Descricao, Vinculado, "")
    Call mniCarregaFormasPagamento_Click
End Sub

Private Sub mniProgramaRelatorioGerencial_Click()
Dim Descricao As String

    Descricao = InputBox("Entre com a Descrição do Relatório Gerencial:", _
        "Programaçao de Relatórios Gerenciais", Descricao)
    If Descricao = "" Then
        Exit Sub
    End If
    
    If MsgBox("O Relatório: [" & Descricao & "] será programado." & vbCrLf & vbCrLf & _
        "Cuidado a programação de Relatórios Gerenciais é irreversivel" & vbCrLf & _
        "Confirma a operação?", vbYesNoCancel + vbQuestion) <> vbYes Then
        Exit Sub
    End If
    Call ACBrECF.ProgramaRelatoriosGerenciais(Descricao, "")
    Call mniCarregaRelatoriosGerenciais_Click
End Sub

Private Sub mniProgramaUnidadeMedida_Click()
Dim um As String

    um = InputBox("Entre com a Descrição da Unidade de Medida:", _
        "Programaçao de Unidades de Medida", um)
    If um = "" Then
        Exit Sub
    End If
    
    If MsgBox("A Unidade de Medida: [" & um & "] será programada." & vbCrLf & vbCrLf & _
        "Cuidado a programação de Unidades de Medida é irreversivel" & vbCrLf & _
        "Confirma a operação ?", vbQuestion + vbYesNoCancel) <> vbYes Then
        Exit Sub
    End If
    
    'PENDENTE
    'Call ACBrECF.ProgramaUnidadeMedida(um)
End Sub

Private Sub mniPularLinhas_Click()
Dim Linhas As String

    Linhas = ACBrECF.LinhasEntreCupons
    Linhas = InputBox("Digite o Numero de Linhas a Pular", "Pular Linhas", Linhas)
    If Linhas = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.PulaLinhas(Val(Linhas))
End Sub

Private Sub mniReducaoZ_Click()
Dim Resp As VbMsgBoxResult

    If ACBrECF.Estado <> EstadoECF_RequerZ Then
        If MsgBox("A Redução Z pode Bloquear o seu ECF até a 12:00pm" & vbCrLf & _
            "Continua assim mesmo ?", vbYesNoCancel + vbQuestion) <> vbYes Then
            Exit Sub
        End If
        
        If MsgBox("Você tem certeza ?", vbYesNoCancel + vbQuestion) <> vbYes Then
            Exit Sub
        End If
    End If
    
    Resp = MsgBox("Envia hora atual ?", vbYesNoCancel + vbQuestion)
    
    If Resp = vbYes Then
        ACBrECF.reducaoZ (Now)
    ElseIf Resp = vbNo Then
        ACBrECF.reducaoZ
    Else
        Exit Sub
    End If
    
    Call AdicionarResposta("Reduçao Z")
    Call AtualizarMemos
End Sub

Private Sub mniRegistraItemNaoFiscal_Click()
Dim Valor, CodCNF As String

    CodCNF = "01"
    Valor = "0"
    
    CodCNF = InputBox("Entre com o indice do Comprovante Não Fiscal", _
        "Registra Item Não Fiscal", CodCNF)
    If CodCNF = "" Then
        Exit Sub
    End If
    
    Valor = InputBox("Entre com o Valor do Comprovante Não Fiscal", _
        "Registra Item Não Fiscal", Valor)
    If Valor = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.RegistraItemNaoFiscal(CodCNF, Valor, _
        "TESTE DE COMPROVANTE NAO FISCAL")
    Call AdicionarResposta("Registra Item Nao Fiscal: " & CodCNF & " " & Valor)
    Call AtualizarMemos
End Sub

Private Sub mniRelatorioGerencialCompleto_Click()
    RelatorioFrm.TipoRelatorio = "G"
    RelatorioFrm.Show vbModal
End Sub

Private Sub mniSair_Click()
    Unload Me
End Sub

Private Sub mniSangria_Click()
Dim CNF, FPG, Valor As String

    CNF = "SANGRIA"
    FPG = "DINHEIRO"
    Valor = "0,00"
    
    Valor = InputBox("Entre com o Valor da Sangria", _
        "Sangria", Valor)
    If Valor = "" Or Val(Valor) <= 0 Then
        Exit Sub
    End If
    
    CNF = InputBox("Entre com a Descrição do Comprovante Não Fiscal", _
        "Sangria", CNF)
    If CNF = "" Then
        Exit Sub
    End If
    
    FPG = InputBox("Entre com a Descrição da Forma de Pagamento", _
        "Sangria", FPG)
    If FPG = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.Sangria(Valor, "TESTE DE SANGRIA") 'PENDENTE ', CNF, FPG)
    
    Call AdicionarResposta("Sangria: " & Valor & " " & CNF & " " & FPG)
    Call AtualizarMemos
End Sub


Private Sub mniSobreACBr_Click()
MsgBox ACBrECF.About
End Sub

Private Sub mniSubTotal_Click()
    Call AdicionarResposta("SubTotal: " & Format(ACBrECF.SubTotal, "#0.00"))
    Call AtualizarMemos
End Sub

Private Sub mniSubTotalizaCupom_Click()
Dim Desc, Obs As String

    Desc = "0"
    Obs = ""

    If ACBrECF.Modelo = ModeloECF_DataRegis Then
        Obs = InputBox("Se necessário, digite alguma Observaçao (até 8 linhas)" & vbCrLf & _
            "O sinal | (pipe) será convertido para #10 (quebra de linha)" & vbCrLf & _
            "A Observação também pode ser enviada no metodo FechaCupom", _
            "Subtotaliza Cupom", Obs)
    End If

    Desc = InputBox("Digite valor negativo para Desconto" & vbCrLf & _
        "ou Valor Positivo para Acrescimo", "Subtotaliza Cupom", Desc)
    If Desc <> "" Then
        Call ACBrECF.SubtotalizaCupom(Desc, Obs)
        Call AdicionarResposta("Subtotaliza Cupom: " & Desc)
        Call AtualizarMemos
    End If
End Sub

Private Sub mniSubTotalizaNaoFiscal_Click()
Dim Desc As String

    Desc = "0"
    
    Desc = InputBox("Digite Valor negativo para Desconto" & vbCrLf & _
        "ou Valor Positivo para Acrescimo", "Subtotaliza Não Fiscal", Desc)
        
    If Desc = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.SubtotalizaNaoFiscal(Desc, "")
    Call AdicionarResposta("Subtotaliza Não Fiscal " & Desc)
    Call AtualizarMemos
End Sub

Private Sub mniSuprimento_Click()
Dim CNF, FPG, cValor As String
Dim Valor As Double

    CNF = "SUPRIMENTO"
    FPG = "DINHEIRO"
    cValor = "0"

    cValor = InputBox("Entre com o Valor do Suprimento", _
        "Suprimento", cValor)
    If cValor = "" Or Val(cValor) <= 0 Then
        Exit Sub
    End If
    
    CNF = InputBox("Entre com a Descrição do Comprovante Não Fiscal", _
        "Suprimento", CNF)
    If CNF = "" Then
        Exit Sub
    End If
    
    FPG = InputBox("Entre com a Descrição da Forrma de Pagamento", _
        "Suprimento", FPG)
    If FPG = "" Then
        Exit Sub
    End If
    
    Call ACBrECF.Suprimento(Valor, "TESTE DE SUPRIMENTO") 'PENDENTE ', CNF, FPG)
    
    Call AdicionarResposta("Suprimento: " & Format(Valor, "#0.00") & " " & CNF & " " & FPG)
    Call AtualizarMemos
End Sub

Private Sub mniTestaPodeAbrirCupom_Click()
Dim Est As String

    Est = Estados(ACBrECF.Estado)

    On Error GoTo Err
    ACBrECF.TestaPodeAbrirCupom
    AdicionarResposta ("Pode Abrir Cupom.. OK")
    
    If False Then
Err:
    AdicionarResposta (Err.Description)
    End If
    
    Call AtualizarMemos
End Sub

Private Sub mniTestar_Click()
'PENDENTE
'    Call ACBrECF.TestarDialog
'    Call AtualizarMemos
End Sub

Private Sub mniTesteVelocidade_Click()
Dim Itens, Cupons As String
Dim i, j As Integer
Dim Inicio, Fim As Date
Dim Resp As VbMsgBoxResult
Dim SubTot, Desc As Double
Dim fp() As FormaPagamento

    Call ACBrECF.CarregaFormasPagamento
    If UBound(ACBrECF.FormasPagamento) < 1 Then
        MsgBox "Nenhuma Forma de Pagamento programada no ECF", vbExclamation
        Exit Sub
    End If
    
    fp = ACBrECF.FormasPagamento
    
    Itens = "10"
    Itens = InputBox("Numero de Itens a imprimir:", _
        "Teste de Velocidade", Itens)
    If Itens = "" Or Val(Itens) < 0 Then
        Exit Sub
    End If
    
    Cupons = "1"
    Cupons = InputBox("Numero de Cupons a imprimir:", _
        "Teste de Velocidade", Cupons)
    If Cupons = "" Or Val(Cupons) < 0 Then
        Exit Sub
    End If
    
    Resp = MsgBox("Monitorar estado do ECF ?", vbYesNoCancel + vbQuestion)
    If Resp = vbCancel Then
        Exit Sub
    End If
    
    Call MouseEspera
  
    For j = 1 To Cupons
        Inicio = Now
        Call AdicionarResposta("Imprimindo " & Itens & " itens.")
        Call AdicionarResposta("Iniciando Cupom: " & Inicio)
        Call ACBrECF.AbreCupom("", "", "")
        Call AdicionarResposta("Cupom Aberto: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        If Resp = vbYes Then
            AdicionarResposta ("Estado ECF: " & EstadoECF(ACBrECF.Estado))
        End If
    
        For i = 1 To Itens
            If i = 1 Then
                If Resp = vbYes Then
                    Call AdicionarResposta("Estado ECF: " & EstadoECF(ACBrECF.Estado))
                End If
            End If
                    
            Call ACBrECF.VendeItem(Format("000", i), _
                "DESCRICAO PRODUTO: " & Format("000", i), _
                "NN", 1, i / 100, 0, "UN")
            
            ACBrECF.EmLinha 1
            
            Call AdicionarResposta("Item " & i & ": " & _
                Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
            
            'Semelhante ao "AguardaImpressao = True", porém é mais rápido, pois no
            'método "VerificaFimImpressao" alem de verificado o "EmLinha" também é
            'solicitado o Status do ECF
        Next i
    
        SubTot = ACBrECF.SubTotal
        Desc = 0
        If SubTot >= 1 Then
            Desc = (SubTot - Int(SubTot)) * -1
        End If
        Call ACBrECF.SubtotalizaCupom(Desc, "")
        Call AdicionarResposta("SubTotalizado: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        If Resp = vbYes Then
            AdicionarResposta ("Estado ECF: " & EstadoECF(ACBrECF.Estado))
        End If
        
        'Efetuando ultimo pagamento no Item 0, deve zerar o Saldo a pagar
        Call ACBrECF.EfetuaPagamento(fp(1).Indice, ACBrECF.SubTotal - ACBrECF.TotalPago, "ZERANDO SALDO A PAGAR RESTANTE", False)
        Call AdicionarResposta("Pagamento Efetuado: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        If Resp = vbYes Then
            Call AdicionarResposta("Estado ECF: " & EstadoECF(ACBrECF.Estado))
        End If
        
        Call ACBrECF.FechaCupom("TESTE DE CUPOM")
        Fim = Now
        Call AdicionarResposta("Finalizado em: " & Fim)
        Call AdicionarResposta("Diferença: " & Format(DateDiff("s", Inicio, Fim), "#0.00") & " segundos")
        Call AtualizarMemos
    Next j
    Call MouseNormal
End Sub

Private Sub mniTesteVinculado_Click()
Dim Cupons As String
Dim cFPG As String
Dim COO As String
Dim nCupons As Integer
Dim j As Integer
Dim Inicio As Date
Dim gerencial As Variant
  
    Call ACBrECF.CarregaFormasPagamento
    If UBound(ACBrECF.FormasPagamento) < 1 Then
        MsgBox "Nenhuma Forma de Pagamento programada no ECF", vbExclamation
        Exit Sub
    End If
    
    Cupons = "1"
    Cupons = InputBox("Numero de Cupons a imprimir:", _
        "Teste de Vinculado", Cupons)
    If Cupons = "" Then
        Exit Sub
    End If
    
    cFPG = "02"
    cFPG = InputBox("Forma de Pagamento a utilizar:", _
        "Teste de Vinculado", cFPG)
    If cFPG = "" Then
        Exit Sub
    End If
    
    If ACBrECF.AchaFPGIndice(cFPG) Is Nothing Then
        MsgBox "Forma de pagamento " & cFPG & " não encontrada", vbCritical
        Exit Sub
    End If
    
    nCupons = Val(Cupons)
    If nCupons < 1 Then
        Exit Sub
    End If
    
    For j = 1 To nCupons
        Inicio = Now
        Call AdicionarResposta("Iniciando Cupom: " & nCupons & " - " & Inicio)
        Call ACBrECF.AbreCupom("", "", "")
        
        Call AdicionarResposta("Cupom Aberto: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        Call ACBrECF.VendeItem("7654321", "TESTE DE PRODUTO, CUPOM: " & _
            Format(nCupons, "000"), "NN", 1, 1, 0, "UN")
        
        Call AdicionarResposta("Item Vendido: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        Call ACBrECF.SubtotalizaCupom(0, "")
        Call AdicionarResposta("SubTotalizado: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        'Efetuando pagamento na FPG informada
        Call ACBrECF.EfetuaPagamento(cFPG, 1, "TESTE DE VINCULADO", True)
        Call AdicionarResposta("Pagamento Efetuado: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        Call ACBrECF.FechaCupom("TESTE DE CUPOM VINCULADO")
        Call AdicionarResposta("Finalizado Cupom: " & Format(DateDiff("s", Inicio, Now), "#0.00") & " segundos")
        
        COO = ACBrECF.NumCupom
        'Por algum motivo que desconhecemos, a função split não está permitindo que o programa seja finalizado
        gerencial = Split(RelatorioFrm.txtRelat.Text, vbCrLf)
        
        'PENDENTE
        'Call ACBrECF.CupomVinculado(COO, cFPG, 1, gerencial, 2)
        
        Call AtualizarMemos
    Next j
End Sub

Private Sub mniTotalAcrescimos_Click()
    Call AdicionarResposta("TotalAcrescimos: (" & ACBrECF.TotalAcrescimos & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalCancelamentos_Click()
    Call AdicionarResposta("TotalCancelamentos: (" & ACBrECF.TotalCancelamentos & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalDescontos_Click()
    Call AdicionarResposta("TotalDescontos: (" & ACBrECF.TotalDescontos & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalIsencao_Click()
    Call AdicionarResposta("TotalIsencao: (" & ACBrECF.TotalIsencao & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalIsencaoISSQN_Click()
    Call AdicionarResposta("TotalIsencaoISSQN: (" & ACBrECF.TotalIsencaoISSQN & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalNaoFiscal_Click()
    Call AdicionarResposta("TotalNaoFiscal: (" & ACBrECF.TotalNaoFiscal & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalNaoTributado_Click()
    Call AdicionarResposta("TotalNaoTributado: (" & ACBrECF.TotalNaoTributado & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalNaoTributadoISSQN_Click()
    Call AdicionarResposta("TotalNaoTributadoISSQN: (" & ACBrECF.TotalNaoTributadoISSQN & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalPago_Click()
    Call AdicionarResposta("Total Pago: " & Format(ACBrECF.TotalPago, "#0.00"))
    Call AtualizarMemos
End Sub

Private Sub mniTotalSubstituicaoTributaria_Click()
    Call AdicionarResposta("TotalSubstituicaoTributaria: (" & _
        ACBrECF.TotalSubstituicaoTributaria & ")")
    Call AtualizarMemos
End Sub

Private Sub mniTotalSubstituicaoTributariaISSQN_Click()
    Call AdicionarResposta("TotalSubstituicaoTributariaISSQN: (" & _
        ACBrECF.TotalSubstituicaoTributariaISSQN & ")")
    Call AtualizarMemos
End Sub

Private Sub mniUsuarioAtual_Click()
    Call AdicionarResposta("UsuarioAtual: (" & ACBrECF.UsuarioAtual & ")")
    Call AtualizarMemos
End Sub

Private Sub mniVendaBruta_Click()
    Call AdicionarResposta("VendaBruta: (" & ACBrECF.VendaBruta & ")")
    Call AtualizarMemos
End Sub

Private Sub mniVendeItem_Click()
    VendeItemFrm.Show vbModal
End Sub

Private Sub obTipoCodBarras_Click(Index As Integer)
    If obTipoCodBarras(0).Value Then
        txtCodBarras.Text = "789000000001"
    ElseIf obTipoCodBarras(1).Value Then
        txtCodBarras.Text = "0000000"
    ElseIf obTipoCodBarras(2).Value Then
        txtCodBarras.Text = "123456"
    ElseIf obTipoCodBarras(3).Value Then
        txtCodBarras.Text = "123456"
    ElseIf obTipoCodBarras(4).Value Then
        txtCodBarras.Text = "abcABC123"
    ElseIf obTipoCodBarras(5).Value Then
        txtCodBarras.Text = "ABC123"
    ElseIf obTipoCodBarras(6).Value Then
        txtCodBarras.Text = "ABC123"
    ElseIf obTipoCodBarras(7).Value Then
        txtCodBarras.Text = "00000000000"
    ElseIf obTipoCodBarras(8).Value Then
        txtCodBarras.Text = "123456"
    ElseIf obTipoCodBarras(9).Value Then
        txtCodBarras.Text = "123456"
    ElseIf obTipoCodBarras(10).Value Then
        txtCodBarras.Text = "123456"
    End If
End Sub

Private Sub txtArqLog_Change()
    ACBrECF.ArqLOG = txtArqLog.Text
End Sub

Private Sub txtArqLog_LostFocus()
    ACBrECF.ArqLOG = txtArqLog.Text
End Sub

Private Sub txtDadosSW_LostFocus(Index As Integer)
'PENDENTE
'    ACBrRFD.SH_RazaoSocial = txtDadosSW(0).Text
'    ACBrRFD.SH_COO = txtDadosSW(1).Text
'    ACBrRFD.SH_CNPJ = txtDadosSW(2).Text
'    ACBrRFD.SH_IE = txtDadosSW(3).Text
'    ACBrRFD.SH_IM = txtDadosSW(4).Text
'    ACBrRFD.SH_NomeAplicativo = txtDadosSW(5).Text
'    ACBrRFD.SH_NumeroAplicativo = txtDadosSW(6).Text
'    ACBrRFD.SH_VersaoAplicativo = txtDadosSW(7).Text
'    ACBrRFD.SH_Linha1 = txtDadosSW(8).Text
'    ACBrRFD.SH_Linha2 = txtDadosSW(9).Text
End Sub

Private Sub txtDirRFD_Change()
'PENDENTE
'    ACBrRFD.DirRFD = txtDirRFD.Text
End Sub

Private Sub txtDirRFD_LostFocus()
'PENDENTE
'    ACBrRFD.DirRFD = txtDirRFD.Text
End Sub

Private Sub txtMensagemAguarde_Change()
'PENDENTE
'    ACBrECF.MsgAguarde = txtMensagemAguarde.Text
End Sub

Private Sub txtMensagemAguarde_LostFocus()
'PENDENTE
'    ACBrECF.MsgAguarde = txtMensagemAguarde.Text
End Sub

Private Sub txtMensagemTrabalho_Change()
'PENDENTE
'    ACBrECF.MsgTrabalhando = txtMensagemTrabalho.Text
End Sub

Private Sub txtMensagemTrabalho_LostFocus()
'PENDENTE
'    ACBrECF.MsgTrabalhando = txtMensagemTrabalho.Text
End Sub

Private Sub txtOperador_Change()
    ACBrECF.Operador = txtOperador.Text
End Sub

Private Sub txtOperador_LostFocus()
    ACBrECF.Operador = txtOperador.Text
End Sub

Public Sub AdicionarResposta(Resposta As String)
    txtResp.Text = txtResp.Text & vbCrLf & Resposta
    txtResp.SelStart = Len(txtResp.Text)
End Sub

Public Sub AdicionarDadosRZ(Dados As String)
    txtDadosRZ.Text = txtDadosRZ.Text & vbCrLf & Dados
    txtDadosRZ.SelStart = Len(txtDadosRZ.Text)
End Sub

Public Sub AdicionarRespostaBoolean(teste As Boolean, Resposta As String)
    If teste Then
        AdicionarResposta (Resposta & ": SIM")
    Else
        AdicionarResposta (Resposta & ": NÃO")
    End If
End Sub

Private Sub CarregarAliquotasECF()
    Dim Aliquota As Variant
    
    Call ACBrECF.CarregaAliquotas
    
    For Each Aliquota In ACBrECF.Aliquotas
        Call AdicionarResposta("Aliquota: " & Aliquota.Sequencia & vbCrLf & _
            "Indice: " & Aliquota.Indice & " -> " & Aliquota.Total & vbCrLf & _
            "Tipo: " & Aliquota.tipo & vbCrLf & _
            "*****")
    Next
    
    Call AtualizarMemos
End Sub

Private Sub LerTotaisAliquotas()
    Dim Aliquota As Variant
    
    Call ACBrECF.CarregaAliquotas
    
    For Each Aliquota In ACBrECF.Aliquotas
        Call AdicionarResposta("Aliquota: " & Aliquota.Sequencia & vbCrLf & _
            "Indice: " & Aliquota.Indice & " -> " & Aliquota.Total & vbCrLf & _
            "Tipo: " & Aliquota.tipo & vbCrLf & _
            "Total: " & Format(Aliquota.Total, "#0.00") & vbCrLf & _
            "*****")
    Next
    
    Call AtualizarMemos
End Sub

Private Sub ArrayToStr(a As Variant, ByRef s As String)
    Dim i As Integer
    s = ""
    For i = LBound(a) To UBound(a)
        s = s & a(i) & vbCrLf
    Next i
End Sub
