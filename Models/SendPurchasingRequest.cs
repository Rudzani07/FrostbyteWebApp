using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SendPurchasingRequest
    {
        [Key]
        public int SendPurchasingRequestID{ get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        //FK
        //FK
        [Required]
        [ForeignKey("PurchasingRequestID")]
        public int PurchasingRequestID { get; set; }

        public virtual PurchasingRequest PR { get; set; }


        [Required]
      [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }
        
        public virtual Supplier S { get; set; }
        
    }
}
