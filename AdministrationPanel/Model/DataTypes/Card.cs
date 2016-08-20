namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Card
    {
		public string _id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public bool removed { get; set; }

        public bool active { get; set; }

		public int __v { get; set; }

		public string user { get; set; }

        public override string ToString()
        {
            return name + ": " + type.ToString() + " " + user;
        }
    }
}
