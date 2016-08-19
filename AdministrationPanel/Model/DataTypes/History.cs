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
        public DateTime date { get; set; }
        public List<Draw> winners { get; set; }
        public List<User> users { get; set; }
        public List<String> specialCases { get; set; }
    }
}
