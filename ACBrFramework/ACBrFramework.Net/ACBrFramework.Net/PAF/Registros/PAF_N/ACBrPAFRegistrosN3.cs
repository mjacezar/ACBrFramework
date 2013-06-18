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
    [Guid("43DF347B-2F4B-4B2C-B55D-33A62A366AB2")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistrosN3 : ICollection<ACBrPAFRegistroN3>
    {
        #region Fields

        private List<ACBrPAFRegistroN3> list;

        #endregion Fields

        #region Constructor

        internal ACBrPAFRegistrosN3()
        {
            this.list = new List<ACBrPAFRegistroN3>();
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
        public ACBrPAFRegistroN3 this[int index]
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

        public void Add(ACBrPAFRegistroN3 item)
        {
            list.Add(item);
        }

        public void AddRange(ACBrPAFRegistroN3[] itens)
        {
            list.AddRange(itens);
        }

        public bool Contains(ACBrPAFRegistroN3 item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ACBrPAFRegistroN3[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrPAFRegistroN3 item)
        {
            return list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ACBrPAFRegistroN3>

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

        IEnumerator<ACBrPAFRegistroN3> IEnumerable<ACBrPAFRegistroN3>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroN3>
    }
}