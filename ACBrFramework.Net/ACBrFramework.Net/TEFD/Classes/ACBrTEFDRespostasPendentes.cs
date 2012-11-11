using System;
using System.Collections.Generic;

namespace ACBrFramework.TEFD
{
	public class ACBrTEFDRespostasPendentes : ACBrComposedComponent, IEnumerable<ACBrTEFDRespostaPendente>
	{
		#region Constructor

		internal ACBrTEFDRespostasPendentes(ACBrTEFD parent) : base(parent) { }

		#endregion Constructor

		#region Properties

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

		public ACBrTEFDRespostaPendente this[int index]
		{
			get
			{
				if (index >= Count) throw new IndexOutOfRangeException();
				return new ACBrTEFDRespostaPendente(this, index);
			}
		}

		#endregion Properties

		#region IEnumerable

		public IEnumerator<ACBrTEFDRespostaPendente> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return new ACBrTEFDRespostaPendente(this, i);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable
	}
}