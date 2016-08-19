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
        public string name { get; set; }

        public string type { get; set; }

        public bool removed { get; set; }

        public bool active { get; set; }

        public User user { get; set; }

        public override string ToString()
        {
            return name + ": " + type.ToString() + " " + (user != null ? user.name : "[NO USER]");
        }
    }
}
