using System;

namespace SortingTriangles
{
    public struct Triangle
    {
        public Triangle(string name, double a, double b, double c)
        {
            Name = name;
            Area = CalculateArea(a,b,c);
        }

        public string Name { get; }
        public double Area { get; }

        public override string ToString() => $"[Triangle {Name}]: {Area:N} cm^2";

        public static bool IsTriangle(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }
        
        public static double CalculateArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2; // semi-perimeter

            return Math.Sqrt(s*(s-a)*(s-b)*(s-c)); // Heron's formula
        }
        
        public static int CompareAreaDesc(Triangle triangle1, Triangle triangle2)
        {
            return triangle2.Area.CompareTo(triangle1.Area);
        }
    }
}
