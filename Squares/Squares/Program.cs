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
    internal class Program
    {
        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_Closed;
            win.SetFramerateLimit(60);

            Game game = new Game();

            // Square square = new Square(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600));
            // Square square2 = new Square(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600));

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));

                //square.Move();
                //square2.Move();

                //square.Draw(win);
                //square2.Draw(win);

                win.DispatchEvents();

                game.Update(win);

                win.Display();
            }
        }

        static void Win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
