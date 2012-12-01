unit ACBrSpedDll;

{$mode delphi}

interface

uses
  Classes, SysUtils;

{%region Records estilo C utilizados nos retornos das funções}

type Bloco0Registro0000 = record
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

{%endregion}

implementation

end.

