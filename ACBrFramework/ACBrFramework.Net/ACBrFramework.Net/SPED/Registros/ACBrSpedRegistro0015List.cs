using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.SPED
{
	public sealed class ACBrSpedRegistro0015List : ICollection<ACBrSpedRegistro0015>
	{
		#region Fields

		private List<ACBrSpedRegistro0015> list;

		#endregion Fields

		#region Constructor

		internal ACBrSpedRegistro0015List()
		{
			this.list = new List<ACBrSpedRegistro0015>();
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
		public ACBrSpedRegistro0015 this[int index]
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

		public void Add(ACBrSpedRegistro0015 value)
		{
			list.Add(value);
		}

		public void AddRange(ACBrSpedRegistro0015[] values)
		{
			list.AddRange(values);
		}

		public bool Contains(ACBrSpedRegistro0015 value)
		{
			return list.Contains(value);
		}

		public void CopyTo(ACBrSpedRegistro0015[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrSpedRegistro0015 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrSpedRegistro0015>

        public IEnumerator<ACBrSpedRegistro0015> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrSpedRegistro0015>
    }
}