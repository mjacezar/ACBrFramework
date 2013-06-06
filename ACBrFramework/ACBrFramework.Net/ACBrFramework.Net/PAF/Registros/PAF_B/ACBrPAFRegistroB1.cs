#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
	#region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("FCA86DBD-6E9B-48A1-A85D-CEB3E3DFC8BA")]
	[ComSourceInterfaces(typeof(IACBrPAFEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	public sealed class ACBrPAFRegistroB1
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