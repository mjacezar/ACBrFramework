unit ACBrDISDll;

interface

uses
  SysUtils,
  Classes,
  ACBrDIS;

type TAtualizaCallback = procedure(Linha : Integer; TextoVisivel: PCHAR); cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
    OnAtualizaCallback : TAtualizaCallback;
    procedure OnAtualiza(Linha : Integer; TextoVisivel: String);
end;

{Handle para o componente TACBrDIS }
type TDISHandle = record
  UltimoErro : String;
  DIS : TACBrDIS;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle}
type PDISHandle = ^TDISHandle;

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

procedure TEventHandlers.OnAtualiza(Linha : Integer; TextoVisivel: String);
begin
     OnAtualizaCallback(Linha, PCHAR(TextoVisivel));
end;

{
CRIA um novo componente TACBrDIS retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrDIS
}
Function DIS_Create(var disHandle: PDISHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try

     New(disHandle);

     disHandle^.DIS := TACBrDIS.Create(nil);
     disHandle^.EventHandlers := TEventHandlers.Create();
     disHandle^.UltimoErro := '';

     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        disHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrDIS e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function DIS_Destroy(disHandle: PDISHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try

     if (disHandle = nil) then
     begin
        Result := -2;
        Exit;
     end;

     disHandle^.DIS.Destroy();
     disHandle^.DIS := nil;

     Dispose(disHandle);
     disHandle := nil;
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        disHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function DIS_GetUltimoErro(const disHandle: PDISHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, disHandle^.UltimoErro, BufferLen);
     Result := length(disHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function DIS_Ativar(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_Desativar(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Desativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;

end;

{%region Propriedades}

Function DIS_GetModelo(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(disHandle^.DIS.Modelo);
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetModelo(const disHandle: PDISHandle; const Modelo : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Modelo := TACBrDISModelo(Modelo);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetModeloStr(const disHandle: PDISHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := disHandle^.DIS.ModeloStr;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetAtivo(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (disHandle^.DIS.Ativo) then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetCursor(const disHandle: PDISHandle; var x : Integer; var y : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     x := disHandle^.DIS.Cursor.x;
     y := disHandle^.DIS.Cursor.y;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetLinhasCount(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := disHandle^.DIS.LinhasCount;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetLinhasCount(const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.LinhasCount := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetColunas (const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := disHandle^.DIS.Colunas;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetColunas (const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Colunas := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function DIS_GetAlinhamento(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(disHandle^.DIS.Alinhamento);
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function DIS_SetAlinhamento(const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Alinhamento := TACBrDISAlinhamento(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetIntervalo (const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := disHandle^.DIS.Intervalo;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetIntervalo (const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Intervalo := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetPassos (const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := disHandle^.DIS.Passos;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetPassos (const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Passos := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetRemoveAcentos (const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (disHandle^.DIS.RemoveAcentos) then
        Result := 1
     else
          Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetRemoveAcentos (const disHandle: PDISHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.RemoveAcentos := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_GetIntervaloEnvioBytes(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result :=  disHandle^.DIS.IntervaloEnvioBytes;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_SetIntervaloEnvioBytes(const disHandle: PDISHandle; const value : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.IntervaloEnvioBytes := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function DIS_GetTrabalhando(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (disHandle^.DIS.Trabalhando) then
          Result := 1
     else
         Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion Propriedades}

{%region Methods}

Function DIS_LimparDisplay(const disHandle: PDISHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.LimparDisplay();
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function DIS_LimparLinha(const disHandle: PDISHandle; const Linha: Integer ) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.LimparLinha(Linha);
      Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_PosicionarCursor(const disHandle: PDISHandle; const Linha : Integer; const  Coluna: Integer )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.PosicionarCursor(Linha, Coluna);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_Escrever(const disHandle: PDISHandle; const  AText : PCHAR  )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Escrever(AText);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_ExibirLinha(const disHandle: PDISHandle; const Linha : Integer ; const AText : PChar )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.ExibirLinha(Linha, AText);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_ExibirLinhaAlinhamento(const disHandle: PDISHandle; const Linha : Integer ; const AText : PChar; const Alinhamento : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.ExibirLinha(Linha, AText, TACBrDISAlinhamento(Alinhamento));
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function DIS_ExibirLinhaEfeito(const disHandle: PDISHandle; const Linha : Integer ; const AText : PChar; const Efeito : Integer )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.ExibirLinha(Linha, AText, TACBrDISEfeitoExibir(Efeito));
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_RolarLinha(const disHandle: PDISHandle; const Linha : Integer ; const Efeito : TACBrDISEfeitoRolar )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.RolarLinha(Linha, TACBrDISEfeitoRolar(Efeito));
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_Parar(const disHandle: PDISHandle)  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Parar();
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_Continuar(const disHandle: PDISHandle)  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.Continuar();
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_PararLinha(const disHandle: PDISHandle; const Linha : Integer )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.PararLinha(Linha);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DIS_ContinuarLinha(const disHandle: PDISHandle; const Linha : Integer )  : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     disHandle^.DIS.ContinuarLinha(Linha);
     Result := 0;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Eventos}

Function DIS_SetOnAtualiza(const disHandle: PDISHandle; const method : TAtualizaCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (disHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if Assigned(method) then
       begin
             disHandle^.DIS.OnAtualiza := disHandle^.EventHandlers.OnAtualiza;
             disHandle^.EventHandlers.OnAtualizaCallback := method;
             Result := 0;
       end
       else
       begin
             disHandle^.DIS.OnAtualiza := nil;
             disHandle^.EventHandlers.OnAtualizaCallback := nil;
             Result := 0;
       end;
  except
     on exception : Exception do
     begin
        disHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

exports

{ Funções }

DIS_Create, DIS_Destroy,
DIS_GetUltimoErro,
DIS_Ativar, DIS_Desativar,

{ Propriedades do Componente }

DIS_GetModelo, DIS_SetModelo, DIS_GetModeloStr,
DIS_GetAtivo,
DIS_GetCursor,
DIS_GetLinhasCount, DIS_SetLinhasCount,
DIS_GetColunas, DIS_SetColunas,
DIS_GetAlinhamento, DIS_SetAlinhamento,
DIS_GetIntervalo, DIS_SetIntervalo,
DIS_GetPassos, DIS_SetPassos,
DIS_GetRemoveAcentos, DIS_SetRemoveAcentos,
DIS_GetIntervaloEnvioBytes, DIS_SetIntervaloEnvioBytes,
DIS_GetTrabalhando,

{Métodos}

DIS_LimparDisplay,
DIS_LimparLinha,
DIS_PosicionarCursor,
DIS_Escrever,
DIS_ExibirLinha,
DIS_ExibirLinhaAlinhamento,
DIS_ExibirLinhaEfeito,
DIS_RolarLinha,
DIS_Parar,
DIS_Continuar,
DIS_PararLinha,
DIS_ContinuarLinha,

{Eventos}
DIS_SetOnAtualiza;


end.
