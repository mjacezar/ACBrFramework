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
	[Guid("7A3D227D-04AE-4925-BD2D-3661F4C5F085")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAFRegistroD1
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