using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;



        protected Machine(string name, double attackPoints, double defensePoints,double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();

        }
        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get;  set; }

        public string Name
        {
            get
            {
                return this.name;
            }

             set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name", "Name cannot be null");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Pilot cannot be null");
                }
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get{ return new List<string>(this.targets) ;}
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var targets = this.targets.Count > 0 ? string.Join(", ", this.targets) : "None";

            sb.AppendLine(string.Format($"-{this.Name}"));
            sb.AppendLine(string.Format($" *Type: {this.GetType().Name}"));
            sb.AppendLine(string.Format($" *Health: {this.HealthPoints}"));
            sb.AppendLine(string.Format($" *Attack: {this.AttackPoints}"));
            sb.AppendLine(string.Format($" *Defense: {this.DefensePoints}"));
            return sb.ToString();
        }
    }
}
