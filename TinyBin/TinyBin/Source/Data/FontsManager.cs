using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TinyBin.Source.Data
{
    internal class FontsManager
    {
        public static PrivateFontCollection pfc = new PrivateFontCollection();
        public static void AddFontFile(byte[] fileInResources)
        {
            int fontlength = fileInResources.Length;
            byte[] fontdata = fileInResources;
            IntPtr data = Marshal.AllocCoTaskMem(fontlength);
            Marshal.Copy(fontdata, 0, data, fontlength);
            pfc.AddMemoryFont(data, fontlength);
        }
    }
}
