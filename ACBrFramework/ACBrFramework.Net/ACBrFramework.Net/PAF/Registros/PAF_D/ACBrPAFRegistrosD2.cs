using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistrosD2 : ICollection<ACBrPAFRegistroD2>
	{
		#region Fields

		private List<ACBrPAFRegistroD2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosD2()
		{
			this.list = new List<ACBrPAFRegistroD2>();
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
		public ACBrPAFRegistroD2 this[int index]
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

		public void Add(ACBrPAFRegistroD2 registrod2)
		{
			list.Add(registrod2);
		}

		public void AddRange(ACBrPAFRegistroD2[] registrosd2)
		{
			list.AddRange(registrosd2);
		}

		public bool Contains(ACBrPAFRegistroD2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroD2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroD2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroD2>

		public IEnumerator<ACBrPAFRegistroD2> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroD2>
	}
}