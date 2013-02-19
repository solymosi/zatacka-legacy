using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Collections;

namespace Zatacka.Unit
{
    /// <summary>
    /// Represents a visual element that can be displayed on the screen.
    /// </summary>
    abstract class Unit : DrawingVisual, ICollection<Unit>
    {
        /// <summary>
        /// Counts the number of calls to Execute since the creation of this Unit.
        /// </summary>
        public long Time { get; protected set; }

        /// <summary>
        /// Specifies whether this Unit can collide with others. If collisions are disabled, this Unit can not detect collisions with others and it is skipped when other units test for collisions as well.
        /// </summary>
        public bool EnableCollisions { get; set; }

        /// <summary>
        /// Specifies whether this Unit can collide with itself. Used only when collisions are enabled.
        /// </summary>
        public bool SelfCollision { get; set; }

        /// <summary>
        /// Contains Target instances other units use to determine whether they have a collision with this Unit. Used only when collisions are enabled.
        /// </summary>
        public HashSet<Collision.Target> Targets { get; protected set; }

        /// <summary>
        /// Contains Target instances this Unit uses to determine whether it has a collision with other units. Used only when collisions are enabled.
        /// </summary>
        public HashSet<Collision.Target> Colliders { get; protected set; }

        /// <summary>
        /// The Canvas this Unit is displayed on.
        /// </summary>
        public Canvas.Canvas Canvas { get; protected set; }

        /// <summary>
        /// Contains child units belonging to this Unit in the unit hierarchy.
        /// </summary>
        protected List<Unit> Units { get; set; }

        /// <summary>
        /// Creates and initializes this Unit and disables collisions by default.
        /// </summary>
        /// <param name="Canvas">The Canvas this Unit is displayed on.</param>
        public Unit(Canvas.Canvas Canvas)
        {
            this.Canvas = Canvas;
            this.Units = new List<Unit>();

            EnableCollisions = false;
            SelfCollision = false;

            this.Targets = new HashSet<Collision.Target>();
            this.Colliders = new HashSet<Collision.Target>();
        }

        /// <summary>
        /// Updates the state of this Unit and its child units.
        /// </summary>
        public void Execute()
        {
            Update();

            foreach (Unit Unit in Units)
            {
                Unit.Execute();
            }

            Time++;
        }

        /// <summary>
        /// Updates the state of this Unit.
        /// </summary>
        abstract protected void Update();

        /// <summary>
        /// Determines whether this Unit collides with another and returns the collision information.
        /// </summary>
        /// <param name="Unit">The other Unit to test collisions on.</param>
        public virtual Collision.Result CollisionsWith(Unit Unit)
        {
            Collision.Result Result = new Collision.Result(this, Unit);

            if (EnableCollisions && Unit.EnableCollisions)
            {
                foreach (Collision.Target Collider in Colliders)
                {
                    foreach (Collision.Target Target in Unit.TargetsWithin(Collider.Geometry.Bounds))
                    {
                        if (Collider.CollidesWith(Target))
                        {
                            if (!Result.Colliders.Contains(Collider)) { Result.Colliders.Add(Collider); }
                            if (!Result.Targets.Contains(Target)) { Result.Targets.Add(Target); }
                        }
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Returns all collision targets. Can be overloaded to return targets only within the specified bounds using a Field.
        /// </summary>
        /// <param name="Bounds">The rectangle used to determine which targets to return.</param>
        protected virtual HashSet<Collision.Target> TargetsWithin(Rect Bounds)
        {
            return Targets;
        }

        /// <summary>
        /// Adds a Unit to the children of this Unit and places it on the top of the other child Units.
        /// </summary>
        /// <param name="Item">The Unit to add.</param>
        public virtual void Add(Unit Item)
        {
            Add(Item, AbsolutePosition.Top);
        }

        /// <summary>
        /// Adds a Unit to the children of this Unit and places it just below the child with the specified position.
        /// </summary>
        /// <param name="Item">The Unit to add.</param>
        /// <param name="Position">The position to place this Unit.</param>
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

        /// <summary>
        /// Adds a Unit to the children of this unit and places it above or below all other child units.
        /// </summary>
        /// <param name="Item">The Unit to add.</param>
        /// <param name="Position">The position to place this Unit.</param>
        public virtual void Add(Unit Item, AbsolutePosition Position)
        {
            switch (Position)
            {
                case AbsolutePosition.Top: Add(Item, Children.Count); break;
                case AbsolutePosition.Bottom: Add(Item, 0); break;
            }
        }

        /// <summary>
        /// Adds a Unit to the children of this unit and places it above or below a specified reference unit.
        /// </summary>
        /// <param name="Item">The Unit to add.</param>
        /// <param name="Position">The position to place this Unit relative to the reference unit.</param>
        /// <param name="Reference">The Unit used as a reference point.</param>
        public virtual void Add(Unit Item, RelativePosition Position, Unit Reference)
        {
            int ReferencePosition = Children.IndexOf(Reference);
            switch (Position)
            {
                case RelativePosition.Above: Add(Item, ReferencePosition + 1); break;
                case RelativePosition.Below: Add(Item, ReferencePosition); break;
            }
        }

        /// <summary>
        /// Removes a Unit from the children of this unit.
        /// </summary>
        /// <param name="Item">The Unit to remove.</param>
        public virtual bool Remove(Unit Item)
        {
            Children.Remove(Item);
            return Units.Remove(Item);
        }

        /// <summary>
        /// Removes all child units from this Unit.
        /// </summary>
        public virtual void Clear()
        {
            Units.Clear();
            Children.Clear();
        }

        /// <summary>
        /// Gets whether the specified unit is a child of this Unit.
        /// </summary>
        /// <param name="Item">The Unit to search for.</param>
        public bool Contains(Unit Item)
        {
            return Units.Contains(Item);
        }

        /// <summary>
        /// Copies all child units to the specified array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="Array">The array to copy the child units to.</param>
        /// <param name="Index">The starting index of the target array.</param>
        public void CopyTo(Unit[] Array, int Index)
        {
            Units.CopyTo(Array, Index);
        }

        /// <summary>
        /// Gets the number of child units belonging to this Unit.
        /// </summary>
        public int Count
        {
            get { return Units.Count; }
        }

        /// <summary>
        /// Gets whether adding or removing child units is disabled.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the child units.
        /// </summary>
        public IEnumerator<Unit> GetEnumerator()
        {
            return Units.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the child units.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Units.GetEnumerator();
        }
    }

    /// <summary>
    /// Describes a position relative to a child unit.
    /// </summary>
    public enum RelativePosition
    {
        Above,
        Below
    }

    /// <summary>
    /// Describes a position among all child units.
    /// </summary>
    public enum AbsolutePosition
    {
        Top,
        Bottom
    }
}