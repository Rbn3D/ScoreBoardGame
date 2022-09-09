using ScoreBoardLib.Logic;
using ScoreBoardLib.Model;
using System;

namespace ScoreBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            GameManager gameManager = new GameManager(scoreBoard);

            GameMenu game = new GameMenu(gameManager);

            game.RunLoop();
        }
    }
}
