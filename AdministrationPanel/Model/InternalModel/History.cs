using System;
using System.Collections.Generic;

namespace Model.InternalModel
{
    public class History
    {
        public DateTime date;
        public IEnumerable<Draw> winners;
        public IEnumerable<User> users;
        public IEnumerable<String> specialCases;
    }
}
