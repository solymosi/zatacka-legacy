using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ZatackaLegacy
{
    class StateMachine : State, IDictionary<int, State>
    {
        public int ID { get; protected set; }
        protected Dictionary<int, State> States { get; private set; }
        public State Current { get { return this[ID]; } }

        public StateMachine() : this(new Dictionary<int, State>()) { }
        public StateMachine(Dictionary<int, State> States) : this(States, 0) { }
        public StateMachine(Dictionary<int, State> States, int ID)
        {
            this.ID = ID;
            this.States = States;
        }

        public void Change(int ID)
        {
            if (Current != null) { Current.Exit(); }
            this.ID = ID;
            Current.Enter();
        }

        public override void Execute()
        {
            if (Current != null) { Current.Execute(); }
        }

        public void Add(int ID, State State)
        {
            if (ID == 0) { throw new ArgumentException("Cannot add state with ID = 0"); }
            States.Add(ID, State);
        }

        public State this[int ID]
        {
            get { return States[ID]; }
            set
            {
                if (ID == 0) { throw new ArgumentException("Cannot add state with ID = 0"); }
                States[ID] = value;
            }
        }

        public bool ContainsKey(int ID) { return States.ContainsKey(ID); }
        public ICollection<int> Keys { get { return States.Keys; } }
        public bool Remove(int ID) { return States.Remove(ID); }
        public bool TryGetValue(int ID, out State State) { return States.TryGetValue(ID, out State); }
        public ICollection<State> Values { get { return States.Values; } }
        public void Add(KeyValuePair<int, State> Pair) { States.Add(Pair.Key, Pair.Value); }
        public void Clear() { States.Clear(); }
        public bool Contains(KeyValuePair<int, State> Pair) { return States.Contains(Pair); }
        public void CopyTo(KeyValuePair<int, State>[] Array, int Index) { States.ToList().CopyTo(Array, Index); }
        public int Count { get { return States.Count; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(KeyValuePair<int, State> Pair) { return States.Remove(Pair.Key); }
        public IEnumerator<KeyValuePair<int, State>> GetEnumerator() { return States.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return States.GetEnumerator(); }
    }
}
