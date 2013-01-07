using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.ECF
{
	public static class ACBrECFInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrECF

		#region Interop Types

		#region Documentation

		/// <summary>
		/// Delegate com a assinatura do ponteiro de função utilizado no Interop
		/// </summary>

		#endregion Documentation

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void NoArgumentCallback();	

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AbreCupomCallback(string CPF_CNPJ, string Nome, string Endereco);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void IntArgumentCallback(int value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void BobinaAdicionaLinhasCallback(string linhas, string operacao);

		[StructLayout(LayoutKind.Sequential)]
		public struct AliquotaRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Indice;

			[MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

			[MarshalAs(UnmanagedType.U1)]
			public char Tipo;

			[MarshalAs(UnmanagedType.R8)]
			public double Total;

			[MarshalAs(UnmanagedType.U1)]
			public byte Sequencia;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DAVsRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string Numero;

			[MarshalAs(UnmanagedType.I4)]
			public int COO_Cupom;

			[MarshalAs(UnmanagedType.I4)]
			public int COO_Dav;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string Titulo;

			[MarshalAs(UnmanagedType.R8)]
			public double Valor;

			[MarshalAs(UnmanagedType.R8)]
			public double DtEmissao;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct FormaPagamentoRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Indice;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string Descricao;

			[MarshalAs(UnmanagedType.U1)]
			public bool PermiteVinculado;

			[MarshalAs(UnmanagedType.R8)]
			public double Total;

			[MarshalAs(UnmanagedType.R8)]
			public double Data;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string TipoDoc;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ComprovanteNaoFiscalRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Indice;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string Descricao;

			[MarshalAs(UnmanagedType.U1)]
			public bool PermiteVinculado;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string FormaPagamento;

			[MarshalAs(UnmanagedType.R8)]
			public double Total;

			[MarshalAs(UnmanagedType.I4)]
			public int Contador;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RelatorioGerencialRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Indice;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string Descricao;

			[MarshalAs(UnmanagedType.I4)]
			public int Contador;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DadosRZRec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.I4)]
			public int CFD;

			[MarshalAs(UnmanagedType.R8)]
			public double CancelamentoISSQN;

			[MarshalAs(UnmanagedType.I4)]
			public int GNFC;

			[MarshalAs(UnmanagedType.I4)]
			public int CRO;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorVendaBruta;

			public IntPtr TotalizadoresNaoFiscais;

			[MarshalAs(UnmanagedType.I4)]
			public int TotalizadoresNaoFiscaisLen;

			public IntPtr ICMS;

			[MarshalAs(UnmanagedType.I4)]
			public int ICMSLen;

			[MarshalAs(UnmanagedType.R8)]
			public double AcrescimoICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double DescontoICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double NaoTributadoICMS;

			public IntPtr RelatorioGerencial;

			[MarshalAs(UnmanagedType.I4)]
			public int RelatorioGerencialLen;

			[MarshalAs(UnmanagedType.I4)]
			public int CRZ;

			public IntPtr ISSQN;

			[MarshalAs(UnmanagedType.I4)]
			public int ISSQNLen;

			[MarshalAs(UnmanagedType.I4)]
			public int GRG;

			[MarshalAs(UnmanagedType.R8)]
			public double ValorGrandeTotal;

			[MarshalAs(UnmanagedType.R8)]
			public double AcrescimoISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double NaoTributadoISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double IsentoICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double SubstituicaoTributariaICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDaImpressora;

			[MarshalAs(UnmanagedType.R8)]
			public double TotalOperacaoNaoFiscal;

			[MarshalAs(UnmanagedType.R8)]
			public double DescontoISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double CancelamentoOPNF;

			[MarshalAs(UnmanagedType.R8)]
			public double AcrescimoOPNF;

			[MarshalAs(UnmanagedType.R8)]
			public double DescontoOPNF;

			[MarshalAs(UnmanagedType.R8)]
			public double CancelamentoICMS;

			[MarshalAs(UnmanagedType.I4)]
			public int GNF;

			[MarshalAs(UnmanagedType.R8)]
			public double IsentoISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double SubstituicaoTributariaISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double VendaLiquida;

			[MarshalAs(UnmanagedType.I4)]
			public int CFC;

			[MarshalAs(UnmanagedType.I4)]
			public int CCF;

			[MarshalAs(UnmanagedType.R8)]
			public double TotalISSQN;

			[MarshalAs(UnmanagedType.R8)]
			public double TotalICMS;

			[MarshalAs(UnmanagedType.I4)]
			public int CDC;

			[MarshalAs(UnmanagedType.I4)]
			public int CCDC;

			[MarshalAs(UnmanagedType.I4)]
			public int NCN;

			[MarshalAs(UnmanagedType.R8)]
			public double DataDoMovimento;

			public IntPtr MeiosDePagamento;

			[MarshalAs(UnmanagedType.I4)]
			public int MeiosDePagamentoLen;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroCOOInicial;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroDoECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroDeSerie;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroDeSerieMFD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroDaLoja;

			[MarshalAs(UnmanagedType.R8)]
			public double TotalTroco;
		}

		#endregion Interop Types

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Create(ref IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Destroy(ref IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetUltimoErro(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Ativar/Desativar

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Ativar(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Desativar(IntPtr ecfHandle);

		#endregion Ativar/Desativar

		#region Métodos ECF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AcharECF(IntPtr ecfHandle, bool Modelo, bool Porta, int TimeOut);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AcharPorta(IntPtr ecfHandle, int TimeOut);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_MudaHorarioVerao(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Sangria(IntPtr ecfHandle, double valor, string obs);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Suprimento(IntPtr ecfHandle, double valor, string obs);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreGaveta(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CorrigeEstadoErro(IntPtr ecfHandle, bool reducaoZ);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PreparaTEF(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_TestaPodeAbrirCupom(IntPtr ecfHandle);

		#endregion Métodos ECF

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetAbout(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetModelo(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetModelo(IntPtr ecfHandle, int modelo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetArqLOG(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetArqLOG(IntPtr ecfHandle, string arqLog);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetMaxLinhasBuffer(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetMaxLinhasBuffer(IntPtr ecfHandle, int maxLinhas);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetAtivo(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetColunas(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetAguardandoResposta(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetComandoEnviado(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetRespostaComando(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetComandoLOG(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetComandoLOG(IntPtr ecfHandle, string comandoLog);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetAguardaImpressao(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetAguardaImpressao(IntPtr ecfHandle, bool aguardaImpressao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetArredondaPorQtd(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetArredondaPorQtd(IntPtr ecfHandle, bool arredonda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetArredondaItemMFD(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetArredondaItemMFD(IntPtr ecfHandle, bool arredonda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetIgnorarTagsFormatacao(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetIgnorarTagsFormatacao(IntPtr ecfHandle, bool ignorar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetPaginaDeCodigo(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetPaginaDeCodigo(IntPtr ecfHandle, int pagina);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetModeloStr(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetRFDID(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDataHora(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCupom(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCOO(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumLoja(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumECF(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumSerie(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumVersao(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDataMovimento(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDataHoraSB(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetCNPJ(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetIE(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetIM(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetCliche(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetUsuarioAtual(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetSubModeloECF(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetPAF(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCRZ(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCRO(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCCF(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumGNF(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumGRG(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCDC(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumCOOInicial(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetVendaBruta(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetGrandeTotal(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalCancelamentos(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalDescontos(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalAcrescimos(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalTroco(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalSubstituicaoTributaria(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalNaoTributado(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalIsencao(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalCancelamentosISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalDescontosISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalAcrescimosISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalSubstituicaoTributariaISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalNaoTributadoISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalIsencaoISSQN(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalNaoFiscal(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetNumUltItem(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetEmLinha(IntPtr ecfHandle, int timeOut);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetPoucoPapel(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetEstado(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetHorarioVerao(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetArredonda(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTermica(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetMFD(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetMFAdicional(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetIdentificaConsumidorRodape(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetSubTotal(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetTotalPago(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetGavetaAberta(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetChequePronto(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetIntervaloAposComando(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetIntervaloAposComando(IntPtr ecfHandle, int intervalo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDescricaoGrande(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetDescricaoGrande(IntPtr ecfHandle, bool descricaoGrande);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetGavetaSinalInvertido(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetGavetaSinalInvertido(IntPtr ecfHandle, bool gavetaSinalInvertido);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetOperador(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOperador(IntPtr ecfHandle, string operador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetMemoParams(IntPtr ecfHandle, string[] linhas, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetMemoParams(IntPtr ecfHandle, StringBuilder linha, int bufferLen, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetMemoParamsLineCount(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetLinhasEntreCupons(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetLinhasEntreCupons(IntPtr ecfHandle, int linhasEntreCupons);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDecimaisPreco(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetDecimaisPreco(IntPtr ecfHandle, int decimaisPreco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDecimaisQtd(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetDecimaisQtd(IntPtr ecfHandle, int decimaisQtd);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDadosReducaoZ(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDadosUltimaReducaoZ(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetDadosReducaoZClass(IntPtr ecfHandle, out IntPtr dadosRZ);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DestroyDadosReducaoZClass(IntPtr ecfHandle, ref IntPtr dadosRZ);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetAAC(IntPtr ecfHandle, IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetEAD(IntPtr ecfHandle, IntPtr eadHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetRFD(IntPtr ecfHandle, IntPtr rfdHandle);

		#endregion Propriedades do Componente

		#region InfoRodapeCupom

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetMD5(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetMD5(IntPtr ecfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetDav(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetDav(IntPtr ecfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetDavOs(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetDavOs(IntPtr ecfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetPreVenda(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetPreVenda(IntPtr ecfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetCupomMania(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetCupomMania(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetMinasLegal(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetMinasLegal(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_GetParaibaLegal(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_SetParaibaLegal(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS(IntPtr ecfHandle, double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS(IntPtr ecfHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS(IntPtr ecfHandle, double value);

		#endregion InfoRodapeCupom

		#region Consumidor

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_GetDocumento(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_GetEndereco(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_GetNome(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_GetEnviado(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_SetEnviado(IntPtr ecfHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_GetAtribuido(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_AtribuiConsumidor(IntPtr ecfHandle, string CPF_CNPJ, string Nome, string Endereco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_Consumidor_Zera(IntPtr ecfHandle);

		#endregion Consumidor

		#region ConfigBarras

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_GetAltura(IntPtr ecfHandle, ref int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_SetAltura(IntPtr ecfHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_GetLarguraLinha(IntPtr ecfHandle, ref int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_SetLarguraLinha(IntPtr ecfHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_GetMostrarCodigo(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ConfigBarras_SetMostrarCodigo(IntPtr ecfHandle, bool value);

		#endregion ConfigBarras

		#region Cupom Fiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_IdentificaConsumidor(IntPtr ecfHandle, string cpfCnpj, string nome, string endereco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreCupom(IntPtr ecfHandle, string cpfCnpj, string nome, string endereco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LegendaInmetroProximoItem(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_VendeItem(IntPtr ecfHandle, string codigo, string descricao, string aliquotaICMS, double qtd, double valorUnitario, double descontoPorc, string unidade, string tipoDescontoAcrescimo, string descontoAcrescimo, int CodDepartamento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DescontoAcrescimoItemAnterior(IntPtr ecfHandle, double valorDescontoAcrescimo, string descontoAcrescimo, string TipoDescontoAcrescimo, int Item);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SubtotalizaCupom(IntPtr ecfHandle, double descontoAcrescimo, string mensagemRodape);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_EfetuaPagamento(IntPtr ecfHandle, string codFormaPagto, double valor, string observacao, bool imprimeVinculado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_EstornaPagamento(IntPtr ecfHandle, string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_FechaCupom(IntPtr ecfHandle, string observacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaCupom(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaItemVendido(IntPtr ecfHandle, int numItem);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaItemVendidoParcial(IntPtr ecfHandle, int numItem, double quantidade);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaDescontoAcrescimoItem(IntPtr ecfHandle, int numItem);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaDescontoAcrescimoSubTotal(IntPtr ecfHandle, char tipoAcrescimoDesconto);

		#endregion Cupom Fiscal

		#region DAV

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DAV_Abrir(IntPtr ecfHandle, double emissao, string decrdocumento, string numero, string situacao, string vendedor, string observacao, string cpfCnpj, string nome, string endereco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DAV_Fechar(IntPtr ecfHandle, string observacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DAV_RegistrarItem(IntPtr ecfHandle, string codigo, string descricao, string unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, bool cancelado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_RelDAVEmitidos(IntPtr ecfHandle, DAVsRec[] DAVs, int index, string TituloRelatorio, string IndiceRelatorio);

		#endregion DAV

		#region PAF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_RelMeiosPagamento(IntPtr ecfHandle, FormaPagamentoRec[] formasPagamento, int count, string TituloRelatorio, int IndiceRelatorio);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_RelIdentificacaoPafECF(IntPtr ecfHandle, IntPtr aacHandle, int IndiceRelatorio);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_RelParametrosConfiguracao(IntPtr ecfHandle, IntPtr aacHandle, int IndiceRelatorio);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_GerarCAT52(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LX_Impressao(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ArquivoMFD_DLL(IntPtr ecfHandle, double DaTaInicial, double DaTaFinal, string Arquivo, int[] Documentos, int QTD_DOC, int Finalidade);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ArquivoMFD_DLL_COO(IntPtr ecfHandle, int COOInicial, int COOFinal, string Arquivo, int[] Documentos, int QTD_DOC, int Finalidade, int TipoContador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_EspelhoMFD_DLL(IntPtr ecfHandle, double DaTaInicial, double DaTaFinal, string Arquivo, int[] Documentos, int QTD_DOC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_EspelhoMFD_DLL_COO(IntPtr ecfHandle, int COOInicial, int COOFinal, string Arquivo, int[] Documentos, int QTD_DOC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DoAtualizarValorGT(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_DoVerificaValorGT(IntPtr ecfHandle);

		#endregion PAF

		#region PAF LMFC

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Cotepe1704(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Cotepe1704_CRZ(IntPtr ecfHandle, int CRZInicial, int CRZFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Espelho(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Espelho_CRZ(IntPtr ecfHandle, int CRZInicial, int CRZFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Impressao(IntPtr ecfHandle, double DataInicial, double DataFinal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFC_Impressao_CRZ(IntPtr ecfHandle, int CRZInicial, int CRZFinal);

		#endregion PAF LMFC

		#region PAF LMFS

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFS_Espelho(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFS_Espelho_CRZ(IntPtr ecfHandle, int CRZInicial, int CRZFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFS_Impressao(IntPtr ecfHandle, double DataInicial, double DataFinal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_LMFS_Impressao_CRZ(IntPtr ecfHandle, int CRZInicial, int CRZFinal);

		#endregion PAF LMFS

		#region PAF Espelho MFD

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_MFD_Cotepe1704(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_MFD_Cotepe1704_COO(IntPtr ecfHandle, int COOInicial, int COOFinal, string CaminhoArquivo);

		#endregion PAF Espelho MFD

		#region PAF Arq. MFD

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_MFD_Espelho(IntPtr ecfHandle, double DataInicial, double DataFinal, string CaminhoArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PafMF_MFD_Espelho_COO(IntPtr ecfHandle, int COOInicial, int COOFinal, string CaminhoArquivo);

		#endregion PAF Arq. MFD

		#region Relatórios

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraX(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ReducaoZ(IntPtr ecfHandle, double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreCupomVinculado(IntPtr ecfHandle, string coo, string codFormaPagto, double valor);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreCupomVinculadoCNF(IntPtr ecfHandle, string coo, string codFormaPagto, string codComprovanteNaoFiscal, double valor);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LinhaCupomVinculado(IntPtr ecfHandle, string linha);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_FechaRelatorio(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_PulaLinhas(IntPtr ecfHandle, int numLinhas);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CortaPapel(IntPtr ecfHandle, bool corteParcial);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_IdentificaPAF(IntPtr ecfHandle, string nomeVersao, string md5);

		#endregion Relatórios

		#region Cupom Não Fiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreNaoFiscal(IntPtr ecfHandle, string cpfCnpj);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_RegistraItemNaoFiscal(IntPtr ecfHandle, string codCNF, double value, string obs);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SubtotalizaNaoFiscal(IntPtr ecfHandle, double descontoAcrescimo, string mensagemRodape);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_EfetuaPagamentoNaoFiscal(IntPtr ecfHandle, string codFormaPagto, double valor, string observacao, bool imprimeVinculado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_FechaNaoFiscal(IntPtr ecfHandle, string observacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CancelaNaoFiscal(IntPtr ecfHandle);

		#endregion Cupom Não Fiscal

		#region Alíquotas

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetAliquota(IntPtr ecfHandle, ref AliquotaRec aliquota, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CarregaAliquotas(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LerTotaisAliquota(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ProgramaAliquota(IntPtr ecfHandle, double aliquota, char tipo, string posicao);

		#endregion Alíquotas

		#region Formas de Pagto


		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AchaFPGDescricao(IntPtr ecfHandle, string descricao, bool buscaexata, bool ignorecase, ref FormaPagamentoRec formaPagamento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AchaFPGIndice(IntPtr ecfHandle, string indice, ref FormaPagamentoRec formaPagamento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetFormaPagamento(IntPtr ecfHandle, ref FormaPagamentoRec formaPagamento, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CarregaFormasPagamento(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LerTotaisFormaPagamento(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ProgramaFormaPagamento(IntPtr ecfHandle, string descricao, bool permiteVinculado, string posicao);

		#endregion Formas de Pagto

		#region Relatorio Gerencial

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_AbreRelatorioGerencial(IntPtr ecfHandle, int indice);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LinhaRelatorioGerencial(IntPtr ecfHandle, string linha, int indiceBMP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ProgramaRelatoriosGerenciais(IntPtr ecfHandle, string descricao, string posicao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetRelatoriosGerenciais(IntPtr ecfHandle, ref RelatorioGerencialRec relatorio, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LerTotaisRelatoriosGerenciais(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CarregaRelatoriosGerenciais(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_RelatorioGerencial(IntPtr ecfHandle, string[] linhas, int linhasCount, int Via, int Indice);

		#endregion Relatorio Gerencial

		#region Comprovante não fiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_GetComprovanteNaoFiscal(IntPtr ecfHandle, ref ComprovanteNaoFiscalRec comprovanteNaoFiscal, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_CarregaComprovantesNaoFiscais(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LerTotaisComprovanteNaoFiscal(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_ProgramaComprovanteNaoFiscal(IntPtr ecfHandle, string descricao, string tipo, string posicao);

		#endregion Comprovante não fiscal

		#region LeituraMemoriaFiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalReducao(IntPtr ecfHandle, int reducaoInicial, int reducaoFinal, bool simplificada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalData(IntPtr ecfHandle, double dataInicial, double dataFinal, bool simplificada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalSerialReducao(IntPtr ecfHandle, int reducaoInicial, int reducaoFinal, bool simplificada, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalSerialData(IntPtr ecfHandle, double dataInicial, double dataFinal, bool simplificada, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalArquivoReducao(IntPtr ecfHandle, int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_LeituraMemoriaFiscalArquivoData(IntPtr ecfHandle, double dataInicial, double dataFinal, string nomeArquivo, bool simplificada);

		#endregion LeituraMemoriaFiscal

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnPoucoPapel(IntPtr ecfHandle, NoArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAguardandoRespostaChange(IntPtr ecfHandle, NoArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnBobinaAdicionaLinhas(IntPtr ecfHandle, BobinaAdicionaLinhasCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesAbreCupom(IntPtr ecfHandle, AbreCupomCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesAbreCupomVinculado(IntPtr ecfHandle, NoArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesAbreNaoFiscal(IntPtr ecfHandle, AbreCupomCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesAbreRelatorioGerencial(IntPtr ecfHandle, IntArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesCancelaCupom(IntPtr ecfHandle, NoArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesCancelaItemNaoFiscal(IntPtr ecfHandle, IntArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ECF_SetOnAntesCancelaItemVendido(IntPtr ecfHandle, IntArgumentCallback method);

		#endregion Eventos

		#endregion ACBrECF
	}
}