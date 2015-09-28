namespace ACBrFramework.LFD
{
	/// C�digo da finalidade do arquivo - TRegistro0000
	public enum CodFinalidade
	{
		Regular,                       // 00 - Remessa regular do arquivo original
		Substituto,                    // 01 - Remessa do arquivo substituto
		DadosAdicionais,               // 02 - Remessa de arquivo com dados adicionais a arquivo anteriormente remetido
		IntimacaoEsp,                  // 03 - Remessa de arquivo requerido por intima��o espec�fica
		CorrecaoIDP,                   // 04 - Remessa de arquivo requerido para corre��o do �ndice de Participa��o dos Munic�pios
		PubDiarioOficial,              // 05 - Remessa de arquivo requerido por ato publicado no Di�rio Oficial
		SintegraRegular,               // 15 - Sintegra - remessa regular de arquivo das opera��es interestaduais
		SintegraSubstituto,            // 16 - Sintegra - remessa de arquivo substituto das opera��es interestaduais
		SintegraDadosAdicionais,       // 17 - Sintegra - remessa de arquivo com dados adicionais das opera��es interestaduais
		SintegraRegularICMSST,         // 18 - Sintegra - remessa regular de arquivo das opera��es interestaduais com substitui��o tribut�ria do ICMS
		SintegraSubstitutoICMSST,      // 19 - Sintegra - remessa de arquivo substituto das opera��es interestaduais com substitui��o tribut�ria do ICMS
		SintegraDadosAdicionaisICMSST, // 20 - Sintegra - remessa de arquivo com dados adicionais das opera��es interestaduais com substitui��o tribut�ria do ICMS
		RegularSefin,                  // 25 - Remessa para a Sefin/Mun de arquivo de reten��es do ISS efetuadas por terceiros
		SubstitutoSefin,               // 26 - Remessa para a Sefin/Mun de arquivo substituto de reten��es do ISS efetuadas por terceiros
		DadosAdicionaisSefin,          // 27 - Remessa para a Sefin/Mun de arquivo com dados adicionais de reten��es do ISS efetuadas por terceiros
		EmissaoDocumento,              // 30 - Emiss�o de documento
		EmissaoDocAvulso,              // 31 - Emiss�o de documento fiscal avulso por reparti��o fiscal
		SolicAuditorFical,             // 61 - Solicita��o de Auditor-Fiscal da Secretaria da Receita Previdenci�ria atrav�s de MPF
		EntregaSecretariaReceita,      // 62 - Entrega na Secretaria da Receita Previdenci�ria - movimento anual de �rg�o p�blico, conforme intima��o
		InfComplementarSefaz           // 90 - Remessa de informa��es complementares para a Sefaz da unidade da federa��o de origem 
	};
}