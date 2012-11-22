using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    interface IStateManager<TKey, TChildren> : IDictionary<TKey, TChildren>
    {
        StateManager<TKey, TChildren> Manager { get; set; }
    }

    abstract class StateManager<TKey, TChildren> : IDictionary<TKey, TChildren> where TChildren : State<StateManager<TKey, TChildren>>
    {
        public event EventHandler<StateChangedEventArgs<TKey, TChildren>> StateChanged = delegate { };

        public State(TKey Initial) : this(new Dictionary<TKey, TChildren>(), Initial) { }
        public State(Dictionary<TKey, TChildren> Children, TKey ID)
        {
            this.ID = ID;
            this.Children = Children;
        }

        public virtual void Change(TKey ID)
        {
            if (Current != null) { Current.Exit(); }
            this.ID = ID;
            StateChanged(this, new StateChangedEventArgs<TKey, TChildren>(ID, Current));
            Current.Enter();
        }

        public TChildren Current
        {
            get { return ContainsKey(ID) ? this[ID] : null; }
        }

        public override void Execute()
        {
            ExecuteChildren();
        }

        public void ExecuteChildren()
        {
            foreach (TChildren Child in Children.Values)
            {
                Child.Execute();
            }
        }

        public void Add(TKey ID, TChildren State)
        {
            Children.Add(ID, State);
        }

        public bool ContainsKey(TKey ID)
        {
            return Children.ContainsKey(ID);
        }

        public ICollection<TKey> Keys
        {
            get { return Children.Keys; }
        }

        public bool Remove(TKey ID)
        {
            return Children.Remove(ID);
        }

        public bool TryGetValue(TKey ID, out TChildren State)
        {
            return Children.TryGetValue(ID, out State);
        }

        public ICollection<TChildren> Values
        {
            get { return Children.Values; }
        }

        public TChildren this[TKey ID]
        {
            get { return Children[ID]; }
            set { Children[ID] = value; }
        }

        public void Add(KeyValuePair<TKey, TChildren> Item)
        {
            Children.Add(Item.Key, Item.Value);
        }

        public void Clear()
        {
            Children.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TChildren> Item)
        {
            return Children.Contains(Item);
        }

        public void CopyTo(KeyValuePair<TKey, TChildren>[] Array, int Index)
        {
            Children.ToList().CopyTo(Array, Index);
        }

        public int Count
        {
            get { return Children.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TChildren> Item)
        {
            return Children.Remove(Item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TChildren>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }

    abstract class State<TParent, TKey, TChildren> : State<TKey, TChildren> //where TChildren : State<State<TParent, TKey, TChildren>>
    {
        public TParent Parent { get; protected set; }
    }

    class StateChangedEventArgs<TKey, TState> : EventArgs
    {
        public TKey ID { get; private set; }
        public TState State { get; private set; }

        public StateChangedEventArgs(TKey ID, TState State)
        {
            this.ID = ID;
            this.State = State;
        }
    }
}
