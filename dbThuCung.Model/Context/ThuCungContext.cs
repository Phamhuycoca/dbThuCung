using dbThuCung.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Context
{
    public class ThuCungContext : DbContext
    {
        public ThuCungContext(DbContextOptions<ThuCungContext> options) : base(options) 
        {

        }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThuNuoi> ThuNuois { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>(e =>
            {
                e.ToTable("DanhMuc");
                e.HasKey(e => e.DanhMucId);
            });
            modelBuilder.Entity<SanPham>(e =>{
                e.ToTable("SanPham");
                e.HasKey(e => e.SanPhamId);
                e.HasOne(e => e.getDanhMuc).WithMany(e => e.SanPham).HasForeignKey(e => e.DanhMucId).OnDelete(DeleteBehavior.Restrict); ;
            });
            modelBuilder.Entity<ThuNuoi>(e =>
            {
                e.ToTable("ThuNuoi");
                e.HasKey(e => e.ThuNuoiId);
                e.HasOne(e => e.getDanhMuc).WithMany(e => e.ThuNuoi).HasForeignKey(e => e.DanhMucId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<NguoiDung>(e => {
                e.ToTable("NguoiDung");
                e.HasKey(e => e.NguoiDungId);
            });
            modelBuilder.Entity<HoaDon>(e => {
                e.ToTable("HoaDon");
                e.HasKey(e => e.HoaDonId);
                e.HasOne(e => e.NguoiDung).WithMany(e => e.getHoaDon).HasForeignKey(e => e.NguoiDungId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<HoaDonChiTiet>(e => {
                e.ToTable("HoaDonChiTiet");
                e.HasKey(e => e.HoaDonChiTietId);
                e.HasOne(e => e.HoaDon).WithMany(e => e.HoaDonChiTiet).HasForeignKey(e => e.HoaDonId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(e => e.sanPhams).WithMany(e => e.HoaDonChiTiet).HasForeignKey(e => e.SanPhamId).OnDelete(DeleteBehavior.Restrict);
                //e.HasOne(e => e.thuNuoi).WithMany(e => e.HoaDonChiTiet).HasForeignKey(e => e.ObjectId).OnDelete(DeleteBehavior.Restrict); ;
            });
            modelBuilder.Entity<CartItem>(e =>
            {
                e.ToTable("GioHang");
                e.HasKey(e => e.CartItemId);
                e.HasOne(e=>e.SanPham).WithMany(e=>e.CartItem).HasForeignKey(e=>e.SanPhamId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(e=>e.NguoiDung).WithMany(e=>e.getCartItem).HasForeignKey(e=>e.NguoiDungId).OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
