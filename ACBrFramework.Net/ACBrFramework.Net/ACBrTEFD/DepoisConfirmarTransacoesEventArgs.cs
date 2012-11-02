﻿using System;

namespace ACBrFramework.ACBrTEFD
{
	public class DepoisConfirmarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisConfirmarTransacoesEventArgs(object respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public object RespostasPendentes { get; private set; }

		#endregion Properties
	}
}