using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosR3 : ICollection<ACBrPAFRegistroR3>
	{
		#region Fields

		private List<ACBrPAFRegistroR3> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR3()
		{
			this.list = new List<ACBrPAFRegistroR3>();
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
		public ACBrPAFRegistroR3 this[int index]
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

		public void Add(ACBrPAFRegistroR3 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR3[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR3 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR3[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR3 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroR3>

		public IEnumerator<ACBrPAFRegistroR3> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroR3>
	}
}