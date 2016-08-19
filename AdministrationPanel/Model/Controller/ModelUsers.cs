using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataTypes;
using RestSharp;

namespace Model
{
    public partial class ParkifyModel
    {
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
            m_RestClient.ExecuteAsync<User>(request, (response, callback) =>
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
            m_RestClient.ExecuteAsync<User>(request, (response, callback) =>
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
    }
}
