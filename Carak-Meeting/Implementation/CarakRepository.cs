using Carak_Meeting.Data;
using Carak_Meeting.Interfaces;
using Carak_Meeting.Models;
using Microsoft.EntityFrameworkCore;

namespace Carak_Meeting.Implementation
{
    public class CarakRepository : ICarak
    {
        private readonly ApplicationDbContext _context;

        public CarakRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async void Add(UserCarak carak)
        {
            _context.Set<UserCarak>().Add(carak);
        }

        public async Task<UserCarak> DeleteCarakById(int carakId)
        {
            return await _context.userCaraks.FirstOrDefaultAsync(carak => carak.id == carakId);
        }

        public Task<bool> DeleteCarakById(string carakId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserCarak>> GetAllCarak()
        {
            return await _context.Set<UserCarak>().ToListAsync();

        }

        public async Task<UserCarak> GetCarakById(int carakId)
        {
            return await _context.userCaraks.FirstOrDefaultAsync(carak => carak.id == carakId);
        }

        public void Remove(UserCarak carak)
        {
            _context.Remove(carak);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
