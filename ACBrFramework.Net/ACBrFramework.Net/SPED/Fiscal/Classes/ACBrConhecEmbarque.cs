using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Informação do tipo de conhecimento de embarque
	public enum ACBrConhecEmbarque
	{
		ceAWB,            //01 – AWB;
		ceMAWB,           //02 – MAWB;
		ceHAWB,           //03 – HAWB;
		ceCOMAT,          //04 – COMAT;
		ceRExpressas,     //06 – R. EXPRESSAS;
		ceEtiqREspressas, //07 – ETIQ. REXPRESSAS;
		ceHrExpressas,    //08 – HR. EXPRESSAS;
		ceAV7,            //09 – AV7;
		ceBL,             //10 – BL;
		ceMBL,            //11 – MBL;
		ceHBL,            //12 – HBL;
		ceCTR,            //13 – CRT;
		ceDSIC,           //14 – DSIC;
		ceComatBL,        //16 – COMAT BL;
		ceRWB,            //17 – RWB;
		ceHRWB,           //18 – HRWB;
		ceTifDta,         //19 – TIF/DTA;
		ceCP2,            //20 – CP2;
		ceNaoIATA,        //91 – NÂO IATA;
		ceMNaoIATA,       //92 – MNAO IATA;
		ceHNaoIATA,       //93 – HNAO IATA;
		ceCOutros         //99 – OUTROS.
	};
}
