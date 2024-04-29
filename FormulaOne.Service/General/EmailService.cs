using FormulaOne.Service.General.Interfaces;

namespace FormulaOne.Service.General;

public class EmailService:IEmailService

{
    public void SendWelcomeEmail(string email, string name)
    {
        Console.WriteLine($"This email will send a welcome email to {name} using the following email {email}");
    }

    public void SendGettingStartedEmail(string email, string name)
    {
        Console.WriteLine($"This email will send a getting started email to {name} using the following email {email}");

    }
}