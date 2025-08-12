using project_school_API.Models;

namespace project_school_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;

        void Update<T>(T entity) where T : class;

        // TODO criar um comportamento que aceita id ao invés de entidade
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //TODO criar repositorio aluno e repositorio Professor

        ///aluno mudar para um repository aluno

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false);

        Task<Aluno[]> GetAllAlunosAsyncByProfessorId(int professorId, bool includeProfessor = false);

        Task<Aluno> GetAlunoByIdAsync( int alunoId, bool includeProfessor = false);

        //Professor
        Task<Professor[]> GetAllProfesoresAsync(bool includealuno = false);

        Task<Professor> GetProfesoreByIdAsync(int professorId, bool includealuno = false);
        ///Task<bool> GetAlProfesoresAsync();
    }
}
