using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class Contractor : IPayable
    {
        public string Name { get; }
        public string Role => "Contractor";
        public decimal DailyRate { get; }
        public int DaysWorked { get; }

        public Contractor(string name, decimal dailyRate, int daysWorked)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is required.");
            if (dailyRate <= 0)
                throw new ArgumentException("Daily rate must be greater than zero.");
            if (daysWorked < 0)
                throw new ArgumentException("Days cannot BE negative.");
            Name = name.Trim();
            DailyRate = dailyRate;
            DaysWorked = dailyWorked;
        }

        public decimal CalculateMonthlyPay() => DailyRate * DaysWorked;

        public decimal CalculateBonus() => 0m;

        public decimal CalculateTax() => 0m;

        public int CompareTo(IPayable? other)
        {
            if (other == null) return -1;
            return other.NetPay().CompareTo(((Ipayable)this).NetPay());
        }
    }
}
