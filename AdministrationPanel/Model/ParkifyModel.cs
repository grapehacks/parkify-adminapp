using System;
using System.Collections.Generic;
using Model.DataTypes;
using RestSharp;

namespace Model
{
    public class ParkifyModel : IParkifyModel
    {
        private const string PathPing = "ping";
        private const string PathGetUsers = @"api/users";
        private const string PathGetCards = @"api/cards";
        private const string PathGetDraw = @"api/draw";
        private const string PathAuth = @"/authenticate";

        public event EventHandler OnAuthenticationSucceed;
		public event EventHandler OnAuthenticationFailed;

		string _myToken;

        ///////////////////////////////////////////////////////////////////////////

        public ParkifyModel(string serverAddress)
        {
            _mRestClient = new RestClient(serverAddress);
        }

        public void Authenticate(Credentials cred, Action<string> action)
		{
		    var request = new RestRequest(PathAuth, Method.POST)
		    {
		        RequestFormat = DataFormat.Json
		    };

		    request.AddJsonBody(cred);
			_mRestClient.ExecuteAsync<AuthResponse>(request, (response, callback) =>
			{
				Log(response.Content);
				var tokenResponse = response.Data;
				_myToken = tokenResponse.Token;
				action(tokenResponse.Message);

				if (!string.IsNullOrEmpty(tokenResponse.Token))
				{
					OnAuthenticationSucceed(this, EventArgs.Empty);
				}
				else
				{
					OnAuthenticationFailed(this, EventArgs.Empty);
				}
			});
		}

        public void SendPing(Action<Ping, string> action)
        {
			var request = new RestRequest(PathPing);
            _mRestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void GetUsers(Action<IEnumerable<User>, string> action)
		{
		    var request = new RestRequest(PathGetUsers, Method.GET)
		    {
		        RequestFormat = DataFormat.Json
		    };

		    request.AddHeader("x-access-token", _myToken);
			_mRestClient.ExecuteAsync<List<User>>(request, (response, callback) =>
			{
				Log(response.Content);
                action(response.Data, GetErrorString(response));
			});
		}
        public void GetUser(string userId, Action<User, string> action)
        {
            var request = new RestRequest(PathGetUsers+"/"+userId);
			request.AddHeader("x-access-token", _myToken);
            _mRestClient.ExecuteAsync<User>(request, response =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void AddUser(User user, Action<User, string> action)
        {
            var request = new RestRequest(PathGetUsers, Method.POST);
			request.AddHeader("x-access-token", _myToken);
            request.AddJsonBody(user);
            _mRestClient.ExecuteAsync<User>(request, response =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetCards(Action<List<Card>, string> action)
        {
            var request = new RestRequest(PathGetCards, Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Card>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action)
        {
            var request = new RestRequest(PathGetDraw, Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action, int count)
        {
            var request = new RestRequest(PathGetDraw + "?count=" + count, Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void RemoveUser(Action<string> action, string userId)
		{
			var request = new RestRequest(PathGetUsers + @"/" + userId, Method.DELETE);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = DataFormat.Json;
			_mRestClient.ExecuteAsync(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.ErrorMessage);
			});
		}


        ///////////////////////////////////////////////////////////////////////////

        private void Log(string log)
        {
            Console.WriteLine(GetType().Name + ":: " + log);
        }

        private string GetErrorString(IRestResponse restResponse)
        {
            if (restResponse.ErrorMessage != null)
            {
                return restResponse.ErrorMessage;
            }

            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return restResponse.StatusDescription;
            }

            return null;
        }

        ///////////////////////////////////////////////////////////////////////////

        private readonly RestClient _mRestClient;
    }
}
