namespace ACBrFramework.LFD
{
	public class RegistroC990 : ACBrComposedComponent
	{
		#region Constructor

		internal RegistroC990(ACBrLFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_C
		{
			get
			{
				return GetInt32(ACBrLFDInterop.LFD_Bloco_C_RegistroC990_GetQTD_LIN_C);
			}
		}

		#endregion Properties
	}
}