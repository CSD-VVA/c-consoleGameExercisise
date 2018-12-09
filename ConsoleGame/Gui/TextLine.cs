using System;

namespace ConsoleGame.Gui
{
    class TextLine : GuiObject
    {
        private string _data;

        public TextLine(int x, int y, int width, string data) : base(x, y, width, 0)
        {
            _data = data;
        }

        public override void Render()
        {
            Console.SetCursorPosition(_x, _y);
            if (_width > _data.Length)
            {
                int offset = (_width - _data.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }

            Console.Write(_data);
        }
    }
}
