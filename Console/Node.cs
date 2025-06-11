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

            if (!isFinded)
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

        public void PrintTree()
        {
            if (this == null)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }
            if (LeftNode != null || RightNode != null)
            {
                Console.Write($"{Employee.Payment} {Employee.Name} (");
                if (LeftNode == null)
                {
                    Console.Write($"-");
                }
                else
                {
                    PrintTree(LeftNode);
                }
                Console.Write($", ");
                if (RightNode == null)
                {
                    Console.Write($"-");
                }
                else
                {
                    PrintTree(RightNode);
                }
                Console.Write($")");
            }
            else Console.Write($"{Employee.Payment} {Employee.Name}");
        }
        private void PrintTree(Node node)
        {
            if (node.LeftNode != null || node.RightNode != null)
            {
                Console.Write($"{node.Employee.Payment} {node.Employee.Name} (");
                if (node.LeftNode == null)
                {
                    Console.Write($"-");
                }
                else
                {
                    PrintTree(node.LeftNode);
                }
                Console.Write($", ");
                if (node.RightNode == null)
                {
                    Console.Write($"-");
                }
                else
                {
                    PrintTree(node.RightNode);
                }
                Console.Write($")");
            }
            else Console.Write($"{node.Employee.Payment} {node.Employee.Name}");
        }
    }
}
