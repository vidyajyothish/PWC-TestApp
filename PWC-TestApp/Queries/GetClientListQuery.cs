using PWC_TestApp.Models;
using MediatR;
namespace PWC_TestApp.Queries
{
    public class GetClientListQuery:IRequest<List<Client>>
    {
    }
}
