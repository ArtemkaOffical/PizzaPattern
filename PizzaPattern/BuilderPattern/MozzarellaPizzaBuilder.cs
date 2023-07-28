using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaPattern.Ingredients;

namespace PizzaPattern.Builder
{
    public class MozzarellaPizzaBuilder : PizzaBuilder
    {
        public MozzarellaPizzaBuilder(string name) : base(name)
        {
        }

        public override void BuildDough()
        {
            Pizza.SetDough(new Dough("Dough", Dough.Type.Thick));
            
        }

        public override void BuildIngredients()
        {
            Pizza.SetIngredients(new Dictionary<Ingredient, int>()
            {
                [new Cheese("Cheder")] = 3
            });
            Pizza.Ingredients.Add(Pizza.Dough, 1);

            Pizza.Ingredients.Add(Pizza.Pasta, 1);
        }

        public override void BuildPasta()
        {
            Pizza.SetPasta(new Pasta("Pasta", Pasta.Type.Tomato));

        }
    }
}
