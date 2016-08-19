using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationPanel.Model;

namespace AdministrationPanel.Model
{
    public class Card
    {
        public string name;
        public string type;
        public bool removed;
        public bool active;
        public User user;
    }
}
