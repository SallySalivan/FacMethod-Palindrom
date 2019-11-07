using System;

namespace TestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Радиус круга : ");
            string variable = Console.ReadLine();
            Shaper sh = new Circle(variable);
            sh.Remove();

            Console.Write("Высота и ширина прямоугольника : ");
            variable = Console.ReadLine();
            Shaper sh2 = new Rectangle(variable);
            sh2.Remove();

            Console.Write("Введите слово для палиндром :");   
            Palindrom.Reduction(Console.ReadLine());
            
        }
    }

    #region Question 3: OOP Design Fundamentals
    abstract class Shaper
    {
        abstract public Formula Remove();
    }

    class Circle : Shaper
    {
        private string variable { get; set; }
        public Circle(string Variable )
        {
            variable = Variable;
        }

        public override Formula Remove()
        {
            return new CircleFormula(variable);
        }
    }

    class Rectangle : Shaper
    {
        private string variable { get; set; }
        public Rectangle(string Variable)
        {
            variable = Variable;
        }

        public override Formula Remove()
        {
            return new RectangleFormula(variable);
        }
    }

    abstract class Formula
    {
        public abstract double Area();
        public abstract double Perimete();


    }

    class CircleFormula : Formula
    {
        private int variable { get; set; }
        public CircleFormula(string Variable)
        {
            variable = Int32.Parse(Variable);
            var area = Area();
            var perimete = Perimete();
            Console.WriteLine($"area: {area} , perimete: {perimete} ");
        }

        public override double Area ()
        {
            var area = variable * variable * 3.14;
            return area;
        }

        public override double Perimete()
        {
            var perimete = 2 * 3.14 * variable;
            return perimete;
        }
    }

    class RectangleFormula : Formula
    {
        private int length { get; set; }
        private int width { get; set; }

        public RectangleFormula(string Variable)
        {
            var split = Variable.Split('x');
            length = Int32.Parse(split[0]);
            width = Int32.Parse(split[1]);
            var area = Area();
            var perimete = Perimete();
            Console.WriteLine($"area:{area},perimete:{perimete}");
        }

        public override double Area()
        {
            var area = length * width;
            return area;
        }

        public override double Perimete()
        {
            var perimete = (length + width) * 2 ;
            return perimete;
        }
    }
    #endregion 
    
    class Palindrom
    {
        public static void Reduction(string Palindrom)
        {
            int Length = Palindrom.Length;
            var result = Palindrom;

            for (int i = 0; i  < Palindrom.Length - 1;)
            {
                if (Palindrom[i] != Palindrom[Length - 1])
                {
                    Palindrom = Palindrom.Insert(Length, Palindrom[i].ToString());
                    Length = Palindrom.Length;
                    i = 0;
                    continue;
                }
                i++;
                Length--;
            }

            Console.WriteLine(Palindrom);
        }
    }

}
