using System;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ACBrFramework.Validador
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Validador.ico.bmp")]
	public class ACBrValidador : ACBrComponent, IDisposable
	{
		#region Events

		[Category("Geral")]
		public event EventHandler<OnMsgErroEventArgs> OnMsgErro
		{
			add
			{
				onMsgErro.Add(value);
			}
			remove
			{
				onMsgErro.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<OnMsgErroEventArgs, ACBrValidadorInterop.OnMsgErroCallback> onMsgErro;

		#endregion Fields

		#region Constructor

		public ACBrValidador()
		{
			onMsgErro = new ACBrEventHandler<OnMsgErroEventArgs, ACBrValidadorInterop.OnMsgErroCallback>(this, OnMsgErroCallback, ACBrValidadorInterop.VAL_SetOnMsgErro);
		}

		#endregion Constructor

		#region Properties

		[Category("Geral")]
		public string Documento
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetDocumento);
			}
			set
			{
				SetString(ACBrValidadorInterop.VAL_SetDocumento, value);
			}
		}

		[Category("Geral")]
		public string Complemento
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetComplemento);
			}
			set
			{
				SetString(ACBrValidadorInterop.VAL_SetComplemento, value);
			}
		}

		[Category("Geral")]
		public string IgnorarChar
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetIgnorarChar);
			}
			set
			{
				SetString(ACBrValidadorInterop.VAL_SetIgnorarChar, value);
			}
		}

		[Category("Geral")]
		public ValTipoDocto TipoDocto
		{
			get
			{
				return (ValTipoDocto)GetInt32(ACBrValidadorInterop.VAL_GetTipoDocto);
			}
			set
			{
				SetInt32(ACBrValidadorInterop.VAL_SetTipoDocto, (int)value);
			}
		}

		[Category("Geral")]
		public bool AjustarTamanho
		{
			get
			{
				return GetBool(ACBrValidadorInterop.VAL_GetAjustarTamanho);
			}
			set
			{
				SetBool(ACBrValidadorInterop.VAL_SetAjustarTamanho, value);
			}
		}

		[Category("Geral")]
		public bool ExibeDigitoCorreto
		{
			get
			{
				return GetBool(ACBrValidadorInterop.VAL_GetExibeDigitoCorreto);
			}
			set
			{
				SetBool(ACBrValidadorInterop.VAL_SetExibeDigitoCorreto, value);
			}
		}

		[Category("Geral")]
		public bool PermiteVazio
		{
			get
			{
				return GetBool(ACBrValidadorInterop.VAL_GetPermiteVazio);
			}
			set
			{
				SetBool(ACBrValidadorInterop.VAL_SetPermiteVazio, value);
			}
		}

		[Category("Geral")]
		public bool RaiseExcept
		{
			get
			{
				return GetBool(ACBrValidadorInterop.VAL_GetRaiseExcept);
			}
			set
			{
				SetBool(ACBrValidadorInterop.VAL_SetRaiseExcept, value);
			}
		}

		[Browsable(false)]
		public string DoctoValidado
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetDoctoValidado);
			}
		}

		[Browsable(false)]
		public string MsgErro
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetMsgErro);
			}
		}

		[Browsable(false)]
		public string DigitoCalculado
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_GetDigitoCalculado);
			}
		}

		[Browsable(false)]
		public Modulo Modulo { get; private set; }

		#endregion Properties

		#region Methods

		#region Funções

		public bool Validar()
		{
			int ret = ACBrValidadorInterop.VAL_Validar(this.Handle);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public string Formatar()
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_Formatar(this.Handle, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarCEP(string CEP)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarCEP(this.Handle, CEP, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarCNPJ(string CNPJ)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarCNPJ(this.Handle, CNPJ, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarCPF(string CPF)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarCNPJ(this.Handle, CPF, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarIE(string IE, string UF)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarIE(this.Handle, IE, UF, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarPIS(string PIS)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarPIS(this.Handle, PIS, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarCheque(string Cheque)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarCheque(this.Handle, Cheque, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}

		public string FormatarSUFRAMA(string SUFRAMA)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = ACBrValidadorInterop.VAL_FormatarSUFRAMA(this.Handle, SUFRAMA, buffer, bufferLen);
			CheckResult(ret);

			return buffer.ToString();
		}
				
		#endregion Funções

		#region EventHandlers

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrValidadorInterop.VAL_Create);
			this.Modulo = new Modulo(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrValidadorInterop.VAL_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr Validador não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrValidadorInterop.VAL_Destroy);
			}
		}

		#endregion Override Methods

		#region Interop EventCallbacks

		[AllowReversePInvokeCalls]
		private void OnMsgErroCallback(string mensagem)
		{
			if (onMsgErro.IsAssigned)
			{
				OnMsgErroEventArgs e = new OnMsgErroEventArgs(mensagem);
				onMsgErro.Raise(e);
			}
		}

		#endregion Interop EventCallbacks

		#endregion Methods
	}
}