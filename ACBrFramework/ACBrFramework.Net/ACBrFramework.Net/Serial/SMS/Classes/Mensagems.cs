using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text;

namespace ACBrFramework.SMS
{
	/*
	public class MemsagemItem : ACBrClassInterop
	{
		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSMSInterop.MSG_Create);
		}

		protected override void OnDisposing()
		{
			CallDestroy(ACBrSMSInterop.MSG_Destroy);
		}
	}

	public class MensagensCollection : ACBrListInterop<MemsagemItem>
	{
		public MensagensCollection()
			: base(ACBrSMSInterop.SMS_MSGC_Add, ACBrSMSInterop.SMS_MSGC_Remove, ACBrSMSInterop.SMS_MSGC_Clear)
		{
		}

	}

	public class Program()
	{
		public static void Main()
		{
			MensagensCollection collection = new MensagensCollection();
			
			MemsagemItem item = new MemsagemItem();
			
			collection.Add(item);

			collection.Remove(item);

			collection.Clear();

		}
	}
	*/

	[DesignTimeVisible(false)]
	public class Mensagems : ACBrComponent, ICollection<Mensagem>
	{
		#region Fields

		private List<Mensagem> list;

		#endregion Fields

		#region Constructor

		internal Mensagems()
		{
			this.list = new List<Mensagem>();
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
		public Mensagem this[int index]
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

		public void Add(Mensagem item)
		{
			list.Add(item);
		}

		public void AddRange(Mensagem[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(Mensagem item)
		{
			return list.Contains(item);
		}

		public void CopyTo(Mensagem[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(Mensagem item)
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

				Mensagem item = new Mensagem();
				item.Telefone = FromUTF8(telefone.ToString());
				item.MensagemTexto = FromUTF8(mensagem.ToString());
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

		protected internal override void OnInitialize()
		{
		}

		protected override void OnDisposing()
		{
		}

		#endregion Internal

		#endregion Methods

		#region IEnumerable<ACBrSMSMensagem>

		public IEnumerator<Mensagem> GetEnumerator()
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