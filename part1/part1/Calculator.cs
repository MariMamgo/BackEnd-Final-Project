using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    // კალკულატორის შესაქმნელად დელეგატების გამოყენებას ვაპირებ. კალკულატორის კლასში ოთხივე ოპერაციისათვის ფუნქციას შევქმნი და მოგვიანებით
    // ეს ფუნქცია მიენიჭება დელეგატს მომხმარებლის არჩევნიდან გამომდინარე.

    public delegate void CalculatorDelegate(float x, float y);

    internal class Calculator
    {
        public void Sum(float a, float b)
        {
            Console.WriteLine($"{a} + {b} = {a + b}");
        }
        public void Sub(float a, float b)
        {
            Console.WriteLine($"{a} - {b} = {a - b}");
        }
        public void Mul(float a, float b)
        {
            Console.WriteLine($"{a} * {b} = {a * b}");
        }
        public void Div(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            } 
            Console.WriteLine($"{a} / {b} = {a / b}");
        }

    }
}
