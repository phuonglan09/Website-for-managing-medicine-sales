using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doctors.Base.Models
{
    public partial class DoctorskinCoreContext : DbContext
    {
        public DoctorskinCoreContext()
        {
        }

        public DoctorskinCoreContext(DbContextOptions<DoctorskinCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<BlogDetail> BlogDetails { get; set; } = null!;
        public virtual DbSet<BlogType> BlogTypes { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServicesDetail> ServicesDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleGroup> RoleGroups { get; set; }
        public virtual DbSet<Module> Modules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.Blogpage).HasColumnName("Blogpage");

                entity.Property(e => e.Homepage).HasColumnName("Homepage");

                entity.Property(e => e.Image).HasColumnName("Image");

                entity.Property(e => e.Productpage).HasColumnName("Productpage");

                entity.Property(e => e.Servicepage).HasColumnName("Servicepage");
            });
            modelBuilder.Entity<BlogDetail>(entity =>
            {
                entity.Property(e => e.Cardimg).HasColumnName("Cardimg");

                entity.Property(e => e.Contentblog).HasColumnName("Contentblog");

                entity.Property(e => e.DateUp)
                    .HasColumnType("datetime")
                    .HasColumnName("DateUp");

                entity.Property(e => e.Hideblog).HasColumnName("Hideblog");

                entity.Property(e => e.BlogTypeId).HasColumnName("BlogTypeId");

                entity.Property(e => e.Shortcontent).HasColumnName("Shortcontent");

                entity.Property(e => e.Title).HasColumnName("Title");
            });

            modelBuilder.Entity<BlogType>(entity =>
            {
                entity.Property(e => e.Hide).HasColumnName("Hide");

                entity.Property(e => e.Namebt).HasColumnName("Namebt");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.Property(e => e.OrderCode).HasColumnName("OrderCode");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.Status).HasColumnName("Status");
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.UnitPrice).HasColumnName("UnitPrice");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");
            });
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Completed).HasColumnName("Completed");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Phone).HasColumnName("Phone");

                entity.Property(e => e.Require).HasColumnName("Require");

                entity.Property(e => e.Timebooking)
                    .HasColumnType("datetime")
                    .HasColumnName("Timebooking");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Hidebrand).HasColumnName("Hidebrand");

                entity.Property(e => e.Namebrand).HasColumnName("Namebrand");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Idp).HasColumnName("idp");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateUp)
                    .HasColumnType("datetime")
                    .HasColumnName("DateUp");

                entity.Property(e => e.Hide).HasColumnName("Hide");

                entity.Property(e => e.Namec).HasColumnName("Namec");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.AvaDoc).HasColumnName("AvaDoc");

                entity.Property(e => e.DateUpDoc)
                    .HasColumnType("datetime")
                    .HasColumnName("DateUpDoc");

                entity.Property(e => e.HideDoc).HasColumnName("HideDoc");

                entity.Property(e => e.Infordoc).HasColumnName("Infordoc");

                entity.Property(e => e.Namedoc).HasColumnName("Namedoc");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Avilability).HasColumnName("Avilability");

                entity.Property(e => e.DateUp)
                    .HasColumnType("datetime")
                    .HasColumnName("DateUp");

                entity.Property(e => e.Descr).HasColumnName("Descr");

                entity.Property(e => e.Hide).HasColumnName("Hide");

                entity.Property(e => e.Idbrand).HasColumnName("Idbrand");

                entity.Property(e => e.Img).HasColumnName("Img");

                entity.Property(e => e.Listimg).HasColumnName("Listimg");

                entity.Property(e => e.Namep).HasColumnName("Namep");

                entity.Property(e => e.Newprice).HasColumnName("newprice");

                entity.Property(e => e.Oldprice).HasColumnName("Oldprice");

                entity.Property(e => e.Rated).HasColumnName("Rated");

                entity.Property(e => e.Statep).HasColumnName("Statep");

                entity.Property(e => e.CateId).HasColumnName("CateId");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.DescDt).HasColumnName("DescDt");

                entity.Property(e => e.HideDt).HasColumnName("HideDt");

                entity.Property(e => e.ImgDt).HasColumnName("ImgDt");

                entity.Property(e => e.NameDt).HasColumnName("NameDt");

            });

            modelBuilder.Entity<ServicesDetail>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.DescDe).HasColumnName("DescDe");

                entity.Property(e => e.HideSd).HasColumnName("HideSd");

                entity.Property(e => e.IdDt).HasColumnName("IdDt");

                entity.Property(e => e.ImgSd).HasColumnName("ImgSd");

                entity.Property(e => e.NameSd).HasColumnName("NameSd");

                entity.Property(e => e.PriceSd).HasColumnName("PriceSd");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Ava).HasColumnName("Ava");

                entity.Property(e => e.Birth)
                    .HasColumnType("datetime")
                    .HasColumnName("Birth");

                entity.Property(e => e.Dateregist)
                    .HasColumnType("datetime")
                    .HasColumnName("Dateregist");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("Gender");

                entity.Property(e => e.Hide).HasColumnName("Hide");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Password).HasColumnName("Password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("Phone");
            });         
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });
            modelBuilder.Entity<RoleGroup>(entity =>
            {
                entity.ToTable("RoleGroup");
            });
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
