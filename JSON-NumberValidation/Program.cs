﻿using System;

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

        static bool IsInRange(char checkRange, char leftLimit, char rightLimit)
        {
            return checkRange >= leftLimit && checkRange <= rightLimit;
        }

        static bool NumberIsNegative(string jsonNumber)
        {
            return jsonNumber.Length > 1 && jsonNumber[0] == '-';
        }

        static bool IsNumber(string number, int index)
        {
            int count = 0;
            for (int i = index; i < number.Length; i++)
            {
                if (!IsInRange(number[i], '1', '9'))
                {
                    if (IsFractional(number, i) && count == 0)
                    {
                        count++;
                        continue;
                    }

                    if (IsExponent(number, i) && count == 1)
                    {
                        continue;
                    }

                    if (IsArithmetic(number, i) && count == 1)
                    {
                        continue;
                    }
                        
                    return false;
                }
            }

            return true;
        }

        static bool IsArithmetic(string number, int i)
        {
            return number.Length > 1 && "+-".Contains(number[i]);
        }

        static bool IsFractional(string number, int index)
        {
            if (index == number.Length -1)
            {
                return false;
            }

            return number[index] == '.' && IsInRange(number[index + 1], '1', '9');
        }

        static bool IsExponent(string compare, int index)
        {
            return index < compare.Length - 1 && char.ToLower(compare[index]) == 'e';
        }
    }
}
