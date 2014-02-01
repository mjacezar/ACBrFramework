using System;

namespace ACBrFramework.TEFD
{
    public class TEFVeSPagueExibeMenuEventArgs : EventArgs
    {
        #region Constructor

        internal TEFVeSPagueExibeMenuEventArgs(string titulo, string[] opcoes, string[] memo)
        {
            this.Titulo = titulo;
            this.Opcoes = opcoes;
            this.Memo = memo;
        }

        #endregion Constructor

        #region Properties

        public string Titulo { get; private set; }

        public string[] Opcoes { get; private set; }

        public string[] Memo { get; private set; }

        public int ItemSelecionado { get; set; }

        #endregion Properties
    }
}