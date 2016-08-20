using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTypes
{
	public class PingUser
	{
		public DateTime date { get; set; }

		public User user { get; set; }

        public override string ToString()
        {
			return date.ToString() + " " + (user != null ? user.name : "[NO USER]");
        }
	}
}
