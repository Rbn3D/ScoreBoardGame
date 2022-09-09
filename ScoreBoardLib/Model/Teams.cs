using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Model
{
    public class Teams
    {
        public static readonly string[] TeamList = new string[]
        {
            "Real Madrid",
            "FC Barcelona",
            "Villarreal",
            "Real Betis",
            "Osasuna",
            "Athletic",
            "Atlético de Madrid",
            "Celta de Vigo",
            "Real Sociedad",
            "Valencia",
            "Mallorca",
            "Girona",
            "Almería",
            "Rayo Vallecano",
            "Espanyol",
            "Real Valladolid",
            "Sevilla",
            "Elche",
            "Getafe",
            "Cádiz"
        };

        public static String GetRandomTeam()
        {
            Random rand = new Random();

            int index = rand.Next(TeamList.Length);
            return TeamList[index];
        }

        public static (String, String) GetRandomTeamPair()
        {
            Random rand = new Random();

            int index1 = rand.Next(TeamList.Length);
            int index2 = rand.Next(TeamList.Length);

            while(index2 == index1)
            {
                index2 = rand.Next(TeamList.Length);
            }

            return (TeamList[index1], TeamList[index2]);
        }
    }
}
