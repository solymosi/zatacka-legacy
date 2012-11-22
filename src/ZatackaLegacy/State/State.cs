using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ZatackaLegacy
{
    abstract class State : ILifecycle
    {
        public virtual void Enter() { }
        public virtual void Exit() { }

        abstract public void Execute();
    }

    abstract class State<TParent> : State
    {
        public TParent Parent { get; protected set; }
    }
}