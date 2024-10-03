using Microsoft.EntityFrameworkCore;

namespace Bookstor_Management.Data
{
    public class bookstoreDbContext: DbContext
    {
        public bookstoreDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
