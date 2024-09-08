using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class SupplierRequestForQoutation
    {
        [Key]
        public int SupplierRequestForQuotationID {  get; set; }
        [Required]
        public DateTime DateIssued { get; set; }
        //FK
        public int SupplierID { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Specification { get; set; }
       
        //FK
        [Required]
          [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
      
        public virtual Department D { get; set; }
       
        [Required]
        public int ItemModel { get; set; }
        [Required]
        public int ItemSerialNumber { get; set; }
        [Required]
        public int Unit { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int EstimatedPrice { get; set; }
        [Required]
        public int QoutedPrice {get; set; }
        [Required]    
        public string PaymentSpecifications { get; set; }
        public string DeliverySpecification {  get; set; }
        [Required]
        public string TermsCondition{get;set; }

    }
}
