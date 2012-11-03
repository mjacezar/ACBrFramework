unit ACBrTEFDll;


interface

uses
  SysUtils,
  Classes,
  ACBrTEFD,
  ACBrTEFDClass,
  ACBrUtil,
  ACBrCommonDll;

{Ponteiros para classes expostas}
type PTEFResp = ^TACBrTEFDResp;
type PTEFRespostasPendentes = ^TACBrTEFDRespostasPendentes;
type PTEFReq = ^TACBrTEFDReq;

{ Ponteiros de função }
type TAguardaRespCallback = procedure(const Arquivo: PChar; const SegundosTimeOut : Integer; var Interromper : Boolean); cdecl;
type TExibeMsgCallback = procedure(const Operacao : TACBrTEFDOperacaoMensagem; const Mensagem : PChar; var AModalResult : TModalResult); cdecl;
type TBloqueiaMouseTecladoCallback = procedure(const Bloqueia : Boolean; var Tratado : Boolean); cdecl;
type TExecutaAcaoCallback = procedure(var Tratado : Boolean); cdecl;
type TComandaECFCallback = procedure(const Operacao : TACBrTEFDOperacaoECF; const Resp : PTEFResp; var RetornoECF : Integer ); cdecl;
type TComandaECFSubtotalizaCallback = procedure(const DescAcre : Double; var RetornoECF : Integer ); cdecl;
type TComandaECFPagamentoCallback = procedure(const IndiceECF : PChar; const Valor : Double; var RetornoECF : Integer);  cdecl;
type TComandaECFAbreVinculadoCallback = procedure(const COO : PChar; const IndiceECF : PChar; const Valor : Double; var RetornoECF : Integer ); cdecl;
type TComandaECFImprimeViaCallback = procedure(const TipoRelatorio : TACBrTEFDTipoRelatorio; const Via : Integer; const ImagemComprovante : array of PChar; const ImagemComprovanteCount : Integer; var RetornoECF : Integer ); cdecl;
type TInfoECFCallback =  procedure(const Operacao : TACBrTEFDInfoECF; var RetornoECF : Integer); cdecl;
type TAntesFinalizarRequisicaoCallback = procedure(const Req : PTEFResp ); cdecl;
type TDepoisConfirmarTransacoes = procedure(const RespostasPendentes : PTEFRespostasPendentes ); cdecl;
type TAntesCancelarTransacaoCallback = procedure(const RespostaPendente : PTEFResp); cdecl;
type TDepoisCancelarTransacoesCallback = procedure(const RespostasPendentes : PTEFRespostasPendentes); cdecl;
type TMudaEstadoReqCallback =  procedure(const EstadoReq  : TACBrTEFDReqEstado); cdecl;
type TMudaEstadoRespCallback = procedure(const EstadoResp : TACBrTEFDRespEstado); cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class

  OnAguardaRespCallback : TAguardaRespCallback;
  OnExibeMsgCallback : TExibeMsgCallback;
  OnBloqueiaMouseTecladoCallback : TBloqueiaMouseTecladoCallback;
  OnRestauraFocoAplicacaoCallback : TExecutaAcaoCallback;
  OnLimpaTecladoCallback : TExecutaAcaoCallback;
  OnComandaECFCallback : TComandaECFCallback;
  OnComandaECFSubtotalizaCallback : TComandaECFSubtotalizaCallback;
  OnComandaECFPagamentoCallback : TComandaECFPagamentoCallback;
  OnComandaECFAbreVinculadoCallback : TComandaECFAbreVinculadoCallback;
  OnComandaECFImprimeViaCallback : TComandaECFImprimeViaCallback;
  OnInfoECFCallback : TInfoECFCallback;
  OnAntesFinalizarRequisicaoCallback : TAntesFinalizarRequisicaoCallback;
  OnDepoisConfirmarTransacoesCallback : TDepoisConfirmarTransacoes;
  OnAntesCancelarTransacaoCallback : TAntesCancelarTransacaoCallback;
  OnDepoisCancelarTransacoesCallback :  TDepoisCancelarTransacoesCallback;
  OnMudaEstadoReqCallback : TMudaEstadoReqCallback;
  OnMudaEstadoRespCallback : TMudaEstadoRespCallback;

  procedure OnAguardaResp(Arquivo: String; SegundosTimeOut : Integer; var Interromper : Boolean);
  procedure OnExibeMsg(Operacao : TACBrTEFDOperacaoMensagem; Mensagem : String; var AModalResult : TModalResult);
  procedure OnBloqueiaMouseTeclado(Bloqueia : Boolean; var Tratado : Boolean);
  procedure OnRestauraFocoAplicacao(var Tratado : Boolean);
  procedure OnLimpaTeclado(var Tratado : Boolean);
  procedure OnComandaECF(Operacao : TACBrTEFDOperacaoECF; Resp : TACBrTEFDResp; var RetornoECF : Integer);
  procedure OnComandaECFSubtotaliza(DescAcre : Double; var RetornoECF : Integer);
  procedure OnComandaECFPagamento(IndiceECF : String; Valor : Double; var RetornoECF : Integer);
  procedure OnComandaECFAbreVinculado(COO, IndiceECF : String; Valor : Double; var RetornoECF : Integer);
  procedure OnComandaECFImprimeVia(TipoRelatorio : TACBrTEFDTipoRelatorio; Via : Integer; ImagemComprovante : TStringList; var RetornoECF : Integer );
  procedure OnInfoECF(Operacao : TACBrTEFDInfoECF; var RetornoECF : String );
  procedure OnAntesFinalizarRequisicao(Req : TACBrTEFDReq);
  procedure OnDepoisConfirmarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
  procedure OnAntesCancelarTransacao(RespostaPendente : TACBrTEFDResp);
  procedure OnDepoisCancelarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
  procedure OnMudaEstadoReq(EstadoReq  : TACBrTEFDReqEstado);
  procedure OnMudaEstadoResp(EstadoResp : TACBrTEFDRespEstado);

end;

{Handle para o componente TACBrTEFD }
type TTEFHandle = record
  UltimoErro : String;
  TEF : TACBrTEFD;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PTEFHandle = ^TTEFHandle;

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

OnAguardaResp
TACBrTEFDAguardaRespEvent
procedure( Arquivo: String;
     SegundosTimeOut : Integer; var Interromper : Boolean)

OnExibeMsg
TACBrTEFDExibeMsg
procedure( Operacao : TACBrTEFDOperacaoMensagem;
     Mensagem : String; var AModalResult : TModalResult )


OnBloqueiaMouseTeclado
TACBrTEFDBloqueiaMouseTeclado
 procedure( Bloqueia : Boolean;
     var Tratado : Boolean )


OnRestauraFocoAplicacao, OnLimpaTeclado,
TACBrTEFDExecutaAcao
procedure( var Tratado : Boolean ) *TACBrTEFDExecutaAcao




OnComandaECF
TACBrTEFDComandaECF
procedure( Operacao : TACBrTEFDOperacaoECF; Resp : TACBrTEFDResp;
     var RetornoECF : Integer )

OnComandaECFSubtotaliza
TACBrTEFDComandaECFSubtotaliza
procedure( DescAcre : Double;
     var RetornoECF : Integer )

OnComandaECFPagamento
TACBrTEFDComandaECFPagamento
procedure( IndiceECF : String; Valor : Double;
     var RetornoECF : Integer )


OnComandaECFAbreVinculado
TACBrTEFDComandaECFAbreVinculado
procedure( COO, IndiceECF : String; Valor : Double;
     var RetornoECF : Integer )

OnComandaECFImprimeVia
TACBrTEFDComandaECFImprimeVia
procedure( TipoRelatorio : TACBrTEFDTipoRelatorio;
     Via : Integer; ImagemComprovante : TStringList;
     var RetornoECF : Integer )



OnInfoECF
TACBrTEFDObterInfoECF
procedure( Operacao : TACBrTEFDInfoECF;
     var RetornoECF : String  )


OnAntesFinalizarRequisicao
TACBrTEFDAntesFinalizarReq
procedure( Req : TACBrTEFDReq )


OnDepoisConfirmarTransacoes
TACBrTEFDProcessarTransacoesPendentes
procedure( RespostasPendentes :
     TACBrTEFDRespostasPendentes )


OnAntesCancelarTransacao
TACBrTEFDAntesCancelarTransacao
procedure( RespostaPendente :
     TACBrTEFDResp )


OnDepoisCancelarTransacoes
TACBrTEFDProcessarTransacoesPendentes
procedure( RespostasPendentes :
     TACBrTEFDRespostasPendentes )

OnMudaEstadoReq
TACBrTEFDMudaEstadoReq
procedure( EstadoReq  : TACBrTEFDReqEstado  )


OnMudaEstadoResp
TACBrTEFDMudaEstadoResp
procedure( EstadoResp : TACBrTEFDRespEstado )

}


{
CRIA um novo componente TACBrECF retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrECF
}
Function TEF_Create(var tefHandle: PTEFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(tefHandle);

     tefHandle^.TEF := TACBrTEFD.Create(nil);
     tefHandle^.EventHandlers := TEventHandlers.Create();
     tefHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        tefHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrECF e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function TEF_Destroy(var tefHandle: PTEFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    tefHandle^.TEF.Destroy();
    tefHandle^.TEF := nil;

    Dispose(tefHandle);
    tefHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        tefHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function TEF_GetUltimoErro(const tefHandle: PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, tefHandle^.UltimoErro, BufferLen);
     Result := length(tefHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Inicializar(const tefHandle : PTEFHandle; GP : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Inicializar(TACBrTEFDTipo(GP));
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_CRT(const tefHandle : PTEFHandle; const Valor : Double; const IndiceFPG_ECF : PChar; const DocumentoVinculado : PChar; const Moeda : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  ret : Boolean;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ret := tefHandle^.TEF.CRT(Valor, IndiceFPG_ECF, DocumentoVinculado, Moeda);
     if (ret) then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_GetGPAtual(const tefHandle : PTEFHandle): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(tefHandle^.TEF.GPAtual);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;


end;

Function TEF_SetGPAtual(const tefHandle : PTEFHandle; GP : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.GPAtual := TACBrTEFDTipo(GP);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


{Set de Eventos}
Function TEF_SetOnAguardaResp(const tefHandle: PTEFHandle; const method : TAguardaRespCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.OnAguardaResp := tefHandle^.EventHandlers.OnAguardaResp;
        tefHandle^.EventHandlers.OnAguardaRespCallback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.OnAguardaResp := nil;
        tefHandle^.EventHandlers.OnAguardaRespCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetOnExibeMsg(const tefHandle: PTEFHandle; const method : TExibeMsgCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.OnExibeMsg := tefHandle^.EventHandlers.OnExibeMsg;
        tefHandle^.EventHandlers.OnExibeMsgCallback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.OnExibeMsg := nil;
        tefHandle^.EventHandlers.OnExibeMsgCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetOnBloqueiaMouseTeclado(const tefHandle: PTEFHandle; const method : TBloqueiaMouseTecladoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnBloqueiaMouseTeclado := tefHandle^.EventHandlers.OnBloqueiaMouseTeclado;
          tefHandle^.EventHandlers.OnBloqueiaMouseTecladoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnBloqueiaMouseTeclado := nil;
          tefHandle^.EventHandlers.OnBloqueiaMouseTecladoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnRestauraFocoAplicacao(const tefHandle: PTEFHandle; const method : TExecutaAcaoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
     if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnRestauraFocoAplicacao := tefHandle^.EventHandlers.OnRestauraFocoAplicacao;
          tefHandle^.EventHandlers.OnRestauraFocoAplicacaoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnRestauraFocoAplicacao := nil;
          tefHandle^.EventHandlers.OnRestauraFocoAplicacaoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnLimpaTeclado(const tefHandle: PTEFHandle; const method : TExecutaAcaoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnLimpaTeclado := tefHandle^.EventHandlers.OnLimpaTeclado;
          tefHandle^.EventHandlers.OnLimpaTecladoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnLimpaTeclado := nil;
          tefHandle^.EventHandlers.OnLimpaTecladoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnComandaECF(const tefHandle: PTEFHandle; const method : TComandaECFCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnComandaECF := tefHandle^.EventHandlers.OnComandaECF;
          tefHandle^.EventHandlers.OnComandaECFCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnComandaECF := nil;
          tefHandle^.EventHandlers.OnComandaECFCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnComandaECFSubtotaliza(const tefHandle: PTEFHandle; const method : TComandaECFSubtotalizaCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnComandaECFSubtotaliza := tefHandle^.EventHandlers.OnComandaECFSubtotaliza;
          tefHandle^.EventHandlers.OnComandaECFSubtotalizaCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnComandaECFSubtotaliza := nil;
          tefHandle^.EventHandlers.OnComandaECFSubtotalizaCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnComandaECFPagamento(const tefHandle: PTEFHandle; const method : TComandaECFPagamentoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnComandaECFPagamento := tefHandle^.EventHandlers.OnComandaECFPagamento;
          tefHandle^.EventHandlers.OnComandaECFPagamentoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnComandaECFPagamento := nil;
          tefHandle^.EventHandlers.OnComandaECFPagamentoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnComandaECFAbreVinculado(const tefHandle: PTEFHandle; const method : TComandaECFAbreVinculadoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnComandaECFAbreVinculado := tefHandle^.EventHandlers.OnComandaECFAbreVinculado;
          tefHandle^.EventHandlers.OnComandaECFAbreVinculadoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnComandaECFAbreVinculado := nil;
          tefHandle^.EventHandlers.OnComandaECFAbreVinculadoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnComandaECFImprimeVia(const tefHandle: PTEFHandle; const method : TComandaECFImprimeViaCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnComandaECFImprimeVia := tefHandle^.EventHandlers.OnComandaECFImprimeVia;
          tefHandle^.EventHandlers.OnComandaECFImprimeViaCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnComandaECFImprimeVia := nil;
          tefHandle^.EventHandlers.OnComandaECFImprimeViaCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnInfoECF(const tefHandle: PTEFHandle; const method : TInfoECFCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnInfoECF := tefHandle^.EventHandlers.OnInfoECF;
          tefHandle^.EventHandlers.OnInfoECFCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnInfoECF := nil;
          tefHandle^.EventHandlers.OnInfoECFCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnAntesFinalizarRequisicao(const tefHandle: PTEFHandle; const method : TAntesFinalizarRequisicaoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnAntesFinalizarRequisicao := tefHandle^.EventHandlers.OnAntesFinalizarRequisicao;
          tefHandle^.EventHandlers.OnAntesFinalizarRequisicaoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnAntesFinalizarRequisicao := nil;
          tefHandle^.EventHandlers.OnAntesFinalizarRequisicaoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnDepoisConfirmarTransacoes(const tefHandle: PTEFHandle; const method : TDepoisConfirmarTransacoes) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnDepoisConfirmarTransacoes := tefHandle^.EventHandlers.OnDepoisConfirmarTransacoes;
          tefHandle^.EventHandlers.OnDepoisConfirmarTransacoesCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnDepoisConfirmarTransacoes := nil;
          tefHandle^.EventHandlers.OnDepoisConfirmarTransacoesCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnAntesCancelarTransacao(const tefHandle: PTEFHandle; const method : TAntesCancelarTransacaoCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnAntesCancelarTransacao := tefHandle^.EventHandlers.OnAntesCancelarTransacao;
          tefHandle^.EventHandlers.OnAntesCancelarTransacaoCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnAntesCancelarTransacao := nil;
          tefHandle^.EventHandlers.OnAntesCancelarTransacaoCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnDepoisCancelarTransacoes(const tefHandle: PTEFHandle; const method : TDepoisCancelarTransacoesCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnDepoisCancelarTransacoes := tefHandle^.EventHandlers.OnDepoisCancelarTransacoes;
          tefHandle^.EventHandlers.OnDepoisCancelarTransacoesCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnDepoisCancelarTransacoes := nil;
          tefHandle^.EventHandlers.OnDepoisCancelarTransacoesCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnMudaEstadoReq(const tefHandle: PTEFHandle; const method : TMudaEstadoReqCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnMudaEstadoReq := tefHandle^.EventHandlers.OnMudaEstadoReq;
          tefHandle^.EventHandlers.OnMudaEstadoReqCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnMudaEstadoReq := nil;
          tefHandle^.EventHandlers.OnMudaEstadoReqCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

Function TEF_SetOnMudaEstadoResp(const tefHandle: PTEFHandle; const method : TMudaEstadoRespCallback) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
    if (tefHandle = nil) then
    begin
       Result := -2;
       Exit;
    end;

    try
    if Assigned(method) then
    begin
          tefHandle^.TEF.OnMudaEstadoResp := tefHandle^.EventHandlers.OnMudaEstadoResp;
          tefHandle^.EventHandlers.OnMudaEstadoRespCallback := method;
          Result := 0;
    end
    else
    begin
          tefHandle^.TEF.OnMudaEstadoResp := nil;
          tefHandle^.EventHandlers.OnMudaEstadoRespCallback := nil;
          Result := 0;
    end;
    except
       on exception : Exception do
       begin
          tefHandle^.UltimoErro := exception.Message;
          Result := -1;
       end
    end;
end;

{Eventos}

procedure TEventHandlers.OnAguardaResp(Arquivo: String; SegundosTimeOut : Integer; var Interromper : Boolean);
begin
   OnAguardaRespCallback(@Arquivo, SegundosTimeOut, Interromper);
end;

procedure TEventHandlers.OnExibeMsg(Operacao : TACBrTEFDOperacaoMensagem; Mensagem : String; var AModalResult : TModalResult);
begin
   OnExibeMsgCallback(Operacao, @Mensagem, AModalResult);
end;

procedure TEventHandlers.OnBloqueiaMouseTeclado(Bloqueia : Boolean; var Tratado : Boolean);
begin
   OnBloqueiaMouseTecladoCallback(Bloqueia, Tratado);
end;

procedure TEventHandlers.OnRestauraFocoAplicacao(var Tratado : Boolean);
begin
   OnRestauraFocoAplicacaoCallback(Tratado);
end;

procedure TEventHandlers.OnLimpaTeclado(var Tratado : Boolean);
begin
   OnLimpaTecladoCallback(Tratado);
end;

procedure TEventHandlers.OnComandaECF(Operacao : TACBrTEFDOperacaoECF; Resp : TACBrTEFDResp; var RetornoECF : Integer);
begin
   OnComandaECFCallback(Operacao, @Resp, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFSubtotaliza(DescAcre : Double; var RetornoECF : Integer);
begin
  OnComandaECFSubtotalizaCallback(DescAcre, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFPagamento(IndiceECF : String; Valor : Double; var RetornoECF : Integer);
begin
  OnComandaECFPagamentoCallback(@IndiceECF, Valor, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFAbreVinculado(COO, IndiceECF : String; Valor : Double; var RetornoECF : Integer);
begin
  OnComandaECFAbreVinculadoCallback(@COO, @IndiceECF, Valor, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFImprimeVia(TipoRelatorio : TACBrTEFDTipoRelatorio; Via : Integer; ImagemComprovante : TStringList; var RetornoECF : Integer );
var
  i : Integer;
  linha : String;
  imagem : array of PChar;
begin

   SetLength(imagem, ImagemComprovante.Count);
   for i := 0 TO ImagemComprovante.Count do
   Begin
        linha := ImagemComprovante.ValueFromIndex[i];
        imagem[i] := @linha;
   end;

   OnComandaECFImprimeViaCallback(TipoRelatorio, Via, imagem, ImagemComprovante.Count, RetornoECF);

   SetLength(imagem, 0);
end;

procedure TEventHandlers.OnInfoECF(Operacao : TACBrTEFDInfoECF; var RetornoECF : String );
var
  retorno : Integer;
begin
    OnInfoECFCallback(Operacao, retorno);
    RetornoECF := IntToStr(retorno);
end;

procedure TEventHandlers.OnAntesFinalizarRequisicao(Req : TACBrTEFDReq);
begin
    OnAntesFinalizarRequisicaoCallback(@Req);
end;

procedure TEventHandlers.OnDepoisConfirmarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
begin
     OnDepoisConfirmarTransacoesCallback(@RespostasPendentes);
end;

procedure TEventHandlers.OnAntesCancelarTransacao(RespostaPendente : TACBrTEFDResp);
begin
     OnAntesCancelarTransacaoCallback(@RespostaPendente);
end;

procedure TEventHandlers.OnDepoisCancelarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
begin
     OnDepoisCancelarTransacoesCallback(@RespostasPendentes);
end;

procedure TEventHandlers.OnMudaEstadoReq(EstadoReq  : TACBrTEFDReqEstado);
begin
   OnMudaEstadoReqCallback(EstadoReq);
end;

procedure TEventHandlers.OnMudaEstadoResp(EstadoResp : TACBrTEFDRespEstado);
begin
  OnMudaEstadoRespCallback(EstadoResp);
end;

exports

{ Funções }
TEF_Create, TEF_Destroy,
TEF_GetUltimoErro,

TEF_Inicializar,
TEF_GetGPAtual, TEF_SetGPAtual,
TEF_CRT,

{Eventos}

TEF_SetOnAguardaResp,
TEF_SetOnExibeMsg,
TEF_SetOnBloqueiaMouseTeclado,
TEF_SetOnRestauraFocoAplicacao,
TEF_SetOnLimpaTeclado,
TEF_SetOnComandaECF,
TEF_SetOnComandaECFSubtotaliza,
TEF_SetOnComandaECFPagamento,
TEF_SetOnComandaECFAbreVinculado,
TEF_SetOnComandaECFImprimeVia,
TEF_SetOnInfoECF,
TEF_SetOnAntesFinalizarRequisicao,
TEF_SetOnDepoisConfirmarTransacoes,
TEF_SetOnAntesCancelarTransacao,
TEF_SetOnDepoisCancelarTransacoes,
TEF_SetOnMudaEstadoReq,
TEF_SetOnMudaEstadoResp

;

end.
