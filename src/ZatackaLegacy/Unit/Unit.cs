using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Collections;

namespace ZatackaLegacy.Unit
{
    abstract class Unit : DrawingVisual, ICollection<Unit>
    {
        public long Created { get; private set; }
        public bool EnableCollisions { get; protected set; }
        public Screen Screen { get; protected set; }
        public Target.Collection Targets { get; private set; }
        protected List<Unit> Units { get; set; }

        public Unit(Screen Screen)
        {
            EnableCollisions = false;

            this.Screen = Screen;
            this.Created = Screen.Time;
            this.Units = new List<Unit>();
            this.Targets = new Target.Collection();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public void Draw()
        {
            Draw(Screen.Time - Created);
            foreach (Unit Unit in Units)
            {
                Unit.Draw();
            }
        }

        public virtual void Draw(long Lifetime) { }

        public virtual void Add(Unit Item)
        {
            Units.Add(Item);
            Children.Add(Item);
        }

        public virtual bool Remove(Unit Item)
        {
            Children.Remove(Item);
            return Units.Remove(Item);
        }

        public virtual void Clear()
        {
            Units.Clear();
            Children.Clear();
        }

        public bool Contains(Unit Item)
        {
            return Units.Contains(Item);
        }

        public void CopyTo(Unit[] Array, int Index)
        {
            Units.CopyTo(Array, Index);
        }

        public int Count
        {
            get { return Units.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<Unit> GetEnumerator()
        {
            return Units.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Units.GetEnumerator();
        }
    }
}