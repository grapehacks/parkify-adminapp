using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DataTypes;

namespace Model
{
    public interface IDataProvider
    {
        Task<Error> Authenticate(Credentials credential);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Card>> GetCards();
        Task<IEnumerable<Draw>> GetDraws();
        Task<bool> SetDrawDate(Ping date);
		Task<Ping> GetDrawTime();
    }
}