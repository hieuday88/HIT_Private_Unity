namespace Bai1
{
    internal class Program
    {
        static void DrawRec()
        {
            int l, w;
            do
            {
                l = int.Parse(Console.ReadLine());
                w = int.Parse(Console.ReadLine());
            }
            while (l < 2 || w < 2);
            
            string topAndBot = new string('*', l);
            string middle = '*' + new string(' ', l - 2) + '*';

            Console.WriteLine(topAndBot);
            for (int i = 0; i < w - 2; i++)
                Console.WriteLine(middle);
            Console.WriteLine(topAndBot);
        }

        static void DrawTri()
        {
            int l = int.Parse(Console.ReadLine());
            int spaceBetween = -1;
            int spaceBefore = l - 2;
            Console.WriteLine(new string(' ', l - 1) + "*");

            for (int i = 0; i < l - 2; i++)
            {
                Console.WriteLine(new string(' ', spaceBefore--) + '*' + new string(' ', spaceBetween += 2) + '*');
            }

            Console.WriteLine(new string('*', spaceBetween + 4));
        }
        static void Main(string[] args)
        {
            DrawRec();
            DrawTri();
        }
    }
}
