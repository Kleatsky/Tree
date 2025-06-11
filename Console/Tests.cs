using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Tests
    {
        public static void Run()
        {
            Node root = new Node(new Employee("Emp1", 50));
            root.AddNode(new Employee("Emp2", 40));
            root.AddNode(new Employee("Emp3", 60));
            root.AddNode(new Employee("Emp4", 45));
            root.AddNode(new Employee("Emp5", 30));
            root.AddNode(new Employee("Emp6", 70));
            root.AddNode(new Employee("Emp7", 20));
            root.AddNode(new Employee("Emp8", 40));
            root.AddNode(new Employee("Emp9", 55));
            root.AddNode(new Employee("Emp10", 80));
            root.AddNode(new Employee("Emp11", 25));
            root.AddNode(new Employee("Emp12", 45));
            root.AddNode(new Employee("Emp13", 90));

            root.ShowOrdered();

            Console.WriteLine();

            root.FindPayment(80);
        }
    }
}
