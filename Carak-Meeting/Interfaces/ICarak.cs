using Carak_Meeting.Models;

namespace Carak_Meeting.Interfaces
{
    public interface ICarak
    {

        Task<IEnumerable<UserCarak>> GetAllCarak();
        
        Task<UserCarak> GetCarakById(int carakId);

        Task<bool> DeleteCarakById(string carakId);

        void Add(UserCarak carak);

        void Remove(UserCarak carak);

        Task<bool> SaveChanges();
        Task<bool> SaveAll();
    }
}
