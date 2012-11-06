using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros60M : ICollection<SintegraRegistro60M>
	{
		#region Fields

		private List<SintegraRegistro60M> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros60M()
		{
			this.list = new List<SintegraRegistro60M>();
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
		public SintegraRegistro60M this[int index]
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

		public void Add(SintegraRegistro60M item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro60M[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro60M item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro60M[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro60M item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro60M>

		public IEnumerator<SintegraRegistro60M> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro60M>
	}
}