using System;
using System.Text;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class NotasFiscais : ACBrComposedComponent
	{
		#region Fields

		private List<NotaFiscal> Item { get; private set; }

		#endregion Fields

		#region Constructor

		internal NotasFiscais(ACBrNFE parent)
			: base(parent)
		{
			this.Item = new List<NotaFiscal>();
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
				return Item[idx];
			}
			set
			{
				int ret = ACBrNFEInterop.NFE_NotasFiscais_SetItem(this.Parent.Handle, ((NotaFiscal)value).ComposedHandle, idx);
				CheckResult(ret);

				Item[idx] = value;
			}
		}

		public NotaFiscal Add()
		{
			IntPtr nfHandle = new IntPtr();

			int ret = ACBrNFEInterop.NFE_NotasFiscais_Add(Parent.Handle, ref nfHandle);
			CheckResult(ret);

			NotaFiscal nf = new NotaFiscal(this.Parent, nfHandle);
			Item.Add(nf);

			return nf;
		}

		public NotaFiscal Insert(int idx)
		{
			IntPtr nfHandle = new IntPtr();

			int ret = ACBrNFEInterop.NFE_NotasFiscais_Insert(Parent.Handle, ref nfHandle, idx);
			CheckResult(ret);

			NotaFiscal nf = new NotaFiscal(Parent, nfHandle);
			Item.Insert(idx, nf);			

			return nf;
		}

		public void Clear()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Clear(Parent.Handle);
			CheckResult(ret);

			Item.Clear();
		}

		public void Assinar()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Assinar(Parent.Handle);
			CheckResult(ret);
		}

		public void Valida()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Valida(Parent.Handle);
			CheckResult(ret);
		}

		public void GerarNFe()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_GerarNFe(Parent.Handle);
			CheckResult(ret);
		}

		public void ValidaAssinatura(out string MSG)
		{
			const int buffelen = 256;
			StringBuilder buffer = new StringBuilder(buffelen);

			int ret = ACBrNFEInterop.NFE_NotasFiscais_ValidaAssinatura(Parent.Handle, buffer, buffelen);
			CheckResult(ret);

			MSG = FromUTF8(buffer.ToString());
		}

		public void Imprimir()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_Imprimir(Parent.Handle);
			CheckResult(ret);
		}

		public void ImprimirPDF()
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_ImprimirPDF(Parent.Handle);
			CheckResult(ret);
		}

		public void LoadFromFile(string arquivo)
		{
			IntPtr nfHandle = new IntPtr();

			int ret = ACBrNFEInterop.NFE_NotasFiscais_LoadFromFile(Parent.Handle, arquivo, ref nfHandle);
			CheckResult(ret);

			NotaFiscal nf = new NotaFiscal(this.Parent, nfHandle);
			Item.Add(nf);
		}

		public void LoadFromString(string arquivo)
		{
			IntPtr nfHandle = new IntPtr();

			int ret = ACBrNFEInterop.NFE_NotasFiscais_LoadFromString(Parent.Handle, arquivo, ref nfHandle);
			CheckResult(ret);

			NotaFiscal nf = new NotaFiscal(this.Parent, nfHandle);
			Item.Add(nf);
		}

		public void SaveToFile(string arquivo, bool txt = false)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_SaveToFile(Parent.Handle, arquivo, txt);
			CheckResult(ret);
		}

		public void SaveToTXT(string arquivo)
		{
			int ret = ACBrNFEInterop.NFE_NotasFiscais_SaveToTXT(Parent.Handle, arquivo);
			CheckResult(ret);
		}

		#endregion Methods
	}
}
