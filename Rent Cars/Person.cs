using System;
using System.IO;
class Person
{    
    protected string name;
    protected string lastName;
    protected int age;
    //--------------------Constructors--------------------
    public Person()
    {
        this.name = "Blank";
        this.lastName = "Blank";
        this.age = 0;
    }
    //--------------------Getters and setters--------------------
    public void SetName() 
    {                                                                             
        while(true)                                                              
        {                                                                         
            Console.WriteLine("\nEnter name for new buyer: ");
            string name = Console.ReadLine();
            string name_ = name.Substring(0,1).ToUpper() + name.Substring(1);
            int intt = 0;
            if(int.TryParse(name, out intt))
            {
                Console.WriteLine("Can't contain numbers!");
                continue;
            }
            if(!name.Equals(name_))
            {
                Console.WriteLine("Must contain first capital letter!");
                continue;
            }
            if(name.Equals(name_))
            {
                Console.WriteLine("Correctly written name");
                this.name = name;            
                break;
            }
        }
    }
    public string GetName()
    {
        return this.name;
    }
    
    public void SetLastName()
    {
        while(true)
        {
            Console.WriteLine("\nEnter last name: ");
            string last_name = Console.ReadLine();
            string last_name_ = last_name.Substring(0,1).ToUpper() + last_name.Substring(1);
            int n = 0;
            if(int.TryParse(last_name,out n))
            {
                Console.WriteLine("Can't use numbers");
                continue;
            }    
            if(!last_name.Equals(last_name_))
            {
                Console.WriteLine("Must contain first capital letter!");
                continue;
            }
            if(last_name.Equals(last_name_))
            {
                Console.WriteLine("Correctly written last name");
                this.lastName = last_name;
                break;
            }   
        }
    }
    public string GetLastName()
    {
        return this.lastName;
    }

    public void SetAge()
    {
        while(true)
        {
            Console.WriteLine("\nEnter age in yyyy format: ");
            string input = Console.ReadLine();
            int n;
            if(int.TryParse(input, out n))
            {
                if(int.Parse(input) > 1930)
                {
                    Console.WriteLine("Correctly written years");
                    this.age = int.Parse(input);
                    break;
                }else
                {
                    Console.WriteLine("Can't enter years that are less than 1930");
                    continue;
                }
            }else
            {
                Console.WriteLine("Can't use letters");
                continue;
            }
        }
    }
    public int GetAge()
    {
        return this.age;
    }
    //--------------------ToString--------------------
    public override string ToString()
    {
        return "Person \n" + $"Name: {GetName()}" + $"\nLast name: {GetLastName()} " + $"\nAge: {GetAge()}";
    }
}
