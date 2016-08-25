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

        Task<string> RemoveUser(string userId);
		Task<Ping> GetDrawTime();

        Task<string> AddUser(User user);
        Task<string> EditUser(User user);
    }
}