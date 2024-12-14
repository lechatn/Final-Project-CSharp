using System;

namespace CsharpFinalProject {
    public class Parking
    {
        public static List<Car> ParkingContent { get; set; } = new List<Car>();

        public Parking() {}

        public static void AddCar(Car car)
        {
            ParkingContent.Add(car);
        }

        public static void ShowCars()
        {
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars in the parking lot");
            }
            foreach (Car car in ParkingContent)
            {
                Console.WriteLine(car);
            }
        }

        public static void ShowAvailableCars()
        {
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars available");
            }
            foreach (Car car in ParkingContent)
            {
                if (car.IsAvailable)
                {
                    Console.WriteLine(car + " id = " + car.Id);
                }
            }
        }

        public static void ShowNotAvailableCars()
        {
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars available");
            }
            foreach (Car car in ParkingContent)
            {
                if (!car.IsAvailable)
                {
                    Console.WriteLine(car + " id = " + car.Id);
                }
            }
        }

        public static void RentCar(int carToRent)
        {
            foreach (Car car in ParkingContent)
            {
                if (car.Id == carToRent && car.IsAvailable)
                {
                    car.IsAvailable = false;
                    Console.WriteLine("Car rented successfully");
                }
                else if (car.Id == carToRent && !car.IsAvailable)
                {
                    Console.WriteLine("Car is not available");
                }
            }
        }

        public static void ReturnCar(int carToReturn)
        {
            foreach (Car car in ParkingContent)
            {
                if (car.Id == carToReturn && !car.IsAvailable)
                {
                    car.IsAvailable = true;
                    Console.WriteLine("Car returned successfully");
                }
                else if (car.Id == carToReturn && car.IsAvailable)
                {
                    Console.WriteLine("Car is not rented");
                }
            }
        }
    }
}