using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.CEP
{
	public class Enderecos : ACBrComposedComponent, IEnumerable<Endereco>
	{
		#region Constructor

		internal Enderecos(ACBrCEP parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public new ACBrCEP Parent
		{
			get
			{
				return (ACBrCEP)base.Parent;
			}
		}

		public int Count
		{
			get
			{
				return GetInt32(ACBrCEPInterop.CEP_Enderecos_GetCount);
			}
		}

		public Endereco this[int index]
		{
			get
			{
				if (index >= Count) throw new IndexOutOfRangeException();

				IntPtr composedHandle;
				int ret = ACBrCEPInterop.CEP_Enderecos_GetItem(this.Handle, this.ComposedHandle, index, out composedHandle);
				CheckResult(ret);

				return new Endereco(this.Parent, composedHandle);
			}
		}

		#endregion Properties

		#region IEnumerable

		public IEnumerator<Endereco> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable
	}
}
