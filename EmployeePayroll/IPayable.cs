using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public interface IPayable : IComparable<IPayable>
    {
        string Name { get; }
        string Role { get; }

        decimal CalculateMonthlyPay();
        decimal CalculateBonus();
        decimal CalculateTax();

        decimal NetPay() => CalculateMonthlyPay() + CalculateBonus() - CalculateTax();
    }
}
