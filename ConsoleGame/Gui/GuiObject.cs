namespace ConsoleGame.Gui
{
    abstract class GuiObject
    {
        protected int _x;
        protected int _y;
        protected int _width;
        protected int _height;

        public GuiObject(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public abstract void Render();
    }
}
