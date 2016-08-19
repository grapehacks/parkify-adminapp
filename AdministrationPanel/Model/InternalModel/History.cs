using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationPanel.Model;

namespace AdministrationPanel.Model
{
    public class History
    {
        public DateTime date;
        public IEnumerable<Draw> winners;
        public IEnumerable<User> users;
        public IEnumerable<String> specialCases;
    }
}
