using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
        
        [Required]
        public int ManagerId { get; set; }
    }
}