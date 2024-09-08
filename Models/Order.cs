using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
  //FK
        [Required]
       
      [ForeignKey("SendSupplierRequestForQoutationID")]
        public  int SendSupplierRequestForQoutationID { get; set; }
        
        public virtual SendSupplierRequestForQuotation sRFQ { get; set; }
        [Required]
        public DateTime PaymentMethod {  get; set; }


        [Required]
        public string AccountHolder {  get; set; }


        //FK
        [Required]
       [ForeignKey("BankNameID")]
        public int BankNameID{ get; set; }
      
        public virtual UserBank Bank { get; set; }
        [Required]
        public string YourReference {get;set; }

        [Required]
        public string TheirReference { get; set; }

        [Required]
        public float Amount { get; set;}

    }
}
