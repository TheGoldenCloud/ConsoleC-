using System;
class CreditCard
{
    public string cardNumber; 
    public int cardPin;
    public double cardBalance;
    
    //--------------------Constructor--------------------
    public CreditCard()
    {
        this.cardNumber = "111-111111-11";
        this.cardPin = 0000;
        this.cardBalance = 0.0;
    }
    //--------------------Getters and setters--------------------
    public void AddCardNumber()
    {
        Console.WriteLine("\nDo you want to create your card number or we can choose ");
        bool cardLoop = true;
        while(cardLoop)
        {
            Console.WriteLine("Type YES for you to crate or type NO for us to create for you: ");
            string answer = Console.ReadLine();
            int n;
            if(int.TryParse(answer, out n))
            {
                Console.WriteLine("Can't use numbers YES/NO ");
                continue;
            }
            if(answer.Equals("Yes") || answer.Equals("YES") || answer.Equals("yes"))
            {
                while(true)
                {
                    Console.WriteLine("Enter card number: ");
                    string cardNum = Console.ReadLine();
                    int m;
                    if(int.TryParse(cardNum, out m))
                    {
                        Console.WriteLine("Can't use numbers, must contain '-' ");
                        continue;
                    }
                    if(CreditCard.CardNumberChecker(cardNum)){
                        Console.WriteLine("Card number successfully added!");
                        this.cardNumber = cardNum;
                        cardLoop = false;
                        break;    
                    }else
                    {
                        Console.WriteLine("Card number written wrong , exp. 360-587596-17");
                        continue;
                    }
                }
            }
            else if(answer.Equals("No") || answer.Equals("NO") || answer.Equals("no"))
            {
                this.cardNumber = RandomNumberGenerate();
                Console.WriteLine("Card number successfully generated!");
                break;
            }
        }
    }
    public void SetCardNumber(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }
    public string GetCardNumber()
    {
        return this.cardNumber;
    }
    public void AddCardPin()
    {
        Console.WriteLine("\nDo you want to create your pin or we can choose: ");
        bool cardLoop = true;
        while(cardLoop)
        {
            Console.WriteLine("Type YES for you to crate or type NO for us to create for you: ");
            string answer2 = Console.ReadLine();
            int n;
            if(int.TryParse(answer2, out n))
            {
                Console.WriteLine("Can't use numbers YES/NO ");
                continue;
            }
            if(answer2.Equals("Yes") || answer2.Equals("YES") || answer2.Equals("yes"))
            {
                while(true)
                {
                    Console.WriteLine("Enter pin number: ");    
                    string cardPinNumber = Console.ReadLine();
                    if(int.TryParse(cardPinNumber, out n))
                    {
                        if(CreditCard.CardPinChecker(int.Parse(cardPinNumber)))
                        {
                            this.cardPin = int.Parse(cardPinNumber);
                            Console.WriteLine("Pin successfully added!");
                            this.cardPin = int.Parse(cardPinNumber);
                            cardLoop = false;
                            break;
                        }    
                    }else
                    {
                        Console.WriteLine("Card pin written wrong, can't use letters");
                        continue;
                    }
                }
            }else if(answer2.Equals("No") || answer2.Equals("NO") || answer2.Equals("no"))
            {
                this.cardPin = RandomPinGenerate();
                Console.WriteLine("Pin successfully generated!");
                break;
            }
        }
    }
    public void SetCardPin(int cardPin)
    {
        this.cardPin = cardPin;
    }
    public int GetCardPin()
    {
        return cardPin;
    }
    public void AddCardBalance()
    {
        while(true)
        {
            Console.WriteLine("\nEnter your card balance: ");
            string balance = Console.ReadLine();
            double n;
            if(double.TryParse(balance, out n))
            {
                if(double.Parse(balance) >= 0)
                {
                    Console.WriteLine("Balance successfully added!");
                    this.cardBalance = double.Parse(balance);
                    break;
                }else
                {
                    Console.WriteLine("Can't have negative balance");
                }
                
            }else
            {
                Console.WriteLine("Card balance written wrong, can't use letters!");
                continue;
            }
        }
    }
    public void SetCardBalance(double balance)
    {
        this.cardBalance = balance;
    }
    public double GetCardBalance()
    {
        return this.cardBalance;
    }
    //--------------------Checkers--------------------
    public static bool CardNumberChecker(string number)
    {
        string[] number_ = number.Split("-");
        if(number.Contains("-"))
        {
            if(number_[0].Length == 3 && number_[1].Length == 6 && number_[2].Length == 2)
            {
                return true;
            }
        }
        return false;    
    }
    public static bool CardPinChecker(int cardPin)
    {
        if(cardPin > 1111 && cardPin < 9999)
        {
            return true;
        }
        return false;
    }
    //--------------------Generate functions--------------------
    public string RandomNumberGenerate()
    {
        Random r = new Random();
        int firstR = r.Next(111,999);
        int secondR = r.Next(11111,99999);
        int thirdR = r.Next(11,99);
        string randomResult = firstR + "-" + secondR + "-" + thirdR;
        return this.cardNumber = randomResult;
    }
    public int RandomPinGenerate()
    {
        Random r = new Random();
        int randomPin = r.Next(1111,9999);
        return this.cardPin = randomPin;
    }
    public override string ToString()
    {
        return $"\nCard number: {GetCardNumber()} " + $"\nCard pin: {GetCardPin()}" + $"\nCard balance: {GetCardBalance()}";
    }
}