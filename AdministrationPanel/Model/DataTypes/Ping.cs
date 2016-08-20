using System;

namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Ping
    {
        public DateTime date { get; set; }

        public override string ToString()
        {
            return date.ToString();
        }
    }
}
