using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros76 : ICollection<SintegraRegistro76>
	{
		#region Fields

		private List<SintegraRegistro76> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros76()
		{
			this.list = new List<SintegraRegistro76>();
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
		public SintegraRegistro76 this[int index]
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

		public void Add(SintegraRegistro76 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro76[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro76 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro76[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro76 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro76>

		public IEnumerator<SintegraRegistro76> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro76>
	}
}