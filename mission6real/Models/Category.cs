using System.ComponentModel.DataAnnotations;

namespace mission6real_Smith.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
