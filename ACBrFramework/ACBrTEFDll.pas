unit ACBrTEFDll;


interface

uses
  SysUtils,
  Classes,
  ACBrTEFD,
  ACBrTEFDClass,
  ACBrTEFDCliSiTef,
  ACBrTEFDVeSPague,
  ACBrUtil;

{%region Ponteiros de função}

type TAguardaRespCallback = procedure(const Arquivo: PChar; const SegundosTimeOut : Integer; var Interromper : Boolean); cdecl;
type TExibeMsgCallback = procedure(const Operacao : Integer; const Mensagem : PChar; var AModalResult : TModalResult); cdecl;
type TBloqueiaMouseTecladoCallback = procedure(const Bloqueia : Boolean; var Tratado : Boolean); cdecl;
type TExecutaAcaoCallback = procedure(var Tratado : Boolean); cdecl;
type TComandaECFCallback = procedure(const Operacao : Integer; const Resp : TACBrTEFDResp; var RetornoECF : Integer ); cdecl;
type TComandaECFSubtotalizaCallback = procedure(const DescAcre : Double; var RetornoECF : Integer ); cdecl;
type TComandaECFPagamentoCallback = procedure(const IndiceECF : PChar; const Valor : Double; var RetornoECF : Integer);  cdecl;
type TComandaECFAbreVinculadoCallback = procedure(const COO : PChar; const IndiceECF : PChar; const Valor : Double; var RetornoECF : Integer ); cdecl;
type TComandaECFImprimeViaCallback = procedure(const TipoRelatorio : Integer; const Via : Integer; const ImagemComprovante : array of PChar; const ImagemComprovanteCount : Integer; var RetornoECF : Integer ); cdecl;
type TInfoECFCallback =  procedure(const Operacao : Integer; const RetornoECF : PChar; const RetornoECFLen : Integer); cdecl;
type TAntesFinalizarRequisicaoCallback = procedure(const Req : TACBrTEFDReq ); cdecl;
type TDepoisConfirmarTransacoes = procedure(const RespostasPendentes : TACBrTEFDRespostasPendentes ); cdecl;
type TAntesCancelarTransacaoCallback = procedure(const RespostaPendente : TACBrTEFDResp); cdecl;
type TDepoisCancelarTransacoesCallback = procedure(const RespostasPendentes : TACBrTEFDRespostasPendentes); cdecl;
type TMudaEstadoReqCallback =  procedure(const EstadoReq  : Integer); cdecl;
type TMudaEstadoRespCallback = procedure(const EstadoResp : Integer); cdecl;
type TTEFCliSiTefExibeMenuCallback = procedure(const Titulo : PChar; const Opcoes : array of PChar; const OpcoesCount : Integer; var ItemSelecionado : Integer; var VoltarMenu : Boolean); cdecl;
type TTEFCliSiTefObtemCampoCalback = procedure(const Titulo : PChar; const TamanhoMinimo : Integer; const TamanhoMaximo : Integer; const TipoCampo : Integer; Operacao : Integer; const Resposta : PChar; const RespLen : Integer; var Digitado : Boolean; var VoltarMenu : Boolean); cdecl;
type TTEFVeSPagueExibeMenuCallback = procedure(const Titulo : PChar; const Opcoes : array of PChar; const OpcoesCount : Integer; const Memo : array of PChar; const MemoCount : Integer; var ItemSelecionado : Integer); cdecl;
type TTEFVeSPagueObtemCampoCalback = procedure(const Titulo : PChar; const Mascara : PChar; const Tipo : Char; var Resposta : PChar; var Digitado : Boolean); cdecl;

{%endregion}

{%region Classe que armazena os EventHandlers para o componente ACBr}

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

  OnTEFCliSiTefExibeMenuCallback : TTEFCliSiTefExibeMenuCallback;
  OnTEFCliSiTefObtemCampoCalback : TTEFCliSiTefObtemCampoCalback;

  OnTEFVeSPagueExibeMenuCallback : TTEFVeSPagueExibeMenuCallback;
  OnTEFVeSPagueObtemCampoCalback : TTEFVeSPagueObtemCampoCalback;

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

  procedure OnTEFCliSiTefExibeMenu(Titulo : String; Opcoes : TStringList; var ItemSelecionado : Integer; var VoltarMenu : Boolean);
  procedure OnTEFCliSiTefObtemCampo(Titulo : String; TamanhoMinimo, TamanhoMaximo : Integer ; TipoCampo : Integer; Operacao : TACBrTEFDCliSiTefOperacaoCampo; var Resposta : AnsiString; var Digitado : Boolean; var VoltarMenu : Boolean );

  procedure OnTEFVeSPagueExibeMenu(Titulo : String; Opcoes : TStringList; Memo: TStringList; var ItemSelecionado : Integer);
  procedure OnTEFVeSPagueObtemCampo(Titulo : String; Mascara : String; Tipo : AnsiChar; var Resposta : String; var Digitado : Boolean);

end;

{%endregion}

{Handle para o componente TACBrTEFD }
type TTEFHandle = record
  UltimoErro : String;
  TEF : TACBrTEFD;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PTEFHandle = ^TTEFHandle;

implementation

{%region Constructor/Destructor}

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
Function TEF_Destroy(tefHandle: PTEFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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

{%endregion}

{%region Propriedades Componente}

Function TEF_SetAutoAtivar(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.AutoAtivarGP := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetAutoAtivar(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.AutoAtivarGP then
        Result:= 1
     Else
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

Function TEF_SetMultiplosCartoes(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.MultiplosCartoes := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetMultiplosCartoes(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.MultiplosCartoes then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetAutoEfetuarPagamento(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.AutoEfetuarPagamento := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetAutoEfetuarPagamento(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.AutoEfetuarPagamento then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetAutoFinalizarCupom(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.AutoFinalizarCupom := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetAutoFinalizarCupom(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.AutoFinalizarCupom then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetCHQEmGerencial(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.CHQEmGerencial := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetCHQEmGerencial(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.CHQEmGerencial then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetEsperaSleep(const tefHandle : PTEFHandle; const Sleep : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.EsperaSleep := Sleep;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetEsperaSleep(const tefHandle : PTEFHandle): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.EsperaSleep;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetEsperaSTS(const tefHandle : PTEFHandle; const STS : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.EsperaSTS := STS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetEsperaSTS(const tefHandle : PTEFHandle): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetNumVias(const tefHandle : PTEFHandle; const Vias : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.NumVias := Vias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetNumVias(const tefHandle : PTEFHandle): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetNumeroMaximoCartoes(const tefHandle : PTEFHandle; const Cartoes : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.NumeroMaximoCartoes := Cartoes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetNumeroMaximoCartoes(const tefHandle : PTEFHandle): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.NumeroMaximoCartoes;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetArqLOG(const tefHandle : PTEFHandle; const Log : pChar): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  tefHandle^.TEF.ArqLOG := Log;
  Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetArqLOG(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  StrTmp := tefHandle^.TEF.ArqLOG;
  StrPLCopy(Buffer, StrTmp, BufferLen);
  Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetExibirMsgAutenticacao(const tefHandle : PTEFHandle; const Ativar : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.ExibirMsgAutenticacao := Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetExibirMsgAutenticacao(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.ExibirMsgAutenticacao then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetPathBackup(const tefHandle : PTEFHandle; const Path: pChar): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  tefHandle^.TEF.PathBackup := Path;
  Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetPathBackup(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  StrTmp := tefHandle^.TEF.PathBackup;
  StrPLCopy(Buffer, StrTmp, BufferLen);
  Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetTrocoMaximo(const tefHandle : PTEFHandle; const troco : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TrocoMaximo := troco;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetTrocoMaximo(const tefHandle : PTEFHandle; var troco : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

   if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     troco := tefHandle^.TEF.TrocoMaximo;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetAbout(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  StrTmp := tefHandle^.TEF.About;
  StrPLCopy(Buffer, StrTmp, BufferLen);
  Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetReq(const tefHandle : PTEFHandle; var reqHandle : TACBrTEFDReq) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     reqHandle := tefHandle^.TEF.Req;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetResp(const tefHandle : PTEFHandle; var respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     respHandle := tefHandle^.TEF.Resp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetRespostasPendentes(const tefHandle : PTEFHandle; var respHandle : TACBrTEFDRespostasPendentes) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     respHandle := tefHandle^.TEF.RespostasPendentes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetSuportaDesconto(const tefHandle : PTEFHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.SuportaDesconto := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetSuportaDesconto(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.SuportaDesconto then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_SetSuportaSaque(const tefHandle : PTEFHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.SuportaSaque := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_GetSuportaSaque(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If tefHandle^.TEF.SuportaSaque then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções TEF}

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

Function TEF_DesInicializar(const tefHandle : PTEFHandle; GP : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.DesInicializar(TACBrTEFDTipo(GP));
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_AtivarGP(const tefHandle : PTEFHandle; GP : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.AtivarGP(TACBrTEFDTipo(GP));
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_ATV(const tefHandle : PTEFHandle; const GP : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.ATV( TACBrTEFDTipo(GP) );
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_ADM(const tefHandle : PTEFHandle; const GP : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  ret : Boolean;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ret := tefHandle^.TEF.ADM( TACBrTEFDTipo(GP) );
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

Function TEF_CNC(const tefHandle : PTEFHandle; const Rede : PChar; const NSU : PChar; const DataHoraTransacao : Double; const Valor : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  ret : Boolean;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ret := tefHandle^.TEF.CNC(Rede, NSU, TDateTime(DataHoraTransacao), Valor);
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

Function TEF_CNF(const tefHandle : PTEFHandle; const Rede : PChar; const NSU : PChar; const Finalizacao : PChar; const DocumentoVinculado : PChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.CNF(Rede, NSU, Finalizacao, DocumentoVinculado);
      Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_NCN(const tefHandle : PTEFHandle; const Rede : PChar; const NSU : PChar; const Finalizacao : PChar; const Valor : Double; const DocumentoVinculado : PChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
      tefHandle^.TEF.NCN(Rede, NSU, Finalizacao, Valor, DocumentoVinculado);
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

Function TEF_CHQ(const tefHandle : PTEFHandle; const Valor : Double; const IndiceFPG_ECF : PChar;
        const DocumentoVinculado : PChar; const CMC7 : PChar;
        const TipoPessoa : Char; const DocumentoPessoa : PChar;
        const DataCheque : Double; const Banco   : PChar;
        const Agencia    : PChar; const AgenciaDC : PChar;
        const Conta      : PChar; const ContaDC   : PChar;
        const Cheque     : PChar; const ChequeDC  : PChar;
        const Compensacao: PChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  ret : Boolean;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     ret := tefHandle^.TEF.CHQ(Valor, IndiceFPG_ECF, DocumentoVinculado, CMC7, TipoPessoa, DocumentoPessoa, DataCheque, Banco, Agencia, AgenciaDC, Conta, ContaDC, Cheque, ChequeDC, Compensacao);
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

Function TEF_CancelarTransacoesPendentes(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.CancelarTransacoesPendentes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_ConfirmarTransacoesPendentes(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.ConfirmarTransacoesPendentes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_ImprimirTransacoesPendentes(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.ImprimirTransacoesPendentes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_FinalizarCupom(const tefHandle : PTEFHandle; const mouse : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.FinalizarCupom(mouse);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Identificacao}

Function TEF_Identificacao_GetNomeAplicacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Identificacao.NomeAplicacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Identificacao_SetNomeAplicacao(const tefHandle : PTEFHandle; const NomeAplicacao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Identificacao.NomeAplicacao := NomeAplicacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Identificacao_GetVersaoAplicacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Identificacao.VersaoAplicacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Identificacao_SetVersaoAplicacao(const tefHandle : PTEFHandle; const VersaoAplicacao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Identificacao.VersaoAplicacao := VersaoAplicacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Identificacao_GetSoftwareHouse(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Identificacao.SoftwareHouse;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Identificacao_SetSoftwareHouse(const tefHandle : PTEFHandle; const SoftwareHouse : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Identificacao.SoftwareHouse := SoftwareHouse;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Identificacao_GetRazaoSocial(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Identificacao.RazaoSocial;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Identificacao_SetRazaoSocial(const tefHandle : PTEFHandle; const RazaoSocial : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Identificacao.RazaoSocial := RazaoSocial;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Req}

Function TEF_Req_GetHeader(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Header;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetHeader(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Header : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Header := Header;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDocumentoVinculado(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.DocumentoVinculado;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetDocumentoVinculado(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const DocumentoVinculado : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.DocumentoVinculado := DocumentoVinculado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetCMC7(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.CMC7;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetCMC7(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const CMC7 : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.CMC7 := CMC7;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDocumentoPessoa(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.DocumentoPessoa;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetDocumentoPessoa(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const DocumentoPessoa : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.DocumentoPessoa := DocumentoPessoa;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetRede(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Rede;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetRede(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Rede : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Rede := Rede;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetNSU(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.NSU;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetNSU(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const NSU : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.NSU := NSU;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetFinalizacao(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Finalizacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetFinalizacao(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Finalizacao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Finalizacao := Finalizacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetBanco(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Banco;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetBanco(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Banco : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Banco := Banco;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetAgencia(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Agencia;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetAgencia(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Agencia : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Agencia := Agencia;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetAgenciaDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.AgenciaDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetAgenciaDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const AgenciaDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.AgenciaDC := AgenciaDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetConta(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Conta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetConta(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Conta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Conta := Conta;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetContaDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.ContaDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetContaDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const ContaDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.ContaDC := ContaDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetCheque(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.Cheque;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetCheque(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Cheque : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Cheque := Cheque;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetChequeDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := reqHandle.ChequeDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Req_SetChequeDC(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const ChequeDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.ChequeDC := ChequeDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function TEF_Req_GetID(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := reqHandle.ID;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetID(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const ID : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.ID := ID;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetMoeda(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := reqHandle.Moeda;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetMoeda(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const Moeda : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.Moeda := Moeda;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetTipoPessoa(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(reqHandle.TipoPessoa);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetTipoPessoa(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const TipoPessoa : AnsiChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.TipoPessoa := TipoPessoa;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetValorTotal(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; var ValorTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ValorTotal := reqHandle.ValorTotal;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetValorTotal(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const ValorTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.ValorTotal := ValorTotal;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDataCheque(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; var DataCheque : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     DataCheque := double(reqHandle.DataCheque);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetDataCheque(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const DataCheque : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.DataCheque := TDateTime(DataCheque);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; var DataHoraTransacaoComprovante : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     DataHoraTransacaoComprovante := double(reqHandle.DataHoraTransacaoComprovante);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; const reqHandle : TACBrTEFDReq; const DataHoraTransacaoComprovante : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     reqHandle.DataHoraTransacaoComprovante := TDateTime(DataHoraTransacaoComprovante);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Resp}

Function TEF_Resp_GetHeader(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Header;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDocumentoVinculado(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.DocumentoVinculado;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCMC7(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.CMC7;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoPessoa(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.TipoPessoa;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDocumentoPessoa(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.DocumentoPessoa;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetRede(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Rede;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetNSU(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.NSU;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetFinalizacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Finalizacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetStatusTransacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.StatusTransacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetNSUTransacaoCancelada(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.NSUTransacaoCancelada;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTextoEspecialOperador(const tefHandle : PTEFHandle;  const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.TextoEspecialOperador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTextoEspecialCliente(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.TextoEspecialOperador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetAutenticacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Autenticacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetBanco(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Banco;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetAgencia(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Agencia;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetAgenciaDC(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.AgenciaDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetConta(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Conta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetContaDC(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ContaDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCheque(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Cheque;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetChequeDC(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ChequeDC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetNomeAdministradora(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.NomeAdministradora;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTrailer(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Trailer;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetArqBackup(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ArqBackup;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetArqRespPendente(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ArqRespPendente;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetIndiceFPG_ECF(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.IndiceFPG_ECF;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetInstituicao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.Instituicao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetModalidadePagto(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ModalidadePagto;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetModalidadePagtoDescrita(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ModalidadePagtoDescrita;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetModalidadeExtenso(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ModalidadeExtenso;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCodigoRedeAutorizada(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.CodigoRedeAutorizada;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetID(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.ID;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetMoeda(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.Moeda;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoTransacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.TipoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCodigoAutorizacaoTransacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.CodigoAutorizacaoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetNumeroLoteTransacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.NumeroLoteTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoParcelamento(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.TipoParcelamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetQtdParcelas(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.QtdParcelas;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetQtdLinhasComprovante(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.QtdLinhasComprovante;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetOrdemPagamento(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.OrdemPagamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoGP(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(respHandle.TipoGP);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetParceladoPor(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(respHandle.ParceladoPor);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoOperacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(respHandle.TipoOperacao);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCNFEnviado(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (respHandle.CNFEnviado) then
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

Function TEF_Resp_GetTransacaoAprovada(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (respHandle.TransacaoAprovada) then
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

Function TEF_Resp_GetDebito(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (respHandle.Debito) then
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

Function TEF_Resp_GetCredito(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (respHandle.Credito) then
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

Function TEF_Resp_GetValorTotal(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var ValorTotal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorTotal := respHandle.ValorTotal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetValorOriginal(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var ValorOriginal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorOriginal := respHandle.ValorOriginal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetSaque(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var Saque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Saque := respHandle.Saque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDesconto(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var Desconto : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Desconto := respHandle.Desconto;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetValorEntradaCDC(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var ValorEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorEntradaCDC := respHandle.ValorEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataCheque(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataCheque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataCheque := respHandle.DataCheque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoHost(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataHoraTransacaoHost : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoHost := respHandle.DataHoraTransacaoHost;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoLocal(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataHoraTransacaoLocal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoLocal := respHandle.DataHoraTransacaoLocal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataPreDatado(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataPreDatado : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataPreDatado := respHandle.DataPreDatado;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoCancelada(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataHoraTransacaoCancelada : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoCancelada := respHandle.DataHoraTransacaoCancelada;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataHoraTransacaoComprovante : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoComprovante := respHandle.DataHoraTransacaoComprovante;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataVencimento(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataVencimento : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataVencimento := respHandle.DataVencimento;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataEntradaCDC(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; var DataEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataEntradaCDC := respHandle.DataEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante1aViaCount(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := respHandle.ImagemComprovante1aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante1aViaLinha(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer; const linha : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ImagemComprovante1aVia[linha];
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante2aViaCount(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := respHandle.ImagemComprovante2aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante2aViaLinha(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen : Integer; const linha : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.ImagemComprovante2aVia[linha];
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_LeInformacao(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDResp; Buffer : pChar; const BufferLen, Identificacao, Sequencia  : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := respHandle.LeInformacao(Identificacao, Sequencia).AsString;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

//Parcelas : TACBrTEFDRespParcelas read fpParcelas ;
{%endregion}

{%region Respostas Pendentes}

Function TEF_RespostasPendentes_GetSaldoAPagar(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDRespostasPendentes; var SaldoAPagar : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     SaldoAPagar := respHandle.SaldoAPagar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetItem(const tefHandle : PTEFHandle; const respPendenteHandle : TACBrTEFDRespostasPendentes; const index : Integer; var respHandle : TACBrTEFDResp) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     respHandle := respPendenteHandle[index];
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTotalPago(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDRespostasPendentes; var TotalPago : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     TotalPago := respHandle.TotalPago;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTotalDesconto(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDRespostasPendentes; var TotalDesconto : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     TotalDesconto := respHandle.TotalDesconto;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetSaldoRestante(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDRespostasPendentes; var SaldoRestante : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     SaldoRestante := respHandle.SaldoRestante;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetCount(const tefHandle : PTEFHandle; const respHandle : TACBrTEFDRespostasPendentes) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := respHandle.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region TEFCliSiTef}

Function TEF_TEFCliSiTef_GetEnderecoIP(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.EnderecoIP;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetEnderecoIP(const tefHandle : PTEFHandle; const EnderecoIP : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.EnderecoIP := EnderecoIP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetCodigoLoja(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.CodigoLoja;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetCodigoLoja(const tefHandle : PTEFHandle; const CodigoLoja : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.CodigoLoja := CodigoLoja;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetNumeroTerminal(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.NumeroTerminal;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetNumeroTerminal(const tefHandle : PTEFHandle; const NumeroTerminal : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.NumeroTerminal := NumeroTerminal;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperador(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.Operador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetOperador(const tefHandle : PTEFHandle; const Operador : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.Operador := Operador;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetRestricoes(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.Restricoes;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetRestricoes(const tefHandle : PTEFHandle; const Restricoes : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.Restricoes := Restricoes;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCliSiTef.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFCliSiTef.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetParametrosAdicionaisCount(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.ParametrosAdicionais.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetParametrosAdicionais(const tefHandle : PTEFHandle; linha : PChar; const BufferLen, index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (index >= 0) and (index < tefHandle^.TEF.TEFCliSiTef.ParametrosAdicionais.Count ) then
  begin
     strTmp := tefHandle^.TEF.TEFCliSiTef.ParametrosAdicionais[index];
     StrPLCopy(linha, strTmp, BufferLen);
  end;
  Result := 0 ;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetParametrosAdicionais(const tefHandle : PTEFHandle; const linhas : array of PChar; const LinhasCount: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i : Integer;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
      for i := 0 to LinhasCount - 1 do
  begin
  tefHandle^.TEF.TEFCliSiTef.ParametrosAdicionais.Add(linhas[i]);
  end;
  Result := 0 ;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_GetOperacaoATV(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoATV;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoATV(const tefHandle : PTEFHandle; const OperacaoATV : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoATV := OperacaoATV;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperacaoADM(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoADM;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoADM(const tefHandle : PTEFHandle; const OperacaoADM : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoADM := OperacaoADM;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperacaoCRT(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoCRT;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoCRT(const tefHandle : PTEFHandle; const OperacaoCRT : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoCRT := OperacaoCRT;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperacaoCHQ(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoCHQ;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoCHQ(const tefHandle : PTEFHandle; const OperacaoCHQ : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoCHQ := OperacaoCHQ;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperacaoCNC(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoCNC;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoCNC(const tefHandle : PTEFHandle; const OperacaoCNC : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoCNC := OperacaoCNC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_GetOperacaoReImpressao(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCliSiTef.OperacaoReImpressao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOperacaoReImpressao(const tefHandle : PTEFHandle; const OperacaoReImpressao : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCliSiTef.OperacaoReImpressao := OperacaoReImpressao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCliSiTef_SetOnExibeMenu(const tefHandle : PTEFHandle; const method : TTEFCliSiTefExibeMenuCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.TEFCliSiTef.OnExibeMenu := tefHandle^.EventHandlers.OnTEFCliSiTefExibeMenu;
        tefHandle^.EventHandlers.OnTEFCliSiTefExibeMenuCallback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.TEFCliSiTef.OnExibeMenu := nil;
        tefHandle^.EventHandlers.OnTEFCliSiTefExibeMenuCallback := nil;
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

Function TEF_TEFCliSiTef_SetOnObtemCampo(const tefHandle : PTEFHandle; const method : TTEFCliSiTefObtemCampoCalback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.TEFCliSiTef.OnObtemCampo:= tefHandle^.EventHandlers.OnTEFCliSiTefObtemCampo;
        tefHandle^.EventHandlers.OnTEFCliSiTefObtemCampoCalback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.TEFCliSiTef.OnObtemCampo := nil;
        tefHandle^.EventHandlers.OnTEFCliSiTefObtemCampoCalback := nil;
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

Function TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(const tefHandle : PTEFHandle; const mensagem : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  Result := tefHandle^.TEF.TEFCliSiTef.DefineMensagemPermanentePinPad(mensagem);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(const tefHandle : PTEFHandle; const Data : Double ;const Cupom : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  Result := tefHandle^.TEF.TEFCliSiTef.ObtemQuantidadeTransacoesPendentes(Data, Cupom);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region TEFVeSPague}

Function TEF_TEFVeSPague_GetAplicacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.Aplicacao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetAplicacao(const tefHandle : PTEFHandle; const Aplicacao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.Aplicacao := Aplicacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetAplicacaoVersao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.AplicacaoVersao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetAplicacaoVersao(const tefHandle : PTEFHandle; const AplicacaoVersao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.AplicacaoVersao := AplicacaoVersao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetGPExeParams(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.GPExeParams;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetGPExeParams(const tefHandle : PTEFHandle; const GPExeParams : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.GPExeParams := GPExeParams;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetEnderecoIP(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.EnderecoIP;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetEnderecoIP(const tefHandle : PTEFHandle; const EnderecoIP : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.EnderecoIP := EnderecoIP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetPorta(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.Porta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetPorta(const tefHandle : PTEFHandle; const Porta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.Porta := Porta;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTimeOut(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFVeSPague.TimeOut;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_SetTimeOut(const tefHandle : PTEFHandle; const TimeOut : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TimeOut := TimeOut;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTemPendencias(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFVeSPague.TemPendencias then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTemPendencias(const tefHandle : PTEFHandle; const TemPendencias : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TemPendencias := TemPendencias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoADM(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoADM;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoADM(const tefHandle : PTEFHandle; const TransacaoADM : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoADM := TransacaoADM;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoCRT(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoCRT;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoCRT(const tefHandle : PTEFHandle; const TransacaoCRT : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoCRT := TransacaoCRT;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoCHQ(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoCHQ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoCHQ(const tefHandle : PTEFHandle; const TransacaoCHQ : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoCHQ := TransacaoCHQ;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoCNC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoCNC;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoCNC(const tefHandle : PTEFHandle; const TransacaoCNC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoCNC := TransacaoCNC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoOpcao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoOpcao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoOpcao(const tefHandle : PTEFHandle; const TransacaoOpcao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoOpcao := TransacaoOpcao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoReImpressao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoReImpressao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoReImpressao(const tefHandle : PTEFHandle; const TransacaoReImpressao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoReImpressao := TransacaoReImpressao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_GetTransacaoPendente(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFVeSPague.TransacaoPendente;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFVeSPague_SetTransacaoPendente(const tefHandle : PTEFHandle; const TransacaoPendente : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFVeSPague.TransacaoPendente := TransacaoPendente;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFVeSPague_SetOnExibeMenu(const tefHandle : PTEFHandle; const method : TTEFVeSPagueExibeMenuCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.TEFVeSPague.OnExibeMenu := tefHandle^.EventHandlers.OnTEFVeSPagueExibeMenu;
        tefHandle^.EventHandlers.OnTEFVeSPagueExibeMenuCallback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.TEFVeSPague.OnExibeMenu := nil;
        tefHandle^.EventHandlers.OnTEFVeSPagueExibeMenuCallback := nil;
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

Function TEF_TEFVeSPague_SetOnObtemCampo(const tefHandle : PTEFHandle; const method : TTEFVeSPagueObtemCampoCalback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        tefHandle^.TEF.TEFVeSPague.OnObtemCampo:= tefHandle^.EventHandlers.OnTEFVeSPagueObtemCampo;
        tefHandle^.EventHandlers.OnTEFVeSPagueObtemCampoCalback := method;
        Result := 0;
  end
  else
  begin
        tefHandle^.TEF.TEFVeSPague.OnObtemCampo := nil;
        tefHandle^.EventHandlers.OnTEFVeSPagueObtemCampoCalback := nil;
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

{%endregion}

{%region TEFDial}

Function TEF_TEFDial_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFDial.AutoAtivarGP) then
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

Function TEF_TEFDial_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFDial.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFDial.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDial.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDial_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFDial.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDial_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDial.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFDisc}

Function TEF_TEFDisc_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFDisc.AutoAtivarGP) then
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

Function TEF_TEFDisc_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFDisc.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFDisc.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFDisc.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFDisc_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFDisc.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFDisc_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFDisc.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFHiper}

Function TEF_TEFHiper_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFHiper.AutoAtivarGP) then
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

Function TEF_TEFHiper_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFHiper.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFHiper.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFHiper.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFHiper_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFHiper.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFHiper_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFHiper.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFGPU}

Function TEF_TEFGPU_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    if (tefHandle^.TEF.TEFGPU.AutoAtivarGP) then
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

Function TEF_TEFGPU_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.AutoAtivarGP := AutoAtivarGP;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    Result := tefHandle^.TEF.TEFGPU.NumVias;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.NumVias := NumVias;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    Result := tefHandle^.TEF.TEFGPU.EsperaSTS;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.EsperaSTS := EsperaSTS;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFGPU.ArqTemp;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFGPU_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.ArqTemp := ArqTemp;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFGPU.ArqReq;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFGPU_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.ArqReq := ArqReq;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFGPU.ArqSTS;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFGPU_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.ArqSTS := ArqSTS;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFGPU.ArqResp;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFGPU_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.ArqResp := ArqResp;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFGPU.GPExeName;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFGPU_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFGPU.GPExeName := GPExeName;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFGPU_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGPU.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGPU_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGPU.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGPU_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFGPU.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGPU_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGPU.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFAuttar}

Function TEF_TEFAuttar_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFAuttar.AutoAtivarGP) then
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

Function TEF_TEFAuttar_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFAuttar.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFAuttar.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFAuttar.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFAuttar_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFAuttar.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFAuttar_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFAuttar.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFBanese}

Function TEF_TEFBanese_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    Result := tefHandle^.TEF.TEFBanese.NumVias;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFBanese.NumVias := NumVias;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFBanese.ArqTemp;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFBanese_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFBanese.ArqTemp := ArqTemp;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFBanese.ArqReq;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFBanese_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFBanese.ArqReq := ArqReq;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFBanese.ArqSTS;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFBanese_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFBanese.ArqSTS := ArqSTS;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
 StrTmp : String;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

try
    StrTmp := tefHandle^.TEF.TEFBanese.ArqResp;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function TEF_TEFBanese_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

 if (tefHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    tefHandle^.TEF.TEFBanese.ArqResp := ArqResp;
    Result := 0;
 except
    on exception : Exception do
    begin
       tefHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;

end;

Function TEF_TEFBanese_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFBanese.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFBanese_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFBanese.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFBanese_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFBanese.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFBanese_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFBanese.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFGood}

Function TEF_TEFGood_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFGood.AutoAtivarGP) then
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

Function TEF_TEFGood_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFGood.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFGood.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFGood.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFGood_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFGood.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFGood_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFGood.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region TEFFoxWin}

Function TEF_TEFFoxWin_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFFoxWin.AutoAtivarGP) then
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

Function TEF_TEFFoxWin_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFFoxWin.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFFoxWin.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFFoxWin.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFFoxWin_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFFoxWin.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFFoxWin_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFFoxWin.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

 {%region TEFPetrocard}

Function TEF_TEFPetrocard_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFPetrocard.AutoAtivarGP) then
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

Function TEF_TEFPetrocard_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFPetrocard.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFPetrocard.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFPetrocard.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFPetrocard_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFPetrocard.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFPetrocard_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFPetrocard.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

 {%region TEFCrediShop}

Function TEF_TEFCrediShop_GetAutoAtivarGP(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (tefHandle^.TEF.TEFCrediShop.AutoAtivarGP) then
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

Function TEF_TEFCrediShop_SetAutoAtivarGP(const tefHandle : PTEFHandle; const AutoAtivarGP : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.AutoAtivarGP := AutoAtivarGP;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetNumVias(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCrediShop.NumVias;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_SetNumVias(const tefHandle : PTEFHandle; const NumVias : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.NumVias := NumVias;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetEsperaSTS(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.TEFCrediShop.EsperaSTS;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_SetEsperaSTS(const tefHandle : PTEFHandle; const EsperaSTS : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.EsperaSTS := EsperaSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetArqTemp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.ArqTemp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetArqTemp(const tefHandle : PTEFHandle; const ArqTemp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.ArqTemp := ArqTemp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetArqReq(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.ArqReq;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetArqReq(const tefHandle : PTEFHandle; const ArqReq : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.ArqReq := ArqReq;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetArqSTS(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.ArqSTS;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetArqSTS(const tefHandle : PTEFHandle; const ArqSTS : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.ArqSTS := ArqSTS;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetArqResp(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.ArqResp;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetArqResp(const tefHandle : PTEFHandle; const ArqResp : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.ArqResp := ArqResp;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetGPExeName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.GPExeName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetGPExeName(const tefHandle : PTEFHandle; const GPExeName : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.GPExeName := GPExeName;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetName(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.TEFCrediShop.Name;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetName(const tefHandle : PTEFHandle; const Name : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.Name := Name;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_TEFCrediShop_GetHabilitado(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     If tefHandle^.TEF.TEFCrediShop.Habilitado then
        Result:= 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_TEFCrediShop_SetHabilitado(const tefHandle : PTEFHandle; const Habilitado : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.TEFCrediShop.Habilitado := Habilitado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Eventos}

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

{%endregion}

{%region EventHandlers}

procedure TEventHandlers.OnAguardaResp(Arquivo: String; SegundosTimeOut : Integer; var Interromper : Boolean);
begin
   OnAguardaRespCallback(PChar(Arquivo), SegundosTimeOut, Interromper);
end;

procedure TEventHandlers.OnExibeMsg(Operacao : TACBrTEFDOperacaoMensagem; Mensagem : String; var AModalResult : TModalResult);
begin
   OnExibeMsgCallback(Integer(Operacao), PChar(Mensagem), AModalResult);
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
   OnComandaECFCallback(Integer(Operacao), Resp, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFSubtotaliza(DescAcre : Double; var RetornoECF : Integer);
begin
  OnComandaECFSubtotalizaCallback(DescAcre, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFPagamento(IndiceECF : String; Valor : Double; var RetornoECF : Integer);
begin
   OnComandaECFPagamentoCallback(PChar(IndiceECF), Valor, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFAbreVinculado(COO, IndiceECF : String; Valor : Double; var RetornoECF : Integer);
begin
  OnComandaECFAbreVinculadoCallback(PChar(COO), PChar(IndiceECF), Valor, RetornoECF);
end;

procedure TEventHandlers.OnComandaECFImprimeVia(TipoRelatorio : TACBrTEFDTipoRelatorio; Via : Integer; ImagemComprovante : TStringList; var RetornoECF : Integer );
var
  i : Integer;
  linha : String;
  imagem : array of PChar;
begin

   SetLength(imagem, ImagemComprovante.Count);
   for i := 0 TO ImagemComprovante.Count - 1 do
   Begin

        linha := ImagemComprovante.Strings[i];
        imagem[i] := PChar(linha);
   end;

   OnComandaECFImprimeViaCallback(Integer(TipoRelatorio), Via, imagem, ImagemComprovante.Count, RetornoECF);

   SetLength(imagem, 0);

end;

procedure TEventHandlers.OnInfoECF(Operacao : TACBrTEFDInfoECF; var RetornoECF : String );
var
  retorno : PChar;
const
  retornoLen = 30;
begin

   retorno := StrAlloc(retornoLen);
   OnInfoECFCallback(Integer(Operacao), retorno, retornoLen);
   RetornoECF := retorno;

end;

procedure TEventHandlers.OnAntesFinalizarRequisicao(Req : TACBrTEFDReq);
begin
    OnAntesFinalizarRequisicaoCallback(Req);
end;

procedure TEventHandlers.OnDepoisConfirmarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
begin
     OnDepoisConfirmarTransacoesCallback(RespostasPendentes);
end;

procedure TEventHandlers.OnAntesCancelarTransacao(RespostaPendente : TACBrTEFDResp);
begin
     OnAntesCancelarTransacaoCallback(RespostaPendente);
end;

procedure TEventHandlers.OnDepoisCancelarTransacoes(RespostasPendentes : TACBrTEFDRespostasPendentes);
begin
     OnDepoisCancelarTransacoesCallback(RespostasPendentes);
end;

procedure TEventHandlers.OnMudaEstadoReq(EstadoReq  : TACBrTEFDReqEstado);
begin
   OnMudaEstadoReqCallback(Integer(EstadoReq));
end;

procedure TEventHandlers.OnMudaEstadoResp(EstadoResp : TACBrTEFDRespEstado);
begin
  OnMudaEstadoRespCallback(Integer(EstadoResp));
end;

procedure TEventHandlers.OnTEFCliSiTefExibeMenu(Titulo : String; Opcoes : TStringList; var ItemSelecionado : Integer; var VoltarMenu : Boolean);
var
  i : Integer;
  linha : String;
  lista : array of PChar;
begin

   SetLength(lista, Opcoes.Count);
   for i := 0 TO Opcoes.Count - 1 do
   Begin
        linha := Opcoes.Strings[i];
        lista[i] := PChar(linha);
   end;

   OnTEFCliSiTefExibeMenuCallback(PChar(Titulo), lista, Opcoes.Count, ItemSelecionado, VoltarMenu);

   SetLength(lista, 0);
end;

procedure TEventHandlers.OnTEFCliSiTefObtemCampo(Titulo : String; TamanhoMinimo, TamanhoMaximo : Integer ; TipoCampo : Integer; Operacao : TACBrTEFDCliSiTefOperacaoCampo; var Resposta : AnsiString; var Digitado : Boolean; var VoltarMenu : Boolean );
var
  resp : PChar;
const
  respLen = 256;
begin

  resp := StrAlloc(respLen);
  OnTEFCliSiTefObtemCampoCalback(PChar(Titulo), TamanhoMinimo, TamanhoMaximo, TipoCampo, Integer(Operacao), resp, respLen, Digitado, VoltarMenu);

  Resposta := resp;

end;

procedure TEventHandlers.OnTEFVeSPagueExibeMenu(Titulo : String; Opcoes : TStringList; Memo: TStringList; var ItemSelecionado : Integer);
var
  i : Integer;
  linha : String;
  lista : array of PChar;
  lista2 : array of PChar;
begin

   SetLength(lista, Opcoes.Count);
   for i := 0 TO Opcoes.Count - 1 do
   Begin
        linha := Opcoes.Strings[i];
        lista[i] := PChar(linha);
   end;

   SetLength(lista2, Memo.Count);
   for i := 0 TO Memo.Count - 1 do
   Begin
        linha := Memo.Strings[i];
        lista2[i] := PChar(linha);
   end;

   OnTEFVeSPagueExibeMenuCallback(PChar(Titulo), lista, Opcoes.Count, lista2, Memo.Count, ItemSelecionado);

   SetLength(lista, 0);
   SetLength(lista2, 0);
end;

procedure TEventHandlers.OnTEFVeSPagueObtemCampo(Titulo : String; Mascara : String; Tipo : AnsiChar; var Resposta : String; var Digitado : Boolean);
var
  resp : PChar;
const
  respLen = 256;
begin
  resp := StrAlloc(respLen);

  OnTEFVeSPagueObtemCampoCalback(PChar(Titulo), PChar(Mascara), Char(Tipo), resp, Digitado);

  Resposta := resp;

end;

{%endregion}

exports

{ Funções }
TEF_Create, TEF_Destroy,
TEF_GetUltimoErro,

{ Propriedade Componente }
TEF_SetAutoAtivar, TEF_GetAutoAtivar,
TEF_GetGPAtual, TEF_SetGPAtual,
TEF_SetMultiplosCartoes, TEF_GetMultiplosCartoes,
TEF_SetAutoEfetuarPagamento, TEF_GetAutoEfetuarPagamento,
TEF_SetAutoFinalizarCupom, TEF_GetAutoFinalizarCupom,
TEF_SetCHQEmGerencial, TEF_GetCHQEmGerencial,
TEF_SetEsperaSleep, TEF_GetEsperaSleep,
TEF_SetEsperaSTS, TEF_GetEsperaSTS,
TEF_SetNumVias, TEF_GetNumVias,
TEF_SetNumeroMaximoCartoes, TEF_GetNumeroMaximoCartoes,
TEF_SetArqLOG, TEF_GetArqLOG,
TEF_SetExibirMsgAutenticacao, TEF_GetExibirMsgAutenticacao,
TEF_SetPathBackup, TEF_GetPathBackup,
TEF_SetTrocoMaximo, TEF_GetTrocoMaximo, TEF_GetAbout,
TEF_GetReq, TEF_GetResp, TEF_GetRespostasPendentes,
TEF_GetSuportaDesconto, TEF_SetSuportaDesconto,
TEF_GetSuportaSaque, TEF_SetSuportaSaque,

{ Funções TEF }
TEF_Inicializar, TEF_DesInicializar,
TEF_AtivarGP, TEF_CRT, TEF_CHQ, TEF_ATV,
TEF_ADM, TEF_CNC, TEF_CNF, TEF_NCN,
TEF_CancelarTransacoesPendentes, TEF_ConfirmarTransacoesPendentes,
TEF_ImprimirTransacoesPendentes, TEF_FinalizarCupom,

{Identificacao}
TEF_Identificacao_GetNomeAplicacao,TEF_Identificacao_SetNomeAplicacao,
TEF_Identificacao_GetVersaoAplicacao,TEF_Identificacao_SetVersaoAplicacao,
TEF_Identificacao_GetSoftwareHouse,TEF_Identificacao_SetSoftwareHouse,
TEF_Identificacao_GetRazaoSocial,TEF_Identificacao_SetRazaoSocial,

{Req}
TEF_Req_GetHeader, TEF_Req_SetHeader,
TEF_Req_GetDocumentoVinculado,TEF_Req_SetDocumentoVinculado,
TEF_Req_GetCMC7, TEF_Req_SetCMC7,
TEF_Req_GetDocumentoPessoa, TEF_Req_SetDocumentoPessoa,
TEF_Req_GetRede, TEF_Req_SetRede,
TEF_Req_GetNSU, TEF_Req_SetNSU,
TEF_Req_GetFinalizacao, TEF_Req_SetFinalizacao,
TEF_Req_GetID, TEF_Req_SetID,
TEF_Req_GetMoeda, TEF_Req_SetMoeda,
TEF_Req_GetTipoPessoa, TEF_Req_SetTipoPessoa,
TEF_Req_GetValorTotal, TEF_Req_SetValorTotal,
TEF_Req_GetDataCheque, TEF_Req_SetDataCheque,
TEF_Req_GetDataHoraTransacaoComprovante, TEF_Req_SetDataHoraTransacaoComprovante,

{Resp}
TEF_Resp_GetHeader,
TEF_Resp_GetDocumentoVinculado,
TEF_Resp_GetCMC7,
TEF_Resp_GetTipoPessoa,
TEF_Resp_GetDocumentoPessoa,
TEF_Resp_GetRede,
TEF_Resp_GetNSU,
TEF_Resp_GetFinalizacao,
TEF_Resp_GetStatusTransacao,
TEF_Resp_GetNSUTransacaoCancelada,
TEF_Resp_GetTextoEspecialOperador,
TEF_Resp_GetTextoEspecialCliente,
TEF_Resp_GetAutenticacao,
TEF_Resp_GetBanco,
TEF_Resp_GetAgencia,
TEF_Resp_GetAgenciaDC,
TEF_Resp_GetConta,
TEF_Resp_GetContaDC,
TEF_Resp_GetCheque,
TEF_Resp_GetChequeDC,
TEF_Resp_GetNomeAdministradora,
TEF_Resp_GetTrailer,
TEF_Resp_GetArqBackup,
TEF_Resp_GetArqRespPendente,
TEF_Resp_GetIndiceFPG_ECF,
TEF_Resp_GetInstituicao,
TEF_Resp_GetModalidadePagto,
TEF_Resp_GetModalidadePagtoDescrita,
TEF_Resp_GetModalidadeExtenso,
TEF_Resp_GetCodigoRedeAutorizada,
TEF_Resp_GetID,
TEF_Resp_GetMoeda,
TEF_Resp_GetTipoTransacao,
TEF_Resp_GetCodigoAutorizacaoTransacao,
TEF_Resp_GetNumeroLoteTransacao,
TEF_Resp_GetTipoParcelamento,
TEF_Resp_GetQtdParcelas,
TEF_Resp_GetQtdLinhasComprovante,
TEF_Resp_GetOrdemPagamento,
TEF_Resp_GetTipoGP,
TEF_Resp_GetParceladoPor,
TEF_Resp_GetTipoOperacao,
TEF_Resp_GetCNFEnviado,
TEF_Resp_GetTransacaoAprovada,
TEF_Resp_GetDebito,
TEF_Resp_GetCredito,
TEF_Resp_GetValorTotal,
TEF_Resp_GetValorOriginal,
TEF_Resp_GetSaque,
TEF_Resp_GetDesconto,
TEF_Resp_GetValorEntradaCDC,
TEF_Resp_GetDataHoraTransacaoHost,
TEF_Resp_GetDataHoraTransacaoLocal,
TEF_Resp_GetDataPreDatado,
TEF_Resp_GetDataCheque,
TEF_Resp_GetDataHoraTransacaoCancelada,
TEF_Resp_GetDataHoraTransacaoComprovante,
TEF_Resp_GetDataVencimento,
TEF_Resp_GetDataEntradaCDC,
TEF_Resp_GetImagemComprovante1aViaCount,
TEF_Resp_GetImagemComprovante1aViaLinha,
TEF_Resp_GetImagemComprovante2aViaCount,
TEF_Resp_GetImagemComprovante2aViaLinha,
TEF_Resp_LeInformacao,

{RespostasPendentes}
TEF_RespostasPendentes_GetCount,
TEF_RespostasPendentes_GetItem,
TEF_RespostasPendentes_GetSaldoRestante,
TEF_RespostasPendentes_GetTotalDesconto,
TEF_RespostasPendentes_GetTotalPago,
TEF_RespostasPendentes_GetSaldoAPagar,


{TEFCliSiTef}
TEF_TEFCliSiTef_GetEnderecoIP, TEF_TEFCliSiTef_SetEnderecoIP,
TEF_TEFCliSiTef_GetCodigoLoja, TEF_TEFCliSiTef_SetCodigoLoja,
TEF_TEFCliSiTef_GetNumeroTerminal, TEF_TEFCliSiTef_SetNumeroTerminal,
TEF_TEFCliSiTef_GetOperador, TEF_TEFCliSiTef_SetOperador,
TEF_TEFCliSiTef_GetName, TEF_TEFCliSiTef_SetName,
TEF_TEFCliSiTef_GetHabilitado, TEF_TEFCliSiTef_SetHabilitado,
TEF_TEFCliSiTef_GetRestricoes, TEF_TEFCliSiTef_SetRestricoes,
TEF_TEFCliSiTef_GetOperacaoATV, TEF_TEFCliSiTef_SetOperacaoATV,
TEF_TEFCliSiTef_GetOperacaoADM, TEF_TEFCliSiTef_SetOperacaoADM,
TEF_TEFCliSiTef_GetOperacaoCRT, TEF_TEFCliSiTef_SetOperacaoCRT,
TEF_TEFCliSiTef_GetOperacaoCHQ, TEF_TEFCliSiTef_SetOperacaoCHQ,
TEF_TEFCliSiTef_GetOperacaoCNC, TEF_TEFCliSiTef_SetOperacaoCNC,
TEF_TEFCliSiTef_GetOperacaoReImpressao, TEF_TEFCliSiTef_SetOperacaoReImpressao,
TEF_TEFCliSiTef_SetOnExibeMenu, TEF_TEFCliSiTef_SetOnObtemCampo,
TEF_TEFCliSiTef_DefineMensagemPermanentePinPad,
TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes,
TEF_TEFCliSiTef_GetParametrosAdicionaisCount,
TEF_TEFCliSiTef_GetParametrosAdicionais, TEF_TEFCliSiTef_SetParametrosAdicionais,

{TEFVeSPague}
TEF_TEFVeSPague_GetAplicacao, TEF_TEFVeSPague_SetAplicacao,
TEF_TEFVeSPague_GetAplicacaoVersao, TEF_TEFVeSPague_SetAplicacaoVersao,
TEF_TEFVeSPague_GetGPExeName, TEF_TEFVeSPague_SetGPExeName,
TEF_TEFVeSPague_GetGPExeParams, TEF_TEFVeSPague_SetGPExeParams,
TEF_TEFVeSPague_GetEnderecoIP, TEF_TEFVeSPague_SetEnderecoIP,
TEF_TEFVeSPague_GetPorta, TEF_TEFVeSPague_SetPorta,
TEF_TEFVeSPague_GetTimeOut, TEF_TEFVeSPague_SetTimeOut,
TEF_TEFVeSPague_GetTemPendencias, TEF_TEFVeSPague_SetTemPendencias,
TEF_TEFVeSPague_GetTransacaoADM, TEF_TEFVeSPague_SetTransacaoADM,
TEF_TEFVeSPague_GetTransacaoCRT, TEF_TEFVeSPague_SetTransacaoCRT,
TEF_TEFVeSPague_GetTransacaoCHQ, TEF_TEFVeSPague_SetTransacaoCHQ,
TEF_TEFVeSPague_GetTransacaoCNC, TEF_TEFVeSPague_SetTransacaoCNC,
TEF_TEFVeSPague_GetTransacaoOpcao, TEF_TEFVeSPague_SetTransacaoOpcao,
TEF_TEFVeSPague_GetTransacaoReImpressao, TEF_TEFVeSPague_SetTransacaoReImpressao,
TEF_TEFVeSPague_GetTransacaoPendente, TEF_TEFVeSPague_SetTransacaoPendente,
TEF_TEFVeSPague_SetOnExibeMenu, TEF_TEFVeSPague_SetOnObtemCampo,

{TEFDial}
TEF_TEFDial_GetAutoAtivarGP, TEF_TEFDial_SetAutoAtivarGP,
TEF_TEFDial_GetNumVias, TEF_TEFDial_SetNumVias,
TEF_TEFDial_GetEsperaSTS,TEF_TEFDial_SetEsperaSTS,
TEF_TEFDial_GetArqTemp, TEF_TEFDial_SetArqTemp,
TEF_TEFDial_GetArqReq, TEF_TEFDial_SetArqReq,
TEF_TEFDial_GetArqSTS, TEF_TEFDial_SetArqSTS,
TEF_TEFDial_GetArqResp, TEF_TEFDial_SetArqResp,
TEF_TEFDial_GetGPExeName, TEF_TEFDial_SetGPExeName,
TEF_TEFDial_GetName, TEF_TEFDial_SetName,
TEF_TEFDial_GetHabilitado, TEF_TEFDial_SetHabilitado,

{TEFDisc}
TEF_TEFDisc_GetAutoAtivarGP, TEF_TEFDisc_SetAutoAtivarGP,
TEF_TEFDisc_GetNumVias, TEF_TEFDisc_SetNumVias,
TEF_TEFDisc_GetEsperaSTS,TEF_TEFDisc_SetEsperaSTS,
TEF_TEFDisc_GetArqTemp, TEF_TEFDisc_SetArqTemp,
TEF_TEFDisc_GetArqReq, TEF_TEFDisc_SetArqReq,
TEF_TEFDisc_GetArqSTS, TEF_TEFDisc_SetArqSTS,
TEF_TEFDisc_GetArqResp, TEF_TEFDisc_SetArqResp,
TEF_TEFDisc_GetGPExeName, TEF_TEFDisc_SetGPExeName,
TEF_TEFDisc_GetName, TEF_TEFDisc_SetName,
TEF_TEFDisc_GetHabilitado, TEF_TEFDisc_SetHabilitado,

{TEFHiper}
TEF_TEFHiper_GetAutoAtivarGP, TEF_TEFHiper_SetAutoAtivarGP,
TEF_TEFHiper_GetNumVias, TEF_TEFHiper_SetNumVias,
TEF_TEFHiper_GetEsperaSTS,TEF_TEFHiper_SetEsperaSTS,
TEF_TEFHiper_GetArqTemp, TEF_TEFHiper_SetArqTemp,
TEF_TEFHiper_GetArqReq, TEF_TEFHiper_SetArqReq,
TEF_TEFHiper_GetArqSTS, TEF_TEFHiper_SetArqSTS,
TEF_TEFHiper_GetArqResp, TEF_TEFHiper_SetArqResp,
TEF_TEFHiper_GetGPExeName, TEF_TEFHiper_SetGPExeName,
TEF_TEFHiper_GetName, TEF_TEFHiper_SetName,
TEF_TEFHiper_GetHabilitado, TEF_TEFHiper_SetHabilitado,

{TEFGPU}
TEF_TEFGPU_GetAutoAtivarGP, TEF_TEFGPU_SetAutoAtivarGP,
TEF_TEFGPU_GetNumVias, TEF_TEFGPU_SetNumVias,
TEF_TEFGPU_GetEsperaSTS,TEF_TEFGPU_SetEsperaSTS,
TEF_TEFGPU_GetArqTemp, TEF_TEFGPU_SetArqTemp,
TEF_TEFGPU_GetArqReq, TEF_TEFGPU_SetArqReq,
TEF_TEFGPU_GetArqSTS, TEF_TEFGPU_SetArqSTS,
TEF_TEFGPU_GetArqResp, TEF_TEFGPU_SetArqResp,
TEF_TEFGPU_GetGPExeName, TEF_TEFGPU_SetGPExeName,
TEF_TEFGPU_GetName, TEF_TEFGPU_SetName,
TEF_TEFGPU_GetHabilitado, TEF_TEFGPU_SetHabilitado,

{TEFAuttar}
TEF_TEFAuttar_GetAutoAtivarGP, TEF_TEFAuttar_SetAutoAtivarGP,
TEF_TEFAuttar_GetNumVias, TEF_TEFAuttar_SetNumVias,
TEF_TEFAuttar_GetEsperaSTS,TEF_TEFAuttar_SetEsperaSTS,
TEF_TEFAuttar_GetArqTemp, TEF_TEFAuttar_SetArqTemp,
TEF_TEFAuttar_GetArqReq, TEF_TEFAuttar_SetArqReq,
TEF_TEFAuttar_GetArqSTS, TEF_TEFAuttar_SetArqSTS,
TEF_TEFAuttar_GetArqResp, TEF_TEFAuttar_SetArqResp,
TEF_TEFAuttar_GetGPExeName, TEF_TEFAuttar_SetGPExeName,
TEF_TEFAuttar_GetName, TEF_TEFAuttar_SetName,
TEF_TEFAuttar_GetHabilitado, TEF_TEFAuttar_SetHabilitado,

{TEFBanese}
TEF_TEFBanese_GetNumVias, TEF_TEFBanese_SetNumVias,
TEF_TEFBanese_GetArqTemp, TEF_TEFBanese_SetArqTemp,
TEF_TEFBanese_GetArqReq, TEF_TEFBanese_SetArqReq,
TEF_TEFBanese_GetArqSTS, TEF_TEFBanese_SetArqSTS,
TEF_TEFBanese_GetArqResp, TEF_TEFBanese_SetArqResp,
TEF_TEFBanese_GetName, TEF_TEFBanese_SetName,
TEF_TEFBanese_GetHabilitado, TEF_TEFBanese_SetHabilitado,

{TEFGood}
TEF_TEFGood_GetAutoAtivarGP, TEF_TEFGood_SetAutoAtivarGP,
TEF_TEFGood_GetNumVias, TEF_TEFGood_SetNumVias,
TEF_TEFGood_GetEsperaSTS,TEF_TEFGood_SetEsperaSTS,
TEF_TEFGood_GetArqTemp, TEF_TEFGood_SetArqTemp,
TEF_TEFGood_GetArqReq, TEF_TEFGood_SetArqReq,
TEF_TEFGood_GetArqSTS, TEF_TEFGood_SetArqSTS,
TEF_TEFGood_GetArqResp, TEF_TEFGood_SetArqResp,
TEF_TEFGood_GetGPExeName, TEF_TEFGood_SetGPExeName,
TEF_TEFGood_GetName, TEF_TEFGood_SetName,
TEF_TEFGood_GetHabilitado, TEF_TEFGood_SetHabilitado,

{TEFFoxWin}
TEF_TEFFoxWin_GetAutoAtivarGP, TEF_TEFFoxWin_SetAutoAtivarGP,
TEF_TEFFoxWin_GetNumVias, TEF_TEFFoxWin_SetNumVias,
TEF_TEFFoxWin_GetEsperaSTS,TEF_TEFFoxWin_SetEsperaSTS,
TEF_TEFFoxWin_GetArqTemp, TEF_TEFFoxWin_SetArqTemp,
TEF_TEFFoxWin_GetArqReq, TEF_TEFFoxWin_SetArqReq,
TEF_TEFFoxWin_GetArqSTS, TEF_TEFFoxWin_SetArqSTS,
TEF_TEFFoxWin_GetArqResp, TEF_TEFFoxWin_SetArqResp,
TEF_TEFFoxWin_GetGPExeName, TEF_TEFFoxWin_SetGPExeName,
TEF_TEFFoxWin_GetName, TEF_TEFFoxWin_SetName,
TEF_TEFFoxWin_GetHabilitado, TEF_TEFFoxWin_SetHabilitado,

{TEFPetrocard}
TEF_TEFPetrocard_GetAutoAtivarGP, TEF_TEFPetrocard_SetAutoAtivarGP,
TEF_TEFPetrocard_GetNumVias, TEF_TEFPetrocard_SetNumVias,
TEF_TEFPetrocard_GetEsperaSTS,TEF_TEFPetrocard_SetEsperaSTS,
TEF_TEFPetrocard_GetArqTemp, TEF_TEFPetrocard_SetArqTemp,
TEF_TEFPetrocard_GetArqReq, TEF_TEFPetrocard_SetArqReq,
TEF_TEFPetrocard_GetArqSTS, TEF_TEFPetrocard_SetArqSTS,
TEF_TEFPetrocard_GetArqResp, TEF_TEFPetrocard_SetArqResp,
TEF_TEFPetrocard_GetGPExeName, TEF_TEFPetrocard_SetGPExeName,
TEF_TEFPetrocard_GetName, TEF_TEFPetrocard_SetName,
TEF_TEFPetrocard_GetHabilitado, TEF_TEFPetrocard_SetHabilitado,


{TEFCrediShop}
TEF_TEFCrediShop_GetAutoAtivarGP, TEF_TEFCrediShop_SetAutoAtivarGP,
TEF_TEFCrediShop_GetNumVias, TEF_TEFCrediShop_SetNumVias,
TEF_TEFCrediShop_GetEsperaSTS,TEF_TEFCrediShop_SetEsperaSTS,
TEF_TEFCrediShop_GetArqTemp, TEF_TEFCrediShop_SetArqTemp,
TEF_TEFCrediShop_GetArqReq, TEF_TEFCrediShop_SetArqReq,
TEF_TEFCrediShop_GetArqSTS, TEF_TEFCrediShop_SetArqSTS,
TEF_TEFCrediShop_GetArqResp, TEF_TEFCrediShop_SetArqResp,
TEF_TEFCrediShop_GetGPExeName, TEF_TEFCrediShop_SetGPExeName,
TEF_TEFCrediShop_GetName, TEF_TEFCrediShop_SetName,
TEF_TEFCrediShop_GetHabilitado, TEF_TEFCrediShop_SetHabilitado,

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
