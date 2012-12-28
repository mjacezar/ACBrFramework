namespace ACBrFramework.Sped
{
	/// Indicador do tipo do frete
	public enum TipoFrete
	{
		PorContaTerceiros,     // 0 - Por conta de terceiros
		PorContaEmitente,      // 1 - Por conta do emitente
		PorContaDestinatario,  // 2 - Por conta do destinatário
		SemCobrancaFrete,      // 9 - Sem cobrança de frete
		Nenhum                 // Preencher vazio
	};
}