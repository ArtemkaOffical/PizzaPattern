﻿using PizzaPattern.Builder;
using PizzaPattern.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.CommandPattern
{
    public class AddPizzaCommand : ICommand
    {

        private Order _order;
        private Order.PizzaIDontKnowHowNameThisClass _pizza;

        public AddPizzaCommand(Order order, Order.PizzaIDontKnowHowNameThisClass pizza)
        {
            _order = order;
            _pizza = pizza;
        }

        public void Execute()
        {
            _order.AddPizza(_pizza);
        }

        public void Undo()
        {
            _order.RemovePizza(_pizza);
        }
    }
}
