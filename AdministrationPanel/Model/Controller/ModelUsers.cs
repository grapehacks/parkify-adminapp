using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataTypes;
using RestSharp;

namespace Model
{
	public partial class ParkifyModel : IParkifyModel
    {
       	public void GetUsers(Action<IEnumerable<User>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetUsers, RestSharp.Method.GET);
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
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetUsers + "/" + userId);
			request.AddHeader("x-access-token", _myToken);
			_mRestClient.ExecuteAsync<User>(request, (response, callback) =>
            {
				Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void AddUser(User user, Action<User, string> action)
        {
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetUsers, Method.POST);
			request.AddHeader("x-access-token", _myToken);
            request.AddJsonBody(user);
			_mRestClient.ExecuteAsync<User>(request, (response, callback) =>
            {
				Log(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }
        
        public void RemoveUser(Action<string> action, string userId)
        {
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetUsers + @"/" + userId, RestSharp.Method.DELETE);
			request.AddHeader("x-access-token", _myToken);
            request.RequestFormat = RestSharp.DataFormat.Json;
			_mRestClient.ExecuteAsync(request, (response, callback) =>
            {
                Log(response.Content);
                action(response.ErrorMessage);
            });
        }
    }
}
