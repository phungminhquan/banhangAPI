using Microsoft.EntityFrameworkCore;

namespace API_Basic.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }

        //chuoi ket noi
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-0B0KLT95\\SQLEXPRESS02; Database = Ql_HocSinh; Trusted_Connection = True;TrustServerCertificate=True");
        }
    }
}
