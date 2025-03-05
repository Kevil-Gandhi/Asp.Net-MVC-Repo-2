using System.ComponentModel.DataAnnotations;

namespace P_02.Models
{
    public class student
    {
        [Key]
        [Required]
        public int sId { get; set; }
        public String sName { get; set; }
        public String sEmail { get; set; }
        public int cId { get; set; }
    }
}
