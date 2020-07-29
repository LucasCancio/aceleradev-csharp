using Codenation.Challenge.Exceptions;
using Source.Entities;
using Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source.Repositories
{
    public class TeamRepository : ITeamRepository
    {

        private readonly List<Team> teams = new List<Team>();
        public List<Team> SelectAll() => teams;

        public Team SelectByID(long id)
        {
            try
            {
                return teams.Where(p => p.id == id).First();
            }
            catch (Exception)
            {
                throw new TeamNotFoundException();
            }
        }

        public bool Insert(Team team)
        {
            if (teams.Any(t => t.Equals(team)))
            {
                return false;
            }
            teams.Add(team);
            return true;
        }

    }
}
