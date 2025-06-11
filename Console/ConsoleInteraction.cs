using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ConsoleInteraction
    {
        public static void Interation()
        {
            while (true)
            {
                Node root = null;

                bool userContinueInput = true;
                Node newNode;
                while (userContinueInput)
                {
                    try
                    {
                        newNode = AddNewNode.AddNodeFromConsole();

                        if (newNode == null)
                        {
                            if (root == null)
                            {
                                Console.WriteLine("Must be at least 1 Employee!");
                            }
                            else
                            {
                                userContinueInput = false;//Stop input employee
                            }
                        }
                        else
                        {
                            if (root == null)
                            {
                                root = newNode;//First Node
                            }
                            else
                            {
                                root.AddNode(newNode);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                root!.ShowOrdered();

                int userInputInt = 1;
                do
                {
                    Console.WriteLine("Enter payment to search employee's name:");
                    string payment = Console.ReadLine();
                    if (!int.TryParse(payment, out int paymentint))
                    {
                        Console.WriteLine("Invalid payment input!");
                    }
                    else
                    {
                        root.FindPayment(paymentint);
                    }

                    Console.WriteLine("Please inpute 0 for start from begin or\ninpute 1 to search employee by payment.");
                    string userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out userInputInt))
                    {
                        Console.WriteLine("Invalid payment input!");
                    }
                }
                while (userInputInt == 1);
            }
        }
    }
}
