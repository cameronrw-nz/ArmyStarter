namespace ArmyStarter.Blazor.Provider
{
    public class AttackingModel
    {
        private int _numberOfModels;
        private int _attacksPerModel;

        public string Name { get; set; }

        public int ToHit { get; set; }

        public int Strength { get; set; }

        public decimal Attacks { get; set; }

        public int AP { get; set; }

        public int Damage { get; set; }

        public bool IsAutoHitting { get; set; }

        public bool IsRerollingHits { get; set; }

        public int NumberOfModels
        {
            get => _numberOfModels;
            set
            {
                _numberOfModels = value;
                Attacks = _numberOfModels * _attacksPerModel;
            }
        }

        public int AttacksPerModel
        {
            get => _attacksPerModel;
            set
            {
                _attacksPerModel = value;
                Attacks = _numberOfModels * _attacksPerModel;
            }
        }

    }
}