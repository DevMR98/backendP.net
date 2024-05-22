using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendP.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}
