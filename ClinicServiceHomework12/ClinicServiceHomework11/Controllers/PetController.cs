using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ClinicServiceHomework11.Models;

namespace ClinicServiceHomework11.Controllers
{
    // Для задания 12 сделаем здесь заглушки
    // Так же теперь при запуске кроме контроллеров клиента
    // появятся контроллеры, которые позволяют работать с животными
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]

        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            if (string.IsNullOrEmpty(createPetRequest.Name) ||
                createPetRequest.Name.Length < 3 ||
                createPetRequest.Birthday < DateTime.Now.AddYears(-25))
            {
                return BadRequest(0); // HTTP 400 BadRequestObjectResult
            }
            return Ok(1); // HTTP200 OkObjectResult
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]

        public ActionResult<int> Update()
        {
            return Ok(1);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "PetDelete")]

        public ActionResult<int> Delete(int petId)
        {
            if (petId <= 0)
            {
                return BadRequest(0);
            }
            return Ok(1);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "ClientGetAll")]

        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(1);
        }
    }
}
