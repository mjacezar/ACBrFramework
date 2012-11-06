using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros71 : ICollection<SintegraRegistro71>
	{
		#region Fields

		private List<SintegraRegistro71> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros71()
		{
			this.list = new List<SintegraRegistro71>();
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
		public SintegraRegistro71 this[int index]
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

		public void Add(SintegraRegistro71 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro71[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro71 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro71[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro71 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro71>

		public IEnumerator<SintegraRegistro71> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro71>
	}
}