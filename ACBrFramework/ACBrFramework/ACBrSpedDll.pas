unit ACBrSpedDll;

{$mode delphi}

interface

uses
  Classes, SysUtils;

{%region Registros Bloco 0}

type Registro0000 = record
  OD_VER     : Integer; /// Código da versão do leiaute: 100, 101, 102
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

type Registro0001 = record
  COD_FIN : Integer;
  QTD_15  : Integer;
  QTD_150 : Integer;
  QTD_190 : Integer;
  QTD_200 : Integer;
end;

type Registro0005 = record
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

type Registro0015 = record
  UF_ST : array[0..2] of char;   /// Sigla da unidade da federação:
  IE_ST : array[0..14] of char;   /// Inscrição Estadual:
end;

type Registro0100 = record
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

type Registro0150 = record
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
  Count0175 : integer;                    /// BLOCO C - Lista de Registro0175 (FILHO)
end;

type Registro0175 = record
  DT_ALT   : Double;                      /// Data de alteração do cadastro:
  NR_CAMPO : array[0..2] of char;         /// Número do campo alterado (Somente campos 03 a 13):
  CONT_ANT : array[0..100] of char;       /// Conteúdo anterior do campo:
end;

type Registro0190 = record
  UNID  : array[0..6] of char;        /// Código da unidade de medida:
  DESCR : array[0..100] of char;
end;

type Registro0200 = record
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

{%endregion}

implementation

end.

