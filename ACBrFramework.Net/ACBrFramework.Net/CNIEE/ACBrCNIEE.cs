using System;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework.CNIEE
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.CNIEE.ico.bmp")]
	public class ACBrCNIEE : ACBrComponent, IDisposable
	{
		#region Events

		#endregion Events

		#region Fields

		private Registro[] registros;

		#endregion Fields

		#region Constructor

		public ACBrCNIEE()
		{
		}

		#endregion Constructor

		#region Properties

		[Category("Geral")]
		public string Arquivo
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetArquivo);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetArquivo, value);
			}
		}

		[Category("Geral")]
		public string VersãoArquivo
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetVersaoArquivo);
			}
		}

		[Category("Geral")]
		public bool ParseText
		{
			get
			{
				return GetBool(ACBrCNIEEInterop.CNIEE_GetParseText);
			}
			set
			{
				SetBool(ACBrCNIEEInterop.CNIEE_SetParseText, value);
			}
		}

		[Category("Geral")]
		public string URLDownload
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetURLDownload);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetURLDownload, value);
			}
		}

		[Category("Proxy")]
		public string ProxyUser
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetProxyUser);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetProxyUser, value);
			}
		}

		[Category("Proxy")]
		public string ProxyPass
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetProxyPass);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetProxyPass, value);
			}
		}

		[Category("Proxy")]
		public string ProxyHost
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetProxyHost);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetProxyHost, value);
			}
		}

		[Category("Proxy")]
		public string ProxyPort
		{
			get
			{
				return GetString(ACBrCNIEEInterop.CNIEE_GetProxyPort);
			}
			set
			{
				SetString(ACBrCNIEEInterop.CNIEE_SetProxyPort, value);
			}
		}

		[Browsable(false)]
		public Registro[] Registros
		{
			get
			{
				if (registros == null) CarregaRegistros();
				return (Registro[])registros;
			}
		}

		#endregion Properties

		#region Methods

		#region Funções

		public bool LerConfiguracoesProxy()
		{
			int ret = ACBrCNIEEInterop.CNIEE_LerConfiguracoesProxy(Handle);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool DownloadTabela()
		{
			int ret = ACBrCNIEEInterop.CNIEE_DownloadTabela(Handle);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool AbrirTabela()
		{
			int ret = ACBrCNIEEInterop.CNIEE_AbrirTabela(Handle);
			CheckResult(ret);

			CarregaRegistros();
			return Convert.ToBoolean(ret);
		}

		public void Exportar(string path, string delimitador)
		{
			int ret = ACBrCNIEEInterop.CNIEE_Exportar(Handle, ToUTF8(path), delimitador, 0);
			CheckResult(ret);
		}

		public void Exportar(string path, Exporta tipo)
		{
			int ret = ACBrCNIEEInterop.CNIEE_Exportar(Handle, ToUTF8(path), null, (int)tipo);
			CheckResult(ret);
		}

		public Registro BuscarECF(string marca, string modelo, string versaosb)
		{
			var record = new ACBrCNIEEInterop.CNIEERegistroRec();
			int ret = ACBrCNIEEInterop.CNIEE_BuscarECF(Handle, ref record, marca, modelo, versaosb);
			CheckResult(ret);

			if (ret == 0)
				return null;

			Registro registro = new Registro();
			registro.Marca = FromUTF8(record.Marca);
			registro.Modelo = FromUTF8(record.Modelo);
			registro.Versao = FromUTF8(record.Versao);
			registro.Tipo = FromUTF8(record.Tipo);
			registro.MarcaDescr = FromUTF8(record.MarcaDescr);
			registro.ModeloDescr = FromUTF8(record.ModeloDescr);
			registro.VersaoSB = FromUTF8(record.VersaoSB);
			registro.QtLacreSL = record.QtLacreSL;
			registro.QTLacreFab = record.QTLacreFab;
			registro.MFD = FromUTF8(record.MFD);
			registro.LacreMFD = FromUTF8(record.LacreMFD);
			registro.AtoAprovacao = FromUTF8(record.AtoAprovacao);
			registro.AtoRegistro = FromUTF8(record.AtoRegistro);
			registro.FormatoNumero = FromUTF8(record.FormatoNumero);

			return registro;
		}

		private void CarregaRegistros()
		{
			int count = ACBrCNIEEInterop.CNIEE_GetRegistroCount(Handle);
			CheckResult(count);

			registros = new Registro[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrCNIEEInterop.CNIEERegistroRec();
				int ret = ACBrCNIEEInterop.CNIEE_GetRegistro(Handle, ref record, i);
				CheckResult(ret);

				Registro registro = new Registro();
				registro.Marca = FromUTF8(record.Marca);
				registro.Modelo = FromUTF8(record.Modelo);
				registro.Versao = FromUTF8(record.Versao);
				registro.Tipo = FromUTF8(record.Tipo);
				registro.MarcaDescr = FromUTF8(record.MarcaDescr);
				registro.ModeloDescr = FromUTF8(record.ModeloDescr);
				registro.VersaoSB = FromUTF8(record.VersaoSB);
				registro.QtLacreSL = record.QtLacreSL;
				registro.QTLacreFab = record.QTLacreFab;
				registro.MFD = FromUTF8(record.MFD);
				registro.LacreMFD = FromUTF8(record.LacreMFD);
				registro.AtoAprovacao = FromUTF8(record.AtoAprovacao);
				registro.AtoRegistro = FromUTF8(record.AtoRegistro);
				registro.FormatoNumero = FromUTF8(record.FormatoNumero);
				registros[i] = registro;
			}
		}

		#endregion Funções

		#region EventHandlers

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrCNIEEInterop.CNIEE_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrCNIEEInterop.CNIEE_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr CNIEE não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrCNIEEInterop.CNIEE_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}