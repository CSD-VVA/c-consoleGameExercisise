using ConsoleGame.View;
using System;

namespace ConsoleGame.Game
{
    class Hero : Unit
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        private int oldX = 1;

        public Hero(int x, int y, string name) : base(x, y, name)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public void MoveRight()
        {
            oldX = X;

            if (X < GameWindow.WIDTH - 2)
            {
                X++;
            }
        }

        public void MoveLeft()
        {
            oldX = X;

            if (X > 1)
            {
                X--;
            }
        }

        public override void Render()
        {
            Console.SetCursorPosition(oldX, Y);
            Console.Write(' ');

            Console.SetCursorPosition(X, Y);
            Console.Write('X');
        }
    }
}
