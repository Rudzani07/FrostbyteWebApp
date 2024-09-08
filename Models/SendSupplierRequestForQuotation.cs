using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SendSupplierRequestForQuotation
    {
        [Key]
        public int SendSupplierPmRequestForQoutationID { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
        //FK
        [Required]
       [ForeignKey("SupplierPmRequestForQoutationID ")]
        public int SupplierRequestForQoutationID { get; set; }
        
        public virtual SupplierRequestForQoutation SRFQ { get; set; }

        //FK
        [Required]
        [ForeignKey("PurchasingManagerID")]
        public int PurchasingManagerID { get; set; }
        
        public virtual PurchasingManager PM{  get; set; }
    }
    
}
