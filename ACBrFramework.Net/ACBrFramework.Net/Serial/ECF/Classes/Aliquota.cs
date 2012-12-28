namespace ACBrFramework.ECF
{
	public sealed class Aliquota
	{
		public int Sequencia { get; internal set; }

		public string Indice { get; internal set; }

		public decimal ValorAliquota { get; internal set; }

		public string Tipo { get; internal set; }

		public decimal Total { get; internal set; }
	}
}