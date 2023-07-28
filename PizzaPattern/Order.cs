using PizzaPattern.Builder;
using PizzaPattern.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern
{
    public class Order
    {
        public int Id { get; private set; }

        public Order()
        {
            Id = new Random().Next(int.MaxValue);
        }

        public Dictionary<PizzaIDontKnowHowNameThisClass, int> Pizzas = new Dictionary<PizzaIDontKnowHowNameThisClass, int>();

        public void RemovePizza(PizzaIDontKnowHowNameThisClass pizza)
        {
            Pizzas[pizza]--;

            if (Pizzas[pizza] <= 0)
                Pizzas.Remove(pizza);
        }
        public void AddPizza(PizzaIDontKnowHowNameThisClass pizza)
        {
            if (!Pizzas.ContainsKey(pizza))
            {
                Pizzas.Add(pizza, 1);
                return;
            }
            Pizzas[pizza]++;
        }
        public class PizzaIDontKnowHowNameThisClass
        {
            public int Id { get; private set; }
            public Pizza Pizza { get; private set; }

            public PizzaIDontKnowHowNameThisClass( Pizza pizza)
            {
                Id = new Random().Next(int.MaxValue);
                Pizza = pizza;
            }
        }
    }
}
