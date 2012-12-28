using System;

namespace ACBrFramework.TEFD
{
	public class TEFCliSiTefObtemCampoEventArgs : EventArgs
	{
		#region Constructor

		internal TEFCliSiTefObtemCampoEventArgs(string titulo, int tamanhoMinimo, int tamanhoMaximo, int tipoCampo, TefCliSiTefOperacaoCampo operacao)
		{
			this.Titulo = titulo;
			this.TamanhoMinimo = tamanhoMinimo;
			this.TamanhoMaximo = tamanhoMaximo;
			this.TipoCampo = tipoCampo;
			this.Operacao = operacao;
		}

		#endregion Constructor

		#region Properties

		public string Titulo { get; private set; }

		public int TamanhoMinimo { get; private set; }

		public int TamanhoMaximo { get; private set; }

		public int TipoCampo { get; private set; }

		public TefCliSiTefOperacaoCampo Operacao { get; private set; }

		public string Resposta { get; set; }

		public bool Digitado { get; set; }

		public bool VoltarMenu { get; set; }

		#endregion Properties
	}
}