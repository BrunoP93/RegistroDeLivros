using CadastroLivros.Data;
using CadastroLivros.Model;
using CadastroLivros.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly RegisterBookContext _context;

        public BookRepository(RegisterBookContext context) {
            _context = context;
        }

        public async Task<BookModel> Create(BookModel book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> Delete(int id)
        {
            BookModel bookPorId = await Get(id);

            if (bookPorId == null)
            {
                throw new Exception($"Livro com ID {id} não foi encontrado no banco de dados");
            }
            _context.Books.Remove(bookPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookModel>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<BookModel> Get(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<BookModel> Update(BookModel book, int id)
        {
            BookModel bookPorId = await Get(id);

            if (bookPorId == null)
            {
                throw new Exception($"Livro com ID {id} não foi encontrado no banco de dados");
            }

            bookPorId.Author = book.Author;
            bookPorId.Title = book.Title;
            bookPorId.Description = book.Description;

            _context.Books.Update(bookPorId);
            await _context.SaveChangesAsync();
            return bookPorId;
           
        }
    }
}
