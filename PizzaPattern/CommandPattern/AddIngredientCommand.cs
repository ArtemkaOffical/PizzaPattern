using PizzaPattern.Builder;
using PizzaPattern.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Command
{
    public class AddIngredientCommand : ICommand
    {
        private Pizza _pizza;
        private Ingredient _ingredient;

        public AddIngredientCommand(Pizza pizza, Ingredient ingredient)
        {
            _pizza = pizza;
            _ingredient = ingredient;
        }

        public void Execute()
        {
            _pizza.AddIngredient(_ingredient);
        }

        public void Undo()
        {
            _pizza.RemoveIngredient(_ingredient);
        }
    }
}
