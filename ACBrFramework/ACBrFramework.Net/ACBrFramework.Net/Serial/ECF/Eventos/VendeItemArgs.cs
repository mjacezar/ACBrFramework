using System;

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
	[Guid("C14CCCE3-B8EE-4A12-B15F-18F9B2C1218D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class VendeItemEventArgs : EventArgs
	{
		#region Constructor

		internal VendeItemEventArgs(string Codigo, string Descricao, string AliquotaICMS, decimal Qtd, decimal ValorUnitario, decimal ValorDescontoAcrescimo, string Unidade, string TipoDescontoAcrescimo, string DescontoAcrescimo)
		{
			this.Codigo = Codigo;
			this.Descricao = Descricao;
			this.AliquotaICMS = AliquotaICMS;
			this.Qtd = Qtd;
			this.TipoDescontoAcrescimo = TipoDescontoAcrescimo;
			this.ValorUnitario = ValorUnitario;
			this.ValorDescontoAcrescimo = ValorDescontoAcrescimo;
			this.Unidade = Unidade;
			this.TipoDescontoAcrescimo = TipoDescontoAcrescimo;
			this.DescontoAcrescimo = DescontoAcrescimo;
		}

		#endregion Constructor

		#region Properties

		public string Codigo { get; private set; }

		public string Descricao { get; private set; }

		public string AliquotaICMS { get; private set; }

		public decimal Qtd
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public decimal ValorUnitario
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public decimal ValorDescontoAcrescimo
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public string Unidade { get; private set; }

		public string TipoDescontoAcrescimo { get; private set; }

		public string DescontoAcrescimo { get; private set; }

		#endregion Properties
	}
}