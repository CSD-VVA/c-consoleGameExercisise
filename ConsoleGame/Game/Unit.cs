using System;

namespace ConsoleGame.Game
{
    class Unit
    {
        protected int x;
        protected int y;
        private readonly string name;

        public Unit(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public virtual void Render()
        {
        }
    }
}
