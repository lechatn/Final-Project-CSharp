using System;

namespace CsharpFinalProject {
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }

        public Car(string Brand, string Model, int Year, List<Car> parkingContent)
        {
            this.Id = parkingContent.Count + 1;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.IsAvailable = true;
        }

        public override string ToString(){
            return $"{Id}- {Brand} {Model} of {Year}, status : " + (IsAvailable ? " available" : " not available");
        }
    }
}