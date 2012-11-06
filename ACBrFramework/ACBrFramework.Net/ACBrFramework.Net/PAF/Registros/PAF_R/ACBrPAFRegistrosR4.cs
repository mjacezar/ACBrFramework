using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosR4 : ICollection<ACBrPAFRegistroR4>
	{
		#region Fields

		private List<ACBrPAFRegistroR4> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR4()
		{
			this.list = new List<ACBrPAFRegistroR4>();
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
		public ACBrPAFRegistroR4 this[int index]
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

		public void Add(ACBrPAFRegistroR4 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR4[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR4 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR4[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR4 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroR4>

		public IEnumerator<ACBrPAFRegistroR4> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroR4>
	}
}