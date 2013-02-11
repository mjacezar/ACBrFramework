namespace ACBrFramework.Sped
{
	public class RegistroD990 : ACBrComposedComponent
	{
		#region Constructor

		internal RegistroD990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD990_GetQTD_LIN_D);
			}
		}

		#endregion Properties
	}
}