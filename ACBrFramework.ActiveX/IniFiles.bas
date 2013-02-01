Attribute VB_Name = "IniFiles"
Declare Function GetPrivateProfileString Lib "kernel32" Alias _
    "GetPrivateProfileStringA" (ByVal lpApplicationName _
    As String, ByVal lpKeyName As Any, ByVal lpDefault _
    As String, ByVal lpReturnedString As String, ByVal _
    nSize As Long, ByVal lpFileName As String) As Long
    
Declare Function WritePrivateProfileString Lib "kernel32" Alias _
    "WritePrivateProfileStringA" (ByVal lpApplicationName _
    As String, ByVal lpKeyName As Any, ByVal lpString As Any, _
    ByVal lpFileName As String) As Long
    
Public Function ReadINI(arquivoIni As String, sessao As String, chave _
    As String, default As String) As String
Dim aux As String * 256
Dim tamanho As Integer
    aux = Space$(256)
    tamanho = GetPrivateProfileString(sessao, chave, default, aux, _
        255, arquivoIni)
    ReadINI = Left$(aux, tamanho)
End Function

Public Sub WriteINI(arquivoIni As String, sessao As String, chave _
    As String, valor As String)
Dim n As Integer
Dim aux As String
    aux = valor
    'Replace any CR/LF characters with spaces
    For n = 1 To Len(valor)
        If Mid$(valor, n, 1) = vbCr Or Mid$(valor, n, 1) = vbLf _
        Then Mid$(valor, n) = " "
    Next n
    n = WritePrivateProfileString(sessao, chave, aux, arquivoIni)
End Sub

