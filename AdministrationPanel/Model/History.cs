using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class History
    {
        public DateTime Date;
        public Array<Draw> Winners;
        public IEnumerable<User> Users;
        public IEnumerable<String> SpecialCases;
    }
}
