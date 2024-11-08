namespace Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(IsValid(input) ? "Yes" : "No");
        }

        static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {               
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }               
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '(')) return false;
                else if (c == ']' && (stack.Count == 0 || stack.Pop() != '[')) return false;
                else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{')) return false;
            }
           
            return stack.Count == 0;
        }
    }
}
    

