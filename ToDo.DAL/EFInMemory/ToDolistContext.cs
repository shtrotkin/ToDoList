using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Entities;
namespace ToDo.DAL.EFInMemory
{
    public class ToDolistContext : DbContext
    {
        public ToDolistContext(DbContextOptions<ToDolistContext> options) : base(options)
        {

        }
        public DbSet<ToDolist> todolist { get; set; }
    }
}
