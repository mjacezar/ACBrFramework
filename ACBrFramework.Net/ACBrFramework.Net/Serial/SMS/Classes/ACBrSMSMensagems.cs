using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACBrFramework.SMS
{
    public class ACBrSMSMensagems : ACBrComponent, ICollection<ACBrSMSMensagem>
    {
        #region Fields

        private List<ACBrSMSMensagem> list;

        #endregion Fields

        #region Constructor

        internal ACBrSMSMensagems()
        {
            this.list = new List<ACBrSMSMensagem>();
        }

        #endregion Constructor

        #region Properties

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        [IndexerName("GetItem")]
        public ACBrSMSMensagem this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        #endregion Properties

        #region Methods

        public void Add(ACBrSMSMensagem item)
        {
            list.Add(item);
        }

        public void AddRange(ACBrSMSMensagem[] item)
        {
            list.AddRange(item);
        }

        public bool Contains(ACBrSMSMensagem item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ACBrSMSMensagem[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrSMSMensagem item)
        {
            return list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public void LoadFromFrile(string arquivo)
        {
            const int bufferLen = 512;
            Iniciar();    
            int ret = ACBrSMSInterop.MSG_LoadFromFrile(this.Handle, arquivo);
            CheckResult(ret);            

            for (int i = 0; i < ret; i++)
            {                
                StringBuilder telefone = new StringBuilder(bufferLen);
                StringBuilder mensagem = new StringBuilder(bufferLen);
                int resp = ACBrSMSInterop.MSG_GetMessage(this.Handle, telefone, mensagem, bufferLen, i);
                CheckResult(resp);

                ACBrSMSMensagem item = new ACBrSMSMensagem();
                item.Telefone = FromUTF8(telefone.ToString());
                item.Mensagem = FromUTF8(mensagem.ToString());
                Add(item);
            }
            Finalizar();            
        }

        #region Internal

        protected internal void Iniciar()
        {
            CallCreate(ACBrSMSInterop.MSG_Create);
        }

        protected internal void Finalizar()
        {
            CallDestroy(ACBrSMSInterop.MSG_Destroy);
        }

        protected internal override void CheckResult(int ret)
        {
            switch (ret)
            {
                case -1:
                    const int BUFFER_LEN = 1024;
                    string error = GetString(ACBrSMSInterop.MSG_GetUltimoErro, BUFFER_LEN);
                    throw new ACBrException(error);

                case -2:
                    throw new ACBrException("ACBr MSG não inicializado.");
            }
        }

        protected internal override void OnInitializeComponent()
        {
        }

        protected override void OnDisposing()
        {
        }

        #endregion Internal

        #endregion Methods

        #region IEnumerable<ACBrSMSMensagem>

        public IEnumerator<ACBrSMSMensagem> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrSMSMensagem>
    }
}
