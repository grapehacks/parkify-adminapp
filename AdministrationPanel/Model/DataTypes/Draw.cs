namespace Model.DataTypes
{
    public class Draw
    {
        User winner { get; set; }

        Card card { get; set; }

        public override string ToString()
        {
            return (winner != null ? winner.name : "[NO USER]") + " " + (card != null ? card.name : "[NO CARD]");
        }
    }
}
