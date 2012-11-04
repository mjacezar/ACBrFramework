using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class SintegraRegistros75 : ICollection<SintegraRegistro75>
	{
		#region Fields

		private List<SintegraRegistro75> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros75()
		{
			this.list = new List<SintegraRegistro75>();
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
		public SintegraRegistro75 this[int index]
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

		public void Add(SintegraRegistro75 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro75[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro75 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro75[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro75 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<SintegraRegistro75>

		public IEnumerator<SintegraRegistro75> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<SintegraRegistro75>
	}
}