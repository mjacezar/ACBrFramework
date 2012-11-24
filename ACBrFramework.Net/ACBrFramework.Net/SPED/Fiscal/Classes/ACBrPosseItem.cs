using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador de propriedade/posse do item
	public enum ACBrPosseItem
	{
		piInformante,           // 0- Item de propriedade do informante e em seu poder;
		piInformanteNoTerceiro, // 1- Item de propriedade do informante em posse de terceiros;
		piTerceiroNoInformante  // 2- Item de propriedade de terceiros em posse do informante
	};
}
