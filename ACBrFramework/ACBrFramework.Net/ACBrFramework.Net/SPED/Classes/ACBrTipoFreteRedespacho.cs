namespace ACBrFramework.SPED
{
	/// Indicador do tipo do frete da opera��o de redespacho
	public enum ACBrTipoFreteRedespacho
	{
		frSemRedespacho,         // 0 � Sem redespacho
		frPorContaEmitente,      // 1 - Por conta do emitente
		frPorContaDestinatario,  // 2 - Por conta do destinat�rio
		frOutros,                // 9 � Outros
		frNenhum                 // Preencher vazio
	};
}