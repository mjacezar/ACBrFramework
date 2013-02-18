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
	[Guid("4CDBFAB2-9CC6-4D31-8B19-42183EC2E24F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ArquivoListaAutenticados : ACBrComposedComponent
	{
		#region Constructor

		internal ArquivoListaAutenticados(IdenticacaoPaf identPaf)
			: base(identPaf.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public string Nome
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_GetNome);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_SetNome, value);
			}
		}

		public string MD5
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_GetMD5);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_SetMD5, value);
			}
		}

		#endregion Properties
	}
}