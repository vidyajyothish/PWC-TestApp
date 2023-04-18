using PWC_TestApp.Models;
using PWC_TestApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
namespace PWC_TestApp.Repositories
{
    public class ClientRepository:IClientRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddClientAsync(Client clientDetails)
        {
            var result = _dbContext.Clients.Add(clientDetails);
            await _dbContext.SaveChangesAsync();
            return await Task.Run(() => true);
        }

        public async Task<int> DeleteClientAsync(int Id)
        {
            var filteredData = _dbContext.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            if(filteredData != null)
            {
                _dbContext.Clients.Remove(filteredData);
            }            
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Client> GetClientByIdAsync(int Id)
        {
            return await _dbContext.Clients.Where(x => x.ClientId == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Client>> GetClientListAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<int> UpdateClientAsync(Client clientDetails)
        {
            _dbContext.Clients.Update(clientDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
