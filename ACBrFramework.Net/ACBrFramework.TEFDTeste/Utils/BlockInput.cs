using System.Runtime.InteropServices;

namespace System
{
    public class BlockInput
    {
        /// Return Type: BOOL->int
        ///fBlockIt: BOOL->int
        [DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        public static extern bool Bloquear(bool fBlockIt);

        
    }
}
