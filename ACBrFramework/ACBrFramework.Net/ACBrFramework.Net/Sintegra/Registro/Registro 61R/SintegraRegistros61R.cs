using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros61R : ICollection<SintegraRegistro61R>
	{
		#region Fields

		private List<SintegraRegistro61R> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros61R()
		{
			this.list = new List<SintegraRegistro61R>();
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
		public SintegraRegistro61R this[int index]
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

		public void Add(SintegraRegistro61R item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro61R[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro61R item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro61R[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro61R item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro61R>

		public IEnumerator<SintegraRegistro61R> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro61R>
	}
}