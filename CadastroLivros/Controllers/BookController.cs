using CadastroLivros.Model;
using CadastroLivros.Repository;
using CadastroLivros.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBook([FromBody] BookModel bookModel)
        {
            BookModel book = await _bookRepository.Create(bookModel);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            BookModel book = await _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            await _bookRepository.Delete(book.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBook(int id, [FromBody] BookModel book)
        {
            if(id == book.Id)
            {
                return BadRequest();
            }
            await _bookRepository.Update(book, id);
            return NoContent();
        }
    }
}
