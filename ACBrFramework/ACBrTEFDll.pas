unit ACBrTEFDll;


interface

uses
  SysUtils,
  Classes,
  ACBrTEFD,
  ACBrTEFDClass,
  ACBrTEFDCliSiTef,
  ACBrUtil,
  ACBrCommonDll
  ;

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

Function TEF_GetReq(const tefHandle : PTEFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (tefHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    if (tefHandle^.TEF.Req = nil) then
     Result := 0
    else
     Result := 1;

  except
     on exception : Exception do
     begin
        tefHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;
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

Function TEF_Req_SetTipoPessoa(const tefHandle : PTEFHandle; const TipoPessoa : char) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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

TEF_Inicializar,
TEF_GetGPAtual, TEF_SetGPAtual,
TEF_CRT,

{Identificacao}
TEF_Identificacao_GetNomeAplicacao,TEF_Identificacao_SetNomeAplicacao,
TEF_Identificacao_GetVersaoAplicacao,TEF_Identificacao_SetVersaoAplicacao,
TEF_Identificacao_GetSoftwareHouse,TEF_Identificacao_SetSoftwareHouse,
TEF_Identificacao_GetRazaoSocial,TEF_Identificacao_SetRazaoSocial,

{Req}
TEF_GetReq,
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

{TEFCliSiTef}
TEF_TEFCliSiTef_GetEnderecoIP, TEF_TEFCliSiTef_SetEnderecoIP,
TEF_TEFCliSiTef_GetCodigoLoja, TEF_TEFCliSiTef_SetCodigoLoja,
TEF_TEFCliSiTef_GetNumeroTerminal, TEF_TEFCliSiTef_SetNumeroTerminal,
TEF_TEFCliSiTef_GetOperador, TEF_TEFCliSiTef_SetOperador,
//TEF_TEFCliSiTef_GetParametrosAdicionais, TEF_TEFCliSiTef_SetParametrosAdicionais,
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

{TEFDisc}
TEF_TEFDisc_GetAutoAtivarGP, TEF_TEFDisc_SetAutoAtivarGP,
TEF_TEFDisc_GetNumVias, TEF_TEFDisc_SetNumVias,
TEF_TEFDisc_GetEsperaSTS,TEF_TEFDisc_SetEsperaSTS,
TEF_TEFDisc_GetArqTemp, TEF_TEFDisc_SetArqTemp,
TEF_TEFDisc_GetArqReq, TEF_TEFDisc_SetArqReq,
TEF_TEFDisc_GetArqSTS, TEF_TEFDisc_SetArqSTS,
TEF_TEFDisc_GetArqResp, TEF_TEFDisc_SetArqResp,
TEF_TEFDisc_GetGPExeName, TEF_TEFDisc_SetGPExeName,

{TEFHiper}
TEF_TEFHiper_GetAutoAtivarGP, TEF_TEFHiper_SetAutoAtivarGP,
TEF_TEFHiper_GetNumVias, TEF_TEFHiper_SetNumVias,
TEF_TEFHiper_GetEsperaSTS,TEF_TEFHiper_SetEsperaSTS,
TEF_TEFHiper_GetArqTemp, TEF_TEFHiper_SetArqTemp,
TEF_TEFHiper_GetArqReq, TEF_TEFHiper_SetArqReq,
TEF_TEFHiper_GetArqSTS, TEF_TEFHiper_SetArqSTS,
TEF_TEFHiper_GetArqResp, TEF_TEFHiper_SetArqResp,
TEF_TEFHiper_GetGPExeName, TEF_TEFHiper_SetGPExeName,

{TEFGPU}
TEF_TEFGPU_GetAutoAtivarGP, TEF_TEFGPU_SetAutoAtivarGP,
TEF_TEFGPU_GetNumVias, TEF_TEFGPU_SetNumVias,
TEF_TEFGPU_GetEsperaSTS,TEF_TEFGPU_SetEsperaSTS,
TEF_TEFGPU_GetArqTemp, TEF_TEFGPU_SetArqTemp,
TEF_TEFGPU_GetArqReq, TEF_TEFGPU_SetArqReq,
TEF_TEFGPU_GetArqSTS, TEF_TEFGPU_SetArqSTS,
TEF_TEFGPU_GetArqResp, TEF_TEFGPU_SetArqResp,
TEF_TEFGPU_GetGPExeName, TEF_TEFGPU_SetGPExeName,

{TEFAuttar}
TEF_TEFAuttar_GetAutoAtivarGP, TEF_TEFAuttar_SetAutoAtivarGP,
TEF_TEFAuttar_GetNumVias, TEF_TEFAuttar_SetNumVias,
TEF_TEFAuttar_GetEsperaSTS,TEF_TEFAuttar_SetEsperaSTS,
TEF_TEFAuttar_GetArqTemp, TEF_TEFAuttar_SetArqTemp,
TEF_TEFAuttar_GetArqReq, TEF_TEFAuttar_SetArqReq,
TEF_TEFAuttar_GetArqSTS, TEF_TEFAuttar_SetArqSTS,
TEF_TEFAuttar_GetArqResp, TEF_TEFAuttar_SetArqResp,
TEF_TEFAuttar_GetGPExeName, TEF_TEFAuttar_SetGPExeName,

{TEFGood}
TEF_TEFGood_GetAutoAtivarGP, TEF_TEFGood_SetAutoAtivarGP,
TEF_TEFGood_GetNumVias, TEF_TEFGood_SetNumVias,
TEF_TEFGood_GetEsperaSTS,TEF_TEFGood_SetEsperaSTS,
TEF_TEFGood_GetArqTemp, TEF_TEFGood_SetArqTemp,
TEF_TEFGood_GetArqReq, TEF_TEFGood_SetArqReq,
TEF_TEFGood_GetArqSTS, TEF_TEFGood_SetArqSTS,
TEF_TEFGood_GetArqResp, TEF_TEFGood_SetArqResp,
TEF_TEFGood_GetGPExeName, TEF_TEFGood_SetGPExeName,

{TEFFoxWin}
TEF_TEFFoxWin_GetAutoAtivarGP, TEF_TEFFoxWin_SetAutoAtivarGP,
TEF_TEFFoxWin_GetNumVias, TEF_TEFFoxWin_SetNumVias,
TEF_TEFFoxWin_GetEsperaSTS,TEF_TEFFoxWin_SetEsperaSTS,
TEF_TEFFoxWin_GetArqTemp, TEF_TEFFoxWin_SetArqTemp,
TEF_TEFFoxWin_GetArqReq, TEF_TEFFoxWin_SetArqReq,
TEF_TEFFoxWin_GetArqSTS, TEF_TEFFoxWin_SetArqSTS,
TEF_TEFFoxWin_GetArqResp, TEF_TEFFoxWin_SetArqResp,
TEF_TEFFoxWin_GetGPExeName, TEF_TEFFoxWin_SetGPExeName,

{TEFPetrocard}
TEF_TEFPetrocard_GetAutoAtivarGP, TEF_TEFPetrocard_SetAutoAtivarGP,
TEF_TEFPetrocard_GetNumVias, TEF_TEFPetrocard_SetNumVias,
TEF_TEFPetrocard_GetEsperaSTS,TEF_TEFPetrocard_SetEsperaSTS,
TEF_TEFPetrocard_GetArqTemp, TEF_TEFPetrocard_SetArqTemp,
TEF_TEFPetrocard_GetArqReq, TEF_TEFPetrocard_SetArqReq,
TEF_TEFPetrocard_GetArqSTS, TEF_TEFPetrocard_SetArqSTS,
TEF_TEFPetrocard_GetArqResp, TEF_TEFPetrocard_SetArqResp,
TEF_TEFPetrocard_GetGPExeName, TEF_TEFPetrocard_SetGPExeName,


{TEFCrediShop}
TEF_TEFCrediShop_GetAutoAtivarGP, TEF_TEFCrediShop_SetAutoAtivarGP,
TEF_TEFCrediShop_GetNumVias, TEF_TEFCrediShop_SetNumVias,
TEF_TEFCrediShop_GetEsperaSTS,TEF_TEFCrediShop_SetEsperaSTS,
TEF_TEFCrediShop_GetArqTemp, TEF_TEFCrediShop_SetArqTemp,
TEF_TEFCrediShop_GetArqReq, TEF_TEFCrediShop_SetArqReq,
TEF_TEFCrediShop_GetArqSTS, TEF_TEFCrediShop_SetArqSTS,
TEF_TEFCrediShop_GetArqResp, TEF_TEFCrediShop_SetArqResp,
TEF_TEFCrediShop_GetGPExeName, TEF_TEFCrediShop_SetGPExeName,

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
