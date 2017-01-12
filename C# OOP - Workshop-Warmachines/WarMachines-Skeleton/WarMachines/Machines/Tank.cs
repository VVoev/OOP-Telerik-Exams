using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank : Machine, ITank,IMachine
    {
        private const int TankHealth = 100;
        private const int TankAttack = 40;
        private const int TankDefence= 30;

        public Tank(string name, double attackPoints, double defensePoints)
                    : base(name, attackPoints, defensePoints,TankHealth)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
            {
                this.AttackPoints -= TankAttack;
                this.DefensePoints += TankDefence;
            }
            else
            {
                this.AttackPoints += TankAttack;
                this.DefensePoints -= TankDefence;
            }
          
        }
        public override string ToString()
        {
            var baseString = base.ToString();
            var sb = new StringBuilder();
            sb.Append(baseString);
            sb.AppendLine(string.Format("*Defense: {0}", this.DefenseMode ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
