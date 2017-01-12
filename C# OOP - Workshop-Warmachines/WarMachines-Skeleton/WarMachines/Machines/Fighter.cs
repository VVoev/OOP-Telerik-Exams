using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter, IMachine
    {
        private const int FighterHealth = 200;


        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            :base(name,attackPoints,defensePoints,FighterHealth)
        {
            this.ToggleStealthMode();


        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }
        public override string ToString()
        {
            var baseString = base.ToString();
            var sb = new StringBuilder();
            sb.Append(baseString);
            sb.AppendLine(string.Format("*Defense: {0}", this.StealthMode ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
