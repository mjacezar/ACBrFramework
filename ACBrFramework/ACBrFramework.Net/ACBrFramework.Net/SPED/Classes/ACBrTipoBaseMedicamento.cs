namespace ACBrFramework.SPED
{
	/// Indicador de tipo de refer�ncia da base de c�lculo do ICMS (ST) do produto farmac�utico
	public enum ACBrTipoBaseMedicamento
	{
		bmCalcTabeladoSugerido,           // 0 - Base de c�lculo referente ao pre�o tabelado ou pre�o m�ximo sugerido;
		bmCalMargemAgregado,              // 1 - Base c�lculo � Margem de valor agregado;
		bmCalListNegativa,                // 2 - Base de c�lculo referente � Lista Negativa;
		bmCalListaPositiva,               // 3 - Base de c�lculo referente � Lista Positiva;
		bmCalListNeutra                   // 4 - Base de c�lculo referente � Lista Neutra
	};
}