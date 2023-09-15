using Microsoft.EntityFrameworkCore;
using myToDoAppX.Models;

namespace myToDoAppX.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)  : base(options) { }
        public DbSet<ToDoModel> ToDos { get; set; }
    }
}
