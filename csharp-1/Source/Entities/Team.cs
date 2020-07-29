using System;

namespace Source.Entities
{
    public class Team
    {
        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            this.id = id;
            this.name = name;
            this.createDate = createDate;
            this.mainShirtColor = mainShirtColor;
            this.secondaryShirtColor = secondaryShirtColor;
        }
        public long id { get; set; }
        public string name { get; set; }
        public DateTime createDate { get; set; }
        public string mainShirtColor { get; set; }
        public string secondaryShirtColor { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Team team = (Team)obj;
            return this.id == team.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
