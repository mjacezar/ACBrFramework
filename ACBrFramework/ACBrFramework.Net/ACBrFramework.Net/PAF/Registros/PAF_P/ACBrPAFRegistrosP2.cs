using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosP2 : ICollection<ACBrPAFRegistroP2>
	{
		#region Fields

		private List<ACBrPAFRegistroP2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosP2()
		{
			this.list = new List<ACBrPAFRegistroP2>();
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
		public ACBrPAFRegistroP2 this[int index]
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

		public void Add(ACBrPAFRegistroP2 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroP2[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroP2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroP2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroP2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroP2>

		public IEnumerator<ACBrPAFRegistroP2> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroP2>
	}
}