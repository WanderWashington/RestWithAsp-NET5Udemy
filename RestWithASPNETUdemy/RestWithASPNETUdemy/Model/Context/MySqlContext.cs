using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class MySqlContext:DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options): base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }


    }

}
