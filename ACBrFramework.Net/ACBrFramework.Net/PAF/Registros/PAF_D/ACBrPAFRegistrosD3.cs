using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("F2660C6C-1D70-483B-A8B5-D80B3F28C0F9")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistrosD3 : ICollection<ACBrPAFRegistroD3>
	{
		#region Fields

		private List<ACBrPAFRegistroD3> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosD3()
		{
			this.list = new List<ACBrPAFRegistroD3>();
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
		public ACBrPAFRegistroD3 this[int index]
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

		public void Add(ACBrPAFRegistroD3 registrod3)
		{
			list.Add(registrod3);
		}

		public void AddRange(ACBrPAFRegistroD3[] registrosd3)
		{
			list.AddRange(registrosd3);
		}

		public bool Contains(ACBrPAFRegistroD3 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroD3[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroD3 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrPAFRegistroD3>

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

        IEnumerator<ACBrPAFRegistroD3> IEnumerable<ACBrPAFRegistroD3>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroD3>
	}
}