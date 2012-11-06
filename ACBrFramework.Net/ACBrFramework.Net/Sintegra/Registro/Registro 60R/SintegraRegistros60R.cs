using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros60R : ICollection<SintegraRegistro60R>
	{
		#region Fields

		private List<SintegraRegistro60R> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros60R()
		{
			this.list = new List<SintegraRegistro60R>();
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
		public SintegraRegistro60R this[int index]
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

		public void Add(SintegraRegistro60R item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro60R[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro60R item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro60R[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro60R item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro60R>

		public IEnumerator<SintegraRegistro60R> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro60R>
	}
}