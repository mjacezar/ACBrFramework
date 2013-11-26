using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("F8162503-7644-473C-88EC-8F84586CE394")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistrosR2 : ICollection<ACBrPAFRegistroR2>
	{
		#region Fields

		private List<ACBrPAFRegistroR2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR2()
		{
			this.list = new List<ACBrPAFRegistroR2>();
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
		public ACBrPAFRegistroR2 this[int index]
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

		public void Add(ACBrPAFRegistroR2 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR2[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrPAFRegistroR2>

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

        IEnumerator<ACBrPAFRegistroR2> IEnumerable<ACBrPAFRegistroR2>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroR2>
	}
}