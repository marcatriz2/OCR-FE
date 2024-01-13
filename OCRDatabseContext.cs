using Microsoft.EntityFrameworkCore;
using OCR_FE.Models;

namespace OCR_FE.Data
{
    public class OCRDatabseContext : DbContext
    {
        public OCRDatabseContext(DbContextOptions<OCRDatabseContext> options)
            : base(options)
        {
        }

        public DbSet<IDInfo> IDInfos { get; set; }
    }
}
