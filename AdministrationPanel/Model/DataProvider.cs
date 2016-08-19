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

        public Task<bool> Authenticate(Credentials credential)
        {
            var tcs = new TaskCompletionSource<bool>();

            _model.Authenticate(credential, s =>
            {
                tcs.SetResult(s == null);
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
    }
}