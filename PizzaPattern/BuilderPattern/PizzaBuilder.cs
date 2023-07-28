using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Builder
{
    public abstract class PizzaBuilder
    {
        public string Name { get; private set; } = null!;
        protected Pizza Pizza;

        protected PizzaBuilder(string name)
        {
            Name = name;
        }

        public abstract void BuildDough();
        public abstract void BuildPasta();
        public abstract void BuildIngredients();
        public Pizza GetPizza() => Pizza;
        public void CreateEmptyPizza() => Pizza = new Pizza(Name);
        
    }
}
