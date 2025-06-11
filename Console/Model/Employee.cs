using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    internal class Employee
    {
        private int payment;

        public string Name { get; set; }
        public int Payment
        {
            get => payment;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Payment can't be below or equal 0");
                payment = value;
            }
        }
        public Employee(string name, int payment)
        {
            if (payment <= 0) throw new ArgumentException("Payment can't be below or equal 0");
            Name = name;
            Payment = payment;
        }
    }
}
