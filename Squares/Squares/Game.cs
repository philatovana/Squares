using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares
{
    public class Game
    {
        public static int Scores;
        public static bool IsLost;

        private Font mainFont;
        private Text scoreText;
        private Text loseText;

        private SquaresList squares;

        private int MaxScores;

        public Game()
        {
            mainFont = new Font("comic.ttf");
            squares = new SquaresList();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты проиграл!( Нажми R для перезапуска!";
            loseText.Position = new Vector2f(20, 290);

            Reset();

        }

        private void Reset()
        {
            squares.Reset();
            Scores = 0;
            IsLost = false;

            //squares = new SquaresList();

            squares.SpawnPlayerSquare();

            squares.SpawnEnemySquare();
        }


        public void Update(RenderWindow win)
        {
            if (IsLost == true)
            {
                win.Draw(loseText);

                if (Scores > MaxScores)
                    MaxScores = Scores;

                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                }
            }

            if (IsLost == false)
            {
                squares.Update(win);

                if (squares.SquareHasRemoved == true)
                {
                    if (squares.RemovedSquare is PlayerSquare)
                    {
                        squares.SpawnPlayerSquare();
                    }
                }
            }


            scoreText.DisplayedString = "Счет: " + Scores.ToString() + "\nMax: " + MaxScores.ToString();
            win.Draw(scoreText);
        }

    }
}
