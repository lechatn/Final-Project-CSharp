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
                Console.WriteLine("No cars available");
            }
            foreach (Car car in ParkingContent)
            {
                Console.WriteLine(car);
            }
        }

        public static List<String> AvailableCars()
        {
            int counter = 0;
            List<String> availableCars = new List<String>();
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars available");
                return availableCars;
            }
            foreach (Car car in ParkingContent)
            {
                if (car.IsAvailable)
                {
                    counter++;
                    availableCars.Add(car.ToString());
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No cars available");
                return availableCars;
            }
            availableCars.Add("Exit");
            return availableCars;
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
                    Console.WriteLine(car);
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

        public static List<String> RentedCars()
        {
            int counter = 0;
            List<String> rentedCars = new List<String>();
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars available");
                return rentedCars;
            }
            foreach (Car car in ParkingContent)
            {
                if (car.IsAvailable == false)
                {
                    counter++;
                    rentedCars.Add(car.ToString());
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No cars available");
                return rentedCars;
            }
            rentedCars.Add("Exit");
            return rentedCars;
        }
    }
}