using System;

namespace ACBrFramework.TEFD
{
	public class TEFCliSiTefExibeMenuEventArgs : EventArgs
	{
		#region Constructor

		internal TEFCliSiTefExibeMenuEventArgs(string titulo, string[] opcoes)
		{
			this.Titulo = titulo;
			this.Opcoes = opcoes;
		}

		#endregion Constructor

		#region Properties

		public string Titulo { get; private set; }

		public string[] Opcoes { get; private set; }

		public int ItemSelecionado { get; set; }

		public bool VoltarMenu { get; set; }

		#endregion Properties
	}
}