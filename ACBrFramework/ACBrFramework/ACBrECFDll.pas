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
  ACBrPAFClass
  ;

{%region Ponteiros de função para uso nos eventos}

type TNoArgumentsCallback = procedure(); cdecl;
type TAntesAbreCupomCallback = procedure(const CPF_CNPJ, Nome, Endereco : PChar); cdecl;
type TIntArgumentCallback = procedure(const Indice: Integer); cdecl;
type TBobinaProcedureCallback = procedure(const Linhas : PChar; const Operacao : PChar); cdecl;


{%endregion}

{%region Classe que armazena os EventHandlers para o componente ACBr}

type TEventHandlersECF = class

    OnPoucoPapelCallback : TNoArgumentsCallback;
    OnAguardandoRespostaChangeCallback :  TNoArgumentsCallback;
    OnAntesAbreCupomCallback : TAntesAbreCupomCallback;
    OnAntesAbreCupomVinculadoCallback : TNoArgumentsCallback;
    OnAntesAbreNaoFiscalCallback : TAntesAbreCupomCallback;
    OnAntesAbreRelatorioGerencialCallback : TIntArgumentCallback;
    OnAntesCancelaCupomCallback : TNoArgumentsCallback;
    OnAntesCancelaItemNaoFiscalCallback : TIntArgumentCallback;
    OnAntesCancelaItemVendidoCallback : TIntArgumentCallback;
    OnBobinaAdicionaLinhasCallback : TBobinaProcedureCallback;

    procedure OnMsgPoucoPapel(Sender: TObject);
    procedure OnAguardandoRespostaChange(Sender: TObject);
    procedure OnAntesAbreCupom(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnAntesAbreCupomVinculado(Sender: TObject);
    procedure OnAntesAbreNaoFiscal(const CPF_CNPJ, Nome, Endereco : String);
    procedure OnAntesAbreRelatorioGerencial(const Indice: Integer);
    procedure OnAntesCancelaCupom(Sender: TObject);
    procedure OnAntesCancelaItemNaoFiscal(const NumItem: Integer);
    procedure OnAntesCancelaItemVendido(const NumItem: Integer);
    procedure OnBobinaAdicionaLinhas(const Linhas : String; const Operacao : String);
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
Function ECF_Destroy(var ecfHandle: PECFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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

Function ECF_Consumidor_GetEnviado(const ecfHandle: PECFHandle; var value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     value := ecfHandle^.ECF.Consumidor.Enviado;
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
     value := ecfHandle^.ECF.Consumidor.Atribuido;
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

Function ECF_GetComandoLOG(const ecfHandle: PECFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetComandoLOG(const ecfHandle: PECFHandle; const ComandoLog : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_Sangria(const ecfHandle: PECFHandle; const Valor: Double; const Obs: pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin


  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Sangria(Valor, Obs);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function ECF_Suprimento(const ecfHandle: PECFHandle; const Valor: Double; const Obs: pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.Suprimento(Valor, Obs);
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
  if (index >= 0) and (index < ecfHandle^.ECF.MemoParams.Count ) then
  begin
     strTmp := ecfHandle^.ECF.MemoParams[index];
     StrPLCopy(linha, strTmp, BufferLen);
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

Function ECF_GetMemoParamsLineCount(const ecfHandle: PECFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_AbreCupom(const ecfHandle: PECFHandle; const CPF_CNPJ, Nome, Endereco : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreCupom( CPF_CNPJ, Nome, Endereco );
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

Function ECF_AbreNaoFiscal(const ecfHandle: PECFHandle; const CPF_CNPJ : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.AbreNaoFiscal(CPF_CNPJ);
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

Function ECF_FechaNaoFiscal(const ecfHandle: PECFHandle; const Observacao: pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.FechaNaoFiscal(Observacao);
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

     lista.Free;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_LeituraMemoriaFiscalSerialData(const ecfHandle: PECFHandle; const DataInicial : double; const DataFinal: double; const Simplificada : Boolean;  Buffer : pChar; const BufferLen : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
  var lista : TStringList;

begin

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

     lista.Free;

  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
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

Function ECF_ArquivoMFD_DLL( const ecfHandle: PECFHandle; const DataInicial, DataFinal: double; const Arquivo : pChar ;const Documentos: array of Integer; const QTD_DOC, Finalidade : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_ArquivoMFD_DLL_COO( const ecfHandle: PECFHandle; const COOInicial, COOFinal: Integer; const Arquivo : pChar ;const Documentos: array of Integer; const QTD_DOC, Finalidade, TipoContador : Integer) : Integer ;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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
      ACNPJCPF, ANomeCliente, AEndereco: pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ecfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ecfHandle^.ECF.DAV_Abrir(AEmissao, AdescrDocumento, ANumero, ASituacao, AVendedor, AObservacao, ACNPJCPF, ANomeCliente, AEndereco);
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
end;

{%endregion}

{%region Eventos }

procedure TEventHandlersECF.OnMsgPoucoPapel(Sender: TObject);
begin
     OnPoucoPapelCallback();
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

procedure TEventHandlersECF.OnBobinaAdicionaLinhas(const Linhas : String; const Operacao : String);
var
  pLinhas: PChar;
  pOperacao: PChar;
begin
     pLinhas := PChar(Linhas);
     pOperacao := PChar(Operacao);
     OnBobinaAdicionaLinhasCallback(pLinhas, pOperacao);
end;

{%endregion}

{%region Set Eventos }

Function ECF_SetOnPoucoPapel(const ecfHandle: PECFHandle; const method : TNoArgumentsCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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
        ecfHandle^.EventHandlers.OnPoucoPapelCallback := method;
        Result := 0;
  end
  else
  begin
        ecfHandle^.ECF.OnMsgPoucoPapel := nil;
        ecfHandle^.EventHandlers.OnPoucoPapelCallback := nil;
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

Function ECF_SetOnAguardandoRespostaChange(const ecfHandle: PECFHandle; const method : TNoArgumentsCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesAbreCupom(const ecfHandle: PECFHandle; const method : TAntesAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesAbreCupomVinculado(const ecfHandle: PECFHandle; const method : TNoArgumentsCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesAbreNaoFiscal(const ecfHandle: PECFHandle; const method : TAntesAbreCupomCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesAbreRelatorioGerencial(const ecfHandle: PECFHandle; const method : TIntArgumentCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesCancelaCupom(const ecfHandle: PECFHandle; const method : TNoArgumentsCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesCancelaItemNaoFiscal(const ecfHandle: PECFHandle; const method : TIntArgumentCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

Function ECF_SetOnAntesCancelaItemVendido(const ecfHandle: PECFHandle; const method : TIntArgumentCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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

{%endregion}

{
NÀO IMPLEMENTADO

Function ECF_ImprimeCheque(const ecfHandle: PECFHandle;
                           const Banco: pChar;
                           const Valor: Double;
                           const Favorecido : pChar;
                           const Cidade: pChar;
                           const Data: TDateTime;
                           const Observacao: String) : Integer ; cdecl;  export;
begin
  if ECF = nil then
   begin
     Result := -2;
     Exit ;
   end;

  try
     ecfHandle^.ECF.ImprimeCheque(Banco,Valor,Favorecido,Cidade,Data,Observacao);
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function ECF_CancelaImpressaoCheque(const ecfHandle: PECFHandle) : Integer ; cdecl;export;
begin
  if ECF = nil then
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

Function EnviaComando(cmd: AnsiString; var resp : pchar ) : Integer ; cdecl;export; overload;
begin
  if ECF = nil then
   begin
     Result := -2;
     Exit ;
   end;

  try
     resp := pchar(ecfHandle^.ECF.EnviaComando(cmd));
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

Function EnviaComando(cmd: AnsiString; lTimeOut: Integer; var resp : pchar ) : Integer ; cdecl;  export; overload;
begin
  if ECF = nil then
   begin
     Result := -2;
     Exit ;
   end;

  try
     resp := pchar(ecfHandle^.ECF.EnviaComando(cmd,lTimeOut));
     Result := 0 ;
  except
     on exception : Exception do
     begin
        ecfHandle^.UltimoErro := exception.Message;
        Result  := -1;
     end
  end;
end;

}

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
ECF_GetComandoLOG, ECF_SetComandoLOG, ECF_GetAguardaImpressao, ECF_SetAguardaImpressao,
ECF_GetModeloStr, ECF_GetRFDID, ECF_GetDataHora, ECF_GetDataHoraStr,
ECF_GetNumCupom, ECF_GetNumCOO, ECF_GetNumLoja, ECF_GetNumECF, ECF_GetNumSerie, ECF_GetNumVersao,
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
ECF_GetTermica, ECF_GetMFD, ECF_GetMFAdicional, ECF_GetIdentificaConsumidorRodape,
ECF_GetPaginaDeCodigo, ECF_SetPaginaDeCodigo, ECF_GetSubTotal, ECF_GetTotalPago, ECF_GetGavetaAberta,
ECF_GetChequePronto, ECF_GetIntervaloAposComando, ECF_SetIntervaloAposComando,
ECF_GetDescricaoGrande, ECF_SetDescricaoGrande, ECF_GetGavetaSinalInvertido, ECF_SetGavetaSinalInvertido,
ECF_GetOperador, ECF_SetOperador, ECF_GetLinhasEntreCupons, ECF_SetLinhasEntreCupons,
ECF_GetDecimaisPreco, ECF_SetDecimaisPreco, ECF_GetDecimaisQtd, ECF_SetDecimaisQtd,

{ Métodos do Componente }

ECF_IdentificaConsumidor, ECF_AbreCupom, ECF_LegendaInmetroProximoItem, ECF_VendeItem,
ECF_DescontoAcrescimoItemAnterior,  ECF_SubtotalizaCupom,
ECF_EfetuaPagamento, ECF_EstornaPagamento, ECF_FechaCupom, ECF_CancelaCupom,
ECF_CancelaItemVendido, ECF_CancelaItemVendidoParcial,
ECF_CancelaDescontoAcrescimoItem, ECF_CancelaDescontoAcrescimoSubTotal,
ECF_LeituraX, ECF_LinhaCupomVinculado, ECF_PreparaTEF,
ECF_FechaRelatorio, ECF_PulaLinhas, ECF_CortaPapel,
ECF_AbreCupomVinculado, ECF_AbreCupomVinculadoCNF,

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
{
ECF_ImprimeCheque, ECF_CancelaImpressaoCheque,
}

ECF_MudaHorarioVerao, ECF_MudaArredondamento,
ECF_CorrigeEstadoErro,

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
ECF_DadosReducaoZClass_GetTotalTroco,

ECF_DadosReducaoZClass_GetCNFCount, ECF_DadosReducaoZClass_GetCNF,
ECF_DadosReducaoZClass_GetICMSCount, ECF_DadosReducaoZClass_GetICMS,
ECF_DadosReducaoZClass_GetRGCount, ECF_DadosReducaoZClass_GetRG,
ECF_DadosReducaoZClass_GetISSQNCount, ECF_DadosReducaoZClass_GetISSQN,
ECF_DadosReducaoZClass_GetFPGCount, ECF_DadosReducaoZClass_GetFPG,

ECF_DadosReducaoZClass_CalculaValoresVirtuais,
ECF_DadosReducaoZClass_MontaDadosReducaoZ,


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
ECF_PafMF_RelParametrosConfiguracao,

{ Bobina }

ECF_SetMemoParams, ECF_GetMemoParams,
ECF_GetMemoParamsLineCount, ECF_MemoLeParams,

{Eventos}

ECF_SetOnPoucoPapel, ECF_SetOnAguardandoRespostaChange, ECF_SetOnAntesAbreCupom,
ECF_SetOnAntesAbreCupomVinculado, ECF_SetOnAntesAbreNaoFiscal, ECF_SetOnAntesAbreRelatorioGerencial,
ECF_SetOnAntesCancelaCupom, ECF_SetOnAntesCancelaItemNaoFiscal, ECF_SetOnAntesCancelaItemVendido,
ECF_SetOnBobinaAdicionaLinhas;

{Não implementado}

{

exports EnviaComando(cmd: AnsiString; var resp : pchar ) overload;
exports EnviaComando(cmd: AnsiString; lTimeOut: Integer; var resp : pchar ) overload;

}

end.

