using System;

namespace Model.DataTypes
{
    public class Ping
    {
        public DateTime date { get; set; }

        public override string ToString()
        {
            return date.ToString();
        }
    }
}
