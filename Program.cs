using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_02
{
    public interface IShape
    {
        double GetPerimeter();
    }
    public class Parallelogram : IShape
    {
        public double A { get; set; } // Основа паралелограма
        public double H { get; set; } // Висота паралелограма
        public double Alfa { get; set; } // Кут між основою і боковою стороною в радіанах

        public double GetPerimeter()
        {
            double X = H / Math.Sin(Alfa);
            return 2 * X + 2 * A;
        }
    }
    public class Trapezium : IShape
    {
        public double C { get; set; } // Перша основа трапеції
        public double D { get; set; } // Друга основа трапеції
        public double H { get; set; } // Висота трапеції

        public double GetPerimeter()
        {
            double X = Math.Sqrt(Math.Pow(0.5 * (C - D), 2) + Math.Pow(H, 2));
            return 2 * X + D + C;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Введення даних для паралелограма
                Console.WriteLine("Введiть основу паралелограма (A): ");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть висоту паралелограма (H): ");
                double h = double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть кут мiж основою i боковою стороною паралелограма (в градусах): ");
                double alfa = double.Parse(Console.ReadLine()) * (Math.PI / 180); // Кут в радіанах

                Parallelogram parallelogram = new Parallelogram
                {
                    A = a,
                    H = h,
                    Alfa = alfa
                };

                double parallelogramPerimeter = parallelogram.GetPerimeter();
                Console.WriteLine($"Периметр паралелограма: {parallelogramPerimeter}");

                // Введення даних для трапеції
                Console.WriteLine("Введiть першу основу трапецiї (C): ");
                double c = double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть першу основу трапецiї (D): ");
                double d = double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть першу основу трапецiї (H): ");
                double ht = double.Parse(Console.ReadLine());

                Trapezium trapezium = new Trapezium
                {
                    C = c,
                    D = d,
                    H = ht
                };

                double trapeziumPerimeter = trapezium.GetPerimeter();
                Console.WriteLine($"Периметр трапецiї: {trapeziumPerimeter}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            // Додайте цей рядок, щоб програма чекала натискання клавіші перед закриттям
            Console.WriteLine("Натиснiть будь-яку клавiшу для завершення...");
            Console.ReadKey();
        }
    }
}
