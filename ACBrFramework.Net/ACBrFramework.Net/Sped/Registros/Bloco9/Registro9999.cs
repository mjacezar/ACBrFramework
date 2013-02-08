namespace ACBrFramework.Sped
{
	public class Registro9999 : ACBrComposedComponent
	{
		#region Constructor

		internal Registro9999(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_9_Registro9999_GetQTD_LIN);
			}
		}

		#endregion Properties
	}
}