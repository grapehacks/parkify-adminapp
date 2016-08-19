using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationPanel.Model;

namespace AdministrationPanel.Model
{
    public enum UserType
    {
        User,
        Admin
    }

    public enum UserParticipate
    {
        Yes,
        No
    }

    public class User
    {
		public string _id { get; set; }
		public string email { get; set; }
		public string name { get; set; }
		public string password { get; set; }
		public bool removed { get; set; }
		public int unreadMsgCounter { get; set; }
		public int __v { get; set; }
		public bool rememberLastChoice { get; set; }
		public bool participate { get; set; }
		public int type { get; set; } 
    }   
}
