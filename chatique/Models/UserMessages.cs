using System.Collections.Generic;

namespace chatique.Models;

public class UserMessages
{
    protected internal string Username { get; set; }
    protected internal List<string> Messages { get; set; }
}
