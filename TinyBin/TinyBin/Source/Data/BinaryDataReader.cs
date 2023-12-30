﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyBin.Source.Data
{
    internal class BinaryDataReader
    {
        public static int updateTimeValue = Constants.DEFAULT_UPDATE_TIME; //default
        public static bool showEmptyBool = true;
        public static bool showOpenBool = true;
        public static bool noProgressUI;
        public static bool noConfirmation;
        public static bool DBLCLICKemptyBin = true;
        public static bool DBLCLICKopenFolder;
        public static bool DBLCLICKopenSettings;

        public static void SettingsRead()
        {
            if (File.Exists(Constants.DATA_FILE_NAME))
            {
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(Constants.DATA_FILE_NAME, FileMode.Open)))
                    {
                        updateTimeValue = reader.ReadInt32();
                        showEmptyBool = reader.ReadBoolean();
                        showOpenBool = reader.ReadBoolean();
                        noProgressUI = reader.ReadBoolean();
                        noConfirmation = reader.ReadBoolean();
                        DBLCLICKemptyBin = reader.ReadBoolean();
                        DBLCLICKopenFolder = reader.ReadBoolean();
                        DBLCLICKopenSettings = reader.ReadBoolean();
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}
