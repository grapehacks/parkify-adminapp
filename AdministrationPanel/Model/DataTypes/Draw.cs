namespace Model.DataTypes
{
    public class Draw
    {
        User Winner { get; set; }

        Card Card { get; set; }

        public override string ToString()
        {
            return (Winner != null ? Winner.Name : "[NO USER]") + " " + (Card != null ? Card.Name : "[NO CARD]");
        }
    }
}
