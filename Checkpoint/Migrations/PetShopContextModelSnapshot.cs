﻿// <auto-generated />
using System;
using Checkpoint.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Checkpoint.Migrations
{
    [DbContext(typeof(PetShopContext))]
    partial class PetShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Checkpoint.Models.Amigo", b =>
                {
                    b.Property<int>("CachorroId")
                        .HasColumnType("int");

                    b.Property<int>("GatoId")
                        .HasColumnType("int");

                    b.HasKey("CachorroId", "GatoId");

                    b.HasIndex("GatoId");

                    b.ToTable("Tbl_Amigo");
                });

            modelBuilder.Entity("Checkpoint.Models.Cachorro", b =>
                {
                    b.Property<int>("CachorroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Castrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Raca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexo")
                        .HasColumnType("int");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("CachorroId");

                    b.HasIndex("TutorId");

                    b.ToTable("Tbl_Cachorro");
                });

            modelBuilder.Entity("Checkpoint.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Tbl_Endereco");
                });

            modelBuilder.Entity("Checkpoint.Models.Gato", b =>
                {
                    b.Property<int>("GatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Castrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Raca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexo")
                        .HasColumnType("int");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("GatoId");

                    b.HasIndex("TutorId");

                    b.ToTable("Tbl_Gato");
                });

            modelBuilder.Entity("Checkpoint.Models.Tutor", b =>
                {
                    b.Property<int>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date")
                        .HasColumnName("Dt_Nascimento");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroTutor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("TutorId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Tbl_Tutor");
                });

            modelBuilder.Entity("Checkpoint.Models.Amigo", b =>
                {
                    b.HasOne("Checkpoint.Models.Cachorro", "Cachorro")
                        .WithMany("Amigos")
                        .HasForeignKey("CachorroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Checkpoint.Models.Gato", "Gato")
                        .WithMany("Amigos")
                        .HasForeignKey("GatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cachorro");

                    b.Navigation("Gato");
                });

            modelBuilder.Entity("Checkpoint.Models.Cachorro", b =>
                {
                    b.HasOne("Checkpoint.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Checkpoint.Models.Gato", b =>
                {
                    b.HasOne("Checkpoint.Models.Tutor", "Tutor")
                        .WithMany("Gatos")
                        .HasForeignKey("TutorId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Checkpoint.Models.Tutor", b =>
                {
                    b.HasOne("Checkpoint.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Checkpoint.Models.Cachorro", b =>
                {
                    b.Navigation("Amigos");
                });

            modelBuilder.Entity("Checkpoint.Models.Gato", b =>
                {
                    b.Navigation("Amigos");
                });

            modelBuilder.Entity("Checkpoint.Models.Tutor", b =>
                {
                    b.Navigation("Gatos");
                });
#pragma warning restore 612, 618
        }
    }
}