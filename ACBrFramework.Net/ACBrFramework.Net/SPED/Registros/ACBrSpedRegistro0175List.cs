using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.SPED
{
	public sealed class ACBrSpedRegistro0175List : ICollection<ACBrSpedRegistro0175>
	{
		#region Fields

		private List<ACBrSpedRegistro0175> list;

		#endregion Fields

		#region Constructor

		internal ACBrSpedRegistro0175List()
		{
			this.list = new List<ACBrSpedRegistro0175>();
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
		public ACBrSpedRegistro0175 this[int index]
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

		public void Add(ACBrSpedRegistro0175 value)
		{
			list.Add(value);
		}

		public void AddRange(ACBrSpedRegistro0175[] values)
		{
			list.AddRange(values);
		}

		public bool Contains(ACBrSpedRegistro0175 value)
		{
			return list.Contains(value);
		}

		public void CopyTo(ACBrSpedRegistro0175[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrSpedRegistro0175 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrSpedRegistro0175>

		public IEnumerator<ACBrSpedRegistro0175> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrSpedRegistro0175>
	}
}