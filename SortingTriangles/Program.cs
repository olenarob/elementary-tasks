using ArgumentsProcessor;
using System;
using System.Collections.Generic;

namespace SortingTriangles
{
    class Program
    {
        private const string ListHeader = "===============Triangles list:===============";

        static void Main(string[] args)
        {
            var triangles = new List<Triangle>();

            string userAnswer;
            do
            {
                if (GetTriangleFromUserInput(out Triangle triangle))
                {
                    triangles.Add(triangle);
                }
                Console.Write("Try again? ");
                userAnswer = Console.ReadLine();
            }
            while (IfRepeat(userAnswer));

            //triangles.Sort();

            DisplayTrianglesList(triangles);
        }

        private static void DisplayTrianglesList(List<Triangle> triangles)
        {
            Console.WriteLine(ListHeader);
            
            int i = 0;
            foreach (var item in triangles)
            {
                Console.WriteLine($"{++i}.{item}");
            }
        }

        private static bool IfRepeat(string userAnswer)
        {
            return userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool GetTriangleFromUserInput(out Triangle triangle)
        {
            triangle = default;
            bool success = false;
            
            Console.Write("Please enter name of triangle: ");
            string name = Console.ReadLine();
            
            double side1 = Argument.GetValueFromUser($" first side of triangle", double.Epsilon, double.MaxValue);
            double side2 = Argument.GetValueFromUser($"second side of triangle", double.Epsilon, double.MaxValue);
            double side3 = Argument.GetValueFromUser($" third side of triangle", double.Epsilon, double.MaxValue);
            
            if (Triangle.IsTriangle(side1, side2, side3))
            {
                triangle = new Triangle(name, side1, side2, side3);
                success = true;
            }
            else
            {
                Console.WriteLine($"Triangle with sides {side1}, {side2}, {side3} doesn't exist!");
            }
            
            return success;
        }
    }
}
