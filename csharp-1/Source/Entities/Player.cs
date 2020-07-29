using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Entities
{
    public class Player
    {
        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            this.id = id;
            this.teamId = teamId;
            this.name = name;
            this.birthDate = birthDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }
        public long id { get; set; }
        public long teamId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        //Nível de habilidade do jogador (0 a 100)
        public int skillLevel { get; set; }
        public decimal salary { get; set; }

        public bool isCaptain { get; set; }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Player player = (Player)obj;
            return this.id == player.id && this.teamId == player.teamId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
