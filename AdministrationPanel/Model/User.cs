using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
        public string Email;
        public string Password;
        public string Name;
        public UserType Type;
        public Card CardValue; //? 
        public bool RememberLastChoice;
        public bool Removed;
        public int UnreadMsgCounter;
    }   
}
