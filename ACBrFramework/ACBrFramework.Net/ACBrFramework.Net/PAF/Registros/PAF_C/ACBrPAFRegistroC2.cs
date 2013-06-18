using System;
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
	[Guid("0093D2A3-737A-4FB9-8DA5-E7EC2815CB6D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAFRegistroC2
	{
		#region Properties

		public string ID_ABASTECIMENTO { get; set; }

		public string TANQUE { get; set; }

		public string BOMBA { get; set; }

		public string BICO { get; set; }

		public string COMBUSTIVEL { get; set; }

		public DateTime DATA_ABASTECIMENTO { get; set; }

		public DateTime HORA_ABASTECIMENTO { get; set; }

        public decimal ENCERRANTE_INICIAL
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

        public decimal ENCERRANTE_FINAL
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

		public string STATUS_ABASTECIMENTO { get; set; }

		public string NRO_SERIE_ECF { get; set; }

		public DateTime DATA { get; set; }

		public DateTime HORA { get; set; }

		public int COO { get; set; }

		public int NRO_NOTA_FISCAL { get; set; }

		public decimal VOLUME
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

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}