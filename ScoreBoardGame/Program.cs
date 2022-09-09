using ScoreBoardLib.Logic;
using ScoreBoardLib.Logic.Abstract;
using ScoreBoardLib.Model;
using ScoreBoardLib.Model.Abstract;
using System;

namespace ScoreBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IDataProvider dataProvider = new DataProvider();
            IGameManager gameManager = new GameManager(scoreBoard, dataProvider);

            GameMenu game = new GameMenu(gameManager);

            game.RunLoop();
        }
    }
}
