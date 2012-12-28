namespace ACBrFramework.Sped
{
	/// Indicador de propriedade/posse do item
	public enum PosseItem
	{
		Informante,           // 0- Item de propriedade do informante e em seu poder;
		InformanteNoTerceiro, // 1- Item de propriedade do informante em posse de terceiros;
		TerceiroNoInformante  // 2- Item de propriedade de terceiros em posse do informante
	};
}