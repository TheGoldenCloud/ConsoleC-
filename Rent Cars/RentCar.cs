
class RentCar : Car{
    public double pricePerDay { get; set; }
    
    public RentCar(){}
    public RentCar(string model, string mark, string color, int yearMade, int mileage,double pricePerDay) : base(model,mark,color,yearMade,mileage){
        this.pricePerDay = pricePerDay;
    }
    public override string ToString()
    {
        return "CAR" + $"\nModel: {Model}" + $"\nBrand: {Mark}" + $"\nMade year: {YearMade}" + $"\nMade year: {Mileage}" + $"\nPrice per day: {pricePerDay}" + $"\nAavailability: {stanjeDostupnosti}";
    }
    //Dopuni funkcije
}
