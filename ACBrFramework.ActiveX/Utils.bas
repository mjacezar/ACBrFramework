Attribute VB_Name = "Utils"
Option Explicit

Private Const BIF_RETURNONLYFSDIRS = 1
Private Const BIF_DONTGOBELOWDOMAIN = 2
Private Const MAX_PATH = 260

Private Declare Function SHBrowseForFolder Lib _
"shell32" (lpbi As BrowseInfo) As Long

Private Declare Function SHGetPathFromIDList Lib _
"shell32" (ByVal pidList As Long, ByVal lpBuffer _
As String) As Long

Private Declare Function lstrcat Lib "kernel32" _
Alias "lstrcatA" (ByVal lpString1 As String, ByVal _
lpString2 As String) As Long

Private Type BrowseInfo
   hWndOwner As Long
   pIDLRoot As Long
   pszDisplayName As Long
   lpszTitle As Long
   ulFlags As Long
   lpfnCallback As Long
   lParam As Long
   iImage As Long
End Type

Public Function ProcurarListBox(List As ListBox, item As String) As Boolean
    Dim i As Integer
    Dim Resultado As Boolean
    Dim Pos As Integer
    
    For i = 0 To List.ListCount - 1
        Pos = InStr(1, LCase(List.List(i)), LCase(item), vbTextCompare)
        'If LCase(List.List(i)) = LCase(item) Then
        If Pos > 0 Then
            Resultado = True
            Exit For
        Else
            Resultado = False
        End If
    Next i
    
    ProcurarListBox = Resultado
End Function


Public Function ProcurarComboBox(Combo As ComboBox, item As String) As Integer
    Dim i As Integer
    Dim Resultado As Integer
    'Dim Pos As Integer
    
    Resultado = -1
    For i = 0 To Combo.ListCount - 1
        'Pos = InStr(1, LCase(List.List(i)), LCase(item), vbTextCompare)
        If LCase(Combo.List(i)) = LCase(item) Then
        'If Pos > 0 Then
            Resultado = i
            Exit For
        End If
    Next i
    
    ProcurarComboBox = Resultado
End Function

Public Function SelecionarDiretorio(Mensagem As String) As String
'Opens a Browse Folders Dialog Box that displays the
'directories in your computer
Dim lpIDList As Long ' Declare Varibles
Dim sBuffer As String
Dim szTitle As String
Dim tBrowseInfo As BrowseInfo

    szTitle = Mensagem
    ' Text to appear in the the gray area under the title bar
    ' telling you what to do
    
    With tBrowseInfo
       '.hWndOwner = Me.hWnd ' Owner Form
       .lpszTitle = lstrcat(szTitle, "")
       .ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN
    End With
    
    lpIDList = SHBrowseForFolder(tBrowseInfo)
    
    If (lpIDList) Then
       sBuffer = Space(MAX_PATH)
       SHGetPathFromIDList lpIDList, sBuffer
       sBuffer = Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
       SelecionarDiretorio = sBuffer
    Else
        SelecionarDiretorio = ""
    End If
End Function
