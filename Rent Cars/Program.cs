using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Projektovanje_ali_u_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the shop!");
            Seller s = new Seller();
            s.AddCars();

            bool loop = true;
            while(loop)
            {
                System.Console.WriteLine("Make a bayer: ");
               
                Buyer b = new Buyer();

                b.SetName();
                b.SetLastName();
                b.SetAge();
                b.AddCashBalance();
                
                Console.WriteLine("\nWill buyer have a credit card? ");
            
                bool loopCard = true;
                while(loopCard)
                {
                    Console.WriteLine("Yes/No: ");
                    string answer = Console.ReadLine();
                    int n;
                    if(int.TryParse(answer, out n))
                    {
                        Console.WriteLine("Can't use numbers");
                        continue;
                    }
                    if(answer.Equals("Yes") || answer.Equals("yes") || answer.Equals("YES"))
                    {
                        CreditCard c = new CreditCard();
                        c.AddCardNumber();
                        c.AddCardPin();
                        c.AddCardBalance();
                        b.setCard(c);
                        break;
                    }else if(answer.Equals("no") || answer.Equals("No") || answer.Equals("NO"))
                    {
                        Console.WriteLine("Buyer stays only with cash!");
                        loop = false;
                        break;
                    }else
                    {
                        Console.WriteLine("Wrong answer!");
                        continue;
                    }
                }

                s.ChoseCar(b);

                Console.WriteLine("Paying with cash or card? ");
                bool payingLoop = true;
                while(payingLoop)
                {
                    Console.WriteLine("Type cash or card: ");
                    string answer = Console.ReadLine();
                    int n;
                    if(int.TryParse(answer, out n))
                    {
                        Console.WriteLine("Can't use numbers");
                        continue;
                    }
                    if(answer.Equals("Cash") || answer.Equals("CASH") || answer.Equals("cash"))
                    {
                        if(!b.GetCashBalance().Equals(0))
                        {
                            s.ChargeCash(b);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You don't have any cash for this transaction!");
                            while(true)
                            {
                                Console.WriteLine("Do you want to pay with card?");
                                string answer1 = Console.ReadLine();
                                int m;
                                if(int.TryParse(answer1, out m))
                                {
                                    Console.WriteLine("Can't use numbers");
                                    continue;
                                }
                                if(answer1.Equals("Yes") || answer1.Equals("YES") || answer1.Equals("yes"))
                                {
                                    if(!b.GetCard().GetCardBalance().Equals(0))
                                    {
                                        s.ChargeCardCash(b);
                                        payingLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        s.RemoveCustomers(b);
                                        payingLoop = false;
                                        break;
                                    }
                                }
                                if(answer1.Equals("No") || answer1.Equals("NO") || answer1.Equals("no"))
                                {
                                    s.RemoveCustomers(b);
                                }
                            }
                        }
                    }
                    if(answer.Equals("Card") || answer.Equals("CARD") || answer.Equals("card"))
                    {
                        if(!b.GetCard().GetCardBalance().Equals(0))
                        {
                            s.ChargeCardCash(b);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You don't have any cash on card for this transaction!");
                            while(true)
                            {
                                Console.WriteLine("Do you want to pay with cash?");
                                string answer1 = Console.ReadLine();
                                int m;
                                if(int.TryParse(answer1, out m))
                                {
                                    Console.WriteLine("Can't use numbers");
                                    continue;
                                }
                                if(answer1.Equals("Yes") || answer1.Equals("YES") || answer1.Equals("yes"))
                                {
                                    if(!b.GetCashBalance().Equals(0))
                                    {
                                        s.ChargeCash(b);
                                        payingLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        s.RemoveCustomers(b);
                                        payingLoop = false;
                                        break;
                                    }
                                }
                                if(answer1.Equals("No") || answer1.Equals("NO") || answer1.Equals("no"))
                                {
                                    s.RemoveCustomers(b);
                                }
                            }
                        }
                    }   
                }
                
                while(true)
                {
                    Console.WriteLine("Do you want to make another buyer? (Yes/No)");
                    string answer = Console.ReadLine();
                    int n = 0;
                    if(int.TryParse(answer, out n))
                    {
                        Console.WriteLine("Can't use numbers");
                        continue;
                    }
                    if(answer.Equals("Yes") || answer.Equals("YES") || answer.Equals("yes"))
                    {
                        loop = true;
                        break;
                    }
                    if(answer.Equals("No") || answer.Equals("NO") || answer.Equals("no"))
                    {
                        loop = false;
                        break;
                    }
                }
            } //End while Buyer

        Seller.DisplayBuyers(s);

        Seller.WriteToFile(s);

        } //End main
    } //End class
} //End namespace
