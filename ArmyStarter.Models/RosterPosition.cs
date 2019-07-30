using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyStarter.Models
{
    public class RosterPosition
    {
        [Column("Type")]
        [Key]
        public string Type
        {
            get { return RosterPositionEnum.ToString(); }
            private set { RosterPositionEnum = EnumExtensions.ParseEnum<RosterPositionType>(value); }
        }

        [NotMapped]
        public RosterPositionType RosterPositionEnum { get; set; }
    }

    public enum RosterPositionType
    {
        HQ,
        Elite,
        Troop,
        FastAttack,
        HeavySupport,
        Fortification,
        LordOfWar
    }

    public class EnumExtensions
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}