

namespace Model.InternalModel
{
    public enum UserType
    {
        User,
        Admin
    }

    public enum UserParticipate
    {
        Yes,
        No, 
        Unknown
    }

    public struct User
    {
        public string email;
        public string password;
        public string Name { get; set; }
        public UserType type;
        public Card card; //? 
        public bool rememberLastChoice;
        public bool removed;
        public int unreadMsgCounter;
        public UserParticipate WillParticipate { get; set; }
    }   
}
