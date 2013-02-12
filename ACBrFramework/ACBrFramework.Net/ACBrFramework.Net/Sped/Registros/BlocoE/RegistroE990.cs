namespace ACBrFramework.Sped
{
	public class RegistroE990: ACBrComposedComponent
	{
		#region Constructor

		internal RegistroE990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_E
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE990_GetQTD_LIN_E);
			}
		}

		#endregion Properties
	}
}