using System;

namespace ACBrFramework.TEFD
{
    public class TEFVeSPagueObtemCampoEventArgs : EventArgs
    {
        #region Constructor

        internal TEFVeSPagueObtemCampoEventArgs(string titulo, string mascara, char tipo)
        {
            this.Titulo = titulo;
            this.Mascara = mascara;
            this.Tipo = tipo;
        }

        #endregion Constructor

        #region Properties

        public string Titulo { get; private set; }

        public string Mascara { get; private set; }

        public char Tipo { get; private set; }

        public string Resposta { get; set; }

        public bool Digitado { get; set; }

        #endregion Properties
    }
}