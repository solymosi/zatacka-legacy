using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    class StateMachine : IState
    {
        private IState current;
        private List<IState> states;


        public StateMachine(IState Current, List<IState> States)
        {
            this.current = Current;
            this.states = States;
            
        }

        public IState Current
        {
            get { return current; }
            set { current = value; }
        }
        public List<IState> States
        {
            get { return states; }
            set { states = value; }
        }

        public virtual void Enter()
        {
        }
        public virtual void Execute()
        {
        }
        public virtual void Exit()
        {
        }
        public virtual void Active()
        {
        }
        public virtual void Inactive()
        {
        }
        public virtual void Paused()
        {
        }
        public virtual void Terminated()
        {
        }

        public bool IsCycleActive()
        {
            return this.current.ActiveCycle;
        }

    }
}
