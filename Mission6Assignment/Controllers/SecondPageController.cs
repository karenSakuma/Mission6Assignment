using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.ToList();
        return View("MovieCollection", new Movies());
    }

    //post the new movie that was added to the database
    [HttpPost]
    public IActionResult MovieCollection(Movies response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //pass record to database
            _context.SaveChanges();
            
            return View("Confirmation", response); //show the confirmation page
        }
        else //invalid data
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }
        
    }

    //show the movies in the database
    public IActionResult MovieDatabase()
    {
        //Linq
        //var movies = _context.Movies.ToList();
        var movies = _context.Movies.Include(m => m.Category).ToList();


        return View(movies);
    }

    //get the movie that needs to be updated
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("MovieCollection", recordToEdit);
    }

    //post the updated info for the movie that was updated
    [HttpPost]
    public IActionResult Edit(Movies updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieDatabase");
    }
    
    //get the movie to be deleted
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        return View(recordToDelete);
    }

    //post for deleting the movie
    [HttpPost]
    public IActionResult Delete(Movies movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieDatabase");
    }
}