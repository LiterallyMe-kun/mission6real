using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission6real_Smith.Models
{
    public class Movie
    {
        //Category Title   Year Director    Rating Edited  Lent To:	Notes
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Please enter the movie title.")]
        public string Title { get; set; }
        [Range(1887, 2100, ErrorMessage = "Please enter the year the movie released.")]
        public int Year { get; set; }
        public string? Director { get; set; } 
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
       
    }
}
