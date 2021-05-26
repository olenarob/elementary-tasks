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
                if (TryGetTriangle(out Triangle triangle))
                {
                    triangles.Add(triangle);
                }
                Console.Write("Try again? ");
                userAnswer = Console.ReadLine();
            }
            while (IfRepeat(userAnswer));

            triangles.Sort(Triangle.CompareAreaDesc);

            DisplayTrianglesList(triangles);
        }

        private static bool IfRepeat(string userAnswer)
        {
            return userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool TryGetTriangle(out Triangle triangle)
        {
            triangle = default;
            bool success = false;
            
            Console.Write("Please enter name of triangle: ");
            string name = Console.ReadLine();
            
            double a = Argument.GetValueFromUser($" first side of triangle", double.Epsilon, double.MaxValue);
            double b = Argument.GetValueFromUser($"second side of triangle", double.Epsilon, double.MaxValue);
            double c = Argument.GetValueFromUser($" third side of triangle", double.Epsilon, double.MaxValue);
            
            if (Triangle.IsTriangle(a, b, c))
            {
                triangle = new Triangle(name, a, b, c);
                success = true;
            }
            else
            {
                Console.WriteLine($"Triangle with sides {a}, {b}, {c} doesn't exist!");
            }
            
            return success;
        }

        private static void DisplayTrianglesList(List<Triangle> triangles)
        {
            Console.WriteLine(ListHeader);

            for (int i = 0; i < triangles.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{triangles[i]}");
            }
        }
    }
}
