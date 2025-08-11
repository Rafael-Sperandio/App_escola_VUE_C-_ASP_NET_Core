using Microsoft.EntityFrameworkCore;
using project_school_API.Models;

namespace project_school_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        { 
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>().HasData( new List<Professor>() {
                new Professor()
                {
                    Id = 1,
                    Nome = "Vinicius",

                },
                new Professor()
                {
                    Id = 2,
                    Nome = "Rafael",

                },
                new Professor()
                {
                    Id = 3,
                    Nome = "Luna",

                },
            }
            );
            modelBuilder.Entity<Aluno>().HasData(new List<Aluno>() 
            {
                new Aluno()
                {
                    Id = 1,
                    Nome = "Maria",
                    Sobrenome = "silva",
                    DataNasc = "02/02/2002",
                    ProfessorId = 1,

                },
                new Aluno()
                {
                    Id = 2,
                    Nome = "joão",
                    Sobrenome= "Fenades",
                    DataNasc = "01/01/2001",
                    ProfessorId = 2,
                },
                new Aluno()
                {
                    Id = 3,
                    Nome = "alex",
                    Sobrenome ="Alencar",
                    DataNasc = "03/03/1999",
                    ProfessorId = 3,
                },
            });

            //base.OnModelCreating(modelBuilder);
        }

    }
}
