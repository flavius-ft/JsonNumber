using System;

namespace JSON_NumberValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string jsonNumber = Console.ReadLine();

            if (GetJsonNumber(jsonNumber))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            Console.Read();
        }

        public static bool GetJsonNumber(string jsonNumber)
        {
            if (!IsNumber(jsonNumber))
            {
                return false;
            }

            return true;
        }

        static bool IsNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!Int32.TryParse(Convert.ToString(number[i]), out int validNumber))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
