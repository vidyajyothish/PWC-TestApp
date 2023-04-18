using PWC_TestApp.Models;
using MediatR;
namespace PWC_TestApp.Commands
{
    public class CreateClientCommand:IRequest<bool>
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime JoinedDate { get; set; }

        public CreateClientCommand(string clientName, string clientEmail, DateTime joinedDate)
        {
            ClientName = clientName;
            ClientEmail = clientEmail;
            JoinedDate = joinedDate;
        }
    }
}
