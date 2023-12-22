using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyBin.Source.WinAPI;

namespace TinyBin.Source.Data
{
    internal class Bin
    {
        public static void OpenFolder() => System.Diagnostics.Process.Start("explorer.exe",
            "shell:RecycleBinFolder");
        public static void Empty()
        {
            if (GetCount() == 0) MessageBox.Show("Recycle Bin is empty.");
            else shell32.SHEmptyRecycleBin(IntPtr.Zero, null,
                shell32.RecycleFlags.SHRB_NOCONFIRMATION | shell32.RecycleFlags.SHRB_NOPROGRESSUI);
        }
        public static int GetCount()
        {
            shell32.SHQUERYRBINFO sqrbi = new shell32.SHQUERYRBINFO();
            sqrbi.cbSize = Marshal.SizeOf(typeof(shell32.SHQUERYRBINFO));
            int hresult = shell32.SHQueryRecycleBin(string.Empty, ref sqrbi);
            return (int)sqrbi.i64NumItems;
        }
    }
}
