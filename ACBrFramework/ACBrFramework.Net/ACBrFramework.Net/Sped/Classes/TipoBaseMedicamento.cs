namespace ACBrFramework.Sped
{
	/// Indicador de tipo de refer�ncia da base de c�lculo do ICMS (ST) do produto farmac�utico
	public enum TipoBaseMedicamento
	{
		CalcTabeladoSugerido,           // 0 - Base de c�lculo referente ao pre�o tabelado ou pre�o m�ximo sugerido;
		CalMargemAgregado,              // 1 - Base c�lculo � Margem de valor agregado;
		CalListNegativa,                // 2 - Base de c�lculo referente � Lista Negativa;
		CalListaPositiva,               // 3 - Base de c�lculo referente � Lista Positiva;
		CalListNeutra                   // 4 - Base de c�lculo referente � Lista Neutra
	};
}