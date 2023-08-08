using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.DataBase
{
    public class EscolaDBContext:DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=School.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("AlunoTB");

            modelBuilder.Entity<Aluno>().HasKey(x => x.Id)
                                        .HasName("Pk_aluno_id");

            modelBuilder.Entity<Aluno>().Property(x => x.Id)
                                        .HasColumnName("PK_ID")
                                        .HasColumnType("INTEGER");

            modelBuilder.Entity<Aluno>().Property(x => x.Name)
                                        .IsRequired()
                                        .HasColumnName("NOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);

            modelBuilder.Entity<Aluno>().Property(x => x.SobreNome)
                                        .IsRequired()
                                        .HasColumnName("SOBRENOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Ignore(x => x.Idade);

            modelBuilder.Entity<Aluno>().Property(x => x.Email)
                                        .IsRequired()
                                        .HasColumnName("EMAIL")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);


            modelBuilder.Entity<Aluno>().HasIndex(x => x.Email)
                                        .IsUnique();

            modelBuilder.Entity<Aluno>().Property(x => x.Genero)
                                        .HasColumnName("GENERO")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(20);

            modelBuilder.Entity<Aluno>().Property(x => x.Telefone)
                                        .HasColumnName("TELEFONE")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(30);

            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento)
                                        .HasColumnName("DATA_NASCIMENTO")
                                        .HasColumnType("datetime2");


            modelBuilder.Entity<Turma>().ToTable("TURMA");

            modelBuilder.Entity<Turma>().Property(x => x.Id)
                                        .HasColumnType("INTEGER")
                                        .HasColumnName("ID");

            modelBuilder.Entity<Turma>().HasKey(x => x.Id);


            modelBuilder.Entity<Turma>().Property(x => x.Curso)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasDefaultValue("Curso Basico")
                            .HasColumnName("CURSO");

            modelBuilder.Entity<Turma>().Property(x => x.Nome)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasColumnName("Nome");

            modelBuilder.Entity<Turma>().HasIndex(x => x.Nome)
                                        .IsUnique();


            modelBuilder.Entity<AlunoTurma>().ToTable("ALUNO_X_TURMA");
            modelBuilder.Entity<AlunoTurma>().Property(x => x.AlunoId)
                             .HasColumnType("INTEGER")
                             .HasColumnName("ALUNO_ID");

            modelBuilder.Entity<AlunoTurma>().Property(x => x.TurmaId)
                             .HasColumnType("INTEGER")
                             .HasColumnName("TURMA_ID");


            modelBuilder.Entity<Aluno>().HasMany(x => x.Turmas)
                                        .WithMany(x => x.Alunos)
                                        .UsingEntity<AlunoTurma>(
                                                    l => l.HasOne(x => x.Turma).WithMany().HasForeignKey(x => x.TurmaId),
                                                    r => r.HasOne(x => x.Aluno).WithMany().HasForeignKey(x => x.AlunoId)
                                                    );


            modelBuilder.Entity<Boletim>().ToTable("BOLETIM");


            modelBuilder.Entity<Boletim>().Property(x => x.Data)
                                            .HasColumnType("date")
                                           .HasColumnName("DATA");

            modelBuilder.Entity<Boletim>().HasOne(x => x.Aluno)
                                        .WithMany(x => x.Boletins)
                                        .HasForeignKey(x => x.AlunoId);


            //modelBuilder.Entity<Aluno>().HasMany(x => x.Boletins)
            //                            .WithOne(x => x.Aluno)
            //                            .HasForeignKey(x => x.AlunoId);


            modelBuilder.Entity<Boletim>().HasMany(x => x.NotasMaterias)
                                          .WithOne(x => x.Boletim)
                                          .HasForeignKey(x => x.BoletimId);


            //modelBuilder.Entity<NotasMateria>().HasOne(x => x.Boletim)
            //                              .WithMany(x => x.NotasMaterias)
            //                              .HasForeignKey(x => x.BoletimId);


            modelBuilder.Entity<NotasMaterias>().HasOne(x => x.Materia)
                                                .WithMany(x => x.NotasMaterias)
                                                .HasForeignKey(x => x.MateriaId);

        }
    }
}
