namespace ACBrFramework.LFD
{
	public class Registro9999 : ACBrComposedComponent
	{
		#region Constructor

		internal Registro9999(ACBrLFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN
		{
			get
			{
				return GetInt32(ACBrLFDInterop.LFD_Bloco_9_Registro9999_GetQTD_LIN);
			}
		}

		#endregion Properties
	}
}