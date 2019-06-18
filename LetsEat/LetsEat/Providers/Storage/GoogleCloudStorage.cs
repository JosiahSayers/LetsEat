using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using LetsEat.Models.Forms;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LetsEat.Providers.Storage
{
    public class GoogleCloudStorage
    {
        private StorageClient storageClient;
        private string projectId;
        private string bucketName;

        public GoogleCloudStorage(string jsonCredential)
        {
            // Instantiates a client.
            GoogleCredential credential = GoogleCredential.FromJson(jsonCredential);
            storageClient = StorageClient.Create(credential);
            projectId = "lets-eat-241620";
            bucketName = projectId + "-images";
        }

        public void Connect()
        {
            try
            {
                storageClient.CreateBucket(projectId, bucketName);
            }
            catch (Google.GoogleApiException e)
            when (e.Error.Code == 409)
            { }
        }

        public string UploadFile(FileStream fileStream)
        { 
            string objectName = GenerateObjectName();
            var file = storageClient.UploadObject(bucketName, objectName, null, fileStream);
            return file.MediaLink;
        }

        public string DeleteFile(string fileurl)
        {
            Regex search = new Regex(@"[a-zA-Z0-9]{16}?");
            string objectName = search.Match(fileurl).ToString();

            storageClient.DeleteObjectAsync(bucketName, objectName);

            return objectName;
        }

        private string GenerateObjectName()
        {
            string[] values = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string output = "";
            Random rand = new Random();

            for(int i=0; i<16; i++)
            {
                output += values[rand.Next(0, values.Length)];
            }

            return output;
        }
    }
}