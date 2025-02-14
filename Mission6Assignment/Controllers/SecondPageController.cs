using Microsoft.AspNetCore.Mvc;
using Mission6Assignment.Models;

namespace Mission6Assignment.Controllers;

public class SecondPageController : Controller
{
    private FilmInfoContext _context;

    public SecondPageController(FilmInfoContext temp) //constructor
    {
        _context = temp;
    }

    // show the about page
    public IActionResult About()
    {
        return View();
    }
    
    //show the movie collection page where users can add a movie to the collection
    [HttpGet]
    public IActionResult MovieCollection()
    {
        return View("MovieCollection");
    }

    [HttpPost]
    public IActionResult MovieCollection(Movie response)
    {
        _context.Movies.Add(response); //pass record to database
        _context.SaveChanges();
        return View("Confirmation", response); //show the confirmation page
    }
    
}