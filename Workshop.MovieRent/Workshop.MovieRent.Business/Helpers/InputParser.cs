﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.MovieRent.Business.Helpers
{
    public class InputParser
    {
        private static readonly List<string> _validConfirmInput = new List<string> {"Y", "y", "Yes", "yes", "1", "True"  };
        private static readonly List<string> _validDeclineInput = new List<string> { "N", "n", "no", "NO", "0", "False"};

        public static int ToInteger(int min, int max)
        {
            int parsedNumber = 0;
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    parsedNumber = int.Parse(Console.ReadLine());
                    if (!(parsedNumber >= min && parsedNumber <= max))
                    {
                        throw new Exception($"Please select from given input range from {min} to {max}.");
                    }
                    isValid = !isValid;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter argument");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not valid input");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too low");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return parsedNumber;
        }

        public static bool ToConfirm()
        {
            bool isValidInput;
            while (true)
            {
                var value = Console.ReadLine();
                if (_validConfirmInput.Contains(value))
                {
                    isValidInput = true;
                    break;
                }
                else if (_validDeclineInput.Contains(value))
                {
                    isValidInput = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid input");
                    Console.WriteLine($"Valid inputs {string.Join(", ",_validConfirmInput).ToArray()} {string.Join(", ", _validDeclineInput).ToArray()}");
                }
            }
            return isValidInput;
        }

        public static DateTime ToDateTime()
        {
            while (true)
            {
                Console.WriteLine("Enter year");
                int year = ToInteger(1900, DateTime.Now.Year - 14);
                Console.WriteLine("Enter Month");
                int month = ToInteger(1, 12);
                Console.WriteLine("Enter date");
                int day = ToInteger(1, DateTime.DaysInMonth(year, month));

                try
                {

                    var dob = new DateTime(year, month, day);
                    return dob;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not valid input");
                }
            }
           
        }
    }
}