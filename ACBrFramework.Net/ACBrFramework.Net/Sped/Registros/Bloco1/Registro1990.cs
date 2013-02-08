namespace ACBrFramework.Sped
{
	public class Registro1990 : ACBrComposedComponent
	{
		#region Constructor

		internal Registro1990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_0
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1990_GetQTD_LIN_1);
			}
		}

		#endregion Properties
	}
}