using Source.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        List<Player> SelectAllOfTeam(long teamId);
        void UpdateToCaptain(long id);
    }
}
