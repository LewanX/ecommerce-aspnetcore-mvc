using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;
        public ProducersService(AppDbContext context)
        {
            _context = context;
        }


        public Task AddAsync(Producer producer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var ProducerId= await GetByIdAsync(id);
            _context.Remove(ProducerId);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Task<Producer> UpdateAsync(int id, Producer newProducer)
        {
            throw new NotImplementedException();
        }
    }
}
