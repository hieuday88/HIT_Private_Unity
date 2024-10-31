using System;


namespace Bai1
{
    internal class Bai1
    {
        static double CalculateDistance(double A, double b, double t)
        {
            double T = 2.0 / b; 
            int vongHoanThanh = (int)(t / T);
            double tConLai = t % T;

            return Math.Round(vongHoanThanh * 4 * A + 2 * A * Math.Abs(Math.Cos(b * Math.PI * tConLai + Math.PI / 2)), 3);
        }

        static void Main(String [] args)
        {
            //Bai 1 a
            Console.WriteLine($"Quang duong vat A di duoc trong 2.125 giay la: {CalculateDistance(9, 5, 2.125)}cm ");

            //Bai 1 b
            Console.WriteLine("Phuong trinh dao dong B: x(t)= Acos(bπt+π/2) (cm)");
            Console.Write("Nhap bien do cua vat dao dong B: ");
            double A = double.Parse(Console.ReadLine());
            Console.Write("Nhap omega cua vat dao dong B = ?π: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Nhap thoi gian dao dong cua vat: ");
            double t = double.Parse(Console.ReadLine());

            Console.WriteLine($"Quang Duong vat B di chuyen duoc sau {t}s la: {CalculateDistance(A, b, t)}cm");
        }

    }
}
