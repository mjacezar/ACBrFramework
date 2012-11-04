using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistrosH2 : ICollection<ACBrPAFRegistroH2>
	{
		#region Fields

		private List<ACBrPAFRegistroH2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosH2()
		{
			this.list = new List<ACBrPAFRegistroH2>();
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
		public ACBrPAFRegistroH2 this[int index]
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

		public void Add(ACBrPAFRegistroH2 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroH2[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroH2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroH2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroH2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroH2>

		public IEnumerator<ACBrPAFRegistroH2> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroH2>
	}
}