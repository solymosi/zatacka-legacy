using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    abstract class State<T> : ILifecycle
    {
        public StateMachine<T, State<T>> Parent { get; protected set; }

        public virtual void Enter() { }
        public virtual void Exit() { }

        abstract public void Execute();
    }
}