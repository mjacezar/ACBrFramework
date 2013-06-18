using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("80AE19D9-86C8-4D02-AFE2-98E4FC2E603D")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroInsumos : ICollection<ACBrPAFRegistroInsumo>
	{
		#region Fields

		private List<ACBrPAFRegistroInsumo> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistroInsumos()
		{
			list = new List<ACBrPAFRegistroInsumo>();
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

#if COM_INTEROP
        [DispId(-4)]
        public IDictionaryEnumerator GetEnumerator()
#else
		public IEnumerator GetEnumerator()
#endif
        {
#if COM_INTEROP
            return (IDictionaryEnumerator)(list.GetEnumerator() as IEnumerator);
#else
		    return list.GetEnumerator();
#endif
        }

        IEnumerator<ACBrPAFRegistroInsumo> IEnumerable<ACBrPAFRegistroInsumo>.GetEnumerator()
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