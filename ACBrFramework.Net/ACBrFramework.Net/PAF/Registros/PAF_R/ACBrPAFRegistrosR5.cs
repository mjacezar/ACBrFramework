using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistrosR5 : ICollection<ACBrPAFRegistroR5>
	{
		#region Fields

		private List<ACBrPAFRegistroR5> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR5()
		{
			this.list = new List<ACBrPAFRegistroR5>();
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
		public ACBrPAFRegistroR5 this[int index]
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

		public void Add(ACBrPAFRegistroR5 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR5[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR5 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR5[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR5 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroR5>

		public IEnumerator<ACBrPAFRegistroR5> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroR5>
	}
}