namespace ACBrFramework.Sped
{
	/// Indicador do tipo do frete da operação de redespacho
	public enum TipoFreteRedespacho
	{
		SemRedespacho,         // 0 – Sem redespacho
		PorContaEmitente,      // 1 - Por conta do emitente
		PorContaDestinatario,  // 2 - Por conta do destinatário
		Outros,                // 9 – Outros
		Nenhum                 // Preencher vazio
	};
}