using PWC_TestApp.Models;
using MediatR;
namespace PWC_TestApp.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id { get; set; }
    }
}
