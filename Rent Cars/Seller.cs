using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class Seller : Person,IEnumerable<Buyer>
{
    private List<Buyer> buyers = new List<Buyer>();
    private Dictionary<string, RentCar> availableCars = new Dictionary<string, RentCar>();
    //--------------------Constructor--------------------
    public Seller(){}
    //--------------------Getters and setters--------------------
    public void AddCars()
    {
        availableCars.Add("Bmw X6",new RentCar("X6","Bmw","Black",2020,12000,250));
        availableCars.Add("Bmw X5",new RentCar("X5","Bmw","Yellow",2015,45000,130));
        availableCars.Add("Bmw X4",new RentCar("X4","Bmw","White",2013,93000,100));

        availableCars.Add("Mercedes GLA 180",new RentCar("GLA 180","Mercedes","Green",2016,104000,85));
        availableCars.Add("Mercedes Maybach",new RentCar("Mercedes Maybach","Mercedes","White",2019,59000,550));
        availableCars.Add("Mercedes S 320",new RentCar("S 320","Mercedes","Grey",2018,12000,150));

        availableCars.Add("Fiat Punto",new RentCar("Punto","Fiat","Red",2010,201000,30));
        availableCars.Add("Fiat Panda",new RentCar("Panda","Fiat","White",2017,69000,50));
        availableCars.Add("Fiat Stilo",new RentCar("Stilo","Fiat","Blue",202,195000,30));

        availableCars.Add("Dacia Logan",new RentCar("Logan","Dacia","Brown",2014,144000,40));
        availableCars.Add("Dacia Sandero",new RentCar("Sandero","Dacia","Black",2010,121000,80));
        availableCars.Add("Dacia Duster",new RentCar("Duster","Dacia","Red",2015,97000,80));
    }
    public List<Buyer> GetListBuyers()
    {
        return this.buyers;
    }
    public void ChoseCar(Buyer b)
    {
        Console.WriteLine("\nChoosing a car ");
            
        bool carLoop = true;
        while(carLoop)
        {
            Console.WriteLine("\nEnter a car model and name: ");
            string chosenCar = Console.ReadLine();
            int n;
            if(int.TryParse(chosenCar, out n))
            {
                Console.WriteLine("Can't use numbers");
                continue;
            }
            else if(availableCars.Keys.Contains(chosenCar))
            {
                b.RentOneCar(availableCars[chosenCar]);
                availableCars.Remove(chosenCar);
                Console.WriteLine("Car successfully added!");
                
                while(true)
                {
                    Console.WriteLine("Do you want to chose another car?");
                    Console.WriteLine("Yes/No: ");
                    string answer = Console.ReadLine();
                    int m;
                    if(int.TryParse(answer, out m))
                    {
                        Console.WriteLine("Can't use numbers");
                        continue;
                    }
                    if(answer.Equals("Yes") || answer.Equals("yes"))
                    {
                        while(carLoop)
                        {
                            Console.WriteLine("Enter a car model and name: ");
                            string chosenCar1 = Console.ReadLine();
                            int o;
                            if(int.TryParse(chosenCar1, out o))
                            {
                                Console.WriteLine("Can't use numbers");
                            }
                            if(availableCars.Keys.Contains(chosenCar1))
                            {
                                b.RentOneCar(availableCars[chosenCar1]);
                                availableCars.Remove(chosenCar);
                                Console.WriteLine("Car successfully added!");
                                break;
                            }
                            else if(!availableCars.Keys.Contains(chosenCar1))
                            {
                                Console.WriteLine("You already added this car to your cart, or you misspelled it!");
                            }
                        }
                    }
                    else if(answer.Equals("No") || answer.Equals("NO") || answer.Equals("no"))
                    {
                        System.Console.WriteLine("Thank you for choosing our cars!");
                        AddBuyerToList(b);
                        carLoop = false;
                        break;
                    }
                }
            }
        }
    }
    public void AddBuyerToList(Buyer b)
    {
        buyers.Add(b);
    }
    //--------------------Cashing--------------------
    public void ChargeCash(Buyer b)
    {
        double sum = 0;
        foreach (RentCar rc in b)
        {
            sum += rc.pricePerDay;
        }
        double sum_ = b.GetCashBalance() - sum;
        b.SetCashBalance(sum_);                
    }
    public void ChargeCardCash(Buyer b)
    {     
        double sum = 0;
        foreach (RentCar rc in b)
        {
            sum += rc.pricePerDay;
        }
        double sum_  = b.GetCard().GetCardBalance() - sum;
        b.GetCard().SetCardBalance(sum_);
    }
    //--------------------Displaying customers--------------------
    public static void DisplayBuyers(Seller s)
    {
        foreach (Buyer b in s)     
        {
            System.Console.WriteLine(b.ToString());
            System.Console.WriteLine(" ");
        }
    }
    //--------------------Removing customers--------------------
    public void RemoveCustomers(Buyer b)
    {
            buyers.Remove(b);
            System.Console.WriteLine("Buyer has no cash balance and card balance so he must go out of the shop!");   
    }
    //--------------------Enumerable--------------------
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerator<Buyer> GetEnumerator()
    {
        foreach (Buyer b in buyers)
        {
            yield return b;
        }
    }
    //--------------------Writing to a txt file--------------------
    public static void WriteToFile(Seller s) 
    {
        try
        {
            FileStream path = new FileStream(@"E:\C# Developent\Projects\VS code\Projektovanje ali u c#\Results.txt",FileMode.Open,FileAccess.Write);
            if(File.Exists(@"E:\C# Developent\Projects\VS code\Projektovanje ali u c#\Results.txt"))
            {
                StreamWriter st = new StreamWriter(path);
                st.Write("----------Total----------");
                st.Write("\n");
                foreach (Buyer b in s)     
                {
                    st.Write("\n");
                    st.Write(b.ToString());
                    st.Write("\n");
                }
                st.Write("----------Total----------");
                st.Write("\n");
                st.Close();
            }
        }catch(IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
}
