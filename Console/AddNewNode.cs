using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class AddNewNode
    {
        public static Node? AddNodeFromConsole()
        {
            Console.WriteLine("Enter employee's name or press enter to stop input employee:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) return null;

            Console.WriteLine("Enter employee's payment:");
            string payment = Console.ReadLine();

            if(!int.TryParse(payment, out int paymentInt))
            {
                throw new Exception("Invalid payment input!");
            }


            return new Node(new Employee(name, paymentInt));
        }
    }
}
