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
        public static int updateTimeValue = 500; //default
        public static bool showEmptyBool;
        public static bool showOpenBool;
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
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}