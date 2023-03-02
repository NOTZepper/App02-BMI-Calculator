using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
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
