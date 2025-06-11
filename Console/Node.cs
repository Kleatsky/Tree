using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp
{
    internal class Node
    {
        public Node? LeftNode { get; set; } = null;
        public Node? RightNode { get; set; } = null;
        public Employee Employee { get; set; }

        public Node(Employee employee)
        {
            Employee = employee;
        }

        public void AddNode(Employee newEmployee)
        {
            if (Employee.Payment < newEmployee.Payment)
            {
                if (RightNode == null)
                {
                    RightNode = new Node(newEmployee);
                }
                else
                {
                    RightNode.AddNode(newEmployee);
                }
            }
            else
            {
                if (LeftNode == null)
                {
                    LeftNode = new Node(newEmployee);
                }
                else
                {
                    LeftNode.AddNode(newEmployee);
                }
            }
        }

        public void AddNode(Node newNode)
        {
            if (Employee.Payment < newNode.Employee.Payment)
            {
                if (RightNode == null)
                {
                    RightNode = newNode;
                }
                else
                {
                    RightNode.AddNode(newNode);
                }
            }
            else
            {
                if (LeftNode == null)
                {
                    LeftNode = newNode;
                }
                else
                {
                    LeftNode.AddNode(newNode);
                }
            }
        }

        public static void PrintTree(Node node, string indent = "", bool isLast = true)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (isLast)
                {
                    Console.Write("└──");
                    indent += "   ";
                }
                else
                {
                    Console.Write("├──");
                    indent += "│  ";
                }

                Console.WriteLine($"{node.Employee.Payment} ({node.Employee.Name})");

                PrintTree(node.LeftNode, indent, false);
                PrintTree(node.RightNode, indent, true);
            }
        }
        public void ShowOrdered()
        {
            if (LeftNode != null)
            {
                LeftNode.ShowOrdered();
            }

            Console.WriteLine($"{Employee.Name} - {Employee.Payment}");

            if (RightNode != null)
            {
                RightNode.ShowOrdered();
            }
        }

        public void FindPayment(int payment)
        {
            bool isFinded = FindPaymentBinary(payment);

            if(!isFinded)
            {
                Console.WriteLine("такой сотрудник не найден");
            }
        }
        private bool FindPaymentBinary(int payment)
        {
            if (payment == Employee.Payment)
            {
                Console.WriteLine($"Name: {Employee.Name}");
                return true;
            }

            if (payment < Employee.Payment && LeftNode != null)
            {
                return LeftNode.FindPaymentBinary(payment);
            }
            else if (payment > Employee.Payment && RightNode != null)
            {
                return RightNode.FindPaymentBinary(payment);
            }

            return false;
        }
    }
}
