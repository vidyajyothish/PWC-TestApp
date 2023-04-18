using PWC_TestApp.Models;
using MediatR;
namespace PWC_TestApp.Commands
{
    public class DeleteClientCommand : IRequest<int>
    {
        public int ClientId { get; set; }
    }
}
