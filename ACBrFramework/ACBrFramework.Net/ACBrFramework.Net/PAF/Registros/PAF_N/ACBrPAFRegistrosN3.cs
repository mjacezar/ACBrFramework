using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosN3 : ICollection<ACBrPAFRegistroN3>
	{
		#region Fields

		private List<ACBrPAFRegistroN3> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosN3()
		{
			this.list = new List<ACBrPAFRegistroN3>();
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
		public ACBrPAFRegistroN3 this[int index]
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

		public void Add(ACBrPAFRegistroN3 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroN3[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroN3 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroN3[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroN3 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroN3>

		public IEnumerator<ACBrPAFRegistroN3> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroN3>
	}
}