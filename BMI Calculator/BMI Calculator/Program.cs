using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program! Please choose an option:");
            Console.WriteLine("1. Distance converter");
            Console.WriteLine("2. BMI calculator");

            string input = Console.ReadLine();
            int choice;

            while (!int.TryParse(input, out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid choice. Please choose again.");
                input = Console.ReadLine();
            }

            switch (choice)
            {
                case 1:
                    DistanceConverter();
                    break;
                case 2:
                    BmiCalculator();
                    break;
            }

            Console.WriteLine("Would you like to use the program again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            input = Console.ReadLine();

            while (input != "1" && input != "2")
            {
                Console.WriteLine("Invalid choice. Please choose again.");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                Main(args);
            }
        }

        static void DistanceConverter()
        {
            Console.WriteLine("");
            Console.WriteLine("Distance Converter");
            Console.WriteLine("By Fudail Khan");
            Console.WriteLine("");

            Console.WriteLine("Select unit to convert from:");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Meters");
            Console.WriteLine("");

            int fromUnit;
            while (true)
            {
                Console.Write("Enter your choice (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out fromUnit) || fromUnit < 1 || fromUnit > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("");

            Console.WriteLine("Select unit to convert to:");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Meters");
            Console.WriteLine("");

            int toUnit;
            while (true)
            {
                Console.Write("Enter your choice (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out toUnit) || toUnit < 1 || toUnit > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("");

            Console.Write("Enter the distance: ");
            double distance;
            while (!double.TryParse(Console.ReadLine(), out distance))
            {
                Console.WriteLine("Invalid distance. Please enter a valid number.");
                Console.Write("Enter the distance: ");
            }
            Console.WriteLine("");

            string fromUnitStr = "";
            string toUnitStr = "";
            double convertedDistance = 0;

            switch (fromUnit)
            {
                case 1:
                    fromUnitStr = "miles";
                    switch (toUnit)
                    {
                        case 1:
                            toUnitStr = "miles";
                            convertedDistance = distance;
                            break;
                        case 2:
                            toUnitStr = "feet";
                            convertedDistance = distance * 5280;
                            break;
                        case 3:
                            toUnitStr = "meters";
                            convertedDistance = distance * 1609.34;
                            break;
                    }
                    break;
                case 2:
                    fromUnitStr = "feet";
                    switch (toUnit)
                    {
                        case 1:
                            toUnitStr = "miles";
                            convertedDistance = distance / 5280;
                            break;
                        case 2:
                            toUnitStr = "feet";
                            convertedDistance = distance;
                            break;
                        case 3:
                            toUnitStr = "meters";
                            convertedDistance = distance / 3.281;
                            break;
                    }
                    break;
                case 3:
                    fromUnitStr = "meters";
                    switch (toUnit)
                    {
                        case 1:
                            toUnitStr = "miles";
                            convertedDistance = distance / 1609.34;
                            break;
                        case 2:
                            toUnitStr = "feet";
                            convertedDistance = distance * 3.281;
                            break;
                        case 3:
                            toUnitStr = "meters";
                            convertedDistance = distance;
                            break;
                    }
                    break;
            }

            Console.WriteLine("{0} {1} is equal to {2} {3}.", distance, fromUnitStr, convertedDistance, toUnitStr);
            Console.ReadLine();
        }

        static void BmiCalculator()
        {
            Console.WriteLine("BMI Calculator");
            Console.WriteLine("---------------");
            Console.WriteLine("This application will calculate your Body Mass Index (BMI) and provide your WHO weight status.");
            Console.WriteLine("");

            Console.WriteLine("Please select your preferred units of measurement:");
            Console.WriteLine("1. Metric");
            Console.WriteLine("2. Imperial");
            Console.WriteLine("");
            Console.Write("Choice: ");

            int choice = 0;
            double weight = 0.0;
            double height = 0.0;

            try
            {
                choice = int.Parse(Console.ReadLine());

                if (choice != 1 && choice != 2)
                {
                    throw new ArgumentException("Invalid choice entered.");
                }

                Console.WriteLine("");
                Console.Write("Please enter your weight in kilograms: ");

                if (choice == 1)
                {
                    weight = double.Parse(Console.ReadLine());

                    if (weight <= 0)
                    {
                        throw new ArgumentException("Weight must be greater than zero.");
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Stones: ");
                    double stones = double.Parse(Console.ReadLine());

                    Console.Write("Pounds: ");
                    double pounds = double.Parse(Console.ReadLine());

                    if (stones < 0 || pounds < 0)
                    {
                        throw new ArgumentException("Invalid weight entered.");
                    }

                    weight = (stones * 14) + pounds;
                }

                Console.Write("Please enter your height in meters: ");

                if (choice == 1)
                {
                    height = double.Parse(Console.ReadLine());

                    if (height <= 0)
                    {
                        throw new ArgumentException("Height must be greater than zero.");
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Feet: ");
                    double feet = double.Parse(Console.ReadLine());

                    Console.Write("Inches: ");
                    double inches = double.Parse(Console.ReadLine());

                    if (feet < 0 || inches < 0 || inches >= 12)
                    {
                        throw new ArgumentException("Invalid height entered.");
                    }

                    height = (feet * 12) + inches;
                }

                double bmi = 0.0;

                if (choice == 1)
                {
                    bmi = weight / Math.Pow(height, 2);
                }
                else
                {
                    bmi = (weight * 703) / Math.Pow(height, 2);
                }

                Console.WriteLine("");
                Console.WriteLine($"Your BMI is {bmi:F2}.");

                if (bmi < 18.5)
                {
                    Console.WriteLine("WHO Weight Status: Underweight");
                }
                else if (bmi < 25.0)
                {
                    Console.WriteLine("WHO Weight Status: Normal");
                }
                else if (bmi < 30.0)
                {
                    Console.WriteLine("WHO Weight Status: Overweight");
                }
                else if (bmi < 35.0)
                {
                    Console.WriteLine("WHO Weight Status: Obese Class I");
                }
                else if (bmi < 40.0)
                {
                    Console.WriteLine("WHO Weight Status: Obese Class II");
                }
                else
                {
                    Console.WriteLine("WHO Weight Status: Obese Class III");
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
