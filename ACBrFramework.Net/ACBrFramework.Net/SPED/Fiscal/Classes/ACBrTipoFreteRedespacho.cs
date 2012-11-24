using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador do tipo do frete da operação de redespacho
	public enum ACBrTipoFreteRedespacho
	{
		frSemRedespacho,         // 0 – Sem redespacho
		frPorContaEmitente,      // 1 - Por conta do emitente
		frPorContaDestinatario,  // 2 - Por conta do destinatário
		frOutros,                // 9 – Outros
		frNenhum                 // Preencher vazio
	};
}
