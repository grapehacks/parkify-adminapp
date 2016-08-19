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
		public string _id;
        public string email;
		public string name;
        public string password;
		public bool removed;
		public int unreadMsgCounter;
		public int __v;
		public bool rememberLastChoice;
		public bool participate;
        public int type;
    }   
}
