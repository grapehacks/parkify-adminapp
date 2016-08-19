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
        public string email;
        public string password;
        public string name;
        public UserType type;
        public Card card; //? 
        public bool rememberLastChoice;
        public bool removed;
        public int unreadMsgCounter;
    }   
}
