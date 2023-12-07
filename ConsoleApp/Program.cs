using System.Text.RegularExpressions;
namespace console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // normal method
            CharAmountDelegate CharAmount = CharAmountMethod;
            double NormalTest = CharAmount("uniusm douam");
            Console.WriteLine(NormalTest + " identical symbols matching the starting symbol");

            // anonymous
            CharAmount = delegate (string input)
            {
                double counts = Regex.Matches(input, $"{input[0]}").Count;
                return counts;
            };
            double AnonymousNest = CharAmount("uniusm douam");
            Console.WriteLine(AnonymousNest + " identical symbols matching the starting symbol");

            // lambda
            CharAmount = (input) =>
            {
                double counts;
                counts = Regex.Matches(input, $"{input[0]}").Count;
                return counts;
            };

            double LambdaTest = CharAmount("uniusm douam");
            Console.WriteLine(LambdaTest + " identical symbols matching the starting symbol");

            Stack stack = new Stack();
            stack.StackEvent += StackClearingHandler;

            stack.Push(5);
            stack.Push(2);
            stack.Pop();
            stack.Clear();

        }

        public delegate double CharAmountDelegate(string input);
        public static double CharAmountMethod(string input)
        {
            double counts = Regex.Matches(input, $"{input[0]}").Count;
            return counts;
        }
        public static void StackClearingHandler(object sender, StackEventArgs eventArgs)
        {
            Console.WriteLine($"Stack event:{eventArgs.EventMessage}");
        }



    }
}