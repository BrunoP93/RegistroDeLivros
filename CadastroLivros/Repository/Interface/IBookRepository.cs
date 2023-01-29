using CadastroLivros.Model;

namespace CadastroLivros.Repository.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookModel>> GetAll(); 

        Task<BookModel> Get(int id);

        Task<BookModel> Create(BookModel book);

        Task<BookModel> Update(BookModel book, int id);

        Task<bool> Delete(int id);
    }
}
