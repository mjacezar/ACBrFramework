using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros61 : ICollection<SintegraRegistro61>
	{
		#region Fields

		private List<SintegraRegistro61> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros61()
		{
			this.list = new List<SintegraRegistro61>();
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
		public SintegraRegistro61 this[int index]
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

		public void Add(SintegraRegistro61 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro61[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro61 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro61[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro61 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro61>

		public IEnumerator<SintegraRegistro61> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro61>
	}
}