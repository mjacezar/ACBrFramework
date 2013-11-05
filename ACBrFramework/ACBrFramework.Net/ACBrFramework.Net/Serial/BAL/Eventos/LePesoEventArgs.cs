using System;
#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.BAL
{
    #region COM Interop Attributes

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("B1357CB5-02DA-4274-B2AC-13EA5D623153")]
    [ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
	public class LePesoEventArgs : EventArgs
	{
		public decimal Peso
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

                #endregion COM_INTEROP
            get; 
            
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

                #endregion COM_INTEROP
            set;
        }
	}
}