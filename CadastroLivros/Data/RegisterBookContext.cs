using CadastroLivros.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Data
{
    public class RegisterBookContext : DbContext
    {
        public RegisterBookContext(DbContextOptions<RegisterBookContext> options) : base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
    }
}
