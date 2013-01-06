unit ACBrRFDDll;

{$mode delphi}

interface

uses
  Classes,
  ACBrRFD,
  SysUtils;

{ Ponteiros de função para uso nos eventos}
type TCalcEADCallback = procedure(Arquivo: PChar); cdecl;
type TCalcHashLogCallback = function(const Linha: PChar) : PChar; cdecl;
type TGetKeyCallback =  function () : PChar;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlersRFD = class

  OnCalcEADCallback : TCalcEADCallback;
  OnCalcHashLogCallback : TCalcHashLogCallback;
  OnGetKeyHashLogCallback : TGetKeyCallback;
  OnGetKeyRSACallback : TGetKeyCallback;

  procedure OnCalcEAD(Arquivo: String);
  procedure OnCalcHashLog(const Linha: String; var Hash: String);
  procedure OnGetKeyHashLog(var Chave: String);
  procedure OnGetKeyRSA(var Chave: AnsiString);

end;

{Handle para o componente TACBrValidador}
type TRFDHandle = record
  UltimoErro : String;
  RFD : TACBrRFD;
  EventHandlers : TEventHandlersRFD;
end;

{Ponteiro para o Handle }
type PRFDHandle = ^TRFDHandle;


implementation

uses ACBrECFDll;

{%region Create/Destroy/Erro}
{
PADRONIZAÇÃO DAS FUNÇÕES:

        PARÂMETROS:
        Todas as funções recebem o parâmetro "handle" que é o ponteiro
        para o componente instanciado; Este ponteiro deve ser armazenado
        pela aplicação que utiliza a DLL;

        RETORNO:
        Todas as funções da biblioteca retornam um Integer com as possíveis Respostas:

                MAIOR OU IGUAL A ZERO: SUCESSO
                Outos retornos maior que zero indicam sucesso, com valor específico de cada função.

                MENOR QUE ZERO: ERROS

                  -1 : Erro ao executar;
                       Vide UltimoErro

                  -2 : ACBr não inicializado.

                  Outros retornos negativos indicam erro específico de cada função;

                  A função "UltimoErro" retornará a mensagem da última exception disparada pelo componente.
}

{
CRIA um novo componente TACBrRFD retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrRFD.
}
Function RFD_Create(var rfdHandle: PRFDHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(rfdHandle);
     rfdHandle^.RFD := TACBrRFD.Create(nil);
     rfdHandle^.EventHandlers := TEventHandlersRFD.Create();
     rfdHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        rfdHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrRFD e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function RFD_Destroy(var rfdHandle: PRFDHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    rfdHandle^.RFD.Destroy();
    rfdHandle^.RFD := nil;

    Dispose(rfdHandle);
    rfdHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        rfdHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function RFD_GetUltimoErro(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, rfdHandle^.UltimoErro, BufferLen);
     Result := length(rfdHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function RFD_GetDirRFD(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.DirRFD;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetDirRFD(const rfdHandle: PRFDHandle; const Dir : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.DirRFD := Dir;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_CNPJ(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_CNPJ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_CNPJ(const rfdHandle: PRFDHandle; const SH_CNPJ : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_CNPJ := SH_CNPJ;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_COO(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_COO;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_COO(const rfdHandle: PRFDHandle; const SH_COO : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_COO := SH_COO;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_IE(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_IE;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_IE(const rfdHandle: PRFDHandle; const SH_IE : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_IE := SH_IE;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_IM(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_IM;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_IM(const rfdHandle: PRFDHandle; const SH_IM : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_IM := SH_IM;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_Linha1(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_Linha1;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_Linha1(const rfdHandle: PRFDHandle; const SH_Linha1 : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_Linha1 := SH_Linha1;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_Linha2(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_Linha2;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_Linha2(const rfdHandle: PRFDHandle; const SH_Linha2 : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_Linha2 := SH_Linha2;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_NomeAplicativo(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_NomeAplicativo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_NomeAplicativo(const rfdHandle: PRFDHandle; const SH_NomeAplicativo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_NomeAplicativo := SH_NomeAplicativo;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_VersaoAplicativo(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_VersaoAplicativo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_VersaoAplicativo(const rfdHandle: PRFDHandle; const SH_VersaoAplicativo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_VersaoAplicativo := SH_VersaoAplicativo;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetSH_NumeroAplicativo(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.SH_NumeroAplicativo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetSH_NumeroAplicativo(const rfdHandle: PRFDHandle; const SH_NumeroAplicativo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.SH_NumeroAplicativo := SH_NumeroAplicativo;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetIgnoraEcfMfd(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if rfdHandle^.RFD.IgnoraEcfMfd then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetIgnoraEcfMfd(const rfdHandle: PRFDHandle; const IgnoraEcfMfd : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.IgnoraEcfMfd := IgnoraEcfMfd;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Funções mapeando as propriedades do componente não visiveis}

Function RFD_GetAtivo(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if rfdHandle^.RFD.Ativo then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetAtivo(const rfdHandle: PRFDHandle; const Ativo : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.Ativo := Ativo;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetDiaMov(const rfdHandle: PRFDHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := rfdHandle^.RFD.DiaMov;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetDirECF(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.DirECF;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetDirECFLog(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.DirECFLog;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetDirECFMes(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.DirECFMes;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetArqRFDID(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.ArqRFDID;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetArqRFD(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.ArqRFD;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetArqReducaoZ(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.ArqReducaoZ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetArqINI(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.ArqINI;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetECF_CROAtual(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := rfdHandle^.RFD.ECF_CROAtual;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetECF_CROAtual(const rfdHandle: PRFDHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.ECF_CROAtual := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetECF_RFDID(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.ECF_RFDID;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetECF_RFDID(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.ECF_RFDID := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetECF_DataHoraSwBasico(const rfdHandle: PRFDHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := rfdHandle^.RFD.ECF_DataHoraSwBasico;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetECF_DataHoraSwBasico(const rfdHandle: PRFDHandle; const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.ECF_DataHoraSwBasico := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetAtoCotepe(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.AtoCotepe;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetAtoCotepe(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.AtoCotepe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_CNPJ(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.CONT_CNPJ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_CNPJ(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_CNPJ := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_IE(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.CONT_IE;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_IE(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_IE := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_NumUsuario(const rfdHandle: PRFDHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
 value := rfdHandle^.RFD.CONT_NumUsuario;
 Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_NumUsuario(const rfdHandle: PRFDHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_NumUsuario := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_RazaoSocial(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.CONT_RazaoSocial;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_RazaoSocial(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_RazaoSocial := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_Endereco(const rfdHandle: PRFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.CONT_Endereco;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_Endereco(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_Endereco := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_DataHoraCadastro(const rfdHandle: PRFDHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := rfdHandle^.RFD.CONT_DataHoraCadastro;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_DataHoraCadastro(const rfdHandle: PRFDHandle; const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_DataHoraCadastro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_CROCadastro(const rfdHandle: PRFDHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
 value := rfdHandle^.RFD.CONT_CROCadastro;
 Result := 0;
 except
    on exception : Exception do
    begin
       rfdHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function RFD_SetCONT_CROCadastro(const rfdHandle: PRFDHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_CROCadastro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_GetCONT_GTCadastro(const rfdHandle: PRFDHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := rfdHandle^.RFD.CONT_GTCadastro;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function RFD_SetCONT_GTCadastro(const rfdHandle: PRFDHandle; const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     rfdHandle^.RFD.CONT_GTCadastro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Componente ACBr}

Function RFD_SetECF(const rfdHandle: PRFDHandle; const ecfHandle : PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      if (ecfHandle = nil) then
      begin
         rfdHandle^.RFD.ECF := nil;
         Result := 0;
      end
      else
      begin
         rfdHandle^.RFD.ECF := ecfHandle^.ECF;
         Result := 0;
      end;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Metodos}

Function RFD_Ativar(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.Ativar;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_Desativar(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.Desativar;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_VerificaParametros(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.VerificaParametros;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_AchaRFDID(const rfdHandle: PRFDHandle; const value : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.AchaRFDID(value);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_LerINI(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.LerINI;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_GravarINI(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.GravarINI;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_CriarArqRFDID(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.CriarArqRFDID(value);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_NomeArqRFD(const rfdHandle: PRFDHandle; const value : Double; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := rfdHandle^.RFD.NomeArqRFD(value);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_AbreCupom(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.AbreCupom;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_VendeItem(const rfdHandle: PRFDHandle; const Codigo, Descricao: pChar;
       const Qtd, ValorUnitario: Double; const Unidade: pChar;
       const ValorDescAcres: Double; Aliquota: pChar ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.VendeItem(Codigo, Descricao, Qtd, ValorUnitario, Unidade, ValorDescAcres, Aliquota);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_SubTotalizaCupom(const rfdHandle: PRFDHandle; const DescontoAcrescimo: Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.SubTotalizaCupom(DescontoAcrescimo);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_FechaCupom(const rfdHandle: PRFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.FechaCupom;
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_CancelaCupom(const rfdHandle: PRFDHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.CancelaCupom(value);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_CancelaItemVendido(const rfdHandle: PRFDHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.CancelaItemVendido(value);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_ReducaoZ(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.ReducaoZ(value);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_Documento(const rfdHandle: PRFDHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.Documento(value);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_EfetuaPagamento(const rfdHandle: PRFDHandle; const value : pChar; const valor : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
      rfdHandle^.RFD.EfetuaPagamento(value, valor);
      Result := 0;
 except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region HandlerEventos}

procedure TEventHandlersRFD.OnCalcEAD(Arquivo: String);
begin
 OnCalcEADCallback(PChar(Arquivo));
end;

procedure TEventHandlersRFD.OnCalcHashLog(const Linha: String; var Hash: String);
begin
 Hash := OnCalcHashLogCallback(PChar(Linha));
end;

procedure TEventHandlersRFD.OnGetKeyHashLog(var Chave: String);
begin
 Chave := OnGetKeyHashLogCallback();
end;

procedure TEventHandlersRFD.OnGetKeyRSA(var Chave: String);
begin
 Chave := OnGetKeyRSACallback();
end;

{%endregion}

{%region Eventos}

Function RFD_SetOnCalcEAD(const rfdHandle: PRFDHandle; const method : TCalcEADCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        rfdHandle^.RFD.OnCalcEAD := rfdHandle^.EventHandlers.OnCalcEAD;
        rfdHandle^.EventHandlers.OnCalcEADCallback := method;
        Result := 0;
  end
  else
  begin
        rfdHandle^.RFD.OnCalcEAD := nil;
        rfdHandle^.EventHandlers.OnCalcEADCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_SetOnCalcHashLog(const rfdHandle: PRFDHandle; const method : TCalcHashLogCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        rfdHandle^.RFD.OnCalcHashLog := rfdHandle^.EventHandlers.OnCalcHashLog;
        rfdHandle^.EventHandlers.OnCalcHashLogCallback := method;
        Result := 0;
  end
  else
  begin
        rfdHandle^.RFD.OnCalcHashLog := nil;
        rfdHandle^.EventHandlers.OnCalcHashLogCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_SetOnGetKeyHashLog(const rfdHandle: PRFDHandle; const method : TGetKeyCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        rfdHandle^.RFD.OnGetKeyHashLog := rfdHandle^.EventHandlers.OnGetKeyHashLog;
        rfdHandle^.EventHandlers.OnGetKeyHashLogCallback := method;
        Result := 0;
  end
  else
  begin
        rfdHandle^.RFD.OnGetKeyHashLog := nil;
        rfdHandle^.EventHandlers.OnGetKeyHashLogCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function RFD_SetOnGetKeyRSA(const rfdHandle: PRFDHandle; const method : TGetKeyCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (rfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        rfdHandle^.RFD.OnGetKeyRSA := rfdHandle^.EventHandlers.OnGetKeyRSA;
        rfdHandle^.EventHandlers.OnGetKeyRSACallback := method;
        Result := 0;
  end
  else
  begin
        rfdHandle^.RFD.OnGetKeyRSA := nil;
        rfdHandle^.EventHandlers.OnGetKeyRSACallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        rfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Funções }
RFD_Create,
RFD_Destroy,
RFD_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
RFD_GetDirRFD, RFD_SetDirRFD, RFD_GetSH_CNPJ, RFD_SetSH_CNPJ,
RFD_GetSH_COO, RFD_SetSH_COO, RFD_GetSH_IE, RFD_SetSH_IE,
RFD_GetSH_IM, RFD_SetSH_IM, RFD_GetSH_Linha1, RFD_SetSH_Linha1,
RFD_GetSH_Linha2, RFD_SetSH_Linha2,
RFD_GetSH_NomeAplicativo, RFD_SetSH_NomeAplicativo,
RFD_GetSH_VersaoAplicativo, RFD_SetSH_VersaoAplicativo,
RFD_GetSH_NumeroAplicativo, RFD_SetSH_NumeroAplicativo,
RFD_GetIgnoraEcfMfd, RFD_SetIgnoraEcfMfd,

{ Funções mapeando as propriedades do componente não visiveis}
RFD_GetAtivo, RFD_SetAtivo, RFD_GetDiaMov, RFD_GetDirECF,
RFD_GetDirECFLog, RFD_GetDirECFMes, RFD_GetArqRFDID,
RFD_GetArqRFD, RFD_GetArqReducaoZ, RFD_GetArqINI,
RFD_GetECF_CROAtual, RFD_SetECF_CROAtual,
RFD_GetECF_RFDID, RFD_SetECF_RFDID,
RFD_GetECF_DataHoraSwBasico, RFD_SetECF_DataHoraSwBasico,
RFD_GetAtoCotepe, RFD_SetAtoCotepe, RFD_GetCONT_CNPJ, RFD_SetCONT_CNPJ,
RFD_GetCONT_IE, RFD_SetCONT_IE, RFD_GetCONT_NumUsuario, RFD_SetCONT_NumUsuario,
RFD_GetCONT_RazaoSocial, RFD_SetCONT_RazaoSocial,
RFD_GetCONT_Endereco, RFD_SetCONT_Endereco,
RFD_GetCONT_DataHoraCadastro, RFD_SetCONT_DataHoraCadastro,
RFD_GetCONT_CROCadastro, RFD_SetCONT_CROCadastro,
RFD_GetCONT_GTCadastro, RFD_SetCONT_GTCadastro,

{ Componente ACBr }
RFD_SetECF,

{ Metodos }
RFD_Ativar, RFD_Desativar, RFD_VerificaParametros, RFD_AchaRFDID,
RFD_LerINI, RFD_GravarINI, RFD_CriarArqRFDID, RFD_NomeArqRFD,
RFD_AbreCupom, RFD_VendeItem, RFD_SubTotalizaCupom,
RFD_FechaCupom, RFD_CancelaCupom, RFD_CancelaItemVendido,
RFD_ReducaoZ, RFD_Documento, RFD_EfetuaPagamento,

{ Eventos }
RFD_SetOnCalcEAD, RFD_SetOnCalcHashLog,
RFD_SetOnGetKeyHashLog, RFD_SetOnGetKeyRSA;

end.

