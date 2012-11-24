using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Código de tipo de Ligação
	public enum ACBrTipoLigacao
	{
		tlNenhum,              // '' - Para uso quando o documento for cancelado
		tlMonofasico,          // 1 - Monofásico
		tlBifasico,            // 2 - Bifásico
		tlTrifasico            // 3 - Trifásico
	};
}
