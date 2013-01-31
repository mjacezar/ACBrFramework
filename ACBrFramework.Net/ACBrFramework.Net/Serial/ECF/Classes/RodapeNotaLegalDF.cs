#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("9D0EF24E-5B1A-4EDE-8189-E70AC3419085")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class RodapeNotaLegalDF : ACBrComposedComponent
	{
		#region Constructor

		internal RodapeNotaLegalDF(Rodape rodape)
			: base(rodape.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool Imprimir
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir, value);
			}
		}

		public bool ProgramaDeCredito
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito, value);
			}
		}

		public decimal ValorICMS
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS);
			}
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS, value);
			}
		}

		public decimal ValorISS
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS);
			}
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS, value);
			}
		}

		#endregion Properties
	}
}