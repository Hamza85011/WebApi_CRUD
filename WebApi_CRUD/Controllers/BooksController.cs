// BooksController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;
using WebApi_CRUD.Models;


[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly List<UserModel> _books;

    public BooksController()
    {
        // In this example, we're using an in-memory list as the data store
        _books = new List<UserModel>
        {
            new UserModel { Id = 1, Title = " A TIME TO KILL BY JOHN GRISHAM",    Author = "Ali khan" },
            new UserModel { Id = 2, Title = " EAST OF EDEN BY JOHN STEINBECK",    Author = "Zahid Ali" },
            new UserModel { Id = 3, Title = " VILE BODIES BY EVELYN WAUGH",       Author = "Abdullah Khilgi" },
            new UserModel { Id = 4, Title = " MOAB IS MY WASHPOT BY STEPHEN FRY", Author = "Junaid Khan" }
        };
    }
    // GET api/books
    [HttpGet]
    public ActionResult<IEnumerable<UserModel>> Get()
    {
        return Ok(_books);
    }
    // GET api/books/1
    [HttpGet("{id}")]
    public ActionResult<UserModel> GetById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }
    [HttpPost]
    public IActionResult Post([FromBody] UserModel newBook)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        newBook.Id = _books.Count + 1;
        _books.Add(newBook);
        return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
    }
    // PUT api/books/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserModel updatedBook)
    {
        var existingBook = _books.FirstOrDefault(b => b.Id == id);
        if (existingBook == null)
            return NotFound();

        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        return NoContent();
    }
    // DELETE api/books/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove == null)
            return NotFound();

        _books.Remove(bookToRemove);
        return NoContent();
    }
}

