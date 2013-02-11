unit ACBrSpedDll;

{$mode delphi}

interface

uses
  Classes, SysUtils;

{%region Registros Bloco 0}

type Bloco0Registro0000 = record
  COD_VER    : Integer; /// Código da versão do leiaute: 100, 101, 102
  COD_FIN    : Integer; /// Código da finalidade do arquivo: 0 - Remessa do arquivo original / 1 - Remessa do arquivo substituto.
  DT_INI     : Double;           /// Data inicial das informações contidas no arquivo
  DT_FIN     : Double;           /// Data final das informações contidas no arquivo
  NOME       : array[0..100] of char;                 /// Nome empresarial do contribuinte:
  CNPJ       : array[0..14] of char;               /// Número de inscrição do contribuinte:
  CPF        : array[0..11] of char;                 /// Número de inscrição do contribuinte:
  UF         : array[0..2] of char;                  /// Sigla da unidade da federação:
  IE         : array[0..14] of char;                  /// Inscrição Estadual do contribuinte:
  COD_MUN    : Integer;            /// Código do município do domicílio fiscal:
  IM         : array[0..14] of char;                  /// Inscrição Municipal do contribuinte:
  SUFRAMA    : array[0..9] of char;             /// Número de inscrição do contribuinte:
  IND_PERFIL : Integer;     /// Perfil de apresentação do arquivo fiscal: A - Perfil A / B - Perfil B / C - Perfil C
  IND_ATIV   : Integer;
end;

type Bloco0Registro0001 = record
   IND_MOV    : Integer; /// Indicador de movimento: 0- Bloco com dados informados, 1- Bloco sem dados informados.
end;

type Bloco0Registro0005 = record
  FANTASIA : array[0..60] of char;     /// Nome de fantasia associado:
  CEP      : array[0..8] of char;     /// Código de Endereçamento Postal:
  ENDERECO : array[0..60] of char;     /// Logradouro e endereço do imóvel:
  NUM      : array[0..10] of char;     /// Número do imóvel:
  COMPL    : array[0..60] of char;     /// Dados complementares do endereço:
  BAIRRO   : array[0..60] of char;     /// Bairro em que o imóvel está situado:
  FONE     : array[0..10] of char;     /// Número do telefone:
  FAX      : array[0..10] of char;     /// Número do fax:
  EMAIL    : array[0..150] of char;     /// Endereço do correio eletrônico:
end;

type Bloco0Registro0015 = record
  UF_ST : array[0..2] of char;   /// Sigla da unidade da federação:
  IE_ST : array[0..14] of char;   /// Inscrição Estadual:
end;

type Bloco0Registro0100 = record
  NOME     : array[0..100] of char;       /// Nome do contabilista/escritório:
  CPF      : array[0..11] of char;        /// Número de inscrição no CPF:
  CRC      : array[0..15] of char;        /// Número de inscrição no Conselho Regional:
  CNPJ     : array[0..14] of char;        /// CNPJ do escritório de contabilidade, se houver:
  CEP      : array[0..8] of char;         /// Código de Endereçamento Postal:
  ENDERECO : array[0..60] of char;        /// Logradouro e endereço do imóvel:
  NUM      : array[0..10] of char;        /// Número do imóvel:
  COMPL    : array[0..60] of char;        /// Dados complementares do endereço:
  BAIRRO   : array[0..60] of char;        /// Bairro em que o imóvel está situado:
  FONE     : array[0..10] of char;        /// Número do telefone:
  FAX      : array[0..10] of char;        /// Número do fax:
  EMAIL    : array[0..150] of char;       /// Endereço do correio eletrônico:
  COD_MUN  : integer;                     /// Código do município, conforme tabela IBGE:
end;

type Bloco0Registro0150 = record
  COD_PART  : array[0..60] of char;       /// Código de identificação do participante:
  NOME      : array[0..100] of char;      /// Nome pessoal ou empresarial:
  COD_PAIS  : array[0..5] of char;        /// Código do país do participante:
  CNPJ      : array[0..14] of char;       /// CNPJ do participante:
  CPF       : array[0..11] of char;       /// CPF do participante na unidade da federação do destinatário:
  IE        : array[0..14] of char;       /// Inscrição Estadual do participante:
  COD_MUN   : integer;                    /// Código do município:
  SUFRAMA   : array[0..9] of char;        /// Número de inscrição na Suframa:
  ENDERECO  : array[0..60] of char;       /// Logradouro e endereço do imóvel:
  NUM       : array[0..10] of char;       /// Número do imóvel:
  COMPL     : array[0..60] of char;       /// Dados complementares do endereço:
  BAIRRO    : array[0..60] of char;       /// Bairro em que o imóvel está situado:
end;

type Bloco0Registro0175 = record
  DT_ALT   : Double;                      /// Data de alteração do cadastro:
  NR_CAMPO : array[0..2] of char;         /// Número do campo alterado (Somente campos 03 a 13):
  CONT_ANT : array[0..100] of char;       /// Conteúdo anterior do campo:
end;

type Bloco0Registro0190 = record
  UNID  : array[0..6] of char;        /// Código da unidade de medida:
  DESCR : array[0..100] of char;
end;

type Bloco0Registro0200 = record
  COD_ITEM     : array[0..60] of char;        /// Código do item:
  DESCR_ITEM   : array[0..200] of char;       /// Descrição do item:
  COD_BARRA    : array[0..14] of char;        /// Código de barra do produto, se houver:
  COD_ANT_ITEM : array[0..60] of char;        /// Código anterior do item (ultima apresentado):
  UNID_INV     : array[0..6] of char;         /// Unidade de medida do estoque:
  TIPO_ITEM    : Integer;                     /// Tipo do item - Atividades Industriais, Comerciais e Serviços: 00 - Mercadoria para Revenda, 01 - Matéria-Prima,  02 - Embalagem, 03 - Produto em Processo, 04 - Produto Acabado, 05 - Subproduto, 06 - Produto Intermediário, 07 - Material de Uso e Consumo, 08 - Ativo Imobilizado, 09 - Serviços, 10 - Outros insumos, 99 - Outras
  COD_NCM      : array[0..8] of char;         /// Código da Nomenclatura Comum do Mercosul:
  EX_IPI       : array[0..3] of char;         /// Código EX, conforme a TIPI:
  COD_GEN      : array[0..2] of char;         /// Código gênero item, tabela indicada item 4.2.1:
  COD_LST      : array[0..4] of char;         /// Código serviço Anexo I - Lei nº116/03:
  ALIQ_ICMS    : Double;                      /// Alíquota ICMS aplicável (operações internas):
end;

type Bloco0Registro0205 = record
  DESCR_ANT_ITEM : array[0..200] of char;    /// Descrição anterior do item:
  DT_INI         : double;                   /// Data inicial de utilização do código:
  DT_FIN         : double;                   /// Data final de utilização do código:
  COD_ANT_ITEM   : array[0..60] of char;     /// Código anterior do item com relação à última informação apresentada.
end;

type Bloco0Registro0206 = record
  COD_COMB   : array[0..60] of char;      /// Código do combustível, conforme tabela publicada pela ANP:
end;

type Bloco0Registro0220 = record
  UNID_CONV  : array[0..6] of char;       /// Unidade comercial a ser convertida na unidade de estoque, referida em 0200:
  FAT_CONV   : Double;                    /// Fator de conversão:
end;

type Bloco0Registro0300 = record
  COD_IND_BEM : array[0..60] of char;    /// Código individualizado do bem ou componente adotado no controle patrimonial do estabelecimento informante
  IDENT_MERC  : Integer;                 /// Identificação do tipo de mercadoria: 1 = bem; 2 = componente.
  DESCR_ITEM  : array[0..200] of char;   /// Descrição do bem ou componente (modelo, marca e outras características necessárias a sua individualização)
  COD_PRNC    : array[0..60] of char;    /// Código de cadastro do bem principal nos casos em que o bem ou componente ( campo 02) esteja vinculado a um bem principal.
  COD_CTA     : array[0..60] of char;    /// Código da conta analítica de contabilização do bem ou componente (campo 06 do Registro 0500)
  NR_PARC     : Double;                  /// Número total de parcelas a serem apropriadas, segundo a legislação de cada unidade federada
end;

type Bloco0Registro0305 = record
  COD_CCUS   : array[0..60] of char;     /// Código do centro de custo onde o bem está sendo ou será utilizado (campo 03 do Registro 0600)
  FUNC       : array[0..200] of char;    /// Descrição sucinta da função do bem na atividade do estabelecimento
  VIDA_UTIL  : Integer;                  /// Vida útil estimada do bem, em número de meses
end;

type Bloco0Registro0400 = record
  COD_NAT    : array[0..60] of char;     /// Código da natureza:
  DESCR_NAT  : array[0..200] of char;    /// Descrição da natureza:
end;

type Bloco0Registro0450 = record
  COD_INF   : array[0..6] of char;      /// Código da informação complementar do documento fiscal:
  TXT       : array[0..1023] of char;    /// Texto livre (1Kb):
end;

type Bloco0Registro0460 = record
  COD_OBS   : array[0..6] of char;      /// Código da Observação do lançamento fiscal:
  TXT       : array[0..1023] of char;   /// Descrição da observação vinculada ao lançamento fiscal:
end;

type Bloco0Registro0500 = record
    DT_ALT     : double;                // Data da inclusão/alteração
    COD_NAT_CC : array[0..2] of char;   // Código da natureza da conta/grupo de contas
    IND_CTA    : array[0..1] of char;   // Indicador do tipo de conta:  S - Sintética ou A - Analítica
    NIVEL      : array[0..5] of char;   // Nível da conta analítica/grupo de contas
    COD_CTA    : array[0..60] of char;  // Código da conta analítica/grupo de conta
    NOME_CTA   : array[0..60] of char;  // Nome da conta analítica/grupo de contas
end;

type Bloco0Registro0600 = record
  DT_ALT     : double;        // Data da inclusão/alteração
  COD_CCUS   : array[0..60] of char;       // Código do centro de custos.
  CCUS       : array[0..60] of char;       // Nome do centro de custos.
end;

{%endregion}

{%region Registros Bloco 1}

type Bloco1Registro1001 = record
   IND_MOV    : Integer; /// Indicador de movimento: 0- Bloco com dados informados, 1- Bloco sem dados informados.
end;

type Bloco1Registro1010 = record
  IND_EXP   : array[0..1] of char; // Reg. 1100 - Ocorreu averbação (conclusão) de exportação no período:
  IND_CCRF  : array[0..1] of char; // Reg. 1200 – Existem informações acerca de créditos de ICMS a serem controlados, definidos pela Sefaz:
  IND_COMB  : array[0..1] of char; // Reg. 1300 – É comercio varejista de combustíveis:
  IND_USINA : array[0..1] of char; // Reg. 1390 – Usinas de açúcar e/álcool – O estabelecimento é produtor de açúcar e/ou álcool carburante:
  IND_VA    : array[0..1] of char; // Reg. 1400 – Existem informações a serem prestadas neste registro e o registro é obrigatório em sua Unidade da Federação:
  IND_EE    : array[0..1] of char; // Reg. 1500 - A empresa é distribuidora de energia e ocorreu fornecimento de energia elétrica para consumidores de outra UF:
  IND_CART  : array[0..1] of char; // Reg. 1600 - Realizou vendas com Cartão de Crédito ou de débito:
  IND_FORM  : array[0..1] of char; // Reg. 1700 - É obrigatório em sua unidade da federação o controle de utilização de documentos  fiscais em papel:
  IND_AER   : array[0..1] of char; // Reg. 1800 – A empresa prestou serviços de transporte aéreo de cargas e de passageiros:
end;

type Bloco1Registro1100 = record
  IND_DOC   : Integer;                /// Informe o tipo de documento: 0 - Declaração de Exportação, 1 - Declaração Simplificada de Exportação.
  NRO_DE    : array[0..11] of char;   /// Número da declaração
  DT_DE     : Double;                 /// Data da declaração (DDMMAAAA)
  NAT_EXP   : Integer;                /// Preencher com: 0 - Exportação Direta, 1 - Exportação Indireta
  NRO_RE    : array[0..12] of char;   /// Nº do registro de Exportação
  DT_RE     : Double;                 /// Data do Registro de Exportação (DDMMAAAA)
  CHC_EMB   : array[0..18] of char;   /// Nº do conhecimento de embarque
  DT_CHC    : Double;                 /// Data do conhecimento de embarque (DDMMAAAA)
  DT_AVB    : Double;                 /// Data da averbação da Declaração de exportação (ddmmaaaa)
  TP_CHC    : Integer;                /// Informação do tipo de conhecimento de transporte : 01 - AWB; 02 - MAWB; 03 - HAWB;04 - COMAT; 06 - R. EXPRESSAS; 07 - ETIQ. REXPRESSAS; 08 - HR. EXPRESSAS; 09 - AV7; 10 - BL; 11 - MBL; 12 - HBL; 13 - CRT; 14 - DSIC; 16 - COMAT BL; 17 - RWB; 18 - HRWB; 19 - TIF/DTA; 20 - CP2; 91 - NÂO IATA; 92 - MNAO IATA; 93 - HNAO IATA; 99 - OUTROS.
  PAIS      : array[0..3] of char;            /// Código do país de destino da mercadoria (Preencher conforme tabela do SISCOMEX)
end;

type Bloco1Registro1105 = record
    COD_MOD  : array[0..2] of char;        /// Código do modelo da NF, conforme tabela 4.1.1
    SERIE    : array[0..3] of char;        /// Série da Nota Fiscal
    NUM_DOC  : array[0..9] of char;        /// Número de Nota Fiscal de Exportação emitida pelo Exportador
    CHV_NFE  : array[0..44] of char;       /// Chave da Nota Fiscal Eletrônica
    DT_DOC   : Double;                     /// Data da emissão da NF de exportação
    COD_ITEM : array[0..60] of char;       /// Código do item (campo 02 do Registro 0200)
end;

type Bloco1Registro1110 = record
    COD_PART  : array[0..60] of char;
    COD_MOD   : array[0..2] of char;
    SER       : array[0..4] of char;
    NUM_DOC   : array[0..9] of char;
    DT_DOC    : Double;
    CHV_NFE   : array[0..44] of char;
    NR_MEMO   : array[0..60] of char;
    QTD       : Double;
    UNID      : array[0..6] of char;
end;

type Bloco1Registro1200 = record
    COD_AJ_APUR : array[0..8] of char;
    SLD_CRED    : Double;
    CRED_APR    : Double;
    CRED_RECEB  : Double;
    CRED_UTIL   : Double;
    SLD_CRED_FIM: Double;
end;

type Bloco1Registro1210 = record
    TIPO_UTIL    : array[0..4] of char;
    NR_DOC       : array[0..60] of char;
    VL_CRED_UTIL : Double;
end;

type Bloco1Registro1300 = record
    COD_ITEM     : array[0..60] of char;
    DT_FECH      : Double;
    ESTQ_ABERT   : Double;
    VOL_ENTR     : Double;
    VOL_DISP     : Double;
    VOL_SAIDAS   : Double;
    ESTQ_ESCR    : Double;
    VAL_AJ_PERDA : Double;
    VAL_AJ_GANHO : Double;
    FECH_FISICO  : Double;
end;


type Bloco1Registro1310 = record
     NUM_TANQUE  : array[0..3] of char;
     ESTQ_ABERT  : Double;
     VOL_ENTR    : Double;
     VOL_DISP    : Double;
     VOL_SAIDAS  : Double;
     ESTQ_ESCR   : Double;
     VAL_AJ_PERDA: Double;
     VAL_AJ_GANHO: Double;
     FECH_FISICO : Double;
end;

type Bloco1Registro1320 = record
     NUM_BICO   : array[0..60] of char;
     NR_INTERV  : array[0..60] of char;
     MOT_INTERV : array[0..50] of char;
     NOM_INTERV : array[0..30] of char;
     CNPJ_INTERV: array[0..14] of char;
     CPF_INTERV : array[0..11] of char;
     VAL_FECHA  : Double;
     VAL_ABERT  : Double;
     VOL_AFERI  : Double;
     VOL_VENDAS : Double;
end;

type Bloco1Registro1350 = record
     SERIE        : array[0..4] of char;
     FABRICANTE   : array[0..60] of char;
     MODELO       : array[0..60] of char;
     TIPO_MEDICAO : Integer;
end;

type Bloco1Registro1360 = record
     NUM_LACRE   : array[0..20] of char;
     DT_APLICACAO: Double;
end;

type Bloco1Registro1370 = record
     NUM_BICO    : array[0..3] of char;
     COD_ITEM    : array[0..60] of char;
     NUM_TANQUE  : array[0..3] of char;
end;

type Bloco1Registro1390 = record
     COD_PROD : array[0..2] of char;
end;

type Bloco1Registro1400 = record
    COD_ITEM : array[0..60] of char;
    MUN      : array[0..7] of char;
    VALOR    : Double;
end;

type Bloco1Registro1500 = record
     IND_OPER     : array[0..1] of char;
     IND_EMIT     : array[0..1] of char;
     COD_PART     : array[0..60] of char;
     COD_MOD      : array[0..60] of char;
     COD_SIT      : Integer;
     SER          : array[0..4] of char;
     SUB          : array[0..3] of char;
     COD_CONS     : Integer;
     NUM_DOC      : array[0..9] of char;
     DT_DOC       : Double;
     DT_E_S       : Double;
     VL_DOC       : Double;
     VL_DESC      : Double;
     VL_FORN      : Double;
     VL_SERV_NT   : Double;
     VL_TERC      : Double;
     VL_DA        : Double;
     VL_BC_ICMS   : Double;
     VL_ICMS      : Double;
     VL_BC_ICMS_ST: Double;
     VL_ICMS_ST   : Double;
     COD_INF      : array[0..6] of char;
     VL_PIS       : Double;
     VL_COFINS    : Double;
     TP_LIGACAO      : Integer;
     COD_GRUPO_TENSAO: Integer;
end;

type Bloco1Registro1510 = record
  NUM_ITEM        : array[0..3] of char;
  COD_ITEM        : array[0..60] of char;
  COD_CLASS       : array[0..4] of char;
  QTD             : Double;
  UNID            : array[0..6] of char;
  VL_ITEM         : Double;
  VL_DESC         : Double;
  CST_ICMS        : array[0..3] of char;
  CFOP            : array[0..4] of char;
  VL_BC_ICMS      : Double;
  ALIQ_ICMS       : Double;
  VL_ICMS         : Double;
  VL_BC_ICMS_ST   : Double;
  ALIQ_ST         : Double;
  VL_ICMS_ST      : Double;
  IND_REC         : Integer;
  COD_PART        : array[0..60] of char;
  VL_PIS          : Double;
  VL_COFINS       : Double;
  COD_CTA         : array[0..60] of char;
end;

type Bloco1Registro1600 = record
    COD_PART     : array[0..60] of char;
    TOT_CREDITO  : Double;
    TOT_DEBITO   : Double;
end;

type Bloco1Registro1700 = record
     COD_DISP   : Integer;
     COD_MOD    : array[0..2] of char;
     SER        : array[0..4] of char;
     SUB        : array[0..3] of char;
     NUM_DOC_INI: array[0..12] of char;
     NUM_DOC_FIN: array[0..12] of char;
     NUM_AUT    : array[0..60] of char;
end;

type Bloco1Registro1710 = record
     NUM_DOC_INI : array[0..12] of char;
     NUM_DOC_FIN : array[0..12] of char;
end;

type Bloco1Registro1800 = record
     VL_CARGA          : Double;
     VL_PASS           : Double;
     VL_FAT            : Double;
     IND_RAT           : Double;
     VL_ICMS_ANT       : Double;
     VL_BC_ICMS        : Double;
     VL_ICMS_APUR      : Double;
     VL_BC_ICMS_APUR   : Double;
     VL_DIF            : Double;
end;

{%endregion Registros Bloco 1}

{%region Registros Bloco 9}

type Bloco9Registro9001 = record
   IND_MOV    : Integer;
end;

type Bloco9Registro9900 = record
REG_BLC     : array[0..4] of char;
QTD_REG_BLC : Integer;
end;

{%endregion Registros Bloco 9}

{%region Registros Bloco C}

type BlocoCRegistroC001 = record
   IND_MOV    : Integer;
end;

type BlocoCRegistroC100 = record
 IND_OPER               : Integer;
 IND_EMIT               : Integer;
 COD_PART               : array[0..60] of char;
 COD_MOD                : array[0..2] of char;
 COD_SIT                : Integer;
 SER                    : array[0..3] of char;
 NUM_DOC                : array[0..9] of char;
 CHV_NFE                : array[0..44] of char;
 DT_DOC                 : Double;
 DT_E_S                 : Double;
 VL_DOC                 : Double;
 IND_PGTO               : Integer;
 VL_DESC                : Double;
 VL_ABAT_NT             : Double;
 VL_MERC                : Double;
 IND_FRT                : Integer;
 VL_FRT                 : Double;
 VL_SEG                 : Double;
 VL_OUT_DA              : Double;
 VL_BC_ICMS             : Double;
 VL_ICMS                : Double;
 VL_BC_ICMS_ST          : Double;
 VL_ICMS_ST             : Double;
 VL_IPI                 : Double;
 VL_PIS                 : Double;
 VL_COFINS              : Double;
 VL_PIS_ST              : Double;
 VL_COFINS_ST           : Double;
end;

type BlocoCRegistroC110 = record
 COD_INF                : array[0..6] of char;
 TXT_COMPL              : array[0..1023] of char;
end;

type BlocoCRegistroC105 = record
 OPER                   : Integer;
 UF                     : array[0..2] of char;
end;

type BlocoCRegistroC111 = record
  NUM_PROC              : array[0..15] of char;
  IND_PROC              : Integer;
end;

type BlocoCRegistroC112 = record
  COD_DA                : Integer;
  UF                    : array[0..2] of char;
  NUM_DA                : array[0..60] of char;
  COD_AUT               : array[0..60] of char;
  VL_DA                 : Double;
  DT_VCTO               : Double;
  DT_PGTO               : Double;
end;

type BlocoCRegistroC113 = record
  IND_OPER              : Integer;
  IND_EMIT              : Integer;
  COD_PART              : array[0..60] of char;
  COD_MOD               : array[0..2] of char;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  NUM_DOC               : array[0..9] of char;
  DT_DOC                : Double;
end;

type BlocoCRegistroC114 = record
  COD_MOD               : array[0..2] of char;
  ECF_FAB               : array[0..20] of char;
  ECF_CX                : array[0..3] of char;
  NUM_DOC               : array[0..6] of char;
  DT_DOC                : Double;
end;

type BlocoCRegistroC115 = record
  IND_CARGA             : Integer;
  CNPJ_COL              : array[0..14] of char;
  IE_COL                : array[0..14] of char;
  CPF_COL               : array[0..11] of char;
  COD_MUN_COL           : array[0..7] of char;
  CNPJ_ENTG             : array[0..14] of char;
  IE_ENTG               : array[0..14] of char;
  CPF_ENTG              : array[0..11] of char;
  COD_MUN_ENTG          : array[0..7] of char;
end;

type BlocoCRegistroC116 = record
  COD_MOD               : array[0..2] of char;
  NR_SAT                : array[0..9] of char;
  CHV_CFE               : array[0..44] of char;
  NUM_CFE               : array[0..6] of char;
  DT_DOC                : Double;
end;

type BlocoCRegistroC120 = record
  COD_DOC_IMP           : Integer;
  NUM_DOC__IMP          : array[0..10] of char;
  PIS_IMP               : Double;
  COFINS_IMP            : Double;
  NUM_ACDRAW            : array[0..20] of char;
end;

type BlocoCRegistroC130 = record
  VL_SERV_NT            : Double;
  VL_BC_ISSQN           : Double;
  VL_ISSQN              : Double;
  VL_BC_IRRF            : Double;
  VL_IRRF               : Double;
  VL_BC_PREV            : Double;
  VL_PREV               : Double;
end;

type BlocoCRegistroC140 = record
  IND_EMIT              : Integer;
  IND_TIT               : Integer;
  DESC_TIT              : array[0..254] of char;
  NUM_TIT               : array[0..60] of char;
  QTD_PARC              : Integer;
  VL_TIT                : Double;
end;

type BlocoCRegistroC141 = record
  NUM_PARC              : array[0..2] of char;
  DT_VCTO               : Double;
  VL_PARC               : Double;
end;

type BlocoCRegistroC160 = record
  COD_PART              : array[0..60] of char;
  VEIC_ID               : array[0..7] of char;
  QTD_VOL               : Integer;
  PESO_BRT              : Double;
  PESO_LIQ              : Double;
  UF_ID                 : array[0..2] of char;
end;

type BlocoCRegistroC165 = record
  COD_PART              : array[0..60] of char;
  VEIC_ID               : array[0..7] of char;
  COD_AUT               : array[0..60] of char;
  NR_PASSE              : array[0..60] of char;
  HORA                  : array[0..6] of char;
  TEMPER                : array[0..60] of char;
  QTD_VOL               : Integer;
  PESO_BRT              : Double;
  PESO_LIQ              : Double;
  NOM_MOT               : array[0..60] of char;
  CPF                   : array[0..11] of char;
  UF_ID                 : array[0..2] of char;
end;

type BlocoCRegistroC170 = record
  NUM_ITEM              : array[0..3] of char;
  COD_ITEM              : array[0..60] of char;
  DESCR_COMPL           : array[0..254] of char;
  QTD                   : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  VL_DESC               : Double;
  IND_MOV               : Integer;
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  COD_NAT               : array[0..10] of char;
  VL_BC_ICMS            : Double;
  ALIQ_ICMS             : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  ALIQ_ST               : Double;
  VL_ICMS_ST            : Double;
  IND_APUR              : Integer;
  CST_IPI               : array[0..2] of char;
  COD_ENQ               : array[0..3] of char;
  VL_BC_IPI             : Double;
  ALIQ_IPI              : Double;
  VL_IPI                : Double;
  CST_PIS               : array[0..2] of char;
  VL_BC_PIS             : Double;
  ALIQ_PIS_PERC         : Double;
  QUANT_BC_PIS          : Double;
  ALIQ_PIS_R            : Double;
  VL_PIS                : Double;
  CST_COFINS            : array[0..2] of char;
  VL_BC_COFINS          : Double;
  ALIQ_COFINS_PERC      : Double;
  QUANT_BC_COFINS       : Double;
  ALIQ_COFINS_R         : Double;
  VL_COFINS             : Double;
  COD_CTA               : array[0..60] of char;
end;

type BlocoCRegistroC171 = record
  NUM_TANQUE            : array[0..3] of char;
  QTDE                  : Double;
end;

type BlocoCRegistroC172 = record
  VL_BC_ISSQN           : Double;
  ALIQ_ISSQN            : Double;
  VL_ISSQN              : Double;
end;

type BlocoCRegistroC173 = record
  LOTE_MED              : array[0..60] of char;
  QTD_ITEM              : Double;
  DT_FAB                : Double;
  DT_VAL                : Double;
  IND_MED               : Integer;
  TP_PROD               : Integer;
  VL_TAB_MAX            : Double;
end;

type BlocoCRegistroC174 = record
   IND_ARM              : Integer;
   NUM_ARM              : array[0..60] of char;
   DESCR_COMPL          : array[0..254] of char;
end;

type BlocoCRegistroC175 = record
  IND_VEIC_OPER         : Integer;
  CNPJ                  : array[0..14] of char;
  UF                    : array[0..2] of char;
  CHASSI_VEIC           : array[0..17] of char;
end;

type BlocoCRegistroC176 = record
  COD_MOD_ULT_E         : array[0..2] of char;
  NUM_DOC_ULT_E         : array[0..9] of char;
  SER_ULT_E             : array[0..3] of char;
  DT_ULT_E              : Double;
  COD_PART_ULT_E        : array[0..60] of char;
  QUANT_ULT_E           : Double;
  VL_UNIT_ULT_E         : Double;
  VL_UNIT_BC_ST         : Double;
end;

type BlocoCRegistroC177 = record
  COD_SELO_IPI          : array[0..6] of char;
  QT_SELO_IPI           : Double;
end;

type BlocoCRegistroC178 = record
  CL_ENQ                : array[0..5] of char;
  VL_UNID               : Double;
  QUANT_PAD             : Double;
end;

type BlocoCRegistroC179 = record
  BC_ST_ORIG_DEST       : Double;
  ICMS_ST_REP           : Double;
  ICMS_ST_COMPL         : Double;
  BC_RET                : Double;
  ICMS_RET              : Double;
end;

type BlocoCRegistroC190 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  VL_RED_BC             : Double;
  VL_IPI                : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC195 = record
 COD_OBS                : array[0..6] of char;
 TXT_COMPL              : array[0..1023] of char;
end;

type BlocoCRegistroC197 = record
  COD_AJ                : array[0..10] of char;
  DESCR_COMPL_AJ        : array[0..254] of char;
  COD_ITEM              : array[0..60] of char;
  VL_BC_ICMS            : Double;
  ALIQ_ICMS             : Double;
  VL_ICMS               : Double;
  VL_OUTROS             : Double;
end;

type BlocoCRegistroC300 = record
  COD_MOD               : array[0..2] of char;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  NUM_DOC_INI           : array[0..6] of char;
  NUM_DOC_FIN           : array[0..6] of char;
  DT_DOC                : Double;
  VL_DOC                : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
  COD_CTA               : array[0..60] of char;
end;

type BlocoCRegistroC310 = record
  NUM_DOC_CANC          : array[0..60] of char;
end;

type BlocoCRegistroC320 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_RED_BC             : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC321 = record
  COD_ITEM              : array[0..60] of char;
  QTD                   : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  VL_DESC               : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
end;

type BlocoCRegistroC350 = record
  SER                   : array[0..3] of char;
  SUB_SER               : array[0..3] of char;
  NUM_DOC               : array[0..6] of char;
  DT_DOC                : Double;
  CNPJ_CPF              : array[0..14] of char;
  VL_MERC               : Double;
  VL_DOC                : Double;
  VL_DESC               : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
  COD_CTA               : array[0..60] of char;
end;

type BlocoCRegistroC370 = record
  NUM_ITEM              : array[0..3] of char;
  COD_ITEM              : array[0..60] of char;
  QTD                   : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  VL_DESC               : Double;
end;

type BlocoCRegistroC390 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_RED_BC             : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC400 = record
  COD_MOD               : array[0..2] of char;
  ECF_MOD               : array[0..20] of char;
  ECF_FAB               : array[0..20] of char;
  ECF_CX                : array[0..3] of char;
end;

type BlocoCRegistroC405 = record
  DT_DOC                : Double;
  CRO                   : integer;
  CRZ                   : integer;
  NUM_COO_FIN           : integer;
  GT_FIN                : Double;
  VL_BRT                : Double;
end;

type BlocoCRegistroC410 = record
   VL_PIS               : Double;
   VL_COFINS            : Double;
end;

type BlocoCRegistroC420 = record
  COD_TOT_PAR           : array[0..7] of char;
  VLR_ACUM_TOT          : Double;
  NR_TOT                : integer;
  DESCR_NR_TOT          : array[0..254] of char;
end;

type BlocoCRegistroC425 = record
  COD_ITEM              : array[0..60] of char;
  QTD                   : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
end;

type BlocoCRegistroC460 = record
  COD_MOD               : array[0..6] of char;
  COD_SIT               : Integer;
  NUM_DOC               : array[0..14] of char;
  DT_DOC                : Double;
  VL_DOC                : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
  CPF_CNPJ              : array[0..14] of char;
  NOM_ADQ               : array[0..60] of char;
end;

type BlocoCRegistroC470 = record
  COD_ITEM              : array[0..60] of char;
  QTD                   : Double;
  QTD_CANC              : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
end;

type BlocoCRegistroC490 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC495 = record
  ALIQ_ICMS             : Double;
  COD_ITEM              : array[0..60] of char;
  QTD                   : Double;
  QTD_CANC              : Double;
  UNID                  : array[0..6] of char;
  VL_ITEM               : Double;
  VL_DESC               : Double;
  VL_CANC               : Double;
  VL_ACMO               : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_ISEN               : Double;
  VL_NT                 : Double;
  VL_ICMS_ST            : Double;
end;

type BlocoCRegistroC500 = record
  IND_OPER              : Integer;
  IND_EMIT              : Integer;
  COD_PART              : array[0..60] of char;
  COD_MOD               : array[0..2] of char;
  COD_SIT               : Integer;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  COD_CONS              : array[0..2] of char;
  NUM_DOC               : array[0..9] of char;
  DT_DOC                : Double;
  DT_E_S                : Double;
  VL_DOC                : Double;
  VL_DESC               : Double;
  VL_FORN               : Double;
  VL_SERV_NT            : Double;
  VL_TERC               : Double;
  VL_DA                 : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  COD_INF               : array[0..6] of char;
  VL_PIS                : Double;
  VL_COFINS             : Double;
  TP_LIGACAO            : Integer;
  COD_GRUPO_TENSAO      : Integer;
end;

type BlocoCRegistroC510 = record
   NUM_ITEM             : array[0..3] of char;
   COD_ITEM             : array[0..60] of char;
   COD_CLASS            : array[0..4] of char;
   QTD                  : Double;
   UNID                 : array[0..6] of char;
   VL_ITEM              : Double;
   VL_DESC              : Double;
   CST_ICMS             : array[0..3] of char;
   CFOP                 : array[0..4] of char;
   VL_BC_ICMS           : Double;
   ALIQ_ICMS            : Double;
   VL_ICMS              : Double;
   VL_BC_ICMS_ST        : Double;
   ALIQ_ST              : Double;
   VL_ICMS_ST           : Double;
   IND_REC              : Integer;
   COD_PART             : array[0..60] of char;
   VL_PIS               : Double;
   VL_COFINS            : Double;
   COD_CTA              : array[0..60] of char;
end;

type BlocoCRegistroC590 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  VL_RED_BC             : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC600 = record
  COD_MOD               : array[0..2] of char;
  COD_MUN               : array[0..7] of char;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  COD_CONS              : array[0..2] of char;
  QTD_CONS              : Double;
  QTD_CANC              : Double;
  DT_DOC                : Double;
  VL_DOC                : Double;
  VL_DESC               : Double;
  CONS                  : Double;
  VL_FORN               : Double;
  VL_SERV_NT            : Double;
  VL_TERC               : Double;
  VL_DA                 : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
end;

type BlocoCRegistroC601 = record
  NUM_DOC_CANC          : array[0..9] of char;
end;

type BlocoCRegistroC610 = record
  COD_CLASS            : array[0..4] of char;
  COD_ITEM             : array[0..60] of char;
  QTD                  : Double;
  UNID                 : array[0..6] of char;
  VL_ITEM              : Double;
  VL_DESC              : Double;
  CST_ICMS             : array[0..3] of char;
  CFOP                 : array[0..4] of char;
  ALIQ_ICMS            : Double;
  VL_BC_ICMS           : Double;
  VL_ICMS              : Double;
  VL_BC_ICMS_ST        : Double;
  VL_ICMS_ST           : Double;
  VL_PIS               : Double;
  VL_COFINS            : Double;
  COD_CTA              : array[0..60] of char;
end;

type BlocoCRegistroC690 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_RED_BC             : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC700 = record
  COD_MOD              : array[0..2] of char;
  SER                  : array[0..4] of char;
  NRO_ORD_INI          : integer;
  NRO_ORD_FIN          : integer;
  DT_DOC_INI           : Double;
  DT_DOC_FIN           : Double;
  NOM_MEST             : array[0..15] of char;
  CHV_COD_DIG          : array[0..32] of char;
end;

type BlocoCRegistroC790 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_BC_ICMS_ST         : Double;
  VL_ICMS_ST            : Double;
  VL_RED_BC             : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC791 = record
   UF                   : array[0..2] of char;
   VL_BC_ICMS_ST        : Double;
   VL_ICMS_ST           : Double;
end;

type BlocoCRegistroC800 = record
  COD_MOD               : array[0..2] of char;
  COD_SIT               : Integer;
  NUM_CFE               : array[0..6] of char;
  DT_DOC                : Double;
  VL_CFE                : Double;
  VL_PIS                : Double;
  VL_COFINS             : Double;
  CNPJ_CPF              : array[0..14] of char;
  NR_SAT                : array[0..9] of char;
  CHV_CFE               : array[0..44] of char;
  VL_DESC               : Double;
  VL_MERC               : Double;
  VL_OUT_DA             : Double;
  VL_ICMS               : Double;
  VL_PIS_ST             : Double;
  VL_COFINS_ST          : Double;
end;

type BlocoCRegistroC850 = record
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  VL_OPR                : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  COD_OBS               : array[0..6] of char;
end;

type BlocoCRegistroC860 = record
  COD_MOD               : array[0..2] of char;
  NR_SAT                : array[0..9] of char;
  DT_DOC                : Double;
  DOC_INI               : array[0..6] of char;
  DOC_FIN               : array[0..6] of char;
end;

type BlocoCRegistroC890 = record
  CST_ICMS                : array[0..3] of char;
  CFOP                    : array[0..4] of char;
  ALIQ_ICMS               : currency;
  VL_OPR                  : currency;
  VL_BC_ICMS              : currency;
  VL_ICMS                 : currency;
  COD_OBS                 : array[0..6] of char;
end;


{%endregion Registros Bloco C}

{%region Registro Bloco D}

type BlocoDRegistroD001 = record
   IND_MOV    : Integer;
end;

type BlocoDRegistroD100 = record
  IND_OPER              : Integer;
  IND_EMIT              : Integer;
  COD_PART              : array[0..60] of char;
  COD_MOD               : array[0..2] of char;
  COD_SIT               : Integer;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  NUM_DOC               : array[0..9] of char;
  CHV_CTE               : array[0..44] of char;
  DT_DOC                : Double;
  DT_A_P                : Double;
  TP_CT_e               : array[0..1] of char;
  CHV_CTE_REF           : array[0..44] of char;
  VL_DOC                : Double;
  VL_DESC               : Double;
  IND_FRT               : Integer;
  VL_SERV               : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_NT                 : Double;
  COD_INF               : array[0..6] of char;
  COD_CTA               : array[0..60] of char;
end;

type BlocoDRegistroD110 = record
  COD_ITEM              : array[0..60] of char;
  NUN_ITEM              : integer;
  VL_SERV               : Double;
  VL_OUT                : Double;
end;

type BlocoDRegistroD120 = record
  COD_MUN_ORIG          :array[0..7] of char;
  COD_MUN_DEST          :array[0..7] of char;
  VEIC_ID               :array[0..7] of char;
  UF_ID                 :array[0..2] of char;
end;

type BlocoDRegistroD130 = record
  COD_PART_CONSG        : array[0..60] of char;
  COD_PART_RED          : array[0..60] of char;
  IND_FRT_RED           : integer;
  COD_MUN_ORIG          : array[0..7] of char;
  COD_MUN_DEST          : array[0..7] of char;
  VEIC_ID               : array[0..7] of char;
  VL_LIQ_FRT            : Double;
  VL_SEC_CAT            : Double;
  VL_DESP               : Double;
  VL_PEDG               : Double;
  VL_OUT                : Double;
  VL_FRT                : Double;
  UF_ID                 : array[0..2] of char;
end;

type BlocoDRegistroD140 = record
  COD_PART_CONSG        : array[0..60] of char;
  COD_MUN_ORIG          : array[0..7] of char;
  COD_MUN_DEST          : array[0..7] of char;
  IND_VEIC              : array[0..1] of char;
  VEIC_ID               : Integer;
  IND_NAV               : Integer;
  VIAGEM                : array[0..60] of char;
  VL_FRT_LIQ            : Double;
  VL_DESP_PORT          : Double;
  VL_DESP_CAR_DESC      : Double;
  VL_OUT                : Double;
  VL_FRT_BRT            : Double;
  VL_FRT_MM             : Double;
end;

type BlocoDRegistroD150 = record
  COD_MUN_ORIG          : array[0..7] of char;
  COD_MUN_DEST          : array[0..7] of char;
  VEIC_ID               : array[0..60] of char;
  VIAGEM                : array[0..60] of char;
  IND_TFA               : Integer;
  VL_PESO_TX            : Double;
  VL_TX_TERR            : Double;
  VL_TX_RED             : Double;
  VL_OUT                : Double;
  VL_TX_ADV             : Double;
end;

type BlocoDRegistroD160 = record
  DESPACHO              : array[0..60] of char;
  CNPJ_CPF_REM          : array[0..14] of char;
  IE_REM                : array[0..14] of char;
  COD_MUN_ORI           : array[0..7] of char;
  CNPJ_CPF_DEST         : array[0..14] of char;
  IE_DEST               : array[0..14] of char;
  COD_MUN_DEST          : array[0..7] of char;
end;

type BlocoDRegistroD161 = record
  IND_CARGA             : Integer;
  CNPJ_COL              : array[0..14] of char;
  IE_COL                : array[0..14] of char;
  COD_MUN_COL           : array[0..7] of char;
  CNPJ_ENTG             : array[0..14] of char;
  IE_ENTG               : array[0..14] of char;
  COD_MUN_ENTG          : array[0..7] of char;
end;

type BlocoDRegistroD162 = record
  COD_MOD               : array[0..2] of char;
  SER                   : array[0..4] of char;
  NUM_DOC               : array[0..9] of char;
  DT_DOC                : Double;
  VL_DOC                : Double;
  VL_MERC               : Double;
  QTD_VOL               : Integer;
  PESO_BRT              : Double;
  PESO_LIQ              : Double;
end;

type BlocoDRegistroD170 = record
  COD_PART_CONSG        : array[0..60] of char;
  COD_PART_RED          : array[0..60] of char;
  COD_MUN_ORIG          : array[0..7] of char;
  COD_MUN_DEST          : array[0..7] of char;
  OTM                   : array[0..60] of char;
  IND_NAT_FRT           : Integer;
  VL_LIQ_FRT            : Double;
  VL_GRIS               : Double;
  VL_PDG                : Double;
  VL_OUT                : Double;
  VL_FRT                : Double;
  VEIC_ID               : array[0..7] of char;
  UF_ID                 : array[0..2] of char;
end;

type BlocoDRegistroD180 = record
  NUM_SEQ               : array[0..60] of char;
  IND_EMIT              : Integer;
  CNPJ_EMIT             : array[0..14] of char;
  UF_EMIT               : array[0..2] of char;
  IE_EMIT               : array[0..14] of char;
  COD_MUN_ORIG          : array[0..7] of char;
  CNPJ_CPF_TOM          : array[0..14] of char;
  UF_TOM                : array[0..2] of char;
  IE_TOM                : array[0..14] of char;
  COD_MUN_DEST          : array[0..7] of char;
  COD_MOD               : array[0..2] of char;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  NUM_DOC               : array[0..9] of char;
  DT_DOC                : Double;
  VL_DOC                : Double;
end;

type BlocoDRegistroD190 = record
   CST_ICMS             : array[0..3] of char;
   CFOP                 : array[0..4] of char;
   ALIQ_ICMS            : Double;
   VL_OPR               : Double;
   VL_BC_ICMS           : Double;
   VL_ICMS              : Double;
   VL_RED_BC            : Double;
   COD_OBS              : array[0..6] of char;
end;

type BlocoDRegistroD195 = record
  COD_OBS               : array[0..6] of char;
  TXT_COMPL             : array[0..1023] of char;
end;

type BlocoDRegistroD197 = record
  COD_AJ               : array[0..10] of char;
  DESCR_COMPL_AJ       : array[0..254] of char;
  COD_ITEM             : array[0..60] of char;
  VL_BC_ICMS           : Double;
  ALIQ_ICMS            : Double;
  VL_ICMS              : Double;
  VL_OUTROS            : Double;
end;

type BlocoDRegistroD300 = record
  COD_MOD               : array[0..2] of char;
  SER                   : array[0..4] of char;
  SUB                   : array[0..3] of char;
  NUM_DOC_INI           : array[0..6] of char;
  NUM_DOC_FIN           : array[0..6] of char;
  CST_ICMS              : array[0..3] of char;
  CFOP                  : array[0..4] of char;
  ALIQ_ICMS             : Double;
  DT_DOC                : Double;
  VL_OPR                : Double;
  VL_DESC               : Double;
  VL_SERV               : Double;
  VL_SEG                : Double;
  VL_OUT_DESP           : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
  VL_RED_BC             : Double;
  COD_OBS               : array[0..6] of char;
  COD_CTA               : array[0..60] of char;
end;

type BlocoDRegistroD301 = record
  NUM_DOC_CANC          : array[0..60] of char;
end;

type BlocoDRegistroD310 = record
  COD_MUN_ORIG          : array[0..7] of char;
  VL_SERV               : Double;
  VL_BC_ICMS            : Double;
  VL_ICMS               : Double;
end;

type BlocoDRegistroD350 = record
  COD_MOD               : array[0..2] of char;
  ECF_MOD               : array[0..20] of char;
  ECF_FAB               : array[0..20] of char;
  ECF_CX                : array[0..3] of char;
end;

type BlocoDRegistroD355 = record
  DT_DOC                : Double;
  CRO                   : integer;
  CRZ                   : integer;
  NUM_COO_FIN           : integer;
  GT_FIN                : Double;
  VL_BRT                : Double;
end;

type BlocoDRegistroD360 = record
  VL_PIS               : Double;
  VL_COFINS            : Double;
end;

type BlocoDRegistroD365 = record
  COD_TOT_PAR           : array[0..7] of char;
  VLR_ACUM_TOT          : Double;
  NR_TOT                : array[0..2] of char;
  DESCR_NR_TOT          : array[0..254] of char;
end;

type BlocoDRegistroD370 = record
   COD_MUN_ORIG         : array[0..7] of char;
   VL_SERV              : Double;
   QTD_BILH             : Double;
   VL_BC_ICMS           : Double;
   VL_ICMS              : Double;
end;



{%endregion Registro Bloco D}

implementation

end.

