using ConsoleGame.View;
using System;

namespace ConsoleGame.Game
{
    class Enemy : Unit
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private readonly int id;

        public const int ENEMY_SLOWNESS = 100;

        public Enemy(int id, int x, int y, string name) : base(x, y, name)
        {
            X = x;
            Y = y;

            this.id = id;
        }

        public void MoveDown()
        {
            if (Y < GameWindow.HEIGHT - 2)
            {
                Y++;
            }
        }

        public int GetId()
        {
            return id;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('V');

            Console.SetCursorPosition(X, Y - 1);
            Console.Write(' ');

            if (Y == GameWindow.HEIGHT - 2)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write('_');
            }
        }
    }
}
