using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.Sintegra
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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
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
			public string Codigo;

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

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro75Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 54)]
			public string Descricao;

			[MarshalAs(UnmanagedType.R8)]
			public double Reducao;

			[MarshalAs(UnmanagedType.R8)]
			public double BaseST;

			[MarshalAs(UnmanagedType.R8)]
			public double AliquotaIpi;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string NCM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string Unidade;

			[MarshalAs(UnmanagedType.R8)]
			public double AliquotaICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double DataFinal;

			[MarshalAs(UnmanagedType.R8)]
			public double DataInicial;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro76Rec
		{
			[MarshalAs(UnmanagedType.R8)]
			public double Isentas;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorTotal;

			[MarshalAs(UnmanagedType.R8)]
			public double Icms;

			[MarshalAs(UnmanagedType.R8)]
			public double BasedeCalculo;

			[MarshalAs(UnmanagedType.R8)]
			public double Outras;

			[MarshalAs(UnmanagedType.I4)]
			public int Modelo;

			[MarshalAs(UnmanagedType.I4)]
			public int Numero;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Situacao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Inscricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SubSerie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Uf;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Serie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

			[MarshalAs(UnmanagedType.I4)]
			public int TipoReceita;

			[MarshalAs(UnmanagedType.I4)]
			public int Aliquota;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro77Rec
		{
			[MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorServico;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorDesconto;

			[MarshalAs(UnmanagedType.R8)]
			public double BaseDeCalculo;

			[MarshalAs(UnmanagedType.I4)]
			public int Modelo;

			[MarshalAs(UnmanagedType.I4)]
			public int Numero;

			[MarshalAs(UnmanagedType.I4)]
			public int NumeroTerminal;

			[MarshalAs(UnmanagedType.I4)]
			public int NumeroItem;

			[MarshalAs(UnmanagedType.I4)]
			public int Aliquota;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJMF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Cfop;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string Codigo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SubSerie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Serie;

			[MarshalAs(UnmanagedType.I4)]
			public int TipoReceita;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro85Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string Declaracao;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDeclaracao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string NaturezaExportacao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string RegistroExportacao;

			[MarshalAs(UnmanagedType.R8)]
			public double DataRegistro;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
			public string Conhecimento;

			[MarshalAs(UnmanagedType.R8)]
			public double DataConhecimento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string TipoConhecimento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string Pais;

			[MarshalAs(UnmanagedType.R8)]
			public double DataAverbacao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NumeroNotaFiscal;

			[MarshalAs(UnmanagedType.R8)]
			public double DataNotaFiscal;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Registro86Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string RegistroExportacao;

			[MarshalAs(UnmanagedType.R8)]
			public double DataRegistro;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPFCNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Inscricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NumeroNotaFiscal;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDocumento;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Serie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

			[MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorUnitario;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorTotalProduto;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string Relacionamento;
		}

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
		public static extern int SIN_GeraArquivo(IntPtr sinHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro10(IntPtr sinHandle, Registro10Rec registro10);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro11(IntPtr sinHandle, Registro11Rec registro11);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro50(IntPtr sinHandle, Registro50Rec[] registro50, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro51(IntPtr sinHandle, Registro51Rec[] registro51, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro53(IntPtr sinHandle, Registro53Rec[] registro53, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro54(IntPtr sinHandle, Registro54Rec[] registro54, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro55(IntPtr sinHandle, Registro55Rec[] registro55, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro56(IntPtr sinHandle, Registro56Rec[] registro56, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro60A(IntPtr sinHandle, Registro60ARec[] registro60A, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro60D(IntPtr sinHandle, Registro60DRec[] registro60D, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro60I(IntPtr sinHandle, Registro60IRec[] registro60I, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro60M(IntPtr sinHandle, Registro60MRec[] registro60M, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro60R(IntPtr sinHandle, Registro60RRec[] registro60R, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro61(IntPtr sinHandle, Registro61Rec[] registro61, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro61R(IntPtr sinHandle, Registro61RRec[] registro61R, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro70(IntPtr sinHandle, Registro70Rec[] registro70, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro71(IntPtr sinHandle, Registro71Rec[] registro71, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro74(IntPtr sinHandle, Registro74Rec[] registro74, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro75(IntPtr sinHandle, Registro75Rec[] registro75, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro76(IntPtr sinHandle, Registro76Rec[] registro76, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro77(IntPtr sinHandle, Registro77Rec[] registro77, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro85(IntPtr sinHandle, Registro85Rec[] registro85, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SIN_Registro86(IntPtr sinHandle, Registro86Rec[] registr86, int count);

		#endregion Methods

		#endregion ACBrSintegra
	}
}