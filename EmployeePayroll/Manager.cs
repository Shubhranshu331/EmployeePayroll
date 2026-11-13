using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public sealed class Manager : FullTimeEmployee
    {
        public int TeamSize { get; }
        public override string Role => "Manager";

        protected override decimal TaxRate => 0.20m;

        public Manager(string name, decimal monthlySalary, int teamSize) : base(name, monthlySalary)
        {
            if (teamSize < 0)
                throw new ArgumentException("Team size cannot be negative.");
            TeamSize = teamSize;
        }

        public override decimal CalculateBonus() => MonthlySalary * 0.10m + TeamSize * 500m;
    }
}
