using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros56 : ICollection<SintegraRegistro56>
	{
		#region Fields

		private List<SintegraRegistro56> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros56()
		{
			this.list = new List<SintegraRegistro56>();
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
		public SintegraRegistro56 this[int index]
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

		public void Add(SintegraRegistro56 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro56[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro56 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro56[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro56 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro56>

		public IEnumerator<SintegraRegistro56> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro56>
	}
}