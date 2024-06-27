using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Foreign Key for Manager
        [JsonIgnore]
        public int ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }
    }
}