using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Unit.Collision
{
    class Field : ICollection<Target>
    {
        public Unit Unit { get; private set; }
        public int Size { get; private set; }

        public HashSet<Target> Targets { get; private set; }
        public Dictionary<int, HashSet<Target>> Cells { get; private set; }

        public Field(Unit Unit)
        {
            this.Unit = Unit;
            this.Size = 10;

            Targets = new HashSet<Target>();
            Cells = new Dictionary<int, HashSet<Target>>();
        }

        public HashSet<Target> Within(Rect Bounds) { return Within(Bounds, 5); }
        public HashSet<Target> Within(Rect Bounds, double Threshold)
        {
            HashSet<Target> Result = new HashSet<Target>();

            int X = (int)(Bounds.Center().X / Size);
            int Y = (int)(Bounds.Center().Y / Size);
            int NX = (int)Math.Ceiling((Bounds.Width / 2 + Threshold) / Size);
            int NY = (int)Math.Ceiling((Bounds.Height / 2 + Threshold) / Size);

            for (int i = X - NX; i <= X + NX; i++)
            {
                for (int j = Y - NY; j <= Y + NY; j++)
                {
                    int K = CalculateKey(i, j);

                    if (!Cells.ContainsKey(K))
                    {
                        continue;
                    }

                    foreach (Target T in Cells[K])
                    {
                        Result.Add(T);
                    }
                }
            }

            return Result;
        }

        private int CalculateKey(int X, int Y)
        {
            return 10000 * X + Y;
        }

        public void Add(Target Target)
        {
            int X = (int)(Target.Geometry.Bounds.Center().X / Size);
            int Y = (int)(Target.Geometry.Bounds.Center().Y / Size);
            int K = CalculateKey(X, Y);

            if (!Cells.ContainsKey(K))
            {
                Cells.Add(K, new HashSet<Target>());
            }

            Cells[K].Add(Target);
            Targets.Add(Target);
        }

        public bool Remove(Target Target)
        {
            int X = (int)(Target.Geometry.Bounds.Center().X / Size);
            int Y = (int)(Target.Geometry.Bounds.Center().Y / Size);
            int K = CalculateKey(X, Y);

            if (Cells.ContainsKey(K))
            {
                Cells[K].Remove(Target);
            }

            return Targets.Remove(Target);
        }

        public void Clear()
        {
            Targets.Clear();
            Cells.Clear();
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
