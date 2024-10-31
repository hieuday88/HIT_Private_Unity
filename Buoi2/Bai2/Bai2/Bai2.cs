

namespace Bai2;
internal class Bai2
{
    static void Main()
    {   
        double v0 = 20; 
        double theta = 30; 
        double g = 9.8; 

        double thetaRad = theta * Math.PI / 180;

        double vx = v0 * Math.Cos(thetaRad);
        double vy = v0 * Math.Sin(thetaRad);

        Console.WriteLine($"Van toc ban dau theo phuong ngang: {vx} m/s");
        Console.WriteLine($"Van toc ban dau theo phuong thang dung: {vy} m/s");

        double tMax = vy / g;
        Console.WriteLine($"Thoi gian len den diem cao nhat la: {tMax} s");
       
        double hMax = (vy * vy) / (2 * g);
        Console.WriteLine($"Chieu cao cuc dai: {hMax} m");
     
        double totalTime = 2 * tMax; 
        double d = vx * totalTime;
        Console.WriteLine($"Quang duong ngang: {d} m");
    }
}
