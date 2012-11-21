using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    abstract class State : ILifecycle
    {
        public StateMachine Parent { get; protected set; }

        public void Enter() { }
        public void Exit() { }

        abstract public void Execute();
    }
}