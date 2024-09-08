using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class DeliveryNote
    {
        [Key]
        public int DeliveryNoteID { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }
   
        //FK
        [ForeignKey("DepartmentID")]
        public int SupplierID { get; set; }

        public virtual Supplier S { get; set; }
      
        

      

    }
}
