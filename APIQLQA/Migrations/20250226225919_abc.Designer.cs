﻿// <auto-generated />
using System;
using APIQLQA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIQLQA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250226225919_abc")]
    partial class abc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIQLQA.Model.ChiTietDonHang", b =>
                {
                    b.Property<int>("MaChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTiet"));

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("MaSanPham");

                    b.ToTable("ChiTietDonHangs");
                });

            modelBuilder.Entity("APIQLQA.Model.DanhMucSanPham", b =>
                {
                    b.Property<int>("MaDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhMuc"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDanhMuc");

                    b.ToTable("DanhMucSanPhams");
                });

            modelBuilder.Entity("APIQLQA.Model.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiDungMaNguoiDung")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDonHang");

                    b.HasIndex("NguoiDungMaNguoiDung");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("APIQLQA.Model.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThem")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaGioHang");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("MaSanPham");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("APIQLQA.Model.NguoiDung", b =>
                {
                    b.Property<int>("MaNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNguoiDung"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNguoiDung");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("APIQLQA.Model.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<string>("ChatLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DanhMucSanPhamMaDanhMuc")
                        .HasColumnType("int");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KichThuoc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaDanhMuc")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ThuongHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XuatXu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("DanhMucSanPhamMaDanhMuc");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("APIQLQA.Model.ChiTietDonHang", b =>
                {
                    b.HasOne("APIQLQA.Model.DonHang", "DonHang")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIQLQA.Model.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("APIQLQA.Model.DonHang", b =>
                {
                    b.HasOne("APIQLQA.Model.NguoiDung", "NguoiDung")
                        .WithMany("DonHangs")
                        .HasForeignKey("NguoiDungMaNguoiDung");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("APIQLQA.Model.GioHang", b =>
                {
                    b.HasOne("APIQLQA.Model.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIQLQA.Model.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("APIQLQA.Model.SanPham", b =>
                {
                    b.HasOne("APIQLQA.Model.DanhMucSanPham", "DanhMucSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("DanhMucSanPhamMaDanhMuc");

                    b.Navigation("DanhMucSanPham");
                });

            modelBuilder.Entity("APIQLQA.Model.DanhMucSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("APIQLQA.Model.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });

            modelBuilder.Entity("APIQLQA.Model.NguoiDung", b =>
                {
                    b.Navigation("DonHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
