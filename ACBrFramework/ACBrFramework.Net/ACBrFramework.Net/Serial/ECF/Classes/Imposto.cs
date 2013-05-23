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
	[Guid("2D204F15-3B9A-4918-88C0-4C37CD234696")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

#endregion COM_INTEROP

	public sealed class Imposto : ACBrComposedComponent
	{
		#region Constructor

		internal Imposto(Rodape rodape)
			: base(rodape.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public string Texto
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetTexto);
			}
			#region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetTexto, value);
			}
		}

		public string Fonte
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetFonte);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetFonte, value);
			}
		}

		public decimal ValorAproximado
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetValorAproximado);
			}
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetValorAproximado, value);
			}
		}

		#endregion Properties
	}
}
