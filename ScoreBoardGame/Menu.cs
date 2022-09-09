using ScoreBoardLib.Logic;
using ScoreBoardLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardGame
{
    public class Menu
    {
        private GameManager GameManager { get; set; } = new GameManager();

        public void RunMenuLoop()
        {
            string userChoice;

            Console.WriteLine("Welcome to the Football World Cup Score Board!");
            Console.WriteLine("");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("");
                Console.WriteLine("1: Start Game");
                Console.WriteLine("2: Finish Game");
                Console.WriteLine("3: Store Finished Game");
                Console.WriteLine("4: Get Summary of Games");
                Console.WriteLine("5: Exit");
                Console.WriteLine("");
                Console.Write("Enter an option: ");

                userChoice = Console.ReadLine();
                Console.WriteLine("");

                switch (userChoice)
                {
                    case "1": // Start Game

                        (Match matchSt, eGameOptionResult resultSt) = GameManager.StartMatch();

                        if(resultSt == eGameOptionResult.MatchAlreadyStarted)
                            Console.WriteLine("Cannot start a new game because there is one already started, you must finish it first.");
                        else if(resultSt == eGameOptionResult.Ok)
                            Console.WriteLine($"Starting match: {matchSt.ToString()}");
                        else
                            Console.WriteLine("Cannot start a new game because there was an unknown error.");

                        break;
                    case "2": // Finish Game

                        (Match matchFn, eGameOptionResult resultFn) = GameManager.FinishMatch();

                        if (resultFn == eGameOptionResult.NoMatchToFinish)
                            Console.WriteLine("Cannot finish game because there isn't an already started game, you must start one first.");
                        else if (resultFn == eGameOptionResult.MatchFinishedButNotStored)
                            Console.WriteLine("Cannot finish game because there is one already finished but not yet stored, you must store it first.");
                        else if (resultFn == eGameOptionResult.Ok)
                            Console.WriteLine($"Finished match: {matchFn.ToString()}");
                        else
                            Console.WriteLine("Cannot finish game because there was an unknown error.");

                        break;

                    case "3": // Store Finished Game

                        eGameOptionResult resultStore = GameManager.StoreFinishedMatch();

                        if (resultStore == eGameOptionResult.NoMatchToStore)
                            Console.WriteLine("Cannot store game because there isn't an already finish game, you must have a finished game first.");
                        else if (resultStore == eGameOptionResult.Ok)
                            Console.WriteLine($"Game stored successfully.");
                        else
                            Console.WriteLine("Cannot store game because there was an unknown error.");

                        break;
                    case "4": // Get Summary

                        List<Match> matches = GameManager.GetSummaryByTotalScore();

                        Console.WriteLine("Summary of games by total score:");
                        Console.WriteLine("");

                        Console.WriteLine(FormatList(matches));

                        break;
                    case "5": // Exit

                        Console.WriteLine("Have a good day!");
                        Environment.Exit(0);

                        break;
                    default:

                        Console.WriteLine("Unrecognised option, please try again");

                        break;
                }


            } while (true);
        }

        private string FormatList(List<Match> matches)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < matches.Count; i++)
            {
                stringBuilder.AppendLine($"{(i + 1)}: {matches[i].ToString()}");
            }

            return stringBuilder.ToString();
        }
    }
}
