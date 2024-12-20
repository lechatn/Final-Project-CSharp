using System;

namespace CsharpFinalProject {
    public class Parking
    {
        public static List<Car> ParkingContent { get; set; } = new List<Car>(); // List of cars in the parking

        public Parking(){} // Constructor for the parking class

        public static void AddCar(Car car) // Method to add a car to the parking
        {
            ParkingContent.Add(car);
        }

        public static void ShowCars() // Method to show all the cars in the parking
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

        public static List<String> AvailableCars() // Method to return a list of all the available cars in the parking
        {
            int counter = 0;
            List<String> availableCars = new List<String>(); // List of available cars
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
                    availableCars.Add(car.ToString()); // Add the car to the list of available cars
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No cars available");
                return availableCars;
            }
            availableCars.Add("Exit"); // Add the exit option to the list of available cars
            return availableCars;
        }



        public static void ShowAvailableCars() // Method to show all the available cars in the parking
        {
            if (ParkingContent.Count == 0)
            {
                Console.WriteLine("No cars available");
            }
            int counter = 0;
            foreach (Car car in ParkingContent)
            {
                if (car.IsAvailable)
                {
                    Console.WriteLine(car);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No cars available");
            }
        }

        public static void RentCar(int carToRent) // Method to rent a car
        {
            foreach (Car car in ParkingContent)
            {
                if (car.Id == carToRent && car.IsAvailable) // Check if the car is available
                {
                    car.IsAvailable = false;
                    Console.WriteLine("Car rented successfully");
                }
                else if (car.Id == carToRent && !car.IsAvailable) // Check if the car is already rented
                {
                    Console.WriteLine("Car is not available");
                }
            }
        }

        public static void ReturnCar(int carToReturn) // Method to return a car
        {
            foreach (Car car in ParkingContent)
            {
                if (car.Id == carToReturn && !car.IsAvailable) // Check if the car is rented
                {
                    car.IsAvailable = true;
                    Console.WriteLine("Car returned successfully");
                }
                else if (car.Id == carToReturn && car.IsAvailable) // Check if the car is already available
                {
                    Console.WriteLine("Car is not rented");
                }
            }
        }

        public static List<String> RentedCars() // Method to return a list of all the rented cars in the parking
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
            rentedCars.Add("Exit"); // Add the exit option to the list of rented cars
            return rentedCars;
        }
    }
}