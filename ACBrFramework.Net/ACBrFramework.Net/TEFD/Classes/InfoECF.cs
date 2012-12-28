namespace ACBrFramework.TEFD
{
	#region Documentation

	/// <summary>
	///Valor do Saldo restante "A Pagar" do Cupom
	///Estado do ECF "L" Livre, "V" Em Venda de Itens,
	///"P" Em Pagamento,
	///"C" CDC ou Vinculado
	///"G" Relatório Gerencial
	///"N" Não Fiscal (em qq fase, pois é dificil detectar a fase)
	///"O" Outro
	///Valor Total de Pagamentos registrados, na Aplicação, e não enviados ao ECF
	/// </summary>

	#endregion Documentation

	public enum InfoECF : int
	{
		SubTotal,
		EstadoECF,
		TotalAPagar
	}
}