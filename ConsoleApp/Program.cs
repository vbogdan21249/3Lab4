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
            double AnonymousTest = CharAmount("uniusm douamu");
            Console.WriteLine(AnonymousTest + " identical symbols matching the starting symbol");

            // lambda
            CharAmount = (input) =>
            {
                double counts;
                counts = Regex.Matches(input, $"{input[0]}").Count;
                return counts;
            };

            double LambdaTest = CharAmount("niusm douamn");
            Console.WriteLine(LambdaTest + " identical symbols matching the starting symbol");

           
            Stack stack = new Stack(2);
            stack.StackEvent += StackClearingHandler;

            stack.Push(5);
            stack.Push(2);
            stack.Push(8); // Stack Overflow
        }

        public delegate double CharAmountDelegate(string input);
        public static double CharAmountMethod(string input)
        {
            double counts = Regex.Matches(input, $"{input[0]}").Count;
            return counts;
        }
        public static void StackClearingHandler(object sender, StackEventArgs eventArgs)
        {
            Console.WriteLine($"Stack event: {eventArgs.EventMessage}");
        }

    }
}