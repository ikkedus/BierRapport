using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public static class CloudStoarge
    {
        private static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=bierrapport;AccountKey=dUPhg9OpeA1vNyohiJFDi02RVTEKY5PXODxHwCZFfy2XKQ0okKNuGbVO57Vwe31CRg4BrvtoIQ+gPYZ8p8Xu2A==;EndpointSuffix=core.windows.net");
        
        public static async void upload(string name,MemoryStream stream)
        {
            var client = storageAccount.CreateCloudBlobClient();

            var container = client.GetContainerReference("somecontainer");
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            var blob = container.GetBlockBlobReference(name);

            await blob.UploadFromStreamAsync(stream);
        }
        public static async Task<MemoryStream> get(string name)
        {
            var client = storageAccount.CreateCloudBlobClient();

            var container = client.GetContainerReference("somecontainer");
            var blob = container.GetBlobReference(name+".png");
            var memStream = new MemoryStream();

            await blob.DownloadToStreamAsync(memStream);

            return memStream;
        }
    }
}
