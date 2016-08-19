using System;
using System.Collections.Generic;

namespace Model.DataTypes
{
    public class History
    {
        public DateTime Date { get; set; }
        public List<Draw> Winners { get; set; }
        public List<User> Users { get; set; }
        public List<String> SpecialCases { get; set; }
    }
}
