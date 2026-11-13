using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; }

        public int HoursWorked { get; }

        public override string Role => "Part-time";

        protected override decimal TaxRate => 0.05m;

        public PartTimeEmployee(string name, decimal hourlyRate, int hoursWorked) : base(name)
        {
            if (hourlyRate <= 0)
                throw new ArgumentException("Hourly rate must be greater than zero.");
            if (hoursWorked < 0)
                throw new ArgumentException("Hours cannot be negative.");

            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateMonthlyPay() => HourlyRate * HoursWorked;
    }
}
