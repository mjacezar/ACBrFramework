using System;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework.Sped
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Sped.ico.bmp")]
	public class ACBrSpedFiscal : ACBrComponent, IDisposable
	{
		#region Properties

		[Category("Geral")]
		public string About
		{
			get
			{
				return GetAbout(ACBrSpedFiscalInterop.SPDF_GetAbout);
			}
		}

		[Category("Geral")]
		public string Arquivo
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetArquivo);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetArquivo, value);
			}
		}

		[Category("Geral")]
		public string CurMascara
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetCurMascara);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetCurMascara, value);
			}
		}

		[Category("Geral")]
		public string Path
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetPath);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetPath, value);
			}
		}

		[Category("Geral")]
		public string Delimitador
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetDelimitador);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetDelimitador, value);
			}
		}

		[Category("Geral")]
		public int LinhasBuffer
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_GetLinhasBuffer);
			}
			set
			{
				SetInt32(ACBrSpedFiscalInterop.SPDF_SetLinhasBuffer, value);
			}
		}

		[Category("Geral")]
		public Boolean TrimString
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_GetTrimString);
			}
			set
			{
				SetBool(ACBrSpedFiscalInterop.SPDF_SetTrimString, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_SetDT_INI, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_SetDT_FIN, value);
			}
		}

		[Browsable(false)]
		public Bloco0 Bloco_0 { get; private set; }

		[Browsable(false)]
		public Bloco1 Bloco_1 { get; private set; }

		[Browsable(false)]
		public Bloco9 Bloco_9 { get; private set; }

		[Browsable(false)]
		public BlocoC Bloco_C { get; private set; }

		[Browsable(false)]
		public BlocoD Bloco_D { get; private set; }

		[Browsable(false)]
		public BlocoE Bloco_E { get; private set; }

		[Browsable(false)]
		public BlocoG Bloco_G { get; private set; }

		[Browsable(false)]
		public BlocoH Bloco_H { get; private set; }

		#endregion Properties

		#region Methods

		public void IniciaGeracao()
		{
			int ret = ACBrSpedFiscalInterop.SPDF_IniciaGeracao(this.Handle);
			CheckResult(ret);
		}

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrSpedFiscalInterop.SPDF_Create);
			Bloco_0 = new Bloco0();
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrSpedFiscalInterop.SPDF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrSPEDFiscal não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSpedFiscalInterop.SPDF_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}