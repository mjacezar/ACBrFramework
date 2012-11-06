using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros60D : ICollection<SintegraRegistro60D>
	{
		#region Fields

		private List<SintegraRegistro60D> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros60D()
		{
			this.list = new List<SintegraRegistro60D>();
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
		public SintegraRegistro60D this[int index]
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

		public void Add(SintegraRegistro60D item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro60D[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro60D item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro60D[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro60D item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro60D>

		public IEnumerator<SintegraRegistro60D> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro60D>
	}
}