using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Command
{
    public class CloseTerminalCommand : ICommand
    {
        private Terminal _terminal;

        public CloseTerminalCommand(Terminal terminal)
        {
            _terminal = terminal;
        }

        public void Execute()
        {
            _terminal.Close();
        }

        public void Undo()
        {
            _terminal.Close();
        }
    }
}
