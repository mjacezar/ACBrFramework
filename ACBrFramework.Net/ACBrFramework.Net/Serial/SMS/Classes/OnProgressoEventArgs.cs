using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBrFramework.SMS
{
    public class OnProgressoEventArgs : EventArgs
    {
        public int Atual { get; set; }

        public int Total { get; set; }
    }
}
