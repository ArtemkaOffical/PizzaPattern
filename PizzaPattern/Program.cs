using PizzaPattern.Ingredients;
using PizzaPattern.Builder;
using PizzaPattern.Command;
using PizzaPattern.FacadePattern;

namespace PizzaPattern
{
    internal class Program
    {
        private static CommandExecuter _commandExecuter = new CommandExecuter();
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal(_commandExecuter);
            TerminalFacade facade = new TerminalFacade(terminal);
            facade.Start();
        }

        
    }
}