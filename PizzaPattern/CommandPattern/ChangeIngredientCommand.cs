using PizzaPattern.Builder;
using PizzaPattern.Command;
using PizzaPattern.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.CommandPattern
{
    public class ChangeIngredientCommand : ICommand
    {
        private Ingredient _ingredient;
        private Pizza _pizza;

        public ChangeIngredientCommand(Ingredient ingredient, Pizza pizza)
        {
            _ingredient = ingredient;
            _pizza = pizza;
        }

        public void Execute()
        {
            _pizza.ChangeIngredient(_ingredient);
        }

        public void Undo()
        {
            _pizza.ChangeIngredient(_ingredient);
        }
    }
}
