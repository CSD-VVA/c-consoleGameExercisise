using ConsoleGame.Gui;
using System;
using System.Collections.Generic;

namespace ConsoleGame.View
{
    sealed class GameWindow : Window
    {
        public IList<Button> Buttons { get; private set; }
        private TextBlock titleTextBlock;

        public const string StartText = "Start";
        public const string CreditsText = "Credits";
        public const string QuitText = "Quit";

        public const int WIDTH = 120;
        public const int HEIGHT = 30;

        const int BUTTON_Y = 13;
        const int FIRST_BUTTON_X = 20;
        const int BETWEEN_BUTTONS = 30;
        const int BUTTON_WIDTH = 18;
        const int BUTTON_HEIGTH = 5;

        public GameWindow() : base(0, 0, WIDTH, HEIGHT, '%')
        {
            titleTextBlock = new TextBlock(
                10, 
                5, 
                100,
                new List<string>
                {
                    "Super duper zaidimas",
                    "Vilius Valiukenas kuryba!",
                    "Made in Vilnius Coding School!"
                });

            Buttons = new List<Button>
            {
                new Button(
                    FIRST_BUTTON_X, BUTTON_Y,
                    BUTTON_WIDTH, BUTTON_HEIGTH, 
                    StartText),
                new Button(
                    FIRST_BUTTON_X + BETWEEN_BUTTONS, BUTTON_Y,
                    BUTTON_WIDTH, BUTTON_HEIGTH, 
                    CreditsText),
                new Button(
                    FIRST_BUTTON_X + BETWEEN_BUTTONS * 2, BUTTON_Y,
                    BUTTON_WIDTH, BUTTON_HEIGTH, 
                    QuitText),
            };

            Buttons[0].SetActive();
        }

        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            RenderButtons();

            Console.SetCursorPosition(0, 0);
        }

        public void RenderButtons()
        {
            foreach (Button button in Buttons)
            {
                button.Render();
            }
        }
    }
}
