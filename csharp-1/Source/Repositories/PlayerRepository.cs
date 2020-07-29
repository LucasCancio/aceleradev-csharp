using Codenation.Challenge.Exceptions;
using Source.Entities;
using Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> players= new List<Player>();
        public List<Player> SelectAll() => players.OrderBy(p => p.id).ToList();
        public List<Player> SelectAllOfTeam(long teamId)
        {
            return players
                        .Where(p => p.teamId == teamId)
                        .OrderBy(p => p.id)
                        .ToList();
        }

        public Player SelectByID(long id)
        {
            try
            {
                return players.Where(p => p.id == id).First();
            }
            catch (Exception)
            {
                throw new PlayerNotFoundException();
            } 
        }

        public bool Insert(Player player)
        {
            if (players.Any(p => p.Equals(player)))
            {
                return false;
            }
            players.Add(player);
            return true;
        }

        public void UpdateToCaptain(long id)
        {
            var player = SelectByID(id);
            players.ForEach(p => p.isCaptain = false);
            players.Where(p => p.id == id).SingleOrDefault().isCaptain = true;
        }
    }
}
