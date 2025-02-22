using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Assignment.Models;

public class Movies
{
   //each component of a record
   [Key]
   public int MovieId { get; set; } 
   
   //foreign key to create relationship with the categories table
   [ForeignKey("CategoryId")]
   public int? CategoryId { get; set; }
   public Categories? Category { get; set; }
   
   [Required(ErrorMessage = "Please enter a Title")]
   public string Title { get; set; }
   
   //prevent users from entering a date earlier than 1888
   [Required(ErrorMessage = "Please enter a year.")]
   [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
   public int Year { get; set; }
   
   //can be null
   public string? Director { get; set; }
   
   //can be null
   public string? Rating { get; set; }
   
   [Required(ErrorMessage = "Please enter whether it was edited or not.")]
   public bool Edited { get; set; } 
   
   //can be null
   public string? LentTo { get; set; }
   
   [Required(ErrorMessage = "Please enter whether it was copied to plex or not.")]
   public bool CopiedToPlex { get; set; }
   
   //keep notes under 25 characters - and can be left null
   [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
   public string? Notes { get; set; }
}