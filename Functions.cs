using System;
using System.Collections.Generic;

namespace DICCreator
{
    public class Functions
    {
        /// <summary>
        /// This function creates Package.xml, description.xml, dicdata2updates.xml files
        /// </summary>
        public static void CreateDefaultXml()
        {
            // Create XML files for Simple Description file and Description about ZIP file 
            XML.Write(CreatePackageContents(), Constants.TemporaryFolder + Constants.PackageContents);
            XML.Write(CreateArchiveDecription(), Data.PathToUpdate + @"\" + Constants.descriptionFile);
            XML.Write(CreateDicDataDeployments(), Data.PathToUpdate + @"\" + Constants.dicdata2updates);
        }

        private static packageContents CreatePackageContents()
        {
            packageContents package = new packageContents();
            package.version = Data.version;

            pathElement pathElementConf = new pathElement();
            pathElementConf.location = "config";

            pathElement pathElementResource = new pathElement();
            pathElementResource.location = "resources";

            package.configPathExtensions = new List<pathElement>();
            package.configPathExtensions.Add(pathElementConf);

            package.resourcePathExtensions = new List<pathElement>();
            package.resourcePathExtensions.Add(pathElementResource);

            return package;
        }

        private static archiveDescription CreateArchiveDecription()
        {
            archiveDescription archiveDesc = new archiveDescription();
            archiveDesc.version = Data.version;
            archiveDesc.archive = new archive();
            archiveDesc.archive.comment = Constants.Comment;
            archiveDesc.archive.name = Constants.DICName;
            archiveDesc.archive.variant = Constants.VariantName;
            archiveDesc.archive.publishedTimestamp = DateTime.UtcNow.ToString();

            return archiveDesc;
        }

        private static dicDataDeployments CreateDicDataDeployments()
        {
            dicDataDeployments ddds = new dicDataDeployments();

            ddds.version = Data.version;
            ddds.ListdicDataDeployment = new List<dicDataDeployment>();

            dicDataDeployment ddd = new dicDataDeployment();
            ddd.descriptionFile = Constants.descriptionFile;
            ddd.archiveFile = Data.PathToZip;
            ddd.activationTimeStamp = DateTime.UtcNow.ToLocalTime().ToString();
            ddd.localDownloadTimeStamp = DateTime.UtcNow.ToLocalTime().ToString();
            ddd.centralDownloadTimeStamp = DateTime.UtcNow.ToLocalTime().ToString();
            ddd.destinations = new List<destination>();
            
            destination dest = new destination();
            dest.source = "destinations";
            dest.name = Data.PathToZip;
            dest.stores = new List<store>();
            dest.systemGroups = new List<string>();

            store objStore = new store();
            objStore.name = Data.storeDetails;

            dest.stores.Add(objStore);
            ddd.destinations.Add(dest);
            ddds.ListdicDataDeployment.Add(ddd);

            return ddds;
        }
    }
}
