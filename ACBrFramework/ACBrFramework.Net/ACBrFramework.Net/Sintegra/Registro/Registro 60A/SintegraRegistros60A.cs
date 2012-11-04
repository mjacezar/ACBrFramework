using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros60A : ICollection<SintegraRegistro60A>
	{
		#region Fields

		private List<SintegraRegistro60A> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros60A()
		{
			this.list = new List<SintegraRegistro60A>();
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
		public SintegraRegistro60A this[int index]
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

		public void Add(SintegraRegistro60A item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro60A[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro60A item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro60A[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro60A item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro60A>

		public IEnumerator<SintegraRegistro60A> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro60A>
	}
}