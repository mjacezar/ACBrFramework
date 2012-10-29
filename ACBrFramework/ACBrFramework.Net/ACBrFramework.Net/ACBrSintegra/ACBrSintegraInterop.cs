using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework
{
	public static class ACBrSintegraInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrSintegra

		#region Interop Types

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro10Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
			public string RazaoSocial;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string Cidade;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Estado;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string Telefone;

			[MarshalAs(UnmanagedType.R8)]
			public double DataInicial;

			[MarshalAs(UnmanagedType.R8)]
			public double DataFinal;

			[MarshalAs(UnmanagedType.I4)]
			public int CodigoConvenio;

			[MarshalAs(UnmanagedType.I4)]
			public int NaturezaInformacoes;

			[MarshalAs(UnmanagedType.I4)]
			public int FinalidadeArquivo;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro11Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 29)]
			public string Responsavel;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string Bairro;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string Cep;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string Numero;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 23)]
			public string Complemento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 35)]
			public string Endereco;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string Telefone;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro50Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Situacao;

			[MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

			[MarshalAs(UnmanagedType.R8)]
			public double Isentas;

			[MarshalAs(UnmanagedType.R8)]
			public double Icms;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorContabil;

			[MarshalAs(UnmanagedType.R8)]
			public double BasedeCalculo;

			[MarshalAs(UnmanagedType.R8)]
			public double Outras;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string EmissorDocumento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro51Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Estado;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorIpi;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorContabil;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Situacao;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorIsentas;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorOutras;
		}

       [StructLayout(LayoutKind.Sequential)]
		public struct Registro53Rec
       {
           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Estado;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

           [MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Situacao;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string CodigoAntecipacao;

           [MarshalAs(UnmanagedType.R8)]
			public double BaseST;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
           public string Emitente;

           [MarshalAs(UnmanagedType.R8)]
			public double Despesas;

           [MarshalAs(UnmanagedType.R8)]
			public double IcmsRetido;
       }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro54Rec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseST;

            [MarshalAs(UnmanagedType.R8)]
			public double BasedeCalculo;

            [MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorDescontoDespesa;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorIpi;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.I4)]
			public int NumeroItem;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 54)]
			public string Descricao;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct Registro55Rec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.I4)]
			public int Agencia;

            [MarshalAs(UnmanagedType.I4)]
			public int Banco;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string NumeroConvenio;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string MesAno;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Numero;

            [MarshalAs(UnmanagedType.R8)]
			public double DataPagamento;

            [MarshalAs(UnmanagedType.R8)]
			public double Vencimento;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro56Rec
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Cnpj;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Cst;

            [MarshalAs(UnmanagedType.I4)]
			public int NumeroItem;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string TipoOperacao;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CnpjConcessionaria;

            [MarshalAs(UnmanagedType.R8)]
			public double Ipi;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
			public string Chassi;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro60MRec
        {
            [MarshalAs(UnmanagedType.I4)]
			public int CRO;

            [MarshalAs(UnmanagedType.I4)]
			public int NumOrdem;

            [MarshalAs(UnmanagedType.R8)]
			public double VendaBruta;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string ModeloDoc;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorGT;

            [MarshalAs(UnmanagedType.I4)]
			public int CRZ;

            [MarshalAs(UnmanagedType.I4)]
			public int CooFinal;

            [MarshalAs(UnmanagedType.I4)]
			public int CooInicial;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NumSerie;

            [MarshalAs(UnmanagedType.R8)]
			public double Emissao;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro60ARec
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NumSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Aliquota;

            [MarshalAs(UnmanagedType.R8)]
			public double Emissao;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;
        }

        [StructLayout(LayoutKind.Sequential)]
		public struct Registro60DRec
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NumSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string StAliquota;

            [MarshalAs(UnmanagedType.R8)]
			public double Emissao;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorIcms;

            [MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro60IRec
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NumSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string StAliquota;

            [MarshalAs(UnmanagedType.R8)]
			public double Emissao;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorIcms;

            [MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;

            [MarshalAs(UnmanagedType.I4)]
			public int Item;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Cupom;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string ModeloDoc;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro60RRec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.R8)]
			public double Qtd;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string MesAno;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Aliquota;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro61Rec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double Emissao;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorIcms;

            [MarshalAs(UnmanagedType.R8)]
			public double Outras;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;

            [MarshalAs(UnmanagedType.R8)]
			public double Isentas;

            [MarshalAs(UnmanagedType.I4)]
			public int NumOrdemInicial;

            [MarshalAs(UnmanagedType.I4)]
			public int NumOrdemFinal;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SubSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

            [MarshalAs(UnmanagedType.R8)]
			public double Aliquota;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro61RRec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

            [MarshalAs(UnmanagedType.R8)]
			public double Valor;

            [MarshalAs(UnmanagedType.R8)]
			public double Qtd;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string MesAno;

           [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string  Codigo;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro70Rec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double Icms;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorContabil;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

            [MarshalAs(UnmanagedType.R8)]
			public double Isentas;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SubSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Serie;

            [MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Situacao;

            [MarshalAs(UnmanagedType.R8)]
			public double Outras;

            [MarshalAs(UnmanagedType.R8)]
			public double BasedeCalculo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string CifFobOutros;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro71Rec
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

            [MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Serie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SubSerie;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Numero;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UFNF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJNF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string InscricaoNF;

            [MarshalAs(UnmanagedType.R8)]
			public double DataNF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string ModeloNF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SerieNF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NumeroNF;

            [MarshalAs(UnmanagedType.R8)]
			public double ValorNF;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro74Rec
        {
            [MarshalAs(UnmanagedType.R8)]
			public double ValorProduto;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string CodigoPosse;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string InscricaoPossuidor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJPossuidor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UFPossuidor;

            [MarshalAs(UnmanagedType.R8)]
			public double Data;

            [MarshalAs(UnmanagedType.R8)]
			public double Quantidade;
        }
        
        /*
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro75Rec
        {
            Codigo       : array[0..14] of char;

            Descricao    : array[0..53] of char;

            [MarshalAs(UnmanagedType.R8)]
			public double Reducao      : Double;

            [MarshalAs(UnmanagedType.R8)]
			public double BaseST       : Double;

            [MarshalAs(UnmanagedType.R8)]
			public double AliquotaIpi  : Double;

            NCM          : array[0..8] of char;

            Unidade      : array[0..6] of char;

            [MarshalAs(UnmanagedType.R8)]
			public double AliquotaICMS : Double;

            [MarshalAs(UnmanagedType.R8)]
			public double DataFinal    : Double;

            [MarshalAs(UnmanagedType.R8)]
			public double DataInicial  : Double;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro76Rec
        {
            Isentas       : Double;
            ValorTotal    : Double;
            Icms          : Double;
            BasedeCalculo : Double;
            Outras        : Double;
            Modelo        : Integer;
            Numero        : Integer;
            Situacao      : array[0..1] of char;
            Inscricao     : array[0..14] of char;
            SubSerie      : array[0..2] of char;
            Uf            : array[0..2] of char;
            Serie         : array[0..2] of char;
            Cfop          : array[0..4] of char;
            CPFCNPJ       : array[0..14] of char;
            DataDocumento : Double;
            TipoReceita   : Integer;
            Aliquota      : Integer;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro77Rec
        {
            Quantidade     : Double;
            ValorServico   : Double;
            ValorDesconto  : Double;
            BaseDeCalculo  : Double;
            Modelo         : Integer;
            Numero         : Integer;
            NumeroTerminal : Integer;
            NumeroItem     : Integer;
            Aliquota       : Integer;
            CNPJMF         : array[0..14] of char;
            Cfop           : array[0..4] of char;
            Codigo         : array[0..11] of char;
            SubSerie       : array[0..2] of char;
            CPFCNPJ        : array[0..14] of char;
            Serie          : array[0..2] of char;
            TipoReceita    : Integer;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro85Rec
        {
            Declaracao         : array[0..11] of char;
            DataDeclaracao     : Double;
            NaturezaExportacao : array[0..1] of char;
            RegistroExportacao : array[0..12] of char;
            DataRegistro       : Double;
            Conhecimento       : array[0..16] of char;
            DataConhecimento   : Double;
            TipoConhecimento   : array[0..2] of char;
            Pais               : array[0..4] of char;
            DataAverbacao      : Double;
            NumeroNotaFiscal   : array[0..6] of char;
            DataNotaFiscal     : Double;
            Modelo             : array[0..2] of char;
            Serie              : array[0..3] of char;
        }
        
        [StructLayout(LayoutKind.Sequential)]
		public struct Registro86Rec
        {
            RegistroExportacao : array[0..12] of char;
            DataRegistro       : Double;
            CPFCNPJ            : array[0..14] of char;
            Inscricao          : array[0..14] of char;
            UF                 : array[0..2] of char;
            NumeroNotaFiscal   : array[0..6] of char;
            DataDocumento      : Double;
            Modelo             : array[0..2] of char;
            Serie              : array[0..3] of char;
            Codigo             : array[0..14] of char;
            Quantidade         : Double;
            ValorUnitario      : Double;
            ValorTotalProduto  : Double;
            Relacionamento     : array[0..1] of char;  
        }*/

		#endregion Interop Types

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_GetFileName(IntPtr sinHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_SetFileName(IntPtr sinHandle, string filename);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_GetVersaoValidador(IntPtr sinHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_SetVersaoValidador(IntPtr sinHandle, int Versao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_GetAtivo(IntPtr sinHandle);

		#endregion Propriedades do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Create(ref IntPtr sinHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Destroy(ref IntPtr sinHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_GetUltimoErro(IntPtr sinHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_LimparRegistros(IntPtr sinHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro10(IntPtr sinHandle, Registro10Rec registro10);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro11(IntPtr sinHandle, Registro11Rec registro11);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro50(IntPtr sinHandle, Registro50Rec[] registro50, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro51(IntPtr sinHandle, Registro51Rec[] registro51, int count);

		#endregion Methods

		#endregion ACBrSintegra
	}
}