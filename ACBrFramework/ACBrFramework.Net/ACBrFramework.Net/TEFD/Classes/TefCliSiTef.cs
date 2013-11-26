using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.TEFD
{
	public class TefCliSiTef : ACBrComposedComponent
	{
		#region Events

		public event EventHandler<TEFCliSiTefExibeMenuEventArgs> OnExibeMenu
		{
			add
			{
				onExibeMenu.Add(value);
			}
			remove
			{
				onExibeMenu.Remove(value);
			}
		}

		public event EventHandler<TEFCliSiTefObtemCampoEventArgs> OnObtemCampo
		{
			add
			{
				onObtemCampo.Add(value);
			}
			remove
			{
				onObtemCampo.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<TEFCliSiTefExibeMenuEventArgs, ACBrTEFInterop.TEFCliSiTefExibeMenuCallback> onExibeMenu;
		private readonly ACBrEventHandler<TEFCliSiTefObtemCampoEventArgs, ACBrTEFInterop.TEFCliSiTefObtemCampoCalback> onObtemCampo;

		#endregion Fields

		#region Constructor

		internal TefCliSiTef(ACBrComponent parent)
			: base(parent)
		{
			onExibeMenu = new ACBrEventHandler<TEFCliSiTefExibeMenuEventArgs, ACBrTEFInterop.TEFCliSiTefExibeMenuCallback>(this, OnTEFCliSiTefExibeMenuCallback, ACBrTEFInterop.TEF_TEFCliSiTef_SetOnExibeMenu);
			onObtemCampo = new ACBrEventHandler<TEFCliSiTefObtemCampoEventArgs, ACBrTEFInterop.TEFCliSiTefObtemCampoCalback>(this, OnTEFCliSiTefObtemCampoCalback, ACBrTEFInterop.TEF_TEFCliSiTef_SetOnObtemCampo);
		}

		#endregion Constructor

		#region Properties

		public string EnderecoIP
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetEnderecoIP);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetEnderecoIP, value);
			}
		}

		public string CodigoLoja
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetCodigoLoja);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetCodigoLoja, value);
			}
		}

		public string NumeroTerminal
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetNumeroTerminal);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetNumeroTerminal, value);
			}
		}

		public string Operador
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperador);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperador, value);
			}
		}

		public string Restricoes
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetRestricoes);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetRestricoes, value);
			}
		}

		public string[] ParametrosAdicionais
		{
			get
			{
				return GetStringArray(ACBrTEFInterop.TEF_TEFCliSiTef_GetParametrosAdicionais, ACBrTEFInterop.TEF_TEFCliSiTef_GetParametrosAdicionaisCount);
			}
			set
			{
				SetStringArray(ACBrTEFInterop.TEF_TEFCliSiTef_SetParametrosAdicionais, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCliSiTef_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCliSiTef_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFCliSiTef_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFCliSiTef_SetHabilitado, value);
			}
		}

		public int OperacaoATV
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoATV);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoATV, value);
			}
		}

		public int OperacaoADM
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoADM);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoADM, value);
			}
		}

		public int OperacaoCRT
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoCRT);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoCRT, value);
			}
		}

		public int OperacaoCHQ
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoCHQ);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoCHQ, value);
			}
		}

		public int OperacaoCNC
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoCNC);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoCNC, value);
			}
		}

		public int OperacaoReImpressao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_GetOperacaoReImpressao);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCliSiTef_SetOperacaoReImpressao, value);
			}
		}

		#endregion Properties

		#region Methods

		public int DefineMensagemPermanentePinPad(string mensagem)
		{
			int ret = ACBrTEFInterop.TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(this.Handle, ToUTF8(mensagem));
			CheckResult(ret);

			return ret;
		}

		public int ObtemQuantidadeTransacoesPendentes(DateTime data, string CupomFiscal)
		{
			int ret = ACBrTEFInterop.TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(this.Handle, ToOADate(data), ToUTF8(CupomFiscal));
			CheckResult(ret);

			return ret;
		}

		#region Interop EventCallbacks

		[AllowReversePInvokeCalls]
		private void OnTEFCliSiTefExibeMenuCallback(string Titulo, IntPtr Opcoes, int OpcoesCount, ref int ItemSelecionado, ref bool VoltarMenu)
		{
			if (onExibeMenu.IsAssigned)
			{
				string[] opcoes = GetStringArray(Opcoes, OpcoesCount);

				var e = new TEFCliSiTefExibeMenuEventArgs(Titulo, opcoes);
				onExibeMenu.Raise(e);

				ItemSelecionado = e.ItemSelecionado;
				VoltarMenu = e.VoltarMenu;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnTEFCliSiTefObtemCampoCalback(string Titulo, int TamanhoMinimo, int TamanhoMaximo, int TipoCampo, int Operacao, StringBuilder Resposta, int RespLen, ref bool Digitado, ref bool VoltarMenu)
		{
			if (onObtemCampo.IsAssigned)
			{
                var e = new TEFCliSiTefObtemCampoEventArgs(Titulo, TamanhoMinimo, TamanhoMaximo, TipoCampo, (TefCliSiTefOperacaoCampo)Operacao);
				onObtemCampo.Raise(e);

				PrepareOutStringBuilder(Resposta, RespLen);
				Resposta.Length = 0;
				Resposta.Append(e.Resposta);
				Digitado = e.Digitado;
				VoltarMenu = e.VoltarMenu;
			}
		}

		#endregion Interop EventCallbacks

		#endregion Methods
	}
}