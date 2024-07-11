//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApi_CRUD.Models;

//namespace WebApi_CRUD.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class DemoWebApiController1 : ControllerBase
//    {
//        public static List<UserModel> userModels = new List<UserModel>
//        {
//          new UserModel() {ID = 1,  Name="Hamza khan"},
//          new UserModel() {ID = 2,  Name = "Ali Khan"},
//          new UserModel() {ID = 3,  Name = "Juanid Akbar"},
//          new UserModel() {ID = 4,  Name = "Numan Akbar"},
//          new UserModel() {ID = 5,  Name = "Abdullah Khilgi"}
//        };


//        [HttpGet]
//        public List<UserModel> Get()
//        {
//            return userModels;
//        }
//        [HttpPost]
//        public IActionResult post([FromBody]UserModel user)
//        {
//            userModels.Add(user);
//            return Ok(userModels);
//        }
//    }
//}


// BooksController.cs


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoWebApiController1 : ControllerBase
    {
        private readonly List<Student> student;

        public DemoWebApiController1()
        {
            student = new List<Student> //Give the data into the hardcode form and than through api I will get this data 
            {
                new Student { Id = 1, FirstName = "Hamza", LastName = "Khan", Age = 25, Gender = "Male" },
                new Student { Id = 2, FirstName = "Dua", LastName = "Fatima", Age = 30, Gender = "Female" },
                new Student { Id = 3, FirstName = "Ali", LastName = "Haider", Age = 22, Gender = "Male" },
                new Student { Id = 4, FirstName = "Fatima", LastName = "Ahmad", Age = 28, Gender = "Female" }
            };
        }
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(student);
        }

        // GET api/books/1
        [HttpGet("{id}")]
        public ActionResult<UserModel> GetById(int id)
        {
            var book = student.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Student newBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            newBook.Id = student.Count + 1;
            student.Add(newBook);
            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }
        // PUT api/books/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedBook)
        {
            var existingBook = student.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
                return NotFound();
            existingBook.FirstName = updatedBook.FirstName;
            existingBook.LastName = updatedBook.LastName;
            existingBook.Age = updatedBook.Age;
            existingBook.Gender = updatedBook.Gender;
            return NoContent();
        }

        // DELETE api/books/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookToRemove = student.FirstOrDefault(b => b.Id == id);
            if (bookToRemove == null)
                return NotFound();
            student.Remove(bookToRemove);
            return NoContent();
        }
    }
}
