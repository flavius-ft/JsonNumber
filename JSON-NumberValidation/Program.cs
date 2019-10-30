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
            int fractionalCount = 0;
            int exponentCount = 0;
            int arithmeticCount = 0;
            for (int i = index; i < number.Length; i++)
            {
                if (!IsInRange(number[i], '1', '9'))
                {
                    if (IsFractional(number, i) && Compare(exponentCount, 0, fractionalCount, 0))
                    {
                        fractionalCount++;
                        continue;
                    }

                    if (IsExponent(number, i) && exponentCount == 0)
                    {
                        exponentCount++;
                        continue;
                    }

                    if (IsArithmetic(number, i) && Compare(fractionalCount, 1,arithmeticCount, 0))
                    {
                        arithmeticCount++;
                        continue;
                    }
                        
                    return false;
                }
            }

            return true;
        }

        static bool Compare(int count1, int i, int count2, int j)
        {
            return count1 == i && count2 == j;
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
