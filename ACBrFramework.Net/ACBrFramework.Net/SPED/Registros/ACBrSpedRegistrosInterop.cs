using System.Runtime.InteropServices;

namespace ACBrFramework.SPED
{
	public static class ACBrSpedRegistrosInterop
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0000
		{
			[MarshalAs(UnmanagedType.I4)]
			public int OD_VER; /// Código da versão do leiaute: 100, 101, 102

			[MarshalAs(UnmanagedType.I4)]
			public int COD_FIN; /// Código da finalidade do arquivo: 0 - Remessa do arquivo original / 1 - Remessa do arquivo substituto.

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI;           /// Data inicial das informações contidas no arquivo

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN;           /// Data final das informações contidas no arquivo

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;                 /// Nome empresarial do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;               /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;                 /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;                  /// Sigla da unidade da federação:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;                  /// Inscrição Estadual do contribuinte:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;            /// Código do município do domicílio fiscal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM;                  /// Inscrição Municipal do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string SUFRAMA;             /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.I4)]
			public int IND_PERFIL;     /// Perfil de apresentação do arquivo fiscal: A - Perfil A / B - Perfil B / C - Perfil C

			[MarshalAs(UnmanagedType.I4)]
			public int IND_ATIV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int COD_FIN;

			[MarshalAs(UnmanagedType.I4)]
			public int QTD_15;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0005
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string FANTASIA;     /// Nome de fantasia associado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP;     /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;     /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;     /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;     /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;     /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;     /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;     /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;     /// Endereço do correio eletrônico:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0015
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ST;   /// Sigla da unidade da federação:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_ST;   /// Inscrição Estadual:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0100
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;       /// Nome do contabilista/escritório:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;        /// Número de inscrição no CPF:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string CRC;        /// Número de inscrição no Conselho Regional:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;        /// CNPJ do escritório de contabilidade, se houver:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP;         /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;        /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;        /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;        /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;        /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;        /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;        /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;       /// Endereço do correio eletrônico:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;                     /// Código do município, conforme tabela IBGE:
		}

        [StructLayout(LayoutKind.Sequential)]
        public struct Bloco0Registro0150
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;     /// Código de identificação do participante:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;         /// Nome pessoal ou empresarial:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string COD_PAIS;     /// Código do país do participante:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;         /// CNPJ do participante:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;          /// CPF do participante na unidade da federação do destinatário:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;           /// Inscrição Estadual do participante:
  
            [MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;         /// Código do município:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string SUFRAMA;      /// Número de inscrição na Suframa:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;     /// Logradouro e endereço do imóvel:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;          /// Número do imóvel:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;        /// Dados complementares do endereço:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;       /// Bairro em que o imóvel está situado:
  
            [MarshalAs(UnmanagedType.I4)]
			public int Count0175;       /// BLOCO C - Lista de Registro0175 (FILHO)    
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Bloco0Registro0175
        {
            [MarshalAs(UnmanagedType.R8)]
			public double DT_ALT;        /// Data de alteração do cadastro:
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string NR_CAMPO;      /// Número do campo alterado (Somente campos 03 a 13):
  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string CONT_ANT;      /// Conteúdo anterior do campo:   
        }

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0190
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;      /// Número do campo alterado (Somente campos 03 a 13):

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string DESCR;      /// Conteúdo anterior do campo:   
		}
	}
}