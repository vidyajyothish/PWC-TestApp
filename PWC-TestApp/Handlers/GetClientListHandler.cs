using MediatR;
using PWC_TestApp.Models;
using PWC_TestApp.Queries;
using PWC_TestApp.Repositories;

namespace PWC_TestApp.Handlers
{
    public class GetClientListHandler : IRequestHandler<GetClientListQuery, List<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientListHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> Handle(GetClientListQuery query, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetClientListAsync();
        }
    }
}
