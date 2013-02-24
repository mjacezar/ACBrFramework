unit ACBrSMSDll;

{$mode delphi}

interface

uses
  Classes, SysUtils,
  ACBrSMSClass, ACBrSMS;

{CallBack Eventos}
type TOnProgressoCallback = procedure(const AAtual, ATotal: Integer); cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
  OnProgressoCallback : TOnProgressoCallback;
  procedure OnProgresso(const AAtual, ATotal: Integer);
end;

{%region Handle para o componente TACBrECF }

type TSMSHandle = record
  UltimoErro : String;
  SMS : TACBrSMS;
  EventHandlers : TEventHandlers;
end;

type TMSGCHandle = record
  UltimoErro : String;
  Menssagens : TACBrSMSMensagens;
end;

type TMSGHandle = record
  UltimoErro : String;
  Menssagem : TACBrSMSMensagem;
end;

{Ponteiro para o Handle }
type PSMSHandle = ^TSMSHandle;
type PMSGCHandle = ^TMSGCHandle;
type PMSGHandle = ^TMSGHandle;

{%endregion}

implementation

{%region Constructor/Destructor/Erro}

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
CRIA um novo componente TACBrECF retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrECF
}
Function SMS_Create(var smsHandle: PSMSHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(smsHandle);

     smsHandle^.SMS := TACBrSMS.Create(nil);
     smsHandle^.EventHandlers := TEventHandlers.Create();
     smsHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        smsHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrECF e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function SMS_Destroy(smsHandle: PSMSHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    smsHandle^.SMS.Destroy();
    smsHandle^.SMS := nil;

    Dispose(smsHandle);
    smsHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        smsHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SMS_GetUltimoErro(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.UltimoErro, BufferLen);
     Result := length(smsHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function SMS_GetModelo(const smsHandle: PSMSHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(smsHandle^.SMS.Modelo);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_SetModelo(const smsHandle: PSMSHandle; const Modelo : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.Modelo := TACBrSMSModelo(Modelo);
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_GetAtivo(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if smsHandle^.SMS.Ativo then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetAtivo(const smsHandle: PSMSHandle; const Ativo : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.Ativo := Ativo;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetATResult(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if smsHandle^.SMS.ATResult then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetATResult(const smsHandle: PSMSHandle; const ATResult : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.ATResult := ATResult;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetQuebraMensagens(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if smsHandle^.SMS.QuebraMensagens then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetQuebraMensagens(const smsHandle: PSMSHandle; const QuebraMensagens : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.QuebraMensagens := QuebraMensagens;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetRecebeConfirmacao(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if smsHandle^.SMS.RecebeConfirmacao then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetRecebeConfirmacao(const smsHandle: PSMSHandle; const RecebeConfirmacao : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.RecebeConfirmacao := RecebeConfirmacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetATTimeOut(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := smsHandle^.SMS.ATTimeOut;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetATTimeOut(const smsHandle: PSMSHandle; const ATTimeOut : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.ATTimeOut := ATTimeOut;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetIntervaloEntreMensagens(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := smsHandle^.SMS.IntervaloEntreMensagens;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_SetIntervaloEntreMensagens(const smsHandle: PSMSHandle; const IntervaloEntreMensagens : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.IntervaloEntreMensagens := IntervaloEntreMensagens;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetBandejasSimCard(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := smsHandle^.SMS.BandejasSimCard;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetSimCard(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(smsHandle^.SMS.SimCard);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetUltimaResposta(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.UltimaResposta, BufferLen);
     Result := length(smsHandle^.SMS.UltimaResposta);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetUltimoComando(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.UltimoComando, BufferLen);
     Result := length(smsHandle^.SMS.UltimoComando);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Propriedades - Não Visiveis }

Function SMS_GetEmLinha(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if smsHandle^.SMS.EmLinha then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetIMEI(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.IMEI, BufferLen);
     Result := length(smsHandle^.SMS.IMEI);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetIMSI(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.IMSI, BufferLen);
     Result := length(smsHandle^.SMS.IMSI);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetOperadora(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.Operadora, BufferLen);
     Result := length(smsHandle^.SMS.Operadora);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetFabricante(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.Fabricante, BufferLen);
     Result := length(smsHandle^.SMS.Fabricante);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetModeloModem(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.ModeloModem, BufferLen);
     Result := length(smsHandle^.SMS.ModeloModem);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetFirmware(const smsHandle: PSMSHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, smsHandle^.SMS.Firmware, BufferLen);
     Result := length(smsHandle^.SMS.Firmware);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetEstadoSincronismo(const smsHandle: PSMSHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(smsHandle^.SMS.EstadoSincronismo);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_GetNivelSinal(const smsHandle: PSMSHandle; var Sinal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Sinal := smsHandle^.SMS.NivelSinal;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Metodos Componente}

Function SMS_Ativar(const smsHandle: PSMSHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;

end;

Function SMS_Desativar(const smsHandle: PSMSHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.Desativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_EnviarSMS(const smsHandle: PSMSHandle; const telefone, menssagem : pChar; Buffer : pChar; const BufferLen : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  Indice : AnsiString;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Indice := '';
     smsHandle^.SMS.EnviarSMS(telefone, menssagem, Indice);
     StrPLCopy(Buffer, Indice, BufferLen);
     Result := length(Indice);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_EnviarSMSLote(const smsHandle: PSMSHandle; const msgcHandle: PMSGCHandle; Buffer : pChar; const BufferLen : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  Indice : AnsiString;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  Indice := '';
  smsHandle^.SMS.EnviarSMSLote(msgcHandle^.Menssagens, Indice);
  StrPLCopy(Buffer, Indice, BufferLen);
  Result := length(Indice);
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_ListarMensagens(const smsHandle: PSMSHandle; const filtro : Integer; const path : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.ListarMensagens(TACBrSMSFiltro(filtro), path);
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_TrocarBandeja(const smsHandle: PSMSHandle; const sim : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     smsHandle^.SMS.TrocarBandeja(TACBrSMSSimCard(sim));
     Result := 0;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Mensagems }

Function SMS_MSGC_Create(var msgcHandle: PMSGCHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(msgcHandle);

     msgcHandle^.Menssagens := TACBrSMSMensagens.create();
     msgcHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        msgcHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SMS_MSGC_Destroy(var msgcHandle: PMSGCHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    msgcHandle^.Menssagens.Destroy;
    msgcHandle^.Menssagens := nil;

    Dispose(msgcHandle);
    msgcHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        msgcHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SMS_MSGC_GetUltimoErro(const msgcHandle: PMSGCHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, msgcHandle^.UltimoErro, BufferLen);
     Result := length(msgcHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSGC_Add(const msgcHandle: PMSGCHandle; const msgHandle: PMSGHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgcHandle^.Menssagens.Add(msgHandle^.Menssagem);
     msgHandle^.Menssagem := msgcHandle^.Menssagens[msgcHandle^.Menssagens.Count - 1];
     Result := msgcHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_MSGC_Remove(const msgcHandle: PMSGCHandle; const msgHandle: PMSGHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgcHandle^.Menssagens.Remove(msgHandle^.Menssagem);
     Result := msgcHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_MSGC_Clear(const msgcHandle: PMSGCHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgcHandle^.Menssagens.Clear;
     Result := msgcHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SMS_MSGC_LoadFromFrile(const msgcHandle: PMSGCHandle; const arquivo : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgcHandle^.Menssagens.LoadFromFrile(arquivo);
     Result := msgcHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSGC_GetMSG(const msgcHandle: PMSGCHandle; const msgHandle: PMSGHandle; const idx : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgcHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgHandle^.Menssagem := msgcHandle^.Menssagens[idx];
     Result := 0;
  except
     on exception : Exception do
     begin
        msgcHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Mensagem }

Function SMS_MSG_Create(var msgHandle: PMSGHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(msgHandle);

     msgHandle^.Menssagem.Create;
     msgHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        msgHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SMS_MSG_Destroy(var msgHandle: PMSGHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    msgHandle^.Menssagem.Destroy;
    msgHandle^.Menssagem := nil;

    Dispose(msgHandle);
    msgHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        msgHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SMS_MSG_GetUltimoErro(const msgHandle: PMSGHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, msgHandle^.UltimoErro, BufferLen);
     Result := length(msgHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSG_GetMensagem(const msgHandle: PMSGHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, msgHandle^.Menssagem.Mensagem, BufferLen);
     Result := length(msgHandle^.Menssagem.Mensagem);
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSG_SetMensagem(const msgHandle: PMSGHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgHandle^.Menssagem.Mensagem := value;
     Result := length(msgHandle^.Menssagem.Mensagem);
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSG_GetTelefone(const msgHandle: PMSGHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, msgHandle^.Menssagem.Telefone, BufferLen);
     Result := length(msgHandle^.Menssagem.Telefone);
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SMS_MSG_SetTelefone(const msgHandle: PMSGHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgHandle^.Menssagem.Telefone := value;
     Result := length(msgHandle^.Menssagem.Telefone);
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Eventos }

procedure TEventHandlers.OnProgresso(const AAtual, ATotal: Integer);
begin
     OnProgressoCallback(AAtual, ATotal);
end;

Function SMS_SetOnProgresso(const smsHandle: PSMSHandle; const method : TOnProgressoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (smsHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        smsHandle^.SMS.OnProgresso := smsHandle^.EventHandlers.OnProgresso;
        smsHandle^.EventHandlers.OnProgressoCallback := method;
        Result := 0;
  end
  else
  begin
        smsHandle^.SMS.OnProgresso := nil;
        smsHandle^.EventHandlers.OnProgressoCallback:= nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        smsHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Constructor/Destructor/Erro }
SMS_Create, SMS_Destroy, SMS_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
SMS_GetModelo, SMS_SetModelo, SMS_GetAtivo, SMS_SetAtivo,
SMS_GetATResult, SMS_SetATResult, SMS_GetATTimeOut, SMS_SetATTimeOut,
SMS_GetBandejasSimCard, SMS_GetSimCard, SMS_GetQuebraMensagens, SMS_SetQuebraMensagens,
SMS_GetRecebeConfirmacao, SMS_SetRecebeConfirmacao, SMS_GetUltimaResposta, SMS_GetUltimoComando,
SMS_GetIntervaloEntreMensagens, SMS_SetIntervaloEntreMensagens, SMS_GetNivelSinal,

{ Propriedades - Não Visiveis }
SMS_GetEmLinha, SMS_GetIMEI, SMS_GetIMSI, SMS_GetOperadora, SMS_GetFabricante,
SMS_GetModeloModem, SMS_GetFirmware, SMS_GetEstadoSincronismo,

{ Metodos Componente }
SMS_Ativar, SMS_Desativar, SMS_EnviarSMS, SMS_EnviarSMSLote,
SMS_ListarMensagens,

{ Mensagens }
SMS_MSGC_Create, SMS_MSGC_Destroy, SMS_MSGC_GetUltimoErro, SMS_MSGC_Add,
SMS_MSGC_Remove, SMS_MSGC_Clear, SMS_MSGC_LoadFromFrile, SMS_MSGC_GetMSG,

{ Mensagem }
SMS_MSG_Create, SMS_MSG_Destroy, SMS_MSG_GetUltimoErro,
SMS_MSG_GetMensagem, SMS_MSG_SetMensagem,
SMS_MSG_GetTelefone, SMS_MSG_SetTelefone,

{ Eventos }
SMS_SetOnProgresso;
end.

