using System.ComponentModel.DataAnnotations;

namespace P_02.Models
{
    public class course
    {
        [Key]
        [Required]
        public int cId { get; set; }
        public String cName { get; set; }
    }
}
