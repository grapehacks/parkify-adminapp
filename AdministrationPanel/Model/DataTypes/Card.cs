namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Card
    {
        public string name { get; set; }

        public string type { get; set; }

        public bool removed { get; set; }

        public bool active { get; set; }

        public User user { get; set; }

        public override string ToString()
        {
            return name + ": " + type.ToString() + " " + (user != null ? user.name : "[NO USER]");
        }
    }
}
