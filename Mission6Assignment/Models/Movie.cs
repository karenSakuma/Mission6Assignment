using System.ComponentModel.DataAnnotations;

namespace Mission6Assignment.Models;

public class Movie
{
   //each component of a record
   [Key]
   [Required] //required to be added into database
   //info to put into the database
   public int MovieId { get; set; }
   [Required]
   public string Category { get; set; }
   [Required]
   public string Title { get; set; }
   [Required]
   public int Year { get; set; }
   [Required]
   public string Director { get; set; }
   [Required]
   public string Rating { get; set; }
   //the rest are not required to be added to database
   public bool? Edited { get; set; } //set as booleon
   public string? LentTo { get; set; }
   [Range(0, 25)] //set range to 25
   public string? Notes { get; set; }
}