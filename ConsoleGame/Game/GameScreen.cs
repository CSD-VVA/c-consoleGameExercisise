using ConsoleGame.Gui;
using ConsoleGame.View;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Game
{
    class GameScreen : Window
    {
        private Hero hero;
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

        public GameScreen() : base(0, 0, GameWindow.WIDTH, GameWindow.HEIGHT, '#')
        {
        }

        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public Hero GetHero()
        {
            return hero;
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.MoveDown();
            }
        }

        public Enemy GetEnemyById(int id)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }
            return null;
        }

        public void RenderHero()
        {
            hero.Render();
        }

        public void RenderEnemies()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Render();
            }

            IList<Enemy> enemiesToDelete = new List<Enemy>();
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.Y >= GameWindow.HEIGHT - 2)
                {
                    enemiesToDelete.Add(enemy);
                }
            }

            foreach (Enemy enemy in enemiesToDelete)
            {
                Enemies.Remove(enemy);
            }
        }

        public int GetAliveEnemyCount()
        {
            return Enemies.Count;
        }
    }
}
