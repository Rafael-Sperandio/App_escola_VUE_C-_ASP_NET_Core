
using Microsoft.EntityFrameworkCore;
using project_school_API.Models;
using System.Linq;

namespace project_school_API.Data
{
    public class Repository : IRepository
    {
        private DataContext _context {  get; }
        public Repository( DataContext context)
        {
            _context = context; 
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0 );
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> querry = _context.Alunos;
            if (includeProfessor)
            {
                querry = querry.Include(i => i.Professor);
            }
            querry = querry.AsNoTracking().OrderBy(a => a.Id);
            return await querry.ToArrayAsync();
        }
        ///alunos

        public async Task<Aluno[]> GetAllAlunosAsyncByProfessorId(int professorId, bool includeProfessor = false)
        {
            IQueryable<Aluno> querry = _context.Alunos;
            if (includeProfessor)
            {
                querry = querry.Include(i => i.Professor);
            }
            querry = querry.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.ProfessorId == professorId);
            return await querry.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> querry = _context.Alunos;
            if (includeProfessor)
            {
                querry = querry.Include(i => i.Professor);
            }
            querry = querry.AsNoTracking()
                            .Where(aluno => aluno.Id == alunoId);
            return await querry.FirstOrDefaultAsync();
        }

        /// profesores

        public async Task<Professor[]> GetAllProfesoresAsync(bool includealuno= false)
        {
            IQueryable<Professor> querry = _context.Professores;
            if (includealuno)
            {
                querry = querry.Include(i => i.Alunos);
            }
            querry = querry.AsNoTracking().OrderBy(p => p.Id);
            return await querry.ToArrayAsync();
        }

        public async Task<Professor> GetProfesoreByIdAsync(int professorId, bool includealuno = false)
        {
            IQueryable<Professor> querry = _context.Professores;
            if (includealuno)
            {
                querry = querry.Include(i => i.Alunos);
            }
            querry = querry.AsNoTracking()
                            .Where(professor => professor.Id == professorId);
            return await querry.FirstOrDefaultAsync();
        }
    }
}
