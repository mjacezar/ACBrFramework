using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros60I : ICollection<SintegraRegistro60I>
	{
		#region Fields

		private List<SintegraRegistro60I> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros60I()
		{
			this.list = new List<SintegraRegistro60I>();
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
		public SintegraRegistro60I this[int index]
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

		public void Add(SintegraRegistro60I item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro60I[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro60I item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro60I[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro60I item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro60I>

		public IEnumerator<SintegraRegistro60I> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro60I>
	}
}