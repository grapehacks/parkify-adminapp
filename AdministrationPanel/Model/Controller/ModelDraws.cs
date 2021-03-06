﻿using System;
using System.Collections.Generic;
using Model.DataTypes;
using RestSharp;

namespace Model
{
	public partial class ParkifyModel : IParkifyModel
	{
		public void GetDraws(Action<List<Draw>, string> action)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetDraw, RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = RestSharp.DataFormat.Json;
			_mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		public void GetDraws(Action<List<Draw>, string> action, int count)
		{
			RestSharp.RestRequest request = new RestSharp.RestRequest(PathGetDraw + "?count=" + count.ToString(), RestSharp.Method.GET);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = RestSharp.DataFormat.Json;
			_mRestClient.ExecuteAsync<List<Draw>>(request, (response, callback) =>
			{
				Log(response.Content);
				action(response.Data, GetErrorString(response));
			});
		}

		public void SetDrawDate(Action<string> action, Ping date)
		{
			var request = new RestRequest(PathDrawDate, Method.PUT);
			request.AddHeader("x-access-token", _myToken);
			request.RequestFormat = DataFormat.Json;
			request.AddJsonBody(date);
			_mRestClient.ExecuteAsync(request, (response, callback) =>
			{
				Log(response.Content);
				action(GetErrorString(response));
			});
		}
	}
}
