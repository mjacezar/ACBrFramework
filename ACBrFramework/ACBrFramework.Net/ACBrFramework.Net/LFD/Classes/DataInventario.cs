namespace ACBrFramework.LFD
{
	public enum DataInventario
	{
		D0, // 0- Levantado no último dia do ano civil, coincidente com a data do balanço
		D1, // 1- Levantado no último dia do ano civil, divergente da data do balanço
		D2, // 2- Levantado na data do balanço, divergente do último dia do ano civil
		D3 // 3- Levantado em data divergente da data do último balanço e do último dia do ano civil                                
	};
}