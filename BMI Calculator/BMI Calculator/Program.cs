using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nC# Apps");
            Console.WriteLine("by Fudail Khan");
            Console.WriteLine("\nPlease choose an app to use:");
            Console.WriteLine("1. Distance converter");
            Console.WriteLine("2. BMI calculator");
            Console.Write("\nChoice: ");

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

            Console.WriteLine("\nWould you like to use the program again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("\nChoice: ");

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
            Console.WriteLine("\n===================================================");
            Console.WriteLine("Distance Converter");

            Console.WriteLine("\nSelect unit to convert from:");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Meters");

            int fromUnit;
            while (true)
            {
                Console.Write("\nChoice: ");
                if (!int.TryParse(Console.ReadLine(), out fromUnit) || fromUnit < 1 || fromUnit > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\nSelect unit to convert to:");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Meters");

            int toUnit;
            while (true)
            {
                Console.Write("\nChoice: ");
                if (!int.TryParse(Console.ReadLine(), out toUnit) || toUnit < 1 || toUnit > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
                else
                {
                    break;
                }
            };

            Console.Write("\nEnter the distance: ");
            double distance;
            while (!double.TryParse(Console.ReadLine(), out distance))
            {
                Console.WriteLine("Invalid distance. Please enter a valid number.");
                Console.Write("Enter the distance: ");
            }

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
        }

        static void BmiCalculator()
        {
            Console.WriteLine("\n===================================================");
            Console.WriteLine("BMI Calculator\n");
            Console.WriteLine("Please select which units you would like to use:");
            Console.WriteLine("1. Metric");
            Console.WriteLine("2. Imperial");

            int choice;
            bool validChoice;
            do
            {
                Console.Write("\nChoice: ");
                validChoice = int.TryParse(Console.ReadLine(), out choice);
            } while (!validChoice || (choice != 1 && choice != 2));

            double weight;
            double height;
            string weightUnit;
            string heightUnit;

            if (choice == 1)
            {
                weightUnit = "kg";
                heightUnit = "m";
                Console.Write("\nEnter your weight in kilograms: ");
                while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid weight.");
                    Console.Write("\nEnter your weight in kilograms: ");
                }

                Console.Write("Enter your height in meters: ");
                while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid height.");
                    Console.Write("Enter your height in meters: ");
                }
            }
            else
            {
                weightUnit = "lb";
                heightUnit = "in";
                Console.Write("\nEnter your weight in pounds: ");
                while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid weight.");
                    Console.Write("\nEnter your weight in pounds: ");
                }

                Console.Write("Enter your height in inches: ");
                while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid height.");
                    Console.Write("Enter your height in inches: ");
                }

                weight = weight * 0.45359237;
                height = height * 0.0254;
            }

            double bmi = weight / (height * height);
            Console.WriteLine($"\nYour BMI is {bmi:f2} kg/m²");

            Console.WriteLine("\nWHO weight status:");
            if (bmi < 18.5)
            {
                Console.WriteLine("Underweight");
            }
            else if (bmi < 25)
            {
                Console.WriteLine("Normal");
            }
            else if (bmi < 30)
            {
                Console.WriteLine("Overweight");
            }
            else if (bmi < 35)
            {
                Console.WriteLine("Obese Class I");
            }
            else if (bmi < 40)
            {
                Console.WriteLine("Obese Class II");
            }
            else
            {
                Console.WriteLine("Obese Class III");
            }

            Console.WriteLine("\nWARNING!");
            Console.WriteLine("If you are Black, Asian or other minority ethnic groups, you have a higher risk.");
        }
    }
}
