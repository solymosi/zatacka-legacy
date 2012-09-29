using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;

namespace ZatackaLegacy
{
    public class TargetCollection : ISet<Target>
    {
        public double CellSize = 50;

        HashSet<Target> List = new HashSet<Target>();
        Dictionary<int, Dictionary<int, HashSet<Target>>> Cells = new Dictionary<int, Dictionary<int, HashSet<Target>>>();

        public bool Add(Target Target)
        {
            int X = (int)(Target.Location.X / CellSize);
            int Y = (int)(Target.Location.Y / CellSize);
            if (!Cells.ContainsKey(X)) { Cells.Add(X, new Dictionary<int, HashSet<Target>>()); }
            if (!Cells[X].ContainsKey(Y)) { Cells[X].Add(Y, new HashSet<Target>()); }
            Cells[X][Y].Add(Target);
            return List.Add(Target);
        }

        public List<HashSet<Target>> Near(Point Location) { return Near(Location, CellSize); }
        public List<HashSet<Target>> Near(Point Location, double Threshold)
        {
            List<HashSet<Target>> Result = new List<HashSet<Target>>();

            int Neighbors = (int)Math.Ceiling(Threshold / CellSize);
            int X = (int)(Location.X / CellSize);
            int Y = (int)(Location.Y / CellSize);

            for (int i = X - Neighbors; i <= X + Neighbors; i++)
            {
                if (!Cells.ContainsKey(i)) { continue; }
                for (int j = Y - Neighbors; j <= Y + Neighbors; j++)
                {
                    if (!Cells[i].ContainsKey(j)) { continue; }
                    Result.Add(Cells[i][j]);
                }
            }

            return Result;
        }

        public bool Remove(Target Target)
        {
            int X = (int)(Target.Location.X / CellSize);
            int Y = (int)(Target.Location.Y / CellSize);
            if (Cells.ContainsKey(X) && Cells[X].ContainsKey(Y))
            {
                Cells[X][Y].Remove(Target);
            }
            return List.Remove(Target);
        }

        public void ExceptWith(IEnumerable<Target> other) { List.ExceptWith(other); }
        public void IntersectWith(IEnumerable<Target> other) { List.IntersectWith(other); }
        public bool IsProperSubsetOf(IEnumerable<Target> other) { return List.IsProperSubsetOf(other); }
        public bool IsProperSupersetOf(IEnumerable<Target> other) { return List.IsProperSupersetOf(other); }
        public bool IsSubsetOf(IEnumerable<Target> other) { return List.IsSubsetOf(other); }
        public bool IsSupersetOf(IEnumerable<Target> other) { return List.IsSupersetOf(other); }
        public bool Overlaps(IEnumerable<Target> other) { return List.Overlaps(other); }
        public bool SetEquals(IEnumerable<Target> other) { return List.SetEquals(other); }
        public void SymmetricExceptWith(IEnumerable<Target> other) { List.SymmetricExceptWith(other); }
        public void UnionWith(IEnumerable<Target> other) { List.UnionWith(other); }
        public void Clear() { List.Clear(); }
        public bool Contains(Target item) { return List.Contains(item); }
        public void CopyTo(Target[] array, int arrayIndex) { List.CopyTo(array, arrayIndex); }
        public int Count { get { return List.Count; } }
        public bool IsReadOnly { get { return false; } }
        public IEnumerator<Target> GetEnumerator() { return List.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator(){return List.GetEnumerator();}
        bool ISet<Target>.Add(Target item) { return Add(item); }
        void ICollection<Target>.Add(Target item) { Add(item); }
    }
}
