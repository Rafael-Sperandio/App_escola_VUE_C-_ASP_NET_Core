using Microsoft.AspNetCore.Mvc;

namespace project_school_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : Controller
    {


        private readonly ILogger<ProfessorController> _logger;
        //rever nececidade loger
        public ProfessorController(ILogger<ProfessorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "valores")]
        public string GetAluno()
        {
            return "Aluno";
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{professorId")]
        public IActionResult GetId(int professorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("{professorId")]

        public IActionResult Put(int professorId)
        {
            return Ok();
        }

        [HttpDelete("{professorId")]
        public IActionResult Delete(int professorId)
        {
            return Ok();
        }

        /*
        [HttpGet]
        public IActionResult Get()
        {
        }
        */
    }
}
