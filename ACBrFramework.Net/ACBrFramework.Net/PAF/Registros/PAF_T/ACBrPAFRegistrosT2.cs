using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistrosT2 : ICollection<ACBrPAFRegistroT2>
	{
		#region Fields

		private List<ACBrPAFRegistroT2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosT2()
		{
			this.list = new List<ACBrPAFRegistroT2>();
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
		public ACBrPAFRegistroT2 this[int index]
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

		public void Add(ACBrPAFRegistroT2 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroT2[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(ACBrPAFRegistroT2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroT2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroT2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroT2>

		public IEnumerator<ACBrPAFRegistroT2> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroT2>
	}
}