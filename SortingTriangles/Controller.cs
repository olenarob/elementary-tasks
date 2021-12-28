using System;
using System.Collections.Generic;

namespace SortingTriangles
{
    public class Controller
    {
        private readonly List<Triangle> triangles;
        private readonly View view;

        public Controller(List<Triangle> triangles, View view)
        {
            this.triangles = triangles;
            this.view = view;
        }
        public void Run()
        {
            string userAnswer;
            do
            {
                if (TryGetTriangle(out Triangle triangle))
                {
                    triangles.Add(triangle);
                }

                userAnswer = view.GetUserMessage("Try again? (y/yes): ");
            }
            while (userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase));

            triangles.Sort(Triangle.CompareAreaDesc);

            DisplayTrianglesList();
        }
        private bool TryGetTriangle(out Triangle triangle)
        {
            triangle = default;
            bool success = false;

            string[] userInput = view.GetArrayOfUserMessage
                ("\nPlease enter the name and sides of the triangle through the comma:");
            
            try
            {
                string name = userInput[0];
                if (string.IsNullOrWhiteSpace(name))
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
                            ("Length of the side of the triangle cannot be less or equal zero!");
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
                view.DisplayMessage("Usage: <name>, <length of side>, <length of side>, <length of side>");
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
            }

            return success;
        }
        
        private void DisplayTrianglesList()
        {
            view.DisplayMessage("\n===============Triangles list:===============");
            
            for (int i = 0; i < triangles.Count; i++)
            {
                view.DisplayMessage($"{i + 1}.{triangles[i]}");
            }
        }
    }
}

