using System;

namespace CsharpFinalProject {
    public class Car
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }

        public Car(string Brand, string Model, int Year)
        {
            Guid myUUId = Guid.NewGuid();
            string convertedUUID = myUUId.ToString();
            this.Id = convertedUUID;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.IsAvailable = true;
        }

        public override string ToString(){
            return $"{Brand} {Model} {Year} {IsAvailable}";
        }
    }
}