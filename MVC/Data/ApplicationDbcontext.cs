using Microsoft.EntityFrameworkCore;
using MVC.Models; // nếu các model nằm trong thư mục Models

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DonHang>()
                .HasOne(dh => dh.KhachHang)
                .WithMany(kh => kh.DonHangs)
                .HasForeignKey(dh => dh.KhachHangId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(ct => ct.DonHang)
                .WithMany(dh => dh.ChiTietDonHangs)
                .HasForeignKey(ct => ct.DonHangId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(ct => ct.SanPham)
                .WithMany(sp => sp.ChiTietDonHangs)
                .HasForeignKey(ct => ct.SanPhamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<MVC.Models.Student> Student { get; set; } = default!;
    }
}
