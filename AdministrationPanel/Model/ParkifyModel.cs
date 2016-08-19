using System;
using System.Collections.Generic;
using Model.DataTypes;
using RestSharp;

namespace Model
{
    public class ParkifyModel
    {
		static string _pathPing = "ping";
		static string _pathGetUsers = @"api/users";
        static string _pathGetCards = @"api/cards";
		static string _pathGetDraw = @"api/draw";
		static string _pathAuth = @"/authenticate";

		public event EventHandler OnAuthenticationSucceed;
		public event EventHandler OnAuthenticationFailed;

		string _myToken;

        ///////////////////////////////////////////////////////////////////////////

        public ParkifyModel(string serverAddress)
        {
            _mServerAddress = serverAddress;
            _mRestClient = new RestSharp.RestClient(_mServerAddress);
        }

		public void Authenticate(Credentials cred, Action<string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(_pathAuth, Method.POST);
			request.RequestFormat = RestSharp.DataFormat.Json;
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
			RestSharp.RestRequest request = new RestSharp.RestRequest(_pathPing);
            _mRestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void GetUsers(Action<IEnumerable<User>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetUsers, RestSharp.Method.GET);
			request.RequestFormat = RestSharp.DataFormat.Json;
			request.AddHeader("x-access-token", _myToken);
			_mRestClient.ExecuteAsync<List<User>>(request, (response, callback) =>
			{
				Log(response.Content);
                action(response.Data, GetErrorString(response));
			});
		}
        public void GetUser(string userId, Action<User, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetUsers+"/"+userId);
			request.AddHeader("x-access-token", _myToken);
            _mRestClient.ExecuteAsync<User>(request, response =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void AddUser(User user, Action<User, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetUsers, Method.POST);
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
            RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetCards, RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Card>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetDraw, RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action, int count)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetDraw + "?count=" + count.ToString(), RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            _mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void RemoveUser(Action<string> action, string userId)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(_pathGetUsers + @"/" + userId, RestSharp.Method.DELETE);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = RestSharp.DataFormat.Json;
			_mRestClient.ExecuteAsync(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.ErrorMessage);
			});
		}


        ///////////////////////////////////////////////////////////////////////////

        private void Log(string log)
        {
            Console.WriteLine(this.GetType().Name + ":: " + log);
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

        private string _mServerAddress;
        private RestSharp.RestClient _mRestClient;
    }
}
