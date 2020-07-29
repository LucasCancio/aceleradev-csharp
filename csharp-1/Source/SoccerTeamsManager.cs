using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.Entities;
using Source.Interfaces;
using Source.Repositories;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        public SoccerTeamsManager()
        {
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
        }



        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            var team = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);
            if (!_teamRepository.Insert(team)) throw new UniqueIdentifierException();
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            CheckIfTeamExists(teamId);

            var player = new Player(id, teamId, name, birthDate, skillLevel, salary);

            if (!_playerRepository.Insert(player)) throw new UniqueIdentifierException();
        }

        public void SetCaptain(long playerId)
        {
            _playerRepository.UpdateToCaptain(playerId);
        }

        public long GetTeamCaptain(long teamId)
        {
            CheckIfTeamExists(teamId);

            Player captain = _playerRepository
                 .SelectAllOfTeam(teamId)
                 .Where(p => p.isCaptain)
                 .SingleOrDefault();

            return captain == null ? throw new CaptainNotFoundException() : captain.id;
        }

        public string GetPlayerName(long playerId)
        {
            return _playerRepository.SelectByID(playerId).name;
        }

        public string GetTeamName(long teamId)
        {
            return _teamRepository.SelectByID(teamId).name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            CheckIfTeamExists(teamId);

            return _playerRepository
                 .SelectAllOfTeam(teamId)
                 .OrderBy(p => p.id)
                 .Select(p => p.id)
                 .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            CheckIfTeamExists(teamId);

            return _playerRepository
                .SelectAllOfTeam(teamId)
                .OrderByDescending(p => p.skillLevel)
                .FirstOrDefault()
                .id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            CheckIfTeamExists(teamId);

            return _playerRepository
                .SelectAllOfTeam(teamId)
                .OrderBy(p => p.birthDate)
                .FirstOrDefault()
                .id;
        }

        public List<long> GetTeams()
        {
            return _teamRepository
                .SelectAll()
                .OrderBy(t => t.id)
                .Select(t => t.id)
                .ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            CheckIfTeamExists(teamId);

            return _playerRepository
                .SelectAllOfTeam(teamId)
                .OrderByDescending(p => p.salary)
                .FirstOrDefault()
                .id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            return _playerRepository.SelectByID(playerId).salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            return _playerRepository
                .SelectAll()
                .OrderByDescending(p => p.skillLevel)
                .Take(top)
                .Select(p => p.id)
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team homeTeam = _teamRepository.SelectByID(teamId);
            Team visitorTeam = _teamRepository.SelectByID(visitorTeamId);

            if (homeTeam.mainShirtColor == visitorTeam.mainShirtColor)
            {
                return visitorTeam.secondaryShirtColor;
            }
            return visitorTeam.mainShirtColor;
        }

        private void CheckIfTeamExists(long teamId)
        {
            _teamRepository.SelectByID(teamId);
        }

    }
}
