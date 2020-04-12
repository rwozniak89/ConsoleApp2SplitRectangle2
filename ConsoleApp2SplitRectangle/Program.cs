using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2SplitRectangle
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj liczbę podziałów: (i wciśniej  Enter, jak pusto lub błąd to przypisze 2)");
            int vv1 = 2;
            
            string svv1 = Console.ReadLine();
            try { vv1 = int.Parse(svv1); }
            catch (Exception) {Console.WriteLine("podano liczbę niecałkowitą, dlatego ustalono wartość na 2");}

            Point[,] T = new Point[2, 2];
            int vxa = 1;
            int vxb = 10;
            int vya = 1;
            int vyb = 10;

            Console.WriteLine("podaj współrzędną X pkt A: (jak pusto lub błąd przypisze 1)");
            string xa= Console.ReadLine();
            try { vxa = int.Parse(xa); }
            catch (Exception) { Console.WriteLine("podano liczbę niecałkowitą, dlatego ustalono wartość na 1"); }
            
            Console.WriteLine("podaj współrzędną Y pkt A: (jak pusto lub błąd przypisze 1)");
            string ya = Console.ReadLine();
            try { vya = int.Parse(ya); }
            catch (Exception) { Console.WriteLine("podano liczbę niecałkowitą, dlatego ustalono wartość na 1"); }

            Console.WriteLine("podaj współrzędną X pkt B: (jak pusto lub błąd przypisze 10)");
            string xb = Console.ReadLine();
            try { vxb = int.Parse(xb); }
            catch (Exception) { Console.WriteLine("podano liczbę niecałkowitą, dlatego ustalono wartość na 10"); }

            Console.WriteLine("podaj współrzędną Y pkt B: (jak pusto lub błąd przypisze 10)");
            string yb = Console.ReadLine();
            try { vyb = int.Parse(yb); }
            catch (Exception) { Console.WriteLine("podano liczbę niecałkowitą, dlatego ustalono wartość na 10"); }

            T[0, 0] = new Point(vxa, vya);
            //T[0, 1] = new Point(10, 1);
            //T[1, 0] = new Point(1, 10);
            T[1, 1] = new Point(vxb, vyb);
            T[0, 1] = new Point(T[1, 1].X, T[0, 0].Y);
            T[1, 0] = new Point(T[0, 0].X, T[1, 1].Y);

            Console.WriteLine("Tablica wejściowa");
            Print2DArray<Point>(T);
            Console.WriteLine();

            //int v1 = 2; // liczba podziału

            int v1 = vv1;
            int v2 = (int)Math.Pow(4, v1); // pow(4, v1); // liczba nowych podprostokątów
            double v5s = Math.Sqrt((double)v2);
            double v3d = v5s + 1;
            int v3 = (int)v3d;
            int v4 = v3 *v3;

            Console.WriteLine(
                $"Liszba podziału v1={v1},\n" +
                $"liczba nowych podprosokątów,v2={v2},\n" +
                $"liczba podziału odcinka boku v5s={v5s},\n" +
                $"liczba wierzchołków w odcinku v3={v3},\n" +
                $"liczba wszystkich nowych wierzchołków v4={v4}");
            Console.WriteLine();
            Point[,] t = new Point[v3, v3];

            for(int x=0; x<v3; x++)
            {
                for (int y = 0; y < v3; y++)
                {
                    t[x, y] = new Point((((T[1, 1].X - T[0, 0].X) / v5s) * x+1), (((T[1, 1].Y - T[0, 0].Y) / v5s) * y + 1));
                }
            }
            Console.WriteLine("Tablica wyjściowa");
            Print2DArray<Point>(t);

            Console.ReadKey();
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x, double y) { X = x; Y = y;}
        }
        
        public static void Print2DArray<T>(T[,] matrix) where T : Point
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("p({0},{1}) X:{2,5:N2} Y:{3,5:N2}\t",i,j, matrix[i, j].X, matrix[i, j].Y);
                }
                Console.WriteLine();
            }
        }

        //public static Func<int, int, int> pow = (x, y) =>
        //{
        //    int result = 1;
        //    for (int i = 0; i < y; i++)
        //    {
        //        result *= x;
        //    }
        //    return result;
        //};
    }
}
