using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Repository
{
    public static class Converter
    {
        public static string NumberALetters(this decimal numberAsString)
        {
            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            string dec = $" dollars and {NumberALetters(Convert.ToDouble(decimales)):0,0} cents";
            var res = NumberALetters(Convert.ToDouble(entero)) + dec;

            return res;
        }
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        private static string NumberALetters(double value)
        {
            string num2Text; value = Math.Truncate(value);
            if (value == 0) num2Text = "zero";
            else if (value == 1) num2Text = "one";
            else if (value == 2) num2Text = "two";
            else if (value == 3) num2Text = "three";
            else if (value == 4) num2Text = "four";
            else if (value == 5) num2Text = "five";
            else if (value == 6) num2Text = "six";
            else if (value == 7) num2Text = "seven";
            else if (value == 8) num2Text = "eight";
            else if (value == 9) num2Text = "nine";
            else if (value == 10) num2Text = "ten";
            else if (value == 11) num2Text = "eleven";
            else if (value == 12) num2Text = "twelve";
            else if (value == 13) num2Text = "thirteen";
            else if (value == 14) num2Text = "fourteen";
            else if (value == 15) num2Text = "fifteen";
            else if (value == 16) num2Text = "sixteen";
            else if (value == 17) num2Text = "seventeen";
            else if (value == 18) num2Text = "eighteen";
            else if (value == 19) num2Text = "nineteen";
            else if (value == 20) num2Text = "twenty";
            else if (value < 30) num2Text = "twenty" + NumberALetters(value - 20);
            else if (value == 30) num2Text = "thirty";
            else if (value == 40) num2Text = "forty";
            else if (value == 50) num2Text = "fifty";
            else if (value == 60) num2Text = "sixty";
            else if (value == 70) num2Text = "seventy";
            else if (value == 80) num2Text = "eighty";
            else if (value == 90) num2Text = "ninety";
            else if (value < 100) num2Text = NumberALetters(Math.Truncate(value / 10) * 10) + " and " + NumberALetters(value % 10);
            //else if (value == 100) num2Text = "one hundred";
            else if (value < 200) num2Text = "one hundred " + NumberALetters(value - 100);
            else if ((value == 100) || (value == 200) || (value == 300) || (value == 400) || (value == 500) || (value == 600) || (value == 700) || (value == 800) || (value == 900)) num2Text = NumberALetters(Math.Truncate(value / 100)) + " hundred";
            //else if (value == 500) num2Text = "QUINIENTOS";
            //else if (value == 700) num2Text = "SETECIENTOS";
            //else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumberALetters(Math.Truncate(value / 100) * 100) + " " + NumberALetters(value % 100);
            else if (value == 1000) num2Text = "one thousand";
            else if (value < 2000) num2Text = "one thousand " + NumberALetters(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumberALetters(Math.Truncate(value / 1000)) + " thousand";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumberALetters(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "one million";
            }
            else if (value < 2000000)
            {
                num2Text = "one million" + NumberALetters(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumberALetters(Math.Truncate(value / 1000000)) + " millions";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumberALetters(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "one billion";
            else if (value < 2000000000000) num2Text = "one billion " + NumberALetters(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumberALetters(Math.Truncate(value / 1000000000000)) + " billions";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumberALetters(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        }
    }
}
