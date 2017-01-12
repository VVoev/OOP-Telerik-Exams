using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null");
                }
                this.name = value;
            }
        }
        public void AddMachine(IMachine machine)
        {
            if (this.machines == null)
            {
                throw new ArgumentNullException("Machine", "Machine cannot be null");
            }
            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var sortedMachines = this.machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);

            var noMachineMaybe =
                this.machines.Count > 0 ?
                this.machines.Count.ToString()
                : "no";
            var machineOrMashines =
                this.machines.Count == 1 ?
                "machine" :
                "machines";



            sb.AppendFormat(string.Format($"{this.Name} – {noMachineMaybe} {machineOrMashines}"));

            foreach (var machine in sortedMachines)
            {
                sb.AppendLine(machine.ToString());
                //-(machine name)
                //*Type: (“Tank”/”Fighter”)
                //*Health: (machine health points)
                //*Attack: (machine attack points)
                //*Defense: (machine defense points)
                //*Targets: (machine target names/”None” – comma separated)
                //*Defense: (“ON”/”OFF” – when applicable)

            }


            return sb.ToString();
        }

    }
}
