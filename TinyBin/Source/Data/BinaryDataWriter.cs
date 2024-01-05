using System;
using System.IO;

namespace TinyBin.Source.Data
{
    internal class BinaryDataWriter
    {
        public static void WriteToFile(int updateTime, bool showEmpty,
            bool ShowOpen, bool noProgressUI,
            bool noConfirmation, bool DBLCLICKemptyBin,
            bool DBLCLICKopenFolder, bool DBLCLICKopenSettings, bool DBLCLICKexit, 
            string LocalizationValue)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(
                           File.Open(Constants.DATA_FILE_NAME,
                               FileMode.Create)))
                {
                    writer.Write(updateTime);
                    writer.Write(showEmpty);
                    writer.Write(ShowOpen);
                    writer.Write(noProgressUI);
                    writer.Write(noConfirmation);
                    writer.Write(DBLCLICKemptyBin);
                    writer.Write(DBLCLICKopenFolder);
                    writer.Write(DBLCLICKopenSettings);
                    writer.Write(DBLCLICKexit);
                    writer.Write(LocalizationValue);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}