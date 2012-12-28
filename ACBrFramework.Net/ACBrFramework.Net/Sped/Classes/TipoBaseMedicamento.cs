namespace ACBrFramework.Sped
{
	/// Indicador de tipo de referência da base de cálculo do ICMS (ST) do produto farmacêutico
	public enum TipoBaseMedicamento
	{
		CalcTabeladoSugerido,           // 0 - Base de cálculo referente ao preço tabelado ou preço máximo sugerido;
		CalMargemAgregado,              // 1 - Base cálculo – Margem de valor agregado;
		CalListNegativa,                // 2 - Base de cálculo referente à Lista Negativa;
		CalListaPositiva,               // 3 - Base de cálculo referente à Lista Positiva;
		CalListNeutra                   // 4 - Base de cálculo referente à Lista Neutra
	};
}