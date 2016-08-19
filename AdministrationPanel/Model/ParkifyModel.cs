using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace AdministrationPanel.Model
{
    public class ParkifyModel
    {
        public static string PING_PATH = "ping";
		public static string PATH_GET_USERS = @"api/users";
        public static string PATH_GET_CARDS = @"api/cards";
        public static string PATH_GET_DRAW = @"api/draw";

		public List<User> UserList;

        ///////////////////////////////////////////////////////////////////////////

        public ParkifyModel(string serverAddress)
        {
            m_ServerAddress = serverAddress;
            m_RestClient = new RestSharp.RestClient(m_ServerAddress);
        }

        public void SendPing(Action<Ping, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PING_PATH);
            m_RestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                LOG(response.Content);
                action(response.Data, response.ErrorMessage);
            });
        }

		public void GetUsers(Action<IEnumerable<User>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS, RestSharp.Method.GET);
			request.RequestFormat = RestSharp.DataFormat.Json;
			m_RestClient.ExecuteAsync<List<User>>(request, (response, callback) =>
			{
				LOG(response.Content);
				action(response.Data, response.ErrorMessage);
			});
		}

        public void AddUser(User user, Action<User, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_USERS, Method.POST);
            request.AddJsonBody(user);
            m_RestClient.ExecuteAsync<User>(request, response =>
            {
                LOG(response.Content);
                action(response.Data, response.ErrorMessage);
            });
        }

        public void GetCards(Action<List<Card>, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_CARDS, RestSharp.Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Card>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, response.ErrorMessage);
            });
        }

        public void GetDraws(Action<List<Draw>, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_DRAW, RestSharp.Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, response.ErrorMessage);
            });
        }

        public void GetDraws(Action<List<Draw>, string> action, int count)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_DRAW + "?count=" + count.ToString(), RestSharp.Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;
            m_RestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
            {
                LOG(response.Content);
                action(response.Data, response.ErrorMessage);
            });
        }


        ///////////////////////////////////////////////////////////////////////////

        private void LOG(string log)
        {
            Console.WriteLine(this.GetType().Name + ":: " + log);
        }

        ///////////////////////////////////////////////////////////////////////////

        private string m_ServerAddress;
        private RestSharp.RestClient m_RestClient;
    }
}
