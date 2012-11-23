﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ZatackaLegacy.State
{
    abstract class State : ILifecycle
    {
        public State Parent { get; protected set; }

        public virtual void Enter() { }
        public virtual void Exit() { }

        abstract public void Execute();

        public virtual T As<T>() where T : State
        {
            return (T)this;
        }
    }

    class State<T> : State, IEnumerable<State>
    {
        public bool Active { get; protected set; }
        public T Type
        {
            get
            {
                if (Active) { return this._Type; }
                throw new InvalidOperationException("State machine is not active.");
            }
            protected set { _Type = value; }
        }

        protected T _Type;
        protected Dictionary<T, State> Items { get; set; }

        public delegate void StateChangeDelegate(object sender, StateChangeEventArgs<T> e);
        public event StateChangeDelegate StateChanged = delegate { };

        public delegate void DeactivateDelegate(object sender, EventArgs e);
        public event DeactivateDelegate Deactivated = delegate { };

        public State()
        {
            Items = new Dictionary<T, State>();
        }

        public override void Execute()
        {
            if (Active) { Current.Execute(); }
        }

        public void Change(T Type)
        {
            if (Has(Type) == false)
            {
                throw new ArgumentException("No state is associated with the provided type.");
            }

            if (Active)
            {
                if (Is(Type))
                {
                    throw new InvalidOperationException("The provided type is already the current state.");
                }

                Current.Exit();
            }

            this.Active = true;
            this.Type = Type;
            Current.Enter();
            this.StateChanged(this, new StateChangeEventArgs<T>(Type, Current));
        }

        public void Reset()
        {
            if (Active)
            {
                Current.Exit();
            }

            this.Active = false;
            this.Type = default(T);
            this.Deactivated(this, new EventArgs());
        }

        public State Current
        {
            get
            {
                if (!Active)
                {
                    throw new InvalidOperationException("State machine is not active.");
                }
                
                return this[Type];
            }
        }

        public bool Is(T Type)
        {
            return Active && Has(Type) && Current == this[Type];
        }

        public void Add(T Type, State State)
        {
            Items.Add(Type, State);
        }

        public bool Has(T Type)
        {
            return Items.ContainsKey(Type);
        }

        public void Remove(T Type)
        {
            if (Is(Type))
            {
                Reset();
            }

            Items.Remove(Type);
        }

        public State this[T Type]
        {
            get { return Items[Type]; }
            set { Items[Type] = value; }
        }

        public void Clear()
        {
            Reset();
            Items.Clear();
        }

        public int Count
        {
            get { return Items.Count; }
        }

        public IEnumerator<State> GetEnumerator()
        {
            return Items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.Values.GetEnumerator();
        }
    }

    class StateChangeEventArgs<T> : EventArgs
    {
        public T Type { get; private set; }
        public State State { get; private set; }

        public StateChangeEventArgs(T Type, State State)
        {
            this.Type = Type;
            this.State = State;
        }
    }
}