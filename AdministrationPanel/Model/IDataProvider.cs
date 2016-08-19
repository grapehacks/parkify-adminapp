using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DataTypes;

namespace Model
{
    public interface IDataProvider
    {
        Task<bool> Authenticate(Credentials credential);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Card>> GetCards();
        Task<IEnumerable<Draw>> GetDraws();
    }
}