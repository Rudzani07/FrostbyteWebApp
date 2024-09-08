using Microsoft.AspNetCore.Identity;

namespace FrostbyteWebApp.Models;

public class ApplicationUser : IdentityUser
{  
   
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
  

}
