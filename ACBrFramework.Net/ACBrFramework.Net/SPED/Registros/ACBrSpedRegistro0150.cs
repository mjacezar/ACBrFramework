namespace ACBrFramework.SPED
{
    public sealed class ACBrSpedRegistro0150
    {
        public ACBrSpedRegistro0150()
        {
            this.Registro0175 = new ACBrSpedRegistro0175List();
        }

        public string COD_PART { get; set; }
        public string NOME { get; set; }
        public string COD_PAIS { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string IE { get; set; }
        public int COD_MUN { get; set; }
        public string SUFRAMA { get; set; }
        public string ENDERECO { get; set; }
        public string NUM { get; set; }
        public string COMPL { get; set; }
        public string BAIRRO { get; set; }

        public ACBrSpedRegistro0175List Registro0175 { get; private set; }
    }
}