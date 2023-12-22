using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyBin.Source.Data
{
    internal class BinaryDataWriter
    {
        public static void WriteToFile(int updateTime, bool showEmpty, bool ShowOpen)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(Constants.DATA_FILE_NAME, FileMode.Create)))
                {
                    writer.Write(updateTime);
                    writer.Write(showEmpty);
                    writer.Write(ShowOpen);
                }
            }
            catch (Exception ex){}
        }
    }
}
