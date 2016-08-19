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

        public void GetCard(string cardId, Action<Card, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_CARDS + "/" + cardId);
            request.AddHeader("x-access-token", myToken);
            m_RestClient.ExecuteAsync<Card>(request, response =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void AddCard(Card card, Action<Card, string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_CARDS, Method.POST);
            request.AddHeader("x-access-token", myToken);
            request.AddJsonBody(card);
            m_RestClient.ExecuteAsync<Card>(request, response =>
            {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
            });
        }

        public void RemoveCard(Action<string> action, string cardId)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_GET_CARDS + @"/" + cardId, RestSharp.Method.DELETE);
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
