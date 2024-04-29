using Microsoft.EntityFrameworkCore;
using Three_Hours_Course.Models;

namespace Three_Hours_Course.NewFolder
{
    public class ApplicationDBContext : DbContext
    {
        // write ctor and press tab two times will create constructor of this class
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }
        //dbset for category table
        public DbSet<Category> Categories { get; set; }
    }
}