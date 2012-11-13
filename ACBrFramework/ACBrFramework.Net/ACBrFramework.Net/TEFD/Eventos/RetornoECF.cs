namespace ACBrFramework.TEFD
{
	public enum RetornoECF : int
	{
		Livre = (int)'L',
		VendaDeItens = (int)'V',
		PagamentoOuSubTotal = (int)'P',
		CDC = (int)'C',
		RelatorioGerencial = (int)'G',
		CDCouRelatorioGerencial = (int)'R',
		RecebimentoNaoFiscal = (int)'N',
		Outro = (int)'O'
	}
}