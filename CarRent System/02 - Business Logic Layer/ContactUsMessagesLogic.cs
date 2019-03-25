using System.Linq;

namespace CarRent
{
  public class ContactUsMessagesLogic : BaseLogic
  {
    public ContactUsMessageModel AddContactUs(ContactUsMessageModel contactUsMessageModel)
    {
      ContactUsMessage contactUsMessage = new ContactUsMessage
      {
        FirstName = contactUsMessageModel.firstName,
        LastName = contactUsMessageModel.lastName,
        Email = contactUsMessageModel.email,
        Phone = contactUsMessageModel.phone,
        Message = contactUsMessageModel.message,
        Subject = contactUsMessageModel.subject,
      };

      DB.ContactUsMessages.Add(contactUsMessage);
      DB.SaveChanges();
      //Email.Send("moishe@gmail.com", "Hi", "This is a test email...");
      return GetOneContactUsMessage(contactUsMessage.ContactUsID);
    }

    private ContactUsMessageModel GetOneContactUsMessage(int id)
    {
      return DB.ContactUsMessages
          .Where(c => c.ContactUsID == id)
          .Select(c => new ContactUsMessageModel
          {
            contactUsID = c.ContactUsID,
            firstName = c.FirstName,
            lastName = c.LastName,
            email = c.Email,
            phone = c.Phone,
            message = c.Message,
            subject = c.Subject
          }).SingleOrDefault();
    }
  }
}
