using System;
using CsharpFinalProject;

namespace CsharpFinalProject{
    public class Controller
    {
        public Dictionary<string, List<string>> carTypes = new Dictionary<string, List<string>>()
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

        public string[] car = {
            "      ______",
            "  ___/      \\___",
            " |   _      _   |",
            "'-(_)-------(_)--'"
        };

        public void Start()
        {
            Console.Clear();
            while(true) {
                Parking parking = new Parking();
                List<string> optionsMenu = new List<string> { "Add a car", "Show all cars", "Show available cars", "Rent a car", "Return a car", "Exit" };

                int selectedIndexMenu = OptionsManager(optionsMenu, "Choose an option");
                string option = (selectedIndexMenu + 1).ToString();
                Console.Clear();
                
                switch (option)
                {
                    case "1":

                        List<string> brands = new List<string>(carTypes.Keys);
                        int selectedIndex = OptionsManager(brands, "Choose the brand of the car");
                        string brand = brands[selectedIndex];
                        Console.Clear();

                        List<string> models = carTypes[brand];
                        selectedIndex = OptionsManager(models, "Choose the model of the car");
                        string model = models[selectedIndex];
                        Console.Clear();


                        int year = YearManager();

                        Car car = new Car(brand, model, year, Parking.ParkingContent);
                        Parking.AddCar(car);
                        Console.Clear();
                        Console.WriteLine("Your car " + brand + model + " of " + year + " has been added to the parking lot"); 
                        break;
                    case "2":
                        Parking.ShowCars();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Parking.ShowAvailableCars();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        List<String> availableCars = Parking.AvailableCars();
                        if (Parking.ParkingContent.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        int idToRent = OptionsManager(availableCars, "Choose the car you want to rent");
                        try {
                            if (idToRent == availableCars.Count - 1) {
                                Console.Clear();
                                break;
                            }
                            if (idToRent < 1 || idToRent > Parking.ParkingContent.Count) {
                                Console.WriteLine("Invalid id, please enter a valid id");
                                break;
                            }
                        } catch {
                            Console.WriteLine("Invalid id, please enter a valid id");
                            break;
                        }
                        Parking.RentCar(idToRent);
                        ShowCarExit();
                        Console.Clear();
                        break;
                    case "5":
                        Parking.ShowNotAvailableCars();
                        if (Parking.ParkingContent.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        Console.WriteLine("Enter the id of the car you want to return");
                        int idToReturn;
                        try {
                            idToReturn = Convert.ToInt32(Console.ReadLine());
                            if (idToReturn < 1 || idToReturn > Parking.ParkingContent.Count) {
                                Console.WriteLine("Invalid id, please enter a valid id");
                                break;
                            }
                        } catch {
                            Console.WriteLine("Invalid id, please enter a valid id");
                            break;
                        }
                        Parking.ReturnCar(idToReturn);
                        ShowCarReturn();
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

        public int OptionsManager(List<string> options, string message)
        {
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("> " + options[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Count - 1) ? 0 : selectedIndex + 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            return selectedIndex;
        }

        public void ShowCarExit()
        {
            int consoleWidth = Console.WindowWidth;
            int carLength = car[0].Length;
            int maxPosition = consoleWidth - carLength;
            int stopPosition = 100;
            int position = 0;

            while (true)
            {
                Console.Clear();
                foreach (string line in car)
                {
                    Console.SetCursorPosition(position, Console.CursorTop);
                    Console.WriteLine(line);
                }
                Thread.Sleep(10);
                position++;
                if (position > stopPosition)
                {
                    return;
                }
            }
        }

        public void ShowCarReturn()
        {
            int consoleWidth = Console.WindowWidth;
            int carLength = car[0].Length;
            int maxPosition = consoleWidth - carLength;
            int stopPosition = 100;
            int position = stopPosition;

            while (true)
            {
                Console.Clear();
                foreach (string line in car)
                {
                    Console.SetCursorPosition(position, Console.CursorTop);
                    Console.WriteLine(line);
                }
                Thread.Sleep(10);
                position--;
                if (position < 0)
                {
                    return;
                }
            }
        }

        public int YearManager() 
        {
            List<int> years = new List<int>();
            for (int i = 1970; i <= 2024; i++)
            {
                years.Add(i);
            }

            int selectedIndex = 29;


            while(true)
            {
                Console.Clear();
                Console.WriteLine("Choose the year of the car\n");
                Console.WriteLine("Use the up and down arrows to navigate and press enter to select the year\n");
                
                Console.WriteLine("- " + years[selectedIndex] + " +");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (selectedIndex != 0){
                        selectedIndex--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (selectedIndex + 1 != years.Count){
                        selectedIndex++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

            }

            return years[selectedIndex];
        }
    }
}