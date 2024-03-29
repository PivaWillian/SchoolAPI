﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI.DataBase;

#nullable disable

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(EscolaDBContext))]
    [Migration("20230808132127_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("SchoolAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTGER")
                        .HasColumnName("PK_ID");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("GENERO");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NOME");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("SOBRENOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id")
                        .HasName("Pk_aluno_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("AlunoTB", (string)null);
                });

            modelBuilder.Entity("SchoolAPI.Models.AlunoTurma", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ALUNO_ID");

                    b.Property<int>("TurmaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TURMA_ID");

                    b.HasKey("AlunoId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ALUNO_X_TURMA", (string)null);
                });

            modelBuilder.Entity("SchoolAPI.Models.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("DATA");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("BOLETIM", (string)null);
                });

            modelBuilder.Entity("SchoolAPI.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("SchoolAPI.Models.NotasMaterias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoletimId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MateriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoletimId");

                    b.HasIndex("MateriaId");

                    b.ToTable("NotasMaterias");
                });

            modelBuilder.Entity("SchoolAPI.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Curso Basico")
                        .HasColumnName("CURSO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("TURMA", (string)null);
                });

            modelBuilder.Entity("SchoolAPI.Models.AlunoTurma", b =>
                {
                    b.HasOne("SchoolAPI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("SchoolAPI.Models.Boletim", b =>
                {
                    b.HasOne("SchoolAPI.Models.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("SchoolAPI.Models.NotasMaterias", b =>
                {
                    b.HasOne("SchoolAPI.Models.Boletim", "Boletim")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("BoletimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Models.Materia", "Materia")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("SchoolAPI.Models.Aluno", b =>
                {
                    b.Navigation("Boletins");
                });

            modelBuilder.Entity("SchoolAPI.Models.Boletim", b =>
                {
                    b.Navigation("NotasMaterias");
                });

            modelBuilder.Entity("SchoolAPI.Models.Materia", b =>
                {
                    b.Navigation("NotasMaterias");
                });
#pragma warning restore 612, 618
        }
    }
}
