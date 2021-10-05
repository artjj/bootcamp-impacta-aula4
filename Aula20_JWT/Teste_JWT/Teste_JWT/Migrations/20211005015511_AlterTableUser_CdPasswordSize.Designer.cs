﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste_JWT.Models;

namespace Teste_JWT.Migrations
{
    [DbContext(typeof(Teste_JWTDbContext))]
    [Migration("20211005015511_AlterTableUser_CdPasswordSize")]
    partial class AlterTableUser_CdPasswordSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teste_JWT.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_USER")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("CD_EMAIL");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NM_USER");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("CD_PASSWORD");

                    b.Property<string>("Profile")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CD_PROFILE");

                    b.HasKey("Id");

                    b.ToTable("TB_USER");
                });
#pragma warning restore 612, 618
        }
    }
}
