using System;

namespace ConsoleGame.Gui
{
    class Window : GuiObject
    {
        private Frame border;

        public Window(int x, int y, int width, int height, char borderChar) : base(x, y, width, height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;

            border = new Frame(x, y, width, height, borderChar);
        }

        public override void Render()
        {
            border.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
