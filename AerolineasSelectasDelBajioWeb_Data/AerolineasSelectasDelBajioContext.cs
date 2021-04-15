using System;
using AerolineasSelectasDelBajioWeb_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_UI.Models
{
    public partial class AerolineasSelectasDelBajioContext : DbContext
    {
        public AerolineasSelectasDelBajioContext()
        {
        }

        public AerolineasSelectasDelBajioContext(DbContextOptions<AerolineasSelectasDelBajioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SourceDestiny> SourceDestiny { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=aerolineasselectasdelbajio.database.windows.net;Initial Catalog=AerolineasSelectasDelBajio;User=fredy97;Password=PanteraOpeth1993");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("airplane");

                entity.HasIndex(e => e.AirplaneName)
                    .HasName("UC_AirplaneName")
                    .IsUnique();

                entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");

                entity.Property(e => e.AirplaneName)
                    .IsRequired()
                    .HasColumnName("airplane_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AirplaneNplaces).HasColumnName("airplane_nplaces");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CityName)
                    .HasName("UC_CityName")
                    .IsUnique();

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.SaleAspnetusersId)
                    .IsRequired()
                    .HasColumnName("sale_aspnetusers_id")
                    .HasMaxLength(450);

                entity.Property(e => e.SaleCreditcard)
                    .HasColumnName("sale_creditcard")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SalePassengerType)
                    .HasColumnName("sale_passenger_type")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SaleDate)
                    .HasColumnName("sale_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleName)
                    .HasColumnName("sale_name")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SaleSubtotal)
                    .HasColumnName("sale_subtotal")
                    .HasColumnType("money");

                entity.Property(e => e.SaleTax)
                    .HasColumnName("sale_tax")
                    .HasColumnType("money");

                entity.Property(e => e.SaleTotal)
                    .HasColumnName("sale_total")
                    .HasColumnType("money");

                entity.HasOne(d => d.SaleAspnetusers)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.SaleAspnetusersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleUser");
            });

            modelBuilder.Entity<SourceDestiny>(entity =>
            {
                entity.ToTable("source_destiny");

                entity.HasIndex(e => new { e.SourceDestinyFrom, e.SourceDestinyTo })
                    .HasName("UC_FromTo")
                    .IsUnique();

                entity.Property(e => e.SourceDestinyId).HasColumnName("source_destiny_id");

                entity.Property(e => e.SourceDestinyFrom).HasColumnName("source_destiny_from");

                entity.Property(e => e.SourceDestinyTo).HasColumnName("source_destiny_to");

                entity.HasOne(d => d.SourceDestinyFromNavigation)
                    .WithMany(p => p.SourceDestinySourceDestinyFromNavigation)
                    .HasForeignKey(d => d.SourceDestinyFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityFrom");

                entity.HasOne(d => d.SourceDestinyToNavigation)
                    .WithMany(p => p.SourceDestinySourceDestinyToNavigation)
                    .HasForeignKey(d => d.SourceDestinyTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityTo");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => new { e.TicketNPlace, e.TicketAirplaneId, e.TicketDepartureTime, e.TicketSourceDestinyId })
                    .HasName("UC_AirplaneTimePlace")
                    .IsUnique();

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.TicketAirplaneId).HasColumnName("ticket_airplane_id");

                entity.Property(e => e.TicketDepartureTime)
                    .HasColumnName("ticket_departure_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketNPlace).HasColumnName("ticket_n_place");

                entity.Property(e => e.TicketPrice)
                    .HasColumnName("ticket_price")
                    .HasColumnType("money");

                entity.Property(e => e.TicketSaleId).HasColumnName("ticket_sale_id");

                entity.Property(e => e.TicketSourceDestinyId).HasColumnName("ticket_source_destiny_id");

                entity.HasOne(d => d.TicketAirplane)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketAirplaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketAirplane");

                entity.HasOne(d => d.TicketSale)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketSaleId)
                    .HasConstraintName("FK_TicketSale");

                entity.HasOne(d => d.TicketSourceDestiny)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketSourceDestinyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketSourceDestiny");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
