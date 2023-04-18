using PWC_TestApp.Models;
using MediatR;
namespace PWC_TestApp.Commands
{
    public class UpdateClientCommand : IRequest<int>
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime JoinedDate { get; set; }
        public UpdateClientCommand(int id, string clientName, string clientEmail, DateTime joinedDate)
        {
            ClientId = id;
            ClientName = clientName;
            ClientEmail = clientEmail;
            JoinedDate = joinedDate;
        }
    }
}
