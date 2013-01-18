using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class Ide
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

		public virtual int cUF { get; set; }
		public virtual int cNF { get; set; }
		public virtual string natOp { get; set; }
		public virtual IndicadorPagamento indPag { get; set; }
		public virtual int modelo { get; set; }
		public virtual int serie { get; set; }
		public virtual int nNF { get; set; }
		public virtual DateTime dEmi { get; set; }
		public virtual DateTime dSaiEnt { get; set; }
		public virtual DateTime hSaiEnt { get; set; }
		public virtual TipoNFe tpNF { get; set; }
		public virtual int cMunFG { get; set; }
		public virtual List<NFrefCollectionItem> NFrefCollection { get; private set; }
		public virtual RefNFP refNFP { get; private set; }
		public virtual TipoImpressao tpImp { get; set; }
		public virtual TipoEmissao tpEmis { get; set; }
		public virtual int cDV { get; set; }
		public virtual TipoAmbiente tpAmb { get; set; }
		public virtual FinalidadeNFe finNFe { get; set; }
		public virtual ProcessoEmissao procEmi { get; set; }
		public virtual string verProc { get; set; }
		public virtual DateTime dhCont { get; set; }
		public virtual string xJust { get; set; }
	}
}
