using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros77 : ICollection<SintegraRegistro77>
	{
		#region Fields

		private List<SintegraRegistro77> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros77()
		{
			this.list = new List<SintegraRegistro77>();
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
		public SintegraRegistro77 this[int index]
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

		public void Add(SintegraRegistro77 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro77[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro77 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro77[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro77 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro77>

		public IEnumerator<SintegraRegistro77> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro77>
	}
}