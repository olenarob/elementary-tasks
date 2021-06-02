using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTriangles
{
    class TriangleManager
    {
        
        public static Triangle GetTriangle(params string[] userInput)
        {
            Triangle triangle = default;

            string name = userInput[0];
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
                        ("Length of the side of the triangle cannot be less or equal zero!");
                }
            }

            if (Triangle.IsTriangle(sides[0], sides[1], sides[2]))
            {
                triangle = new Triangle(name, sides[0], sides[1], sides[2]);
            }
            else
            {
                throw new Exception
                    ($"Triangle with sides {sides[0]}, {sides[1]}, {sides[2]} doesn't exist!");
            }
            return triangle;
        }
    }
}
