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
    }
}
