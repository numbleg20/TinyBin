using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinAPI;

namespace TinyBin.Source.Data
{
    internal class Bin
    {
        public static void OpenFolder() => System.Diagnostics.Process.Start("explorer.exe",
            "shell:RecycleBinFolder");

        public static void Empty()
        {
            uint flags = (BinaryDataReader.noProgressUI ? 0x01u : 0) |
                         (BinaryDataReader.noConfirmation ? 0x02u : 0);
            if (GetCount() == 0) MessageBox.Show("Recycle Bin is empty.");
            else Shell32.SHEmptyRecycleBin(IntPtr.Zero, null, flags);
        }

        public static int GetCount()
        {
            Shell32.SHQUERYRBINFO sqrbi = new Shell32.SHQUERYRBINFO();
            sqrbi.cbSize = Marshal.SizeOf(typeof(Shell32.SHQUERYRBINFO));
            int hresult = Shell32.SHQueryRecycleBin(string.Empty, ref sqrbi);
            return (int)sqrbi.i64NumItems;
        }
    }
}