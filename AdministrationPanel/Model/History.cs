using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class History
    {
        public DateTime date;
        public Array<Draw> winners;
        public IEnumerable<User> users;
        public IEnumerable<String> specialCases;
    }
}
