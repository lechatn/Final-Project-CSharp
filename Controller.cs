using System;
using CsharpFinalProject;

namespace CsharpFinalProject{
    public class Controller
    {
        private Dictionary<string, List<string>> carTypes = new Dictionary<string, List<string>>() // Dictionary with car brands and models
        {
            { "Toyota", new List<string> { "Corolla", "Yaris", "Camry", "Rav4", "Land Cruiser" } },
            { "Honda", new List<string> { "Civic", "Accord", "CR-V", "Pilot", "Odyssey" } },
            { "Ford", new List<string> { "Fiesta", "Focus", "Fusion", "Escape", "Explorer" } },
            { "Chevrolet", new List<string> { "Spark", "Sonic", "Malibu", "Equinox", "Traverse" } },
            { "Nissan", new List<string> { "Versa", "Sentra", "Altima", "Rogue", "Pathfinder" } },
            { "Peugeot", new List<string> { "208", "206", "308", "408", "2008", "3008" } },
            { "Renault", new List<string> { "Clio", "Megane", "Captur", "Koleos", "Duster" } },
            { "Volkswagen", new List<string> { "Gol", "Polo", "Jetta", "Tiguan", "Touareg" } },
            { "Hyundai", new List<string> { "i10", "i20", "i30", "Tucson", "Santa Fe" } },
            { "Kia", new List<string> { "Picanto", "Rio", "Cerato", "Sportage", "Sorento" } },
            { "Mercedes-Benz", new List<string> { "A-Class", "C-Class", "E-Class", "S-Class", "GLA", "GLC" } },
            { "BMW", new List<string> { "1 Series", "3 Series", "5 Series", "7 Series", "X1", "X3", "X5" } },
            { "Audi", new List<string> { "A1", "A3", "A4", "A6", "Q2", "Q3", "Q5" } },
            { "Lexus", new List<string> { "IS", "ES", "GS", "LS", "NX", "RX" } },
            { "Mazda", new List<string> { "2", "3", "6", "CX-3", "CX-5", "CX-9" } },
            { "Subaru", new List<string> { "Impreza", "Legacy", "Forester", "Outback", "Ascent" } },
            { "Jeep", new List<string> { "Renegade", "Compass", "Cherokee", "Grand Cherokee", "Wrangler" } },
            { "Land Rover", new List<string> { "Discovery", "Discovery Sport", "Range Rover Evoque", "Range Rover Velar", "Range Rover Sport", "Range Rover" } },
            { "Volvo", new List<string> { "S60", "S90", "V60", "V90", "XC40", "XC60", "XC90" } },
            { "Jaguar", new List<string> { "XE", "XF", "XJ", "F-Pace", "E-Pace", "I-Pace" } },
            { "Tesla", new List<string> { "Model S", "Model 3", "Model X", "Model Y" } },
            { "Fiat", new List<string> { "500", "Panda", "Tipo", "500X", "500L" } },
            { "Alfa Romeo", new List<string> { "Giulietta", "Giulia", "Stelvio" } },
            { "Mitsubishi", new List<string> { "Mirage", "Lancer", "Outlander", "Pajero" } },
            { "Suzuki", new List<string> { "Swift", "Baleno", "Vitara", "Jimny" } },
            { "Citroen", new List<string> { "C3", "C4", "C5", "C3 Aircross", "C4 Cactus" } }
        };

        public void Start() // Main menu
        {
            Console.Clear(); // Clear the console
            while(true) { // Loop to keep the program running
                Parking parking = new Parking();
                List<string> optionsMenu = new List<string> { "Add a car", "Show all cars", "Show available cars", "Rent a car", "Return a car", "Exit" };

                int selectedIndexMenu = OptionsManager(optionsMenu, "Choose an option:"); // Call the OptionsManager method to show the main menu
                string option = (selectedIndexMenu + 1).ToString();
                Console.Clear();
                
                switch (option) // Switch to manage the options
                {
                    case "1":

                        List<string> brands = new List<string>(carTypes.Keys); // List with the car brands
                        int selectedIndex = OptionsManager(brands, "Choose the brand of the car");
                        string brand = brands[selectedIndex];
                        Console.Clear();

                        List<string> models = carTypes[brand]; // List with the car models
                        selectedIndex = OptionsManager(models, "Choose the model of the car");
                        string model = models[selectedIndex];
                        Console.Clear();

                        int year = YearManager(); // Call the YearManager method to select the year of the car

                        Car car = new Car(brand, model, year, Parking.ParkingContent);
                        Parking.AddCar(car);
                        Console.Clear();
                        Console.WriteLine("Your car " + brand + model + " of " + year + " has been added to the parking lot"); 
                        break;
                    case "2":
                        Parking.ShowCars(); // Call the ShowCars method to show all the cars in the parking lot
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Parking.ShowAvailableCars(); // Call the ShowAvailableCars method to show all the available cars in the parking lot
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        List<String> availableCars = Parking.AvailableCars(); // Call the AvailableCars method to show all the available cars in the parking lot
                        if (Parking.ParkingContent.Count == 0 || availableCars.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        int idToRent = OptionsManager(availableCars, "Choose the car you want to rent"); // Call the OptionsManager method to show the available cars
                        try { 
                            if (idToRent == availableCars.Count) {
                                Console.Clear();
                                break;
                            }
                            else if (idToRent < 0 || idToRent > Parking.ParkingContent.Count) { // Check if the id is valid
                                Console.WriteLine("Invalid id, please enter a valid id");
                                break;
                            }
                            else {
                                idToRent = Convert.ToInt32(availableCars[idToRent].Split("-")[0]); // Get the great id of the car by splitting the string
                                Parking.RentCar(idToRent); // Call the RentCar method to rent the car
                                Animation animation = new Animation();
                                animation.ShowCarExit(); // Call the ShowCarExit method to show the animation of the car leaving the parking lot
                            }
                        } catch {
                            Console.WriteLine("Invalid id, please enter a valid id");
                            break;
                        }
                        Console.Clear();
                        break;
                    case "5":
                        List<String> rentedCars = Parking.RentedCars(); // Call the RentedCars method to show all the rented cars in the parking lot
                        if (Parking.ParkingContent.Count == 0 || rentedCars.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        int idToReturn = OptionsManager(rentedCars, "Choose the car you want to return"); // Call the OptionsManager method to show the rented cars
                        try {
                            if (idToReturn == rentedCars.Count) {
                                Console.Clear();
                                break;
                            }
                            else if (idToReturn < 0 || idToReturn > Parking.ParkingContent.Count) { // Check if the id is valid
                                Console.WriteLine("Invalid id, please enter a valid id");
                                break;
                            }
                            else {
                                idToReturn = Convert.ToInt32(rentedCars[idToReturn].Split("-")[0]); // Get the great id of the car by splitting the string
                                Parking.ReturnCar(idToReturn); // Call the ReturnCar method to return the car
                                Animation animation = new Animation();
                                animation.ShowCarReturn();  // Call the ShowCarReturn method to show the animation of the car returning to the parking lot
                            }
                        } catch {
                            Console.WriteLine("Invalid id, please enter a valid id");
                            break;
                        }
                        Console.Clear();
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

        private int OptionsManager(List<string> options, string message) // Method to manage the options
        {
            int selectedIndex = 0; // Index of the selected option

            while (true) // Loop to keep the program running
            {
                Console.Clear();
                Console.WriteLine(message);
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Change the color of the selected option
                    }
                    Console.WriteLine("> " + options[i]); // Show the options
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow) // Check if the up arrow key is pressed
                { 
                    selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1; 
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow) // Check if the down arrow key is pressed
                { 
                    selectedIndex = (selectedIndex == options.Count - 1) ? 0 : selectedIndex + 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter) // Check if the enter key is pressed
                {
                    break;
                }
            }

            return selectedIndex; // Return the index of the selected option
        }

        private int YearManager() 
        {
            List<int> years = new List<int>(); // List with the years of the cars
            for (int i = 1970; i <= 2024; i++)
            {
                years.Add(i); 
            }

            int selectedIndex = 29; 


            while(true) // Loop to keep the program running
            {
                Console.Clear();
                Console.WriteLine("Choose the year of the car\n");
                Console.WriteLine("Use the left and right arrows to navigate and press enter to select the year\n");
                
                Console.WriteLine("- " + years[selectedIndex] + " +"); // Show the selected year
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow) // Check if the left arrow key is pressed
                {
                    if (selectedIndex != 0){
                        selectedIndex--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow) // Check if the right arrow key is pressed
                {
                    if (selectedIndex + 1 != years.Count){
                        selectedIndex++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter) // Check if the enter key is pressed
                {
                    break;
                }

            }

            return years[selectedIndex];
        }
    }
}