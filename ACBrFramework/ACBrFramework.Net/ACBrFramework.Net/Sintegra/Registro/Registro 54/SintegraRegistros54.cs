using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros54 : ICollection<SintegraRegistro54>
	{
		#region Fields

		private List<SintegraRegistro54> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros54()
		{
			this.list = new List<SintegraRegistro54>();
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
		public SintegraRegistro54 this[int index]
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

		public void Add(SintegraRegistro54 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro54[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro54 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro54[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro54 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro54>

		public IEnumerator<SintegraRegistro54> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro54>
	}
}