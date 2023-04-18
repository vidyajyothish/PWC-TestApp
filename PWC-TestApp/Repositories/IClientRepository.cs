using PWC_TestApp.Models;

namespace PWC_TestApp.Repositories
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClientListAsync();
        public Task<Client> GetClientByIdAsync(int Id);
        public Task<bool> AddClientAsync(Client clientDetails);
        public Task<int> UpdateClientAsync(Client clientDetails);
        public Task<int> DeleteClientAsync(int Id);
    }
}
