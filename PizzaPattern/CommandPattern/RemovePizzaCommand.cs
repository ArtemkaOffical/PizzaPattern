using PizzaPattern.Builder;
using PizzaPattern.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.CommandPattern
{
    public class RemovePizzaCommand : ICommand
    {

        private Order _order;
        private Order.PizzaIDontKnowHowNameThisClass _pizza;

        public RemovePizzaCommand(Order order, Order.PizzaIDontKnowHowNameThisClass pizza)
        {
            _order = order;
            _pizza = pizza;
        }

        public void Execute()
        {
            _order.RemovePizza(_pizza);
        }

        public void Undo()
        {
            _order.AddPizza(_pizza);
        }
    
    }
}
