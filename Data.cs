using System;
using System.Collections.Generic;

namespace DICCreator
{
    public class Data
    {
        public static string version = string.Empty;
        public static string PathToZip = string.Empty;
        public static string PathToUpdate = string.Empty;
        public static string storeDetails = string.Empty;
        public static string descriptionFile = string.Empty;
        public static string archiveFile = string.Empty;
        public static FileHandler fileHandler = null;
        public static DatabaseManager dbHandler = null;
        public static config DirectItemChoice1 = null;
        public static config DirectItemChoice2 = null;
        public static config DirectItemChoice3 = null;
        public static texts textEN = new texts();
        public static texts textDE = new texts();
        public static texts textCZ = new texts();
    }

    [Serializable]
    public class BR
    {
        
    }
}
