namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Card
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Removed { get; set; }

        public bool Active { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return Name + ": " + Type.ToString() + " " + (User != null ? User.Name : "[NO USER]");
        }
    }
}
