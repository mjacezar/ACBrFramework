#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("DF17E675-E0D2-4E60-A725-0D4FCB52EBFD")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ConfigBarras : ACBrComposedComponent
	{
		#region Constructor

		internal ConfigBarras(ACBrECF acbrECF)
			: base(acbrECF)
		{
		}

		#endregion Constructor

		#region Properties

		public int Altura
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_ConfigBarras_GetAltura);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_ConfigBarras_SetAltura, value);
			}
		}

		public int LarguraLinha
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_ConfigBarras_GetLarguraLinha);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_ConfigBarras_SetLarguraLinha, value);
			}
		}

		public int Margem
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_ConfigBarras_GetMargem);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_ConfigBarras_SetMargem, value);
			}
		}

		public bool MostrarCodigo
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_ConfigBarras_GetMostrarCodigo);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_ConfigBarras_SetMostrarCodigo, value);
			}
		}

		#endregion Properties
	}
}