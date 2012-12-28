namespace ACBrFramework.Sped
{
	/// Informação do tipo de conhecimento de embarque
	public enum ConhecEmbarque
	{
		AWB,            //01 – AWB;
		MAWB,           //02 – MAWB;
		HAWB,           //03 – HAWB;
		COMAT,          //04 – COMAT;
		RExpressas,     //06 – R. EXPRESSAS;
		EtiqREspressas, //07 – ETIQ. REXPRESSAS;
		HrExpressas,    //08 – HR. EXPRESSAS;
		AV7,            //09 – AV7;
		BL,             //10 – BL;
		MBL,            //11 – MBL;
		HBL,            //12 – HBL;
		CTR,            //13 – CRT;
		DSIC,           //14 – DSIC;
		ComatBL,        //16 – COMAT BL;
		RWB,            //17 – RWB;
		HRWB,           //18 – HRWB;
		TifDta,         //19 – TIF/DTA;
		CP2,            //20 – CP2;
		NaoIATA,        //91 – NÂO IATA;
		MNaoIATA,       //92 – MNAO IATA;
		HNaoIATA,       //93 – HNAO IATA;
		COutros         //99 – OUTROS.
	};
}