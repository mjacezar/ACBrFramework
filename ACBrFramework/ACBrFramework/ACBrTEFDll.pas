﻿unit ACBrTEFDll;


interface

uses
  SysUtils,
  Classes,
  ACBrTEFD,
  ACBrTEFDClass,
  ACBrTEFDCliSiTef,
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
type TInfoECFCallback =  procedure(const Operacao : TACBrTEFDInfoECF; const RetornoECF : PChar; const RetornoECFLen : Integer); cdecl;
type TAntesFinalizarRequisicaoCallback = procedure(const Req : PTEFResp ); cdecl;
type TDepoisConfirmarTransacoes = procedure(const RespostasPendentes : PTEFRespostasPendentes ); cdecl;
type TAntesCancelarTransacaoCallback = procedure(const RespostaPendente : PTEFResp); cdecl;
type TDepoisCancelarTransacoesCallback = procedure(const RespostasPendentes : PTEFRespostasPendentes); cdecl;
type TMudaEstadoReqCallback =  procedure(const EstadoReq  : TACBrTEFDReqEstado); cdecl;
type TMudaEstadoRespCallback = procedure(const EstadoResp : TACBrTEFDRespEstado); cdecl;
type TTEFCliSiTefExibeMenuCallback = procedure(const Titulo : PChar; const Opcoes : array of PChar; const OpcoesCount : Integer; var ItemSelecionado : Integer; var VoltarMenu : Boolean); cdecl;
type TTEFCliSiTefObtemCampoCalback = procedure(const Titulo : PChar; const TamanhoMinimo : Integer; const TamanhoMaximo : Integer; const TipoCampo : Integer; Operacao : TACBrTEFDCliSiTefOperacaoCampo; const Resposta : PChar; const RespLen : Integer; var Digitado : Boolean; var VoltarMenu : Boolean); cdecl;

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

  OnTEFCliSiTefExibeMenuCallback : TTEFCliSiTefExibeMenuCallback;
  OnTEFCliSiTefObtemCampoCalback : TTEFCliSiTefObtemCampoCalback;

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

// Propriedades

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

Function TEF_SetEsperaSleep(const tefHandle : PTEFHandle; const Espera : Integer): Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.EsperaSleep := Espera;
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

///////////////////////////////////////////////////////////

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

Function TEF_FinalizarCupom(const tefHandle : PTEFHandle; const mouse : Boolean ) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

{Identificacao}
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

{Req}

Function TEF_Req_GetHeader(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Header;
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

Function TEF_Req_SetHeader(const tefHandle : PTEFHandle; const Header : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Header := Header;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDocumentoVinculado(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.DocumentoVinculado;
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

Function TEF_Req_SetDocumentoVinculado(const tefHandle : PTEFHandle; const DocumentoVinculado : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.DocumentoVinculado := DocumentoVinculado;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetCMC7(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.CMC7;
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

Function TEF_Req_SetCMC7(const tefHandle : PTEFHandle; const CMC7 : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.CMC7 := CMC7;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDocumentoPessoa(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.DocumentoPessoa;
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

Function TEF_Req_SetDocumentoPessoa(const tefHandle : PTEFHandle; const DocumentoPessoa : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.DocumentoPessoa := DocumentoPessoa;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetRede(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Rede;
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

Function TEF_Req_SetRede(const tefHandle : PTEFHandle; const Rede : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Rede := Rede;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetNSU(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.NSU;
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

Function TEF_Req_SetNSU(const tefHandle : PTEFHandle; const NSU : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.NSU := NSU;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetFinalizacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Finalizacao;
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

Function TEF_Req_SetFinalizacao(const tefHandle : PTEFHandle; const Finalizacao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Finalizacao := Finalizacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetBanco(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Banco;
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

Function TEF_Req_SetBanco(const tefHandle : PTEFHandle; const Banco : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Banco := Banco;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetAgencia(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Agencia;
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

Function TEF_Req_SetAgencia(const tefHandle : PTEFHandle; const Agencia : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Agencia := Agencia;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetAgenciaDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.AgenciaDC;
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

Function TEF_Req_SetAgenciaDC(const tefHandle : PTEFHandle; const AgenciaDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.AgenciaDC := AgenciaDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetConta(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Conta;
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

Function TEF_Req_SetConta(const tefHandle : PTEFHandle; const Conta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Conta := Conta;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetContaDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.ContaDC;
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

Function TEF_Req_SetContaDC(const tefHandle : PTEFHandle; const ContaDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.ContaDC := ContaDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetCheque(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.Cheque;
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

Function TEF_Req_SetCheque(const tefHandle : PTEFHandle; const Cheque : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Cheque := Cheque;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetChequeDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Req.ChequeDC;
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

Function TEF_Req_SetChequeDC(const tefHandle : PTEFHandle; const ChequeDC : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.ChequeDC := ChequeDC;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;


Function TEF_Req_GetID(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.Req.ID;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetID(const tefHandle : PTEFHandle; const ID : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.ID := ID;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetMoeda(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := tefHandle^.TEF.Req.Moeda;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetMoeda(const tefHandle : PTEFHandle; const Moeda : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.Moeda := Moeda;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetTipoPessoa(const tefHandle : PTEFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(tefHandle^.TEF.Req.TipoPessoa);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetTipoPessoa(const tefHandle : PTEFHandle; const TipoPessoa : AnsiChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.TipoPessoa := TipoPessoa;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetValorTotal(const tefHandle : PTEFHandle; var ValorTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ValorTotal := tefHandle^.TEF.Req.ValorTotal;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetValorTotal(const tefHandle : PTEFHandle; const ValorTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.ValorTotal := ValorTotal;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDataCheque(const tefHandle : PTEFHandle; var DataCheque : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     DataCheque := double(tefHandle^.TEF.Req.DataCheque);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetDataCheque(const tefHandle : PTEFHandle; const DataCheque : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.DataCheque := TDateTime(DataCheque);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_GetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; var DataHoraTransacaoComprovante : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     DataHoraTransacaoComprovante := double(tefHandle^.TEF.Req.DataHoraTransacaoComprovante);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function TEF_Req_SetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; const DataHoraTransacaoComprovante : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     tefHandle^.TEF.Req.DataHoraTransacaoComprovante := TDateTime(DataHoraTransacaoComprovante);
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{Resp}

Function TEF_Resp_GetHeader(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Header;
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

Function TEF_Resp_GetDocumentoVinculado(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.DocumentoVinculado;
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

Function TEF_Resp_GetCMC7(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.CMC7;
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

Function TEF_Resp_GetTipoPessoa(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.TipoPessoa;
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

Function TEF_Resp_GetDocumentoPessoa(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.DocumentoPessoa;
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

Function TEF_Resp_GetRede(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Rede;
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

Function TEF_Resp_GetNSU(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.NSU;
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

Function TEF_Resp_GetFinalizacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Finalizacao;
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

Function TEF_Resp_GetStatusTransacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.StatusTransacao;
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

Function TEF_Resp_GetNSUTransacaoCancelada(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.NSUTransacaoCancelada;
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

Function TEF_Resp_GetTextoEspecialOperador(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.TextoEspecialOperador;
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

Function TEF_Resp_GetTextoEspecialCliente(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.TextoEspecialOperador;
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

Function TEF_Resp_GetAutenticacao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Autenticacao;
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

Function TEF_Resp_GetBanco(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Banco;
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

Function TEF_Resp_GetAgencia(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Agencia;
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

Function TEF_Resp_GetAgenciaDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.AgenciaDC;
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

Function TEF_Resp_GetConta(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Conta;
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

Function TEF_Resp_GetContaDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ContaDC;
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

Function TEF_Resp_GetCheque(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Cheque;
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

Function TEF_Resp_GetChequeDC(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ChequeDC;
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

Function TEF_Resp_GetNomeAdministradora(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.NomeAdministradora;
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

Function TEF_Resp_GetTrailer(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Trailer;
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

Function TEF_Resp_GetArqBackup(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ArqBackup;
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

Function TEF_Resp_GetArqRespPendente(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ArqRespPendente;
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

Function TEF_Resp_GetIndiceFPG_ECF(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.IndiceFPG_ECF;
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

Function TEF_Resp_GetInstituicao(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.Instituicao;
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

Function TEF_Resp_GetModalidadePagto(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ModalidadePagto;
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

Function TEF_Resp_GetModalidadePagtoDescrita(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ModalidadePagtoDescrita;
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

Function TEF_Resp_GetModalidadeExtenso(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ModalidadeExtenso;
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

Function TEF_Resp_GetCodigoRedeAutorizada(const tefHandle : PTEFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.CodigoRedeAutorizada;
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

Function TEF_Resp_GetID(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.ID;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetMoeda(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.Moeda;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.TipoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCodigoAutorizacaoTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.CodigoAutorizacaoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetNumeroLoteTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.NumeroLoteTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoParcelamento(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.TipoParcelamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetQtdParcelas(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.QtdParcelas;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetQtdLinhasComprovante(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.QtdLinhasComprovante;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetOrdemPagamento(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.Resp.OrdemPagamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoGP(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.Resp.TipoGP);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetParceladoPor(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.Resp.ParceladoPor);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetTipoOperacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.Resp.TipoOperacao);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetCNFEnviado(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.Resp.CNFEnviado) then
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

Function TEF_Resp_GetTransacaoAprovada(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.Resp.TransacaoAprovada) then
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

Function TEF_Resp_GetDebito(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.Resp.Debito) then
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

Function TEF_Resp_GetCredito(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.Resp.Credito) then
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

Function TEF_Resp_GetValorTotal(const tefHandle : PTEFHandle; var ValorTotal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorTotal := tefHandle^.TEF.Resp.ValorTotal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetValorOriginal(const tefHandle : PTEFHandle; var ValorOriginal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorOriginal := tefHandle^.TEF.Resp.ValorOriginal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetSaque(const tefHandle : PTEFHandle; var Saque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Saque := tefHandle^.TEF.Resp.Saque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDesconto(const tefHandle : PTEFHandle; var Desconto : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Desconto := tefHandle^.TEF.Resp.Desconto;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetValorEntradaCDC(const tefHandle : PTEFHandle; var ValorEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorEntradaCDC := tefHandle^.TEF.Resp.ValorEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataCheque(const tefHandle : PTEFHandle; var DataCheque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataCheque := tefHandle^.TEF.Resp.DataCheque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoHost(const tefHandle : PTEFHandle; var DataHoraTransacaoHost : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoHost := tefHandle^.TEF.Resp.DataHoraTransacaoHost;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoLocal(const tefHandle : PTEFHandle; var DataHoraTransacaoLocal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoLocal := tefHandle^.TEF.Resp.DataHoraTransacaoLocal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataPreDatado(const tefHandle : PTEFHandle; var DataPreDatado : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataPreDatado := tefHandle^.TEF.Resp.DataPreDatado;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoCancelada(const tefHandle : PTEFHandle; var DataHoraTransacaoCancelada : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoCancelada := tefHandle^.TEF.Resp.DataHoraTransacaoCancelada;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; var DataHoraTransacaoComprovante : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoComprovante := tefHandle^.TEF.Resp.DataHoraTransacaoComprovante;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataVencimento(const tefHandle : PTEFHandle; var DataVencimento : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataVencimento := tefHandle^.TEF.Resp.DataVencimento;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetDataEntradaCDC(const tefHandle : PTEFHandle; var DataEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataEntradaCDC := tefHandle^.TEF.Resp.DataEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante1aViaCount(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := tefHandle^.TEF.Resp.ImagemComprovante1aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante1aViaLinha(const tefHandle : PTEFHandle; const linha : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ImagemComprovante1aVia[linha];
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

Function TEF_Resp_GetImagemComprovante2aViaCount(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := tefHandle^.TEF.Resp.ImagemComprovante2aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_Resp_GetImagemComprovante2aViaLinha(const tefHandle : PTEFHandle; const linha : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.Resp.ImagemComprovante2aVia[linha];
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
//ImagemComprovante1aVia : TStringList read fpImagemCompro
//ImagemComprovante2aVia : TStringList read fpImagemCompro

{Respostas Pendentes}

Function TEF_RespostasPendentes_GetSaldoAPagar(const tefHandle : PTEFHandle; var SaldoAPagar : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     SaldoAPagar := tefHandle^.TEF.RespostasPendentes.SaldoAPagar;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTotalPago(const tefHandle : PTEFHandle; var TotalPago : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     TotalPago := tefHandle^.TEF.RespostasPendentes.TotalPago;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTotalDesconto(const tefHandle : PTEFHandle; var TotalDesconto : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     TotalDesconto := tefHandle^.TEF.RespostasPendentes.TotalDesconto;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetSaldoRestante(const tefHandle : PTEFHandle; var SaldoRestante : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     SaldoRestante := tefHandle^.TEF.RespostasPendentes.SaldoRestante;
     Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;


Function TEF_RespostasPendentes_GetCount(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;



Function TEF_RespostasPendentes_GetHeader(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Header;
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

Function TEF_RespostasPendentes_GetDocumentoVinculado(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].DocumentoVinculado;
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

Function TEF_RespostasPendentes_GetCMC7(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].CMC7;
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

Function TEF_RespostasPendentes_GetTipoPessoa(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].TipoPessoa;
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

Function TEF_RespostasPendentes_GetDocumentoPessoa(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].DocumentoPessoa;
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

Function TEF_RespostasPendentes_GetRede(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Rede;
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

Function TEF_RespostasPendentes_GetNSU(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].NSU;
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

Function TEF_RespostasPendentes_GetFinalizacao(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Finalizacao;
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

Function TEF_RespostasPendentes_GetStatusTransacao(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].StatusTransacao;
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

Function TEF_RespostasPendentes_GetNSUTransacaoCancelada(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].NSUTransacaoCancelada;
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

Function TEF_RespostasPendentes_GetTextoEspecialOperador(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].TextoEspecialOperador;
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

Function TEF_RespostasPendentes_GetTextoEspecialCliente(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].TextoEspecialOperador;
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

Function TEF_RespostasPendentes_GetAutenticacao(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Autenticacao;
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

Function TEF_RespostasPendentes_GetBanco(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Banco;
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

Function TEF_RespostasPendentes_GetAgencia(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Agencia;
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

Function TEF_RespostasPendentes_GetAgenciaDC(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].AgenciaDC;
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

Function TEF_RespostasPendentes_GetConta(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Conta;
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

Function TEF_RespostasPendentes_GetContaDC(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ContaDC;
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

Function TEF_RespostasPendentes_GetCheque(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Cheque;
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

Function TEF_RespostasPendentes_GetChequeDC(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ChequeDC;
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

Function TEF_RespostasPendentes_GetNomeAdministradora(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].NomeAdministradora;
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

Function TEF_RespostasPendentes_GetTrailer(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Trailer;
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

Function TEF_RespostasPendentes_GetArqBackup(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ArqBackup;
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

Function TEF_RespostasPendentes_GetArqRespPendente(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ArqRespPendente;
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

Function TEF_RespostasPendentes_GetIndiceFPG_ECF(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].IndiceFPG_ECF;
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

Function TEF_RespostasPendentes_GetInstituicao(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].Instituicao;
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

Function TEF_RespostasPendentes_GetModalidadePagto(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ModalidadePagto;
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

Function TEF_RespostasPendentes_GetModalidadePagtoDescrita(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ModalidadePagtoDescrita;
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

Function TEF_RespostasPendentes_GetModalidadeExtenso(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ModalidadeExtenso;
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

Function TEF_RespostasPendentes_GetCodigoRedeAutorizada(const tefHandle : PTEFHandle; const index : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].CodigoRedeAutorizada;
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

//Int
Function TEF_RespostasPendentes_GetID(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].ID;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetMoeda(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].Moeda;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTipoTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].TipoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetCodigoAutorizacaoTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].CodigoAutorizacaoTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetNumeroLoteTransacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].NumeroLoteTransacao;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTipoParcelamento(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].TipoParcelamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetQtdParcelas(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].QtdParcelas;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetQtdLinhasComprovante(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].QtdLinhasComprovante;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetOrdemPagamento(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := tefHandle^.TEF.RespostasPendentes[index].OrdemPagamento;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTipoGP(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.RespostasPendentes[index].TipoGP);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetParceladoPor(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.RespostasPendentes[index].ParceladoPor);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetTipoOperacao(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(tefHandle^.TEF.RespostasPendentes[index].TipoOperacao);
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

//Bool
Function TEF_RespostasPendentes_GetCNFEnviado(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.RespostasPendentes[index].CNFEnviado) then
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

Function TEF_RespostasPendentes_GetTransacaoAprovada(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.RespostasPendentes[index].TransacaoAprovada) then
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

Function TEF_RespostasPendentes_GetDebito(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.RespostasPendentes[index].Debito) then
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

Function TEF_RespostasPendentes_GetCredito(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
	 if (tefHandle^.TEF.RespostasPendentes[index].Credito) then
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

Function TEF_RespostasPendentes_GetValorTotal(const tefHandle : PTEFHandle; const index : Integer; var ValorTotal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorTotal := tefHandle^.TEF.RespostasPendentes[index].ValorTotal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetValorOriginal(const tefHandle : PTEFHandle; const index : Integer; var ValorOriginal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorOriginal := tefHandle^.TEF.RespostasPendentes[index].ValorOriginal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetSaque(const tefHandle : PTEFHandle; const index : Integer; var Saque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Saque := tefHandle^.TEF.RespostasPendentes[index].Saque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDesconto(const tefHandle : PTEFHandle; const index : Integer; var Desconto : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Desconto := tefHandle^.TEF.RespostasPendentes[index].Desconto;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetValorEntradaCDC(const tefHandle : PTEFHandle; const index : Integer; var ValorEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    ValorEntradaCDC := tefHandle^.TEF.RespostasPendentes[index].ValorEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataCheque(const tefHandle : PTEFHandle; const index : Integer; var DataCheque : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataCheque := tefHandle^.TEF.RespostasPendentes[index].DataCheque;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataHoraTransacaoHost(const tefHandle : PTEFHandle; const index : Integer; var DataHoraTransacaoHost : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoHost := tefHandle^.TEF.RespostasPendentes[index].DataHoraTransacaoHost;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataHoraTransacaoLocal(const tefHandle : PTEFHandle; const index : Integer; var DataHoraTransacaoLocal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoLocal := tefHandle^.TEF.RespostasPendentes[index].DataHoraTransacaoLocal;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataPreDatado(const tefHandle : PTEFHandle; const index : Integer; var DataPreDatado : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataPreDatado := tefHandle^.TEF.RespostasPendentes[index].DataPreDatado;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataHoraTransacaoCancelada(const tefHandle : PTEFHandle; const index : Integer; var DataHoraTransacaoCancelada : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoCancelada := tefHandle^.TEF.RespostasPendentes[index].DataHoraTransacaoCancelada;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataHoraTransacaoComprovante(const tefHandle : PTEFHandle; const index : Integer; var DataHoraTransacaoComprovante : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataHoraTransacaoComprovante := tefHandle^.TEF.RespostasPendentes[index].DataHoraTransacaoComprovante;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataVencimento(const tefHandle : PTEFHandle; const index : Integer; var DataVencimento : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataVencimento := tefHandle^.TEF.RespostasPendentes[index].DataVencimento;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetDataEntradaCDC(const tefHandle : PTEFHandle; const index : Integer; var DataEntradaCDC : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    DataEntradaCDC := tefHandle^.TEF.RespostasPendentes[index].DataEntradaCDC;
	Result := 0;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetImagemComprovante1aViaCount(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := tefHandle^.TEF.RespostasPendentes[index].ImagemComprovante1aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetImagemComprovante1aViaLinha(const tefHandle : PTEFHandle; const index : Integer; const linha : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ImagemComprovante1aVia[linha];
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

Function TEF_RespostasPendentes_GetImagemComprovante2aViaCount(const tefHandle : PTEFHandle; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    Result := tefHandle^.TEF.RespostasPendentes[index].ImagemComprovante2aVia.Count;
  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function TEF_RespostasPendentes_GetImagemComprovante2aViaLinha(const tefHandle : PTEFHandle; const index : Integer; const linha : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := tefHandle^.TEF.RespostasPendentes[index].ImagemComprovante2aVia[linha];
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

{TEFCliSiTef}
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

//Function TEF_TEFCliSiTef_GetParametrosAdicionais

//Function TEF_TEFCliSiTef_SetParametrosAdicionais

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

 {TEFDial}
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

{TEFDisc}
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

{TEFHiper}
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


{TEFGPU}
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

{TEFAuttar}
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

{TEFGood}
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

{TEFFoxWin}
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

 {TEFPetrocard}
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


 {TEFCrediShop}
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


{Eventos}
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


{EventHandlers}

procedure TEventHandlers.OnAguardaResp(Arquivo: String; SegundosTimeOut : Integer; var Interromper : Boolean);
begin
   OnAguardaRespCallback(PChar(Arquivo), SegundosTimeOut, Interromper);
end;

procedure TEventHandlers.OnExibeMsg(Operacao : TACBrTEFDOperacaoMensagem; Mensagem : String; var AModalResult : TModalResult);
begin
   OnExibeMsgCallback(Operacao, PChar(Mensagem), AModalResult);
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

   OnComandaECFImprimeViaCallback(TipoRelatorio, Via, imagem, ImagemComprovante.Count, RetornoECF);

   SetLength(imagem, 0);

end;

procedure TEventHandlers.OnInfoECF(Operacao : TACBrTEFDInfoECF; var RetornoECF : String );
var
  retorno : PChar;
const
  retornoLen = 30;
begin

   retorno := StrAlloc(retornoLen);
   OnInfoECFCallback(Operacao, retorno, retornoLen);
   RetornoECF := retorno;

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
  OnTEFCliSiTefObtemCampoCalback(PChar(Titulo), TamanhoMinimo, TamanhoMaximo, TipoCampo, Operacao, resp, respLen, Digitado, VoltarMenu);

  Resposta := resp;

end;

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

{RespostasPendentes}
TEF_RespostasPendentes_GetCount,
TEF_RespostasPendentes_GetSaldoRestante,
TEF_RespostasPendentes_GetTotalDesconto,
TEF_RespostasPendentes_GetTotalPago,
TEF_RespostasPendentes_GetSaldoAPagar,
TEF_RespostasPendentes_GetHeader,
TEF_RespostasPendentes_GetDocumentoVinculado,
TEF_RespostasPendentes_GetCMC7,
TEF_RespostasPendentes_GetTipoPessoa,
TEF_RespostasPendentes_GetDocumentoPessoa,
TEF_RespostasPendentes_GetRede,
TEF_RespostasPendentes_GetNSU,
TEF_RespostasPendentes_GetFinalizacao,
TEF_RespostasPendentes_GetStatusTransacao,
TEF_RespostasPendentes_GetNSUTransacaoCancelada,
TEF_RespostasPendentes_GetTextoEspecialOperador,
TEF_RespostasPendentes_GetTextoEspecialCliente,
TEF_RespostasPendentes_GetAutenticacao,
TEF_RespostasPendentes_GetBanco,
TEF_RespostasPendentes_GetAgencia,
TEF_RespostasPendentes_GetAgenciaDC,
TEF_RespostasPendentes_GetConta,
TEF_RespostasPendentes_GetContaDC,
TEF_RespostasPendentes_GetCheque,
TEF_RespostasPendentes_GetChequeDC,
TEF_RespostasPendentes_GetNomeAdministradora,
TEF_RespostasPendentes_GetTrailer,
TEF_RespostasPendentes_GetArqBackup,
TEF_RespostasPendentes_GetArqRespPendente,
TEF_RespostasPendentes_GetIndiceFPG_ECF,
TEF_RespostasPendentes_GetInstituicao,
TEF_RespostasPendentes_GetModalidadePagto,
TEF_RespostasPendentes_GetModalidadePagtoDescrita,
TEF_RespostasPendentes_GetModalidadeExtenso,
TEF_RespostasPendentes_GetCodigoRedeAutorizada,
TEF_RespostasPendentes_GetID,
TEF_RespostasPendentes_GetMoeda,
TEF_RespostasPendentes_GetTipoTransacao,
TEF_RespostasPendentes_GetCodigoAutorizacaoTransacao,
TEF_RespostasPendentes_GetNumeroLoteTransacao,
TEF_RespostasPendentes_GetTipoParcelamento,
TEF_RespostasPendentes_GetQtdParcelas,
TEF_RespostasPendentes_GetQtdLinhasComprovante,
TEF_RespostasPendentes_GetOrdemPagamento,
TEF_RespostasPendentes_GetTipoGP,
TEF_RespostasPendentes_GetParceladoPor,
TEF_RespostasPendentes_GetTipoOperacao,
TEF_RespostasPendentes_GetCNFEnviado,
TEF_RespostasPendentes_GetTransacaoAprovada,
TEF_RespostasPendentes_GetDebito,
TEF_RespostasPendentes_GetCredito,
TEF_RespostasPendentes_GetValorTotal,
TEF_RespostasPendentes_GetValorOriginal,
TEF_RespostasPendentes_GetSaque,
TEF_RespostasPendentes_GetDesconto,
TEF_RespostasPendentes_GetValorEntradaCDC,
TEF_RespostasPendentes_GetDataCheque,
TEF_RespostasPendentes_GetDataHoraTransacaoHost,
TEF_RespostasPendentes_GetDataHoraTransacaoLocal,
TEF_RespostasPendentes_GetDataPreDatado,
TEF_RespostasPendentes_GetDataHoraTransacaoCancelada,
TEF_RespostasPendentes_GetDataHoraTransacaoComprovante,
TEF_RespostasPendentes_GetDataVencimento,
TEF_RespostasPendentes_GetDataEntradaCDC,
TEF_RespostasPendentes_GetImagemComprovante1aViaCount,
TEF_RespostasPendentes_GetImagemComprovante1aViaLinha,
TEF_RespostasPendentes_GetImagemComprovante2aViaCount,
TEF_RespostasPendentes_GetImagemComprovante2aViaLinha,


{TEFCliSiTef}
TEF_TEFCliSiTef_GetEnderecoIP, TEF_TEFCliSiTef_SetEnderecoIP,
TEF_TEFCliSiTef_GetCodigoLoja, TEF_TEFCliSiTef_SetCodigoLoja,
TEF_TEFCliSiTef_GetNumeroTerminal, TEF_TEFCliSiTef_SetNumeroTerminal,
TEF_TEFCliSiTef_GetOperador, TEF_TEFCliSiTef_SetOperador,
//TEF_TEFCliSiTef_GetParametrosAdicionais, TEF_TEFCliSiTef_SetParametrosAdicionais,
TEF_TEFCliSiTef_GetName, TEF_TEFCliSiTef_SetName,
TEF_TEFCliSiTef_GetHabilitado, TEF_TEFCliSiTef_SetHabilitado,
TEF_TEFCliSiTef_GetRestricoes, TEF_TEFCliSiTef_SetRestricoes,
TEF_TEFCliSiTef_GetOperacaoATV, TEF_TEFCliSiTef_SetOperacaoATV,
TEF_TEFCliSiTef_GetOperacaoADM, TEF_TEFCliSiTef_SetOperacaoADM,
TEF_TEFCliSiTef_GetOperacaoCRT, TEF_TEFCliSiTef_SetOperacaoCRT,
TEF_TEFCliSiTef_GetOperacaoCHQ, TEF_TEFCliSiTef_SetOperacaoCHQ,
TEF_TEFCliSiTef_GetOperacaoCNC, TEF_TEFCliSiTef_SetOperacaoCNC,
TEF_TEFCliSiTef_GetOperacaoReImpressao, TEF_TEFCliSiTef_SetOperacaoReImpressao,
TEF_TEFCliSiTef_SetOnExibeMenu,
TEF_TEFCliSiTef_SetOnObtemCampo,

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
