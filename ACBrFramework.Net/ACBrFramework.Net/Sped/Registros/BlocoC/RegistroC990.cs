namespace ACBrFramework.Sped
{
	public class RegistroC990 : ACBrComposedComponent
	{
		#region Constructor

		internal RegistroC990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_C
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C);
			}
		}

		#endregion Properties
	}
}