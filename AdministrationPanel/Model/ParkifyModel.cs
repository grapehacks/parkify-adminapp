using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataTypes;
using RestSharp;

namespace Model
{
    public class ParkifyModel
    {
		static string PATH_PING = "ping";
		static string PATH_GET_USERS = @"api/users";
        static string PATH_GET_CARDS = @"api/cards";
		static string PATH_GET_DRAW = @"api/draw";
		static string PATH_AUTH = @"/authenticate";

		public event EventHandler OnAuthenticationSucceed;
		public event EventHandler OnAuthenticationFailed;

		string myToken;

        ///////////////////////////////////////////////////////////////////////////

        public ParkifyModel(string serverAddress)
        {
            m_ServerAddress = serverAddress;
            m_RestClient = new RestSharp.RestClient(m_ServerAddress);
        }

		public void Authenticate(Credentials cred, Action<string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_AUTH, Method.POST);
			request.RequestFormat = RestSharp.DataFormat.Json;
			request.AddJsonBody(cred);
			m_RestClient.ExecuteAsync<AuthResponse>(request, (response, callback) =>
			{
				LOG(response.Content);
				var tokenResponse = response.Data;
				myToken = tokenResponse.token;
				action(tokenResponse.message);

				if (!string.IsNullOrEmpty(tokenResponse.token))
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
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_PING);
            m_RestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void GetUsers(Action<IEnumerable<User>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS, RestSharp.Method.GET);
			request.RequestFormat = RestSharp.DataFormat.Json;
			request.AddHeader("x-access-token", myToken);
			m_RestClient.ExecuteAsync<List<User>>(request, (response, callback) =>
			{
				LOG(response.Content);
                action(response.Data, GetErrorString(response));
			});
		}
        public void GetUser(string userId, Action<User, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS+"/"+userId);
			request.AddHeader("x-access-token", myToken);
            m_RestClient.ExecuteAsync<User>(request, response =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void AddUser(User user, Action<User, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS, Method.POST);
			request.AddHeader("x-access-token", myToken);
            request.AddJsonBody(user);
            m_RestClient.ExecuteAsync<User>(request, response =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetCards(Action<List<Card>, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_CARDS, RestSharp.Method.GET);
			request.AddHeader("x-access-token", myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Card>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_DRAW, RestSharp.Method.GET);
			request.AddHeader("x-access-token", myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void GetDraws(Action<List<Draw>, string> action, int count)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_DRAW + "?count=" + count.ToString(), RestSharp.Method.GET);
			request.AddHeader("x-access-token", myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

		public void RemoveUser(Action<string> action, string userId)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS + @"/" + userId, RestSharp.Method.DELETE);
			request.AddHeader("x-access-token", myToken);
			request.RequestFormat = RestSharp.DataFormat.Json;
			m_RestClient.ExecuteAsync(request, (response, callback) =>
			{
				LOG(response.Content);
				action(response.ErrorMessage);
			});
		}


        ///////////////////////////////////////////////////////////////////////////

        private void LOG(string log)
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

        private string m_ServerAddress;
        private RestSharp.RestClient m_RestClient;
    }
}
