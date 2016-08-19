using System;
using System.Collections.Generic;
using Model.DataTypes;

namespace Model
{
    public interface IParkifyModel
    {
        event EventHandler OnAuthenticationSucceed;
        event EventHandler OnAuthenticationFailed;
        void Authenticate(Credentials cred, Action<string> action);
        void SendPing(Action<Ping, string> action);
        void GetUsers(Action<IEnumerable<User>, string> action);
        void GetUser(string userId, Action<User, string> action);
        void AddUser(User user, Action<User, string> action);
        void GetCards(Action<List<Card>, string> action);
        void GetDraws(Action<List<Draw>, string> action);
        void GetDraws(Action<List<Draw>, string> action, int count);
        void RemoveUser(Action<string> action, string userId);
    }
}