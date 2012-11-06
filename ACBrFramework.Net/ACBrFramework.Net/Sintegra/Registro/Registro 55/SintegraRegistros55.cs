using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros55 : ICollection<SintegraRegistro55>
	{
		#region Fields

		private List<SintegraRegistro55> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros55()
		{
			this.list = new List<SintegraRegistro55>();
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
		public SintegraRegistro55 this[int index]
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

		public void Add(SintegraRegistro55 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro55[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro55 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro55[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro55 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro55>

		public IEnumerator<SintegraRegistro55> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro55>
	}
}