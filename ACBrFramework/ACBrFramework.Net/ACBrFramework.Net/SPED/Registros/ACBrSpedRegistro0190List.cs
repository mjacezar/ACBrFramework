using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.SPED
{
	public sealed class ACBrSpedRegistro0190List : ICollection<ACBrSpedRegistro0190>
	{
		#region Fields

		private List<ACBrSpedRegistro0190> list;

		#endregion Fields

		#region Constructor

		internal ACBrSpedRegistro0190List()
		{
			this.list = new List<ACBrSpedRegistro0190>();
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
		public ACBrSpedRegistro0190 this[int index]
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

		public void Add(ACBrSpedRegistro0190 value)
		{
			list.Add(value);
		}

		public void AddRange(ACBrSpedRegistro0190[] values)
		{
			list.AddRange(values);
		}

		public bool Contains(ACBrSpedRegistro0190 value)
		{
			return list.Contains(value);
		}

		public void CopyTo(ACBrSpedRegistro0190[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrSpedRegistro0190 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool LocalizaRegistro(string UNID)
		{
			bool retorno = false;
			int ret = -1;
			
			ret = list.FindIndex(p => p.UNID == UNID);
			if(ret > -1)
				retorno = true;

			return retorno;
		}

		#endregion Methods

		#region IEnumerable<ACBrSpedRegistro0190>

		public IEnumerator<ACBrSpedRegistro0190> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrSpedRegistro0190>
	}
}
