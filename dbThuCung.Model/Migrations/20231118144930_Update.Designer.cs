﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dbThuCung.Model.Context;

#nullable disable

namespace dbThuCung.Model.Migrations
{
    [DbContext(typeof(ThuCungContext))]
    [Migration("20231118144930_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("dbThuCung.Model.Entities.DanhMuc", b =>
                {
                    b.Property<long>("DanhMucId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DanhMucId"), 1L, 1);

                    b.Property<string>("DanhMucTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhMucId");

                    b.ToTable("DanhMuc", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.HoaDon", b =>
                {
                    b.Property<long>("HoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("HoaDonId"), 1L, 1);

                    b.Property<string>("HoaDonDiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoaDonSdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayTao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NguoiDungId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("HoaDonId");

                    b.HasIndex("NguoiDungId");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.HoaDonChiTiet", b =>
                {
                    b.Property<long>("HoaDonChiTietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("HoaDonChiTietId"), 1L, 1);

                    b.Property<long>("HoaDonId")
                        .HasColumnType("bigint");

                    b.Property<long>("ObjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("HoaDonChiTietId");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("ObjectId");

                    b.ToTable("HoaDonChiTiet", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.NguoiDung", b =>
                {
                    b.Property<long>("NguoiDungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NguoiDungId"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiDungHinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguoiDungId");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.SanPham", b =>
                {
                    b.Property<long>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SanPhamId"), 1L, 1);

                    b.Property<long>("DanhMucId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SanPhamGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SanPhamHinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SanPhamTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanPhamId");

                    b.HasIndex("DanhMucId");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.ThuNuoi", b =>
                {
                    b.Property<long>("ThuNuoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ThuNuoiId"), 1L, 1);

                    b.Property<long>("DanhMucId")
                        .HasColumnType("bigint");

                    b.Property<string>("MauLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ThuNuoiGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ThuNuoiHinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThuNuoiTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThuNuoiId");

                    b.HasIndex("DanhMucId");

                    b.ToTable("ThuNuoi", (string)null);
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.HoaDon", b =>
                {
                    b.HasOne("dbThuCung.Model.Entities.NguoiDung", "NguoiDung")
                        .WithMany("getHoaDon")
                        .HasForeignKey("NguoiDungId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.HoaDonChiTiet", b =>
                {
                    b.HasOne("dbThuCung.Model.Entities.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiet")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("dbThuCung.Model.Entities.SanPham", "sanPhams")
                        .WithMany("HoaDonChiTiet")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("dbThuCung.Model.Entities.ThuNuoi", "thuNuoi")
                        .WithMany("HoaDonChiTiet")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("sanPhams");

                    b.Navigation("thuNuoi");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.SanPham", b =>
                {
                    b.HasOne("dbThuCung.Model.Entities.DanhMuc", "getDanhMuc")
                        .WithMany("SanPham")
                        .HasForeignKey("DanhMucId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("getDanhMuc");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.ThuNuoi", b =>
                {
                    b.HasOne("dbThuCung.Model.Entities.DanhMuc", "getDanhMuc")
                        .WithMany("ThuNuoi")
                        .HasForeignKey("DanhMucId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("getDanhMuc");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.DanhMuc", b =>
                {
                    b.Navigation("SanPham");

                    b.Navigation("ThuNuoi");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiet");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.NguoiDung", b =>
                {
                    b.Navigation("getHoaDon");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.SanPham", b =>
                {
                    b.Navigation("HoaDonChiTiet");
                });

            modelBuilder.Entity("dbThuCung.Model.Entities.ThuNuoi", b =>
                {
                    b.Navigation("HoaDonChiTiet");
                });
#pragma warning restore 612, 618
        }
    }
}
