﻿using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<RolEntity> RolEntity { get; set; }
        public DbSet<RolUserEntity> RolUserEntity { get; set; }
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<RolPermissionEntity> RolPermissionEntity { get; set; }
        public DbSet<TypePermissionEntity> TypePermissionEntity { get; set; }


        public DbSet<BooksEntity> BocksEntity { get; set; }
        public DbSet<EditorialEntity> EditorialEntity { get; set; }
        public DbSet<AuthorsEntity> AuthorsEntity { get; set; }
        public DbSet<AuthorbooksEntity> AuthorbooksEntity { get; set; }



        public DbSet<TypeStateEntity> TypeStateEntity { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(b => b.Email)
                .IsUnique();

            //// este código es para hacer una excepción con los ID que les seteamos en el Enums
            modelBuilder.Entity<TypeStateEntity>().Property(t => t.IdTypeState).ValueGeneratedNever();
            modelBuilder.Entity<TypePermissionEntity>().Property(t => t.IdTypePermission).ValueGeneratedNever();
            modelBuilder.Entity<RolEntity>().Property(t => t.IdRol).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.IdPermission).ValueGeneratedNever();
        }

    }
}
