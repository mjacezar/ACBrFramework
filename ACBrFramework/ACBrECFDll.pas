unit ACBrECFDll;

interface

uses
  SysUtils,
  Classes,
  ACBrECF,
  ACBrECFClass,
  ACBrDevice,
  ACBrUtil,
  ACBrAACDLL,
  ACBrEADDll,
  ACBrRFDDll,
  ACBrPAFClass;

{%region Ponteiros de função para uso nos eventos}

type TCallback = procedure(); cdecl;
type TAbreCupomCallback = procedure(const CPF_CNPJ, Nome, Endereco : PChar); cdecl;
type TRelatorioGerencialCallback = procedure(const Indice: Integer); cdecl;
type TCancelaItemCallback = procedure(const Indice: Integer); cdecl;
type TEfetuaPagamentoCallback = procedure(const CodFormaPagto: pChar; const Valor: Double; const Observacao: pChar; const ImprimeVinculado: Boolean); cdecl;
type TFechaCupomCallback = procedure(const Observacao: pChar; const IndiceBMP: Integer); cdecl;
type TSangriaSuprimentoCallback = procedure(const Valor: Double; const Obs, DescricaoCNF, DescricaoFPG : pChar); cdecl;
type TSubtotalizaCupomCallback = procedure(const DescontoAcrescimo: Double; const MensagemRodape: pChar); cdecl;
type TVendeItemCallback = procedure(const Codigo, Descricao, AliquotaICMS: pChar; const Qtd, ValorUnitario, ValorDescontoAcrescimo: Double; const Unidade, TipoDescontoAcrescimo, DescontoAcrescimo: pChar); cdecl;
type TBobinaProcedureCallback = procedure(const Linhas : PChar; const Operacao : PChar); cdecl;
type TChangeEstadoCallback = procedure(const EstadoAnterior, EstadoAtual: Integer); cdecl;
type TChequeEstadoCallback = function(const EstadoAtual: Integer) : Boolean; cdecl;
type TErrorCallback = function() : Boolean; cdecl;
type TErrorRelatorioCallback = function(const Indice: Integer) : Boolean; cdecl;
type TMsgCallback = procedure(Mensagem : pChar); cdecl;
type TPAFCalcEADCallback = procedure(Mensagem : pChar); cdecl;
type TMsgRetentarCallback = function(const Mensagem, Situacao: pChar) : Boolean; cdecl;


{%endregion}

{%region Classe que armazena os EventHandlers para o componente ACBr}

type TEventHandlersECF = class

    OnMsgPoucoPapelCallback : TCallback;
    OnAguardandoRespostaChangeCallback :  TCallback;

    OnAntesAbreCupomCallback : TAbreCupomCallback;
    OnAntesAbreCupomVinculadoCallback : TCallback;
    OnAntesAbreNaoFiscalCallback : TAbreCupomCallback;
    OnAntesAbreRelatorioGerencialCallback : TRelatorioGerencialCallback;
    OnAntesCancelaCupomCallback : TCallback;
    OnAntesCancelaItemNaoFiscalCallback : TCancelaItemCallback;
    OnAntesCancelaItemVendidoCallback : TCancelaItemCallback;
    OnAntesCancelaNaoFiscalCallback : TCallback;
    OnAntesEfetuaPagamentoCallback : TEfetuaPagamentoCallback;
    OnAntesEfetuaPagamentoNaoFiscalCallback : TEfetuaPagamentoCallback;
    OnAntesFechaCupomCallback : TFechaCupomCallback;
    OnAntesFechaNaoFiscalCallback : TFechaCupomCallback;
    OnAntesFechaRelatorioCallback : TCallback;
    OnAntesLeituraXCallback : TCallback;
    OnAntesReducaoZCallback : TCallback;
    OnAntesSangriaCallback : TSangriaSuprimentoCallback;
    OnAntesSubtotalizaCupomCallback : TSubtotalizaCupomCallback;
    OnAntesSubtotalizaNaoFiscalCallback : TSubtotalizaCupomCallback;
    OnAntesSuprimentoCallback : TSangriaSuprimentoCallback;
    OnAntesVendeItemCallback : TVendeItemCallback;

    OnBobinaAdicionaLinhasCallback : TBobinaProcedureCallback;
    OnChangeEstadoCallback : TChangeEstadoCallback;
    OnChequeEstadoCallback : TChequeEstadoCallback;

    OnDepoisAbreCupomCallback : TAbreCupomCallback;
    OnDepoisAbreCupomVinculadoCallback : TCallback;
    OnDepoisAbreNaoFiscalCallback : TAbreCupomCallback;
    OnDepoisAbreRelatorioGerencialCallback : TRelatorioGerencialCallback;
    OnDepoisCancelaCupomCallback : TCallback;
    OnDepoisCancelaItemNaoFiscalCallback : TCancelaItemCallback;
    OnDepoisCancelaItemVendidoCallback : TCancelaItemCallback;
    OnDepoisCancelaNaoFiscalCallback : TCallback;
    OnDepoisEfetuaPagamentoCallback : TEfetuaPagamentoCallback;
    OnDepoisEfetuaPagamentoNaoFiscalCallback : TEfetuaPagamentoCallback;
    OnDepoisFechaCupomCallback : TFechaCupomCallback;
    OnDepoisFechaNaoFiscalCallback : TFechaCupomCallback;
    OnDepoisFechaRelatorioCallback : TCallback;
    OnDepoisLeituraXCallback : TCallback;
    OnDepoisReducaoZCallback : TCallback;
    OnDepoisSangriaCallback : TSangriaSuprimentoCallback;
    OnDepoisSubtotalizaCupomCallback : TSubtotalizaCupomCallback;
    OnDepoisSubtotalizaNaoFiscalCallback : TSubtotalizaCupomCallback;
    OnDepoisSuprimentoCallback : TSangriaSuprimentoCallback;
    OnDepoisVendeItemCallback : TVendeItemCallback;

    OnErrorAbreCupomCallback : TErrorCallback;
    OnErrorAbreCupomVinculadoCallback : TErrorCallback;
    OnErrorAbreNaoFiscalCallback : TErrorCallback;
    OnErrorAbreRelatorioGerencialCallback : TErrorRelatorioCallback;
    OnErrorCancelaCupomCallback : TErrorCallback;
    OnErrorCancelaItemNaoFiscalCallback : TErrorCallback;
    OnErrorCancelaItemVendidoCallback : TErrorCallback;
    OnErrorCancelaNaoFiscalCallback : TErrorCallback;
    OnErrorEfetuaPagamentoCallback : TErrorCallback;
    OnErrorEfetuaPagamentoNaoFiscalCallback : TErrorCallback;
    OnErrorFechaCupomCallback : TErrorCallback;
    OnErrorFechaNaoFiscalCallback : TErrorCallback;
    OnErrorFechaRelatorioCallback : TErrorCallback;
    OnErrorLeituraXCallback : TErrorCallback;
    OnErrorReducaoZCallback : TErrorCallback;
    OnErrorSangriaCallback : TErrorCallback;
    OnErrorSemPapelCallback : TCallback;
    OnErrorSubtotalizaCupomCallback : TErrorCallback;
    OnErrorSubtotalizaNaoFiscalCallback : TErrorCallback;
    OnErrorSuprimentoCallback : TErrorCallback;
    OnErrorVendeItemCallback : TErrorCallback;

    OnMsgAguardeCallback : TMSgCallback;
    OnMsgRetentarCallback : TMsgRetentarCallback;
    OnPAFCalcEADCallback : TPAFCalcEADCallback;
    OnPAFGetKeyRSACallback : TChaveCallback ;

    procedure OnMsgPoucoPapel(Sender: TObject);
    procedure OnAguardandoRespostaChange(Sender: TObject);

    procedure OnAntesAbreCupom(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnAntesAbreCupomVinculado(Sender: TObject);
    procedure OnAntesAbreNaoFiscal(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnAntesAbreRelatorioGerencial(const Indice: Integer);
    procedure OnAntesCancelaCupom(Sender: TObject);
    procedure OnAntesCancelaItemNaoFiscal(const NumItem: Integer);
    procedure OnAntesCancelaItemVendido(const NumItem: Integer);
    procedure OnAntesCancelaNaoFiscal(Sender: TObject);
    procedure OnAntesEfetuaPagamento(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
    procedure OnAntesEfetuaPagamentoNaoFiscal(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
    procedure OnAntesFechaCupom(const Observacao: AnsiString; const IndiceBMP: Integer);
    procedure OnAntesFechaNaoFiscal(const Observacao: AnsiString; const IndiceBMP: Integer);
    procedure OnAntesFechaRelatorio(Sender: TObject);
    procedure OnAntesLeituraX(Sender: TObject);
    procedure OnAntesReducaoZ(Sender: TObject);
    procedure OnAntesSangria(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
    procedure OnAntesSubtotalizaCupom(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
    procedure OnAntesSubtotalizaNaoFiscal(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
    procedure OnAntesSuprimento(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
    procedure OnAntesVendeItem(const Codigo, Descricao, AliquotaICMS: String; const Qtd, ValorUnitario,
          ValorDescontoAcrescimo: Double; const Unidade, TipoDescontoAcrescimo, DescontoAcrescimo: String);

    procedure OnBobinaAdicionaLinhas(const Linhas : String; const Operacao : String);
    procedure OnChangeEstado(const EstadoAnterior, EstadoAtual: TACBrECFEstado);
    procedure OnChequeEstado(const EstadoAtual: TACBrECFCHQEstado;  var Continuar: Boolean);

    procedure OnDepoisAbreCupom(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnDepoisAbreCupomVinculado(Sender: TObject);
    procedure OnDepoisAbreNaoFiscal(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnDepoisAbreRelatorioGerencial(const Indice: Integer);
    procedure OnDepoisCancelaCupom(Sender: TObject);
    procedure OnDepoisCancelaItemNaoFiscal(const NumItem: Integer);
    procedure OnDepoisCancelaItemVendido(const NumItem: Integer);
    procedure OnDepoisCancelaNaoFiscal(Sender: TObject);
    procedure OnDepoisEfetuaPagamento(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
    procedure OnDepoisEfetuaPagamentoNaoFiscal(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
    procedure OnDepoisFechaCupom(const Observacao: AnsiString; const IndiceBMP: Integer);
    procedure OnDepoisFechaNaoFiscal(const Observacao: AnsiString; const IndiceBMP: Integer);
    procedure OnDepoisFechaRelatorio(Sender: TObject);
    procedure OnDepoisLeituraX(Sender: TObject);
    procedure OnDepoisReducaoZ(Sender: TObject);
    procedure OnDepoisSangria(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
    procedure OnDepoisSubtotalizaCupom(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
    procedure OnDepoisSubtotalizaNaoFiscal(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
    procedure OnDepoisSuprimento(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
    procedure OnDepoisVendeItem(const Codigo, Descricao, AliquotaICMS: String; const Qtd, ValorUnitario,
          ValorDescontoAcrescimo: Double; const Unidade, TipoDescontoAcrescimo, DescontoAcrescimo: String);

    procedure OnErrorAbreCupom(var Tratado: Boolean);
    procedure OnErrorAbreCupomVinculado(var Tratado: Boolean);
    procedure OnErrorAbreNaoFiscal(var Tratado: Boolean);
    procedure OnErrorAbreRelatorioGerencial(var Tratado: Boolean; const Indice: Integer);
    procedure OnErrorCancelaCupom(var Tratado: Boolean);
    procedure OnErrorCancelaItemNaoFiscal(var Tratado: Boolean);
    procedure OnErrorCancelaItemVendido(var Tratado: Boolean);
    procedure OnErrorCancelaNaoFiscal(var Tratado: Boolean);
    procedure OnErrorEfetuaPagamento(var Tratado: Boolean);
    procedure OnErrorEfetuaPagamentoNaoFiscal(var Tratado: Boolean);
    procedure OnErrorFechaCupom(var Tratado: Boolean);
    procedure OnErrorFechaNaoFiscal(var Tratado: Boolean);
    procedure OnErrorFechaRelatorio(var Tratado: Boolean);
    procedure OnErrorLeituraX(var Tratado: Boolean);
    procedure OnErrorReducaoZ(var Tratado: Boolean);
    procedure OnErrorSangria(var Tratado: Boolean);
    procedure OnErrorSemPapel(Sender: TObject);
    procedure OnErrorSubtotalizaCupom(var Tratado: Boolean);
    procedure OnErrorSubtotalizaNaoFiscal(var Tratado: Boolean);
    procedure OnErrorSuprimento(var Tratado: Boolean);
    procedure OnErrorVendeItem(var Tratado: Boolean);

    procedure OnMsgAguarde(const Mensagem : String);
    procedure OnMsgRetentar(const Mensagem: String; const Situacao: String; var Result: Boolean);
    procedure OnPAFCalcEAD(Arquivo: String);
    procedure OnPAFGetKeyRSA(var Chave: AnsiString);

end;

{%endregion}

{Handle para o componente TACBrECF }
type TECFHandle = record
  UltimoErro : String;
  ECF : TACBrECF;
  EventHandlers : TEventHandlersECF;
end;

{Ponteiro para o Handle }
type PECFHandle = ^TECFHandle;

{%region Records estilo C utilizados nos retornos das funções}

type TAliquotaRec = record
      Indice    : array[0..3] of char;
      Aliquota  : double;
      Tipo      : char;
      Total     : double;
      Sequencia : byte;
end;

type TDAVsRec = record
      Numero    : array[0..13] of char;
      COO_Cupom : Integer;
      COO_Dav   : Integer;
      Titulo    : array[0..30] of char;
      Valor     : double;
      DtEmissao : double;
end;

type TFormaPagamentoRec = record
      Indice           : array[0..3] of char;
      Descricao        : array[0..29] of char;
      PermiteVinculado : boolean;
      Total            : double;
      Data             : TDateTime;
      TipoDoc          : array[0..29] of char;
end;

type TComprovanteNaoFiscalRec = record
    Indice            : array[0..3] of char;
    Descricao         : array[0..29] of char;
    PermiteVinculado  : Boolean;
    FormaPagamento    : array[0..3] of char;
    Total             : Double ;
    Contador          : Integer;
end;

type TRelatorioGerencialRec = record
    Indice    : array[0..3] of char;
    Descricao : array[0..29] of char;
    Contador  : Integer;
end;

{%endregion}

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
Function ECF_Create(var ecfHandle: PECFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(ecfHandle);

     ecfHandle^.ECF := TACBrECF.Create(nil);
     ecfHandle^.EventHandlers := TEventHandlersECF.Create();
     ecfHandle^.ECF.ReTentar := False;
     ecfHandle^.ECF.ExibeMensagem := False;
     ecfHandle^.ECF.BloqueiaMouseTeclado := False;
     ecfHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        ecfHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrECF e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function ECF_Destroy(ecfHandle: PECFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    ecfHandle^.ECF.Destroy();
    ecfHandle^.ECF := nil;
    Dispose(ecfHandle);
    ecfHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        ecfHandle^.UltimoErro := exception.Message;
     end
  end;
end;

Function ECF_GetUltimoErro(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, ecfHandle^.UltimoErro, BufferLen);
     Result := length(ecfHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function ECF_GetAbout(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.About;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetModelo(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(ecfHandle^.ECF.Modelo);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SetModelo(const ecfHandle: PECFHandle; const Modelo : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Modelo := TACBrECFModelo(Modelo);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetPorta(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.Porta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SetPorta(const ecfHandle: PECFHandle; const Porta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Porta := Porta;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetTimeOut(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.TimeOut;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SetTimeOut(const ecfHandle: PECFHandle; const TimeOut : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.TimeOut := TimeOut;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetPaginaDeCodigo(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.PaginaDeCodigo;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SetPaginaDeCodigo(const ecfHandle: PECFHandle; const PaginaDeCodigo : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PaginaDeCodigo := PaginaDeCodigo;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetIntervaloAposComando(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.IntervaloAposComando;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetIntervaloAposComando(const ecfHandle: PECFHandle; const Intervalo : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.IntervaloAposComando := Intervalo;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDescricaoGrande(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if ecfHandle^.ECF.DescricaoGrande then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetDescricaoGrande(const ecfHandle: PECFHandle; const DescricaoGrande : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DescricaoGrande := DescricaoGrande;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetGavetaSinalInvertido(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if ecfHandle^.ECF.GavetaSinalInvertido then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetGavetaSinalInvertido(const ecfHandle: PECFHandle; const GavetaSinalInvertido : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.GavetaSinalInvertido := GavetaSinalInvertido;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetArredondaPorQtd(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if ecfHandle^.ECF.ArredondaPorQtd then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetArredondaPorQtd(const ecfHandle: PECFHandle; const ArredondaPorQtd : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.ArredondaPorQtd  := ArredondaPorQtd;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetArredondaItemMFD(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if ecfHandle^.ECF.ArredondaItemMFD then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetArredondaItemMFD(const ecfHandle: PECFHandle; const ArredondaItemMFD : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.ArredondaItemMFD  := ArredondaItemMFD;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetIgnorarTagsFormatacao(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if ecfHandle^.ECF.IgnorarTagsFormatacao then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetIgnorarTagsFormatacao(const ecfHandle: PECFHandle; const IgnorarTagsFormatacao : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.IgnorarTagsFormatacao  := IgnorarTagsFormatacao;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetOperador(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.Operador;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOperador(const ecfHandle: PECFHandle; const Operador : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;
  try
     ecfHandle^.ECF.Operador := Operador;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetLinhasEntreCupons(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
       Result := ecfHandle^.ECF.LinhasEntreCupons;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetLinhasEntreCupons(const ecfHandle: PECFHandle; const LinhasEntreCupons : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LinhasEntreCupons := LinhasEntreCupons;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDecimaisPreco(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
       Result := ecfHandle^.ECF.DecimaisPreco;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetDecimaisPreco(const ecfHandle: PECFHandle; const DecimaisPreco : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DecimaisPreco := DecimaisPreco;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDecimaisQtd(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
       Result := ecfHandle^.ECF.DecimaisQtd;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetDecimaisQtd(const ecfHandle: PECFHandle; const DecimaisQtd : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DecimaisQtd := DecimaisQtd;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetArqLOG(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  StrTmp := ecfHandle^.ECF.ArqLOG;
  StrPLCopy(Buffer, StrTmp, BufferLen);
  Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetArqLOG(const ecfHandle: PECFHandle; const ArqLog : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.ArqLOG := ArqLog;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetMaxLinhasBuffer(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.MaxLinhasBuffer;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetMaxLinhasBuffer(const ecfHandle: PECFHandle; const MaxLinha : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.MaxLinhasBuffer := MaxLinha;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetPausaRelatorio(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.PausaRelatorio;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetPausaRelatorio(const ecfHandle: PECFHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PausaRelatorio := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataHoraUltimaReducaoZ(const ecfHandle: PECFHandle; var data : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    data := ecfHandle^.ECF.DataHoraUltimaReducaoZ;
    Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region InfoRodapeCupom}

Function ECF_InfoRodapeCupom_GetMD5(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.MD5;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetMD5(const ecfHandle: PECFHandle; const md5 : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.MD5 := md5;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetDav(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.Dav;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetDav(const ecfHandle: PECFHandle; const Dav : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Dav := Dav;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetDavOs(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.DavOs;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetDavOs(const ecfHandle: PECFHandle; const DavOs : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.DavOs := DavOs;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetPreVenda(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.PreVenda;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetPreVenda(const ecfHandle: PECFHandle; const PreVenda : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.PreVenda := PreVenda;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetCupomMania(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.InfoRodapeCupom.CupomMania then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetCupomMania(const ecfHandle: PECFHandle; const CupomMania : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.CupomMania := CupomMania;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetMinasLegal(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.InfoRodapeCupom.MinasLegal then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetMinasLegal(const ecfHandle: PECFHandle; const MinasLegal : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.MinasLegal := MinasLegal;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_GetParaibaLegal(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.InfoRodapeCupom.ParaibaLegal then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_SetParaibaLegal(const ecfHandle: PECFHandle; const ParaibaLegal : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.ParaibaLegal := ParaibaLegal;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.Imprimir then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir(const ecfHandle: PECFHandle; const Imprimir : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.Imprimir := Imprimir;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ProgramaDeCredito then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito(const ecfHandle: PECFHandle; const ProgramaDeCredito : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ProgramaDeCredito := ProgramaDeCredito;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ValorICMS;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS(const ecfHandle: PECFHandle; const ValorICMS : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ValorICMS := ValorICMS;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ValorISS;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS(const ecfHandle: PECFHandle; const ValorISS : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.NotaLegalDF.ValorISS := ValorISS;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_GetImprimir(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if (ecfHandle^.ECF.InfoRodapeCupom.Restaurante.Imprimir) then
          Result := 1
     else
          Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_SetImprimir(const ecfHandle: PECFHandle; const Imprimir : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Restaurante.Imprimir := Imprimir;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_GetECF(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := ecfHandle^.ECF.InfoRodapeCupom.Restaurante.ECF;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_SetECF(const ecfHandle: PECFHandle; const ECF : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Restaurante.ECF := ECF;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_GetCER(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := ecfHandle^.ECF.InfoRodapeCupom.Restaurante.CER;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_SetCER(const ecfHandle: PECFHandle; const CER : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Restaurante.CER := CER;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_GetCOO(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := ecfHandle^.ECF.InfoRodapeCupom.Restaurante.COO;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_SetCOO(const ecfHandle: PECFHandle; const COO : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Restaurante.COO := COO;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_GetMesa(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.Restaurante.Mesa;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Restaurante_SetMesa(const ecfHandle: PECFHandle; const mesa : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Restaurante.Mesa := mesa;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_GetTexto(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.Imposto.Texto;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_SetTexto(const ecfHandle: PECFHandle; const texto : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Imposto.Texto := texto;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_GetFonte(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.InfoRodapeCupom.Imposto.Fonte;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_SetFonte(const ecfHandle: PECFHandle; const fonte : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Imposto.Fonte := fonte;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_GetValorAproximado(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.InfoRodapeCupom.Imposto.ValorAproximado;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_InfoRodapeCupom_Imposto_SetValorAproximado(const ecfHandle: PECFHandle; const valor : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.InfoRodapeCupom.Imposto.ValorAproximado := valor;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Consumidor}

Function ECF_Consumidor_GetDocumento(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.Consumidor.Documento;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_GetEndereco(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.Consumidor.Endereco;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_GetNome(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.Consumidor.Nome;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_GetEnviado(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.Consumidor.Enviado then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_SetEnviado(const ecfHandle: PECFHandle; const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.Consumidor.Enviado := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_GetAtribuido(const ecfHandle: PECFHandle; var value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.Consumidor.Atribuido then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_AtribuiConsumidor(const ecfHandle: PECFHandle; const CPF_CNPJ, Nome, Endereco: pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.Consumidor.AtribuiConsumidor(CPF_CNPJ, Nome, Endereco);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_Consumidor_Zera(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.Consumidor.Zera;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region ConfigBarras}

Function ECF_ConfigBarras_GetAltura(const ecfHandle: PECFHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.ConfigBarras.Altura;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_ConfigBarras_SetAltura(const ecfHandle: PECFHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.ConfigBarras.Altura := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_ConfigBarras_GetLarguraLinha(const ecfHandle: PECFHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.ConfigBarras.LarguraLinha;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_ConfigBarras_SetLarguraLinha(const ecfHandle: PECFHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.ConfigBarras.LarguraLinha := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_ConfigBarras_GetMostrarCodigo(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     if ecfHandle^.ECF.ConfigBarras.MostrarCodigo Then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_ConfigBarras_SetMostrarCodigo(const ecfHandle: PECFHandle; const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.ConfigBarras.MostrarCodigo := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Propriedades - Não Visiveis }

Function ECF_GetAtivo(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (ecfHandle^.ECF.Ativo) then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetColunas(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ecfHandle^.ECF.Colunas;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetAguardandoResposta(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
        if (ecfHandle^.ECF.AguardandoResposta) then
           Result := 1
        else
           Result :=0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetComandoLog(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.ComandoLOG;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SetComandoLog(const ecfHandle: PECFHandle; const ComandoLog : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     ecfHandle^.ECF.ComandoLOG := ComandoLog;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetAguardaImpressao(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
        if ecfHandle^.ECF.AguardaImpressao then
            Result := 1
        else
            Result :=0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetAguardaImpressao(const ecfHandle: PECFHandle; const AguardaImpressao : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AguardaImpressao := AguardaImpressao;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetModeloStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := ecfHandle^.ECF.ModeloStr;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetRFDID(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := ecfHandle^.ECF.RFDID;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataHora(const ecfHandle: PECFHandle; var ticks : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ticks := double(ecfHandle^.ECF.DataHora);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataHoraStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := FormatDateTime('dd/mm/yyyy hh:nn:ss', ecfHandle^.ECF.DataHora);
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCupom(const ecfHandle: PECFHandle;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCupom;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCOO(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCOO;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumLoja(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumLoja;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumECF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumECF;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumSerie(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumSerie;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumSerieMFD(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumSerieMFD;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumVersao(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumVersao;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end;
  end;
end;

Function ECF_GetDataMovimento(const ecfHandle: PECFHandle; var ticks : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ticks := double(ecfHandle^.ECF.DataMovimento);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataMovimentoStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := pchar(FormatDateTime('dd/mm/yyyy', ecfHandle^.ECF.DataMovimento));
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataHoraSB(const ecfHandle: PECFHandle; var ticks : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ticks := double(ecfHandle^.ECF.DataHoraSB);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDataHoraSBStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := pchar(FormatDateTime('dd/mm/yyyy hh:nn:ss', ecfHandle^.ECF.DataHoraSB));
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetCNPJ(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.CNPJ;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetIE(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.IE;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetIM(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.IM;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetCliche(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.Cliche;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetUsuarioAtual(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.UsuarioAtual;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetSubModeloECF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.SubModeloECF;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetPAF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := ecfHandle^.ECF.PAF;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetNumCRZ(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCRZ;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCRO(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCRO;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCCF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCCF;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumGNF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumGNF;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumGRG(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumGRG;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCDC(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCDC;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetComandoEnviado(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   cmd : String;
   strTmp : String;
   Ch  : String;
   ASC : Byte ;
   I   : Integer ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := '';
     cmd := ecfHandle^.ECF.ComandoEnviado;
     For I := 1 to Length(cmd) do
     begin
     ASC := Ord(cmd[I]) ;

     case ASC of
        2   : Ch := '[STX]' ;
        3   : Ch := '[ETX]' ;
        6   : Ch := '[ACK]' ;
        10  : Ch := #10 ; //'[LF]' ;
        13  : Ch := #13 ; //'[CR]' ;
        27  : Ch := '[ESC]' ;
        255 : Ch := '[FF]' ;
        32..127 : Ch := cmd[I] ;
     else ;
       Ch := '['+IntToStr(ASC)+']'
     end;
     strTmp := strTmp + Ch ;
     end;

     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetRespostaComando(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   cmd : String;
   strTmp : String;
   Ch  : String;
   ASC : Byte ;
   I   : Integer ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := '';
     cmd := ecfHandle^.ECF.RespostaComando;
     For I := 1 to Length(cmd) do
     begin
     ASC := Ord(cmd[I]) ;

     case ASC of
        2   : Ch := '[STX]' ;
        3   : Ch := '[ETX]' ;
        6   : Ch := '[ACK]' ;
        10  : Ch := #10 ; //'[LF]' ;
        13  : Ch := #13 ; //'[CR]' ;
        27  : Ch := '[ESC]' ;
        255 : Ch := '[FF]' ;
        32..127 : Ch := cmd[I] ;
     else ;
       Ch := '['+IntToStr(ASC)+']'
     end;
     strTmp := strTmp + Ch;
     end;

     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumCOOInicial(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.NumCOOInicial;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetVendaBruta(const ecfHandle: PECFHandle; var VendaBruta : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     VendaBruta := ecfHandle^.ECF.VendaBruta;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetGrandeTotal(const ecfHandle: PECFHandle; var GrandeTotal : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GrandeTotal := ecfHandle^.ECF.GrandeTotal;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalCancelamentos(const ecfHandle: PECFHandle; var TotalCancelamentos : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalCancelamentos := ecfHandle^.ECF.TotalCancelamentos;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalDescontos(const ecfHandle: PECFHandle; var TotalDescontos : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalDescontos := ecfHandle^.ECF.TotalDescontos;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalAcrescimos(const ecfHandle: PECFHandle; var TotalAcrescimos : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalAcrescimos := ecfHandle^.ECF.TotalAcrescimos;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalTroco(const ecfHandle: PECFHandle; var TotalTroco : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalTroco := ecfHandle^.ECF.TotalTroco;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalSubstituicaoTributaria(const ecfHandle: PECFHandle; var TotalSubstituicaoTributaria : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalSubstituicaoTributaria := ecfHandle^.ECF.TotalSubstituicaoTributaria;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalNaoTributado(const ecfHandle: PECFHandle; var TotalNaoTributado : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalNaoTributado := ecfHandle^.ECF.TotalNaoTributado;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalIsencao(const ecfHandle: PECFHandle; var TotalIsencao : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalIsencao := ecfHandle^.ECF.TotalIsencao;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalCancelamentosISSQN(const ecfHandle: PECFHandle; var TotalCancelamentosISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalCancelamentosISSQN := ecfHandle^.ECF.TotalCancelamentosISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalDescontosISSQN(const ecfHandle: PECFHandle; var TotalDescontosISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalDescontosISSQN := ecfHandle^.ECF.TotalDescontosISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalAcrescimosISSQN(const ecfHandle: PECFHandle; var TotalAcrescimosISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalAcrescimosISSQN := ecfHandle^.ECF.TotalAcrescimosISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalSubstituicaoTributariaISSQN(const ecfHandle: PECFHandle; var TotalSubstituicaoTributariaISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalSubstituicaoTributariaISSQN := ecfHandle^.ECF.TotalSubstituicaoTributariaISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalNaoTributadoISSQN(const ecfHandle: PECFHandle; var TotalNaoTributadoISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalNaoTributadoISSQN := ecfHandle^.ECF.TotalNaoTributadoISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalIsencaoISSQN(const ecfHandle: PECFHandle; var TotalIsencaoISSQN : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalIsencaoISSQN := ecfHandle^.ECF.TotalIsencaoISSQN;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalNaoFiscal(const ecfHandle: PECFHandle; var TotalNaoFiscal : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalNaoFiscal := ecfHandle^.ECF.TotalNaoFiscal;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetNumUltItem(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      Result := ecfHandle^.ECF.NumUltItem;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

{%endregion}

{%region Propriedades - Componentes ACBr }

Function ECF_SetAAC(const ecfHandle: PECFHandle; const aacHandle : PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

  if (aacHandle = nil) then
  begin
  ecfHandle^.ECF.AAC := nil;
  Result := 0;
  end
  else
  begin
  ecfHandle^.ECF.AAC := aacHandle^.AAC;
  Result := 0;
  end;

  except on exception : Exception do
  begin
  ecfHandle^.UltimoErro := exception.Message;
  Result := -1;
  end
  end;
end;

Function ECF_SetEAD(const ecfHandle: PECFHandle; const eadHandle : PEADHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if (eadHandle = nil) then
  begin
  ecfHandle^.ECF.EAD := nil;
  Result := 0;
  end
  else
  begin
  ecfHandle^.ECF.EAD := eadHandle^.EAD;
  Result := 0;
  end;
  except on exception : Exception do
  begin
  ecfHandle^.UltimoErro := exception.Message;
  Result := -1;
  end
  end;
end;

Function ECF_SetRFD(const ecfHandle: PECFHandle; const rfdHandle : PRFDHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;
  try

  if (rfdHandle = nil) then
  begin
  ecfHandle^.ECF.RFD := nil;
  Result := 0;
  end
  else
  begin
  ecfHandle^.ECF.RFD := rfdHandle^.RFD;
  Result := 0;
  end;
  except on exception : Exception do
  begin
  ecfHandle^.UltimoErro := exception.Message;
  Result := -1;
  end
  end;
end;


{%endregion}

{%region ECF - Flags }

Function ECF_GetEmLinha(const ecfHandle: PECFHandle; const TimeOut : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     if (ecfHandle^.ECF.EmLinha(TimeOut)) then
       Result := 1
     else
       Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetPoucoPapel(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     if (ecfHandle^.ECF.PoucoPapel) then
       Result := 1
     else
       Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetEstado(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := integer(ecfHandle^.ECF.Estado);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetHorarioVerao(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.HorarioVerao then
        Result := 1
     Else
        Result := 0;


  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetArredonda(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.Arredonda then
        Result := 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTermica(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.Termica then
        Result := 1
     Else
        Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetMFD(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.MFD then
        Result:= 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetMFAdicional(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.MFAdicional;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetIdentificaConsumidorRodape(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.IdentificaConsumidorRodape then
        Result:= 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetParamDescontoISSQN(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.ParamDescontoISSQN then
        Result:= 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;


Function ECF_GetSubTotal(const ecfHandle: PECFHandle; var SubTotal : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;;

  try
     SubTotal := ecfHandle^.ECF.Subtotal;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetTotalPago(const ecfHandle: PECFHandle; var TotalPago : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TotalPago := ecfHandle^.ECF.TotalPago;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetGavetaAberta(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.GavetaAberta then
        Result := 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetChequePronto(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     If ecfHandle^.ECF.ChequePronto then
        Result := 1
     Else
        Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Métodos do componente}

Function ECF_Ativar(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Ativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;

end;

Function ECF_Desativar(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Desativar;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PreparaTEF(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  ecfHandle^.ECF.PreparaTEF;
  Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_TestaPodeAbrirCupom(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      ecfHandle^.ECF.TestaPodeAbrirCupom;
      Result := 0 ;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_Sangria(const ecfHandle: PECFHandle; const Valor: Double; const Obs, DescricaoCNF, DescricaoFPG : pChar;  IndiceBMP: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin


  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Sangria(Valor, Obs, DescricaoCNF, DescricaoFPG, IndiceBMP);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_Suprimento(const ecfHandle: PECFHandle; const Valor: Double; const Obs, DescricaoCNF, DescricaoFPG : pChar;  IndiceBMP: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Suprimento(Valor, Obs, DescricaoCNF, DescricaoFPG, IndiceBMP);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_AbreGaveta(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreGaveta;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_MudaHorarioVerao(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.MudaHorarioVerao;
     Result := 0 ;
  except
      on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_MudaArredondamento(const ecfHandle: PECFHandle;  const Arredondar: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.MudaArredondamento(Arredondar);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CorrigeEstadoErro(const ecfHandle: PECFHandle; const ReducaoZ: Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CorrigeEstadoErro(ReducaoZ);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_AcharECF(const ecfHandle: PECFHandle; const ProcuraModelo : Boolean; const ProcuraPorta  : Boolean; const TimeOut : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (ecfHandle^.ECF.AcharECF(ProcuraModelo, ProcuraPorta, TimeOut)) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_AcharPorta(const ecfHandle: PECFHandle; const TimeOut : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (ecfHandle^.ECF.AcharPorta(TimeOut))then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PulaLinhas(const ecfHandle: PECFHandle; const NumLinhas : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PulaLinhas(NumLinhas);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CortaPapel(const ecfHandle: PECFHandle; const CorteParcial : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CortaPapel(CorteParcial);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_IdentificaOperador(const ecfHandle: PECFHandle; const Nome : PChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.IdentificaOperador(Nome);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

{%endregion}

{%region Metodos Bobina }

Function ECF_SetMemoParams(const ecfHandle: PECFHandle; const linhas : array of PChar; const LinhasCount: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
i: Integer;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  ecfHandle^.ECF.MemoParams.Clear;
  for i := 0 to LinhasCount - 1 do
  begin
  ecfHandle^.ECF.MemoParams.Add(linhas[i]);
  end;
  Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetMemoParams(const ecfHandle: PECFHandle; linha : PChar; const BufferLen, index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.MemoParams[index];
     StrPLCopy(linha, strTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetMemoParamsCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  Result := ecfHandle^.ECF.MemoParams.Count;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_MemoLeParams(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  ecfHandle^.ECF.MemoLeParams;
  Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Métodos do cupom fiscal}

Function ECF_IdentificaConsumidor(const ecfHandle: PECFHandle; const CPF_CNPJ, Nome, Endereco : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.IdentificaConsumidor( CPF_CNPJ, Nome, Endereco );
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_AbreCupom(const ecfHandle: PECFHandle; const CPF_CNPJ, Nome, Endereco : pChar; const ModoPreVenda : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreCupom( CPF_CNPJ, Nome, Endereco, ModoPreVenda);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_LegendaInmetroProximoItem(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LegendaInmetroProximoItem;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_VendeItem(const ecfHandle: PECFHandle;
                       const Codigo, Descricao, AliquotaICMS : pChar;
                       const Qtd, ValorUnitario, DescontoPorc : Double;
                       const Unidade, TipoDescontoAcrescimo,
                       DescontoAcrescimo : pChar; const CodDepartamento: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.VendeItem(Codigo, Descricao, AliquotaICMS, Qtd, ValorUnitario,
                              DescontoPorc, Unidade, TipoDescontoAcrescimo, DescontoAcrescimo, CodDepartamento );
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DescontoAcrescimoItemAnterior(const ecfHandle: PECFHandle;
                                           const ValorDescontoAcrescimo : Double; const DescontoAcrescimo, TipoDescontoAcrescimo : pChar; const Item : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DescontoAcrescimoItemAnterior(ValorDescontoAcrescimo, DescontoAcrescimo, TipoDescontoAcrescimo, Item);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_SubtotalizaCupom(const ecfHandle: PECFHandle; const DescontoAcrescimo : Double ; const MensagemRodape : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.SubtotalizaCupom( DescontoAcrescimo, MensagemRodape );
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_EfetuaPagamento(const ecfHandle: PECFHandle; const CodFormaPagto : pChar; const Valor : Double; const Observacao : pChar ; const ImprimeVinculado : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.EfetuaPagamento(CodFormaPagto, Valor, Observacao, ImprimeVinculado);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_EstornaPagamento(const ecfHandle: PECFHandle; const CodFormaPagtoEstornar : pChar; const CodFormaPagtoEfetivar : pChar; const Valor: Double; const Observacao : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.EstornaPagamento(CodFormaPagtoEstornar, CodFormaPagtoEfetivar, Valor, Observacao);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_FechaCupom(const ecfHandle: PECFHandle; const Observacao : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.FechaCupom( Observacao );
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CancelaCupom(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaCupom;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CancelaItemVendido(const ecfHandle: PECFHandle; const NumItem : Integer ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaItemVendido( NumItem );
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CancelaItemVendidoParcial(const ecfHandle: PECFHandle; const NumItem : Integer; const Quantidade : Double ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaItemVendidoParcial(NumItem, Quantidade);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CancelaDescontoAcrescimoItem(const ecfHandle: PECFHandle; const NumItem : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaDescontoAcrescimoItem(NumItem);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_CancelaDescontoAcrescimoSubTotal(const ecfHandle: PECFHandle; const TipoAcrescimoDesconto : Char) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaDescontoAcrescimoSubTotal(TipoAcrescimoDesconto);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Cupom Vinculado }

Function ECF_AbreCupomVinculado(const ecfHandle: PECFHandle; const COO, CodFormaPagto : pChar; const Valor : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreCupomVinculado(COO, CodFormaPagto, Valor);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_AbreCupomVinculadoCNF(const ecfHandle: PECFHandle; const COO, CodFormaPagto, CodComprovanteNaoFiscal : pChar; const Valor : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreCupomVinculado(COO, CodFormaPagto, CodComprovanteNaoFiscal, Valor);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_LinhaCupomVinculado(const ecfHandle: PECFHandle; const Linha : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LinhaCupomVinculado(Linha);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_ReimpressaoVinculado(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.ReimpressaoVinculado;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SegundaViaVinculado(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.SegundaViaVinculado;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Alíquotas}

Function ECF_GetAliquota(const ecfHandle: PECFHandle; var retAliquota : TAliquotaRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  aliquota : TACBrECFAliquota;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

   aliquota := ecfHandle^.ECF.Aliquotas[index];
   StrPLCopy(retAliquota.Indice, aliquota.Indice, 4);
   retAliquota.Aliquota := aliquota.Aliquota;
   retAliquota.Tipo := aliquota.Tipo;
   retAliquota.Total := aliquota.Total;
   retAliquota.Sequencia := aliquota.Sequencia;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_GetALCount(const ecfHandle: PECFHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   if Assigned(ecfHandle^.ECF.Aliquotas) then
   begin
     value := ecfHandle^.ECF.Aliquotas.Count;
     Result := 1;
   end
   else
     Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_CarregaAliquotas(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CarregaAliquotas;
     Result := ecfHandle^.ECF.Aliquotas.Count;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetAliquotasStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  I : Integer;
  strTmp : string ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      strTmp := '' ;
      if ecfHandle^.ECF.Aliquotas.Count < 1 then
        ecfHandle^.ECF.CarregaAliquotas ;

      for I := 0 to ecfHandle^.ECF.Aliquotas.Count -1 do
         strTmp := strTmp + padL(ecfHandle^.ECF.Aliquotas[I].Indice,4)
                      + ' '
                      + ecfHandle^.ECF.Aliquotas[I].Tipo
                      + FormatFloat('#0.00', ecfHandle^.ECF.Aliquotas[I].Aliquota) + '|' ;

     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_LerTotaisAliquota(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
     ecfHandle^.ECF.LerTotaisAliquota;
     Result := ecfHandle^.ECF.Aliquotas.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_LerTotaisAliquotaStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  I : Integer;
  strTmp : string ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      strTmp := '' ;
      ecfHandle^.ECF.LerTotaisAliquota ;

      for I := 0 to ecfHandle^.ECF.Aliquotas.Count -1 do
         strTmp := strTmp + padL(ecfHandle^.ECF.Aliquotas[I].Indice,4) +
                            FormatFloat('########0.00', ecfHandle^.ECF.Aliquotas[I].Total ) + '|' ;


     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_ProgramaAliquota(const ecfHandle: PECFHandle; const Aliquota : Double; const Tipo : Char) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      ecfHandle^.ECF.ProgramaAliquota(Aliquota, Tipo);
      Result := 0 ;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_AchaIcmsAliquota(const ecfHandle: PECFHandle;
                              const Aliq : Double ;
                              const Tipo : Char ;
                              var ret_pos : pchar ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
    ICMS : TACBrECFAliquota;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      ICMS := ecfHandle^.ECF.AchaICMSAliquota( Aliq, Tipo  ) ;
      if ICMS <> nil then
              ret_pos := pchar(padL(ICMS.Indice,4))
      else
         ret_pos := pchar(padL('-1',4));
      Result := 0 ;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

{%endregion}

{%region Forma de pagamento}

Function ECF_GetFormaPagamento(const ecfHandle: PECFHandle; var retFormaPagamento : TFormaPagamentoRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  formaPagamento : TACBrECFFormaPagamento;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.FormasPagamento.Count) then
      begin

              formaPagamento := ecfHandle^.ECF.FormasPagamento[index];

              StrPLCopy(retFormaPagamento.Indice, formaPagamento.Indice, 4);
              StrPLCopy(retFormaPagamento.Descricao, formaPagamento.Descricao, 30);
              retFormaPagamento.PermiteVinculado := formaPagamento.PermiteVinculado;
              retFormaPagamento.Total := formaPagamento.Total;
              retFormaPagamento.Data:= formaPagamento.Data;
              StrPLCopy(retFormaPagamento.TipoDoc, formaPagamento.TipoDoc, 30);
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_GetFPGCount(const ecfHandle: PECFHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
    if Assigned(ecfHandle^.ECF.FormasPagamento) then
   begin
     value := ecfHandle^.ECF.FormasPagamento.Count;
     Result := 1;
   end
   else
     Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_CarregaFormasPagamento(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CarregaFormasPagamento;
     Result := ecfHandle^.ECF.FormasPagamento.Count;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_LerTotaisFormaPagamento(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      ecfHandle^.ECF.LerTotaisFormaPagamento;
      Result := ecfHandle^.ECF.FormasPagamento.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_GetFormasPagamentoStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  I : Integer;
  strTmp : string;
  Vinc : Char ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      strTmp := '' ;
      if ecfHandle^.ECF.FormasPagamento.Count < 1 then
         ecfHandle^.ECF.CarregaFormasPagamento ;


      for I := 0 to ecfHandle^.ECF.FormasPagamento.Count -1 do
      begin
         Vinc := ' ' ;
         if ecfHandle^.ECF.FormasPagamento[I].PermiteVinculado then
            Vinc := 'V' ;

         strTmp := strTmp + padL(ecfHandle^.ECF.FormasPagamento[I].Indice,4)
                      + ' '
                      + Vinc
                      + ecfHandle^.ECF.FormasPagamento[I].Descricao
                      + '|' ;
      end;

      StrPLCopy(Buffer, strTmp, BufferLen);
      Result := length(strTmp)
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_LerTotaisFormaPagamentoStr(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  I : Integer;
  strTmp : string ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      strTmp := '' ;
      ecfHandle^.ECF.LerTotaisFormaPagamento ;

      for I := 0 to ecfHandle^.ECF.FormasPagamento.Count -1 do
         strTmp := strTmp + padL(ecfHandle^.ECF.FormasPagamento[I].Indice,4)
                      + FormatFloat('########0.00', ecfHandle^.ECF.FormasPagamento[I].Total ) + '|' ;


      StrPLCopy(Buffer, strTmp, BufferLen);
      Result := length(strTmp)
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_ProgramaFormaPagamento(const ecfHandle: PECFHandle; const Descricao : pChar ; const PermiteVinculado : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  pDesc : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      pDesc := String(Descricao);
      ecfHandle^.ECF.ProgramaFormaPagamento(pDesc, PermiteVinculado);
      Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_AchaFPGDescricao(const ecfHandle: PECFHandle; const descricao : pChar; const BuscaExata, IgnorarCase : Boolean; var retFormaPagamento : TFormaPagamentoRec) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
   FormPGT : TACBrECFFormaPagamento;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     FormPGT := ecfHandle^.ECF.AchaFPGDescricao(descricao, BuscaExata, IgnorarCase);
     if FormPGT <> nil then
     begin
           retFormaPagamento.Data := FormPGT.Data;
           retFormaPagamento.Descricao := FormPGT.Descricao;
           retFormaPagamento.Indice := FormPGT.Indice;
           retFormaPagamento.PermiteVinculado := FormPGT.PermiteVinculado;
           retFormaPagamento.TipoDoc := FormPGT.TipoDoc;
           retFormaPagamento.Total := FormPGT.Total;
           Result := 1 ;
     end
     else
     Begin
           Result := 0;
     end

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_AchaFPGIndice(const ecfHandle: PECFHandle; const indice : pChar; var retFormaPagamento : TFormaPagamentoRec) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
   FormPGT : TACBrECFFormaPagamento;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     FormPGT := ecfHandle^.ECF.AchaFPGIndice(indice);
     if FormPGT <> nil then
     begin
           retFormaPagamento.Data := FormPGT.Data;
           retFormaPagamento.Descricao := FormPGT.Descricao;
           retFormaPagamento.Indice := FormPGT.Indice;
           retFormaPagamento.PermiteVinculado := FormPGT.PermiteVinculado;
           retFormaPagamento.TipoDoc := FormPGT.TipoDoc;
           retFormaPagamento.Total := FormPGT.Total;
           Result := 1 ;
     end
     else
     Begin
           Result := 0;
     end

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Comprovantes Não Fiscais}

Function ECF_AbreNaoFiscal(const ecfHandle: PECFHandle; const CPF_CNPJ, Nome, Endereco : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreNaoFiscal(CPF_CNPJ, Nome, Endereco);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_RegistraItemNaoFiscal(const ecfHandle: PECFHandle; const CodCNF: pChar; const Valor: Double; const Obs: pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.RegistraItemNaoFiscal(CodCNF,Valor,Obs);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_SubtotalizaNaoFiscal(const ecfHandle: PECFHandle; const DescontoAcrescimo: Double; const MensagemRodape: pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.SubtotalizaNaoFiscal(DescontoAcrescimo,MensagemRodape);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_EfetuaPagamentoNaoFiscal(const ecfHandle: PECFHandle; const CodFormaPagto: pChar; const Valor: Double; const Observacao: pChar; const ImprimeVinculado: Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.EfetuaPagamentoNaoFiscal(CodFormaPagto,Valor,Observacao,ImprimeVinculado);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_FechaNaoFiscal(const ecfHandle: PECFHandle; const Observacao: pChar; const IndiceBMP : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.FechaNaoFiscal(Observacao, IndiceBMP);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_CancelaNaoFiscal(const ecfHandle: PECFHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CancelaNaoFiscal;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_GetComprovanteNaoFiscal(const ecfHandle: PECFHandle; var retComprovanteNaoFiscal : TComprovanteNaoFiscalRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  comprovanteNaoFiscal : TACBrECFComprovanteNaoFiscal;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.ComprovantesNaoFiscais.Count) then
      begin
              comprovanteNaoFiscal := ecfHandle^.ECF.ComprovantesNaoFiscais[index];

              StrPLCopy(retComprovanteNaoFiscal.Indice, comprovanteNaoFiscal.Indice, 4);
              StrPLCopy(retComprovanteNaoFiscal.Descricao, comprovanteNaoFiscal.Descricao, 30);
              retComprovanteNaoFiscal.PermiteVinculado := comprovanteNaoFiscal.PermiteVinculado;
              StrPLCopy(retComprovanteNaoFiscal.FormaPagamento, comprovanteNaoFiscal.FormaPagamento, 4);
              retComprovanteNaoFiscal.Total := comprovanteNaoFiscal.Total;
              retComprovanteNaoFiscal.Contador := comprovanteNaoFiscal.Contador;
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_GetCNFCount(const ecfHandle: PECFHandle; var value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
    if Assigned(ecfHandle^.ECF.ComprovantesNaoFiscais) then
   begin
     value := ecfHandle^.ECF.ComprovantesNaoFiscais.Count;
     Result := 1;
   end
   else
     Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_CarregaComprovantesNaoFiscais(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.CarregaComprovantesNaoFiscais;
     Result := ecfHandle^.ECF.ComprovantesNaoFiscais.Count;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_LerTotaisComprovanteNaoFiscal(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
     ecfHandle^.ECF.LerTotaisComprovanteNaoFiscal;
     Result := ecfHandle^.ECF.ComprovantesNaoFiscais.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_ComprovantesNaoFiscais(const ecfHandle: PECFHandle; var v_ComprovantesNaoFiscais : pchar ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
Var
  I : Integer;
  resp : string;
  Vinc : Char;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      resp := '' ;
      if ecfHandle^.ECF.ComprovantesNaoFiscais.Count < 1 then
         ecfHandle^.ECF.CarregaComprovantesNaoFiscais ;


      for I := 0 to ecfHandle^.ECF.ComprovantesNaoFiscais.Count -1 do
      begin
         Vinc := ' ' ;
         if ecfHandle^.ECF.ComprovantesNaoFiscais[I].PermiteVinculado then
            Vinc := 'V' ;

         resp := resp + padL(ecfHandle^.ECF.ComprovantesNaoFiscais[I].Indice,4)
                      + ' '
                      + Vinc
                      + ecfHandle^.ECF.ComprovantesNaoFiscais[I].Descricao
                      + '|' ;
      end;
      if resp <> '' then
      begin
         v_ComprovantesNaoFiscais := pchar(copy(resp,1,Length(resp)-1)) ;
      End;
      Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
   end;
end;

Function ECF_LerTotaisComprovante(const ecfHandle: PECFHandle; var v_LerTotaisComprovante : pchar ) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
   Var I : Integer;
      resp : string ;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      resp := '' ;
      ecfHandle^.ECF.LerTotaisComprovanteNaoFiscal;

      for I := 0 to ecfHandle^.ECF.ComprovantesNaoFiscais.Count -1 do
         resp := resp + padL(ecfHandle^.ECF.ComprovantesNaoFiscais[I].Indice,4)
                      + FormatFloat('########0.00', ecfHandle^.ECF.ComprovantesNaoFiscais[I].Total ) + '|' ;


      if resp <> '' then
      begin
         v_LerTotaisComprovante := pchar(copy(resp,1,Length(resp)-1)) ;
      End;
      Result := 0 ;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
   end;
end;

Function ECF_ProgramaComprovanteNaoFiscal(const ecfHandle: PECFHandle; const Descricao, Tipo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  pDesc : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      pDesc := String(Descricao);
      ecfHandle^.ECF.ProgramaComprovanteNaoFiscal(pDesc, Tipo);
      Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_AchaCNFDescricao(const ecfHandle: PECFHandle; var retComprovanteNaoFiscal : TComprovanteNaoFiscalRec; const descricao : pChar;
                              const busca, ignore : Boolean) : Integer ;  cdecl;  export;
var
CNF    : TACBrECFComprovanteNaoFiscal;
begin

   if (ecfHandle = nil) then
   begin
      Result := -2;
      Exit;
   end;

   try
   CNF := ecfHandle^.ECF.AchaCNFDescricao(descricao, busca, ignore);
   if CNF <> nil then
   Begin
   StrPLCopy(retComprovanteNaoFiscal.Indice, CNF.Indice, 4);
   StrPLCopy(retComprovanteNaoFiscal.Descricao, CNF.Descricao, 30);
   retComprovanteNaoFiscal.PermiteVinculado := CNF.PermiteVinculado;
   StrPLCopy(retComprovanteNaoFiscal.FormaPagamento, CNF.FormaPagamento, 4);
   retComprovanteNaoFiscal.Total := CNF.Total;
   retComprovanteNaoFiscal.Contador := CNF.Contador;
   Result := 1;
   end
   else
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
   end;
end;

{%endregion}

{%region Leitura Memoria Fiscal }

Function ECF_LeituraMemoriaFiscalReducao(const ecfHandle: PECFHandle; const ReducaoInicial : Integer; const ReducaoFinal: Integer; const Simplificada : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LeituraMemoriaFiscal(ReducaoInicial, ReducaoFinal, Simplificada);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_LeituraMemoriaFiscalData(const ecfHandle: PECFHandle; const DataInicial : double; const DataFinal: double; const Simplificada : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LeituraMemoriaFiscal(DataInicial, DataFinal, Simplificada);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_LeituraMemoriaFiscalSerialReducao(const ecfHandle: PECFHandle; const ReducaoInicial : Integer; const ReducaoFinal: Integer; const Simplificada : Boolean; Buffer : pChar; const BufferLen : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
   var lista : TStringList;
begin

  try
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lista := TStringList.Create;
     lista.Delimiter := #10;

     ecfHandle^.ECF.LeituraMemoriaFiscalSerial(ReducaoInicial, ReducaoFinal, lista, Simplificada);

     StrPLCopy(Buffer, lista.DelimitedText, BufferLen);
     Result := length(lista.DelimitedText);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
  finally
    FreeAndNil(lista);
  end;
end;

Function ECF_LeituraMemoriaFiscalSerialData(const ecfHandle: PECFHandle; const DataInicial : double; const DataFinal: double; const Simplificada : Boolean;  Buffer : pChar; const BufferLen : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
  var lista : TStringList;

begin

  try
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lista := TStringList.Create;
     lista.Delimiter := #10;

     ecfHandle^.ECF.LeituraMemoriaFiscalSerial(DataInicial, DataFinal, lista, Simplificada);

     StrPLCopy(Buffer, lista.DelimitedText, BufferLen);
     Result := length(lista.DelimitedText);

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
  finally
    FreeAndNil(lista);
  end;
end;

Function ECF_LeituraMemoriaFiscalArquivoReducao(const ecfHandle: PECFHandle; const ReducaoInicial : Integer; const ReducaoFinal: Integer; const NomeArquivo: pChar; const Simplificada : Boolean) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     ecfHandle^.ECF.LeituraMemoriaFiscalSerial(ReducaoInicial, ReducaoFinal, NomeArquivo, Simplificada);
     Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_LeituraMemoriaFiscalArquivoData(const ecfHandle: PECFHandle; const DataInicial : double; const DataFinal: double; const NomeArquivo: pChar; const Simplificada : Boolean) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     ecfHandle^.ECF.LeituraMemoriaFiscalSerial(DataInicial, DataFinal, NomeArquivo, Simplificada);
     Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

{%endregion}

{%region Leitura X}

Function ECF_LeituraX(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LeituraX;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PafMF_LX_Impressao(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PafMF_LX_Impressao;
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Redução Z }

Function ECF_ReducaoZ(const ecfHandle: PECFHandle; Const date : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.ReducaoZ(date);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_GetDadosReducaoZ(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_GetDadosUltimaReducaoZ(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosUltimaReducaoZ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Redução Z Class}

Function ECF_DadosReducaoZClass_GetCOO(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.COO;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCFD(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CFD;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCancelamentoISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.CancelamentoISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetGNFC(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.GNFC;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCRO(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CRO;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetValorVendaBruta(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.ValorVendaBruta;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetAcrescimoICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.AcrescimoICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDataHoraEmissao(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DataHoraEmissao;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDescontoICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DescontoICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetNaoTributadoICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.NaoTributadoICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCRZ(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CRZ;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetGRG(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.GRG;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetValorGrandeTotal(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.ValorGrandeTotal;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetAcrescimoISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.AcrescimoISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetNaoTributadoISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.NaoTributadoISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetIsentoICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.IsentoICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.SubstituicaoTributariaICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDataDaImpressora(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DataDaImpressora;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.TotalOperacaoNaoFiscal;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDescontoISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DescontoISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCancelamentoOPNF(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.CancelamentoOPNF;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetAcrescimoOPNF(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.AcrescimoOPNF;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDescontoOPNF(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DescontoOPNF;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCancelamentoICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.CancelamentoICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetGNF(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.GNF;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetIsentoISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.IsentoISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.SubstituicaoTributariaISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetVendaLiquida(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.VendaLiquida;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCFC(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CFC;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCCF(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CCF;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetTotalISSQN(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.TotalISSQN;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetTotalICMS(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.TotalICMS;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCDC(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CDC;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCCDC(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.CCDC;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetNCN(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.NCN;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetDataDoMovimento(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.DataDoMovimento;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetNumeroCOOInicial(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.NumeroCOOInicial;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DadosReducaoZClass_GetNumeroDoECF(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.NumeroDoECF;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DadosReducaoZClass_GetNumeroDeSerie(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.NumeroDeSerie;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DadosReducaoZClass_GetNumeroDeSerieMFD(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.NumeroDeSerieMFD;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DadosReducaoZClass_GetNumeroDaLoja(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.NumeroDaLoja;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DadosReducaoZClass_GetTotalTroco(const ecfHandle: PECFHandle; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   value := ecfHandle^.ECF.DadosReducaoZClass.TotalTroco;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCNFCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.TotalizadoresNaoFiscais.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetCNF(const ecfHandle: PECFHandle; var retComprovanteNaoFiscal : TComprovanteNaoFiscalRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  comprovanteNaoFiscal : TACBrECFComprovanteNaoFiscal;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.DadosReducaoZClass.TotalizadoresNaoFiscais.Count) then
      begin
              comprovanteNaoFiscal := ecfHandle^.ECF.DadosReducaoZClass.TotalizadoresNaoFiscais[index];

              StrPLCopy(retComprovanteNaoFiscal.Indice, comprovanteNaoFiscal.Indice, 4);
              StrPLCopy(retComprovanteNaoFiscal.Descricao, comprovanteNaoFiscal.Descricao, 30);
              retComprovanteNaoFiscal.PermiteVinculado := comprovanteNaoFiscal.PermiteVinculado;
              StrPLCopy(retComprovanteNaoFiscal.FormaPagamento, comprovanteNaoFiscal.FormaPagamento, 4);
              retComprovanteNaoFiscal.Total := comprovanteNaoFiscal.Total;
              retComprovanteNaoFiscal.Contador := comprovanteNaoFiscal.Contador;
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetICMSCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.ICMS.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetICMS(const ecfHandle: PECFHandle; var retAliquota : TAliquotaRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  aliquota : TACBrECFAliquota;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

   aliquota := ecfHandle^.ECF.DadosReducaoZClass.ICMS[index];
   StrPLCopy(retAliquota.Indice, aliquota.Indice, 4);
   retAliquota.Aliquota := aliquota.Aliquota;
   retAliquota.Tipo := aliquota.Tipo;
   retAliquota.Total := aliquota.Total;
   retAliquota.Sequencia := aliquota.Sequencia;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetRGCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.RelatorioGerencial.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetRG(const ecfHandle: PECFHandle; var retRelatorios : TRelatorioGerencialRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  relatorios : TACBrECFRelatorioGerencial;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.DadosReducaoZClass.RelatorioGerencial.Count) then
      begin

              relatorios := ecfHandle^.ECF.DadosReducaoZClass.RelatorioGerencial[index];

              StrPLCopy(retRelatorios.Indice, relatorios.Indice, 4);
              StrPLCopy(retRelatorios.Descricao, relatorios.Descricao, 30);
              retRelatorios.Contador := relatorios.Contador;
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetISSQNCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.ISSQN.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetISSQN(const ecfHandle: PECFHandle; var retAliquota : TAliquotaRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  aliquota : TACBrECFAliquota;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

   aliquota := ecfHandle^.ECF.DadosReducaoZClass.ISSQN[index];
   StrPLCopy(retAliquota.Indice, aliquota.Indice, 4);
   retAliquota.Aliquota := aliquota.Aliquota;
   retAliquota.Tipo := aliquota.Tipo;
   retAliquota.Total := aliquota.Total;
   retAliquota.Sequencia := aliquota.Sequencia;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end
end;

Function ECF_DadosReducaoZClass_GetFPGCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   Result := ecfHandle^.ECF.DadosReducaoZClass.MeiosDePagamento.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_GetFPG(const ecfHandle: PECFHandle; var retFormaPagamento : TFormaPagamentoRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  formaPagamento : TACBrECFFormaPagamento;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.DadosReducaoZClass.MeiosDePagamento.Count) then
      begin

              formaPagamento := ecfHandle^.ECF.DadosReducaoZClass.MeiosDePagamento[index];

              StrPLCopy(retFormaPagamento.Indice, formaPagamento.Indice, 4);
              StrPLCopy(retFormaPagamento.Descricao, formaPagamento.Descricao, 30);
              retFormaPagamento.PermiteVinculado := formaPagamento.PermiteVinculado;
              retFormaPagamento.Total := formaPagamento.Total;
              retFormaPagamento.Data:= formaPagamento.Data;
              StrPLCopy(retFormaPagamento.TipoDoc, formaPagamento.TipoDoc, 30);
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_CalculaValoresVirtuais(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
   ecfHandle^.ECF.DadosReducaoZClass.CalculaValoresVirtuais;
   Result := 0;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_DadosReducaoZClass_MontaDadosReducaoZ(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := ecfHandle^.ECF.DadosReducaoZClass.MontaDadosReducaoZ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region PAF }

Function ECF_IdentificaPAF(const ecfHandle: PECFHandle; const NomeVersao : pChar; const MD5 : pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     ecfHandle^.ECF.IdentificaPAF(NomeVersao, MD5);
     Result := 0;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_PafMF_GerarCAT52(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double; const CaminhoArquivo: pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
        Result := -2;
        Exit;
  end;

  try
  ecfHandle^.ECF.PafMF_GerarCAT52(DataInicial, DataFinal, CaminhoArquivo);
  Result := 0;
  except
     on exception : Exception do
     begin
     ecfHandle^.UltimoErro := exception.Message;
     Result := -1;
     end
  end
end;

Function ECF_DoAtualizarValorGT(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DoAtualizarValorGT;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_DoVerificaValorGT(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DoVerificaValorGT;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region PAF LMFC }

Function ECF_PafMF_LMFC_Cotepe1704(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double; const CaminhoArquivo: pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Cotepe1704(DataInicial, DataFinal, CaminhoArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFC_Cotepe1704_CRZ( const ecfHandle: PECFHandle; const CRZInicial, CRZFinal: Integer;
      const PathArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Cotepe1704(CRZInicial, CRZFinal, PathArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFC_Espelho(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double; const CaminhoArquivo: pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Espelho(DataInicial, DataFinal, CaminhoArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFC_Espelho_CRZ(const ecfHandle: PECFHandle; const CRZInicial, CRZFinal: Integer;
      const PathArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Espelho(CRZInicial, CRZFinal, PathArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFC_Impressao(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Impressao(DataInicial, DataFinal);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFC_Impressao_CRZ(const ecfHandle: PECFHandle; const CRZInicial, CRZFinal: Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFC_Impressao(CRZInicial, CRZFinal);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

{%endregion}

{%region PAF LMFS }

Function ECF_PafMF_LMFS_Espelho(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double; const CaminhoArquivo: pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFS_Espelho(DataInicial, DataFinal, CaminhoArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFS_Espelho_CRZ( const ecfHandle: PECFHandle; const CRZInicial, CRZFinal: Integer;
      const PathArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFS_Espelho(CRZInicial, CRZFinal, PathArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFS_Impressao(const ecfHandle: PECFHandle; const DataInicial , DataFinal: double) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFS_Impressao(DataInicial, DataFinal);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_LMFS_Impressao_CRZ(const ecfHandle: PECFHandle; const CRZInicial, CRZFinal: Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_LMFS_Impressao(CRZInicial, CRZFinal);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

{%endregion}

{%region PAF Espelho MFD }

Function ECF_PafMF_MFD_Cotepe1704( const ecfHandle: PECFHandle; const DataInicial, DataFinal: double; const CaminhoArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_MFD_Cotepe1704(DataInicial, DataFinal, CaminhoArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_MFD_Cotepe1704_COO( const ecfHandle: PECFHandle; const COOInicial, COOFinal: Integer;
      const PathArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_MFD_Cotepe1704(COOInicial, COOFinal, PathArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

{%endregion}

{%region PAF Arquivos }

Function ECF_ArquivoMFD_DLL( const ecfHandle: PECFHandle; const DataInicial, DataFinal: double; const Arquivo : pChar ;
      const Documentos: array of Integer; const QTD_DOC, Finalidade : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  DocumentSet   : TACBrECFTipoDocumentoSet;
  i             : Integer;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

try
if (QTD_DOC = 0) And (Finalidade = -1) then
begin
   ecfHandle^.ECF.ArquivoMFD_DLL(DataInicial, DataFinal, Arquivo);
end
else
begin
DocumentSet := [];
for i := 0 to QTD_DOC - 1 do
begin
  Include(DocumentSet, TACBrECFTipoDocumento(Documentos[i]));
end;
ecfHandle^.ECF.ArquivoMFD_DLL(DataInicial, DataFinal, Arquivo, DocumentSet, TACBrECFFinalizaArqMFD(Finalidade));
end;

Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_ArquivoMFD_DLL_COO( const ecfHandle: PECFHandle; const COOInicial, COOFinal: Integer; const Arquivo : pChar ;
      const Documentos: array of Integer; const QTD_DOC, Finalidade, TipoContador : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  DocumentSet   : TACBrECFTipoDocumentoSet;
  i             : Integer;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

try
if (QTD_DOC = 0) And (Finalidade = -1) And (TipoContador = -1) then
begin
   ecfHandle^.ECF.ArquivoMFD_DLL(COOInicial, COOFinal, Arquivo);
end
else
begin
DocumentSet := [];
for i := 0 to QTD_DOC - 1 do
begin
  Include(DocumentSet, TACBrECFTipoDocumento(Documentos[i]));
end;
ecfHandle^.ECF.ArquivoMFD_DLL(COOInicial, COOFinal, Arquivo, DocumentSet, TACBrECFFinalizaArqMFD(Finalidade), TACBrECFTipoContador(TipoContador));
end;

Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_EspelhoMFD_DLL( const ecfHandle: PECFHandle; const DataInicial, DataFinal: double; const Arquivo : pChar ;const Documentos: array of Integer; const QTD_DOC : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  DocumentSet   : TACBrECFTipoDocumentoSet;
  i             : Integer;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

try
if (QTD_DOC = 0)then
begin
   ecfHandle^.ECF.EspelhoMFD_DLL(DataInicial, DataFinal, Arquivo);
end
else
begin
DocumentSet := [];
for i := 0 to QTD_DOC - 1 do
begin
  Include(DocumentSet, TACBrECFTipoDocumento(Documentos[i]));
end;
ecfHandle^.ECF.EspelhoMFD_DLL(DataInicial, DataFinal, Arquivo, DocumentSet);
end;

Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_EspelhoMFD_DLL_COO( const ecfHandle: PECFHandle; const COOInicial, COOFinal: Integer; const Arquivo : pChar ;const Documentos: array of Integer; const QTD_DOC: Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  DocumentSet   : TACBrECFTipoDocumentoSet;
  i             : Integer;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

try
if (QTD_DOC = 0)then
begin
   ecfHandle^.ECF.EspelhoMFD_DLL(COOInicial, COOFinal, Arquivo);
end
else
begin
DocumentSet := [];
for i := 0 to QTD_DOC - 1 do
begin
  Include(DocumentSet, TACBrECFTipoDocumento(Documentos[i]));
end;
ecfHandle^.ECF.EspelhoMFD_DLL(COOInicial, COOFinal, Arquivo, DocumentSet);
end;

Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_Binario(const ecfHandle: PECFHandle; const path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PafMF_Binario(path);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PafMF_ArqMF(const ecfHandle: PECFHandle; const path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PafMF_ArqMF(path);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PafMF_ArqMFD(const ecfHandle: PECFHandle; const path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.PafMF_ArqMFD(path);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region PAF Arq. MFD }

Function ECF_PafMF_MFD_Espelho( const ecfHandle: PECFHandle; const DataInicial, DataFinal: double; const CaminhoArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_MFD_Espelho(DataInicial, DataFinal, CaminhoArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

Function ECF_PafMF_MFD_Espelho_COO( const ecfHandle: PECFHandle; const COOInicial, COOFinal: Integer;
      const PathArquivo: pChar ) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;

try
ecfHandle^.ECF.PafMF_MFD_Espelho(COOInicial, COOFinal, PathArquivo);
Result := 0;
except
on exception : Exception do
begin
ecfHandle^.UltimoErro := exception.Message;
Result := -1;
end
end;
end;

{%endregion}

{%region Metodos DAV }

Function ECF_DAV_Abrir(const ecfHandle: PECFHandle; const AEmissao : double;
      const ADescrDocumento, ANumero, ASituacao, AVendedor, AObservacao,
      ACNPJCPF, ANomeCliente, AEndereco: pChar; AIndice : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DAV_Abrir(AEmissao, AdescrDocumento, ANumero, ASituacao, AVendedor, AObservacao, ACNPJCPF, ANomeCliente, AEndereco, AIndice);
     Result := 0;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DAV_RegistrarItem(const ecfHandle: PECFHandle; const ACodigo, ADescricao, AUnid : pChar;
      const AQuantidade, AVlrUnitario, AVlrDesconto, AVlrAcrescimo: Double;
      const ACancelado: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DAV_RegistrarItem(ACodigo, ADescricao, AUnid, AQuantidade, AVlrUnitario, AVlrDesconto, AVlrAcrescimo, ACancelado);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function ECF_DAV_Fechar(const ecfHandle: PECFHandle; const Observacao : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DAV_Fechar( Observacao );
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_PafMF_RelDAVEmitidos(const ecfHandle: PECFHandle; const DAVsEmitidos: array of TDAVsRec; const Index : Integer;
      const TituloRelatorio: pChar; const IndiceRelatorio: Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  DAVs: TACBrECFDAVs;
  I : Integer;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;
if(Index <= 0) then
begin
   ecfHandle^.UltimoErro := 'O Número de DAVs precisa ser maior que zero';
   Result := -1;
end;
try
   DAVs := TACBrECFDAVs.Create;
   for I := 0 to Index - 1 do
   begin
   with DAVs.New do
       begin
         Numero    := DAVsEmitidos[i].Numero;
         COO_Dav   := DAVsEmitidos[i].COO_Dav;
         COO_Cupom := DAVsEmitidos[i].COO_Cupom;
         Titulo    := DAVsEmitidos[i].Titulo;
         DtEmissao := DAVsEmitidos[i].DtEmissao;
         Valor     := DAVsEmitidos[i].Valor;
       end;
   end;

   ecfHandle^.ECF.PafMF_RelDAVEmitidos(DAVs, TituloRelatorio, IndiceRelatorio);
   DAVs.Free;
   Result := 0;
except
   on exception : Exception do
begin
  ecfHandle^.UltimoErro := exception.Message;
  DAVs.Free;
  Result := -1;
end
end;
end;

{%endregion}

{%region Paf Rels }

Function ECF_PafMF_RelMeiosPagamento(const ecfHandle: PECFHandle; const formasPagamento: array of TFormaPagamentoRec; const Index : Integer; const TituloRelatorio: pChar; const IndiceRelatorio: Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  AFormasPagamento : TACBrECFFormasPagamento;
  I : Integer;
begin
if (ecfHandle = nil) then
begin
Result := -2;
Exit;
end;
if(Index <= 0) then
begin
   ecfHandle^.UltimoErro := 'O Número de formas de pagamento precisa ser maior que zero';
   Result := -1;
end;
try
   AFormasPagamento := TACBrECFFormasPagamento.Create;
   for I := 0 to Index - 1 do
   begin
   with AFormasPagamento.New do
       begin
         Indice              := formasPagamento[i].Indice;
         Descricao           := formasPagamento[i].Descricao;
         PermiteVinculado    := formasPagamento[i].PermiteVinculado;
         Total               := formasPagamento[i].Total;
         Data                := formasPagamento[i].Data;
         TipoDoc             := formasPagamento[i].TipoDoc;
       end;
   end;

   ecfHandle^.ECF.PafMF_RelMeiosPagamento(AFormasPagamento, TituloRelatorio, IndiceRelatorio);
   AFormasPagamento.Free;
   Result := 0;
except
   on exception : Exception do
begin
  ecfHandle^.UltimoErro := exception.Message;
  AFormasPagamento.Free;
  Result := -1;
end
end;
end;

Function ECF_PafMF_RelIdentificacaoPafECF(const ecfHandle: PECFHandle; const aacHandle : PAACHandle; const indiceRelatorio : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
    Result := -2;
    Exit;
end;

if (aacHandle = nil) then
begin
    Result := -1;
    ecfHandle^.UltimoErro := 'A Identificação não pode ser nula';
    Exit;
end;

try
   ecfHandle^.ECF.PafMF_RelIdentificacaoPafECF(aacHandle^.AAC.IdentPAF, indiceRelatorio);
   Result := 0;
except
   on exception : Exception do
   begin
   ecfHandle^.UltimoErro := exception.Message;
   Result := -1;
   end
end;
end;

Function ECF_PafMF_RelParametrosConfiguracao(const ecfHandle: PECFHandle; const aacHandle : PAACHandle; const indiceRelatorio : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

if (aacHandle = nil) then
begin
    Result := -1;
    ecfHandle^.UltimoErro := 'Os Parametros não podem ser nulos';
    Exit;
end;

try
   ecfHandle^.ECF.PafMF_RelParametrosConfiguracao(aacHandle^.AAC.IdentPAF.Paf, indiceRelatorio);
   Result := 0;
except
   on exception : Exception do
   begin
   ecfHandle^.UltimoErro := exception.Message;
   Result := -1;
   end
end;
end;

Function ECF_PafMF_RelParametrosConfiguracao2(const ecfHandle: PECFHandle; const Perfil: pChar; const indiceRelatorio : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
if (ecfHandle = nil) then
begin
   Result := -2;
   Exit;
end;

try
   ecfHandle^.ECF.PafMF_RelParametrosConfiguracao(Perfil, indiceRelatorio);
   Result := 0;
except
   on exception : Exception do
   begin
   ecfHandle^.UltimoErro := exception.Message;
   Result := -1;
   end
end;
end;

{%endregion}

{%region Relatorio Gerencial }

Function ECF_AbreRelatorioGerencial(const ecfHandle: PECFHandle; const Indice : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreRelatorioGerencial(Indice);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_FechaRelatorio(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.FechaRelatorio;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_LinhaRelatorioGerencial(const ecfHandle: PECFHandle; const Linha : pChar; const IndiceBMP : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.LinhaRelatorioGerencial(Linha, IndiceBMP);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_ProgramaRelatoriosGerenciais(const ecfHandle: PECFHandle; const Descricao, Posicao: pChar) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  pDesc, pPosi : String;
begin
  if (ecfHandle = nil) then
  begin
          Result := -2;
          Exit;
  end;

  try
     pDesc := String(Descricao);
     pPosi := String(Posicao);
     ecfHandle^.ECF.ProgramaRelatoriosGerenciais(pDesc, pPosi);
     Result := 0;
  except
    on exception : Exception do
  begin
  ecfHandle^.UltimoErro := exception.Message;
  Result := -1;
  end
  end;
end;

Function ECF_CarregaRelatoriosGerenciais(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
     ecfHandle^.ECF.CarregaRelatoriosGerenciais;
     Result := ecfHandle^.ECF.RelatoriosGerenciais.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_LerTotaisRelatoriosGerenciais(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
     ecfHandle^.ECF.LerTotaisRelatoriosGerenciais;
     Result := ecfHandle^.ECF.RelatoriosGerenciais.Count;
   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_GetRelatoriosGerenciais(const ecfHandle: PECFHandle; var retRelatorios : TRelatorioGerencialRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  relatorios : TACBrECFRelatorioGerencial;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ecfHandle^.ECF.RelatoriosGerenciais.Count) then
      begin

              relatorios := ecfHandle^.ECF.RelatoriosGerenciais[index];

              StrPLCopy(retRelatorios.Indice, relatorios.Indice, 4);
              StrPLCopy(retRelatorios.Descricao, relatorios.Descricao, 30);
              retRelatorios.Contador := relatorios.Contador;
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function ECF_RelatorioGerencial(const ecfHandle: PECFHandle; const linhas : array of PChar; const LinhasCount : Integer;  const Vias : Integer; const Indice: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: Integer;
  Lista: TStringList;
begin

  try

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  Lista := TStringList.Create();
  for i := 0 to LinhasCount - 1 do
  begin
  Lista.Add(String(linhas[i]));
  end;
  ecfHandle^.ECF.RelatorioGerencial(Lista, Vias, Indice);
  Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
  finally
    FreeAndNil(Lista);
  end;
end;

{%endregion}

{%region Cheques}

Function ECF_ImprimeCheque(const ecfHandle: PECFHandle; const Banco: pChar; const Valor: Double;
                           const Favorecido , Cidade: pChar; const Data: Double; const Observacao: pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (ecfHandle = nil) then
   begin
     Result := -2;
     Exit ;
   end;

  try
     ecfHandle^.ECF.ImprimeCheque(Banco, Valor, Favorecido, Cidade, Data, Observacao);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_CancelaImpressaoCheque(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (ecfHandle = nil) then
   begin
     Result := -2;
     Exit ;
   end;

  try
     ecfHandle^.ECF.CancelaImpressaoCheque;
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_LeituraCMC7(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTmp := ecfHandle^.ECF.LeituraCMC7;
     StrPLCopy(Buffer, strTmp, BufferLen);
     Result := length(strTmp);
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

{%endregion}

{%region Comando}

Function ECF_EnviaComando(const ecfHandle: PECFHandle; cmd: pChar; const timeout : Integer; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
   strTmp : String;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if (timeout < 0) then
     strTmp := ecfHandle^.ECF.EnviaComando(cmd)
  else
     strTmp := ecfHandle^.ECF.EnviaComando(cmd, timeout);

  StrPLCopy(Buffer, strTmp, BufferLen);
  Result := length(strTmp);
  except
     on exception : Exception do
     begin
     ecfHandle^.UltimoErro := exception.Message;
     Result  := -1;
     end
  end;
end;

{%endregion}

{%region Eventos }

procedure TEventHandlersECF.OnMsgPoucoPapel(Sender: TObject);
begin
     OnMsgPoucoPapelCallback();
end;

procedure TEventHandlersECF.OnAguardandoRespostaChange(Sender: TObject);
begin
     OnAguardandoRespostaChangeCallback();
end;

procedure TEventHandlersECF.OnAntesAbreCupom(const CPF_CNPJ, Nome, Endereco : String);
begin
     OnAntesAbreCupomCallback(PChar(CPF_CNPJ), PChar(Nome), PChar(Endereco));
end;

procedure TEventHandlersECF.OnAntesAbreCupomVinculado(Sender: TObject);
begin
     OnAntesAbreCupomVinculadoCallback();
end;

procedure TEventHandlersECF.OnAntesAbreNaoFiscal(const CPF_CNPJ, Nome, Endereco : String);
begin
     OnAntesAbreNaoFiscalCallback(PChar(CPF_CNPJ), PChar(Nome), PChar(Endereco));
end;

procedure TEventHandlersECF.OnAntesAbreRelatorioGerencial(const Indice: Integer);
begin
     OnAntesAbreRelatorioGerencialCallback(Indice);
end;

procedure TEventHandlersECF.OnAntesCancelaCupom(Sender: TObject);
begin
     OnAntesCancelaCupomCallback();
end;

procedure TEventHandlersECF.OnAntesCancelaItemNaoFiscal(const NumItem: Integer);
begin
     OnAntesCancelaItemNaoFiscalCallback(NumItem);
end;

procedure TEventHandlersECF.OnAntesCancelaItemVendido(const NumItem: Integer);
begin
     OnAntesCancelaItemVendidoCallback(NumItem);
end;

procedure TEventHandlersECF.OnAntesCancelaNaoFiscal(Sender: TObject);
begin
     OnAntesCancelaNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnAntesEfetuaPagamento(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
begin
     OnAntesEfetuaPagamentoCallback(pChar(CodFormaPagto), Valor, pChar(Observacao), ImprimeVinculado);
end;

procedure TEventHandlersECF.OnAntesEfetuaPagamentoNaoFiscal(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
begin
     OnAntesEfetuaPagamentoNaoFiscalCallback(pChar(CodFormaPagto), Valor, pChar(Observacao), ImprimeVinculado);
end;

procedure TEventHandlersECF.OnAntesFechaCupom(const Observacao: AnsiString; const IndiceBMP: Integer);
begin
     OnAntesFechaCupomCallback(pChar(Observacao), IndiceBMP);
end;

procedure TEventHandlersECF.OnAntesFechaNaoFiscal(const Observacao: AnsiString; const IndiceBMP: Integer);
begin
     OnAntesFechaNaoFiscalCallback(pChar(Observacao), IndiceBMP);
end;

procedure TEventHandlersECF.OnAntesFechaRelatorio(Sender: TObject);
begin
     OnAntesFechaRelatorioCallback();
end;

procedure TEventHandlersECF.OnAntesLeituraX(Sender: TObject);
begin
     OnAntesLeituraXCallback();
end;

procedure TEventHandlersECF.OnAntesReducaoZ(Sender: TObject);
begin
     OnAntesReducaoZCallback();
end;

procedure TEventHandlersECF.OnAntesSangria(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
begin
     OnAntesSangriaCallback(Valor, pChar(Obs), pChar(DescricaoCNF), pChar(DescricaoFPG));
end;

procedure TEventHandlersECF.OnAntesSubtotalizaCupom(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
begin
     OnAntesSubtotalizaCupomCallback(DescontoAcrescimo, pChar(MensagemRodape));
end;

procedure TEventHandlersECF.OnAntesSubtotalizaNaoFiscal(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
begin
     OnAntesSubtotalizaNaoFiscalCallback(DescontoAcrescimo, pChar(MensagemRodape));
end;

procedure TEventHandlersECF.OnAntesSuprimento(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
begin
     OnAntesSuprimentoCallback(Valor, pChar(Obs), pChar(DescricaoCNF), pChar(DescricaoFPG));
end;

procedure TEventHandlersECF.OnAntesVendeItem(const Codigo, Descricao, AliquotaICMS: String; const Qtd, ValorUnitario,
          ValorDescontoAcrescimo: Double; const Unidade, TipoDescontoAcrescimo, DescontoAcrescimo: String);
begin
     OnAntesVendeItemCallback(pChar(Codigo), pChar(Descricao), pChar(AliquotaICMS), Qtd, ValorUnitario,
          ValorDescontoAcrescimo, pChar(Unidade), pChar(TipoDescontoAcrescimo), pChar(DescontoAcrescimo));
end;

procedure TEventHandlersECF.OnBobinaAdicionaLinhas(const Linhas : String; const Operacao : String);
var
  pLinhas: PChar;
  pOperacao: PChar;
begin
     pLinhas := PChar(Linhas);
     pOperacao := PChar(Operacao);
     OnBobinaAdicionaLinhasCallback(pLinhas, pOperacao);
end;

procedure TEventHandlersECF.OnChangeEstado(const EstadoAnterior, EstadoAtual: TACBrECFEstado);
begin
     OnChangeEstadoCallback(Integer(EstadoAnterior), Integer(EstadoAtual));
end;

procedure TEventHandlersECF.OnChequeEstado(const EstadoAtual: TACBrECFCHQEstado;  var Continuar: Boolean);
begin
    Continuar := OnChequeEstadoCallback(Integer(EstadoAtual));
end;

procedure TEventHandlersECF.OnDepoisAbreCupom(const CPF_CNPJ, Nome, Endereco : String);
begin
     OnDepoisAbreCupomCallback(PChar(CPF_CNPJ), PChar(Nome), PChar(Endereco));
end;

procedure TEventHandlersECF.OnDepoisAbreCupomVinculado(Sender: TObject);
begin
     OnDepoisAbreCupomVinculadoCallback();
end;

procedure TEventHandlersECF.OnDepoisAbreNaoFiscal(const CPF_CNPJ, Nome, Endereco : String);
begin
     OnDepoisAbreNaoFiscalCallback(PChar(CPF_CNPJ), PChar(Nome), PChar(Endereco));
end;

procedure TEventHandlersECF.OnDepoisAbreRelatorioGerencial(const Indice: Integer);
begin
     OnDepoisAbreRelatorioGerencialCallback(Indice);
end;

procedure TEventHandlersECF.OnDepoisCancelaCupom(Sender: TObject);
begin
     OnDepoisCancelaCupomCallback();
end;

procedure TEventHandlersECF.OnDepoisCancelaItemNaoFiscal(const NumItem: Integer);
begin
     OnDepoisCancelaItemNaoFiscalCallback(NumItem);
end;

procedure TEventHandlersECF.OnDepoisCancelaItemVendido(const NumItem: Integer);
begin
     OnDepoisCancelaItemVendidoCallback(NumItem);
end;

procedure TEventHandlersECF.OnDepoisCancelaNaoFiscal(Sender: TObject);
begin
     OnDepoisCancelaNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnDepoisEfetuaPagamento(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
begin
     OnDepoisEfetuaPagamentoCallback(pChar(CodFormaPagto), Valor, pChar(Observacao), ImprimeVinculado);
end;

procedure TEventHandlersECF.OnDepoisEfetuaPagamentoNaoFiscal(const CodFormaPagto: String; const Valor: Double;
          const Observacao: AnsiString; const ImprimeVinculado: Boolean);
begin
     OnDepoisEfetuaPagamentoNaoFiscalCallback(pChar(CodFormaPagto), Valor, pChar(Observacao), ImprimeVinculado);
end;

procedure TEventHandlersECF.OnDepoisFechaCupom(const Observacao: AnsiString; const IndiceBMP: Integer);
begin
     OnDepoisFechaCupomCallback(pChar(Observacao), IndiceBMP);
end;

procedure TEventHandlersECF.OnDepoisFechaNaoFiscal(const Observacao: AnsiString; const IndiceBMP: Integer);
begin
     OnDepoisFechaNaoFiscalCallback(pChar(Observacao), IndiceBMP);
end;

procedure TEventHandlersECF.OnDepoisFechaRelatorio(Sender: TObject);
begin
     OnDepoisFechaRelatorioCallback();
end;

procedure TEventHandlersECF.OnDepoisLeituraX(Sender: TObject);
begin
     OnDepoisLeituraXCallback();
end;

procedure TEventHandlersECF.OnDepoisReducaoZ(Sender: TObject);
begin
     OnDepoisReducaoZCallback();
end;

procedure TEventHandlersECF.OnDepoisSangria(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
begin
     OnDepoisSangriaCallback(Valor, pChar(Obs), pChar(DescricaoCNF), pChar(DescricaoFPG));
end;

procedure TEventHandlersECF.OnDepoisSubtotalizaCupom(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
begin
     OnDepoisSubtotalizaCupomCallback(DescontoAcrescimo, pChar(MensagemRodape));
end;

procedure TEventHandlersECF.OnDepoisSubtotalizaNaoFiscal(const DescontoAcrescimo: Double;  const MensagemRodape: AnsiString);
begin
     OnDepoisSubtotalizaNaoFiscalCallback(DescontoAcrescimo, pChar(MensagemRodape));
end;

procedure TEventHandlersECF.OnDepoisSuprimento(const Valor: Double; const Obs: AnsiString; const DescricaoCNF, DescricaoFPG: String);
begin
     OnDepoisSuprimentoCallback(Valor, pChar(Obs), pChar(DescricaoCNF), pChar(DescricaoFPG));
end;

procedure TEventHandlersECF.OnDepoisVendeItem(const Codigo, Descricao, AliquotaICMS: String; const Qtd, ValorUnitario,
          ValorDescontoAcrescimo: Double; const Unidade, TipoDescontoAcrescimo, DescontoAcrescimo: String);
begin
     OnDepoisVendeItemCallback(pChar(Codigo), pChar(Descricao), pChar(AliquotaICMS), Qtd, ValorUnitario,
          ValorDescontoAcrescimo, pChar(Unidade), pChar(TipoDescontoAcrescimo), pChar(DescontoAcrescimo));
end;

procedure TEventHandlersECF.OnErrorAbreCupom(var Tratado: Boolean);
begin
     Tratado := OnErrorAbreCupomCallback();
end;

procedure TEventHandlersECF.OnErrorAbreCupomVinculado(var Tratado: Boolean);
begin
     Tratado := OnErrorAbreCupomVinculadoCallback();
end;

procedure TEventHandlersECF.OnErrorAbreNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorAbreNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorAbreRelatorioGerencial(var Tratado: Boolean; const Indice: Integer);
begin
     Tratado := OnErrorAbreRelatorioGerencialCallback(Indice);
end;

procedure TEventHandlersECF.OnErrorCancelaCupom(var Tratado: Boolean);
begin
     Tratado := OnErrorCancelaCupomCallback();
end;

procedure TEventHandlersECF.OnErrorCancelaItemNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorCancelaItemNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorCancelaItemVendido(var Tratado: Boolean);
begin
     Tratado := OnErrorCancelaItemVendidoCallback();
end;

procedure TEventHandlersECF.OnErrorCancelaNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorCancelaNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorEfetuaPagamento(var Tratado: Boolean);
begin
     Tratado := OnErrorEfetuaPagamentoCallback();
end;

procedure TEventHandlersECF.OnErrorEfetuaPagamentoNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorEfetuaPagamentoNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorFechaCupom(var Tratado: Boolean);
begin
     Tratado := OnErrorFechaCupomCallback();
end;

procedure TEventHandlersECF.OnErrorFechaNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorFechaNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorFechaRelatorio(var Tratado: Boolean);
begin
     Tratado := OnErrorFechaRelatorioCallback();
end;

procedure TEventHandlersECF.OnErrorLeituraX(var Tratado: Boolean);
begin
     Tratado := OnErrorLeituraXCallback();
end;

procedure TEventHandlersECF.OnErrorReducaoZ(var Tratado: Boolean);
begin
     Tratado := OnErrorReducaoZCallback();
end;

procedure TEventHandlersECF.OnErrorSangria(var Tratado: Boolean);
begin
     Tratado := OnErrorSangriaCallback();
end;

procedure TEventHandlersECF.OnErrorSemPapel(Sender: TObject);
begin
     OnErrorSemPapelCallback();
end;

procedure TEventHandlersECF.OnErrorSubtotalizaCupom(var Tratado: Boolean);
begin
     Tratado := OnErrorSubtotalizaCupomCallback();
end;

procedure TEventHandlersECF.OnErrorSubtotalizaNaoFiscal(var Tratado: Boolean);
begin
     Tratado := OnErrorSubtotalizaNaoFiscalCallback();
end;

procedure TEventHandlersECF.OnErrorSuprimento(var Tratado: Boolean);
begin
     Tratado := OnErrorSuprimentoCallback();
end;

procedure TEventHandlersECF.OnErrorVendeItem(var Tratado: Boolean);
begin
     Tratado := OnErrorVendeItemCallback();
end;

procedure TEventHandlersECF.OnMsgAguarde(const Mensagem : String);
begin
     OnMsgAguardeCallback(pChar(Mensagem));
end;

procedure TEventHandlersECF.OnMsgRetentar(const Mensagem: String; const Situacao: String; var Result: Boolean);
begin
     Result := OnMsgRetentarCallback(pChar(Mensagem), pChar(Situacao));
end;

procedure TEventHandlersECF.OnPAFCalcEAD(Arquivo: String);
begin
     OnPAFCalcEADCallback(pChar(Arquivo));
end;

procedure TEventHandlersECF.OnPAFGetKeyRSA(var Chave: AnsiString);
begin
     Chave := OnPAFGetKeyRSACallback();
end;


{%endregion}

{%region Set Eventos }

Function ECF_SetOnMsgPoucoPapel(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnMsgPoucoPapel := ecfHandle^.EventHandlers.OnMsgPoucoPapel;
        ecfHandle^.EventHandlers.OnMsgPoucoPapelCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnMsgPoucoPapel := nil;
        ecfHandle^.EventHandlers.OnMsgPoucoPapelCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAguardandoRespostaChange(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAguardandoRespostaChange := ecfHandle^.EventHandlers.OnAguardandoRespostaChange;
        ecfHandle^.EventHandlers.OnAguardandoRespostaChangeCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAguardandoRespostaChange := nil;
        ecfHandle^.EventHandlers.OnAguardandoRespostaChangeCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesAbreCupom(const ecfHandle: PECFHandle; const method : TAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesAbreCupom := ecfHandle^.EventHandlers.OnAntesAbreCupom;
        ecfHandle^.EventHandlers.OnAntesAbreCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesAbreCupom := nil;
        ecfHandle^.EventHandlers.OnAntesAbreCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesAbreCupomVinculado(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesAbreCupomVinculado := ecfHandle^.EventHandlers.OnAntesAbreCupomVinculado;
        ecfHandle^.EventHandlers.OnAntesAbreCupomVinculadoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesAbreCupomVinculado := nil;
        ecfHandle^.EventHandlers.OnAntesAbreCupomVinculadoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesAbreNaoFiscal(const ecfHandle: PECFHandle; const method : TAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesAbreNaoFiscal := ecfHandle^.EventHandlers.OnAntesAbreNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesAbreNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesAbreNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesAbreNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesAbreRelatorioGerencial(const ecfHandle: PECFHandle; const method : TRelatorioGerencialCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesAbreRelatorioGerencial := ecfHandle^.EventHandlers.OnAntesAbreRelatorioGerencial;
        ecfHandle^.EventHandlers.OnAntesAbreRelatorioGerencialCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesAbreRelatorioGerencial := nil;
        ecfHandle^.EventHandlers.OnAntesAbreRelatorioGerencialCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesCancelaCupom(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesCancelaCupom := ecfHandle^.EventHandlers.OnAntesCancelaCupom;
        ecfHandle^.EventHandlers.OnAntesCancelaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesCancelaCupom := nil;
        ecfHandle^.EventHandlers.OnAntesCancelaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesCancelaItemNaoFiscal(const ecfHandle: PECFHandle; const method : TCancelaItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesCancelaItemNaoFiscal := ecfHandle^.EventHandlers.OnAntesCancelaItemNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesCancelaItemNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesCancelaItemNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesCancelaItemNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesCancelaItemVendido(const ecfHandle: PECFHandle; const method : TCancelaItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesCancelaItemVendido := ecfHandle^.EventHandlers.OnAntesCancelaItemVendido;
        ecfHandle^.EventHandlers.OnAntesCancelaItemVendidoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesCancelaItemVendido := nil;
        ecfHandle^.EventHandlers.OnAntesCancelaItemVendidoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesCancelaNaoFiscal(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesCancelaNaoFiscal := ecfHandle^.EventHandlers.OnAntesCancelaNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesCancelaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesCancelaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesCancelaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesEfetuaPagamento(const ecfHandle: PECFHandle; const method : TEfetuaPagamentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesEfetuaPagamento := ecfHandle^.EventHandlers.OnAntesEfetuaPagamento;
        ecfHandle^.EventHandlers.OnAntesEfetuaPagamentoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesEfetuaPagamento := nil;
        ecfHandle^.EventHandlers.OnAntesEfetuaPagamentoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesEfetuaPagamentoNaoFiscal(const ecfHandle: PECFHandle; const method : TEfetuaPagamentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesEfetuaPagamentoNaoFiscal := ecfHandle^.EventHandlers.OnAntesEfetuaPagamentoNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesEfetuaPagamentoNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesEfetuaPagamentoNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesEfetuaPagamentoNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesFechaCupom(const ecfHandle: PECFHandle; const method : TFechaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesFechaCupom := ecfHandle^.EventHandlers.OnAntesFechaCupom;
        ecfHandle^.EventHandlers.OnAntesFechaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesFechaCupom := nil;
        ecfHandle^.EventHandlers.OnAntesFechaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesFechaNaoFiscal(const ecfHandle: PECFHandle; const method : TFechaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesFechaNaoFiscal := ecfHandle^.EventHandlers.OnAntesFechaNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesFechaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesFechaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesFechaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesFechaRelatorio(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesFechaRelatorio := ecfHandle^.EventHandlers.OnAntesFechaRelatorio;
        ecfHandle^.EventHandlers.OnAntesFechaRelatorioCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesFechaRelatorio := nil;
        ecfHandle^.EventHandlers.OnAntesFechaRelatorioCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesLeituraX(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesLeituraX := ecfHandle^.EventHandlers.OnAntesLeituraX;
        ecfHandle^.EventHandlers.OnAntesLeituraXCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesLeituraX := nil;
        ecfHandle^.EventHandlers.OnAntesLeituraXCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesReducaoZ(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesReducaoZ := ecfHandle^.EventHandlers.OnAntesReducaoZ;
        ecfHandle^.EventHandlers.OnAntesReducaoZCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesReducaoZ := nil;
        ecfHandle^.EventHandlers.OnAntesReducaoZCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesSangria(const ecfHandle: PECFHandle; const method : TSangriaSuprimentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesSangria := ecfHandle^.EventHandlers.OnAntesSangria;
        ecfHandle^.EventHandlers.OnAntesSangriaCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesSangria := nil;
        ecfHandle^.EventHandlers.OnAntesSangriaCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesSubtotalizaCupom(const ecfHandle: PECFHandle; const method : TSubtotalizaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesSubtotalizaCupom := ecfHandle^.EventHandlers.OnAntesSubtotalizaCupom;
        ecfHandle^.EventHandlers.OnAntesSubtotalizaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesSubtotalizaCupom := nil;
        ecfHandle^.EventHandlers.OnAntesSubtotalizaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesSubtotalizaNaoFiscal(const ecfHandle: PECFHandle; const method : TSubtotalizaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesSubtotalizaNaoFiscal := ecfHandle^.EventHandlers.OnAntesSubtotalizaNaoFiscal;
        ecfHandle^.EventHandlers.OnAntesSubtotalizaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesSubtotalizaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnAntesSubtotalizaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesSuprimento(const ecfHandle: PECFHandle; const method : TSangriaSuprimentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesSuprimento := ecfHandle^.EventHandlers.OnAntesSuprimento;
        ecfHandle^.EventHandlers.OnAntesSuprimentoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesSuprimento := nil;
        ecfHandle^.EventHandlers.OnAntesSuprimentoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnAntesVendeItem(const ecfHandle: PECFHandle; const method : TVendeItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnAntesVendeItem := ecfHandle^.EventHandlers.OnAntesVendeItem;
        ecfHandle^.EventHandlers.OnAntesVendeItemCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnAntesVendeItem := nil;
        ecfHandle^.EventHandlers.OnAntesVendeItemCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnBobinaAdicionaLinhas(const ecfHandle: PECFHandle; const method : TBobinaProcedureCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnBobinaAdicionaLinhas := ecfHandle^.EventHandlers.OnBobinaAdicionaLinhas;
        ecfHandle^.EventHandlers.OnBobinaAdicionaLinhasCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnBobinaAdicionaLinhas := nil;
        ecfHandle^.EventHandlers.OnBobinaAdicionaLinhasCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnChangeEstado(const ecfHandle: PECFHandle; const method : TChangeEstadoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnChangeEstado := ecfHandle^.EventHandlers.OnChangeEstado;
        ecfHandle^.EventHandlers.OnChangeEstadoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnChangeEstado := nil;
        ecfHandle^.EventHandlers.OnChangeEstadoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnChequeEstado(const ecfHandle: PECFHandle; const method : TChequeEstadoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnChequeEstado := ecfHandle^.EventHandlers.OnChequeEstado;
        ecfHandle^.EventHandlers.OnChequeEstadoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnChangeEstado := nil;
        ecfHandle^.EventHandlers.OnChequeEstadoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisAbreCupom(const ecfHandle: PECFHandle; const method : TAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisAbreCupom := ecfHandle^.EventHandlers.OnDepoisAbreCupom;
        ecfHandle^.EventHandlers.OnDepoisAbreCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisAbreCupom := nil;
        ecfHandle^.EventHandlers.OnDepoisAbreCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisAbreCupomVinculado(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisAbreCupomVinculado := ecfHandle^.EventHandlers.OnDepoisAbreCupomVinculado;
        ecfHandle^.EventHandlers.OnDepoisAbreCupomVinculadoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisAbreCupomVinculado := nil;
        ecfHandle^.EventHandlers.OnDepoisAbreCupomVinculadoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisAbreNaoFiscal(const ecfHandle: PECFHandle; const method : TAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisAbreNaoFiscal := ecfHandle^.EventHandlers.OnDepoisAbreNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisAbreNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisAbreNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisAbreNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisAbreRelatorioGerencial(const ecfHandle: PECFHandle; const method : TRelatorioGerencialCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisAbreRelatorioGerencial := ecfHandle^.EventHandlers.OnDepoisAbreRelatorioGerencial;
        ecfHandle^.EventHandlers.OnDepoisAbreRelatorioGerencialCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisAbreRelatorioGerencial := nil;
        ecfHandle^.EventHandlers.OnDepoisAbreRelatorioGerencialCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisCancelaCupom(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisCancelaCupom := ecfHandle^.EventHandlers.OnDepoisCancelaCupom;
        ecfHandle^.EventHandlers.OnDepoisCancelaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisCancelaCupom := nil;
        ecfHandle^.EventHandlers.OnDepoisCancelaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisCancelaItemNaoFiscal(const ecfHandle: PECFHandle; const method : TCancelaItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisCancelaItemNaoFiscal := ecfHandle^.EventHandlers.OnDepoisCancelaItemNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisCancelaItemNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisCancelaItemNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisCancelaItemNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisCancelaItemVendido(const ecfHandle: PECFHandle; const method : TCancelaItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisCancelaItemVendido := ecfHandle^.EventHandlers.OnDepoisCancelaItemVendido;
        ecfHandle^.EventHandlers.OnDepoisCancelaItemVendidoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisCancelaItemVendido := nil;
        ecfHandle^.EventHandlers.OnDepoisCancelaItemVendidoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisCancelaNaoFiscal(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisCancelaNaoFiscal := ecfHandle^.EventHandlers.OnDepoisCancelaNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisCancelaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisCancelaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisCancelaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisEfetuaPagamento(const ecfHandle: PECFHandle; const method : TEfetuaPagamentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisEfetuaPagamento := ecfHandle^.EventHandlers.OnDepoisEfetuaPagamento;
        ecfHandle^.EventHandlers.OnDepoisEfetuaPagamentoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisEfetuaPagamento := nil;
        ecfHandle^.EventHandlers.OnDepoisEfetuaPagamentoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisEfetuaPagamentoNaoFiscal(const ecfHandle: PECFHandle; const method : TEfetuaPagamentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisEfetuaPagamentoNaoFiscal := ecfHandle^.EventHandlers.OnDepoisEfetuaPagamentoNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisEfetuaPagamentoNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisEfetuaPagamentoNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisEfetuaPagamentoNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisFechaCupom(const ecfHandle: PECFHandle; const method : TFechaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisFechaCupom := ecfHandle^.EventHandlers.OnDepoisFechaCupom;
        ecfHandle^.EventHandlers.OnDepoisFechaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisFechaCupom := nil;
        ecfHandle^.EventHandlers.OnDepoisFechaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisFechaNaoFiscal(const ecfHandle: PECFHandle; const method : TFechaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisFechaNaoFiscal := ecfHandle^.EventHandlers.OnDepoisFechaNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisFechaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisFechaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisFechaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisFechaRelatorio(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisFechaRelatorio := ecfHandle^.EventHandlers.OnDepoisFechaRelatorio;
        ecfHandle^.EventHandlers.OnDepoisFechaRelatorioCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisFechaRelatorio := nil;
        ecfHandle^.EventHandlers.OnDepoisFechaRelatorioCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisLeituraX(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisLeituraX := ecfHandle^.EventHandlers.OnDepoisLeituraX;
        ecfHandle^.EventHandlers.OnDepoisLeituraXCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisLeituraX := nil;
        ecfHandle^.EventHandlers.OnDepoisLeituraXCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisReducaoZ(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisReducaoZ := ecfHandle^.EventHandlers.OnDepoisReducaoZ;
        ecfHandle^.EventHandlers.OnDepoisReducaoZCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisReducaoZ := nil;
        ecfHandle^.EventHandlers.OnDepoisReducaoZCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisSangria(const ecfHandle: PECFHandle; const method : TSangriaSuprimentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisSangria := ecfHandle^.EventHandlers.OnDepoisSangria;
        ecfHandle^.EventHandlers.OnDepoisSangriaCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisSangria := nil;
        ecfHandle^.EventHandlers.OnDepoisSangriaCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisSubtotalizaCupom(const ecfHandle: PECFHandle; const method : TSubtotalizaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisSubtotalizaCupom := ecfHandle^.EventHandlers.OnDepoisSubtotalizaCupom;
        ecfHandle^.EventHandlers.OnDepoisSubtotalizaCupomCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisSubtotalizaCupom := nil;
        ecfHandle^.EventHandlers.OnDepoisSubtotalizaCupomCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisSubtotalizaNaoFiscal(const ecfHandle: PECFHandle; const method : TSubtotalizaCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisSubtotalizaNaoFiscal := ecfHandle^.EventHandlers.OnDepoisSubtotalizaNaoFiscal;
        ecfHandle^.EventHandlers.OnDepoisSubtotalizaNaoFiscalCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisSubtotalizaNaoFiscal := nil;
        ecfHandle^.EventHandlers.OnDepoisSubtotalizaNaoFiscalCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisSuprimento(const ecfHandle: PECFHandle; const method : TSangriaSuprimentoCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisSuprimento := ecfHandle^.EventHandlers.OnDepoisSuprimento;
        ecfHandle^.EventHandlers.OnDepoisSuprimentoCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisSuprimento := nil;
        ecfHandle^.EventHandlers.OnDepoisSuprimentoCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnDepoisVendeItem(const ecfHandle: PECFHandle; const method : TVendeItemCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ecfHandle^.ECF.OnDepoisVendeItem := ecfHandle^.EventHandlers.OnDepoisVendeItem;
        ecfHandle^.EventHandlers.OnDepoisVendeItemCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnDepoisVendeItem := nil;
        ecfHandle^.EventHandlers.OnDepoisVendeItemCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_SetOnErrorAbreCupom(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorAbreCupom := ecfHandle^.EventHandlers.OnErrorAbreCupom;
    ecfHandle^.EventHandlers.OnErrorAbreCupomCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorAbreCupom := nil;
    ecfHandle^.EventHandlers.OnErrorAbreCupomCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorAbreCupomVinculado(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorAbreCupomVinculado := ecfHandle^.EventHandlers.OnErrorAbreCupomVinculado;
    ecfHandle^.EventHandlers.OnErrorAbreCupomVinculadoCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorAbreCupomVinculado := nil;
    ecfHandle^.EventHandlers.OnErrorAbreCupomVinculadoCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorAbreNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorAbreNaoFiscal := ecfHandle^.EventHandlers.OnErrorAbreNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorAbreNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorAbreNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorAbreNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorAbreRelatorioGerencial(const ecfHandle: PECFHandle; const method : TErrorRelatorioCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorAbreRelatorioGerencial := ecfHandle^.EventHandlers.OnErrorAbreRelatorioGerencial;
    ecfHandle^.EventHandlers.OnErrorAbreRelatorioGerencialCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorAbreRelatorioGerencial := nil;
    ecfHandle^.EventHandlers.OnErrorAbreRelatorioGerencialCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorCancelaCupom(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorCancelaCupom := ecfHandle^.EventHandlers.OnErrorCancelaCupom;
    ecfHandle^.EventHandlers.OnErrorCancelaCupomCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorCancelaCupom := nil;
    ecfHandle^.EventHandlers.OnErrorCancelaCupomCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorCancelaItemNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorCancelaItemNaoFiscal := ecfHandle^.EventHandlers.OnErrorCancelaItemNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorCancelaItemNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorCancelaItemNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorCancelaItemNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorCancelaItemVendido(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorCancelaItemVendido := ecfHandle^.EventHandlers.OnErrorCancelaItemVendido;
    ecfHandle^.EventHandlers.OnErrorCancelaItemVendidoCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorCancelaItemVendido := nil;
    ecfHandle^.EventHandlers.OnErrorCancelaItemVendidoCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorCancelaNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorCancelaNaoFiscal := ecfHandle^.EventHandlers.OnErrorCancelaNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorCancelaNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorCancelaNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorCancelaNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorEfetuaPagamento(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorEfetuaPagamento := ecfHandle^.EventHandlers.OnErrorEfetuaPagamento;
    ecfHandle^.EventHandlers.OnErrorEfetuaPagamentoCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorEfetuaPagamento := nil;
    ecfHandle^.EventHandlers.OnErrorEfetuaPagamentoCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorEfetuaPagamentoNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorEfetuaPagamentoNaoFiscal := ecfHandle^.EventHandlers.OnErrorEfetuaPagamentoNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorEfetuaPagamentoNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorEfetuaPagamentoNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorEfetuaPagamentoNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorFechaCupom(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorFechaCupom := ecfHandle^.EventHandlers.OnErrorFechaCupom;
    ecfHandle^.EventHandlers.OnErrorFechaCupomCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorFechaCupom := nil;
    ecfHandle^.EventHandlers.OnErrorFechaCupomCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorFechaNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorFechaNaoFiscal := ecfHandle^.EventHandlers.OnErrorFechaNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorFechaNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorFechaNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorFechaNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorFechaRelatorio(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorFechaRelatorio := ecfHandle^.EventHandlers.OnErrorFechaRelatorio;
    ecfHandle^.EventHandlers.OnErrorFechaRelatorioCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorFechaRelatorio := nil;
    ecfHandle^.EventHandlers.OnErrorFechaRelatorioCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorLeituraX(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorLeituraX := ecfHandle^.EventHandlers.OnErrorLeituraX;
    ecfHandle^.EventHandlers.OnErrorLeituraXCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorLeituraX := nil;
    ecfHandle^.EventHandlers.OnErrorLeituraXCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorReducaoZ(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorReducaoZ := ecfHandle^.EventHandlers.OnErrorReducaoZ;
    ecfHandle^.EventHandlers.OnErrorReducaoZCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorReducaoZ := nil;
    ecfHandle^.EventHandlers.OnErrorReducaoZCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorSangria(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorSangria := ecfHandle^.EventHandlers.OnErrorSangria;
    ecfHandle^.EventHandlers.OnErrorSangriaCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorSangria := nil;
    ecfHandle^.EventHandlers.OnErrorSangriaCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorSemPapel(const ecfHandle: PECFHandle; const method : TCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorSemPapel := ecfHandle^.EventHandlers.OnErrorSemPapel;
    ecfHandle^.EventHandlers.OnErrorSemPapelCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorSemPapel := nil;
    ecfHandle^.EventHandlers.OnErrorSemPapelCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorSubtotalizaCupom(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorSubtotalizaCupom := ecfHandle^.EventHandlers.OnErrorSubtotalizaCupom;
    ecfHandle^.EventHandlers.OnErrorSubtotalizaCupomCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorSubtotalizaCupom := nil;
    ecfHandle^.EventHandlers.OnErrorSubtotalizaCupomCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorSubtotalizaNaoFiscal(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorSubtotalizaNaoFiscal := ecfHandle^.EventHandlers.OnErrorSubtotalizaNaoFiscal;
    ecfHandle^.EventHandlers.OnErrorSubtotalizaNaoFiscalCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorSubtotalizaNaoFiscal := nil;
    ecfHandle^.EventHandlers.OnErrorSubtotalizaNaoFiscalCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorSuprimento(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorSuprimento := ecfHandle^.EventHandlers.OnErrorSuprimento;
    ecfHandle^.EventHandlers.OnErrorSuprimentoCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorSuprimento := nil;
    ecfHandle^.EventHandlers.OnErrorSuprimentoCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnErrorVendeItem(const ecfHandle: PECFHandle; const method : TErrorCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnErrorVendeItem := ecfHandle^.EventHandlers.OnErrorVendeItem;
    ecfHandle^.EventHandlers.OnErrorVendeItemCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnErrorVendeItem := nil;
    ecfHandle^.EventHandlers.OnErrorVendeItemCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnMsgAguarde(const ecfHandle: PECFHandle; const method : TMsgCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnMsgAguarde := ecfHandle^.EventHandlers.OnMsgAguarde;
    ecfHandle^.EventHandlers.OnMsgAguardeCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnMsgAguarde := nil;
    ecfHandle^.EventHandlers.OnMsgAguardeCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnMsgRetentar(const ecfHandle: PECFHandle; const method : TMsgRetentarCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnMsgRetentar := ecfHandle^.EventHandlers.OnMsgRetentar;
    ecfHandle^.EventHandlers.OnMsgRetentarCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnMsgRetentar := nil;
    ecfHandle^.EventHandlers.OnMsgRetentarCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnPAFCalcEAD(const ecfHandle: PECFHandle; const method : TPAFCalcEADCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnPAFCalcEAD := ecfHandle^.EventHandlers.OnPAFCalcEAD;
    ecfHandle^.EventHandlers.OnPAFCalcEADCallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnPAFCalcEAD := nil;
    ecfHandle^.EventHandlers.OnPAFCalcEADCallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

Function ECF_SetOnPAFGetKeyRSA(const ecfHandle: PECFHandle; const method : TChaveCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (ecfHandle = nil) then
begin
 Result := -2;
 Exit;
end;

try
if Assigned(method) then
begin
    ecfHandle^.ECF.OnPAFGetKeyRSA := ecfHandle^.EventHandlers.OnPAFGetKeyRSA;
    ecfHandle^.EventHandlers.OnPAFGetKeyRSACallback := method;
    Result := 0;
end
else
begin
    ecfHandle^.ECF.OnPAFGetKeyRSA := nil;
    ecfHandle^.EventHandlers.OnPAFGetKeyRSACallback := nil;
    Result := 0;
end;
except
 on exception : Exception do
 begin
    ecfHandle^.UltimoErro := exception.Message;
    Result := -1;
 end
end;
end;

{%endregion}

exports

{ Funções }

ECF_Create, ECF_Destroy,
ECF_GetUltimoErro, ECF_Ativar, ECF_Desativar,

{ Propriedades da porta serial }

ECF_GetPorta, ECF_SetPorta,
ECF_GetTimeOut, ECF_SetTimeOut,
ECF_GetAtivo,

{ Propriedades do Componente }
ECF_GetAbout, ECF_GetArqLOG, ECF_SetArqLOG,
ECF_GetModelo, ECF_SetModelo, ECF_GetMaxLinhasBuffer, ECF_SetMaxLinhasBuffer,
ECF_GetColunas, ECF_GetAguardandoResposta, ECF_GetComandoEnviado, ECF_GetRespostaComando,
ECF_GetComandoLog, ECF_SetComandoLog, ECF_GetAguardaImpressao, ECF_SetAguardaImpressao,
ECF_GetModeloStr, ECF_GetRFDID, ECF_GetDataHora, ECF_GetDataHoraStr,
ECF_GetNumCupom, ECF_GetNumCOO, ECF_GetNumLoja, ECF_GetNumECF, ECF_GetNumSerie, ECF_GetNumSerieMFD, ECF_GetNumVersao,
ECF_GetDataMovimento, ECF_GetDataMovimentoStr, ECF_GetDataHoraSB, ECF_GetDataHoraSBStr,
ECF_GetCNPJ, ECF_GetIE, ECF_GetIM, ECF_GetCliche, ECF_GetUsuarioAtual, ECF_GetSubModeloECF,
ECF_GetPAF, ECF_GetNumCRZ, ECF_GetNumCRO, ECF_GetNumCCF, ECF_GetNumGNF, ECF_GetNumGRG, ECF_GetNumCDC,
ECF_GetNumCOOInicial, ECF_GetVendaBruta, ECF_GetGrandeTotal,
ECF_GetTotalCancelamentos, ECF_GetTotalDescontos, ECF_GetTotalAcrescimos, ECF_GetTotalTroco,
ECF_GetTotalSubstituicaoTributaria, ECF_GetTotalNaoTributado, ECF_GetTotalIsencao,
ECF_GetTotalCancelamentosISSQN, ECF_GetTotalDescontosISSQN,
ECF_GetTotalAcrescimosISSQN, ECF_GetTotalSubstituicaoTributariaISSQN,
ECF_GetTotalNaoTributadoISSQN, ECF_GetTotalIsencaoISSQN, ECF_GetTotalNaoFiscal,
ECF_GetNumUltItem, ECF_GetArredondaPorQtd, ECF_SetArredondaPorQtd,
ECF_GetArredondaItemMFD, ECF_SetArredondaItemMFD, ECF_GetIgnorarTagsFormatacao, ECF_SetIgnorarTagsFormatacao,
ECF_GetEmLinha, ECF_GetPoucoPapel, ECF_GetEstado, ECF_GetHorarioVerao, ECF_GetArredonda,
ECF_GetTermica, ECF_GetMFD, ECF_GetMFAdicional, ECF_GetIdentificaConsumidorRodape, ECF_GetParamDescontoISSQN,
ECF_GetPaginaDeCodigo, ECF_SetPaginaDeCodigo, ECF_GetSubTotal, ECF_GetTotalPago, ECF_GetGavetaAberta,
ECF_GetChequePronto, ECF_GetIntervaloAposComando, ECF_SetIntervaloAposComando,
ECF_GetDescricaoGrande, ECF_SetDescricaoGrande, ECF_GetGavetaSinalInvertido, ECF_SetGavetaSinalInvertido,
ECF_GetOperador, ECF_SetOperador, ECF_GetLinhasEntreCupons, ECF_SetLinhasEntreCupons,
ECF_GetDecimaisPreco, ECF_SetDecimaisPreco, ECF_GetDecimaisQtd, ECF_SetDecimaisQtd,
ECF_GetPausaRelatorio, ECF_SetPausaRelatorio, ECF_GetDataHoraUltimaReducaoZ,

{ Métodos do Componente }

ECF_IdentificaConsumidor, ECF_AbreCupom, ECF_LegendaInmetroProximoItem, ECF_VendeItem,
ECF_DescontoAcrescimoItemAnterior,  ECF_SubtotalizaCupom,
ECF_EfetuaPagamento, ECF_EstornaPagamento, ECF_FechaCupom, ECF_CancelaCupom,
ECF_CancelaItemVendido, ECF_CancelaItemVendidoParcial,
ECF_CancelaDescontoAcrescimoItem, ECF_CancelaDescontoAcrescimoSubTotal,
ECF_LeituraX, ECF_LinhaCupomVinculado, ECF_ReimpressaoVinculado, ECF_PreparaTEF,
ECF_FechaRelatorio, ECF_PulaLinhas, ECF_CortaPapel,
ECF_AbreCupomVinculado, ECF_AbreCupomVinculadoCNF, ECF_SegundaViaVinculado,

{ Aliquotas }

ECF_GetAliquota, ECF_GetALCount,
ECF_CarregaAliquotas, ECF_LerTotaisAliquota,
ECF_GetAliquotasStr, ECF_LerTotaisAliquotaStr,
ECF_ProgramaAliquota, ECF_AchaIcmsAliquota,

{ Formas de Pagamento }

ECF_GetFormaPagamento, ECF_CarregaFormasPagamento, ECF_LerTotaisFormaPagamento,
ECF_GetFormasPagamentoStr, ECF_LerTotaisFormaPagamentoStr, ECF_ProgramaFormaPagamento,
ECF_AchaFPGDescricao, ECF_AchaFPGIndice, ECF_GetFPGCount,

{ Comprovante Não Fiscal }

ECF_GetComprovanteNaoFiscal, ECF_CarregaComprovantesNaoFiscais,
ECF_LerTotaisComprovanteNaoFiscal, ECF_ProgramaComprovanteNaoFiscal,
ECF_ComprovantesNaoFiscais, ECF_LerTotaisComprovante, ECF_AchaCNFDescricao,
ECF_GetCNFCount,

ECF_TestaPodeAbrirCupom, ECF_Sangria, ECF_Suprimento,
ECF_AbreNaoFiscal, ECF_RegistraItemNaoFiscal, ECF_SubtotalizaNaoFiscal, ECF_EfetuaPagamentoNaoFiscal,
ECF_FechaNaoFiscal, ECF_CancelaNaoFiscal, ECF_AcharECF, ECF_AcharPorta,

ECF_AbreGaveta,

{Cheques}

ECF_ImprimeCheque, ECF_CancelaImpressaoCheque, ECF_LeituraCMC7,

{Utilitarios}

ECF_MudaHorarioVerao, ECF_MudaArredondamento,
ECF_CorrigeEstadoErro, ECF_EnviaComando,

{ InfoRodape Cupom }

ECF_InfoRodapeCupom_GetMD5, ECF_InfoRodapeCupom_SetMD5,
ECF_InfoRodapeCupom_GetDav, ECF_InfoRodapeCupom_SetDav,
ECF_InfoRodapeCupom_GetDavOs, ECF_InfoRodapeCupom_SetDavOs,
ECF_InfoRodapeCupom_GetPreVenda, ECF_InfoRodapeCupom_SetPreVenda,
ECF_InfoRodapeCupom_GetCupomMania, ECF_InfoRodapeCupom_SetCupomMania,
ECF_InfoRodapeCupom_GetMinasLegal, ECF_InfoRodapeCupom_SetMinasLegal,
ECF_InfoRodapeCupom_GetParaibaLegal, ECF_InfoRodapeCupom_SetParaibaLegal,
ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir, ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir,
ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito,  ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito,
ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS, ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS,
ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS, ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS,

ECF_InfoRodapeCupom_Restaurante_GetImprimir, ECF_InfoRodapeCupom_Restaurante_SetImprimir,
ECF_InfoRodapeCupom_Restaurante_GetECF, ECF_InfoRodapeCupom_Restaurante_SetECF,
ECF_InfoRodapeCupom_Restaurante_GetCER, ECF_InfoRodapeCupom_Restaurante_SetCER,
ECF_InfoRodapeCupom_Restaurante_GetCOO, ECF_InfoRodapeCupom_Restaurante_SetCOO,
ECF_InfoRodapeCupom_Restaurante_GetMesa,ECF_InfoRodapeCupom_Restaurante_SetMesa,

ECF_InfoRodapeCupom_Imposto_GetTexto, ECF_InfoRodapeCupom_Imposto_SetTexto,
ECF_InfoRodapeCupom_Imposto_GetFonte, ECF_InfoRodapeCupom_Imposto_SetFonte,
ECF_InfoRodapeCupom_Imposto_GetValorAproximado, ECF_InfoRodapeCupom_Imposto_SetValorAproximado,

{ Consumidor }

ECF_Consumidor_GetDocumento, ECF_Consumidor_GetEndereco, ECF_Consumidor_GetNome,
ECF_Consumidor_GetEnviado, ECF_Consumidor_SetEnviado, ECF_Consumidor_GetAtribuido,
ECF_Consumidor_AtribuiConsumidor, ECF_Consumidor_Zera,

{ ConfigBarras }

ECF_ConfigBarras_GetAltura, ECF_ConfigBarras_SetAltura,
ECF_ConfigBarras_GetLarguraLinha, ECF_ConfigBarras_SetLarguraLinha,
ECF_ConfigBarras_GetMostrarCodigo, ECF_ConfigBarras_SetMostrarCodigo,

{ Leitura Memoria Fiscal }

ECF_LeituraMemoriaFiscalReducao, ECF_LeituraMemoriaFiscalData,
ECF_LeituraMemoriaFiscalSerialReducao, ECF_LeituraMemoriaFiscalSerialData,
ECF_LeituraMemoriaFiscalArquivoReducao, ECF_LeituraMemoriaFiscalArquivoData,

{ Reduzão Z }

ECF_GetDadosReducaoZ, ECF_GetDadosUltimaReducaoZ,
ECF_ReducaoZ,

{ Redução Z Class }
ECF_DadosReducaoZClass_GetCOO, ECF_DadosReducaoZClass_GetCFD,
ECF_DadosReducaoZClass_GetCancelamentoISSQN, ECF_DadosReducaoZClass_GetGNFC,
ECF_DadosReducaoZClass_GetCRO, ECF_DadosReducaoZClass_GetValorVendaBruta,
ECF_DadosReducaoZClass_GetAcrescimoICMS, ECF_DadosReducaoZClass_GetDescontoICMS,
ECF_DadosReducaoZClass_GetNaoTributadoICMS, ECF_DadosReducaoZClass_GetCRZ,
ECF_DadosReducaoZClass_GetGRG, ECF_DadosReducaoZClass_GetValorGrandeTotal,
ECF_DadosReducaoZClass_GetAcrescimoISSQN, ECF_DadosReducaoZClass_GetNaoTributadoISSQN,
ECF_DadosReducaoZClass_GetIsentoICMS, ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS,
ECF_DadosReducaoZClass_GetDataDaImpressora, ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal,
ECF_DadosReducaoZClass_GetDescontoISSQN, ECF_DadosReducaoZClass_GetCancelamentoOPNF,
ECF_DadosReducaoZClass_GetAcrescimoOPNF, ECF_DadosReducaoZClass_GetDescontoOPNF,
ECF_DadosReducaoZClass_GetCancelamentoICMS, ECF_DadosReducaoZClass_GetGNF,
ECF_DadosReducaoZClass_GetIsentoISSQN, ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN,
ECF_DadosReducaoZClass_GetVendaLiquida, ECF_DadosReducaoZClass_GetCFC,
ECF_DadosReducaoZClass_GetCCF, ECF_DadosReducaoZClass_GetTotalISSQN,
ECF_DadosReducaoZClass_GetTotalICMS, ECF_DadosReducaoZClass_GetCDC,
ECF_DadosReducaoZClass_GetCCDC, ECF_DadosReducaoZClass_GetNCN,
ECF_DadosReducaoZClass_GetDataDoMovimento, ECF_DadosReducaoZClass_GetNumeroCOOInicial,
ECF_DadosReducaoZClass_GetNumeroDoECF, ECF_DadosReducaoZClass_GetNumeroDeSerie,
ECF_DadosReducaoZClass_GetNumeroDeSerieMFD, ECF_DadosReducaoZClass_GetNumeroDaLoja,
ECF_DadosReducaoZClass_GetTotalTroco, ECF_DadosReducaoZClass_GetDataHoraEmissao,

ECF_DadosReducaoZClass_GetCNFCount, ECF_DadosReducaoZClass_GetCNF,
ECF_DadosReducaoZClass_GetICMSCount, ECF_DadosReducaoZClass_GetICMS,
ECF_DadosReducaoZClass_GetRGCount, ECF_DadosReducaoZClass_GetRG,
ECF_DadosReducaoZClass_GetISSQNCount, ECF_DadosReducaoZClass_GetISSQN,
ECF_DadosReducaoZClass_GetFPGCount, ECF_DadosReducaoZClass_GetFPG,

ECF_DadosReducaoZClass_CalculaValoresVirtuais,
ECF_DadosReducaoZClass_MontaDadosReducaoZ,


ECF_IdentificaOperador,

{ Componentes ACBr }

ECF_SetAAC, ECF_SetEAD, ECF_SetRFD,

{ Relatorio Gerenciais }

ECF_AbreRelatorioGerencial, ECF_LinhaRelatorioGerencial,
ECF_GetRelatoriosGerenciais, ECF_LerTotaisRelatoriosGerenciais,
ECF_ProgramaRelatoriosGerenciais, ECF_CarregaRelatoriosGerenciais,
ECF_RelatorioGerencial,

{PAF}

ECF_PafMF_GerarCAT52, ECF_PafMF_LX_Impressao,
ECF_IdentificaPAF, ECF_DoAtualizarValorGT,
ECF_DoVerificaValorGT,

{PAF Arquivos}

ECF_ArquivoMFD_DLL, ECF_ArquivoMFD_DLL_COO,
ECF_EspelhoMFD_DLL, ECF_EspelhoMFD_DLL_COO,
ECF_PafMF_Binario, ECF_PafMF_ArqMF, ECF_PafMF_ArqMFD,

{PAF LMFC}

ECF_PafMF_LMFC_Cotepe1704, ECF_PafMF_LMFC_Cotepe1704_CRZ,
ECF_PafMF_LMFC_Espelho, ECF_PafMF_LMFC_Espelho_CRZ,
ECF_PafMF_LMFC_Impressao, ECF_PafMF_LMFC_Impressao_CRZ,

{PAF LMFS}

ECF_PafMF_LMFS_Espelho, ECF_PafMF_LMFS_Espelho_CRZ,
ECF_PafMF_LMFS_Impressao, ECF_PafMF_LMFS_Impressao_CRZ,

{PAF Espelho MFD}

ECF_PafMF_MFD_Cotepe1704, ECF_PafMF_MFD_Cotepe1704_COO,

{PAF Arq. MFD}

ECF_PafMF_MFD_Espelho, ECF_PafMF_MFD_Espelho_COO,

{DAV}

ECF_DAV_Abrir, ECF_DAV_RegistrarItem,
ECF_DAV_Fechar, ECF_PafMF_RelDAVEmitidos,

{Paf Rels}

ECF_PafMF_RelMeiosPagamento, ECF_PafMF_RelIdentificacaoPafECF,
ECF_PafMF_RelParametrosConfiguracao, ECF_PafMF_RelParametrosConfiguracao2,

{ Bobina }

ECF_SetMemoParams, ECF_GetMemoParams,
ECF_GetMemoParamsCount, ECF_MemoLeParams,

{Eventos}

ECF_SetOnMsgPoucoPapel, ECF_SetOnAguardandoRespostaChange, ECF_SetOnAntesAbreCupom,
ECF_SetOnAntesAbreCupomVinculado, ECF_SetOnAntesAbreNaoFiscal, ECF_SetOnAntesAbreRelatorioGerencial,
ECF_SetOnAntesCancelaCupom, ECF_SetOnAntesCancelaItemNaoFiscal, ECF_SetOnAntesCancelaItemVendido,
ECF_SetOnAntesCancelaNaoFiscal,ECF_SetOnAntesEfetuaPagamento, ECF_SetOnAntesEfetuaPagamentoNaoFiscal,
ECF_SetOnAntesFechaCupom, ECF_SetOnAntesFechaNaoFiscal, ECF_SetOnAntesFechaRelatorio,
ECF_SetOnAntesLeituraX, ECF_SetOnAntesReducaoZ, ECF_SetOnAntesSangria,
ECF_SetOnAntesSubtotalizaCupom, ECF_SetOnAntesSubtotalizaNaoFiscal, ECF_SetOnAntesSuprimento,
ECF_SetOnAntesVendeItem, ECF_SetOnBobinaAdicionaLinhas, ECF_SetOnChangeEstado,
ECF_SetOnDepoisAbreCupom, ECF_SetOnDepoisAbreCupomVinculado, ECF_SetOnDepoisAbreNaoFiscal,
ECF_SetOnDepoisAbreRelatorioGerencial, ECF_SetOnDepoisCancelaCupom, ECF_SetOnDepoisCancelaItemNaoFiscal,
ECF_SetOnDepoisCancelaItemVendido, ECF_SetOnDepoisCancelaNaoFiscal,ECF_SetOnDepoisEfetuaPagamento,
ECF_SetOnDepoisEfetuaPagamentoNaoFiscal, ECF_SetOnDepoisFechaCupom, ECF_SetOnDepoisFechaNaoFiscal,
ECF_SetOnDepoisFechaRelatorio, ECF_SetOnDepoisLeituraX, ECF_SetOnDepoisReducaoZ,
ECF_SetOnDepoisSangria, ECF_SetOnDepoisSubtotalizaCupom, ECF_SetOnDepoisSubtotalizaNaoFiscal,
ECF_SetOnDepoisSuprimento, ECF_SetOnDepoisVendeItem, ECF_SetOnErrorAbreCupom,
ECF_SetOnErrorAbreCupomVinculado, ECF_SetOnErrorAbreNaoFiscal, ECF_SetOnErrorAbreRelatorioGerencial,
ECF_SetOnErrorCancelaCupom, ECF_SetOnErrorCancelaItemNaoFiscal,
ECF_SetOnErrorCancelaItemVendido, ECF_SetOnErrorCancelaNaoFiscal,ECF_SetOnErrorEfetuaPagamento,
ECF_SetOnErrorEfetuaPagamentoNaoFiscal, ECF_SetOnErrorFechaCupom, ECF_SetOnErrorFechaNaoFiscal,
ECF_SetOnErrorFechaRelatorio, ECF_SetOnErrorLeituraX, ECF_SetOnErrorReducaoZ,
ECF_SetOnErrorSangria, ECF_SetOnErrorSemPapel, ECF_SetOnErrorSubtotalizaCupom,
ECF_SetOnErrorSubtotalizaNaoFiscal, ECF_SetOnErrorSuprimento, ECF_SetOnErrorVendeItem,
ECF_SetOnMsgAguarde, ECF_SetOnMsgRetentar, ECF_SetOnPAFCalcEAD, ECF_SetOnPAFGetKeyRSA;

end.

