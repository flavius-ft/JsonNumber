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
            if (NumberIsNegative(jsonNumber))
            {
                if (!IsNumber(jsonNumber, 1))
                {
                    return false;
                }
            }
            else
            {
                if (!IsNumber(jsonNumber, 0))
                {
                    return false;
                }
            }

            return true;
        }

        static bool NumberIsNegative(string jsonNumber)
        {
                if (jsonNumber[0] == '-')
                {
                return true;
                }

                if (Int32.TryParse(Convert.ToString(jsonNumber[1]), out int number))
                {
            }
            else
            {
                return false;
            }

            return false;
        }

        static bool IsNumber(string number, int index)
        {
            for (int i = index; i < number.Length; i++)
            {
                if (!Int32.TryParse(Convert.ToString(number[i]), out int validNumber))
                {
                    return false;
                }

                if (number[index] == '0')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
