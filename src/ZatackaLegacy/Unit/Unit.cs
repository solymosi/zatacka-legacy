using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Collections;

namespace Zatacka.Unit
{
    abstract class Unit : DrawingVisual, ICollection<Unit>
    {
        public long Created { get; private set; }
        public bool EnableCollisions { get; protected set; }
        public Canvas.Canvas Canvas { get; protected set; }
        public Target.Collection Targets { get; private set; }
        protected List<Unit> Units { get; set; }

        public Unit(Canvas.Canvas Canvas)
        {
            EnableCollisions = false;

            this.Canvas = Canvas;
            //this.Created = Canvas.Time;
            this.Units = new List<Unit>();
            this.Targets = new Target.Collection();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public void Draw()
        {
            //Draw(Screen.Time - Created);
            Draw(0);
            foreach (Unit Unit in Units)
            {
                Unit.Draw();
            }
        }

        public virtual void Draw(long Lifetime) { }

        public virtual void Add(Unit Item)
        {
            Add(Item, AbsolutePosition.Top);
        }

        public virtual void Add(Unit Item, int Position)
        {
            Units.Add(Item);

            if(Position == Children.Count)
            {
                Children.Add(Item);
            }
            else
            {
                Children.Insert(Position, Item);
            }
        }

        public virtual void Add(Unit Item, AbsolutePosition Position)
        {
            switch (Position)
            {
                case AbsolutePosition.Top: Add(Item, Children.Count); break;
                case AbsolutePosition.Bottom: Add(Item, 0); break;
            }
        }

        public virtual void Add(Unit Item, RelativePosition Position, Unit Reference)
        {
            int ReferencePosition = Children.IndexOf(Reference);
            switch (Position)
            {
                case RelativePosition.Above: Add(Item, ReferencePosition + 1); break;
                case RelativePosition.Below: Add(Item, ReferencePosition); break;
            }
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

    public enum RelativePosition
    {
        Above,
        Below
    }

    public enum AbsolutePosition
    {
        Top,
        Bottom
    }
}