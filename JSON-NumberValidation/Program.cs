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
                    if (jsonNumber[1] >= '1')
                    {
                    }
                    else if (jsonNumber[1] <= '9')
                    {
                    }
                    else
                    {
                    return false;
                    }

                    return true;
                }

            return false;
        }

        static bool IsNumber(string number, int index)
        {
            for (int i = index; i < number.Length; i++)
            {
                if (number[i] < '1')
                {
                    return false;
                }
                else if (number[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
