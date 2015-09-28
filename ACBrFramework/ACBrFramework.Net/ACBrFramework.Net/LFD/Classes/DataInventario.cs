namespace ACBrFramework.LFD
{
	public enum DataInventario
	{
		D0, // 0- Levantado no �ltimo dia do ano civil, coincidente com a data do balan�o
		D1, // 1- Levantado no �ltimo dia do ano civil, divergente da data do balan�o
		D2, // 2- Levantado na data do balan�o, divergente do �ltimo dia do ano civil
		D3 // 3- Levantado em data divergente da data do �ltimo balan�o e do �ltimo dia do ano civil                                
	};
}