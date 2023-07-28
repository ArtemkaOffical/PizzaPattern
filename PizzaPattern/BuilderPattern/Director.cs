using PizzaPattern.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Builder
{
    public class Director
    {
        private PizzaBuilder _pizzaBuilder = null!;

        public void SetBuilder(PizzaBuilder builder) => _pizzaBuilder = builder;
        public Pizza GetPizza() => _pizzaBuilder.GetPizza();
        public void Construct()
        {
            _pizzaBuilder.CreateEmptyPizza();
            _pizzaBuilder.BuildDough();
            _pizzaBuilder.BuildPasta();
            _pizzaBuilder.BuildIngredients();
        }

        

    }
}
