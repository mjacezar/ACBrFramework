VERSION 5.00
Begin VB.Form RelatorioFrm 
   Caption         =   "Relatório Gerencial"
   ClientHeight    =   4440
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   4710
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
   ScaleHeight     =   4440
   ScaleWidth      =   4710
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command3 
      Caption         =   "&Imprimir"
      Height          =   375
      Left            =   3480
      TabIndex        =   8
      Top             =   3960
      Width           =   1095
   End
   Begin VB.TextBox txtValor 
      Height          =   285
      Left            =   3720
      TabIndex        =   6
      Text            =   "1,50"
      Top             =   360
      Width           =   840
   End
   Begin VB.CommandButton btnCNF 
      Caption         =   "..."
      Height          =   255
      Left            =   3240
      TabIndex        =   5
      Top             =   360
      Width           =   375
   End
   Begin VB.TextBox txtCNF 
      Height          =   285
      Left            =   2640
      TabIndex        =   4
      Top             =   360
      Width           =   480
   End
   Begin VB.CommandButton btnFPG 
      Caption         =   "..."
      Height          =   255
      Left            =   2160
      TabIndex        =   3
      Top             =   360
      Width           =   375
   End
   Begin VB.TextBox txtFPG 
      Height          =   285
      Left            =   1560
      TabIndex        =   2
      Text            =   "01"
      Top             =   360
      Width           =   480
   End
   Begin VB.TextBox txtCupom 
      Height          =   285
      Left            =   720
      TabIndex        =   1
      Top             =   360
      Width           =   720
   End
   Begin VB.TextBox txtVias 
      Height          =   285
      Left            =   120
      TabIndex        =   0
      Text            =   "3"
      Top             =   360
      Width           =   480
   End
   Begin VB.TextBox txtRelat 
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
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   7
      Text            =   "RelatorioF.frx":0000
      Top             =   840
      Width           =   4455
   End
   Begin VB.Label Valor 
      AutoSize        =   -1  'True
      Caption         =   "Valor"
      Height          =   195
      Left            =   3720
      TabIndex        =   13
      Top             =   120
      Width           =   450
   End
   Begin VB.Label lblCNF 
      AutoSize        =   -1  'True
      Caption         =   "CNF"
      Height          =   195
      Left            =   2640
      TabIndex        =   12
      Top             =   120
      Width           =   345
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Forma Pgto."
      Height          =   195
      Left            =   1560
      TabIndex        =   11
      Top             =   120
      Width           =   1035
   End
   Begin VB.Label lblCupom 
      AutoSize        =   -1  'True
      Caption         =   "Cupom"
      Height          =   195
      Left            =   720
      TabIndex        =   10
      Top             =   120
      Width           =   615
   End
   Begin VB.Label lblVias 
      AutoSize        =   -1  'True
      Caption         =   "Vias"
      Height          =   195
      Left            =   120
      TabIndex        =   9
      Top             =   120
      Width           =   360
   End
End
Attribute VB_Name = "RelatorioFrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Baseado no demo do projeto ACBrX desenvolvido por Robson Braga
' www.easysoftware.net.br/acbrx.html

Public TipoRelatorio As String

Private Sub Command1_Click()
    Call MainFrm.mniCarregaFormasPagamento_Click
End Sub

Private Sub Command2_Click()
    Call MainFrm.mniCarregaComprovantesNaoFiscais_Click
End Sub

Private Sub Command3_Click()
Dim Relatorio As Variant

    'PENDENTE
   Relatorio = Split(txtRelat.Text)
   If TipoRelatorio = "V" Then
        'Call MainFrm.ACBrECF.CupomVinculado(txtCupom.Text, txtFPG.Text, txtValor.Text, _
            Relatorio, txtVias.Text)
    Else
        'Call MainFrm.ACBrECF.RelatorioGerencial(Relatorio, txtVias.Text, txtCupom.Text)
    End If
       
End Sub

Private Sub Form_Load()
    txtFPG.Visible = TipoRelatorio = "V"
    lblFPG.Visible = txtFPG.Visible
    btnFPG.Visible = txtFPG.Visible
    lblValor.Visible = txtFPG.Visible
    txtValor.Visible = txtFPG.Visible
    
    If edCupom.Visible Then
        txtCupom.Text = MainFrm.ACBrECF.NumCupom
        txtCNF.Text = ""
        txtCNF.Visible = txtFPG.Visible And _
            (MainFrm.ACBrECF.Modelo = ecfDaruma Or MainFrm.ACBrECF.Modelo = ecfSchalter)
        btnCNF.Visible = txtCNF.Visible
        lblCNF.Visible = txtCNF.Visible
        If TipoRelatorio = "V" Then
            Caption = "Cupom NAO Fiscal Vinculado"
        End If
    Else
        Caption = "Relatório Gerêncial"
        lblCupom.Caption = "Indice Relatório Rerencial"
        txtCupom.Text = "01"
    End If
End Sub
