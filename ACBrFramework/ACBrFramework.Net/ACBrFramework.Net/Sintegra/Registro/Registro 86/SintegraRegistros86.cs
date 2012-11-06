using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistros86 : ICollection<SintegraRegistro86>
	{
		#region Fields

		private List<SintegraRegistro86> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros86()
		{
			this.list = new List<SintegraRegistro86>();
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
		public SintegraRegistro86 this[int index]
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

		public void Add(SintegraRegistro86 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro86[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro86 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro86[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro86 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro86>

		public IEnumerator<SintegraRegistro86> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro86>
	}
}