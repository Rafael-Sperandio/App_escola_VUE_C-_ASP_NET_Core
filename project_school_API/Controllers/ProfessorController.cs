using Microsoft.AspNetCore.Mvc;
using project_school_API.Data;
using project_school_API.Models;

namespace project_school_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : Controller
    {


        private readonly ILogger<ProfessorController> _logger;
        private readonly IRepository _repository;
        //rever nececidade loger
        public ProfessorController(ILogger<ProfessorController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllProfesoresAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }
        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var result = await _repository.GetProfesoreByIdAsync(professorId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            try
            {
                _repository.Add(professor);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/Professor/{professor.Id}", professor);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }
        [HttpPut("{professorId}")]

        public async Task<IActionResult> Put(int professorId, Professor professor)
        {
            try
            {
                var professorExiste = await _repository.GetProfesoreByIdAsync(professorId);
                if (professorExiste == null)
                {
                    return NotFound();
                }
                _repository.Update(professor);
                if (await _repository.SaveChangesAsync())
                {
                    professor = await _repository.GetProfesoreByIdAsync(professorId);
                    return Created($"/Professor/{professor.Id}", professor);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "Banco de dados falhou");
            }
        }

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                var professor = await _repository.GetProfesoreByIdAsync(professorId);
                if (professor == null)
                {
                    return NotFound();
                }
                _repository.Delete(professor);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();

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
