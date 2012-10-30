using System;

namespace ACBrFramework
{
    public class SintegraRegistro61
    {
        public DateTime Emissao { get; set; }
        public double Valor { get; set; }
        public double ValorIcms { get; set; }
        public double Outras { get; set; }
        public double BaseDeCalculo { get; set; }
        public double Isentas { get; set; }
        public int NumOrdemInicial { get; set; }
        public int NumOrdemFinal { get; set; }
        public string Modelo { get; set; }
        public string SubSerie { get; set; }
        public string Serie { get; set; }
        public double Aliquota { get; set; }
    }
}
