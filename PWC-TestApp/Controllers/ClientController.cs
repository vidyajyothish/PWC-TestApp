using MediatR;
using Microsoft.AspNetCore.Mvc;
using PWC_TestApp.Commands;
using PWC_TestApp.Models;
using PWC_TestApp.Queries;

namespace PWC_TestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;
        public ClientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetClientList")]
        public async Task<List<Client>> GetClientList()
        {
            var clientList = await mediator.Send(new GetClientListQuery());

            return clientList;
        }

        [HttpGet]
        [Route("GetClientDetails")]
        public async Task<IActionResult> GetClientDetails(int clientId)
        {
            var clientDetails = await mediator.Send(new GetClientByIdQuery() { Id = clientId });
            if (clientDetails != null)
                return StatusCode(201, clientDetails);
            else
                return StatusCode(201, "No data found");
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<bool> AddClient([FromBody] Client client)
        {
            return await mediator.Send(new CreateClientCommand(
                client.ClientName,
                client.ClientEmail,
                client.JoinedDate));
        }

        [HttpPut]
        [Route("UpdateClient")]
        public async Task<int> UpdateClient(Client client)
        {
            var isClientDetailUpdated = await mediator.Send(new UpdateClientCommand(
               client.ClientId,
               client.ClientName,
               client.ClientEmail,
               client.JoinedDate));
            return isClientDetailUpdated;
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public async Task<int> DeleteClient(int clientId)
        {
            return await mediator.Send(new DeleteClientCommand() { ClientId = clientId });
        }
    }
}