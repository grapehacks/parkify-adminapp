using System;
using System.Collections.Generic;

namespace Model.InternalModel
{
    public class History
    {
        public DateTime date { get; set; }
        public List<Draw> winners { get; set; }
        public List<User> users { get; set; }
        public List<String> specialCases { get; set; }
    }
}
