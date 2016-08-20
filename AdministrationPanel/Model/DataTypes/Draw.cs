using System.Collections.Generic;

namespace Model.DataTypes
{
    public class Winner
    {
        public string user { get; set; }

        public string card { get; set; }

        public string _id { get; set; }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class Draw
    {
        public string _id { get; set; }

        public int __v { get; set; }

        public List<int> specialCases { get; set; }

        public List<string> users { get; set; }

        public List<Winner> winner { get; set; }

        public string Date { get; set; }

        //public override string ToString()
        //{
        //    return (winner != null ? winner.user : "[NO USER]") + " " + (card != null ? card.name : "[NO CARD]");
        //}
    }
}
