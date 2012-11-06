using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosR7 : ICollection<ACBrPAFRegistroR7>
	{
		#region Fields

		private List<ACBrPAFRegistroR7> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR7()
		{
			this.list = new List<ACBrPAFRegistroR7>();
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
		public ACBrPAFRegistroR7 this[int index]
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

		public void Add(ACBrPAFRegistroR7 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR7[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR7 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR7[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR7 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroR7>

		public IEnumerator<ACBrPAFRegistroR7> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroR7>
	}
}