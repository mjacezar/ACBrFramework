using System;
using System.ComponentModel;
using System.Drawing;
using ACBrFramework.SPED;

namespace ACBrFramework.SPEDFiscal
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.SPED.Fiscal.ico.bmp")]
	public class ACBrSPEDFiscal : ACBrComponent, IDisposable
	{
		#region Properties

		[Category("Geral")]
		public string About
		{
			get
			{
				return string.Format("ACBr: {0} ACBrFramework: {1}", GetString(ACBrSPEDFiscalInterop.SPDF_GetAbout), this.GetType().Assembly.GetName().Version);
			}
		}

		[Category("Geral")]
		public string Arquivo
		{
			get
			{
				return GetString(ACBrSPEDFiscalInterop.SPDF_GetArquivo);
			}
			set
			{
				SetString(ACBrSPEDFiscalInterop.SPDF_SetArquivo, value);
			}
		}

		[Category("Geral")]
		public string CurMascara
		{
			get
			{
				return GetString(ACBrSPEDFiscalInterop.SPDF_GetCurMascara);
			}
			set
			{
				SetString(ACBrSPEDFiscalInterop.SPDF_SetCurMascara, value);
			}
		}

		[Category("Geral")]
		public string Path
		{
			get
			{
				return GetString(ACBrSPEDFiscalInterop.SPDF_GetPath);
			}
			set
			{
				SetString(ACBrSPEDFiscalInterop.SPDF_SetPath, value);
			}
		}

		[Category("Geral")]
		public string Delimitador
		{
			get
			{
				return GetString(ACBrSPEDFiscalInterop.SPDF_GetDelimitador);
			}
			set
			{
				SetString(ACBrSPEDFiscalInterop.SPDF_SetDelimitador, value);
			}
		}

		[Category("Geral")]
		public int LinhasBuffer
		{
			get
			{
				return GetInt32(ACBrSPEDFiscalInterop.SPDF_GetLinhasBuffer);
			}
			set
			{
				SetInt32(ACBrSPEDFiscalInterop.SPDF_SetLinhasBuffer, value);
			}
		}

		[Category("Geral")]
		public Boolean TrimString
		{
			get
			{
				return GetBool(ACBrSPEDFiscalInterop.SPDF_GetTrimString);
			}
			set
			{
				SetBool(ACBrSPEDFiscalInterop.SPDF_SetTrimString, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSPEDFiscalInterop.SPDF_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSPEDFiscalInterop.SPDF_SetDT_INI, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSPEDFiscalInterop.SPDF_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSPEDFiscalInterop.SPDF_SetDT_FIN, value);
			}
		}

		[Browsable(false)]
		public ACBrSPEDBloco0 Bloco_0 { get; private set; }

		#endregion Properties

		#region Methods

		public void IniciaGeracao()
		{
			int ret = ACBrSPEDFiscalInterop.SPDF_IniciaGeracao(this.Handle);
			CheckResult(ret);
		}

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrSPEDFiscalInterop.SPDF_Create);
			Bloco_0 = new ACBrSPEDBloco0();
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrSPEDFiscalInterop.SPDF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrSPEDFiscal não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSPEDFiscalInterop.SPDF_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}