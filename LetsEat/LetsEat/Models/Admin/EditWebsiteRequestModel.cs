namespace LetsEat.Models.Admin
{
    public class EditWebsiteRequestModel
    {
        public bool SuccessfullyDeleted { get; set; }
        public bool EmailSent { get; set; }

        public EditWebsiteRequestModel()
        {
            SuccessfullyDeleted = false;
            EmailSent = false;
        }

        public EditWebsiteRequestModel(bool successfullyDeleted, bool emailSent)
        {
            SuccessfullyDeleted = successfullyDeleted;
            EmailSent = emailSent;
        }
    }
}
