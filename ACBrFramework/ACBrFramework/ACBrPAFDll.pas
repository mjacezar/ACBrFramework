unit ACBrPAFDll;

interface

uses
  SysUtils,
  Classes,
  ACBrPAF,
  ACBrAACDLL,
  ACBrEADDLL,
  ACBrUtil;

{ Ponteiros de função }
type
  TGetChaveCallback = function(): PChar; cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type
  TEventHandlers = class
    ChaveRSA: ansistring;
    OnGetChaveRSACallback: TGetChaveCallback;
    procedure GetChaveRSA(var Chave: ansistring);
  end;

{Handle para o componente TACBrECF }
type
  TPAFHandle = record
    UltimoErro: string;
    PAF: TACBrPAF;
    EventHandlers: TEventHandlers;
  end;

{Ponteiro para o Handle }
type
  PPAFHandle = ^TPAFHandle;

{%region Records estilo C utilizados nas funções}

type
  TRegistroHD1Rec = record
    RAZAOSOCIAL: array[0..50] of char;
    UF: array[0..2] of char;
    CNPJ: array[0..14] of char;
    IE: array[0..14] of char;
    IM: array[0..14] of char;
  end;

type
  TRegistroHD2Rec = record
    RAZAOSOCIAL: array[0..50] of char;
    UF: array[0..2] of char;
    CNPJ: array[0..14] of char;
    IE: array[0..14] of char;
    IM: array[0..14] of char;
    NUM_FAB: array[0..20] of char;
    MF_ADICIONAL: array[0..1] of char;
    TIPO_ECF: array[0..7] of char;
    MARCA_ECF: array[0..20] of char;
    MODELO_ECF: array[0..20] of char;
    DT_EST: double;
    InclusaoExclusao: boolean;
    RegistroValido: boolean;
  end;

type
  TRegistroB2Rec = record
    BOMBA: array[0..3] of char;
    BICO: array[0..3] of char;
    Data: double;
    HORA: double;
    MOTIVO: array[0..50] of char;
    CNPJ_EMPRESA: array[0..14] of char;
    CPF_TECNICO: array[0..11] of char;
    NRO_LACRE_ANTES: array[0..15] of char;
    NRO_LACRE_APOS: array[0..15] of char;
    ENCERRANTE_ANTES: double;
    ENCERRANTE_APOS: double;
    RegistroValido: boolean;
  end;

type
  TRegistroC2Rec = record
    ID_ABASTECIMENTO: array[0..15] of char;
    TANQUE: array[0..3] of char;
    BOMBA: array[0..3] of char;
    BICO: array[0..3] of char;
    COMBUSTIVEL: array[0..20] of char;
    DATA_ABASTECIMENTO: double;
    HORA_ABASTECIMENTO: double;
    ENCERRANTE_INICIAL: double;
    ENCERRANTE_FINAL: double;
    STATUS_ABASTECIMENTO: array[0..10] of char;
    NRO_SERIE_ECF: array[0..14] of char;
    Data: double;
    HORA: double;
    COO: integer;
    NRO_NOTA_FISCAL: integer;
    VOLUME: double;
    RegistroValido: boolean;
  end;

type
  TRegistroD3Rec = record
    DT_INCLUSAO: double;
    NUM_ITEM: integer;
    COD_ITEM: array[0..14] of char;
    DESC_ITEM: array[0..100] of char;
    QTDE_ITEM: double;
    UNI_ITEM: array[0..3] of char;
    VL_UNIT: double;
    VL_DESCTO: double;
    VL_ACRES: double;
    VL_TOTAL: double;
    DEC_VL_UNIT: integer;
    DEC_QTDE_ITEM: integer;
    SIT_TRIB: array[0..1] of char;
    ALIQ: double;
    IND_CANC: array[0..1] of char;
    RegistroValido: boolean;
  end;

type
  TRegistroD2Rec = record
    QTD_D3: integer;
    QTD_D4: integer;
    NUM_FAB: array[0..20] of char;
    MF_ADICIONAL: array[0..1] of char;
    TIPO_ECF: array[0..7] of char;
    MARCA_ECF: array[0..20] of char;
    MODELO_ECF: array[0..20] of char;
    COO: array[0..6] of char;
    NUM_DAV: array[0..13] of char;
    DT_DAV: double;
    TIT_DAV: array[0..30] of char;
    VLT_DAV: double;
    COO_DFV: array[0..6] of char;
    NUMERO_ECF: array[0..3] of char;
    NOME_CLIENTE: array[0..40] of char;
    CPF_CNPJ: array[0..14] of char;
    RegistroValido: boolean;
  end;

type
  TRegistroE2Rec = record
    COD_MERC: array[0..14] of char;
    DESC_MERC: array[0..50] of char;
    UN_MED: array[0..6] of char;
    QTDE_EST: double;
    RegistroValido: boolean;
  end;

type
  TRegistroH2Rec = record
    CNPJ_CRED_CARTAO: array[0..14] of char;
    COO: integer;
    CCF: integer;
    VLR_TROCO: double;
    DT_TROCO: double;
    CPF: array[0..14] of char;
    Titulo: array[0..7] of char;
    RegistroValido: boolean;
  end;

type
  TRegistroN2Rec = record
    LAUDO: array[0..10] of char;
    NOME: array[0..50] of char;
    VERSAO: array[0..10] of char;
  end;

type
  TRegistroN3Rec = record
    NOME_ARQUIVO: array[0..50] of char;
    MD5: array[0..32] of char;
  end;

type
  TRegistroP2Rec = record
    COD_MERC_SERV: array[0..14] of char;
    DESC_MERC_SERV: array[0..50] of char;
    UN_MED: array[0..6] of char;
    IAT: array[0..1] of char;
    IPPT: array[0..1] of char;
    ST: array[0..1] of char;
    ALIQ: double;
    VL_UNIT: double;
    RegistroValido: boolean;
  end;

type
  TRegistroR1Rec = record
    QTD_R2: integer;
    QTD_R4: integer;
    QTD_R6: integer;
    NUM_FAB: array[0..20] of char;
    MF_ADICIONAL: array[0..1] of char;
    TIPO_ECF: array[0..7] of char;
    MARCA_ECF: array[0..20] of char;
    MODELO_ECF: array[0..20] of char;
    VERSAO_SB: array[0..10] of char;
    DT_INST_SB: double;
    HR_INST_SB: double;
    NUM_SEQ_ECF: integer;
    CNPJ: array[0..14] of char;
    IE: array[0..14] of char;
    CNPJ_SH: array[0..14] of char;
    IE_SH: array[0..14] of char;
    IM_SH: array[0..14] of char;
    NOME_SH: array[0..40] of char;
    NOME_PAF: array[0..40] of char;
    VER_PAF: array[0..10] of char;
    COD_MD5: array[0..32] of char;
    DT_INI: double;
    DT_FIN: double;
    ER_PAF_ECF: array[0..4] of char;
    InclusaoExclusao: boolean;
    RegistroValido: boolean;
  end;

type
  TRegistroR2Rec = record
    QTD_R3: integer;
    NUM_USU: integer;
    CRZ: integer;
    COO: integer;
    CRO: integer;
    DT_MOV: double;
    DT_EMI: double;
    HR_EMI: double;
    VL_VBD: double;
    PAR_ECF: array[0..1] of char;
    RegistroValido: boolean;
  end;

type
  TRegistroR3Rec = record
    TOT_PARCIAL: array[0..7] of char;
    VL_ACUM: double;
    RegistroValido: boolean;
  end;

type
  TRegistroR4Rec = record
    QTD_R5: integer;
    QTD_R7: integer;
    NUM_USU: integer;
    NUM_CONT: integer;
    COO: integer;
    DT_INI: double;
    SUB_DOCTO: double;
    SUB_DESCTO: double;
    TP_DESCTO: array[0..1] of char;
    SUB_ACRES: double;
    TP_ACRES: array[0..1] of char;
    VL_TOT: double;
    CANC: array[0..1] of char;
    VL_CA: double;
    ORDEM_DA: array[0..1] of char;
    NOME_CLI: array[0..40] of char;
    CNPJ_CPF: array[0..14] of char;
    RegistroValido: boolean;
  end;

type
  TRegistroR5Rec = record
    NUM_CONT: integer;
    NUM_ITEM: integer;
    COD_ITEM: array[0..14] of char;
    DESC_ITEM: array[0..100] of char;
    QTDE_ITEM: double;
    UN_MED: array[0..3] of char;
    VL_UNIT: double;
    DESCTO_ITEM: double;
    ACRES_ITEM: double;
    VL_TOT_ITEM: double;
    COD_TOT_PARC: array[0..7] of char;
    IND_CANC: array[0..1] of char;
    QTDE_CANC: double;
    VL_CANC: double;
    VL_CANC_ACRES: double;
    IAT: array[0..1] of char;
    IPPT: array[0..1] of char;
    QTDE_DECIMAL: integer;
    VL_DECIMAL: integer;
    RegistroValido: boolean;
  end;

type
  TRegistroR6Rec = record
    QTD_R7: integer;
    NUM_USU: integer;
    COO: integer;
    GNF: integer;
    GRG: integer;
    CDC: integer;
    DENOM: array[0..2] of char;
    DT_FIN: double;
    HR_FIN: double;
    RegistroValido: boolean;
  end;

type
  TRegistroR7Rec = record
    CCF: integer;
    GNF: integer;
    MP: array[0..15] of char;
    VL_PAGTO: double;
    IND_EST: array[0..1] of char;
    VL_EST: double;
    RegistroValido: boolean;
  end;

type
  TRegistroT2Rec = record
    DT_MOV: double;
    TP_DOCTO: array[0..10] of char;
    SERIE: array[0..2] of char;
    NUM_BILH_I: integer;
    NUM_BILH_F: integer;
    NUM_ECF: array[0..20] of char;
    CRZ: integer;
    CFOP: array[0..4] of char;
    VL_CONT: double;
    VL_BASECALC: double;
    ALIQ: double;
    VL_IMPOSTO: double;
    VL_ISENTAS: double;
    VL_OUTRAS: double;
    RegistroValido: boolean;
  end;

type
  TRegistroMercadoriaRec = record
    Descricao: array[0..100] of char;
    Codigo: array[0..14] of char;
    Aliquota: double;
    Unidade: array[0..3] of char;
    Quantidade: double;
    Ean: array[0..13] of char;
    CST: array[0..3] of char;
    VlrUnitario: double;
    QTD_Insumos: integer;
  end;

type
  TRegistroInsumoRec = record
    Descricao: array[0..100] of char;
    Codigo: array[0..14] of char;
    Aliquota: double;
    Unidade: array[0..3] of char;
    Quantidade: double;
    Ean: array[0..13] of char;
    CST: array[0..3] of char;
    VlrUnitario: double;
  end;

{
 Coloquei em uma region separada para facilitar no momento do merge.

 ===================================================================

 Foi levantado todos os tipos necessários para o desenvolvimento dos Registros
 do ECF que são: (Mostrando apenas os tipos não implementados)

    U1: Identificação do Estabelecimento Usuário do PAF-ECF
    A2: Total Diário de Meios de Pagamento
    E3: Identificação do ECF que Emitiu o Documento Base para a Atualização do Estoque
    D4: Log de Alteração de Itens do DAV


    F2: Manifesto Fiscal de Viagem – Transporte de Passageiros
    F3: Bilhetes de Passagens do Manifesto – Transporte de Passageiros
    F4: Tipo de serviço – Transporte de Passageiros
    T2: Movimento Diário -Transporte de Passageiros
    M2: Cupom de Embarque
    L2: Cupom de Embarque Gratuidade
    G2: Movimento Diário de Pedágio
    S2: Mesa/Conta de Cliente
}

// Total Diário de Meios de Pagamento
type
  TRegistroA2Rec = record
    Data: double;
    MeioDePagamento: array[0..25] of char;
    CodigoTipoDocumento: array[0..1] of char;
    Valor: double;
    RegistroValido: boolean;
  end;
//  Identificação do ECF que Emitiu o Documento Base para a Atualização do Estoque
type
  TRegistroE3Rec = record
    NumeroFabricacao: array[0..20] of char;
    MFAdicional: array[0..1] of char;
    TipoECF: array[0..7] of char;
    MarcaECF: array[0..20] of char;
    ModeloECF: array[0..20] of char;
    DataEstoque: double;
    HoraEstoque: double;
    RegistroValido: boolean;
  end;
// Log de Alteração de Itens do DAV
type
  TRegistroD4Rec = record
    NumeroDAV: array[0..13] of char;
    DataAlteracao: double;
    HoraAlteracao: double;
    CodigoProdutoServico: array[0..14] of char;
    Descricao: array[0..100] of char;
    Quantidade: double;
    Unidade: array[0..3] of char;
    ValorUnitario: double;
    DescontoSobreItem: double;
    AcrescimoSobreItem: double;
    ValorTotalLiquido: double;
    SituacaoTributaria: array[0..1] of char;
    Aliquota: double;
    IndicadorCancelamento: array[0..1] of char;
    CasasDecimaisQtd: integer;
    CasasDecimaisVlUn: integer;
    TipoAlteracao: array[0..1] of char;

  end;
// Manifesto Fiscal de Viagem – Transporte de Passageiros
type
  TRegistroF2Rec = record
    CNPJOrgao: array[0..14] of char;
    CNPJEmpresa: array[0..14] of char;
    CodigoLocalEmissao: double;
    IdentificacoLinha: double;
    DescricaoLinha: array[0..80] of char;
    DataPartida: double;
    HorarioPartida: double;
    CodigoTipoViagem: double;
  end;
// Bilhetes de Passagens do Manifesto – Transporte de Passageiros
type
  TRegistroF3Rec = record
    NumeroFabricacaoECF: array[0..20] of char;
    MFAdicional: array[0..1] of char;
    ModeloECF: array[0..20] of char;
    NumeroUsuario: integer;
    CCF: integer;
    COO: integer;
    CodigoOrigem: integer;
    CodigoDestino: integer;
    ValorTotalDocumento: double;
    SituacaoTributaria: array[0..1] of char;
    CodigoTipoServico: double;
    Poltrona: double;
  end;
// Tipo de serviço – Transporte de Passageiros
type
  TRegistroF4Rec = record
    CodigoTipoServico: integer;
    TotalTipoServico: double;
  end;
// Cupom de Embarque
type
  TRegistroM2Rec = record
    CNPJ: array[0..14] of char;
    InscricaoEstadual: array[0..14] of char;
    InscricaoMunicipal: array[0..14] of char;
    NumeroFabECF: array[0..20] of char;
    MFAdicional: array[0..1] of char;
    TipoECF: array[0..7] of char;
    MarcaECF: array[0..20] of char;
    ModeloECF: array[0..20] of char;
    NumeroUsuario: array[0..2] of char;
    CCF: integer;
    COO: integer;
    DataEmissao: double;
    HoraEmissao: double;
    Modalidade: double;
    Categoria: double;
    IdentificacaoLinha: array[0..8] of char;
    CodigoOrigem: array[0..20] of char;
    Codigodestino: array[0..20] of char;
    TipoServico: integer;
    DataViagem: double;
    HorarioViagem: double;
    TipoViagem: integer;
    Poltrona: integer;
    Plataforma: array[0..15] of char;
    CodigoDesconto: integer;
    ValorTarifa: double;
    Aliquota: double;
    Pedagio: double;
    TaxaEmbarque: double;
    ValorTotal: double;
    FormaPagamento: integer;
    ValorPago: double;
    NomePassageiro: array[0..50] of char;
    NumeroDocId: array[0..20] of char;
    SAC: array[0..10] of char;
    Agencia: array[0..30] of char;
  end;
// Cupom de Embarque Gratuidade
type
  TRegistroL2Rec = record
    CNPJ: array[0..14] of char;
    InscricaoEstadual: array[0..14] of char;
    InscricaoMunicipal: array[0..14] of char;
    NumeroFabECF: array[0..20] of char;
    MFAdicional: array[0..1] of char;
    TipoECF: array[0..7] of char;
    MarcaECF: array[0..20] of char;
    ModeloECF: array[0..20] of char;
    NumeroUsuario: array[0..2] of char;
    COO: integer;
    GNF: integer;
    GRG: integer;
    DataEmissao: double;
    HoraEmissao: double;
    Modalidade: integer;
    Categoria: integer;
    IdentificacaoLinha: array[0..8] of char;
    CodigoOrigem: array[0..20] of char;
    Codigodestino: array[0..20] of char;
    TipoServico: integer;
    DataViagem: double;
    HorarioViagem: double;
    TipoViagem: integer;
    Poltrona: integer;
    Plataforma: array[0..15] of char;
    CodigoDesconto: integer;
    ValorTarifa: double;
    Pedagio: double;
    TaxaEmbarque: double;
    ValorTotal: double;
    FormaPagamento: integer;
    ValorPago: double;
    NomePassageiro: array[0..50] of char;
    NumeroDocId: array[0..20] of char;
    SAC: array[0..10] of char;
    Agencia: array[0..30] of char;
  end;
// Movimento Diário de Pedágio
type
  TRegistroG2Rec = record
    CNPJ: array[0..14] of char;
    NumeroFabECF: array[0..20] of char;
    MFAdicional: array[0..1] of char;
    TipoECF: array[0..7] of char;
    MarcaECF: array[0..20] of char;
    ModeloECF: array[0..20] of char;
    NumeroCabine: double;
    DataMovimento: double;
    COOInicial: integer;
    COOFinal: integer;
    CCFInicial: integer;
    CCFFinal: integer;
    Valor2EixoSimples: double;
    Valor2EixosDupla: double;
    Valor3EixosSimples: double;
    Valor3EixosDupla: double;
    Valor4EixosSimples: double;
    Valor4EixosDupla: double;
    Valor5EixosDupla: double;
    Valor6EixosDupla: double;
    ValorRelativo: double;
    ValorTotalDia: double;
    QtdeVeiculoIsento: integer;
    Localizacao: array[0..250] of char;
  end;
// Mesa/Conta de Cliente
type
  TRegistroS2Rec = record
    CNPJ: array[0..14] of char;
    DataAbertura: double;
    HoraAabertura: double;
    Situacao: array[0..1] of char;
    ValorTotal: double;
    COOConferenciaMesa: integer;
    NumeroFabECFRG: array[0..20] of char;
    COOCupomFIscal: integer;
    NumeroFabECF: array[0..20] of char;
  end;

{%endregion}

implementation

{%region Constructor/Destructor/Error}
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
CRIA um novo componente TACBrPAF retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
function PAF_Create(var pafHandle: PPAFHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
    New(pafHandle);
    pafHandle^.PAF := TACBrPAF.Create(nil);
    pafHandle^.EventHandlers := TEventHandlers.Create();
    pafHandle^.UltimoErro := '';
    Result := 0;
  except
    on Exception: Exception do
    begin
      Result := -1;
      pafHandle^.UltimoErro := Exception.Message;
    end
  end;

end;

{
DESTRÓI o objeto TACBrPAF e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
function PAF_Destroy(pafHandle: PPAFHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.Destroy();
    pafHandle^.PAF := nil;

    Dispose(pafHandle);
    pafHandle := nil;
    Result := 0;

  except
    on Exception: Exception do
    begin
      Result := -1;
      pafHandle^.UltimoErro := Exception.Message;
    end
  end;

end;

function PAF_GetUltimoErro(const pafHandle: PPAFHandle; Buffer: PChar;
  const BufferLen: integer): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
    StrPLCopy(Buffer, pafHandle^.UltimoErro, BufferLen);
    Result := length(pafHandle^.UltimoErro);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

function PAF_GetPath(const pafHandle: PPAFHandle; Buffer: PChar;
  const BufferLen: integer): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp: string;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    StrTmp := pafHandle^.PAF.Path;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetPath(const pafHandle: PPAFHandle; const Path: PChar): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.Path := Path;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_GetDelimitador(const pafHandle: PPAFHandle; Buffer: PChar;
  const BufferLen: integer): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp: string;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    StrTmp := pafHandle^.PAF.Delimitador;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetDelimitador(const pafHandle: PPAFHandle;
  const Delimitador: PChar): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.Delimitador := Delimitador;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_GetCurMascara(const pafHandle: PPAFHandle; Buffer: PChar;
  const BufferLen: integer): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp: string;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    StrTmp := pafHandle^.PAF.CurMascara;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetCurMascara(const pafHandle: PPAFHandle;
  const CurMascara: PChar): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.CurMascara := CurMascara;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_GetTrimString(const pafHandle: PPAFHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    Result := integer(pafHandle^.PAF.TrimString);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetTrimString(const pafHandle: PPAFHandle;
  const TrimString: boolean): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.TrimString := TrimString;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_GetAssinarArquivo(const pafHandle: PPAFHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    Result := integer(pafHandle^.PAF.AssinarArquivo);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetAssinarArquivo(const pafHandle: PPAFHandle;
  const Assinar: boolean): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    pafHandle^.PAF.AssinarArquivo := Assinar;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_GetChaveRSA(const pafHandle: PPAFHandle; Buffer: PChar;
  const BufferLen: integer): integer; {$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp: string;
begin

  try
    StrTmp := pafHandle^.EventHandlers.ChaveRSA;
    StrPLCopy(Buffer, StrTmp, BufferLen);
    Result := length(StrTmp);
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetChaveRSA(const pafHandle: PPAFHandle; const Chave: PChar): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
    if not Assigned(pafHandle^.PAF.OnPAFGetKeyRSA) then
    begin
      pafHandle^.PAF.OnPAFGetKeyRSA := pafHandle^.EventHandlers.GetChaveRSA;
    end;
    pafHandle^.EventHandlers.ChaveRSA := Chave;
    Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;

end;

function PAF_SetAAC(const pafHandle: PPAFHandle; const aacHandle: PAACHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  if (aacHandle = nil) then
  begin
    pafHandle^.PAF.AAC := nil;
  end
  else
  begin

    try
      pafHandle^.PAF.AAC := aacHandle^.AAC;
      Result := 0;
    except
      on Exception: Exception do
      begin
        pafHandle^.UltimoErro := Exception.Message;
        Result := -1;
      end
    end;
  end;
end;

function PAF_SetEAD(const pafHandle: PPAFHandle; const eadHandle: PEADHandle): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  if (eadHandle = nil) then
  begin
    pafHandle^.PAF.EAD := nil;
  end
  else
  begin

    try
      pafHandle^.PAF.EAD := eadHandle^.EAD;
      Result := 0;
    except
      on Exception: Exception do
      begin
        pafHandle^.UltimoErro := Exception.Message;
        Result := -1;
      end
    end;
  end;
end;

{%endregion}

{%region Metodos do componente }

{%region Métodos do tipo "Preenche_?"}

function PAF_Preenche_A(const pafHandle: PPAFHandle;
  const RegistroA2Rec: array of TRegistroA2Rec; const CountA2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  try

    pafHandle^.PAF.PAF_A.RegistroA2.Clear;

    for i := 0 to CountA2 - 1 do
    begin
      with pafHandle^.PAF.PAF_A.RegistroA2.New do
      begin
        RegistroValido := RegistroA2Rec[i].RegistroValido;
        DT := RegistroA2Rec[i].Data;
        MEIO_PGTO := RegistroA2Rec[i].MeioDePagamento;
        TIPO_DOC := RegistroA2Rec[i].CodigoTipoDocumento;
        VL := RegistroA2Rec[i].Valor;
      end;
    end;

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_B.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_B(const pafHandle: PPAFHandle;
  const RegistroB1Rec: TRegistroHD1Rec; const RegistroB2Rec: array of TRegistroB2Rec;
  const CountB2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  try
    pafHandle^.PAF.PAF_B.RegistroB1.RAZAOSOCIAL := RegistroB1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_B.RegistroB1.UF := RegistroB1Rec.UF;
    pafHandle^.PAF.PAF_B.RegistroB1.CNPJ := RegistroB1Rec.CNPJ;
    pafHandle^.PAF.PAF_B.RegistroB1.IE := RegistroB1Rec.IE;
    pafHandle^.PAF.PAF_B.RegistroB1.IM := RegistroB1Rec.IM;

    pafHandle^.PAF.PAF_B.RegistroB2.Clear;

    for i := 0 to CountB2 - 1 do
    begin
      with pafHandle^.PAF.PAF_B.RegistroB2.New do
      begin
        BOMBA := RegistroB2Rec[i].BOMBA;
        BICO := RegistroB2Rec[i].BICO;
        Data := RegistroB2Rec[i].Data;
        HORA := RegistroB2Rec[i].HORA;
        MOTIVO := RegistroB2Rec[i].MOTIVO;
        CNPJ_EMPRESA := RegistroB2Rec[i].CNPJ_EMPRESA;
        CPF_TECNICO := RegistroB2Rec[i].CPF_TECNICO;
        NRO_LACRE_ANTES := RegistroB2Rec[i].NRO_LACRE_ANTES;
        NRO_LACRE_APOS := RegistroB2Rec[i].NRO_LACRE_APOS;
        ENCERRANTE_ANTES := RegistroB2Rec[i].ENCERRANTE_ANTES;
        ENCERRANTE_APOS := RegistroB2Rec[i].ENCERRANTE_APOS;
        RegistroValido := RegistroB2Rec[i].RegistroValido;
      end;
    end;

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_B.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_C(const pafHandle: PPAFHandle;
  const RegistroC1Rec: TRegistroHD1Rec; const RegistroC2Rec: array of TRegistroC2Rec;
  const CountC2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  //continua ...
  try
    pafHandle^.PAF.PAF_C.RegistroC1.RAZAOSOCIAL := RegistroC1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_C.RegistroC1.UF := RegistroC1Rec.UF;
    pafHandle^.PAF.PAF_C.RegistroC1.CNPJ := RegistroC1Rec.CNPJ;
    pafHandle^.PAF.PAF_C.RegistroC1.IE := RegistroC1Rec.IE;
    pafHandle^.PAF.PAF_C.RegistroC1.IM := RegistroC1Rec.IM;

    pafHandle^.PAF.PAF_C.RegistroC2.Clear;

    for i := 0 to CountC2 - 1 do
    begin
      with pafHandle^.PAF.PAF_C.RegistroC2.New do
      begin
        ID_ABASTECIMENTO := RegistroC2Rec[i].ID_ABASTECIMENTO;
        TANQUE := RegistroC2Rec[i].TANQUE;
        BOMBA := RegistroC2Rec[i].BOMBA;
        BICO := RegistroC2Rec[i].BICO;
        COMBUSTIVEL := RegistroC2Rec[i].COMBUSTIVEL;
        DATA_ABASTECIMENTO := RegistroC2Rec[i].DATA_ABASTECIMENTO;
        HORA_ABASTECIMENTO := RegistroC2Rec[i].HORA_ABASTECIMENTO;
        ENCERRANTE_INICIAL := RegistroC2Rec[i].ENCERRANTE_INICIAL;
        ENCERRANTE_FINAL := RegistroC2Rec[i].ENCERRANTE_FINAL;
        STATUS_ABASTECIMENTO := RegistroC2Rec[i].STATUS_ABASTECIMENTO;
        NRO_SERIE_ECF := RegistroC2Rec[i].NRO_SERIE_ECF;
        Data := RegistroC2Rec[i].Data;
        HORA := RegistroC2Rec[i].HORA;
        COO := RegistroC2Rec[i].COO;
        NRO_NOTA_FISCAL := RegistroC2Rec[i].NRO_NOTA_FISCAL;
        VOLUME := RegistroC2Rec[i].VOLUME;
        RegistroValido := RegistroC2Rec[i].RegistroValido;
      end;
    end;

    pafHandle^.PAF.CurMascara := '';

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_C.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_D(const pafHandle: PPAFHandle;
  const RegistroD1Rec: TRegistroHD1Rec; const RegistroD2Rec: array of TRegistroD2Rec;
  const CountD2: integer; const RegistroD3Rec: array of TRegistroD3Rec;
  const RegistroD4Rec: array of TRegistroD4Rec; const CountD4: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i, D, d4, IndexItem, index4: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...
  if (CountD2 <= 0) then
  begin
    pafHandle^.UltimoErro := 'O numero de DAVs não pode ser Zero';
    Result := -1;
    Exit;
  end;

  try
    IndexItem := 0;
    index4 := 0;
    pafHandle^.PAF.PAF_D.RegistroD1.RAZAOSOCIAL := RegistroD1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_D.RegistroD1.UF := RegistroD1Rec.UF;
    pafHandle^.PAF.PAF_D.RegistroD1.CNPJ := RegistroD1Rec.CNPJ;
    pafHandle^.PAF.PAF_D.RegistroD1.IE := RegistroD1Rec.IE;
    pafHandle^.PAF.PAF_D.RegistroD1.IM := RegistroD1Rec.IM;

    pafHandle^.PAF.PAF_D.RegistroD2.Clear;

    for i := 0 to CountD2 - 1 do
    begin
      with pafHandle^.PAF.PAF_D.RegistroD2.New do
      begin
        NUM_FAB := RegistroD2Rec[i].NUM_FAB;
        MF_ADICIONAL := RegistroD2Rec[i].MF_ADICIONAL;
        TIPO_ECF := RegistroD2Rec[i].TIPO_ECF;
        MARCA_ECF := RegistroD2Rec[i].MARCA_ECF;
        MODELO_ECF := RegistroD2Rec[i].MODELO_ECF;
        COO := RegistroD2Rec[i].COO;
        NUM_DAV := RegistroD2Rec[i].NUM_DAV;
        DT_DAV := RegistroD2Rec[i].DT_DAV;
        TIT_DAV := RegistroD2Rec[i].TIT_DAV;
        VLT_DAV := RegistroD2Rec[i].VLT_DAV;
        COO_DFV := RegistroD2Rec[i].COO_DFV;
        NUMERO_ECF := RegistroD2Rec[i].NUMERO_ECF;
        NOME_CLIENTE := RegistroD2Rec[i].NOME_CLIENTE;
        CPF_CNPJ := RegistroD2Rec[i].CPF_CNPJ;
        RegistroValido := RegistroD2Rec[i].RegistroValido;

        if RegistroD2Rec[i].QTD_D3 < 1 then
        begin
          pafHandle^.PAF.PAF_D.LimpaRegistros;
          pafHandle^.UltimoErro := 'O numero de itens nas DAVs não pode ser Zero';
          Result := -1;
          Exit;
        end;

        for D := 0 to RegistroD2Rec[i].QTD_D3 - 1 do
        begin
          // adicionar os itens do dav, um para cada item
          with RegistroD3.New do
          begin
            DT_INCLUSAO := RegistroD3Rec[IndexItem].DT_INCLUSAO;
            NUM_ITEM := RegistroD3Rec[IndexItem].NUM_ITEM;
            COD_ITEM := RegistroD3Rec[IndexItem].COD_ITEM;
            DESC_ITEM := RegistroD3Rec[IndexItem].DESC_ITEM;
            QTDE_ITEM := RegistroD3Rec[IndexItem].QTDE_ITEM;
            UNI_ITEM := RegistroD3Rec[IndexItem].UNI_ITEM;
            VL_UNIT := RegistroD3Rec[IndexItem].VL_UNIT;
            VL_DESCTO := RegistroD3Rec[IndexItem].VL_DESCTO;
            VL_ACRES := RegistroD3Rec[IndexItem].VL_ACRES;
            VL_TOTAL := RegistroD3Rec[IndexItem].VL_TOTAL;
            DEC_VL_UNIT := RegistroD3Rec[IndexItem].DEC_VL_UNIT;
            DEC_QTDE_ITEM := RegistroD3Rec[IndexItem].DEC_QTDE_ITEM;
            SIT_TRIB := RegistroD3Rec[IndexItem].SIT_TRIB;
            ALIQ := RegistroD3Rec[IndexItem].ALIQ;
            IND_CANC := RegistroD3Rec[IndexItem].IND_CANC;
            RegistroValido := RegistroD3Rec[IndexItem].RegistroValido;
          end;
          Inc(IndexItem);
        end;

        if (CountD4 > 0) then
        begin
          for d4 := 0 to RegistroD2Rec[i].QTD_D4 - 1 do
          begin
            with RegistroD4.New do
            begin
              COD_ITEM := RegistroD4Rec[index4].CodigoProdutoServico;
              DESC_ITEM := RegistroD4Rec[index4].Descricao;
              QTDE_ITEM := RegistroD4Rec[index4].Quantidade;
              UNI_ITEM := RegistroD4Rec[index4].Unidade;
              VL_UNIT := RegistroD4Rec[index4].ValorUnitario;
              VL_DESCTO := RegistroD4Rec[index4].DescontoSobreItem;
              VL_ACRES := RegistroD4Rec[index4].AcrescimoSobreItem;
              VL_TOTAL := RegistroD4Rec[index4].ValorTotalLiquido;
              SIT_TRIB := RegistroD4Rec[index4].SituacaoTributaria;
              ALIQ := RegistroD4Rec[index4].Aliquota;
              IND_CANC := RegistroD4Rec[index4].IndicadorCancelamento;
              DEC_QTDE_ITEM := RegistroD4Rec[index4].CasasDecimaisQtd;
              DEC_VL_UNIT := RegistroD4Rec[index4].CasasDecimaisVlUn;
              NUM_DAV := RegistroD4Rec[index4].NumeroDAV;
              DT_ALT := RegistroD4Rec[index4].DataAlteracao;
              TIP_ALT := RegistroD4Rec[index4].TipoAlteracao;
            end;
            Inc(index4);
          end;
        end;
      end;
    end;

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_D.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_E(const pafHandle: PPAFHandle;
  const RegistroE1Rec: TRegistroHD2Rec; const RegistroE2Rec: array of TRegistroE2Rec;
  const RegistroE3Rec: TRegistroE3Rec; const CountE2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  if (CountE2 <= 0) then
  begin
    pafHandle^.UltimoErro := 'O numero de Itens não pode ser Zero';
    Result := -1;
    Exit;
  end;

  try
    pafHandle^.PAF.PAF_E.RegistroE1.RAZAOSOCIAL := RegistroE1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_E.RegistroE1.UF := RegistroE1Rec.UF;
    pafHandle^.PAF.PAF_E.RegistroE1.CNPJ := RegistroE1Rec.CNPJ;
    pafHandle^.PAF.PAF_E.RegistroE1.IE := RegistroE1Rec.IE;
    pafHandle^.PAF.PAF_E.RegistroE1.IM := RegistroE1Rec.IM;
    pafHandle^.PAF.PAF_E.RegistroE1.NUM_FAB := RegistroE1Rec.NUM_FAB;
    pafHandle^.PAF.PAF_E.RegistroE1.MF_ADICIONAL := RegistroE1Rec.MF_ADICIONAL;
    pafHandle^.PAF.PAF_E.RegistroE1.TIPO_ECF := RegistroE1Rec.TIPO_ECF;
    pafHandle^.PAF.PAF_E.RegistroE1.MARCA_ECF := RegistroE1Rec.MARCA_ECF;
    pafHandle^.PAF.PAF_E.RegistroE1.MODELO_ECF := RegistroE1Rec.MODELO_ECF;
    pafHandle^.PAF.PAF_E.RegistroE1.DT_EST := RegistroE1Rec.DT_EST;
    pafHandle^.PAF.PAF_E.RegistroE1.RegistroValido := RegistroE1Rec.RegistroValido;
    pafHandle^.PAF.PAF_E.RegistroE1.InclusaoExclusao := RegistroE1Rec.InclusaoExclusao;

    pafHandle^.PAF.PAF_E.RegistroE2.Clear;

    for i := 0 to CountE2 - 1 do
    begin
      with pafHandle^.PAF.PAF_E.RegistroE2.New do
      begin
        COD_MERC := RegistroE2Rec[i].COD_MERC;
        DESC_MERC := RegistroE2Rec[i].DESC_MERC;
        UN_MED := RegistroE2Rec[i].UN_MED;
        QTDE_EST := RegistroE2Rec[i].QTDE_EST;
        RegistroValido := RegistroE2Rec[i].RegistroValido;
      end;
    end;

    pafHandle^.PAF.PAF_E.RegistroE3.RegistroValido := RegistroE3Rec.RegistroValido;
    pafHandle^.PAF.PAF_E.RegistroE3.NUM_FAB := RegistroE3Rec.NumeroFabricacao;
    pafHandle^.PAF.PAF_E.RegistroE3.MF_ADICIONAL := RegistroE3Rec.MFAdicional;
    pafHandle^.PAF.PAF_E.RegistroE3.TIPO_ECF := RegistroE3Rec.TipoECF;
    pafHandle^.PAF.PAF_E.RegistroE3.MARCA_ECF := RegistroE3Rec.MarcaECF;
    pafHandle^.PAF.PAF_E.RegistroE3.MODELO_ECF := RegistroE3Rec.ModeloECF;
    pafHandle^.PAF.PAF_E.RegistroE3.DT_EST := RegistroE3Rec.DataEstoque;

    Result := 1;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_E.LimpaRegistros;

      Result := -1;
    end
  end;

end;

function PAF_Preenche_H(const pafHandle: PPAFHandle;
  const RegistroH1Rec: TRegistroHD2Rec; const RegistroH2Rec: array of TRegistroH2Rec;
  const CountH2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  if (CountH2 <= 0) then
  begin
    pafHandle^.UltimoErro := 'O numero de Itens não pode ser Zero';
    Result := -1;
    Exit;
  end;

  try
    pafHandle^.PAF.PAF_H.RegistroH1.RAZAOSOCIAL := RegistroH1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_H.RegistroH1.UF := RegistroH1Rec.UF;
    pafHandle^.PAF.PAF_H.RegistroH1.CNPJ := RegistroH1Rec.CNPJ;
    pafHandle^.PAF.PAF_H.RegistroH1.IE := RegistroH1Rec.IE;
    pafHandle^.PAF.PAF_H.RegistroH1.IM := RegistroH1Rec.IM;
    pafHandle^.PAF.PAF_H.RegistroH1.NUM_FAB := RegistroH1Rec.NUM_FAB;
    pafHandle^.PAF.PAF_H.RegistroH1.MF_ADICIONAL := RegistroH1Rec.MF_ADICIONAL;
    pafHandle^.PAF.PAF_H.RegistroH1.TIPO_ECF := RegistroH1Rec.TIPO_ECF;
    pafHandle^.PAF.PAF_H.RegistroH1.MARCA_ECF := RegistroH1Rec.MARCA_ECF;
    pafHandle^.PAF.PAF_H.RegistroH1.MODELO_ECF := RegistroH1Rec.MODELO_ECF;
    pafHandle^.PAF.PAF_H.RegistroH1.DT_EST := RegistroH1Rec.DT_EST;
    pafHandle^.PAF.PAF_H.RegistroH1.RegistroValido := RegistroH1Rec.RegistroValido;
    pafHandle^.PAF.PAF_H.RegistroH1.InclusaoExclusao := RegistroH1Rec.InclusaoExclusao;

    pafHandle^.PAF.PAF_H.RegistroH2.Clear;

    for i := 0 to CountH2 - 1 do
    begin
      with pafHandle^.PAF.PAF_H.RegistroH2.New do
      begin
        RegistroValido := RegistroH2Rec[i].RegistroValido;
        CNPJ_CRED_CARTAO := RegistroH2Rec[i].CNPJ_CRED_CARTAO;
        COO := RegistroH2Rec[i].COO;
        CCF := RegistroH2Rec[i].CCF;
        VLR_TROCO := RegistroH2Rec[i].VLR_TROCO;
        DT_TROCO := RegistroH2Rec[i].DT_TROCO;
        CPF := RegistroH2Rec[i].CPF;
        Titulo := RegistroH2Rec[i].Titulo;
      end;
    end;

    Result := 1;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_H.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_P(const pafHandle: PPAFHandle;
  const RegistroP1Rec: TRegistroHD1Rec; const RegistroP2Rec: array of TRegistroP2Rec;
  const CountP2: integer): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  try
    pafHandle^.PAF.PAF_P.RegistroP1.RAZAOSOCIAL := RegistroP1Rec.RAZAOSOCIAL;
    pafHandle^.PAF.PAF_P.RegistroP1.UF := RegistroP1Rec.UF;
    pafHandle^.PAF.PAF_P.RegistroP1.CNPJ := RegistroP1Rec.CNPJ;
    pafHandle^.PAF.PAF_P.RegistroP1.IE := RegistroP1Rec.IE;
    pafHandle^.PAF.PAF_P.RegistroP1.IM := RegistroP1Rec.IM;

    pafHandle^.PAF.PAF_P.RegistroP2.Clear;

    for i := 0 to CountP2 - 1 do
    begin
      with pafHandle^.PAF.PAF_P.RegistroP2.New do
      begin
        COD_MERC_SERV := RegistroP2Rec[i].COD_MERC_SERV;
        DESC_MERC_SERV := RegistroP2Rec[i].DESC_MERC_SERV;
        UN_MED := RegistroP2Rec[i].UN_MED;
        IAT := RegistroP2Rec[i].IAT;
        IPPT := RegistroP2Rec[i].IPPT;
        ST := RegistroP2Rec[i].ST;
        ALIQ := RegistroP2Rec[i].ALIQ;
        VL_UNIT := RegistroP2Rec[i].VL_UNIT;
        RegistroValido := RegistroP2Rec[i].RegistroValido;
      end;
    end;

    Result := 1;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_P.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_Preenche_N(const pafHandle: PPAFHandle;
  const RegistroN1Rec : TRegistroHD1Rec; const RegistroN2Rec : TRegistroN2Rec;
  const RegistroN3Rec : array of TRegistroN3Rec; const QTD_N3 : Integer)
 : Integer;{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i : Integer;
begin
  if (pafHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
   pafHandle^.PAF.PAF_N.LimpaRegistros;

   pafHandle^.PAF.PAF_N.RegistroN1.UF          := RegistroN1Rec.UF;
   pafHandle^.PAF.PAF_N.RegistroN1.RAZAOSOCIAL := RegistroN1Rec.RAZAOSOCIAL;
   pafHandle^.PAF.PAF_N.RegistroN1.CNPJ        := RegistroN1Rec.CNPJ;
   pafHandle^.PAF.PAF_N.RegistroN1.IE          := RegistroN1Rec.IE;
   pafHandle^.PAF.PAF_N.RegistroN1.IM          := RegistroN1Rec.IM;

   pafHandle^.PAF.PAF_N.RegistroN2.NOME  := RegistroN2Rec.NOME;
   pafHandle^.PAF.PAF_N.RegistroN2.LAUDO := RegistroN2Rec.LAUDO;
   pafHandle^.PAF.PAF_N.RegistroN2.VERSAO  := RegistroN2Rec.VERSAO;

   for i := 0 to QTD_N3 - 1 do
   begin
   with pafHandle^.PAF.PAF_N.RegistroN3.New do
   begin
   NOME_ARQUIVO := RegistroN3Rec[i].NOME_ARQUIVO;
   MD5          := RegistroN3Rec[i].MD5;
   end;
   end;

  Result := 1;

  except
  on exception : Exception do
  begin
  pafHandle^.UltimoErro := exception.Message;
  pafHandle^.PAF.PAF_N.LimpaRegistros;
  Result := -1;
  end
  end;
end;

function PAF_Preenche_R(const pafHandle: PPAFHandle;
  const CountR1: integer;
  const RegistroR1Rec: array of TRegistroR1Rec;
  const RegistroR2Rec: array of TRegistroR2Rec;
  const RegistroR3Rec: array of TRegistroR3Rec;
  const RegistroR4Rec: array of TRegistroR4Rec;
  const RegistroR5Rec: array of TRegistroR5Rec;
  const RegistroR6Rec: array of TRegistroR6Rec;
  const RegistroR7Rec: array of TRegistroR7Rec): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i, d, e, IndexR2, IndexR3, IndexR4, IndexR5, IndexR6, IndexR7: integer;

begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  try
    IndexR2 := 0;
    IndexR3 := 0;
    IndexR4 := 0;
    IndexR5 := 0;
    IndexR6 := 0;
    IndexR7 := 0;
    pafHandle^.PAF.PAF_R.LimpaRegistros;

    for i := 0 to CountR1 - 1 do
    begin
      with pafHandle^.PAF.PAF_R.RegistroR01.New do
      begin
        NUM_FAB := RegistroR1Rec[i].NUM_FAB;
        MF_ADICIONAL := RegistroR1Rec[i].MF_ADICIONAL;
        TIPO_ECF := RegistroR1Rec[i].TIPO_ECF;
        MARCA_ECF := RegistroR1Rec[i].MARCA_ECF;
        MODELO_ECF := RegistroR1Rec[i].MODELO_ECF;
        VERSAO_SB := RegistroR1Rec[i].VERSAO_SB;
        DT_INST_SB := RegistroR1Rec[i].DT_INST_SB;
        HR_INST_SB := RegistroR1Rec[i].HR_INST_SB;
        NUM_SEQ_ECF := RegistroR1Rec[i].NUM_SEQ_ECF;
        CNPJ := RegistroR1Rec[i].CNPJ;
        IE := RegistroR1Rec[i].IE;
        CNPJ_SH := RegistroR1Rec[i].CNPJ_SH;
        IE_SH := RegistroR1Rec[i].IE_SH;
        IM_SH := RegistroR1Rec[i].IM_SH;
        NOME_SH := RegistroR1Rec[i].NOME_SH;
        NOME_PAF := RegistroR1Rec[i].NOME_PAF;
        VER_PAF := RegistroR1Rec[i].VER_PAF;
        COD_MD5 := RegistroR1Rec[i].COD_MD5;
        DT_INI := RegistroR1Rec[i].DT_INI;
        DT_FIN := RegistroR1Rec[i].DT_FIN;
        ER_PAF_ECF := RegistroR1Rec[i].ER_PAF_ECF;
        InclusaoExclusao := RegistroR1Rec[i].InclusaoExclusao;
        RegistroValido := RegistroR1Rec[i].RegistroValido;

        //Registro R2 e R3
        for d := 0 to RegistroR1Rec[i].QTD_R2 - 1 do
        begin
          with RegistroR02.New do
          begin
            NUM_USU := RegistroR2Rec[IndexR2].NUM_USU;
            CRZ := RegistroR2Rec[IndexR2].CRZ;
            COO := RegistroR2Rec[IndexR2].COO;
            CRO := RegistroR2Rec[IndexR2].CRO;
            DT_MOV := RegistroR2Rec[IndexR2].DT_MOV;
            DT_EMI := RegistroR2Rec[IndexR2].DT_EMI;
            HR_EMI := RegistroR2Rec[IndexR2].HR_EMI;
            VL_VBD := RegistroR2Rec[IndexR2].VL_VBD;
            PAR_ECF := RegistroR2Rec[IndexR2].PAR_ECF;
            RegistroValido := RegistroR2Rec[IndexR2].RegistroValido;

            for e := 0 to RegistroR2Rec[IndexR2].QTD_R3 - 1 do
            begin
              with RegistroR03.New do
              begin
                TOT_PARCIAL := RegistroR3Rec[IndexR3].TOT_PARCIAL;
                VL_ACUM := RegistroR3Rec[IndexR3].VL_ACUM;
                RegistroValido := RegistroR3Rec[IndexR3].RegistroValido;
              end;
              Inc(IndexR3);
            end;
          end;
          Inc(IndexR2);
        end;

        //Registro R4, R5 e R7
        for d := 0 to RegistroR1Rec[i].QTD_R4 - 1 do
        begin
          with RegistroR04.New do
          begin
            NUM_USU := RegistroR4Rec[IndexR4].NUM_USU;
            NUM_CONT := RegistroR4Rec[IndexR4].NUM_CONT;
            COO := RegistroR4Rec[IndexR4].COO;
            DT_INI := RegistroR4Rec[IndexR4].DT_INI;
            SUB_DOCTO := RegistroR4Rec[IndexR4].SUB_DOCTO;
            SUB_DESCTO := RegistroR4Rec[IndexR4].SUB_DESCTO;
            TP_DESCTO := RegistroR4Rec[IndexR4].TP_DESCTO;
            SUB_ACRES := RegistroR4Rec[IndexR4].SUB_ACRES;
            TP_ACRES := RegistroR4Rec[IndexR4].TP_ACRES;
            VL_TOT := RegistroR4Rec[IndexR4].VL_TOT;
            CANC := RegistroR4Rec[IndexR4].CANC;
            VL_CA := RegistroR4Rec[IndexR4].VL_CA;
            ORDEM_DA := RegistroR4Rec[IndexR4].ORDEM_DA;
            NOME_CLI := RegistroR4Rec[IndexR4].NOME_CLI;
            CNPJ_CPF := RegistroR4Rec[IndexR4].CNPJ_CPF;
            RegistroValido := RegistroR4Rec[IndexR4].RegistroValido;

            for e := 0 to RegistroR4Rec[IndexR4].QTD_R5 - 1 do
            begin
              with RegistroR05.New do
              begin
                NUM_CONT := RegistroR5Rec[IndexR5].NUM_CONT;
                NUM_ITEM := RegistroR5Rec[IndexR5].NUM_ITEM;
                COD_ITEM := RegistroR5Rec[IndexR5].COD_ITEM;
                DESC_ITEM := RegistroR5Rec[IndexR5].DESC_ITEM;
                QTDE_ITEM := RegistroR5Rec[IndexR5].QTDE_ITEM;
                UN_MED := RegistroR5Rec[IndexR5].UN_MED;
                VL_UNIT := RegistroR5Rec[IndexR5].VL_UNIT;
                DESCTO_ITEM := RegistroR5Rec[IndexR5].DESCTO_ITEM;
                ACRES_ITEM := RegistroR5Rec[IndexR5].ACRES_ITEM;
                VL_TOT_ITEM := RegistroR5Rec[IndexR5].VL_TOT_ITEM;
                COD_TOT_PARC := RegistroR5Rec[IndexR5].COD_TOT_PARC;
                IND_CANC := RegistroR5Rec[IndexR5].IND_CANC;
                QTDE_CANC := RegistroR5Rec[IndexR5].QTDE_CANC;
                VL_CANC := RegistroR5Rec[IndexR5].VL_CANC;
                VL_CANC_ACRES := RegistroR5Rec[IndexR5].VL_CANC_ACRES;
                IAT := RegistroR5Rec[IndexR5].IAT;
                IPPT := RegistroR5Rec[IndexR5].IPPT;
                QTDE_DECIMAL := RegistroR5Rec[IndexR5].QTDE_DECIMAL;
                VL_DECIMAL := RegistroR5Rec[IndexR5].VL_DECIMAL;
                RegistroValido := RegistroR5Rec[IndexR5].RegistroValido;
              end;
              Inc(IndexR5);
            end;

            for e := 0 to RegistroR4Rec[IndexR4].QTD_R7 - 1 do
            begin
              with RegistroR07.New do
              begin
                CCF := RegistroR7Rec[IndexR7].CCF;
                GNF := RegistroR7Rec[IndexR7].GNF;
                MP := RegistroR7Rec[IndexR7].MP;
                VL_PAGTO := RegistroR7Rec[IndexR7].VL_PAGTO;
                IND_EST := RegistroR7Rec[IndexR7].IND_EST;
                VL_EST := RegistroR7Rec[IndexR7].VL_EST;
                RegistroValido := RegistroR7Rec[IndexR7].RegistroValido;
              end;
              Inc(IndexR7);
            end;
          end;
          Inc(IndexR4);
        end;

        //Registro R6 e R7
        for d := 0 to RegistroR1Rec[i].QTD_R6 - 1 do
        begin
          with RegistroR06.New do
          begin
            NUM_USU := RegistroR6Rec[IndexR6].NUM_USU;
            COO := RegistroR6Rec[IndexR6].COO;
            GNF := RegistroR6Rec[IndexR6].GNF;
            GRG := RegistroR6Rec[IndexR6].GRG;
            CDC := RegistroR6Rec[IndexR6].CDC;
            DENOM := RegistroR6Rec[IndexR6].DENOM;
            DT_FIN := RegistroR6Rec[IndexR6].DT_FIN;
            HR_FIN := RegistroR6Rec[IndexR6].HR_FIN;
            RegistroValido := RegistroR6Rec[IndexR6].RegistroValido;

            for e := 0 to RegistroR6Rec[IndexR6].QTD_R7 - 1 do
            begin
              with RegistroR07.New do
              begin
                CCF := RegistroR7Rec[IndexR7].CCF;
                GNF := RegistroR7Rec[IndexR7].GNF;
                MP := RegistroR7Rec[IndexR7].MP;
                VL_PAGTO := RegistroR7Rec[IndexR7].VL_PAGTO;
                IND_EST := RegistroR7Rec[IndexR7].IND_EST;
                VL_EST := RegistroR7Rec[IndexR7].VL_EST;
                RegistroValido := RegistroR7Rec[IndexR7].RegistroValido;
              end;
              Inc(IndexR7);
            end;
          end;
          Inc(IndexR6);
        end;
      end;
    end;

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_R.LimpaRegistros;
      Result := -1;
    end
  end;

end;

function PAF_Preenche_T(const pafHandle: PPAFHandle;
  const RegistroT1Rec : TRegistroHD1Rec; const RegistroT2Rec : array of TRegistroT2Rec;
  const CountT2 : Integer) : Integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i : Integer;
begin
  if (pafHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  if(CountT2 <= 0) then
  begin
     pafHandle^.UltimoErro := 'O numero de Itens não pode ser Zero';
     Result := -1;
     Exit;
  end;

  try
   pafHandle^.PAF.PAF_T.RegistroT1.RAZAOSOCIAL      := RegistroT1Rec.RAZAOSOCIAL;
   pafHandle^.PAF.PAF_T.RegistroT1.UF               := RegistroT1Rec.UF;
   pafHandle^.PAF.PAF_T.RegistroT1.CNPJ             := RegistroT1Rec.CNPJ;
   pafHandle^.PAF.PAF_T.RegistroT1.IE               := RegistroT1Rec.IE;
   pafHandle^.PAF.PAF_T.RegistroT1.IM               := RegistroT1Rec.IM;

   pafHandle^.PAF.PAF_T.RegistroT2.Clear;

   for i := 0 to CountT2 - 1 do
   begin
   with pafHandle^.PAF.PAF_T.RegistroT2.New do
   begin
   DT_MOV         := RegistroT2Rec[i].DT_MOV;
   TP_DOCTO       := RegistroT2Rec[i].TP_DOCTO;
   SERIE          := RegistroT2Rec[i].SERIE;
   NUM_BILH_I     := RegistroT2Rec[i].NUM_BILH_I;
   NUM_BILH_F     := RegistroT2Rec[i].NUM_BILH_F;
   NUM_ECF        := RegistroT2Rec[i].NUM_ECF;
   CRZ            := RegistroT2Rec[i].CRZ;
   CFOP           := RegistroT2Rec[i].CFOP;
   VL_CONT        := RegistroT2Rec[i].VL_CONT;
   VL_BASECALC    := RegistroT2Rec[i].VL_BASECALC;
   ALIQ           := RegistroT2Rec[i].ALIQ;
   VL_IMPOSTO     := RegistroT2Rec[i].VL_IMPOSTO;
   VL_ISENTAS     := RegistroT2Rec[i].VL_ISENTAS;
   VL_OUTRAS      := RegistroT2Rec[i].VL_OUTRAS;
   RegistroValido := RegistroT2Rec[i].RegistroValido;
   end;
   end;

  Result := 1;

  except
  on exception : Exception do
  begin
  pafHandle^.UltimoErro := exception.Message;
  pafHandle^.PAF.PAF_N.LimpaRegistros;
  Result := -1;
  end
  end;
end;

function PAF_Preenche_U(const pafHandle: PPAFHandle;
  const RegistroU1Rec: TRegistroHD1Rec): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;
  //continua ...

  pafHandle^.PAF.PAF_U.RegistroU1.RAZAOSOCIAL := RegistroU1Rec.RazaoSocial;
  pafHandle^.PAF.PAF_U.RegistroU1.CNPJ := RegistroU1Rec.CNPJ;
  pafHandle^.PAF.PAF_U.RegistroU1.IE := RegistroU1Rec.IE;
  pafHandle^.PAF.PAF_U.RegistroU1.IM := RegistroU1Rec.IM;

  Result := 1;
end;

function PAF_Preenche_TITP(const pafHandle: PPAFHandle;
  const RegistroMercadoriasRec: array of TRegistroMercadoriaRec;
  const Count: integer; const RegistroInsumosRec: array of TRegistroInsumoRec;
  const Titulo: PChar; const Data: double): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i, d, IndexItem: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    IndexItem := 0;
    pafHandle^.PAF.PAF_TITP.LimpaRegistros;
    pafHandle^.PAF.PAF_TITP.DataHora := Data;
    pafHandle^.PAF.PAF_TITP.Titulo := Titulo;
    for i := 0 to Count - 1 do
    begin
      with pafHandle^.PAF.PAF_TITP.Mercadorias.New do
      begin
        Descricao := RegistroMercadoriasRec[i].Descricao;
        Codigo := RegistroMercadoriasRec[i].Codigo;
        Aliquota := RegistroMercadoriasRec[i].Aliquota;
        Unidade := RegistroMercadoriasRec[i].Unidade;
        Quantidade := RegistroMercadoriasRec[i].Quantidade;
        Ean := RegistroMercadoriasRec[i].Ean;
        CST := RegistroMercadoriasRec[i].CST;
        VlrUnitario := RegistroMercadoriasRec[i].VlrUnitario;

        if RegistroMercadoriasRec[i].QTD_Insumos < 1 then
        begin
          pafHandle^.PAF.PAF_TITP.LimpaRegistros;
          pafHandle^.UltimoErro := 'O numero de insumos não pode ser Zero';
          Result := -1;
          Exit;
        end;

        for d := 0 to RegistroMercadoriasRec[i].QTD_Insumos - 1 do
        begin
          // adiciona os insumos para cada mercadoria
          with Insumos.New do
          begin
            Descricao := RegistroInsumosRec[IndexItem].Descricao;
            Codigo := RegistroInsumosRec[IndexItem].Codigo;
            Aliquota := RegistroInsumosRec[IndexItem].Aliquota;
            Unidade := RegistroInsumosRec[IndexItem].Unidade;
            Quantidade := RegistroInsumosRec[IndexItem].Quantidade;
            Ean := RegistroInsumosRec[IndexItem].Ean;
            CST := RegistroInsumosRec[IndexItem].CST;
            VlrUnitario := RegistroInsumosRec[IndexItem].VlrUnitario;
          end;
          Inc(IndexItem);
        end;
      end;
    end;

    Result := 1;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_TITP.LimpaRegistros;
      Result := -1;
    end
  end;
end;

{%region Não implementados}

{
 Os métodos abaixo não foram implementados ainda por falta de tempo, e no momento (08/11/2013)
 Implementei apenas os que vou utilizar para a homologação.

I´ll be back...
}

//function PAF_Preenche_F(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
//{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;

//end;

//function PAF_Preenche_G(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
// {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;
//  //continua ...
//end;

//function PAF_Preenche_L(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
// {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;
//  //continua ...
//end;

//function PAF_Preenche_M(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
// {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;
//  //continua ...
//end;

//function PAF_Preenche_S(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
// {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;
//  //continua ...
//end;

//function PAF_Preenche_T(const pafHandle: PPAFHandle; const Arquivo: PChar): integer;
// {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
//var
//  i: integer;
//begin
//  if (pafHandle = nil) then
//  begin
//    Result := -2;
//    Exit;
//  end;
//  //continua ...
//end;

{%endregion}

{%endegion}

function PAF_SaveFileTXT_B(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    if (pafHandle^.PAF.SaveFileTXT_B(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_B.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_C(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  OldMask: string;
begin
  try
    if (pafHandle = nil) then
    begin
      Result := -2;
      Exit;
    end;

    OldMask := pafHandle^.PAF.CurMascara;
    pafHandle^.PAF.CurMascara := '';

    if (pafHandle^.PAF.SaveFileTXT_C(Arquivo)) then
    begin
      pafHandle^.PAF.CurMascara := OldMask;
      Result := 1;
    end
    else
    begin
      pafHandle^.PAF.CurMascara := OldMask;
      Result := 0;
    end

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_C.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_D(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;
{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    if (pafHandle^.PAF.SaveFileTXT_D(Arquivo)) then
      Result := 1
    else
      Result := 0;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_D.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_E(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_E(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_E.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_H(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_H(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_H.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_N(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_N(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_N.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_P(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_P(Arquivo)) then
      Result := 1
    else
      Result := 0;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_P.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_R(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;
{$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i, d, e, IndexR2, IndexR3, IndexR4, IndexR5, IndexR6, IndexR7: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_R(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_R.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_T(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;

 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  i: integer;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try

    if (pafHandle^.PAF.SaveFileTXT_T(Arquivo)) then
      Result := 1
    else
      Result := 0;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_T.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_TITP(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    if (pafHandle^.PAF.SaveFileTXT_TITP(Arquivo)) then
      Result := 1
    else
      Result := 0;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      pafHandle^.PAF.PAF_TITP.LimpaRegistros;
      Result := -1;
    end
  end;
end;

function PAF_SaveFileTXT_RegistrosPAF(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    if (pafHandle^.PAF.SaveFileTXT_RegistrosPAF(Arquivo)) then
      Result := 1
    else
      Result := 0;
  except
    on Exception: Exception do
    begin
      pafHandle^.PAF.PAF_A.LimpaRegistros;
      pafHandle^.PAF.PAF_B.LimpaRegistros;
      pafHandle^.PAF.PAF_C.LimpaRegistros;
      pafHandle^.PAF.PAF_D.LimpaRegistros;
      pafHandle^.PAF.PAF_E.LimpaRegistros;
      pafHandle^.PAF.PAF_H.LimpaRegistros;
      pafHandle^.PAF.PAF_N.LimpaRegistros;
      pafHandle^.PAF.PAF_P.LimpaRegistros;
      pafHandle^.PAF.PAF_R.LimpaRegistros;
      pafHandle^.PAF.PAF_T.LimpaRegistros;
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;
end;

function PAF_AssinaArquivoComEAD(const pafHandle: PPAFHandle;
  const Arquivo: PChar): integer;{$IFDEF STDCALL} stdcall;
 {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin
  try
    if (pafHandle = nil) then
    begin
      Result := -2;
      Exit;
    end;

    if (pafHandle^.PAF.AssinaArquivoComEAD(Arquivo)) then
      Result := 1
    else
      Result := 0;

  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;
end;

{%endregion}

{%region Eventos}

procedure TEventHandlers.GetChaveRSA(var Chave: ansistring);
begin
  if (Length(ChaveRSA) > 0) then
    Chave := ChaveRSA
  else
    Chave := OnGetChaveRSACallback();
end;

function PAF_SetOnPAFGetKeyRSA(const pafHandle: PPAFHandle;
  const method: TGetChaveCallback): integer;
 {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (pafHandle = nil) then
  begin
    Result := -2;
    Exit;
  end;

  try
    if Assigned(method) then
    begin
      pafHandle^.PAF.OnPAFGetKeyRSA := pafHandle^.EventHandlers.GetChaveRSA;
      pafHandle^.EventHandlers.OnGetChaveRSACallback := method;
      Result := 0;
    end
    else
    begin
      pafHandle^.PAF.OnPAFGetKeyRSA := nil;
      pafHandle^.EventHandlers.OnGetChaveRSACallback := nil;
      Result := 0;
    end;
  except
    on Exception: Exception do
    begin
      pafHandle^.UltimoErro := Exception.Message;
      Result := -1;
    end
  end;
end;

{%endregion}

exports

  { Funções }
  PAF_Create,
  PAF_Destroy,
  PAF_GetUltimoErro,

  {Eventos}
  PAF_SetOnPAFGetKeyRSA,

  { Propriedades Componente }
  PAF_GetPath,
  PAF_SetPath,
  PAF_GetDelimitador,
  PAF_SetDelimitador,
  PAF_GetCurMascara,
  PAF_SetCurMascara,
  PAF_GetTrimString,
  PAF_SetTrimString,
  PAF_GetAssinarArquivo,
  PAF_SetAssinarArquivo,
  PAF_GetChaveRSA,
  PAF_SetChaveRSA,
  PAF_SetAAC,
  PAF_SetEAD,

  {Preenche registros da ECF}
  PAF_Preenche_A,
  PAF_Preenche_B,
  PAF_Preenche_C,
  PAF_Preenche_D,
  PAF_Preenche_E,
  PAF_Preenche_H,
  PAF_Preenche_N,
  PAF_Preenche_P,
  PAF_Preenche_R,
  PAF_Preenche_T,
  PAF_Preenche_U,
  PAF_Preenche_TITP,

  {Salvar Arquivos PAF}
  PAF_SaveFileTXT_B,
  PAF_SaveFileTXT_C,
  PAF_SaveFileTXT_D,
  PAF_SaveFileTXT_E,
  PAF_SaveFileTXT_H,
  PAF_SaveFileTXT_N,
  PAF_SaveFileTXT_P,
  PAF_SaveFileTXT_R,
  PAF_SaveFileTXT_T,
  PAF_SaveFileTXT_TITP,
  PAF_SaveFileTXT_RegistrosPAF,
  PAF_AssinaArquivoComEAD;

end.
