using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Actions
{
    interface Action
    {
        public void Create(params string[] args);
        private void Run() { }
    }
}
