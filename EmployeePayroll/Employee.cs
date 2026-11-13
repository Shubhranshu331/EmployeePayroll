using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public abstract class Employee : IPayable
    {
        public string Name { get; }
        public abstract string Role { get; }
        protected abstract decimal TaxRate { get; }

        protected Employee(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            Name = name.Trim();
        }

        public abstract decimal CalculateMonthlyPay();

        public virtual decimal CalculateBonus();

        public decimal CalculateTax()
        {
            return Math.Round((CalculateMonthlyPay() + CalculateBonus()) * TaxRate, 2);
        }

        public int CompareTo(IPayable? other)
        {
            if (other == null) return -1;
            return other.NetPay().CompareTo(((IPayable)this).NetPay());
        }
    }
}
