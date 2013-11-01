using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
#region COM_INTEROP

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("2C635407-C6AE-491B-8393-AF2D52D13497")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistrosR1 : ICollection<ACBrPAFRegistroR1>
	{
		#region Fields

		private readonly List<ACBrPAFRegistroR1> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosR1()
		{
			this.list = new List<ACBrPAFRegistroR1>();
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
		public ACBrPAFRegistroR1 this[int index]
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

		public void Add(ACBrPAFRegistroR1 item)
		{
			list.Add(item);
		}

		public void AddRange(ACBrPAFRegistroR1[] items)
		{
			list.AddRange(items);
		}

		public bool Contains(ACBrPAFRegistroR1 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroR1[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroR1 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrPAFRegistroR1>

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

        IEnumerator<ACBrPAFRegistroR1> IEnumerable<ACBrPAFRegistroR1>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroR1>
	}
}