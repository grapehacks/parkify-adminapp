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

		public void Authenticate(Credentials cred, Action<Error> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_AUTH, Method.POST);
			request.RequestFormat = RestSharp.DataFormat.Json;
			request.AddJsonBody(cred);
			m_RestClient.ExecuteAsync<AuthResponse>(request, (response, callback) =>
			{
				LOG(response.Content);

				if (response.StatusCode != System.Net.HttpStatusCode.OK)
				{
					action(new Error(ServerError.AuthenticationFailed, response.ErrorMessage));
				}
				else
				{
					var tokenResponse = response.Data;
					if (tokenResponse.user.type == UserType.Admin)
					{
						myToken = tokenResponse.token;

						if (!string.IsNullOrEmpty(tokenResponse.token))
						{
							action(null);
							OnAuthenticationSucceed(this, EventArgs.Empty);
						}
						else
						{
							action(new Error(ServerError.AuthenticationFailed, ""));
							OnAuthenticationFailed(this, EventArgs.Empty);
						}
					}
					else
					{
						action(new Error(ServerError.UserIsNotAdmin, ""));
					}
				}
			});
		}

        ///////////////////////////////////////////////////////////////////////////

        public void SendPing(Action<Ping, string> action)
        {
			RestSharp.RestRequest request = new RestSharp.RestRequest(PATH_PING);
            m_RestClient.ExecuteAsync<Ping>(request, (response, callback) => {
                LOG(response.Content);
                action(response.Data, GetErrorString(response));
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
