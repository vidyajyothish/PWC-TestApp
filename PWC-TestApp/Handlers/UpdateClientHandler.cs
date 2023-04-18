using MediatR;
using PWC_TestApp.Commands;
using PWC_TestApp.Repositories;
namespace PWC_TestApp.Handlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<int> Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var clientDetails = await _clientRepository.GetClientByIdAsync(command.ClientId);
            if (clientDetails == null)
                return default;

            clientDetails.ClientName = command.ClientName;
            clientDetails.ClientEmail = command.ClientEmail;
            clientDetails.JoinedDate = command.JoinedDate;

            return await _clientRepository.UpdateClientAsync(clientDetails);
        }
    }
}
