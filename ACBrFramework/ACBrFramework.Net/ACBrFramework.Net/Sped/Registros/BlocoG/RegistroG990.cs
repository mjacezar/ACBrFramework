namespace ACBrFramework.Sped
{
	public class RegistroG990: ACBrComposedComponent
	{
		#region Constructor

		internal RegistroG990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_G
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG990_GetQTD_LIN_G);
			}
		}

		#endregion Properties
	}
}