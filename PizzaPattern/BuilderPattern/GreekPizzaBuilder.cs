using PizzaPattern.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Builder
{
    public class GreekPizzaBuilder : PizzaBuilder
    {
        public GreekPizzaBuilder(string name) : base(name)
        {
        }

        public override void BuildDough()
        {
            Pizza.SetDough(new Dough("Dough", Dough.Type.Thick));
        }

        public override void BuildIngredients()
        {
            Pizza.SetIngredients(new Dictionary<Ingredient, int>());
        }

        public override void BuildPasta()
        {
            Pizza.SetPasta(new Pasta("Pasta", Pasta.Type.Tomato));
        }
    }
}
