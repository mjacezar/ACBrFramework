using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.AAC
{
	public sealed class ACBrAACArquivos : ACBrComposedComponent, IEnumerable<ACBrAACArquivo>
	{
		#region Constructor

		internal ACBrAACArquivos(ACBrECFIdenticacaoPaf identPaf)
			: base(identPaf.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return GetInt32(ACBrAACInterop.AAC_IdentPaf_OutrosArquivos_Count);
			}
		}

		[IndexerName("GetItem")]
		public ACBrAACArquivo this[int index]
		{
			get
			{
				return Get(index);
			}
		}

		#endregion Properties

		#region Methods

		public void New(ACBrAACArquivo aacArquivo)
		{
			ACBrAACInterop.TECFArquivo item = new ACBrAACInterop.TECFArquivo();
			item.NOME_ARQUIVO = ToUTF8(aacArquivo.Nome);
			item.MD5 = ToUTF8(aacArquivo.MD5);

			int ret = ACBrAACInterop.AAC_IdentPaf_OutrosArquivos_New(this.Handle, item);
			CheckResult(ret);
		}

		public void Clear()
		{
			int ret = ACBrAACInterop.AAC_IdentPaf_OutrosArquivos_Clear(this.Handle);
			CheckResult(ret);
		}

		private ACBrAACArquivo Get(int index)
		{
			ACBrAACInterop.TECFArquivo item = new ACBrAACInterop.TECFArquivo();
			int ret = ACBrAACInterop.AAC_IdentPaf_OutrosArquivos_Get(this.Handle, ref item, index);
			CheckResult(ret);

			ACBrAACArquivo aacArquivo = new ACBrAACArquivo();
			aacArquivo.Nome = FromUTF8(item.NOME_ARQUIVO);
			aacArquivo.MD5 = FromUTF8(item.MD5);

			return aacArquivo;
		}

		#endregion Methods

		#region IEnumerable<ACBrAACArquivo>

		public IEnumerator<ACBrAACArquivo> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return Get(i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACArquivo>
	}
}