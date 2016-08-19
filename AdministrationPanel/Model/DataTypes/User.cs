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
		public string Id { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public bool Removed { get; set; }

		public int UnreadMsgCounter { get; set; }

		public int V { get; set; }
		
        public bool RememberLastChoice { get; set; }

		public UserParticipate Participate { get; set; }

		public UserType Type { get; set; }

        public override string ToString()
        {
            return Id + ": " + Email + " - " + Name;
        }
    }   
}
