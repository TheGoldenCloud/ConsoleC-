using System;
using System.Collections;
using System.Collections.Generic;
class Buyer : Person, IEnumerable<RentCar>
{
    private List<RentCar> buyersCars;
    private double cashBalance;
    private CreditCard card;
    //--------------------Constructor--------------------
    public Buyer() : base()
    {
        this.cashBalance = 0.0;
        this.card = new CreditCard();
        this.buyersCars = new List<RentCar>();
    }
    //--------------------Getters and setters--------------------
    public void AddCashBalance()
    {
        while(true)
        {
            Console.WriteLine("\nEnter cash balance: ");
            string input = Console.ReadLine();
            int n;
            if(int.TryParse(input, out n))
            {
                if(int.Parse(input) >= 0)
                {
                    Console.WriteLine("Correctly written cash balance");
                    this.cashBalance = double.Parse(input);
                    break;
                }else
                {
                    Console.WriteLine("Cash can't be negative");
                    continue;
                }
            }else
            {
                Console.WriteLine("Can't use letters");
                continue;
            }
        }
    }
    public void SetCashBalance(double balance)
    {
        this.cashBalance = balance;
    }
    public double GetCashBalance()
    {
        return this.cashBalance;
    }
    public void setCard(CreditCard k)
    {
        this.card = k;
    }
    public CreditCard GetCard()
    {
        return this.card;
    }
    public void SetBuyerCars(List<RentCar> rentCars)
    {
        this.buyersCars = rentCars;
    }

    public List<RentCar> GetBuyersCars()
    {
        return this.buyersCars;
    }
    
    public void RentOneCar(RentCar ra)
    {
        this.buyersCars.Add(ra);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerator<RentCar> GetEnumerator()
    {
        foreach (RentCar r in buyersCars)
        {
            yield return r;
        }
    }
    //--------------------ToString--------------------
    public override string ToString()
    {
        if(GetCard().GetCardBalance().Equals(0))
        {
            return "BUYER \n" + $"Name: {GetName()}" + $"\nLast name: {GetLastName()}" + $"\nAge: {GetAge()}" + $"\nCash balance: {GetCashBalance()}";
        }
        return "BUYER \n" + $"Name: {GetName()}" + $"\nLast name: {GetLastName()}" + $"\nAge: {GetAge()}" + $"\nCash balance: {GetCashBalance()}" + card.ToString();
    }
}