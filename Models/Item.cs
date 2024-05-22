using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace backendP.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }



    }
}
