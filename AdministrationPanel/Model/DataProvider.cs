using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DataTypes;

namespace Model
{
    public class DataProvider : IDataProvider
    {
        private readonly IParkifyModel _model;
        private TaskCompletionSource<bool> _authenticationCompletionSource;

        public DataProvider(IParkifyModel model)
        {
            _model = model;
        }

        public Task<bool> Authenticate()
        {
            _authenticationCompletionSource = new TaskCompletionSource<bool>();

            _model.OnAuthenticationSucceed += OnSucceeded;
            _model.OnAuthenticationFailed += OnFailed;

            return _authenticationCompletionSource.Task;
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

        private void OnFailed(object sender, EventArgs eventArgs)
        {
            _authenticationCompletionSource.SetResult(false);
            _model.OnAuthenticationSucceed -= OnSucceeded;
            _model.OnAuthenticationFailed -= OnFailed;
        }

        private void OnSucceeded(object sender, EventArgs eventArgs)
        {
            _authenticationCompletionSource.SetResult(true);
            _model.OnAuthenticationSucceed -= OnSucceeded;
            _model.OnAuthenticationFailed -= OnFailed;
        }
    }
}