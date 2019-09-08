namespace LetsEat.Models
{
  public class Error
  {
    public string ErrorMessage { get; }

    public Error(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}