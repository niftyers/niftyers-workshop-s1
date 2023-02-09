using Microsoft.AspNetCore.Mvc;
using Library;

namespace Niftyers {

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase {

        public static List<Book> Books = new List<Book>();
        
        public IActionResult BooksList() {
            return Ok(Books);
        }

        [HttpPost("Create")]
        public IActionResult Create(string Name, string Description, string Author, string DateCreated) {
            var newBook = new Book();
            newBook.ID = Guid.NewGuid().ToString();
            newBook.Name = Name;
            newBook.Description = Description;
            newBook.Author = Author;
            newBook.DateCreated = DateCreated;

            Books.Add(newBook);

            return Ok("New book was successfully added");
        }


        [HttpPost("Info")]
        public  IActionResult Info(string ID) {
             
            var book = Books.Find(b => b.ID == ID);

            if (book == null) return Ok("No record found");

            return Ok(book) ;
        }

        [HttpPost("Delete")]
        public  IActionResult Delete(string ID) {
             
            var data = Books.Find(b => b.ID == ID);

            if (data == null) return Ok("No record found");

            Books.Remove(data);

            return Ok("Book was successfully deleted") ;

        }


    }
}