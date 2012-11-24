using System;

namespace ACBrFramework.SPEDFiscal
{
	/// C�digo de tipo de Liga��o
	public enum ACBrTipoLigacao
	{
		tlNenhum,              // '' - Para uso quando o documento for cancelado
		tlMonofasico,          // 1 - Monof�sico
		tlBifasico,            // 2 - Bif�sico
		tlTrifasico            // 3 - Trif�sico
	};
}
