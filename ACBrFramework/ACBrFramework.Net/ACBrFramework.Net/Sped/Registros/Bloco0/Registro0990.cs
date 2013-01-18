namespace ACBrFramework.Sped
{
	public class Registro0990 : ACBrComposedComponent
	{
		#region Constructor

		internal Registro0990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_0
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0990_GetQTD_LIN_0);
			}
		}

		#endregion Properties
	}
}