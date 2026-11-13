using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class Payroll
    {
        private readonly List<IPayable> _people = new List<IPayable>();

        public int Count => _people.Count;

        public void Add(IPayable person)
        {
            _people.Add(person);
        }

        public List<IPayable> GetSortedByPay()
        {
            var copy = new List<IPayable>(_people);
            copy.Sort();
            return copy;
        }

        public decimal TotalNetPay()
        {
            return _people.Sum(p => p.NetPay());
        }

        public decimal TotalTax()
        {
            return _people.Sum(p => p.CalculateTax());
        }
    }
}
