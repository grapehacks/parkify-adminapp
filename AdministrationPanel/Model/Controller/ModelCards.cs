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
		public void GetCards(Action<List<Card>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetCards, RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = RestSharp.DataFormat.Json;
			_mRestClient.ExecuteAsync<List<Card>>(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		public void GetCard(string cardId, Action<Card, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetCards + "/" + cardId);
			request.AddHeader("x-access-token", _myToken);
			_mRestClient.ExecuteAsync<Card>(request, response =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		public void AddCard(Card card, Action<Card, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetCards, Method.POST);
			request.AddHeader("x-access-token", _myToken);
			request.AddJsonBody(card);
			_mRestClient.ExecuteAsync<Card>(request, response =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		public void RemoveCard(Action<string> action, string cardId)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetCards + @"/" + cardId, RestSharp.Method.DELETE);
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
