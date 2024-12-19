using System.Security;

namespace SharpWebApp;

public class Settings {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SMTPFromEmailAddress { get; set; }
    public string TopSecret { get; set; }
}