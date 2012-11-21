using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ZatackaLegacy
{
    class StateMachine<TKey, TState> : State<TKey>, IDictionary<TKey, TState> where TState : State<TKey>
    {
        public TKey ID { get; protected set; }
        public State<TKey> Current { get { return this[ID]; } }
        protected Dictionary<TKey, TState> States { get; set; }

        public StateMachine(TKey Initial) : this(new Dictionary<TKey, TState>(), Initial) { }
        public StateMachine(Dictionary<TKey, TState> States, TKey ID) 
        {
            this.ID = ID;
            this.States = States;
        }

        public virtual void Change(TKey ID)
        {
            if (Current != null) { Current.Exit(); }
            this.ID = ID;
            Current.Enter();
        }

        public override void Execute()
        {
            if (Current != null) { Current.Execute(); }
        }

        public void Add(TKey ID, TState State)
        {
            States.Add(ID, State);
        }

        public TState this[TKey ID]
        {
            get { return States[ID]; }
            set { States[ID] = value; }
        }

        public bool ContainsKey(TKey ID) { return States.ContainsKey(ID); }
        public ICollection<TKey> Keys { get { return States.Keys; } }
        public bool Remove(TKey ID) { return States.Remove(ID); }
        public bool TryGetValue(TKey ID, out TState State) { return States.TryGetValue(ID, out State); }
        public ICollection<TState> Values { get { return States.Values; } }
        public void Add(KeyValuePair<TKey, TState> Pair) { States.Add(Pair.Key, Pair.Value); }
        public void Clear() { States.Clear(); }
        public bool Contains(KeyValuePair<TKey, TState> Pair) { return States.Contains(Pair); }
        public void CopyTo(KeyValuePair<TKey, TState>[] Array, int Index) { States.ToList().CopyTo(Array, Index); }
        public int Count { get { return States.Count; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(KeyValuePair<TKey, TState> Pair) { return States.Remove(Pair.Key); }
        public IEnumerator<KeyValuePair<TKey, TState>> GetEnumerator() { return States.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return States.GetEnumerator(); }
    }
}
