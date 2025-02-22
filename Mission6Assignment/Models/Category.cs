namespace Mission6Assignment.Models;
using System.ComponentModel.DataAnnotations;


public class Categories
{
    //model for the categories
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    // Movies database
    public ICollection<Movies> Movie { get; set; }
}