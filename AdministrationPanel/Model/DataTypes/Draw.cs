namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Draw
    {
        public User winner { get; set; }

        public Card card { get; set; }

        public string Date { get; set; }

        public override string ToString()
        {
            return (winner != null ? winner.name : "[NO USER]") + " " + (card != null ? card.name : "[NO CARD]");
        }
    }
}
