using Microsoft.AspNetCore.Mvc;

namespace project_school_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {


        private readonly ILogger<AlunoController> _logger;
        //rever nececidade loger
        public AlunoController(ILogger<AlunoController> logger)
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
        [HttpGet("{alunoId")]
        public IActionResult GetId()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("{alunoId")]

        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete("{alunoId")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
