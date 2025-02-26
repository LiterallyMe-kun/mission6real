using System.ComponentModel.DataAnnotations;

namespace mission6real_Smith.Models
{
    public class Movie
    {
        //Category Title   Year Director    Rating Edited  Lent To:	Notes
        [Key]
        [Required]
        public int MovieId { get; set; } 
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; } 
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }

    }
}
