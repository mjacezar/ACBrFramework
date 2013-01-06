unit ACBrEADDll;

interface

uses
  SysUtils,
  Classes,
  ACBrEAD,
  ACBrUtil;

{ Ponteiros de função }
type TGetChaveCallback = function () : PChar; cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
   ChavePrivada : AnsiString;
   ChavePublica : AnsiString;
   OnGetChavePrivadaCallback : TGetChaveCallback;
   OnGetChavePublicaCallback : TGetChaveCallback;
   procedure GetChavePrivada(var Chave : AnsiString);
   procedure GetChavePublica(var Chave : AnsiString);
end;

{Handle para o componente TACBrEAD }
type TEADHandle = record
  UltimoErro : String;
  EAD : TACBrEAD;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PEADHandle = ^TEADHandle;


implementation

{%region Constructor\Destructor\Erro}

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
CRIA um novo componente TACBrEAD retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
Function EAD_Create(var eadHandle: PEADHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(eadHandle);
     eadHandle^.EAD := TACBrEAD.Create(nil);
     eadHandle^.EventHandlers := TEventHandlers.Create();
     eadHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        eadHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrEAD e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function EAD_Destroy(var eadHandle: PEADHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (eadHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    eadHandle^.EAD.Destroy();
    eadHandle^.EAD := nil;

    Dispose(eadHandle);
    eadHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        eadHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function EAD_GetUltimoErro(const eadHandle: PEADHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, eadHandle^.UltimoErro, BufferLen);
     Result := length(eadHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Propriedades do componente}

Function EAD_GetChavePrivada(const eadHandle: PEADHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

 try
     StrTmp := eadHandle^.EventHandlers.ChavePrivada;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_SetChavePrivada(const eadHandle: PEADHandle; const Chave : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     if not Assigned(eadHandle^.EAD.OnGetChavePrivada) then
     begin
     eadHandle^.EAD.OnGetChavePrivada := eadHandle^.EventHandlers.GetChavePrivada;
     end;
     eadHandle^.EventHandlers.ChavePrivada := Chave;
     Result := 0;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_GetChavePublica(const eadHandle: PEADHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

 try
     StrTmp := eadHandle^.EventHandlers.ChavePublica;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_SetChavePublica(const eadHandle: PEADHandle; const Chave : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  try
     if not Assigned(eadHandle^.EAD.OnGetChavePublica) then
     begin
     eadHandle^.EAD.OnGetChavePublica := eadHandle^.EventHandlers.GetChavePublica;
     end;
     eadHandle^.EventHandlers.ChavePublica := Chave;
     Result := 0;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_GetOpenSSL_Version(const eadHandle: PEADHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

 try
     StrTmp := eadHandle^.EAD.OpenSSL_Version;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_GetAbout(const eadHandle: PEADHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

 try
     StrTmp := eadHandle^.EAD.About;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Metodos}

function EAD_GerarChaves(const eadHandle: PEADHandle; ChavePUB, ChavePRI : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  ChavePublica, ChavePrivada : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     ChavePrivada := '' ;
     ChavePublica := '' ;
     eadHandle^.EAD.GerarChaves( ChavePublica, ChavePrivada );
     ChavePublica := StringReplace( ChavePublica, #10, sLineBreak, [rfReplaceAll] );
     ChavePrivada := StringReplace( ChavePrivada, #10, sLineBreak, [rfReplaceAll] );

     StrPLCopy(ChavePUB, ChavePublica, BufferLen);
     StrPLCopy(ChavePRI, ChavePrivada, BufferLen);
     Result := 0;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularModuloeExpoente(const eadHandle: PEADHandle; ModuloBuffer, ExpoenteBuffer: pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  Modulo, Expoente : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     Modulo := '' ;
     Expoente := '' ;
     eadHandle^.EAD.CalcularModuloeExpoente(Modulo, Expoente);

     StrPLCopy(ModuloBuffer, Modulo, BufferLen);
     StrPLCopy(ExpoenteBuffer, Expoente, BufferLen);
     Result := Length(ModuloBuffer) + Length(ExpoenteBuffer);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularChavePublica(const eadHandle: PEADHandle; ChavePUB: pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  Chave : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     Chave :=  eadHandle^.EAD.CalcularChavePublica;
     Chave := StringReplace( Chave, #10, sLineBreak, [rfReplaceAll] );
     StrPLCopy(ChavePUB, Chave, BufferLen);
     Result := Length(ChavePUB);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_GerarXMLeECFc(const eadHandle: PEADHandle;const NomeSH, PathArquivo: pChar): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     if Assigned(PathArquivo) then
        eadHandle^.EAD.GerarXMLeECFc(NomeSH, PathArquivo)
     else
        eadHandle^.EAD.GerarXMLeECFc(NomeSH);
     Result := 0;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_ConverteXMLeECFcParaOpenSSL(const eadHandle: PEADHandle;const Arquivo: pChar; ChavePUB: pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.ConverteXMLeECFcParaOpenSSL(Arquivo);
     TempSTR := StringReplace( TempSTR, #10, sLineBreak, [rfReplaceAll] );
     StrPLCopy(ChavePUB, TempSTR, BufferLen);
     Result := Length(ChavePUB);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularHashArquivo(const eadHandle: PEADHandle; const Arquivo: pChar; const HashType: Integer; Hash : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.CalcularHashArquivo(Arquivo, TACBrEADDgst(HashType));
     StrPLCopy(Hash, TempSTR, BufferLen);
     Result := Length(Hash);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularHash(const eadHandle: PEADHandle; const str: pChar; const HashType: Integer; Hash : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.CalcularHash(str, TACBrEADDgst(HashType));
     StrPLCopy(Hash, TempSTR, BufferLen);
     Result := Length(Hash);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularEADArquivo(const eadHandle: PEADHandle; const Arquivo: pChar; EAD : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.CalcularEADArquivo(Arquivo);
     StrPLCopy(EAD, TempSTR, BufferLen);
     Result := Length(EAD);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_CalcularEAD(const eadHandle: PEADHandle; const EString: array of pChar; const count : Integer;
           EAD : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString;
  StringList : TStringList;
  i : Integer;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     StringList := TStringList.Create;

     for i := 0 to count do
     begin
        StringList.Add(Estring[i]);
     end;

     TempSTR := eadHandle^.EAD.CalcularEAD(StringList);
     StrPLCopy(EAD, TempSTR, BufferLen);
     Result := Length(EAD);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_AssinarArquivoComEAD(const eadHandle: PEADHandle; const Arquivo: pChar; const Remove:Boolean; EAD: pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.AssinarArquivoComEAD(Arquivo, Remove);
     StrPLCopy(EAD, TempSTR, BufferLen);
     Result := Length(EAD);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_VerificarEADArquivo(const eadHandle: PEADHandle;const Arquivo: pChar): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     if (eadHandle^.EAD.VerificarEADArquivo(Arquivo))then
       Result := 1
     else
       Result := 0;

  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_VerificarEAD(const eadHandle: PEADHandle; const ead: pChar): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     if (eadHandle^.EAD.VerificarEAD(ead))then
       Result := 1
     else
       Result := 0;

  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_RemoveEADArquivo(const eadHandle: PEADHandle;const Arquivo: pChar): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     eadHandle^.EAD.RemoveEADArquivo(Arquivo);
     Result := 0;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_MD5FromFile(const eadHandle: PEADHandle; const APathArquivo: pChar; Hash : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.MD5FromFile(APathArquivo);
     StrPLCopy(Hash, TempSTR, BufferLen);
     Result := Length(Hash);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

function EAD_MD5FromString(const eadHandle: PEADHandle; const AString: pChar; Hash : pChar; const BufferLen : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  TempSTR : AnsiString ;
begin
  try
     if (eadHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     TempSTR := eadHandle^.EAD.MD5FromString(AString);
     StrPLCopy(Hash, TempSTR, BufferLen);
     Result := Length(Hash);
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

{%endregion}

{%region Eventos}

procedure TEventHandlers.GetChavePrivada(var Chave : AnsiString);
begin
  if (Length(ChavePrivada) > 0) then
    Chave := ChavePrivada
  else
     Chave := OnGetChavePrivadaCallback();
end;

procedure TEventHandlers.GetChavePublica(var Chave : AnsiString);
begin
  if (Length(ChavePublica) > 0) then
    Chave := ChavePublica
  else
     Chave := OnGetChavePublicaCallback();
end;

Function EAD_SetOnGetChavePublica(const eadHandle: PEADHandle; const method : TGetChaveCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (eadHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if Assigned(method) then
     begin
        eadHandle^.EAD.OnGetChavePublica := eadHandle^.EventHandlers.GetChavePublica;
        eadHandle^.EventHandlers.OnGetChavePublicaCallback := method;
        Result := 0;
     end
     else
     begin
        eadHandle^.EAD.OnGetChavePublica := nil;
        eadHandle^.EventHandlers.OnGetChavePublicaCallback := nil;
        Result := 0;
     end;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function EAD_SetOnGetChavePrivada(const eadHandle: PEADHandle; const method : TGetChaveCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (eadHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if Assigned(method) then
     begin
        eadHandle^.EAD.OnGetChavePrivada := eadHandle^.EventHandlers.GetChavePrivada;
        eadHandle^.EventHandlers.OnGetChavePrivadaCallback := method;
        Result := 0;
     end
     else
     begin
        eadHandle^.EAD.OnGetChavePrivada := nil;
        eadHandle^.EventHandlers.OnGetChavePrivadaCallback := nil;
        Result := 0;
     end;
  except
     on exception : Exception do
     begin
        eadHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Funções }
EAD_Create,
EAD_Destroy,
EAD_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
EAD_GetChavePrivada, EAD_SetChavePrivada,
EAD_GetChavePublica, EAD_SetChavePublica,
EAD_GetOpenSSL_Version, EAD_GetAbout,

{ Metodos do componente }
EAD_GerarChaves, EAD_CalcularModuloeExpoente,
EAD_GerarXMLeECFc, EAD_ConverteXMLeECFcParaOpenSSL,
EAD_CalcularEADArquivo, EAD_AssinarArquivoComEAD,
EAD_VerificarEADArquivo, EAD_CalcularChavePublica,
EAD_CalcularHash, EAD_RemoveEADArquivo, EAD_VerificarEAD,
EAD_CalcularEAD, EAD_CalcularHashArquivo, EAD_MD5FromString, EAD_MD5FromFile,

{Eventos}
EAD_SetOnGetChavePrivada,
EAD_SetOnGetChavePublica
;

end.
