﻿// <auto-generated />
using System;
using API_Mercado.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Mercado.Migrations
{
    [DbContext(typeof(API_MercadoContext))]
    partial class API_MercadoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_Mercado.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PRODUTO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_VALIDADE_PRODUTO");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("NM_PRODUTO");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("VLR_PRODUTO");

                    b.HasKey("Id");

                    b.ToTable("TB_PRODUTO");
                });

            modelBuilder.Entity("API_Mercado.Models.User", b =>
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

            modelBuilder.Entity("API_Mercado.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_VENDA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("ID_USUARIO_VENDA");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("VLR_TOTAL_VENDA");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("TB_VENDA");
                });

            modelBuilder.Entity("API_Mercado.Models.VendaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_VENDA_ITEM")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int")
                        .HasColumnName("ID_PRODUTO");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int")
                        .HasColumnName("ID_VENDA");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("QTD_VENDA");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdVenda");

                    b.ToTable("TB_VENDA_ITEM");
                });

            modelBuilder.Entity("API_Mercado.Models.Venda", b =>
                {
                    b.HasOne("API_Mercado.Models.User", "Usuario")
                        .WithMany("Vendas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API_Mercado.Models.VendaItem", b =>
                {
                    b.HasOne("API_Mercado.Models.Produto", "Produto")
                        .WithMany("VendasDoProduto")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_Mercado.Models.Venda", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("API_Mercado.Models.Produto", b =>
                {
                    b.Navigation("VendasDoProduto");
                });

            modelBuilder.Entity("API_Mercado.Models.User", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("API_Mercado.Models.Venda", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
