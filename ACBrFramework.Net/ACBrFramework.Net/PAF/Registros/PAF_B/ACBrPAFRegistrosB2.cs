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
    [Guid("0A9A2227-BF7A-472C-80FD-FC58D42BF1E4")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistrosB2 : ICollection<ACBrPAFRegistroB2>
    {
        #region Fields

        private List<ACBrPAFRegistroB2> list;

        #endregion Fields

        #region Constructor

        internal ACBrPAFRegistrosB2()
        {
            this.list = new List<ACBrPAFRegistroB2>();
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
        public ACBrPAFRegistroB2 this[int index]
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

        public void Add(ACBrPAFRegistroB2 registrob2)
        {
            list.Add(registrob2);
        }

        public void AddRange(ACBrPAFRegistroB2[] registrosb2)
        {
            list.AddRange(registrosb2);
        }

        public bool Contains(ACBrPAFRegistroB2 item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ACBrPAFRegistroB2[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrPAFRegistroB2 item)
        {
            return list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ACBrPAFRegistroB2>

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

        IEnumerator<ACBrPAFRegistroB2> IEnumerable<ACBrPAFRegistroB2>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroB2>
    }
}