namespace ACBrFramework.LFD
{
	public class RegistroA990 : ACBrComposedComponent
	{
		#region Constructor

		internal RegistroA990(ACBrLFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_0
		{
			get
			{
				return GetInt32(ACBrLFDInterop.LFD_Bloco_A_RegistroA990_GetQTD_LIN_A);
			}
		}

		#endregion Properties
	}
}