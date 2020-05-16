﻿// <auto-generated />
using DatabaseScriptRunner.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseScriptRunner.Infraestructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseScriptRunner.Domain.Entities.ActionUser", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUser");

                    b.Property<string>("command");

                    b.HasKey("IdAction");

                    b.ToTable("ActionUsers");
                });

            modelBuilder.Entity("DatabaseScriptRunner.Domain.Entities.Database", b =>
                {
                    b.Property<int>("IdDatabase")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionString");

                    b.Property<string>("Name");

                    b.HasKey("IdDatabase");

                    b.ToTable("Databases");
                });

            modelBuilder.Entity("DatabaseScriptRunner.Domain.Entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseScriptRunner.Domain.Entities.UserDatabase", b =>
                {
                    b.Property<int>("IdDatabase");

                    b.Property<int>("IdUser");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IdDatabase", "IdUser");

                    b.HasAlternateKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("UserDatabase");
                });

            modelBuilder.Entity("DatabaseScriptRunner.Domain.Entities.UserDatabase", b =>
                {
                    b.HasOne("DatabaseScriptRunner.Domain.Entities.Database")
                        .WithMany("UserDatabases")
                        .HasForeignKey("IdDatabase")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseScriptRunner.Domain.Entities.User")
                        .WithMany("UserDatabases")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}