using MediatR;
using PWC_TestApp.Models;
using PWC_TestApp.Queries;
using PWC_TestApp.Repositories;

namespace PWC_TestApp.Handlers
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetClientByIdAsync(query.Id);
        }
    }
}
