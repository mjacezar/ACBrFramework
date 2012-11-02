using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistroMercadorias : ACBrComposedComponent, IEnumerable<ACBrPAFRegistroMercadoria>
	{
		#region Fields

		internal int position = -1;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistroMercadorias(ACBrPAFPAF_TITP PAF_TITP) : base(PAF_TITP.Parent) { }

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return GetInt32(ACBrPAFInterop.PAF_TITP_Mercadorias_Count);
			}
		}

		[IndexerName("GetItem")]
		public ACBrPAFRegistroMercadoria this[int index]
		{
			get
			{
				return Get(index);
			}
		}

		[Browsable(true)]
		public ACBrPAFRegistroInsumos Insumos { get; private set; }

		#endregion Properties

		#region Methods

		public void New(ACBrPAFRegistroMercadoria mercadoria)
		{
			ACBrPAFInterop.RegistroTITPRec item = new ACBrPAFInterop.RegistroTITPRec();
			item.Codigo = ToUTF8(mercadoria.Codigo);
			item.Descricao = ToUTF8(mercadoria.Descricao);
			item.Aliquota = mercadoria.Aliquota;
			item.Unidade = ToUTF8(mercadoria.Unidade);
			item.Quantidade = mercadoria.Quantidade;
			item.Ean = ToUTF8(mercadoria.Ean);
			item.CST = ToUTF8(mercadoria.CST);
			item.VlrUnitario = mercadoria.VlrUnitario;
			int ret = ACBrPAFInterop.PAF_TITP_Mercadorias_New(this.Handle, item);
			CheckResult(ret);
		}

		public void Clear()
		{
			int ret = ACBrPAFInterop.PAF_TITP_Mercadorias_Clear(this.Handle);
			CheckResult(ret);
		}

		private ACBrPAFRegistroMercadoria Get(int index)
		{
			ACBrPAFInterop.RegistroTITPRec item = new ACBrPAFInterop.RegistroTITPRec();
			int ret = ACBrPAFInterop.PAF_TITP_Mercadorias_Get(this.Handle, ref item, index);
			CheckResult(ret);

			position = index;

			ACBrPAFRegistroMercadoria mercadoria = new ACBrPAFRegistroMercadoria();
			mercadoria.Codigo = FromUTF8(item.Codigo);
			mercadoria.Descricao = FromUTF8(item.Descricao);
			mercadoria.Aliquota = item.Aliquota;
			mercadoria.Unidade = FromUTF8(item.Unidade);
			mercadoria.Quantidade = item.Quantidade;
			mercadoria.Ean = FromUTF8(item.Ean);
			mercadoria.CST = FromUTF8(item.CST);
			mercadoria.VlrUnitario = item.VlrUnitario;
			return mercadoria;
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroMercadoria>

		public IEnumerator<ACBrPAFRegistroMercadoria> GetEnumerator()
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

		#endregion IEnumerable<ACBrPAFRegistroMercadoria>
	}
}