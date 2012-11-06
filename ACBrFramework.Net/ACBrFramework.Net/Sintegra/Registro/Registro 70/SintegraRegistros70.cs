using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros70 : ICollection<SintegraRegistro70>
	{
		#region Fields

		private List<SintegraRegistro70> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros70()
		{
			this.list = new List<SintegraRegistro70>();
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
		public SintegraRegistro70 this[int index]
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

		public void Add(SintegraRegistro70 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro70[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro70 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro70[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro70 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro70>

		public IEnumerator<SintegraRegistro70> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro70>
	}
}