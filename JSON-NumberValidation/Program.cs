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
            return IsNumber(jsonNumber, NumberIsNegative(jsonNumber) ? 1 : 0);
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
            bool fractionalSimbol = true;
            bool exponentSimbol = true;
            bool arithmeticSimbol = true;

            for (int i = index; i < number.Length; i++)
            {
                if (!IsInRange(number[i], '1', '9'))
                {
                    if (SubunitNumber(number, i))
                    {
                        continue;
                    }

                    if (IsFractional(number, i, exponentSimbol, fractionalSimbol))
                    {
                        fractionalSimbol = false;
                        continue;
                    }

                    if (IsExponent(number, i, exponentSimbol))
                    {
                        exponentSimbol = false;
                        continue;
                    }

                    if (IsArithmetic(number, i, fractionalSimbol, arithmeticSimbol))
                    {
                        arithmeticSimbol = false;
                        continue;
                    }
                        
                    return false;
                }
            }

            return true;
        }

        static bool IsArithmetic(string number , int i , bool fractional, bool arithmetic)
        {
            return !fractional && arithmetic && CheckArithmetic(number, i);
        }

        static bool IsExponent(string number, int i, bool exponent)
        {
            return exponent && CheckExponent(number, i);
        }

        static bool IsFractional(string number, int i, bool exponent, bool fractional)
        {
            return exponent && fractional && CheckFractional(number, i);
        }

        static bool SubunitNumber(string number, int i)
        {
            return number[i] == '0' && number[i + 1] == '.';
        }

        static bool CheckArithmetic(string number, int i)
        {
            return number.Length > 1 && "+-".Contains(number[i]);
        }

        static bool CheckFractional(string number, int index)
        {
            if (index == number.Length -1)
            {
                return false;
            }

            return number[index] == '.' && IsInRange(number[index + 1], '1', '9');
        }

        static bool CheckExponent(string compare, int index)
        {
            return index < compare.Length - 1 && char.ToLower(compare[index]) == 'e';
        }
    }
}
