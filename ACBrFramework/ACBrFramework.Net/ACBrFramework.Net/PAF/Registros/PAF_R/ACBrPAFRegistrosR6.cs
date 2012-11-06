using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosR6 : ICollection<ACBrPAFRegistroR6>
	{
		#region Fields

		private List<ACBrPAFRegistroR6> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR6()
		{
			this.list = new List<ACBrPAFRegistroR6>();
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
		public ACBrPAFRegistroR6 this[int index]
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

		public void Add(ACBrPAFRegistroR6 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR6[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR6 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR6[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR6 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroR6>

		public IEnumerator<ACBrPAFRegistroR6> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroR6>
	}
}