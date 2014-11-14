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
	[Guid("2D204F15-3B9A-4918-88C0-4C37CD234696")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

#endregion COM_INTEROP

	public sealed class Imposto : ACBrComposedComponent
	{
		#region Constructor

		internal Imposto(Rodape rodape)
			: base(rodape.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public string Texto
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetTexto);
			}			
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetTexto, value);
			}
		}

		public string Fonte
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetFonte);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetFonte, value);
			}
		}

		public decimal ValorAproximado
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetValorAproximado);
			}
			#region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetValorAproximado, value);
			}
		}

        public decimal ValorAproximadoFederal
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetValorAproximadoFederal);
            }
            #region COM_INTEROP

#if COM_INTEROP
            [param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetValorAproximadoFederal, value);
            }
        }

        public decimal ValorAproximadoEstadual
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetValorAproximadoEstadual);
            }
            #region COM_INTEROP

#if COM_INTEROP
            [param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetValorAproximadoEstadual, value);
            }
        }

        public decimal ValorAproximadoMunicipal
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get
            {
                return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetValorAproximadoMunicipal);
            }
            #region COM_INTEROP

#if COM_INTEROP
            [param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set
            {
                SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetValorAproximadoMunicipal, value);
            }
        }

        public bool ModoCompacto
	    {
	        get
	        {
                return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_GetModoCompacto);
	        }
            set
            {
                SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_Imposto_SetModoCompacto, value);
            }

	    }

		#endregion Properties
	}
}
