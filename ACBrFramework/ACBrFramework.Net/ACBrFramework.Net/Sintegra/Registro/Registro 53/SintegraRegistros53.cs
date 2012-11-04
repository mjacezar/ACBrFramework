using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros53 : ICollection<SintegraRegistro53>
	{
		#region Fields

		private List<SintegraRegistro53> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros53()
		{
			this.list = new List<SintegraRegistro53>();
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
		public SintegraRegistro53 this[int index]
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

		public void Add(SintegraRegistro53 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro53[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro53 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro53[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro53 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro53>

		public IEnumerator<SintegraRegistro53> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro53>
	}
}