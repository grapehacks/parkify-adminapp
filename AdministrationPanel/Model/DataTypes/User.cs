namespace Model.DataTypes
{
    public enum UserType
    {
        User,
        Admin
    }

    public enum UserParticipate
    {
        No,
		Yes,
		NotDefined
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

		public UserParticipate participate { get; set; }

		public UserType type { get; set; }

        public override string ToString()
        {
            return _id + ": " + email + " - " + name;
        }
    }   
}
