using System;

namespace ACBrFramework.ECF
{
	public class VendeItemArgs : EventArgs
	{
		internal VendeItemArgs(string Codigo, string Descricao, string AliquotaICMS, decimal Qtd, decimal ValorUnitario, decimal ValorDescontoAcrescimo, string Unidade, string TipoDescontoAcrescimo, string DescontoAcrescimo)
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
		public decimal Qtd { get; set; }
		public decimal ValorUnitario { get; private set; }
		public decimal ValorDescontoAcrescimo { get; private set; }
		public string Unidade { get; private set; }
		public string TipoDescontoAcrescimo { get; private set; }
		public string DescontoAcrescimo { get; private set; }
	}
}
