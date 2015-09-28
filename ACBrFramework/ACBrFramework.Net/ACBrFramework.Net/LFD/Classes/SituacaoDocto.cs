namespace ACBrFramework.LFD
{
	/// Situa��o do Documento
	public enum SituacaoDocto
	{
		Regular,                     // 00 - Documento regular
		ExtempRegular,               // 01 - Escritura��o extempor�nea de documento regular
		Cancelado,                   // 02 - Documento cancelado
		CancelamentoDocAnterior,     // 03 - Cancelamento de cupom fiscal anterior
		CanceladoExtemp,             // 04 - Escritura��o extempor�nea de documento cancelado
		DesfazimentoNegocio,         // 05 - Desfazimento de neg�cio
		DocumentoReferenciado,       // 06 - Documento referenciado
		RegularSimples,              // 07 - Documento regular - Simples Nacional
		ExtempRegularSimples,        // 08 - Documento regular extempor�neo - Simples Nacional
		LancDoctoregular,            // 50 - Lan�amento de documento regular
		LancExtempDoctoRegular,      // 51 - Lan�amento de documento regular extempor�neo
		LancDoctoCancelado,          // 52 - Lan�amento de documento cancelado
		LancCancelamentoDocAnterior, // 53 - Lan�amento de cancelamento de cupom fiscal anterior
		LancCanceladoExtemp,         // 54 - Lan�amento de documento cancelado extempor�neo
		LancDesfazimentoNegocio,     // 55 - Lan�amento de desfazimento de neg�cio
		LancDocumentoReferenciado,   // 56 - Lan�amento de documento referenciado
		LancDoctoOutrasSituacoes,    // 58 - Lan�amento de documento em outras situa��es de repercuss�o nula
		LancDoctoRepercNevativa      // 59 - Lan�amento de documento com repercuss�o negativa  
	};
}