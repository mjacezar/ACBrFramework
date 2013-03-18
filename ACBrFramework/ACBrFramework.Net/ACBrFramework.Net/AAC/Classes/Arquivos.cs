using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("E2B492E7-B180-41AB-A922-484DE27A5281")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Arquivos : ACBrComposedComponent, IEnumerable<Arquivo>
	{
		#region Constructor

		internal Arquivos(IdenticacaoPaf identPaf)
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
		public Arquivo this[int index]
		{
			get
			{
				return Get(index);
			}
		}

		#endregion Properties

		#region Methods

		public void New(Arquivo aacArquivo)
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

		private Arquivo Get(int index)
		{
			ACBrAACInterop.TECFArquivo item = new ACBrAACInterop.TECFArquivo();
			int ret = ACBrAACInterop.AAC_IdentPaf_OutrosArquivos_Get(this.Handle, ref item, index);
			CheckResult(ret);

			Arquivo aacArquivo = new Arquivo();
			aacArquivo.Nome = FromUTF8(item.NOME_ARQUIVO);
			aacArquivo.MD5 = FromUTF8(item.MD5);

			return aacArquivo;
		}

		#endregion Methods

		#region IEnumerable<ACBrAACArquivo>

		IEnumerator<Arquivo> IEnumerable<Arquivo>.GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return Get(i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Arquivo>)this).GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACArquivo>

		
	}
}