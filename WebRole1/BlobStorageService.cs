using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebRole1.Controllers
{
    class BlobStorageService
    {
        public CloudBlobContainer GetImageBlobContainer()
        {
            //Connect to the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageAccountConnection"));

            //Create cloud blob service client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Check if there's any containers with the appropriate name
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("niclasimages");

            //If container doesn't exist, create it!
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }

        public CloudBlobContainer GetVideoBlobContainer()
        {
            //Connect to the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageAccountConnection"));

            //Create cloud blob service client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Check if there's any containers with the appropriate name
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("niclasvideos");

            //If container doesn't exist, create it!
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }

        public CloudBlobContainer GetFileBlobContainer()
        {
            //Connect to the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageAccountConnection"));

            //Create cloud blob service client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Check if there's any containers with the appropriate name
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("niclasfiles");

            //If container doesn't exist, create it!
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }
    }
}
