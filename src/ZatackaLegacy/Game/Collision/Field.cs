using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Game.Collision
{
    class Field : ICollection<Target>
    {
        public Engine Engine { get; private set; }
        public double Size { get; private set; }

        HashSet<Target> Targets { get; private set; }
        HashSet<Target>[,] Cells { get; private set; }

        public Field(Engine Engine)
        {
            Size = 50;
            this.Engine = Engine;
            Initialize();
        }

        private void Initialize()
        {
            double Width = Engine.Game.Canvas.Size.Width / Size;
            double Height = Engine.Game.Canvas.Size.Height / Size;
            Targets = new HashSet<Target>();
            Cells = new HashSet<Target>[(int)Width + 1, (int)Height + 1];
        }

        public List<Target> Near(Point Location) { return Near(Location, Size); }
        public List<Target> Near(Point Location, double Threshold)
        {
            List<Target> Result = new List<Target>();

            int Neighbors = (int)Math.Ceiling(Threshold / Size);
            int X = (int)(Location.X / Size);
            int Y = (int)(Location.Y / Size);

            for (int i = X - Neighbors; i <= X + Neighbors; i++)
            {
                if (i < 0 || i >= Cells.GetLength(0))
                {
                    continue;
                }

                for (int j = Y - Neighbors; j <= Y + Neighbors; j++)
                {
                    if (j < 0 || j >= Cells.GetLength(1) || Cells[i, j] == null)
                    {
                        continue;
                    }

                    foreach (Target T in Cells[i, j])
                    {
                        Result.Add(T);
                    }
                }
            }

            return Result;
        }

        public void Add(Target Target)
        {
            int X = (int)(Target.Location.X / Size);
            int Y = (int)(Target.Location.Y / Size);

            if (Cells[X, Y] == null)
            {
                Cells[X, Y] = new HashSet<Target>();
            }

            Cells[X, Y].Add(Target);
            Targets.Add(Target);
        }

        public void Remove(Target Target)
        {
            int X = (int)(Target.Location.X / Size);
            int Y = (int)(Target.Location.Y / Size);

            if (Cells[X, Y] != null)
            {
                Cells[X, Y].Remove(Target);
            }

            Targets.Remove(Target);
        }

        public void Clear()
        {
            Initialize();
        }

        public bool Contains(Target Target)
        {
            return Targets.Contains(Target);
        }

        public void CopyTo(Target[] Array, int Index)
        {
            Targets.CopyTo(Array, Index);
        }

        public int Count
        {
             get { return Targets.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<Target> GetEnumerator()
        {
            return Targets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Targets.GetEnumerator();
        }
    }
}
