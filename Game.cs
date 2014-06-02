using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGLGame.GUI;
using System.Drawing;

namespace OGLGame
{
    public enum GameState
    {
        Menu = 0,
        Level = 1,
        MenuStats = 2,
        Exit = 3
    }

    class Game
    {
        private GameState state;

        private Container GUIMenu = new Container();

        private Level level = new Level();

        public Game()
        {
            state = GameState.Menu;
        }

        public void LoadContent()
        {
            Button buttonNewGame = new Button(new Rectangle(295, 150, 200, 40), "New Game", 2);
            buttonNewGame.onClick += NewGame;
            GUIMenu.Add(buttonNewGame);

            Button buttonStats = new Button(new Rectangle(295, 190, 200, 40), "Stats", 2);
            buttonStats.onClick += StatsGame;
            GUIMenu.Add(buttonStats);

            Button buttonExit = new Button(new Rectangle(295, 230, 200, 40), "Exit", 2);
            buttonExit.onClick += ExitGame;
            GUIMenu.Add(buttonExit);

            level.Load(1, "map.txt");
        }

        public bool Run(int dt)
        {
            switch (state)
            {
                case GameState.Menu:

                    GUIMenu.Update();
                    GUIMenu.Draw();
                    return true;

                case GameState.Level:
                    level.Update(dt);
                    level.Draw(dt);
                    return true;

                case GameState.MenuStats:

                    return true;

                case GameState.Exit:

                    return false;
            }

            return false;
        }

        public void Resize(int width, int height)
        {
            GUIMenu.Resize(width, height);
            level.Resize(width, height);
        }

        private void NewGame()
        {
            Log.Instance.Write("Включаем новую игру");
            state = GameState.Level;
        }

        private void ExitGame()
        {
            Log.Instance.Write("Выход из игры");
            state = GameState.Exit;
        }

        private void StatsGame()
        {
            Log.Instance.Write("Меню статистики");
            state = GameState.MenuStats;
        }
    }
}
