using Final.Actions;
using Final.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final
{
    class ActionFactory
    {
        private Dictionary<string, string> actions = new Dictionary<string, string>();
        public Actions.Action command { get; }

        public ActionFactory(string action)
        {
            this.setCommandsArray();
            string cmd;
            bool value = this.actions.TryGetValue(action, out cmd);

            if(!value)
            {
                throw new WrongCommandException($"There is no {action} command");
            }

            Type className = Type.GetType($"Final.Actions.{cmd}", false, true);
            this.command = (Actions.Action) Activator.CreateInstance(className);
        }

        private void setCommandsArray()
        {
            this.actions.Add("/cd", "Step");
            this.actions.Add("/rm", "Delete");
            this.actions.Add("/copy", "Copy");
            this.actions.Add("/help", "Help");
            this.actions.Add("/info", "Info");
            this.actions.Add("/ls", "Show");
        }
    }
}
