using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Models;

namespace Lab1.ViewModels
{
	internal class Calculator
	{
        static public string Calc(string number1, string number2, string command)
        {
            if (command == "+") return ((new RomanNumberExtend(number1) + new RomanNumberExtend(number2)).ToString());
            if (command == "-") return ((new RomanNumberExtend(number1) - new RomanNumberExtend(number2)).ToString());
            if (command == "*") return ((new RomanNumberExtend(number1) * new RomanNumberExtend(number2)).ToString());
            return (new RomanNumberExtend(number1) / new RomanNumberExtend(number2)).ToString();

        }
    }
}
