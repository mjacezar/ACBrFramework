using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

using ACBrFramework.AAC;
using ACBrFramework.EAD;

namespace ACBrFramework.PAF
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.PAF.ico.bmp")]
	public class ACBrPAF : ACBrComponent, IDisposable
	{
		#region EventHandlers

		public event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA
		{
			add
			{
				onPAFGetKeyRSA.Add(value);
			}
			remove
			{
				onPAFGetKeyRSA.Remove(value);
			}
		}

		#endregion EventHandlers

		#region Fields

		private readonly ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.OnPAFGetKeyRSACallback> onPAFGetKeyRSA;

		private ACBrAAC aac;
		private ACBrEAD ead;

		#endregion Fields

		#region Constructor

		public ACBrPAF()
		{
			onPAFGetKeyRSA = new ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.OnPAFGetKeyRSACallback>(this, OnPAFGetKeyRSACallBack, ACBrPAFInterop.PAF_SetOnPAFGetKeyRSA);
		}

		#endregion Constructor

		#region Properties

		public string Path
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetPath);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetPath, value);
			}
		}

		public string Delimitador
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetDelimitador);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetDelimitador, value);
			}
		}

		public string CurMascara
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetCurMascara);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetCurMascara, value);
			}
		}

		public bool TrimString
		{
			get
			{
				return GetBool(ACBrPAFInterop.PAF_GetTrimString);
			}
			set
			{
				SetBool(ACBrPAFInterop.PAF_SetTrimString, value);
			}
		}

		public bool AssinarArquivo
		{
			get
			{
				return GetBool(ACBrPAFInterop.PAF_GetAssinarArquivo);
			}
			set
			{
				SetBool(ACBrPAFInterop.PAF_SetAssinarArquivo, value);
			}
		}

		[Browsable(false)]
		public ACBrPAF_B PAF_B { get; private set; }

		[Browsable(false)]
		public ACBrPAF_C PAF_C { get; private set; }

		[Browsable(false)]
		public ACBrPAF_D PAF_D { get; private set; }

		[Browsable(false)]
		public ACBrPAF_E PAF_E { get; private set; }

		[Browsable(false)]
		public ACBrPAF_H PAF_H { get; private set; }

		[Browsable(false)]
		public ACBrPAF_N PAF_N { get; private set; }

		[Browsable(false)]
		public ACBrPAF_P PAF_P { get; private set; }

		[Browsable(false)]
		public ACBrPAF_R PAF_R { get; private set; }

		[Browsable(false)]
		public ACBrPAF_T PAF_T { get; private set; }

		[Browsable(false)]
		public ACBrPAF_TITP PAF_TITP { get; private set; }

		public ACBrAAC AAC
		{
			get
			{
				return this.aac;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, value.Handle);
					CheckResult(ret);

					this.aac = value;
				}
			}
		}

		public ACBrEAD EAD
		{
			get
			{
				return this.ead;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, value.Handle);
					CheckResult(ret);

					this.ead = value;
				}
			}
		}

		#endregion Properties

		#region Methods

		public bool AssinarArquivoComEAD(string arquivo)
		{
			int ret = ACBrPAFInterop.PAF_AssinarArquivoComEAD(this.Handle, arquivo);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrPAFInterop.PAF_Create);
			PAF_B = new ACBrPAF_B(this);
			PAF_C = new ACBrPAF_C(this);
			PAF_D = new ACBrPAF_D(this);
			PAF_E = new ACBrPAF_E(this);
			PAF_H = new ACBrPAF_H(this);
			PAF_N = new ACBrPAF_N(this);
			PAF_P = new ACBrPAF_P(this);
			PAF_R = new ACBrPAF_R(this);
			PAF_T = new ACBrPAF_T(this);
			PAF_TITP = new ACBrPAF_TITP(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrPAFInterop.PAF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr PAF não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrPAFInterop.PAF_Destroy);
			}
		}

		#endregion Override Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private string OnPAFGetKeyRSACallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onPAFGetKeyRSA.IsAssigned)
				onPAFGetKeyRSA.Raise(e);

			return e.Chave;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}