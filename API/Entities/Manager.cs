using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhoneNumber { get; set; }
    }
}