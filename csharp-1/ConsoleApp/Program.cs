using Codenation.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Object test = null;
                teste();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            //Console.WriteLine("Hello World!");
            //var manager = new SoccerTeamsManager();
            //manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");


            //manager.AddPlayer(0, 1, "Jogador 2", new DateTime(2003, 1, 1), 1, 0);
            
            //manager.AddPlayer(2, 1, "Jogador 1", new DateTime(1970, 1, 1), 12, 0);
            //manager.AddPlayer(3, 1, "Jogador 1", new DateTime(1987, 1, 1), 9, 0);
            //manager.AddPlayer(4, 1, "Jogador 1", new DateTime(1970, 1, 1), 10, 0);
            //manager.AddPlayer(1, 1, "Jogador 1", new DateTime(1998, 1, 1), 10, 0);
            //var topPlayers = manager.GetTopPlayers(4);
            //var oldID = manager.GetOlderTeamPlayer(1);
            //var bestId = manager.GetBestTeamPlayer(1);


        }

        static void teste()
        {
            throw new IndexOutOfRangeException();
        }

        public static void Should_Be_Unique_Ids_For_Teams()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
        }

        public static void Should_Be_Valid_Player_When_Set_Captain()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.SetCaptain(1);
            long captainId = manager.GetTeamCaptain(1);//1
            manager.SetCaptain(2);//PlayerNotFoundException
        }

        public static void Should_Ensure_Sort_Order_When_Get_Team_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() { 15, 2, 33, 4, 13 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Today, 0, 0);

            playersIds.Sort();
            var players = manager.GetTeamPlayers(1);//==playersIds
        }


        public static void Should_Choose_Best_Team_Player()
        {
            var testes = new Dictionary<string, int>() {
                { "10,20,300,40,50", 2 } ,
                { "50,240,3,1,50", 1 },
                { "10,22,24,3,24", 2 }
            };

            foreach (var teste in testes)
            {
                var manager = new SoccerTeamsManager();
                manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

                var skillsLevelList = teste.Key.Split(',').Select(x => int.Parse(x)).ToList();
                for (int i = 0; i < skillsLevelList.Count(); i++)
                    manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, skillsLevelList[i], 0);

                Console.WriteLine(teste.Value == manager.GetBestTeamPlayer(1));
            }


        }

        public static void Should_Choose_Right_Color_When_Get_Visitor_Shirt_Color(string teamColors, string visitorColors, string visitorMatchColor)
        {
            var testes = new List<List<string>>();
            {
                new List<string>() { "Azul;Vermelho", "Azul;Amarelo", "Amarelo" };
                new List<string>() { "Azul;Vermelho", "Amarelo;Laranja", "Amarelo" };
                new List<string>() { "Azul;Vermelho", "Azul;Vermelho", "Vermelho" };
            };

            long teamId = 1;
            long visitorTeamId = 2;
            var teamColorList = teamColors.Split(";");
            var visitorColorList = visitorColors.Split(";");

            var manager = new SoccerTeamsManager();
            manager.AddTeam(teamId, $"Time {teamId}", DateTime.Now, teamColorList[0], teamColorList[1]);
            manager.AddTeam(visitorTeamId, $"Time {visitorTeamId}", DateTime.Now, visitorColorList[0], visitorColorList[1]);

            Console.WriteLine(visitorMatchColor== manager.GetVisitorShirtColor(teamId, visitorTeamId));
        }
    }
}
