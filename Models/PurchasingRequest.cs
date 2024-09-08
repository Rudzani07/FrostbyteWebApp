using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class PurchasingRequest
    {
        [Key]
        public int PurchasingRequestID { get; set; }
        [Required]
        public DateTime DateIssued { get; set; }
        //FK
        [Required]
        
        public int InventoryLiaisonID { get; set; }
        [ForeignKey("InventoryLiaisonID")]
        public virtual InventoryLiaison Inv {get; set; }


        [Required]
        [StringLength(5)]
        public string ItemCode {get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Specification { get; set; }   
       
        //FK
        [Required]
   [ForeignKey(" DepartmentID")]
        public int DepartmentID { get; set; }
     
        public virtual Department D {get; set; }   

        public int ItemModel { get; set; } 
        [Required]
        public int ItemSerialNumber { get; set; }
        [Required]
        public int  Unit {  get; set; }
        [Required]
        public int Quantity {get; set;}

        [Required]
        public float EstimatedPrice {  get; set; }

    }
}
