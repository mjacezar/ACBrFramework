unit ACBrSintegraDll;


interface

uses
  Classes,
  SysUtils,
  ACBrSintegra,
  ACBrUtil;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class

end;

{Handle para o componente TACBrSintegra }
type TSintegraHandle = record
  UltimoErro : String;
  Sintegra : TACBrSintegra;
  EventHandlers : TEventHandlers;
end;

{ Registro }
type TRegistro10Rec = record
  CNPJ                : array[0..14] of char;
  Inscricao           : array[0..14] of char;
  RazaoSocial         : array[0..35] of char;
  Cidade              : array[0..30] of char;
  Estado              : array[0..2] of char;
  Telefone            : array[0..10] of char;
  DataInicial         : Double;
  DataFinal           : Double;
  CodigoConvenio      : Integer;
  NaturezaInformacoes : Integer;
  FinalidadeArquivo   : Integer;
end;

type TRegistro11Rec = record
  Responsavel : array[0..28] of char;
  Bairro      : array[0..15] of char;
  Cep         : array[0..8] of char;
  Numero      : array[0..5] of char;
  Complemento : array[0..22] of char;
  Endereco    : array[0..34] of char;
  Telefone    : array[0..12] of char;
end;

type TRegistro50Rec = record
  CPFCNPJ          : array[0..14] of char;
  Inscricao        : array[0..14] of char;
  UF               : array[0..2] of char;
  Situacao         : array[0..1] of char;
  Aliquota         : Double;
  Isentas          : Double;
  Icms             : Double;
  ValorContabil    : Double;
  BasedeCalculo    : Double;
  Outras           : Double;
  EmissorDocumento : array[0..1] of char;
  Cfop             : array[0..4] of char;
  Serie            : array[0..3] of char;
  Modelo           : array[0..2] of char;
  Numero           : array[0..6] of char;
  DataDocumento    : Double;
end;

type TRegistro51Rec = record
  CPFCNPJ       : array[0..14] of char;
  Inscricao     : array[0..14] of char;
  Estado        : array[0..2] of char;
  ValorIpi      : Double;
  ValorContabil : Double;
  Serie         : array[0..3] of char;
  DataDocumento : Double;
  Cfop          : array[0..4] of char;
  Numero        : array[0..6] of char;
  Situacao      : array[0..1] of char;
  ValorIsentas  : Double;
  ValorOutras   : Double;
end;

type TRegistro53Rec = record
  CPFCNPJ           : array[0..14] of char;
  Inscricao         : array[0..14] of char;
  Estado            : array[0..2] of char;
  Serie             : array[0..3] of char;
  DataDocumento     : Double;
  Cfop              : array[0..4] of char;
  Numero            : array[0..6] of char;
  Situacao          : array[0..3] of char;
  CodigoAntecipacao : array[0..1] of char;
  BaseST            : Double;
  Modelo            : array[0..2] of char;
  Emitente          : array[0..1] of char;
  Despesas          : Double;
  IcmsRetido        : Double;
end;

type TRegistro54Rec = record
  Aliquota             : Double;
  BaseST               : Double;
  BasedeCalculo        : Double;
  Quantidade           : Double;
  ValorDescontoDespesa : Double;
  ValorIpi             : Double;
  Valor                : Double;
  NumeroItem           : Integer;
  CST                  : string;
  Codigo               : array[0..14] of char;
  CFOP                 : array[0..4] of char;
  Descricao            : array[0..53] of char;
  CPFCNPJ              : array[0..14] of char;
  Numero               : array[0..6] of char;
  Modelo               : array[0..2] of char;
  Serie                : array[0..3] of char;
end;

type TRegistro55Rec = record
  Valor          : double;
  Agencia        : Integer;
  Banco          : Integer;
  NumeroConvenio : array[0..30] of char;
  Inscricao      : array[0..14] of char;
  MesAno         : array[0..6] of char;
  CNPJ           : array[0..14] of char;
  UF             : array[0..2] of char;
  Numero         : array[0..14] of char;
  DataPagamento  : double;
  Vencimento     : double;
end;

type TRegistro56Rec = record
  Cnpj               : array[0..14] of char;
  Modelo             : array[0..2] of char;
  Serie              : array[0..3] of char;
  Numero             : array[0..6] of char;
  Cfop               : array[0..4] of char;
  Cst                : array[0..3] of char;
  NumeroItem         : Integer;
  Codigo             : array[0..14] of char;
  TipoOperacao       : array[0..1] of char;
  CnpjConcessionaria : array[0..14] of char;
  Ipi                : Double;
  Chassi             : array[0..17] of char;
end;

type TRegistro60MRec = record
  CRO        : Integer;
  NumOrdem   : Integer;
  VendaBruta : Double;
  ModeloDoc  : array[0..2] of char;
  ValorGT    : Double;
  CRZ        : Integer;
  CooFinal   : Integer;
  CooInicial : Integer;
  NumSerie   : array[0..20] of char;
  Emissao    : Double;
end;

type TRegistro60ARec = record
  NumSerie   : array[0..20] of char;
  Aliquota   : array[0..4] of char;
  Emissao    : Double;
  Valor      : Double;
end;

type TRegistro60DRec = record
  NumSerie      : array[0..20] of char;
  StAliquota    : array[0..4] of char;
  Emissao       : Double;
  Valor         : Double;
  Codigo        : array[0..14] of char;
  ValorIcms     : Double;
  Quantidade    : Double;
  BaseDeCalculo : Double;
end;

type TRegistro70Rec = record
  Icms          : Double;
  ValorContabil : Double;
  UF            : array[0..2] of char;
  Isentas       : Double;
  SubSerie      : array[0..2] of char;
  Serie         : array[0..1] of char;
  DataDocumento : Double;
  Modelo        : array[0..2] of char;
  CPFCNPJ       : array[0..14] of char;
  Cfop          : array[0..4] of char;
  Numero        : array[0..6] of char;
  Inscricao     : array[0..14] of char;
  Situacao      : array[0..14] of char;
  Outras        : Double;
  BasedeCalculo : Double;
  CifFobOutros  : array[0..1] of char;
end;

type TRegistro74Rec = record
  ValorProduto       : Double;
  CodigoPosse        : array[0..1] of char;
  InscricaoPossuidor : array[0..14] of char;
  Codigo             : array[0..14] of char;
  CNPJPossuidor      : array[0..14] of char;
  UFPossuidor        : array[0..2] of char;
  Data               : Double;
  Quantidade         : Double;
end;

type TRegistro75Rec = record
  Codigo       : array[0..14] of char;
  Descricao    : array[0..53] of char;
  Reducao      : Double;
  BaseST       : Double;
  AliquotaIpi  : Double;
  NCM          : array[0..8] of char;
  Unidade      : array[0..6] of char;
  AliquotaICMS : Double;
  DataFinal    : Double;
  DataInicial  : Double;
end;

{Ponteiro para o Handle }
type PSINHandle = ^TSintegraHandle;

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
CRIA um novo componente TACBrSintegra retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
Function SIN_Create(var sinHandle: PSINHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(sinHandle);
     sinHandle^.Sintegra := TACBrSintegra.Create(nil);
     sinHandle^.EventHandlers := TEventHandlers.Create();
     sinHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        sinHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrSintegra e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function SIN_Destroy(var sinHandle: PSINHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    sinHandle^.Sintegra.Destroy();
    sinHandle^.Sintegra := nil;

    Dispose(sinHandle);
    sinHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        sinHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SIN_GetUltimoErro(const sinHandle: PSINHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, sinHandle^.UltimoErro, BufferLen);
     Result := length(sinHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{ Funções mapeando as propriedades do componente }
Function SIN_GetFileName(const sinHandle: PSINHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := sinHandle^.Sintegra.FileName;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SIN_SetFileName(const sinHandle: PSINHandle; const FileN : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     sinHandle^.Sintegra.FileName := FileN;
     Result := 0;
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SIN_GetVersaoValidador(const sinHandle: PSINHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(sinHandle^.Sintegra.VersaoValidador);
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SIN_SetVersaoValidador(const sinHandle: PSINHandle; const Versao : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     sinHandle^.Sintegra.VersaoValidador  := TVersaoValidador(Versao);
     Result := 0;
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SIN_GetAtivo(const sinHandle: PSINHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (sinHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if (sinHandle^.Sintegra.Ativo) then
        Result := 1
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        sinHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{ Funções do Componente}
function SIN_LimparRegistros(const sinHandle: PSINHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
try
   if (sinHandle = nil) then
   begin
     Result := -2;
     Exit;
   end;
   sinHandle^.Sintegra.LimparRegistros;

except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro10(const sinHandle: PSINHandle; const Registro10Rec : TRegistro10Rec): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
try
   if (sinHandle = nil) then
   begin
     Result := -2;
     Exit;
   end;

   with sinHandle^.Sintegra.Registro10 do
   begin
   CNPJ                := Registro10Rec.CNPJ;
   Inscricao           := Registro10Rec.Inscricao;
   RazaoSocial         := Registro10Rec.RazaoSocial;
   Cidade              := Registro10Rec.Cidade;
   Estado              := Registro10Rec.Estado;
   Telefone            := Registro10Rec.Telefone;
   DataInicial         := Registro10Rec.DataInicial;
   DataFinal           := Registro10Rec.DataFinal;
   CodigoConvenio      := IntToStr(Registro10Rec.CodigoConvenio);
   NaturezaInformacoes := IntToStr(Registro10Rec.NaturezaInformacoes);
   FinalidadeArquivo   := IntToStr(Registro10Rec.FinalidadeArquivo);
   end;
   Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro11(const sinHandle: PSINHandle; const Registro11Rec : TRegistro11Rec): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
try
   if (sinHandle = nil) then
   begin
     Result := -2;
     Exit;
   end;

   with sinHandle^.Sintegra.Registro11 do
   begin
   Responsavel := Registro11Rec.Responsavel;
   Bairro      := Registro11Rec.Bairro;
   Cep         := Registro11Rec.Cep;
   Numero      := Registro11Rec.Numero;
   Complemento := Registro11Rec.Complemento;
   Endereco    := Registro11Rec.Endereco;
   Telefone    := Registro11Rec.Telefone;
   end;
   Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro50(const sinHandle: PSINHandle; const Registro50Rec : array of TRegistro50Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro50: TRegistro50;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro50                  := TRegistro50.Create;
  registro50.CPFCNPJ          := Registro50Rec[i].CPFCNPJ;
  registro50.Inscricao        := Registro50Rec[i].Inscricao;
  registro50.DataDocumento    := Registro50Rec[i].DataDocumento;
  registro50.UF               := Registro50Rec[i].UF;
  registro50.Modelo           := Registro50Rec[i].Modelo;
  registro50.Serie            := Registro50Rec[i].Serie;
  registro50.Numero           := Registro50Rec[i].Numero;
  registro50.Cfop             := Registro50Rec[i].Cfop;
  registro50.EmissorDocumento := Registro50Rec[i].EmissorDocumento;
  registro50.ValorContabil    := Registro50Rec[i].ValorContabil;
  registro50.BasedeCalculo    := Registro50Rec[i].BasedeCalculo;
  registro50.Icms             := Registro50Rec[i].Icms;
  registro50.Isentas          := Registro50Rec[i].Isentas;
  registro50.Outras           := Registro50Rec[i].Outras;
  registro50.Aliquota         := Registro50Rec[i].Aliquota;
  registro50.Situacao         := Registro50Rec[i].Situacao;
  Registros50.Add(registro50);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro51(const sinHandle: PSINHandle; const Registro51Rec : array of TRegistro51Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro51: TRegistro51;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro51               := TRegistro51.Create;
  registro51.CPFCNPJ       := Registro51Rec[i].CPFCNPJ;
  registro51.Inscricao     := Registro51Rec[i].Inscricao;
  registro51.DataDocumento := Registro51Rec[i].DataDocumento;
  registro51.Estado        := Registro51Rec[i].Estado;
  registro51.Serie         := Registro51Rec[i].Serie;
  registro51.Numero        := Registro51Rec[i].Numero;
  registro51.Cfop          := Registro51Rec[i].Cfop;
  registro51.ValorContabil := Registro51Rec[i].ValorContabil;
  registro51.ValorIpi      := Registro51Rec[i].ValorIpi;
  registro51.ValorOutras   := Registro51Rec[i].ValorOutras;
  registro51.ValorIsentas  := Registro51Rec[i].ValorIsentas;
  registro51.Situacao      := Registro51Rec[i].Situacao;
  Registros51.Add(registro51);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro53(const sinHandle: PSINHandle; const Registro53Rec : array of TRegistro53Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro53: TRegistro53;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro53                   := TRegistro53.Create;
  registro53.CPFCNPJ           := Registro53Rec[i].CPFCNPJ;
  registro53.Inscricao         := Registro53Rec[i].Inscricao;
  registro53.Estado            := Registro53Rec[i].Estado;
  registro53.Serie             := Registro53Rec[i].Serie;
  registro53.DataDocumento     := Registro53Rec[i].DataDocumento;
  registro53.Cfop              := Registro53Rec[i].Cfop;
  registro53.Numero            := Registro53Rec[i].Numero;
  registro53.Situacao          := Registro53Rec[i].Situacao;
  registro53.CodigoAntecipacao := Registro53Rec[i].CodigoAntecipacao;
  registro53.BaseST            := Registro53Rec[i].BaseST;
  registro53.Modelo            := Registro53Rec[i].Modelo;
  registro53.Emitente          := Registro53Rec[i].Emitente;
  registro53.Despesas          := Registro53Rec[i].Despesas;
  registro53.IcmsRetido        := Registro53Rec[i].IcmsRetido;
  Registros53.Add(registro53);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro54(const sinHandle: PSINHandle; const Registro54Rec : array of TRegistro54Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro54: TRegistro54;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro54                      := TRegistro54.Create;
  registro54.Aliquota             := Registro54Rec[i].Aliquota;
  registro54.BaseST               := Registro54Rec[i].BaseST;
  registro54.BasedeCalculo        := Registro54Rec[i].BasedeCalculo;
  registro54.Quantidade           := Registro54Rec[i].Quantidade;
  registro54.ValorDescontoDespesa := Registro54Rec[i].ValorDescontoDespesa;
  registro54.ValorIpi             := Registro54Rec[i].ValorIpi;
  registro54.Valor                := Registro54Rec[i].Valor;
  registro54.NumeroItem           := Registro54Rec[i].NumeroItem;
  registro54.CST                  := Registro54Rec[i].CST;
  registro54.Codigo               := Registro54Rec[i].Codigo;
  registro54.CFOP                 := Registro54Rec[i].CFOP;
  registro54.Descricao            := Registro54Rec[i].Descricao;
  registro54.CPFCNPJ              := Registro54Rec[i].CPFCNPJ;
  registro54.Numero               := Registro54Rec[i].Numero;
  registro54.Modelo               := Registro54Rec[i].Modelo;
  registro54.Serie                := Registro54Rec[i].Serie;
  Registros54.Add(registro54);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro55(const sinHandle: PSINHandle; const Registro55Rec : array of TRegistro55Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro55: TRegistro55;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro55                := TRegistro55.Create;
  registro55.Valor          := Registro55Rec[i].Valor;
  registro55.Agencia        := Registro55Rec[i].Agencia;
  registro55.Banco          := Registro55Rec[i].Banco;
  registro55.NumeroConvenio := Registro55Rec[i].NumeroConvenio;
  registro55.Inscricao      := Registro55Rec[i].Inscricao;
  registro55.MesAno         := Registro55Rec[i].MesAno;
  registro55.CNPJ           := Registro55Rec[i].CNPJ;
  registro55.UF             := Registro55Rec[i].UF;
  registro55.Numero         := Registro55Rec[i].Numero;
  registro55.DataPagamento  := Registro55Rec[i].DataPagamento;
  registro55.Vencimento     := Registro55Rec[i].Vencimento;
  Registros55.Add(registro55);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro56(const sinHandle: PSINHandle; const Registro56Rec : array of TRegistro56Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro56: TRegistro56;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro56                    := TRegistro56.Create;
  registro56.Cnpj               := Registro56Rec[i].Cnpj;
  registro56.Modelo             := Registro56Rec[i].Modelo;
  registro56.Serie              := Registro56Rec[i].Serie;
  registro56.Numero             := Registro56Rec[i].Numero;
  registro56.Cfop               := Registro56Rec[i].Cfop;
  registro56.Cst                := Registro56Rec[i].Cst;
  registro56.NumeroItem         := Registro56Rec[i].NumeroItem;
  registro56.Codigo             := Registro56Rec[i].Codigo;
  registro56.TipoOperacao       := Registro56Rec[i].TipoOperacao;
  registro56.CnpjConcessionaria := Registro56Rec[i].CnpjConcessionaria;
  registro56.Ipi                := Registro56Rec[i].Ipi;
  registro56.Chassi             := Registro56Rec[i].Chassi;
  Registros56.Add(registro56);
  end;
  end;
  Result := 0;
except
   on exception : Exception do
   begin
      sinHandle^.UltimoErro := exception.Message;
      Result := -1;
   end
end;
end;

function SIN_Registro60M(const sinHandle: PSINHandle; const Registro60MRec : array of TRegistro60MRec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro60M: TRegistro60M;
  i : Integer;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro60M            := TRegistro60M.Create;
  registro60M.Emissao    := Registro60MRec[i].Emissao;
  registro60M.NumSerie   := Registro60MRec[i].NumSerie;
  registro60M.NumOrdem   := Registro60MRec[i].NumOrdem;
  registro60M.ModeloDoc  := Registro60MRec[i].ModeloDoc;
  registro60M.CooInicial := Registro60MRec[i].CooInicial;
  registro60M.CooFinal   := Registro60MRec[i].CooFinal;
  registro60M.CRZ        := Registro60MRec[i].CRZ;
  registro60M.CRO        := Registro60MRec[i].CRO;
  registro60M.VendaBruta := Registro60MRec[i].VendaBruta;
  registro60M.ValorGT    := Registro60MRec[i].ValorGT;
  Registros60M.Add(registro60M);
  end;
  end;
  Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

function SIN_Registro60A(const sinHandle: PSINHandle;  const Registro60ARec : array of TRegistro60ARec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro60A: TRegistro60A;
  i : Integer;
begin
try
  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
    begin
      registro60A            := TRegistro60A.Create;
      registro60A.Emissao    := Registro60ARec[i].Emissao;
      registro60A.NumSerie   := Registro60ARec[i].NumSerie;
      registro60A.StAliquota := Registro60ARec[i].Aliquota;
      registro60A.Valor      := Registro60ARec[i].Valor;
      Registros60A.Add(registro60A);
    end;
  end;
    Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end;
 end;
end;

function SIN_Registro60D(const sinHandle: PSINHandle;  const Registro60DRec : array of TRegistro60DRec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro60D: TRegistro60D;
  i : Integer;
begin
try
  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
  begin
  registro60D               := TRegistro60D.Create;
  registro60D.Emissao       := Registro60DRec[i].Emissao;
  registro60D.NumSerie      := Registro60DRec[i].NumSerie;
  registro60D.Codigo        := Registro60DRec[i].Codigo;
  registro60D.Quantidade    := Registro60DRec[i].Quantidade;
  registro60D.Valor         := Registro60DRec[i].Valor;
  registro60D.BaseDeCalculo := Registro60DRec[i].BaseDeCalculo;
  registro60D.StAliquota    := Registro60DRec[i].StAliquota;
  registro60D.ValorIcms     := Registro60DRec[i].ValorIcms;
  Registros60D.Add(registro60D);
  end;
  end;
  Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end;
 end;;
end;

function SIN_Registro70(const sinHandle: PSINHandle;  const Registro70Rec : array of TRegistro70Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro70: TRegistro70;
  i : Integer;
begin
try
  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
    begin
      registro70               := TRegistro70.Create;
      registro70.CPFCNPJ       := Registro70Rec[i].CPFCNPJ;
      registro70.Inscricao     := Registro70Rec[i].Inscricao;
      registro70.DataDocumento := Registro70Rec[i].DataDocumento;
      registro70.UF            := Registro70Rec[i].UF;
      registro70.Modelo        := Registro70Rec[i].Modelo;
      registro70.Serie         := Registro70Rec[i].Serie;
      registro70.SubSerie      := Registro70Rec[i].SubSerie;
      registro70.Numero        := Registro70Rec[i].Numero;
      registro70.Cfop          := Registro70Rec[i].Cfop;
      registro70.ValorContabil := Registro70Rec[i].ValorContabil;
      registro70.BasedeCalculo := Registro70Rec[i].BasedeCalculo;
      registro70.Icms          := Registro70Rec[i].Icms;
      registro70.Isentas       := Registro70Rec[i].Isentas;
      registro70.Outras        := Registro70Rec[i].Outras;
      registro70.CifFobOutros  := Registro70Rec[i].CifFobOutros;
      registro70.Situacao      := Registro70Rec[i].Situacao;
      Registros70.Add(registro70);
    end;
  end;
  Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end;
 end;
end;

function SIN_Registro74(const sinHandle: PSINHandle;  const Registro74Rec : array of TRegistro74Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro74: TRegistro74;
  i : Integer;
begin
try
  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
    begin
      registro74                    := TRegistro74.Create;
      registro74.Data               := Registro74Rec[i].Data;
      registro74.Codigo             := Registro74Rec[i].Codigo;
      registro74.Quantidade         := Registro74Rec[i].Quantidade;
      registro74.ValorProduto       := Registro74Rec[i].ValorProduto;
      registro74.CodigoPosse        := Registro74Rec[i].CodigoPosse;
      registro74.CNPJPossuidor      := Registro74Rec[i].CNPJPossuidor;
      registro74.InscricaoPossuidor := Registro74Rec[i].InscricaoPossuidor;
      registro74.UFPossuidor        := Registro74Rec[i].UFPossuidor;
      Registros74.Add(registro74);
    end;
  end;
  Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end;
 end;
end;

function SIN_Registro75(const sinHandle: PSINHandle;  const Registro75Rec : array of TRegistro75Rec; const Count : Integer): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  registro75: TRegistro75;
  i : Integer;
begin
try
  for i := 0 to Count - 1 do
  begin
  with sinHandle^.Sintegra do
    begin
    registro75              := TRegistro75.Create;
    registro75.DataInicial  := Registro75Rec[i].DataInicial;
    registro75.DataFinal    := Registro75Rec[i].DataFinal;
    registro75.Codigo       := Registro75Rec[i].Codigo;
    registro75.NCM          := Registro75Rec[i].NCM;
    registro75.Descricao    := Registro75Rec[i].Descricao;
    registro75.Unidade      := Registro75Rec[i].Unidade;
    registro75.AliquotaIpi  := Registro75Rec[i].AliquotaIpi;
    registro75.AliquotaICMS := Registro75Rec[i].AliquotaICMS;
    registro75.Reducao      := Registro75Rec[i].Reducao;
    registro75.BaseST       := Registro75Rec[i].BaseST;
    Registros75.Add(registro75);
    end;
  end;
  Result:=0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end;
 end;
end;

function SIN_GeraArquivo(const sinHandle: PSINHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
try
  if (sinHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  sinHandle^.Sintegra.GeraArquivo;
  Result := 0;
except
    on exception : Exception do
    begin
       sinHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

exports
{ Funções }
SIN_Create, SIN_Destroy,
SIN_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
SIN_GetFileName, SIN_SetFileName,
SIN_GetVersaoValidador, SIN_SetVersaoValidador,
SIN_GetAtivo,

{ Funções do componente }
SIN_LimparRegistros, SIN_GeraArquivo,

{ Registros }
SIN_Registro10, SIN_Registro11,
SIN_Registro50, SIN_Registro51,
SIN_Registro53, SIN_Registro54,
SIN_Registro55, SIN_Registro56,
SIN_Registro60M, SIN_Registro60A,
SIN_Registro60D, SIN_Registro70,
SIN_Registro74, SIN_Registro75;
end.

