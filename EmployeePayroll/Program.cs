namespace EmployeePayroll
{
    internal class Program
    {
        private static readonly Payroll payroll = new Payroll();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                string? choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddFullTime(); break;
                        case "2": AddPartTime(); break;
                        case "3": AddManager(); break;
                        case "4": AddContractor(); break;
                        case "5": ShowReport(); break;
                        case "6": LoadSamples(); break;
                        case "0": running = false; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.WriteLine("Goodbye!");
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== EMPLOYEE PAYROLL ===");
            Console.WriteLine("1. Add full-time     4. Add contractor");
            Console.WriteLine("2. Add part-time     5. Payroll report");
            Console.WriteLine("3. Add manager       6. Load samples");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Choose: ");
        }

        static string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        static void AddFullTime()
        {
            string name = ReadText("Name; ");
            decimal salary = ReadDecimal("MOnthly salary: ");
            payroll.Add(new FullTimeEmployee(name, salary));
            Console.WriteLine($"Added.");
        }

        static void AddPartTime()
        {
            string name = ReadText("Name: ");
            decimal rate = ReadDecimal("Hourly rate: ");
            int hours = ReadInt("Hours worked: ");
            payroll.Add(new PartTimeEmployee(name, rate, hours));
            Console.WriteLine("Added: ");
        }

        static void AddManager()
        {
            string name = ReadText("Name: ");
            decimal salary = ReadDecimal("Monthly salary: ");
            int team = ReadInt("Team size: ");
            payroll.Add(new Manager(name, salary, team));
            Console.WriteLine("Added. ");
        }

        static void AddContractor()
        {
            string name = ReadText("Name: ");
            decimal rate = ReadDecimal("Daily rate: ");
            int days = ReadInt("Team size: ");
            payroll.Add(new Contractor(name, rate, days));
            Console.WriteLine("Added. ");
        }

        static void LoadSamples()
        {
            payroll.Add(new FullTimeEmployee("Asha", 50000m));
            payroll.Add(new PartTimeEmployee("Ravi", 400m, 80));
            payroll.Add(new Manager("meera", 80000m, 5));
            payroll.Add(new Contractor("Kiran", 3000m, 15));
            Console.WriteLine("4 samples added.");
        }

        static void ShowReport()
        {
            if ( payroll.Count == 0)
            {
                Console.WriteLine("No staff yet.");
                return;
            }

            Console.WriteLine($"{"Name",-10}{"Role",-12}{"Pay",12}{"Bonus",12}{"Tax",12}{"Net",12}");
            Console.WriteLine(new string('-', 70));

            foreach (IPayable p in payroll.GetSortedByPay())
            {
                Console.WriteLine(
                    $"{p.Name,-10}{p.Role,-12}{p.CalculateMonthlyPay(),12:N2}" +
                    $"{p.CalculateBonus(),12:N2}{p.CalculateTax(),12:N2}{p.NetPay(),12:N2}");
            }
            Console.WriteLine(new string ('-', 70));
            Console.WriteLine($"Total tax: {payroll.TotalTax():N2}");
            Console.WriteLine($"Total net payout: {payroll.TotalNetPay():N2}");
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Please enter a number.");
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Please enter a whole number.");
            }
        }
    }
}