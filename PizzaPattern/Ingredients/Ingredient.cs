using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPattern.Ingredients
{
    public abstract class Ingredient
    {
        public string Name { get; private set; }

        public Ingredient(string name)
        {
            Name = name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public override bool Equals(object? obj)
        {
            return obj is Ingredient ingredient  && Name == ingredient.Name;
        }
        protected T GetSomeValueInterface<T>(string s) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), s);
        }

        public virtual void Change()
        {
            Console.WriteLine("this cant be changed");
        }
    }
}
