using MediatR;
using PWC_TestApp.Commands;
using PWC_TestApp.Repositories;

namespace PWC_TestApp.Handlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            var clientDetails = await _clientRepository.GetClientByIdAsync(command.ClientId);
            if (clientDetails == null)
                return default;

            return await _clientRepository.DeleteClientAsync(clientDetails.ClientId);
        }
    }
}
