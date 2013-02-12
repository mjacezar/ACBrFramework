namespace ACBrFramework.Sped
{
	public class RegistroH990: ACBrComposedComponent
	{
		#region Constructor

		internal RegistroH990(ACBrSpedFiscal parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_H
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_Bloco_H_RegistroH990_GetQTD_LIN_H);
			}
		}

		#endregion Properties
	}
}