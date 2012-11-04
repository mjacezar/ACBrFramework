using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros51 : ICollection<SintegraRegistro51>
	{
		#region Fields

		private List<SintegraRegistro51> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros51()
		{
			this.list = new List<SintegraRegistro51>();
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
		public SintegraRegistro51 this[int index]
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

		public void Add(SintegraRegistro51 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro51[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro51 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro51[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro51 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro51>

		public IEnumerator<SintegraRegistro51> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro51>
	}
}