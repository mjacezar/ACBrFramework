namespace ACBrFramework.SPED
{
	public class ACBrSpedRegistro0001
	{
		public ACBrSpedRegistro0001()
		{
			this.Registro0005 = new ACBrSpedRegistro0005();
			this.Registro0015 = new ACBrSpedRegistro0015List();
			this.Registro0100 = new ACBrSpedRegistro0100();
            this.Registro0150 = new ACBrSpedRegistro0150List();
			this.Registro0190 = new ACBrSpedRegistro0190List();
		}

		public ACBrCodFinalidade COD_FIN { get; set; }

		public ACBrSpedRegistro0005 Registro0005 { get; private set; }

		public ACBrSpedRegistro0015List Registro0015 { get; private set; }

		public ACBrSpedRegistro0100 Registro0100 { get; private set; }

        public ACBrSpedRegistro0150List Registro0150 { get; private set; }

		public ACBrSpedRegistro0190List Registro0190 { get; private set; }
	}
}