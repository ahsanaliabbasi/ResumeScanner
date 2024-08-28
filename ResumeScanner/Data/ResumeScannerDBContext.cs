using Microsoft.EntityFrameworkCore;

namespace ResumeScanner.Data
{
    public class ResumeScannerDBContext : DbContext
    {
        public ResumeScannerDBContext(DbContextOptions<ResumeScannerDBContext> options) : base(options)
        {

        }


    }
}
