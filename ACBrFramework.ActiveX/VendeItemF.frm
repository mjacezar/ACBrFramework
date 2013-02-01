VERSION 5.00
Begin VB.Form VendeItemFrm 
   Caption         =   "Vende Item"
   ClientHeight    =   3540
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   5985
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
   ScaleHeight     =   3540
   ScaleWidth      =   5985
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "&Fechar"
      Height          =   375
      Left            =   1560
      TabIndex        =   25
      Top             =   3000
      Width           =   1215
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&Imprimir"
      Height          =   375
      Left            =   240
      TabIndex        =   24
      Top             =   3000
      Width           =   1215
   End
   Begin VB.Frame Frame2 
      Height          =   2180
      Left            =   3000
      TabIndex        =   10
      Top             =   1200
      Width           =   2775
      Begin VB.TextBox txtValorAliqICMS 
         Height          =   285
         Left            =   1680
         TabIndex        =   11
         Text            =   "NN"
         Top             =   240
         Width           =   975
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "SF = Subst.Tributária ISSQN"
         Height          =   195
         Index           =   5
         Left            =   120
         TabIndex        =   23
         Top             =   1800
         Width           =   2460
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "SN = Nao Incidencia ISSQN"
         Height          =   195
         Index           =   4
         Left            =   120
         TabIndex        =   22
         Top             =   1560
         Width           =   2385
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "SI = Isento ISSQN"
         Height          =   195
         Index           =   3
         Left            =   120
         TabIndex        =   21
         Top             =   1320
         Width           =   1620
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "FF = Substituiçao Tributária"
         Height          =   195
         Index           =   2
         Left            =   120
         TabIndex        =   20
         Top             =   1080
         Width           =   2355
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "NN = Nao Incidencia"
         Height          =   195
         Index           =   0
         Left            =   120
         TabIndex        =   19
         Top             =   840
         Width           =   1755
      End
      Begin VB.Label lblLegendaAliquota 
         AutoSize        =   -1  'True
         Caption         =   "II = Isento"
         Height          =   195
         Index           =   1
         Left            =   120
         TabIndex        =   18
         Top             =   600
         Width           =   945
      End
      Begin VB.Label Label7 
         AutoSize        =   -1  'True
         Caption         =   "Valor Aliq. ICMS"
         Height          =   195
         Index           =   0
         Left            =   120
         TabIndex        =   17
         Top             =   240
         Width           =   1410
      End
   End
   Begin VB.Frame Frame1 
      Height          =   1335
      Left            =   240
      TabIndex        =   6
      Top             =   1560
      Width           =   2535
      Begin VB.OptionButton optValor 
         Caption         =   "Valor"
         Height          =   255
         Left            =   960
         TabIndex        =   9
         Top             =   960
         Width           =   1335
      End
      Begin VB.OptionButton optPercentual 
         Caption         =   "Percentual"
         Height          =   255
         Left            =   960
         TabIndex        =   8
         Top             =   720
         Value           =   -1  'True
         Width           =   1335
      End
      Begin VB.TextBox txtDesconto 
         Height          =   285
         Left            =   960
         TabIndex        =   7
         Text            =   "0,00"
         Top             =   360
         Width           =   1455
      End
      Begin VB.Label Label6 
         AutoSize        =   -1  'True
         Caption         =   "Desconto"
         Height          =   195
         Left            =   120
         TabIndex        =   16
         Top             =   360
         Width           =   795
      End
   End
   Begin VB.TextBox txtUnidade 
      Height          =   285
      Left            =   1200
      TabIndex        =   5
      Text            =   "UN"
      Top             =   1200
      Width           =   1575
   End
   Begin VB.TextBox txtPrecoUnit 
      Height          =   285
      Left            =   4200
      TabIndex        =   4
      Text            =   "1,50"
      Top             =   840
      Width           =   1575
   End
   Begin VB.TextBox txtQtde 
      Height          =   285
      Left            =   1200
      TabIndex        =   3
      Text            =   "1"
      Top             =   840
      Width           =   1575
   End
   Begin VB.TextBox txtDescricao 
      Height          =   285
      Left            =   1200
      TabIndex        =   2
      Text            =   "Teste de Produto"
      Top             =   480
      Width           =   4575
   End
   Begin VB.TextBox txtCodigo 
      Height          =   285
      Left            =   1200
      TabIndex        =   1
      Text            =   "111222333"
      Top             =   120
      Width           =   1575
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   "Unidade"
      Height          =   195
      Left            =   360
      TabIndex        =   15
      Top             =   1200
      Width           =   690
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "Preço Unit."
      Height          =   195
      Left            =   3120
      TabIndex        =   14
      Top             =   840
      Width           =   930
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "Qtde."
      Height          =   195
      Left            =   600
      TabIndex        =   13
      Top             =   840
      Width           =   465
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Descrição"
      Height          =   195
      Left            =   240
      TabIndex        =   12
      Top             =   480
      Width           =   840
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Código"
      Height          =   195
      Left            =   480
      TabIndex        =   0
      Top             =   120
      Width           =   600
   End
End
Attribute VB_Name = "VendeItemFrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Baseado no demo do projeto ACBrX desenvolvido por Robson Braga
' www.easysoftware.net.br/acbrx.html

Private Sub Command1_Click()
Dim Desc As String

    Call MainFrm.MouseEspera
    Desc = "%"
    If optValor.Value Then
        Desc = "$"
    End If
        
    Call MainFrm.ACBrECF.VendeItem(txtCodigo.Text, txtDescricao.Text, _
        txtValorAliqICMS.Text, txtQtde.Text, txtPrecoUnit.Text, _
        txtDesconto.Text, txtUnidade.Text, Desc)
        
    Call MainFrm.AdicionarResposta("Vende Item: Cod:" & txtCodigo.Text & vbCrLf & _
        "Desc" & txtDescricao.Text & vbCrLf & _
        "Aliq:" & txtValorAliqICMS.Text & vbCrLf & _
        "Qtd:" & txtQtde.Text & vbCrLf & _
        "Preço:" & txtPrecoUnit.Text & vbCrLf & _
        "Desc:" & txtDesconto.Text & vbCrLf & _
        "Un:" & txtUnidade.Text & vbCrLf & _
        "Desc:" & Desc & vbCrLf & _
        "*****")
        
    Call MainFrm.AtualizarMemos
    Call MainFrm.MouseNormal
  
End Sub

Private Sub Command2_Click()
    Unload Me
End Sub
