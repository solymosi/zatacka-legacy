using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Game.Collision
{
    class Engine
    {
        public Game Game { get; private set; }
        public Field Field { get; private set; }
        public List<Unit.Unit> Units { get; private set; }

        public Engine(Game Game)
        {
            this.Game = Game;
            this.Field = new Field(this);
            this.Units = new List<Unit.Unit>();
        }

        public void Register(Unit.Unit Unit)
        {
            
        }

        public void Execute()
        {


            foreach (Unit.Unit Unit in Units)
            {
                if (Unit.EnableCollisions)
                {
                    foreach (Type Type in Unit.Collisions)
                    {
                        
                    }
                }
            }
        }
    }

    enum Type
    {
        Wall = 1,
        Curve
    }
}
