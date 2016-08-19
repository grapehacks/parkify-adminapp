using System;
using Model.InternalModel;

namespace Model
{
    public class ParkifyModel
    {
        public static string PING_PATH = "ping";
        

        public ParkifyModel(string serverAddress)
        {
            m_ServerAddress = serverAddress;
            m_RestClient = new RestSharp.RestClient(m_ServerAddress);
        }

        public void SendPing(Action<string> action)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(PING_PATH);
            m_RestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                LOG(response.Content);
                action(response.Content);
            });
        }


        private void LOG(string log)
        {
            Console.WriteLine(this.GetType().Name + ":: " + log);
        }

        private string m_ServerAddress;
        private RestSharp.RestClient m_RestClient;
    }
}
