using System;
namespace LetsEat.Models.Image
{
    public class ImageErrorMessages : BaseError
    {
        public Error Upload
        {
            get
            {
                return ErrorResult("Error uploading image");
            }
        }

        public Error StorageProvider
        {
            get
            {
                return ErrorResult("Error sending file to storage provider");
            }
        }

        public Error Delete
        {
            get
            {
                return ErrorResult("Error deleting image");
            }
        }
    }
}
