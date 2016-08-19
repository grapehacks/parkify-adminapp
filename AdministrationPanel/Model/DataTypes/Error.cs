using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTypes
{
	public enum ServerError
	{
		AuthenticationFailed,
		UserIsNotAdmin,
		ServerNotConnectable,
		WrongCredentials,
		BadRequest,
		InternalError
	}

	public class Error
	{
		public Error(ServerError reason, string message)
		{
			errorReason = reason;
			errorMessage = message;
		}

		public ServerError errorReason;
		public string errorMessage;
	}
}
