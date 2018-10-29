using System;
using System.IO;

namespace DICCreator
{
    static class Program
    {
        /// <summary>
        /// Author:       Husniddin Salahiddinov
        /// Date:         02-04-2017
        /// Description:  Application reads  binary data from  central  database and   converting  them into .png files
        ///               even  cutting  them  for suitable  size for  SCO  cash register. 
        /// Added:        For  JIRA TASK TPNETAHOLD-231    
        /// Version:      1.0.0.2
        /// </summary>
        private static GetImagesFromDB getImages = new GetImagesFromDB();
       
        [STAThread]
        static void Main(string[] args)
        {
            Logger.Log = new LogHandler.Log(@".\Log\", "DICCreator", true, 10, 0);
            Logger.Log.Clean();

            Data.fileHandler = new FileHandler();
            
            // Check connection string with DB
            Data.dbHandler = new DatabaseManager();

            // Version of application
            Data.version = "v1.01";
            try
            {
                // Create root folder for .exe file
                Data.PathToZip = @"C:\TPiScan\cz-ahold\base\defaultremote\dicdata-2";
                Data.PathToUpdate = @"C:\DICUpdate";

                var dZ = Directory.Exists(Data.PathToZip);
                var dU = Directory.Exists(Data.PathToUpdate);

                if (dZ == true)
                {
                    string[] files = Directory.GetFiles(Data.PathToZip);
                    if (files.Length > 0)
                    {
                        foreach (var item in files)
                        {
                            File.Delete(item);  //Clear old data in local machine
                        }
                    }
                }
                // Create Temparoary directories for saving data in local storage
                if (!dZ)
                    Directory.CreateDirectory(Data.PathToZip);

                if (!dU)
                    Directory.CreateDirectory(Data.PathToUpdate);

                if (Data.dbHandler.IsConnectionExists.IsConnected)
                {
                    if (Directory.Exists(Constants.TemporaryFolder))
                        Directory.Delete(Constants.TemporaryFolder, true);
                    
                    // Call this function  for download images from DB
                    getImages.GetImageFromDB(); 
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Write("ERROR, ex: " +ex.Message);
            }
            finally
            {
                if (Directory.Exists(Constants.TemporaryFolder))
                    Directory.Delete(Constants.TemporaryFolder, true);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hotovo!");
            }

        }
    }
}
