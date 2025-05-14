using GenerateSVG.Models;
using Microsoft.EntityFrameworkCore;

namespace GenerateSVG.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<ShapeModel> Shapes { get; set; }
    }
}
