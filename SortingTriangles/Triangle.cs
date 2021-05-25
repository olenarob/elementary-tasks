using System;

namespace SortingTriangles
{
    public struct Triangle
    {
        string name;
        double a;
        double b;
        double c;
        double area;

        public Triangle(string name, double a, double b, double c)
        {
            this.name = name;

            this.a = a;
            this.b = b;
            this.c = c;
            
            area = CalculateArea(a,b,c);
        }

        public double Area { get => area; set => area = value; }

        public static bool IsTriangle(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }
        
        public static double CalculateArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2; // semi-perimeter

            return Math.Sqrt(s*(s-a)*(s-b)*(s-c));
        }

        public override string ToString()
        {
            return $"[Triangle {name}]: {Area} cm";
        }
    }
}
