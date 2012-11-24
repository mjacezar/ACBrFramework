using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador do tipo de serviço prestado
	public enum ACBrServicoPrestado
	{
		spTelefonia,                // 0- Telefonia;
		spComunicacaoDados,         // 1- Comunicação de dados;
		spTVAssinatura,             // 2- TV por assinatura;
		spAcessoInternet,           // 3- Provimento de acesso à Internet;
		spMultimidia,               // 4- Multimídia;
		spOutros                    // 9- Outros
	};
}
