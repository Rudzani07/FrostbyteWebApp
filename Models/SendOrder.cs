using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SendOrder
    {
        [Key]
        public int SendOrderID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        //FK
        [Required]
         [ForeignKey("OrderID")]
        public int OrderID { get; set; }
     
        public virtual Order O { get; set; }

        [Required]
        [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }
      
        public virtual Supplier S { get; set; }
       
    }
}
