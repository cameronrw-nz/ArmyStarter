namespace ArmyStarter.Blazor.Provider
{
    public class AttackingModel
    {
        public string Name { get; set; }

        public int ToHit { get; set; }

        public int Strength { get; set; }

        public decimal Attacks { get; set; }

        public int AP { get; set; }

        public bool IsAutoHitting { get; set; }

        public bool IsRerollingHits { get; set; }
    }
}