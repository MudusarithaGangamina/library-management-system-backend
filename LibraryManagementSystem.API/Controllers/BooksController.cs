using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Domain;
using LibraryManagementSystem.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LMSDbContext dbContext;
        public BooksController(LMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // GET ALL BOOKS
        // GET : https://localhost:portnumber/api/Books
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data From Database - Domain Models
            var books = dbContext.Books.ToList();

            //Map Domain Models to DTOs
            var bookDetailsDtos = new List<BookDetailsDto>();
            foreach(var book in books)
            {
                bookDetailsDtos.Add(new BookDetailsDto()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description
                });
            }

            //Return DTOs to Client
            return Ok(bookDetailsDtos);
        }

        // GET A BOOK BY ID
        // GET : https://localhost:portnumber/api/Books/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Get Data From Database - Domain Models
            var book = dbContext.Books.Find(id);

            if(book == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var bookDetailsDto = new BookDetailsDto
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };

            //Return DTO to client
            return Ok(bookDetailsDto);
        }

        // POST TO CREATE A NEW BOOK
        // POST : https://localhost:portnumber/api/Books
        [HttpPost]
        public IActionResult Create([FromBody] BookDetailsDto bookDetailsDto)
        {
            // Map DTO to Domain Model
            var book = new Book
            {
                Title = bookDetailsDto.Title,
                Author = bookDetailsDto.Author,
                Description = bookDetailsDto.Description
            };

            // Use Domain Model to Create a Book
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            // Map Domain Model Back to DTO
            var bookDto = new BookDetailsDto
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description

            };

            return CreatedAtAction(nameof(GetById), new { id = book.Id},bookDto);
        }

        // UPDATE A BOOK
        // PUT : https://localhost:portnumber/api/Books/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BookDetailsDto bookDetailsDto)
        {
            //Check if Book exists in Database
            var book = dbContext.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model
            book.Title = bookDetailsDto.Title;
            book.Author = bookDetailsDto.Author;
            book.Description = bookDetailsDto.Description;

            dbContext.SaveChanges();

            //Return Domain Model to DTO
            var bookDto = new BookDetailsDto
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };
            return Ok(bookDto);
        }

        // DELETE A BOOK
        // DELETE : https://localhost:portnumber/api/Books/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Check if Book exists in Database
            var book = dbContext.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

            //Return Domain Model to DTO
            var bookDto = new BookDetailsDto
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };
            return Ok(bookDto);
        }
    }
}
