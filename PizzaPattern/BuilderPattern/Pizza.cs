using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaPattern.Command;
using PizzaPattern.Ingredients;

namespace PizzaPattern.Builder
{
    public class Pizza
    {
        public string Name { get; private set; }

        public Dictionary<Ingredient, int> Ingredients { get; private set; } = null!;

        public Dough Dough { get; private set; } = null!;
        public Pasta Pasta { get; private set; } = null!;


        public Pizza(string name)
        {
            Name = name;
        }
        public void SetDough(Dough dough) { Dough = dough; }
        public void SetPasta(Pasta pasta) { Pasta = pasta; }
        public void SetIngredients(Dictionary<Ingredient, int> ingredients) { Ingredients = ingredients; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.AppendLine(":");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                int num = i + 1;
                sb.Append(num);
                sb.Append(". ");
                sb.AppendLine(Ingredients.ElementAt(i).Key.Name);
            }
            return sb.ToString();
        }

        public void ChangeIngredient(Ingredient ingredient)
        {
            ingredient.Change();
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients[ingredient]--;

            if (Ingredients[ingredient] <= 0)
                Ingredients.Remove(ingredient);
        }
        public void AddIngredient(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient))
            {
                Ingredients.Add(ingredient, 1);
                return;
            }

            Ingredients[ingredient]++;
        }
    }
}
