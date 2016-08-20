using System;
using System.Collections.Generic;
using Model.DataTypes;
using RestSharp;

namespace Model
{
	public partial class ParkifyModel : IParkifyModel
	{
		private const string PathPing = "ping";
		private const string PathGetUsers = @"api/users";
		private const string PathGetCards = @"api/cards";
		private const string PathGetDraw = @"api/draw";
		private const string PathAuth = @"/authenticate";
		private const string PathDrawDate = @"/draw/draw-date";

		string _myToken;

		///////////////////////////////////////////////////////////////////////////

		public ParkifyModel()
		{
			_mRestClient = new RestClient("http://krk.grapeup.com:8080");
		}

		///////////////////////////////////////////////////////////////////////////

		public void Authenticate(Credentials cred, Action<Error> action)
		{
			var request = new RestRequest(PathAuth, Method.POST)
			{
				RequestFormat = DataFormat.Json
			};

			request.AddJsonBody(cred);
			_mRestClient.ExecuteAsync<AuthResponse>(request, (response, callback) =>
			{
				Log(response.Content);

				if (response.StatusCode != System.Net.HttpStatusCode.OK)
				{
					action(new Error(ServerError.AuthenticationFailed, GetErrorString(response)));
				}
				else
				{
					var tokenResponse = response.Data;
					if (tokenResponse.user.type == UserType.Admin)
					{
						_myToken = tokenResponse.token;

						if (!string.IsNullOrEmpty(tokenResponse.token))
						{
							action(null);
						}
						else
						{
							action(new Error(ServerError.AuthenticationFailed, GetErrorString(response)));
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

		public void PingForDate(Action<Ping, string> action)
		{
			var request = new RestRequest(PathPing);
			_mRestClient.ExecuteAsync<Ping>(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		///////////////////////////////////////////////////////////////////////////

		public void PingForUser(Action<PingUser, string> action)
		{
			var request = new RestRequest(PathPing);
			request.RequestFormat = RestSharp.DataFormat.Json;
			request.AddHeader("x-access-token", _myToken);
			_mRestClient.ExecuteAsync<PingUser>(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		///////////////////////////////////////////////////////////////////////////

		private void Log(string log)
		{
			Console.WriteLine(GetType().Name + ":: " + log);
		}

		///////////////////////////////////////////////////////////////////////////

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

		private readonly RestClient _mRestClient;
	}
}
