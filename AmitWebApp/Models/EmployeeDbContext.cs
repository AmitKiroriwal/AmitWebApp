using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyWebApp.Models;

namespace AmitWebApp.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<MyGallery> myGallery { get; set; }
        public DbSet<GalleryCategory> galleryCategories { get; set; }
        //public DbSet<State> state { get; set; }
        //public DbSet<District> District { get; set; }
        public DbSet<States> states { get; set; }
        public DbSet<Districts> districts { get; set; }
        public DbSet<Cities> cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
