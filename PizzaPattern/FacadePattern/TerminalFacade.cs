using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern.FacadePattern
{
    public class TerminalFacade
    {
        private Terminal _terminal;

        public TerminalFacade(Terminal terminal)
        {
            _terminal = terminal;
        }

        public void Start()
        {
            _terminal.Init();
            _terminal.Start();
        }

    }
}
