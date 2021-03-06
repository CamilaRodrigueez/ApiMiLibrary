// <auto-generated />
using Infraestructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220317042852_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.AuthorbooksEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdBooks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuthor");

                    b.HasIndex("IdBooks")
                        .IsUnique();

                    b.ToTable("AuthorsBooks","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.AuthorsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Authors","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.BooksEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeState")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IdEditorial");

                    b.HasIndex("IdTypeState");

                    b.ToTable("Bocks","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.EditorialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Editorial","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Master.TypeStateEntity", b =>
                {
                    b.Property<int>("IdTypeState")
                        .HasColumnType("int");

                    b.Property<string>("TypeState")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdTypeState");

                    b.ToTable("TypeState","Master");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.PermissionEntity", b =>
                {
                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("IdTypePermission")
                        .HasColumnType("int");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPermission");

                    b.HasIndex("IdTypePermission");

                    b.ToTable("Permission","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.RolEntity", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdRol");

                    b.ToTable("Rol","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.RolPermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermission");

                    b.HasIndex("IdRol");

                    b.ToTable("RolesPermission","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.RolUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdUser");

                    b.ToTable("RolUser","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.TypePermissionEntity", b =>
                {
                    b.Property<int>("IdTypePermission")
                        .HasColumnType("int");

                    b.Property<string>("TypePermission")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypePermission");

                    b.ToTable("TypePermission","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.UserEntity", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("IdUser");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.AuthorbooksEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Library.AuthorsEntity", "AuthorsEntity")
                        .WithMany()
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Library.BooksEntity", "BooksEntity")
                        .WithOne("AuthorbooksEntity")
                        .HasForeignKey("Infraestructure.Entity.Models.Library.AuthorbooksEntity", "IdBooks")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.BooksEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Library.EditorialEntity", "EditorialEntity")
                        .WithMany()
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Master.TypeStateEntity", "TypeStateEntity")
                        .WithMany()
                        .HasForeignKey("IdTypeState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.PermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Security.TypePermissionEntity", "TypePermissionEntity")
                        .WithMany("PermissionEntities")
                        .HasForeignKey("IdTypePermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.RolPermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Security.PermissionEntity", "PermissionEntity")
                        .WithMany("RolPermissionEntities")
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Security.RolEntity", "RolEntity")
                        .WithMany("RolPermissionEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Security.RolUserEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Security.RolEntity", "RolEntity")
                        .WithMany("RolUserEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Security.UserEntity", "UserEntity")
                        .WithMany("RolUserEntities")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
