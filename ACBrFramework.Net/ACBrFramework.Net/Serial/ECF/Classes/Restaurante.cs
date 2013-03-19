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
	[Guid("37DC86EF-999A-4992-9945-FB334DF3FEC6")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Restaurante : ACBrComposedComponent
	{
		#region Constructor

		internal Restaurante(Rodape rodape)
			: base(rodape.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool Imprimir
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_GetImprimir);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_SetImprimir, value);
			}
		}

		public int ECF
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_GetECF);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_SetECF, value);
			}
		}

		public int COO
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_GetCOO);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_SetCOO, value);
			}
		}

		public int CER
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_GetCER);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_SetCER, value);
			}
		}

		public string Mesa
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_GetMesa);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_Restaurante_SetMesa, value);
			}
		}

		#endregion Properties
	}
}