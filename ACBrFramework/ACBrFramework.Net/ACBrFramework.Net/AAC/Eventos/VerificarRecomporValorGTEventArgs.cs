using System;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("6F873733-E7F9-4108-8F0C-B353AF58909F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class VerificarRecomporValorGTEventArgs : EventArgs
	{
		#region Constructor

		internal VerificarRecomporValorGTEventArgs(string numserie)
		{
			NumSerie = numserie;
		}

		#endregion Constructor

		#region Properties

		public string NumSerie { get; private set; }

		public decimal ValorGT
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;

			#region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			set;
		}

		#endregion Properties
	}
}