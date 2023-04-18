using MediatR;
using PWC_TestApp.Commands;
using PWC_TestApp.Models;
using PWC_TestApp.Repositories;
namespace PWC_TestApp.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<bool> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var clientDetails = new Client()
            {
                ClientName = command.ClientName,
                ClientEmail = command.ClientEmail,
                JoinedDate  = command.JoinedDate,
            };

            return await _clientRepository.AddClientAsync(clientDetails);
        }
    }
}
