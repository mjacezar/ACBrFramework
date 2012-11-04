using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros85 : ICollection<SintegraRegistro85>
	{
		#region Fields

		private List<SintegraRegistro85> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros85()
		{
			this.list = new List<SintegraRegistro85>();
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
		public SintegraRegistro85 this[int index]
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

		public void Add(SintegraRegistro85 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro85[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro85 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro85[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro85 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro85>

		public IEnumerator<SintegraRegistro85> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro85>
	}
}