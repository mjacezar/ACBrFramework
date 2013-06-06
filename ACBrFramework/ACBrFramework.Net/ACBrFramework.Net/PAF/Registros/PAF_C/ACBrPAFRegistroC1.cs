#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP


namespace ACBrFramework.PAF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CCA93061-77AA-41B8-8F16-427F45EB7EE2")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAFRegistroC1
	{
		#region Properties

		public string RazaoSocial { get; set; }

		public string UF { get; set; }

		public string CNPJ { get; set; }

		public string IE { get; set; }

		public string IM { get; set; }

		#endregion Properties
	}
}