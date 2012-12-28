using System;
using System.Collections.Generic;

namespace ACBrFramework.TEFD
{
	public class RespostasPendentes : ACBrComposedComponent, IEnumerable<Resp>
	{
		#region Constructor

		internal RespostasPendentes(ACBrTEFD parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public new ACBrTEFD Parent
		{
			get
			{
				return (ACBrTEFD)base.Parent;
			}
		}

		public int Count
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetCount);
			}
		}

		public decimal SaldoRestante
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetSaldoRestante);
			}
		}

		public decimal TotalDesconto
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetTotalDesconto);
			}
		}

		public decimal TotalPago
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetTotalPago);
			}
		}

		public decimal SaldoAPagar
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetSaldoAPagar);
			}
		}

		public Resp this[int index]
		{
			get
			{
				if (index >= Count) throw new IndexOutOfRangeException();

				IntPtr composedHandle;
				int ret = ACBrTEFInterop.TEF_RespostasPendentes_GetItem(this.Handle, this.ComposedHandle, index, out composedHandle);
				CheckResult(ret);

				return new Resp(this.Parent, composedHandle);
			}
		}

		#endregion Properties

		#region IEnumerable

		public IEnumerator<Resp> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable
	}
}