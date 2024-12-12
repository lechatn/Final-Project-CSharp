using System;

namespace CsharpFinalProject {
    public class Parking
    {
        public static List<Car> ParkingContent { get; set; }  = new List<Car>();

        public static void AddCar(Car car)
        {
            ParkingContent.Add(car);
        }
        public static void RemoveCar(Car car)
        {
            ParkingContent.Remove(car);
        }
        public static void ShowCars()
        {
            foreach (Car car in ParkingContent)
            {
                Console.WriteLine(car);
            }
        }
        public static void ShowAvailableCars()
        {
            foreach (Car car in ParkingContent)
            {
                if (car.IsAvailable)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}