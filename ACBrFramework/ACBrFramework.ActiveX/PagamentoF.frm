VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form PagamentoFrm 
   Caption         =   "Efetuar Pagamento"
   ClientHeight    =   4935
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   6960
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
   ScaleHeight     =   4935
   ScaleWidth      =   6960
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnFechar 
      Caption         =   "&Fechar"
      Height          =   375
      Left            =   5520
      TabIndex        =   31
      Top             =   4440
      Width           =   1335
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   4215
      Left            =   120
      TabIndex        =   7
      Top             =   120
      Width           =   6735
      _ExtentX        =   11880
      _ExtentY        =   7435
      _Version        =   393216
      Style           =   1
      Tabs            =   2
      TabsPerRow      =   2
      TabHeight       =   520
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Verdana"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TabCaption(0)   =   "Pagamento"
      TabPicture(0)   =   "PagamentoF.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label1(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label6"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label2"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "Label3"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label4"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Label5"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "lblTotalCupom"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "lblTotalPago"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "txtCod"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "txtValor"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "txtObs"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "Command1"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "chkVinc"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "btnImprimir"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "lstFormas"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).ControlCount=   16
      TabCaption(1)   =   "Estorno"
      TabPicture(1)   =   "PagamentoF.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "txtMsgPromocional"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "chkVincNovo"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "chkVincCancelado"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "lstFormasEst"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "btnEstornar"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "txtValorEstorno"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "txtTipoNovo"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "txtTipoCanc"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "Label10"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).Control(9)=   "Label9"
      Tab(1).Control(9).Enabled=   0   'False
      Tab(1).Control(10)=   "Label8"
      Tab(1).Control(10).Enabled=   0   'False
      Tab(1).Control(11)=   "Label7"
      Tab(1).Control(11).Enabled=   0   'False
      Tab(1).Control(12)=   "Label1(3)"
      Tab(1).Control(12).Enabled=   0   'False
      Tab(1).Control(13)=   "Label1(2)"
      Tab(1).Control(13).Enabled=   0   'False
      Tab(1).ControlCount=   14
      Begin VB.TextBox txtMsgPromocional 
         Height          =   285
         Left            =   -73680
         TabIndex        =   23
         Top             =   3000
         Width           =   5175
      End
      Begin VB.CheckBox chkVincNovo 
         Caption         =   "Cupom Vinculado"
         Height          =   255
         Left            =   -73680
         TabIndex        =   21
         Top             =   2160
         Width           =   1815
      End
      Begin VB.CheckBox chkVincCancelado 
         Caption         =   "Cupom Vinculado"
         Height          =   255
         Left            =   -73680
         TabIndex        =   19
         Top             =   1440
         Width           =   1815
      End
      Begin VB.ListBox lstFormasEst 
         Height          =   1620
         ItemData        =   "PagamentoF.frx":0038
         Left            =   -71520
         List            =   "PagamentoF.frx":003A
         TabIndex        =   25
         Top             =   1080
         Width           =   3015
      End
      Begin VB.CommandButton btnEstornar 
         Caption         =   "Estornar"
         Height          =   375
         Left            =   -73680
         TabIndex        =   24
         Top             =   3480
         Width           =   1695
      End
      Begin VB.TextBox txtValorEstorno 
         Height          =   285
         Left            =   -73680
         TabIndex        =   22
         Top             =   2520
         Width           =   1815
      End
      Begin VB.TextBox txtTipoNovo 
         Height          =   285
         Left            =   -73680
         TabIndex        =   20
         Top             =   1800
         Width           =   1815
      End
      Begin VB.TextBox txtTipoCanc 
         Height          =   285
         Left            =   -73680
         TabIndex        =   18
         Top             =   1080
         Width           =   1815
      End
      Begin VB.ListBox lstFormas 
         Height          =   1815
         ItemData        =   "PagamentoF.frx":003C
         Left            =   3360
         List            =   "PagamentoF.frx":003E
         TabIndex        =   6
         Top             =   1320
         Width           =   3015
      End
      Begin VB.CommandButton btnImprimir 
         Caption         =   "Imprimir"
         Height          =   375
         Left            =   1200
         TabIndex        =   5
         Top             =   2760
         Width           =   1695
      End
      Begin VB.CheckBox chkVinc 
         Caption         =   "Cupom Vinculado"
         Height          =   255
         Left            =   1200
         TabIndex        =   4
         Top             =   2400
         Width           =   1815
      End
      Begin VB.CommandButton Command1 
         Caption         =   "..."
         Height          =   255
         Left            =   2640
         TabIndex        =   1
         Top             =   1320
         Width           =   375
      End
      Begin VB.TextBox txtObs 
         Height          =   285
         Left            =   1200
         TabIndex        =   3
         Top             =   2040
         Width           =   1815
      End
      Begin VB.TextBox txtValor 
         Height          =   285
         Left            =   1200
         TabIndex        =   2
         Top             =   1680
         Width           =   1815
      End
      Begin VB.TextBox txtCod 
         Height          =   285
         Left            =   1200
         TabIndex        =   0
         Top             =   1320
         Width           =   1335
      End
      Begin VB.Label lblTotalPago 
         AutoSize        =   -1  'True
         Caption         =   "0,00"
         Height          =   195
         Left            =   4680
         TabIndex        =   30
         Top             =   3720
         Width           =   375
      End
      Begin VB.Label lblTotalCupom 
         AutoSize        =   -1  'True
         Caption         =   "0,00"
         Height          =   195
         Left            =   4680
         TabIndex        =   29
         Top             =   3360
         Width           =   375
      End
      Begin VB.Label Label10 
         AutoSize        =   -1  'True
         Caption         =   "Txt Adicional"
         Height          =   195
         Left            =   -74880
         TabIndex        =   28
         Top             =   3000
         Width           =   1095
      End
      Begin VB.Label Label9 
         AutoSize        =   -1  'True
         Caption         =   "Valor"
         Height          =   195
         Left            =   -74280
         TabIndex        =   27
         Top             =   2520
         Width           =   450
      End
      Begin VB.Label Label8 
         AutoSize        =   -1  'True
         Caption         =   "Novo"
         Height          =   195
         Left            =   -74280
         TabIndex        =   26
         Top             =   1800
         Width           =   435
      End
      Begin VB.Label Label7 
         AutoSize        =   -1  'True
         Caption         =   "Canc."
         Height          =   195
         Left            =   -74400
         TabIndex        =   17
         Top             =   1080
         Width           =   495
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "no último CF ou CNF"
         BeginProperty Font 
            Name            =   "Verdana"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   195
         Index           =   3
         Left            =   -74880
         TabIndex        =   16
         Top             =   720
         Width           =   1950
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "Somente podem ser estornados pagamentos efetivados"
         BeginProperty Font 
            Name            =   "Verdana"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   195
         Index           =   2
         Left            =   -74880
         TabIndex        =   15
         Top             =   480
         Width           =   5460
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         Caption         =   "Total Pago:"
         BeginProperty Font 
            Name            =   "Verdana"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   3555
         TabIndex        =   14
         Top             =   3720
         Width           =   1095
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         Caption         =   "Total Cupom:"
         BeginProperty Font 
            Name            =   "Verdana"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   3360
         TabIndex        =   13
         Top             =   3360
         Width           =   1275
      End
      Begin VB.Label Label3 
         AutoSize        =   -1  'True
         Caption         =   "Descrição"
         Height          =   195
         Left            =   240
         TabIndex        =   12
         Top             =   2040
         Width           =   840
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         Caption         =   "Valor"
         Height          =   195
         Left            =   600
         TabIndex        =   11
         Top             =   1680
         Width           =   450
      End
      Begin VB.Label Label6 
         AutoSize        =   -1  'True
         Caption         =   "Código"
         Height          =   195
         Left            =   480
         TabIndex        =   10
         Top             =   1320
         Width           =   600
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "- Se o valor pago for superior ao Total do Cupom será calculado o TROCO"
         Height          =   195
         Index           =   1
         Left            =   120
         TabIndex        =   9
         Top             =   840
         Width           =   6405
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "- Entre com um ou vários pagamentos até atingir o Total do Cupom"
         Height          =   195
         Index           =   0
         Left            =   120
         TabIndex        =   8
         Top             =   600
         Width           =   5820
      End
   End
End
Attribute VB_Name = "PagamentoFrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Baseado no demo do projeto ACBrX desenvolvido por Robson Braga
' www.easysoftware.net.br/acbrx.html

Public Estado, TipoCupom As String

Private Sub btnFechar_Click()
    Unload Me
End Sub

Private Sub btnImprimir_Click()
    If TipoCupom <> "N" Then
        Call MainFrm.ACBrECF.EfetuaPagamento(txtCod.Text, txtValor.Text, _
            txtObs.Text, chkVinc.Value)
        Call MainFrm.AdicionarResposta("Efetua Pagamento: " & txtCod.Text & vbCrLf & _
            "Valor: " & txtValor.Text & vbCrLf & _
            "Obs: " & txtObs.Text & vbCrLf & _
            "Vinc: " & IIf(chkVinc.Value, "S", "N") & vbCrLf & _
            "*****")
    Else
        Call MainFrm.ACBrECF.EfetuaPagamentoNaoFiscal(txtCod.Text, txtValor.Text, _
            txtObs.Text, chkVinc.Value)
        Call MainFrm.AdicionarResposta("Efetua Pagamento Não Fiscal: " & txtCod.Text & vbCrLf & _
            "Valor: " & txtValor.Text & vbCrLf & _
            "Obs: " & txtObs.Text & vbCrLf & _
            " Vinc: " & IIf(chkVinc.Value, "S", "N"))
    End If
    
    Call MainFrm.AtualizarMemos
    Call AtualizaVal
End Sub

Private Sub Command1_Click()
Dim Descricao As String
Dim FPG As FormaPagamento
    
    Descricao = InputBox("Entre com a Descrição a Localizar ou Cadastrar(Bematech)", _
        "Pesquisa Descrição Forma Pagamento", Descricao)
    If Descricao <> "" Then
        Set FPG = MainFrm.ACBrECF.AchaFPGDescricao(Descricao, False, True)
        
        If FPG Is Nothing Then
            Call MsgBox("Forma de Pagamento: " & Descricao & " não encontrada", vbCritical)
            Exit Sub
        End If
        
        txtCod.Text = FPG.Indice
        
        'Bematech permite cadastrar formas de Pagamento dinamicamente
        If (MainFrm.ACBrECF.Modelo = ecfBematech) And Not _
            ProcurarListBox(lstFormas, txtCod.Text) Then
            Call CarregaFPG
        End If
    End If
End Sub

Private Sub Command3_Click()
    Call MainFrm.ACBrECF.EstornaPagamento(txtTipoCanc.Text, txtTipoNovo.Text, _
        txtValorEstorno.Text, txtMsgPromocional.Text)
    Call MainFrm.AtualizarMemos
    Call AtualizaVal
End Sub

Private Sub Form_Load()
    If Estado = "Estorno" Then
        SSTab.Tab = 1
        'txtTipoCanc.SetFocus
    Else
        SSTab.Tab = 0
        'Call txtCod.SetFocus
    End If
    
    Estado = ""
    
    Call AtualizaVal
    Call CarregaFPG
    TipoCupom = "F"
End Sub

Private Sub AtualizaVal()
    lblTotalCupom.Caption = Format(MainFrm.ACBrECF.SubTotal, "#0.00")
    lblTotalPago.Caption = Format(MainFrm.ACBrECF.TotalPago, "#0.00")
End Sub


Private Sub CarregaFPG()
Dim item As String
Dim forma As Variant

    lstFormas.Clear
    lstFormasEst.Clear
    With MainFrm
        'Bematech e NaoFiscal permitem cadastrar formas de Pagamento dinamicamente
        If .ACBrECF.Modelo = ecfBematech Or .ACBrECF.Modelo = ecfNaoFiscal Then
            Call .ACBrECF.CarregaFormasPagamento
        Else
            Call .ACBrECF.AchaFPGIndice("")  'força carregar, se ainda nao o fez
        End If
     
        For Each forma In .ACBrECF.FormasPagamento
            item = forma.Indice & " -> " & _
                forma.Descricao & " - " & IIf(forma.permiteVinculado, "V", "")
            Call lstFormas.AddItem(item)
            Call lstFormasEst.AddItem(item)
        Next
    End With
End Sub

Private Sub lstFormas_GotFocus()
    btnImprimir.SetFocus
End Sub

Private Sub lstFormasEst_GotFocus()
    btnEstornar.SetFocus
End Sub
