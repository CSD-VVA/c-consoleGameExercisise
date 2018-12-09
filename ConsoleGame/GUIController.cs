using ConsoleGame.Gui;
using ConsoleGame.View;
using System;

namespace ConsoleGame
{
    class GUIController
    {
        private readonly GameWindow gameWindow;
        private readonly CreditWindow creditWindow;
        private readonly GameController gameController;

        private int selectedButtonIndex = 0;
        private bool needToRenderGameWindow = true;
        private bool needToRenderCreditsWindow = true;

        public GUIController()
        {
            gameWindow = new GameWindow();
            creditWindow = new CreditWindow();
            gameController = new GameController(this);
        }

        public void ShowMenu()
        {
            gameWindow.Render();

            do
            {
                needToRenderCreditsWindow = true;

                GetUserSelection();

            } while (needToRenderGameWindow);
        }

        public void GetUserSelection()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                switch (pressedChar.Key)
                {
                    case ConsoleKey.Enter:
                        switch (gameWindow.Buttons[selectedButtonIndex].Name)
                        {
                            case GameWindow.StartText:
                                gameController.StartGame();
                                break;
                            case GameWindow.CreditsText:
                                ShowCredits();
                                break;
                            case GameWindow.QuitText:
                                needToRenderGameWindow = false;
                                break;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (selectedButtonIndex < 2)
                        {
                            selectedButtonIndex++;
                            SetButtonSelected(gameWindow.Buttons[selectedButtonIndex]);
                            gameWindow.RenderButtons();
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (selectedButtonIndex > 0)
                        {
                            selectedButtonIndex--;
                            SetButtonSelected(gameWindow.Buttons[selectedButtonIndex]);
                            gameWindow.RenderButtons();
                        }
                        break;
                    case ConsoleKey.Escape:
                        needToRenderGameWindow = false;
                        break;
                }
            }
        }

        public void ShowCredits()
        {
            creditWindow.Render();

            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Enter:
                            gameWindow.Render();
                            GetUserSelection();
                            needToRenderCreditsWindow = false;
                            break;
                        case ConsoleKey.Escape:
                            gameWindow.Render();
                            GetUserSelection();
                            needToRenderCreditsWindow = false;
                            break;
                    }
                }

            } while (needToRenderCreditsWindow);
        }

        public void SetButtonSelected(Button selectedButton)
        {
            foreach (Button button in gameWindow.Buttons)
            {
                if (button.Equals(selectedButton))
                {
                    button.SetActive();
                }
                else
                {
                    button.SetInactive();
                }
            }
        }
    }
}
