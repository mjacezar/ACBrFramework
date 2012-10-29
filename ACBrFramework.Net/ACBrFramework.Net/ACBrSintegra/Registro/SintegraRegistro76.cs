using System;

namespace ACBrFramework
{
    public class SintegraRegistro76
    {
        public double Isentas { get; set; }
        public double ValorTotal { get; set; }
        public double Icms { get; set; }
        public double BasedeCalculo { get; set; }
        public double Outras { get; set; }
        public int Modelo { get; set; }
        public int Numero { get; set; }
        public string Situacao { get; set; }
        public string Inscricao { get; set; }
        public string SubSerie { get; set; }
        public string Uf { get; set; }
        public string Serie { get; set; }
        public string Cfop { get; set; }
        public string CPFCNPJ { get; set; }
        public DateTime DataDocumento { get; set; }
        public ACBrSintegraTipoReceita TipoReceita { get; set; }
        public int Aliquota { get; set; }
    }
}
