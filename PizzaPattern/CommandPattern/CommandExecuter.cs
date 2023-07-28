using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.Command
{
    public class CommandExecuter
    {
        private Stack< ICommand> _commands = new Stack<ICommand>();

        public void SetCommand(ICommand command)
        {
            _commands.Push(command);
            command.Execute();
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                ICommand command = _commands.Pop();
                command.Undo();
            }
        }
    }
}
