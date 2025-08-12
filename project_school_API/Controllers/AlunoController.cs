using Microsoft.AspNetCore.Mvc;
using project_school_API.Data;
using project_school_API.Models;

namespace project_school_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {


        private readonly ILogger<AlunoController> _logger;
        private readonly IRepository _repository;
        //rever nececidade loger
        public AlunoController(ILogger<AlunoController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,"Banco de dados falhou");
            }
            
        }
        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetbyAlunoId(int alunoId)
        {
            try
            {
                var result = await _repository.GetAlunoByIdAsync(alunoId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }
        [HttpGet("ByProfessor/{professorId}")]
        public async Task<IActionResult> GetbyProfessorId(int professorId)
        {
            try
            {
                var result = await _repository.GetAllAlunosAsyncByProfessorId(professorId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repository.Add(aluno);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/Aluno/{aluno.Id}",aluno);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }
        [HttpPut("{alunoId}")]

        public async Task<IActionResult> Put(int alunoId, Aluno aluno)
        {
            try
            {
                var alunoExite = await _repository.GetAlunoByIdAsync(alunoId);
                if(alunoExite == null)
                {
                    return NotFound();
                }

                _repository.Update(aluno);
                if (await _repository.SaveChangesAsync())
                {
                    aluno = await _repository.GetAlunoByIdAsync(alunoId,true);
                    return Created($"/Aluno/{aluno.Id}", aluno);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                //StatusCode.Status500InternalServerError
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }

        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                var alunoExite = await _repository.GetAlunoByIdAsync(alunoId);
                if (alunoExite == null)
                {
                    return NotFound();
                }

                _repository.Delete(alunoExite);
                if (await _repository.SaveChangesAsync())
                {
                    alunoExite = await _repository.GetAlunoByIdAsync(alunoId, true);
                    return Ok(); 
                        ///Created($"/Aluno/{alunoExite.Id}", alunoExite);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }
        
    }
}
