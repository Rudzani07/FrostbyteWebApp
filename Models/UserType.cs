using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostbyteWebApp.Models
{
    public class UserType
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }
        public virtual Supplier Sup { get; set; }


        [Required]
        [ForeignKey("InventoryLiaisonID")]
        public int InventoryLiaisonID { get; set; }
        public virtual InventoryLiaison Inv { get; set; }
        


        [Required]
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
     


        [Required]
        [ForeignKey("SupplierID")]
        public int? AdminID { get; set; }
        public virtual Admin Ad { get; set; }
        



        [Required]
        [ForeignKey("PurchasingManagerID")]
        public int? PurchasingManagerID { get; set; }
        public virtual PurchasingManager Pum { get; set; }
      
    }
}
