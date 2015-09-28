namespace ACBrFramework.LFD
{
	public enum TipoCompensacaoISS
	{
		Cancelamento, // 0- Cancelamento de nota fiscal
		GlosaValor, // 1- Glosa de valor faturado
		ErroValor, // 2- Erro de preenchimento de valor faturado
		ErroValorDeclarado, // 3- Erro de preenchimento de valor faturado
		ErroValorDeducao, // 4- Erro de preenchimento de valor de dedução da base de cálculo
		ErroValorISSRetido, // 5- Erro de preenchimento de valor de ISS retido
		Outros // 9- Outros                 
	};
}