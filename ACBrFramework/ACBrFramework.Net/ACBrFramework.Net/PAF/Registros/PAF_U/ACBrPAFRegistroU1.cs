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
	[Guid("02991883-D795-4405-91FB-78FD1DEDA4FA")]
	[ComSourceInterfaces(typeof(IACBrPAFEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM Interop Attributes

    public sealed class ACBrPAFRegistroU1
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