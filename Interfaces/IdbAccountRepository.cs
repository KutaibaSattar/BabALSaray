using System.Collections.Generic;
using System.Threading.Tasks;
using AppEntities;

namespace BabALSaray.Interfaces
{
    public interface IdbAccountRepository
    {
        void Update(dbAccounts dbAccounts);

        Task<bool> SaveAllAsync();
        Task<IEnumerable<dbAccounts>> GetDbAccountsAsync();

        Task<dbAccounts> GetDbAccountByIdAsync(int id);
        
        
    }

}