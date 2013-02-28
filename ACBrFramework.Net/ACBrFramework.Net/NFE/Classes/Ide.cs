using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Ide
	{
		public Ide()
		{
			this.NFrefCollection = new List<NFrefCollectionItem>();
			this.refNFP = new RefNFP();
			this.indPag = IndicadorPagamento.Prazo;
			this.tpNF = TipoNFe.Saida;
			this.tpImp = TipoImpressao.Paisagem;
			this.tpEmis = TipoEmissao.Normal;
			this.tpAmb = TipoAmbiente.Homologacao;
			this.finNFe = FinalidadeNFe.Normal;
			this.procEmi = ProcessoEmissao.AplicativoContribuinte;
		}

		public int cUF { get; set; }
		public int cNF { get; set; }
		public string natOp { get; set; }
		public IndicadorPagamento indPag { get; set; }
		public int modelo { get; set; }
		public int serie { get; set; }
		public int nNF { get; set; }
		public DateTime dEmi { get; set; }
		public DateTime dSaiEnt { get; set; }
		public DateTime hSaiEnt { get; set; }
		public TipoNFe tpNF { get; set; }
		public int cMunFG { get; set; }
		public List<NFrefCollectionItem> NFrefCollection { get; private set; }
		public RefNFP refNFP { get; private set; }
		public TipoImpressao tpImp { get; set; }
		public TipoEmissao tpEmis { get; set; }
		public int cDV { get; set; }
		public TipoAmbiente tpAmb { get; set; }
		public FinalidadeNFe finNFe { get; set; }
		public ProcessoEmissao procEmi { get; set; }
		public string verProc { get; set; }
		public DateTime dhCont { get; set; }
		public string xJust { get; set; }
	}
}