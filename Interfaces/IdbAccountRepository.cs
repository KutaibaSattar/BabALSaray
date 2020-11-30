using System.Collections.Generic;
using System.Threading.Tasks;
using AppEntities;

namespace BabALSaray.Interfaces
{
    public interface IdbAccountRepository
    {

        Task<IEnumerable<dbAccounts>> GetDbAccounts();

        
        
    }

}