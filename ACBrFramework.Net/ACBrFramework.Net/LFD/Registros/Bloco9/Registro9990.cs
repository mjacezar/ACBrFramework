namespace ACBrFramework.LFD
{
	public class Registro9990 : ACBrComposedComponent
	{
		#region Constructor

		internal Registro9990(ACBrLFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int QTD_LIN_9
		{
			get
			{
				return GetInt32(ACBrLFDInterop.LFD_Bloco_9_Registro9990_GetQTD_LIN_9);
			}
		}

		#endregion Properties
	}
}