using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary { get; }

        public override string Role => "Full-time";

        protected override decimal TaxRate => 0.10m;

        public FullTimeEmployee(string name, decimal monthlySalary) : base(name)
        {
            if (monthlySalary <= 0)
                throw new ArgumentException("Salary must be greater than zero.");
            MonthlySalary = monthlySalary;
        }

        public override decimal CalculateMonthlyPay() => MonthlySalary;

        public override decimal CalculateBonus() => MonthlySalary * 0.05m;
    }
}
