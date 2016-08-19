namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
