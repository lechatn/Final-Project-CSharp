using System;
using CsharpFinalProject;

namespace CsharpFinalProject{
    public class Controller
    {
        public void Start()
        {
            Console.Clear();
            while(true) {
                Parking parking = new Parking();
                Console.WriteLine("Welcome to the parking lot");
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. Show cars");
                Console.WriteLine("3. Show available cars");
                Console.WriteLine("4. Rent car");
                Console.WriteLine("5. Return car");
                Console.WriteLine("6. Exit");

                string option = Console.ReadLine();
                Console.Clear();
                
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the brand of the car");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Enter the model of the car");
                        string model = Console.ReadLine();
                        Console.WriteLine("Enter the year of the car");
                        int year;
                        while(true) {
                            try {
                                year = Convert.ToInt32(Console.ReadLine());
                                break;
                            } catch {
                                Console.WriteLine("Invalid year, please enter a valid year");
                            }
                        }
                        Car car = new Car(brand, model, year);
                        Parking.AddCar(car);
                        Console.Clear();
                        Console.WriteLine("Your car " + brand + model + " of " + year + " has been added to the parking lot"); 
                        break;
                    case "2":
                        Parking.ShowCars();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Parking.ShowAvailableCars();
                        break;
                    case "4":
                        Parking.ShowAvailableCars();
                        if (Parking.ParkingContent.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine("Enter the id of the car you want to rent");
                        string idToRent = Console.ReadLine();
                        for (int i = 0; i < Parking.ParkingContent.Count; i++)
                        {
                            if (Parking.ParkingContent[i].Id == idToRent)
                            {
                                Car carToRent = Parking.ParkingContent[i];
                                Parking.RentCar(carToRent);
                            }
                        }
                        break;
                    case "5":
                        if (Parking.ParkingContent.Count == 0)
                        {
                            Console.WriteLine("No cars to return");
                            break;
                        }
                        Console.WriteLine("Enter the id of the car you want to return");
                        string idToReturn = Console.ReadLine();
                        for (int i = 0; i < Parking.ParkingContent.Count; i++)
                        {
                            if (Parking.ParkingContent[i].Id == idToReturn)
                            {
                                Car carToReturn = Parking.ParkingContent[i];
                                Parking.ReturnCar(carToReturn);
                            }
                        }
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}