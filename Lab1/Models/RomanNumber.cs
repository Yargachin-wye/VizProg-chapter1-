using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        public int romannumber;
        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n == 0 || n > 3999) throw new RomanNumberException();
            romannumber = (int)n;
        }

        //Перевод одного символа из римской записи в дестяичную
        public static int CharToInt(char ch)
        {
            if (ch == 'I') return 1;

            if (ch == 'V') return 5;

            if (ch == 'X') return 10;

            if (ch == 'L') return 50;

            if (ch == 'C') return 100;

            if (ch == 'D') return 500;

            if (ch == 'M') return 1000;

            return 0;
        }

        //Перевод всего римского числа в десятичную
        public static int RomanToInt(string s)
        {
            int res = 0;
            for (int i = 0; i < (s.Length - 1); ++i)
            {
                if (CharToInt(s[i]) < CharToInt(s[i + 1]))
                    res -= CharToInt(s[i]);
                else
                    res += CharToInt(s[i]);
            }
            res += CharToInt(s[s.Length - 1]);
            return res;
        }

        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new RomanNumberException();
            int num = n1.romannumber + n2.romannumber;
            return new RomanNumber((ushort)num);
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new RomanNumberException();
            int num = n1.romannumber - n2.romannumber;
            if (num <= 0) throw new RomanNumberException();
            return new RomanNumber((ushort)num);
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new RomanNumberException();
            int num = n1.romannumber * n2.romannumber;
            return new RomanNumber((ushort)num);

        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new RomanNumberException();
            int num = n1.romannumber / n2.romannumber;
            if (num == 0) throw new RomanNumberException();
            return new RomanNumber((ushort)num);
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string result = "";
            int number = romannumber;
            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result += numerals[i];
                }
            }
            return result;
        }
        public object Clone()
        {
            return new RomanNumber((ushort)romannumber);
        }

        public int CompareTo(object? o)
        {
            if (o is RomanNumber num) return romannumber - RomanNumber.RomanToInt(num.ToString());
            else throw new ArgumentException("Некорректное значение параметра");
        }
    }
}
