using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CreateDepartmentDTO
    {
        [Required]
        public string DepartmentName { get; set; }
        
        [Required]
        public int ManagerId { get; set; }
    }
}