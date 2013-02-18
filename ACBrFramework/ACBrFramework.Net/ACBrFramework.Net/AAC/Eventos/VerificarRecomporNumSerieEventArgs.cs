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
	[Guid("3D1D1811-CC58-49E2-9AAC-E14690069B92")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class VerificarRecomporNumSerieEventArgs : EventArgs
	{ 
		#region Constructor

		internal VerificarRecomporNumSerieEventArgs(string numserie, decimal gt)
		{
			NumSerie = numserie;
			ValorGT = gt;
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
			private set;
		}

		public int CRO { get; set; }

		public int CNI { get; set; }

		#endregion Properties
	}
}