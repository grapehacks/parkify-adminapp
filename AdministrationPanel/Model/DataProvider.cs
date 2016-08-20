using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DataTypes;

namespace Model
{
    public class DataProvider : IDataProvider
    {
        private readonly IParkifyModel _model;

        public DataProvider(IParkifyModel model)
        {
            _model = model;
        }

        public Task<Error> Authenticate(Credentials credential)
        {
            var tcs = new TaskCompletionSource<Error>();

            _model.Authenticate(credential, error =>
            {
                tcs.SetResult(error);
            });

            return tcs.Task;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            var tcs = new TaskCompletionSource<IEnumerable<User>>();

            _model.GetUsers((users, s) => { tcs.SetResult(users); });

            return tcs.Task;
        }

        public Task<IEnumerable<Card>> GetCards()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Card>>();

            _model.GetCards((cards, s) => { tcs.SetResult(cards); });

            return tcs.Task;
        }

        public Task<IEnumerable<Draw>> GetDraws()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Draw>>();

            _model.GetDraws((draws, s) => { tcs.SetResult(draws); });

            return tcs.Task;
        }

        public Task<bool> SetDrawDate(Ping date)
        {
            var tcs = new TaskCompletionSource<bool>();

            _model.SetDrawDate((s) => { 
                tcs.SetResult(s == null); 
            }, date);

            return tcs.Task;
        }

        public Task<string> RemoveUser(string userId)
        {
            var tcs = new TaskCompletionSource<string>();

            _model.RemoveUser(s => { tcs.SetResult(s); }, userId);

            return tcs.Task;
        }
    }
}