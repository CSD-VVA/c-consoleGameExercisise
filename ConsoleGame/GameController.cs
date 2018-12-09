using ConsoleGame.Game;
using ConsoleGame.View;
using System;

namespace ConsoleGame
{
    class GameController
    {
        private readonly GUIController guiController;

        private int counterForEnemyMoving = 0;
        private int counterForAddingEnemies = 0;
        private readonly int enemySpawSlowness = 300;

        private int enemiesAliveCount;

        const int STARTING_ENEMY_COUNT = 10;

        public GameController(GUIController guiController)
        {
            this.guiController = guiController;
        }

        public void StartGame()
        {
            Console.Clear();

            GameScreen myGame = new GameScreen();
            myGame.Render();

            myGame.SetHero(new Hero(GameWindow.WIDTH / 2, GameWindow.HEIGHT - 3, "HERO"));
            myGame.RenderHero();

            Random rnd = new Random();
            int enemyCount = 0;

            bool needToRender = true;

            do
            {
                enemiesAliveCount = myGame.GetAliveEnemyCount();

                myGame.RenderEnemies();

                counterForEnemyMoving++;
                counterForAddingEnemies++;

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            guiController.ShowMenu();
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.GetHero().MoveRight();
                            myGame.RenderHero();
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.GetHero().MoveLeft();
                            myGame.RenderHero();
                            break;
                        case ConsoleKey.Spacebar:
                            // shoot bullet
                            break;
                    }
                }

                if (counterForEnemyMoving == Enemy.ENEMY_SLOWNESS)
                {
                    counterForEnemyMoving = 0;
                    myGame.MoveAllEnemiesDown();

                    UpdateEnemyCount();
                }

                if (counterForAddingEnemies == enemySpawSlowness)
                {
                    counterForAddingEnemies = 0;

                    int enemySpawnX = rnd.Next(1, GameWindow.WIDTH - 1);
                    int enemySpawnY = rnd.Next(2, GameWindow.HEIGHT / 4);

                    myGame.AddEnemy(new Enemy(enemyCount, enemySpawnX, enemySpawnY + 2, "enemy" + enemyCount));
                    enemyCount++;
                }

                foreach (Enemy enemy in myGame.Enemies)
                {
                    if (enemy.X == myGame.GetHero().X && enemy.Y == myGame.GetHero().Y)
                    {
                        guiController.ShowMenu();
                        needToRender = false;
                    }
                }

            } while (needToRender);
        }

        private void UpdateEnemyCount()
        {
            Console.SetCursorPosition(GameWindow.WIDTH - 10, 2);
            Console.Write("Enemies:");

            Console.SetCursorPosition(GameWindow.WIDTH - 7, 3);
            Console.Write(enemiesAliveCount);
        }
    }
}
