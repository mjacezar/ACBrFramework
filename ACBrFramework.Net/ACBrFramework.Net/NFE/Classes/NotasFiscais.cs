using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class NotasFiscais : ACBrComposedComponent, IEnumerable<NotaFiscal>
	{
		#region Fields

		#endregion Fields

		#region Constructor

		internal NotasFiscais(ACBrNFE parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public int Count
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NotasFiscais_Count);
			}
		}

		public string GetNamePath
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NotasFiscais_GetNamePath);
			}
		}

		#endregion Properties

		#region Methods

		public NotaFiscal this[int idx]
		{
			get
			{
				if (idx >= Count) throw new IndexOutOfRangeException();
				
				IntPtr nfHandle;
				int ret = ACBrNFEInterop.NFE_NotasFiscais_GetItem(this.Handle, out nfHandle, idx);
				CheckResult(ret);

				return new NotaFiscal(this.Parent, nfHandle);
			}
			set
			{
				int ret = ACBrNFEInterop.NFE_NotasFiscais_SetItem(this.Handle, value.ComposedHandle, idx);
				CheckResult(ret);
			}
		}

		public NotaFiscal Add()
		{
			IntPtr nfHandle;
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Add(this.Handle, out nfHandle);
			CheckResult(ret);

			return new NotaFiscal(this.Parent, nfHandle);
		}

		public NotaFiscal Insert(int idx)
		{
			IntPtr nfHandle;

			int ret = ACBrNFEInterop.NFE_NotasFiscais_Insert(this.Handle, out nfHandle, idx);
			CheckResult(ret);

			return new NotaFiscal(Parent, nfHandle);
		}

		public void Clear()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Clear(this.Handle);
			CheckResult(ret);
		}

		public void Assinar()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Assinar(this.Handle);
			CheckResult(ret);
		}

		public void Valida()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Valida(this.Handle);
			CheckResult(ret);
		}

		public void GerarNFe()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_GerarNFe(this.Handle);
			CheckResult(ret);
		}

		public void ValidaAssinatura(out string MSG)
		{
			MSG = FromUTF8(GetString(ACBrNFEInterop.NFE_NotasFiscais_ValidaAssinatura, 256));
		}

		public void Imprimir()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Imprimir(this.Handle);
			CheckResult(ret);
		}

		public void ImprimirPDF()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_ImprimirPDF(this.Handle);
			CheckResult(ret);
		}

		public bool LoadFromFile(string arquivo)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_LoadFromFile(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool LoadFromString(string xml)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_LoadFromString(this.Handle, ToUTF8(xml));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool SaveToFile(string arquivo, bool txt = false)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_SaveToFile(this.Handle, ToUTF8(arquivo), txt);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool SaveToTXT(string arquivo)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_SaveToTXT(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods

		#region IEnumerable<NotasFiscais>

		public IEnumerator<NotaFiscal> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<NotasFiscais>
	}
}
