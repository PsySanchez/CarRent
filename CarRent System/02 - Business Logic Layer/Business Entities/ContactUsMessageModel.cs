namespace CarRent
{
  public class ContactUsMessageModel
  {
    public int contactUsID { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string message { get; set; }
    public string subject { get; set; }

    public override string ToString()
    {
      return $"First name: {firstName}," +
          $"Last Name: {lastName}," +
          $"Email: {email}," +
          $"Phone: {phone}," +
          $"Message: {message}," +
          $"Subject: {subject}";
    }
  }
}
