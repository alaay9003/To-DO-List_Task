using Microsoft.EntityFrameworkCore;
using To_DO_List_Task.Models;

namespace To_DO_List_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {
            
        }

        public DbSet<Note> Notes { get; set; }
    }
}
