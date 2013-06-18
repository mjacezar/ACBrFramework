using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("45818E0A-FDB0-41E3-8AE2-D481D026140B")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistrosR7 : ICollection<ACBrPAFRegistroR7>
    {
        #region Fields

        private List<ACBrPAFRegistroR7> list;

        #endregion Fields

        #region Constructor

        internal ACBrPAFRegistrosR7()
        {
            this.list = new List<ACBrPAFRegistroR7>();
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
        public ACBrPAFRegistroR7 this[int index]
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

        public void Add(ACBrPAFRegistroR7 item)
        {
            list.Add(item);
        }

        public void AddRange(ACBrPAFRegistroR7[] items)
        {
            list.AddRange(items);
        }

        public bool Contains(ACBrPAFRegistroR7 item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ACBrPAFRegistroR7[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrPAFRegistroR7 item)
        {
            return list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ACBrPAFRegistroR7>

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

        IEnumerator<ACBrPAFRegistroR7> IEnumerable<ACBrPAFRegistroR7>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroR7>	}
    }
}