using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrostbyteWebApp.Models
{
    public class UserBank
    {
        [Key]
        public int UserBankID { get; set; }

        [Required]
        public String BankName { get; set; }

        public int BranchCodeName { get; set; }

      
    }
}
