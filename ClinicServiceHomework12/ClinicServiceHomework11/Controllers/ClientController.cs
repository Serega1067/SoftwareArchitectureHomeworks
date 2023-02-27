using ClinicServiceHomework11.Services;
using ClinicServiceHomework11.Models;
using ClinicServiceHomework11.Models.Requests;
using ClinicServiceHomework11.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicServiceHomework11.Controllers
{
    // [controller] это шаблон в место которого будит автоматически
    // подставлятся имя данного контроллера, то есть Client
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // Создадим вспомогательную переменную и сохраним ссылку
        // на эту переменную репозитория
        // Тем самым мы сможем в рамках наших методов действий
        // работать с этим репозиторием
        private IClientRepository _clientRepository;

        // В качестве зависимости передадим ссылку на интерфейс
        // в рамках которого этот объект будит имплиментирован
        public ClientController(IClientRepository clientRepository)
        {
            // Здесь прописывать this ненужно, так как у экземпляра
            // текущего объекта _clientRepository имя с нижним
            // подчёркиванием и оно уникальное
            // Все филды можно именовать со знака подчёркивания
            _clientRepository = clientRepository;
        }

        // Далее протянем некоторые методы действий
        // У нас есть сущность клиента и мы можем добавлять
        // клиента, удалять клиента и редактировать клиента
        [HttpPost("create")]
        [SwaggerOperation(OperationId = "ClientCreate")]
        public ActionResult<int> Create([FromBody] CreateClientRequest createClientRequest)
        {
            Client client = new Client();
            client.Document = createClientRequest.Document;
            client.SurName = createClientRequest.SurName;
            client.FirstName = createClientRequest.FirstName;
            client.Patronymic = createClientRequest.Patronymic;
            client.Birthday = createClientRequest.Birthday;
            int res = _clientRepository.Create(client);
            return Ok(res); // заглушка
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "ClientUpdate")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest updateClientRequest)
        {
            Client client = new Client();
            client.ClientId = updateClientRequest.ClientId;
            client.Document = updateClientRequest.Document;
            client.SurName = updateClientRequest.SurName;
            client.FirstName = updateClientRequest.FirstName;
            client.Patronymic = updateClientRequest.Patronymic;
            client.Birthday = updateClientRequest.Birthday;
            int res = _clientRepository.Update(client);
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "ClientDelete")]
        public ActionResult<int> Delete([FromQuery] int clientId)
        {
            int res = _clientRepository.Delete(clientId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "ClientGetAll")]
        public ActionResult<IList<Client>> GetAll()
        {
            IList<Client> clients = _clientRepository.GetAll();
            return Ok(clients);
        }

        [HttpGet("get-by-id/{clientId}")]
        [SwaggerOperation(OperationId = "ClientGetById")]
        public ActionResult<Client> GetById([FromRoute] int clientId)
        {
            Client client = _clientRepository.GetById(clientId);
            return Ok(client);
        }
    }
}
