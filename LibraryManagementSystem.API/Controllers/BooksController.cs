using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Domain;
using LibraryManagementSystem.API.Models.DTO;
using LibraryManagementSystem.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LMSDbContext dbContext;
        private readonly IBookRepository bookRepository;

        public BooksController(LMSDbContext dbContext, IBookRepository bookRepository)
        {
            this.dbContext = dbContext;
            this.bookRepository = bookRepository;
        }


        // GET ALL BOOKS
        // GET : https://localhost:portnumber/api/Books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain Models
            var books = await bookRepository.GetAllAsync();

            //Map Domain Models to DTOs
            var bookDetailsDtos = new List<BookDetailsDto>();
            foreach(var book in books)
            {
                bookDetailsDtos.Add(new BookDetailsDto()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl
                });
            }

            //Return DTOs to Client
            return Ok(bookDetailsDtos);
        }

        // GET A BOOK BY ID
        // GET : https://localhost:portnumber/api/Books/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //Get Data From Database - Domain Models
            var book = await bookRepository.GetByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var bookDetailsDto = new BookDetailsDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl
            };

            //Return DTO to client
            return Ok(bookDetailsDto);
        }

        // POST TO CREATE A NEW BOOK
        // POST : https://localhost:portnumber/api/Books
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto bookDto)
        {
            if (ModelState.IsValid) 
            {
                // Map DTO to Domain Model
                var book = new Book
                {
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    Description = bookDto.Description,
                    ImageUrl = bookDto.ImageUrl
                };

                // Use Domain Model to Create a Book
                book = await bookRepository.CreateAsync(book);

                // Map Domain Model Back to DTO
                var bookDetailsDto = new BookDetailsDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl

                };

                return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDetailsDto);
            }
            else 
            {
                return BadRequest(ModelState);
            }
            
        }

        // UPDATE A BOOK
        // PUT : https://localhost:portnumber/api/Books/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookDto bookDto)
        {
            if (ModelState.IsValid) 
            {
                //Map DTO to Domain Model
                var book = new Book
                {
                    Id = id,
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    Description = bookDto.Description,
                    ImageUrl = bookDto.ImageUrl
                };
                //Check if Book exists in Database
                book = await bookRepository.UpdateAsync(id, book);

                if (book == null)
                {
                    return NotFound();
                }

                //Return Domain Model to DTO
                var bookDetailsDto = new BookDetailsDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl
                };
                return Ok(bookDetailsDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        // DELETE A BOOK
        // DELETE : https://localhost:portnumber/api/Books/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //Check if Book exists in Database
            var book = await bookRepository.DeleteAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            //Return Domain Model to DTO
            var bookDetailsDto = new BookDetailsDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl
            };
            return Ok(bookDetailsDto);
        }
    }
}
