using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SendPmRequestForQuotation
    {
        [Key]
        public int SendPmRequestForQoutationID { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string ResponseLocation { get; set; }

        //fk
        [Required]
        [ForeignKey("PmRequestForQuotationID ")]
        public int PmRequestForQuotationID { get; set; }
       
        public virtual PmRequestForQoutation PM {get; set;}

        //fk
        [Required]
     [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }
       
        public virtual Supplier S { get; set; }

    }
}
