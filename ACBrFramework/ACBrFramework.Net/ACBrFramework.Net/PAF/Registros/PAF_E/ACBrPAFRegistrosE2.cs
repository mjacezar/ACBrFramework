using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistrosE2 : ICollection<ACBrPAFRegistroE2>
	{
		#region Fields

		private List<ACBrPAFRegistroE2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosE2()
		{
			this.list = new List<ACBrPAFRegistroE2>();
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
		public ACBrPAFRegistroE2 this[int index]
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

		public void Add(ACBrPAFRegistroE2 registroe2)
		{
			list.Add(registroe2);
		}

		public void AddRange(ACBrPAFRegistroE2[] registrose2)
		{
			list.AddRange(registrose2);
		}

		public bool Contains(ACBrPAFRegistroE2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroE2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroE2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroE2>

		public IEnumerator<ACBrPAFRegistroE2> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroE2>
	}
}