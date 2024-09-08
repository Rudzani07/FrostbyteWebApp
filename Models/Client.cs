using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrostbyteWebApp.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public String FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
  
        public int Phone { get; set; }


        [Required]
        public string Address1 { get; set; }


        [Required]
        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public int ZipCode { get; set; }

    }
}
