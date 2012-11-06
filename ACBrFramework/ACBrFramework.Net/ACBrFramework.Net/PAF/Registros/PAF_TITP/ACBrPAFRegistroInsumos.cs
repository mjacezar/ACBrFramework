using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroInsumos : ICollection<ACBrPAFRegistroInsumo>
	{
		#region Fields

		private List<ACBrPAFRegistroInsumo> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistroInsumos()
		{
			this.list = new List<ACBrPAFRegistroInsumo>();
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
		public ACBrPAFRegistroInsumo this[int index]
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

		public void Add(ACBrPAFRegistroInsumo mercadoria)
		{
			list.Add(mercadoria);
		}

		public void AddRange(ACBrPAFRegistroInsumo[] mercadorias)
		{
			list.AddRange(mercadorias);
		}

		public bool Contains(ACBrPAFRegistroInsumo item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroInsumo[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroInsumo item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroInsumo>

		public IEnumerator<ACBrPAFRegistroInsumo> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroInsumo>
	}
}