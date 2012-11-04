using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros74 : ICollection<SintegraRegistro74>
	{
		#region Fields

		private List<SintegraRegistro74> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros74()
		{
			this.list = new List<SintegraRegistro74>();
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
		public SintegraRegistro74 this[int index]
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

		public void Add(SintegraRegistro74 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro74[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro74 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro74[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro74 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro74>

		public IEnumerator<SintegraRegistro74> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro74>
	}
}