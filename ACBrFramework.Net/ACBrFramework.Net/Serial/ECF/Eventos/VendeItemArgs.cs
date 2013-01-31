using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C14CCCE3-B8EE-4A12-B15F-18F9B2C1218D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class VendeItemEventArgs : EventArgs
	{
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

		public string Codigo { get; private set; }

		public string Descricao { get; private set; }

		public string AliquotaICMS { get; private set; }

		public decimal Qtd
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			private set; 
		}

		public decimal ValorUnitario
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get; 
			private set; 
		}

		public decimal ValorDescontoAcrescimo
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get; 
			private set; 
		}

		public string Unidade { get; private set; }

		public string TipoDescontoAcrescimo { get; private set; }

		public string DescontoAcrescimo { get; private set; }
	}
}