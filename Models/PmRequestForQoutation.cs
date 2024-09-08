using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class PmRequestForQoutation
    {
        [Key]
        public int PmRequestForQoutationID { get; set; }
        public string Description {get;set;}
        //FK
        [Required]
         [ForeignKey("PurchasingRequestID")]
        public int PurchasingRequestID { get; set; }
      
        public virtual PurchasingRequest PR {  get; set; }

        //FK
        [Required]
        [ForeignKey("PurchasingRequestID")]
        public int PurcasingManagerID { get; set; }

        public virtual PurchasingManager PM { get; set; }


    }

}
