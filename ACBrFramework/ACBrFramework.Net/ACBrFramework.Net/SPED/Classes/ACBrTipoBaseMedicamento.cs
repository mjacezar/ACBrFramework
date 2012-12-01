namespace ACBrFramework.SPED
{
	/// Indicador de tipo de referência da base de cálculo do ICMS (ST) do produto farmacêutico
	public enum ACBrTipoBaseMedicamento
	{
		bmCalcTabeladoSugerido,           // 0 - Base de cálculo referente ao preço tabelado ou preço máximo sugerido;
		bmCalMargemAgregado,              // 1 - Base cálculo – Margem de valor agregado;
		bmCalListNegativa,                // 2 - Base de cálculo referente à Lista Negativa;
		bmCalListaPositiva,               // 3 - Base de cálculo referente à Lista Positiva;
		bmCalListNeutra                   // 4 - Base de cálculo referente à Lista Neutra
	};
}