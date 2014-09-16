using System;
using System.Collections.Generic;
#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
    #region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("4CE90A74-8192-4D24-9E4D-0C1B2B666A58")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
    public sealed class RodapeAbastecimento : ACBrComposedComponent
    {
        #region Constructor

        internal RodapeAbastecimento(ACBrECF parent, IntPtr composedHandle)
            : base(parent, composedHandle)
        {
        }

        #endregion Constructor

        #region Properties

        public int Bico 
        { 
            get
            {
                return GetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetBico);
            }
            set
            {
                SetInt32(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetBico, value);
            }
        }
        public decimal EI
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetEI);
            }

            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetEI, value);
            }
        }
        public decimal EF
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetEF);
            }

            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetEF, value);
            }
        }
        public decimal Volume 
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetVolume);
            }

            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetVolume, value);
            }
        }
        public Boolean Automatico
        {
            get
            {
                return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetAutomatico);
            }
            set
            {
                SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetAutomatico, value);
            }
        }

        #endregion Properties
    }
}
