using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.TEFD
{
    public class TEFVeSPague : ACBrComposedComponent
    {
        #region Events

        public event EventHandler<TEFVeSPagueExibeMenuEventArgs> OnExibeMenu
        {
            add
            {
                onExibeMenu.Add(value);
            }
            remove
            {
                onExibeMenu.Remove(value);
            }
        }

        public event EventHandler<TEFVeSPagueObtemCampoEventArgs> OnObtemCampo
        {
            add
            {
                onObtemCampo.Add(value);
            }
            remove
            {
                onObtemCampo.Remove(value);
            }
        }

        #endregion Events

        #region Fields

        private readonly ACBrEventHandler<TEFVeSPagueExibeMenuEventArgs, ACBrTEFInterop.TEFVeSPagueExibeMenuCallback> onExibeMenu;
        private readonly ACBrEventHandler<TEFVeSPagueObtemCampoEventArgs, ACBrTEFInterop.TEFVeSPagueObtemCampoCalback> onObtemCampo;

        #endregion Fields

        #region Constructor

        internal TEFVeSPague(ACBrComponent parent)
            : base(parent)
        {
            onExibeMenu = new ACBrEventHandler<TEFVeSPagueExibeMenuEventArgs, ACBrTEFInterop.TEFVeSPagueExibeMenuCallback>(this, OnTEFVeSPagueExibeMenuCallback, ACBrTEFInterop.TEF_TEFVeSPague_SetOnExibeMenu);
            onObtemCampo = new ACBrEventHandler<TEFVeSPagueObtemCampoEventArgs, ACBrTEFInterop.TEFVeSPagueObtemCampoCalback>(this, OnTEFVeSPagueObtemCampoCalback, ACBrTEFInterop.TEF_TEFVeSPague_SetOnObtemCampo);
        }

        #endregion Constructor

        #region Properties

        public string Aplicacao
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetAplicacao);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetAplicacao, value);
            }
        }

        public string AplicacaoVersao
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetAplicacaoVersao);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetAplicacaoVersao, value);
            }
        }

        public string GPExeName
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetGPExeName);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetGPExeName, value);
            }
        }

        public string GPExeParams
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetGPExeParams);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetGPExeParams, value);
            }
        }

        public string EnderecoIP
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetEnderecoIP);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetEnderecoIP, value);
            }
        }

        public string Porta
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetPorta);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetPorta, value);
            }
        }

        public int TimeOut
        {
            get
            {
                return GetInt32(ACBrTEFInterop.TEF_TEFVeSPague_GetTimeOut);
            }
            set
            {
                SetInt32(ACBrTEFInterop.TEF_TEFVeSPague_SetTimeOut, value);
            }
        }

        public bool TemPendencias
        {
            get
            {
                return GetBool(ACBrTEFInterop.TEF_TEFVeSPague_GetTemPendencias);
            }
            set
            {
                SetBool(ACBrTEFInterop.TEF_TEFVeSPague_SetTemPendencias, value);
            }
        }

        public string TransacaoADM
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoADM);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoADM, value);
            }
        }

        public string TransacaoCRT
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoCRT);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoCRT, value);
            }
        }

        public string TransacaoCHQ
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoCHQ);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoCHQ, value);
            }
        }

        public string TransacaoCNC
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoCNC);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoCNC, value);
            }
        }

        public string TransacaoOpcao
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoOpcao);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoOpcao, value);
            }
        }

        public string TransacaoReImpressao
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoReImpressao);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoReImpressao, value);
            }
        }

        public string TransacaoPendente
        {
            get
            {
                return GetString(ACBrTEFInterop.TEF_TEFVeSPague_GetTransacaoPendente);
            }
            set
            {
                SetString(ACBrTEFInterop.TEF_TEFVeSPague_SetTransacaoPendente, value);
            }
        }

        #endregion Properties

        #region Methods

        #region Interop EventCallbacks

        [AllowReversePInvokeCalls]
        private void OnTEFVeSPagueExibeMenuCallback(string Titulo, IntPtr Opcoes, int OpcoesCount, IntPtr Memo, int MemoCount, ref int ItemSelecionado)
        {
            if (onExibeMenu.IsAssigned)
            {
                string[] opcoes = GetStringArray(Opcoes, OpcoesCount);
                string[] memo = GetStringArray(Memo, MemoCount);

                var e = new TEFVeSPagueExibeMenuEventArgs(Titulo, opcoes, memo);
                onExibeMenu.Raise(e);

                ItemSelecionado = e.ItemSelecionado;
            }
        }

        [AllowReversePInvokeCalls]
        private void OnTEFVeSPagueObtemCampoCalback(string Titulo, string Mascara, char Tipo, ref string Resposta, ref bool Digitado)
        {
            if (onObtemCampo.IsAssigned)
            {
                var e = new TEFVeSPagueObtemCampoEventArgs(Titulo, Mascara, Tipo);
                onObtemCampo.Raise(e);
                Resposta = e.Resposta;
                Digitado = e.Digitado;
            }
        }

        #endregion Interop EventCallbacks

        #endregion Methods
    }
}