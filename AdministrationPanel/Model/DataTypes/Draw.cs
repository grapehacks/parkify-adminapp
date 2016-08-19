using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationPanel.Model;

namespace AdministrationPanel.Model
{
    public class Draw
    {
        User winner { get; set; }

        Card card { get; set; }

        public override string ToString()
        {
            return (winner != null ? winner.name : "[NO USER]") + " " + (card != null ? card.name : "[NO CARD]");
        }
    }
}
