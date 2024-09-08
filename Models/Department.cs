using System.ComponentModel.DataAnnotations;

namespace FrostbyteWebApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        public int DepartmentName {get;set; }
    }
}
