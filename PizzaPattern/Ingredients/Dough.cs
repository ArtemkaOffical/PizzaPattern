using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Ingredients
{
    public class Dough : Ingredient
    {
        public Type TypeDough { get; private set; }

        public Dough(string name, Type typeDough) : base(name)
        {
            TypeDough = typeDough;
        }

        public override void Change()
        {
            Console.WriteLine("input Thin or Thick for dough");
            string input = Console.ReadLine();
            Type value =  GetSomeValueInterface<Type>(input);
            TypeDough = value;
            Console.WriteLine("Dough type = " + value);
        }

        public enum Type
        {
            Thin,
            Thick,
        }

    }
}
