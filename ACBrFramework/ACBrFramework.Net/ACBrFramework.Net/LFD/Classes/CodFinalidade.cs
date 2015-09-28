namespace ACBrFramework.LFD
{
	/// Código da finalidade do arquivo - TRegistro0000
	public enum CodFinalidade
	{
		Regular,                       // 00 - Remessa regular do arquivo original
		Substituto,                    // 01 - Remessa do arquivo substituto
		DadosAdicionais,               // 02 - Remessa de arquivo com dados adicionais a arquivo anteriormente remetido
		IntimacaoEsp,                  // 03 - Remessa de arquivo requerido por intimação específica
		CorrecaoIDP,                   // 04 - Remessa de arquivo requerido para correção do Índice de Participação dos Municípios
		PubDiarioOficial,              // 05 - Remessa de arquivo requerido por ato publicado no Diário Oficial
		SintegraRegular,               // 15 - Sintegra - remessa regular de arquivo das operações interestaduais
		SintegraSubstituto,            // 16 - Sintegra - remessa de arquivo substituto das operações interestaduais
		SintegraDadosAdicionais,       // 17 - Sintegra - remessa de arquivo com dados adicionais das operações interestaduais
		SintegraRegularICMSST,         // 18 - Sintegra - remessa regular de arquivo das operações interestaduais com substituição tributária do ICMS
		SintegraSubstitutoICMSST,      // 19 - Sintegra - remessa de arquivo substituto das operações interestaduais com substituição tributária do ICMS
		SintegraDadosAdicionaisICMSST, // 20 - Sintegra - remessa de arquivo com dados adicionais das operações interestaduais com substituição tributária do ICMS
		RegularSefin,                  // 25 - Remessa para a Sefin/Mun de arquivo de retenções do ISS efetuadas por terceiros
		SubstitutoSefin,               // 26 - Remessa para a Sefin/Mun de arquivo substituto de retenções do ISS efetuadas por terceiros
		DadosAdicionaisSefin,          // 27 - Remessa para a Sefin/Mun de arquivo com dados adicionais de retenções do ISS efetuadas por terceiros
		EmissaoDocumento,              // 30 - Emissão de documento
		EmissaoDocAvulso,              // 31 - Emissão de documento fiscal avulso por repartição fiscal
		SolicAuditorFical,             // 61 - Solicitação de Auditor-Fiscal da Secretaria da Receita Previdenciária através de MPF
		EntregaSecretariaReceita,      // 62 - Entrega na Secretaria da Receita Previdenciária - movimento anual de órgão público, conforme intimação
		InfComplementarSefaz           // 90 - Remessa de informações complementares para a Sefaz da unidade da federação de origem 
	};
}