using System.ComponentModel;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CE8FB949-42A9-4FB6-856D-41D1F662F003")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class IdenticacaoPaf : ACBrComposedComponent
	{
		#region Constructor

		internal IdenticacaoPaf(ACBrAAC acbrAAC)
			: base(acbrAAC)
		{
			this.Empresa = new Empresa(this);
			this.Paf = new InfoPaf(this);
			this.ECFsAutorizados = new ECFs(this);
			this.OutrosArquivos = new Arquivos(this);
			this.ArquivoListaAutenticados = new ArquivoListaAutenticados(this);
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public Empresa Empresa { get; private set; }

		[Browsable(true)]
		public InfoPaf Paf { get; private set; }

		[Browsable(true)]
		public ECFs ECFsAutorizados { get; private set; }

		[Browsable(true)]
		public Arquivos OutrosArquivos { get; private set; }

		[Browsable(true)]
		public ArquivoListaAutenticados ArquivoListaAutenticados { get; private set; }

		public string NumeroLaudo
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_GetNumeroLaudo);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_SetNumeroLaudo, value);
			}
		}

		public string VersaoER
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_GetVersaoER);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_SetVersaoER, value);
			}
		}

		#endregion Properties
	}
}