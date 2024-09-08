using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SendDeliveryNote
    {
        [Key]
        public int SendDeliveryID { get; set; }

        [Required]
        public virtual PurchasingRequest PR { get; set; }

        [Required]
             [ForeignKey("Order ID")]
        public int OrdrID { get; set; }

        public virtual Order Orders{ get; set; }

        [Required]
       [ForeignKey("PurchasingID")]
        public int PurchasingManagerID { get; set; }
        
        public virtual PurchasingManager PM { get; set; }
    }
}
