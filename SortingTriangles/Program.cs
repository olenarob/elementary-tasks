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

            Console.WriteLine("Please enter the name and sides of the triangle through the comma:");
            string[] userInput = Console.ReadLine().Split(',');

            try
            {
                string name = userInput[0].Trim();
                if (name.Equals(""))
                {
                    throw new FormatException("Name of the triangle cannot be empty!");
                }
                
                double[] sides = new double[3];

                for (int i = 0; i < 3; i++)
                {
                    sides[i] = double.Parse(userInput[i + 1]);
                    
                    if (double.IsNegative(sides[i]))
                    {
                        throw new OverflowException
                            ("Length of the side of the triangle cannot be less zero!");
                    }
                }

                if (Triangle.IsTriangle(sides[0], sides[1], sides[2]))
                {
                    triangle = new Triangle(name, sides[0], sides[1], sides[2]);
                    success = true;
                }
                else
                {
                    throw new Exception
                        ($"Triangle with sides {sides[0]}, {sides[1]}, {sides[2]} doesn't exist!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: <name>,<length of side>,<length of side>,<length of side>");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
