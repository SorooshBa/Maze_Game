using BestWays;
using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Drawing;

namespace BestWaysGame
{
    class Program
    {
        class gameMap
        {
            static void Main(string[] args)
            {
                GameManager gameManager = new GameManager();
                gameManager.MoveTO("3j 2i 1j 2i");
                Console.WriteLine(gameManager.isWon().ToString());
            }
        }
    }
}

