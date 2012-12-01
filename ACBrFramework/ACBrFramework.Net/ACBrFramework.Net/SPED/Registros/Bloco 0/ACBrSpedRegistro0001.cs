namespace ACBrFramework.SPED.Blocos.Bloco0
{
	public class ACBrSpedRegistro0001
	{
		public ACBrSpedRegistro0001()
		{
			this.Registro0005 = new ACBrSpedRegistro0005();
			this.Registro0015List = new ACBrSpedRegistro0015List();
			this.Registro0100 = new ACBrSpedRegistro0100();
		}

		public ACBrCodFinalidade COD_FIN { get; set; }

		public ACBrSpedRegistro0005 Registro0005 { get; private set; }

		public ACBrSpedRegistro0015List Registro0015List { get; private set; }

		public ACBrSpedRegistro0100 Registro0100 { get; private set; }
	}
}