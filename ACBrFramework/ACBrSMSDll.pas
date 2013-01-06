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

{Handle para o componente TACBrECF }
type TSMSHandle = record
  UltimoErro : String;
  SMS : TACBrSMS;
  EventHandlers : TEventHandlers;
  Menssagens    : TACBrSMSMensagens;
end;

type TMSGHandle = record
  UltimoErro : String;
  Menssagens : TACBrSMSMensagens;
end;

{Ponteiro para o Handle }
type PSMSHandle = ^TSMSHandle;
type PMSGHandle = ^TMSGHandle;

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
Function SMS_Destroy(var smsHandle: PSMSHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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

Function SMS_EnviarSMSLote(const smsHandle: PSMSHandle; const msgHandle: PMSGHandle; Buffer : pChar; const BufferLen : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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
  smsHandle^.SMS.EnviarSMSLote(msgHandle^.Menssagens, Indice);
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

{%region Mensagem }

Function MSG_Create(var msgHandle: PMSGHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(msgHandle);

     msgHandle^.Menssagens := TACBrSMSMensagens.create();
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

Function MSG_Destroy(var msgHandle: PMSGHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    msgHandle^.Menssagens.Destroy;
    msgHandle^.Menssagens := nil;

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

Function MSG_GetUltimoErro(const msgHandle: PMSGHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function MSG_Add(const msgHandle: PMSGHandle; const telefone, mensagem : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  msg : TACBrSMSMensagem;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msg.Create;
     msg.Telefone := telefone;
     msg.Mensagem := mensagem;
     msgHandle^.Menssagens.Add(msg);
     Result := msgHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function MSG_LoadFromFrile(const msgHandle: PMSGHandle; const arquivo : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     msgHandle^.Menssagens.LoadFromFrile(arquivo);
     Result := msgHandle^.Menssagens.Count;
  except
     on exception : Exception do
     begin
        msgHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function MSG_GetMensagem(const msgHandle: PMSGHandle; telefone, menssagem : pChar;
             const BufferLen : Integer; const Index : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (msgHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(telefone, msgHandle^.Menssagens[Index].Telefone, BufferLen);
     StrPLCopy(menssagem, msgHandle^.Menssagens[Index].Mensagem, BufferLen);
     Result := 0;
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
MSG_Create, MSG_Destroy, MSG_GetUltimoErro, MSG_Add,
MSG_LoadFromFrile, MSG_GetMensagem,

{ Eventos }
SMS_SetOnProgresso;
end.

