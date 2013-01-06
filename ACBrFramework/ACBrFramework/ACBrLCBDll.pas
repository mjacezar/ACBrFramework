unit ACBrLCBDll;

interface

uses
  SysUtils,
  Classes,
  ACBrLCB;

{ Ponteiros de função }
type TLeCodigoCallback = procedure (); cdecl;

{ Classe que armazena os ponteiros de função para os Handlers }
type TEventHandlers = class
  OnLeCodigoCallback : TLeCodigoCallback;
  procedure OnLeCodigo(Sender: TObject);
end;

{Handle para o componente TACBrLCB }
type TLCBHandle = record
  UltimoErro : String;
  LCB : TACBrLCB;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle}
type PLCBHandle = ^TLCBHandle;



implementation

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
CRIA um novo componente TACBrLCB retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrLCB
}

procedure TEventHandlers.OnLeCodigo(Sender: TObject);
begin
     OnLeCodigoCallback();
end;


Function LCB_Create(var lcbHandle: PLCBHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try

     New(lcbHandle);

     lcbHandle^.LCB := TACBrLCB.Create(nil);
     lcbHandle^.EventHandlers := TEventHandlers.Create();
     lcbHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        lcbHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrLCB e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function LCB_Destroy(var lcbHandle: PLCBHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try

     if (lcbHandle = nil) then
     begin
        Result := -2;
        Exit;
     end;

     lcbHandle^.LCB.Destroy();
     lcbHandle^.LCB := nil;

     Dispose(lcbHandle);
     lcbHandle := nil;
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        lcbHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function LCB_GetUltimoErro(const lcbHandle: PLCBHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, lcbHandle^.UltimoErro, BufferLen);
     Result := length(lcbHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function LCB_Ativar(const lcbHandle: PLCBHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lcbHandle^.LCB.Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_Desativar(const lcbHandle: PLCBHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lcbHandle^.LCB.Desativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;

end;

Function LCB_GetPorta(const lcbHandle: PLCBHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lcbHandle^.LCB.Porta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_SetPorta(const lcbHandle: PLCBHandle; const Porta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lcbHandle^.LCB.Porta := Porta;
     Result := 0;
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_GetAtivo(const lcbHandle: PLCBHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (lcbHandle^.LCB.Ativo) then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_SetOnLeCodigo(const lcbHandle: PLCBHandle; const method : TLeCodigoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if Assigned(method) then
       begin
             lcbHandle^.LCB.OnLeCodigo := lcbHandle^.EventHandlers.OnLeCodigo;
             lcbHandle^.EventHandlers.OnLeCodigoCallback := method;
             Result := 0;
       end
       else
       begin
             lcbHandle^.LCB.OnLeCodigo := nil;
             lcbHandle^.EventHandlers.OnLeCodigoCallback := nil;
             Result := 0;
       end;
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_GetUltimoCodigo(const lcbHandle: PLCBHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lcbHandle^.LCB.UltimoCodigo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_GetUltimaLeitura(const lcbHandle: PLCBHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lcbHandle^.LCB.UltimaLeitura;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LCB_LerString(const lcbHandle: PLCBHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lcbHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lcbHandle^.LCB.LerString;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lcbHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


exports

{ Funções }

LCB_Create, LCB_Destroy,
LCB_GetUltimoErro,
LCB_Ativar, LCB_Desativar,
LCB_LerString,

{ Propriedades do Componente }

LCB_GetPorta, LCB_SetPorta,
LCB_GetAtivo, LCB_SetOnLeCodigo,
LCB_GetUltimoCodigo, LCB_GetUltimaLeitura;

end.
