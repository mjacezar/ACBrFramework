unit ACBrSpedFiscaldll;

interface

uses
  Classes,
  SysUtils,
  ACBrSpedFiscal;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
end;

{Handle para o componente TACBrSPEDFiscal}
type TSPDFHandle = record
  UltimoErro : String;
  SPEDFiscal : TACBrSPEDFiscal;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PSPDFHandle = ^TSPDFHandle;

implementation

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
CRIA um novo componente TACBrSPEDFiscal retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
Function SPDF_Create(var spdfHandle: PSPDFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(spdfHandle);
     spdfHandle^.SPEDFiscal := TACBrSPEDFiscal.Create(nil);
     spdfHandle^.EventHandlers := TEventHandlers.Create();
     spdfHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        spdfHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrSPEDFiscal e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function SPDF_Destroy(var spdfHandle: PSPDFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    spdfHandle^.SPEDFiscal.Destroy();
    spdfHandle^.SPEDFiscal := nil;

    Dispose(spdfHandle);
    spdfHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        spdfHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SPDF_GetUltimoErro(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, spdfHandle^.UltimoErro, BufferLen);
     Result := length(spdfHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function SPDF_GetAbout(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.About;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetArquivo(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Arquivo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetArquivo(const spdfHandle: PSPDFHandle; Const Arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Arquivo := Arquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetCurMascara(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.CurMascara;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetCurMascara(const spdfHandle: PSPDFHandle; Const CurMascara : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.CurMascara := CurMascara;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetPath(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Path;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetPath(const spdfHandle: PSPDFHandle; Const Path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Path := Path;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetDelimitador(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Delimitador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetDelimitador(const spdfHandle: PSPDFHandle; Const Delimitador : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Delimitador := Delimitador;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetLinhasBuffer(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.LinhasBuffer;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetLinhasBuffer(const spdfHandle: PSPDFHandle; const Linhas: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.LinhasBuffer := Linhas;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_GetTrimString(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.TrimString then
      Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetTrimString(const spdfHandle: PSPDFHandle; const TrimString: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.TrimString := TrimString;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

 {%region Funções mapeando as propriedades do componente não visiveis}

Function SPDF_GetDT_INI(const spdfHandle: PSPDFHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Data := Double(spdfHandle^.SPEDFiscal.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetDT_INI(const spdfHandle: PSPDFHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.DT_INI := Data;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_GetDT_FIN(const spdfHandle: PSPDFHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Data := Double(spdfHandle^.SPEDFiscal.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetDT_FIN(const spdfHandle: PSPDFHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.DT_FIN := Data;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Methods }

Function SPDF_IniciaGeracao(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.IniciaGeracao;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Create/Destroy/Erro }
SPDF_Create,
SPDF_Destroy,
SPDF_GetUltimoErro,

{ Funções mapeando as propriedades do componente }

SPDF_GetAbout, SPDF_GetArquivo, SPDF_SetArquivo,
SPDF_GetCurMascara, SPDF_SetCurMascara, SPDF_GetPath,
SPDF_SetPath, SPDF_GetDelimitador, SPDF_SetDelimitador,
SPDF_GetLinhasBuffer, SPDF_SetLinhasBuffer, SPDF_GetTrimString,
SPDF_SetTrimString, SPDF_GetDT_INI, SPDF_SetDT_INI,
SPDF_GetDT_FIN, SPDF_SetDT_FIN,

{ Methods }
SPDF_IniciaGeracao
;
end.

