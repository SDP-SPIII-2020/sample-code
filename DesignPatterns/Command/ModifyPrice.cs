using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    public class ModifyPrice
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach (var cmd in Enumerable.Reverse(_commands))
            {
                cmd.UndoAction();
            }    
        }
        
        public string ListCommands()
        {
            var sb = new StringBuilder();
            foreach (var item in _commands)
            {
                sb.Append($"{item} ");
            }

            return sb.ToString();
        }
    }
}